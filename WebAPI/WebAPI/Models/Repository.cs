using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class Repository: IRepository
    {
	    private bool _disposed = false;
		private readonly DBModel _context;

	    public Repository(DBModel context)
	    {
		    this._context = context;
	    }

	    public IEnumerable<object> GetQuestions()
	    {
		     var qns = _context.Questions
			    .Select(x => new
			    {
				    QnID = x.QnID,
				    Qn = x.Qn,
				    ImageName = x.ImageName,
				    x.Option1,
				    x.Option2,
				    x.Option3,
				    x.Option4
			    })
			    .OrderBy(y => Guid.NewGuid())
			    .Take(10).ToArray();

		    return qns.AsEnumerable()
			    .Select(x => new
			    {
				    QnID = x.QnID,
				    Qn = x.Qn,
				    ImageName = x.ImageName,
				    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
			    }).ToList();
		}

	    public IEnumerable<Question> GetAnswers(int qIDs)
	    {
		    throw new NotImplementedException();
	    }

	    protected virtual void Dispose(bool disposing)
	    {
		    if (!this._disposed)
		    {
			    if (disposing)
			    {
				    _context.Dispose();
			    }
		    }
		    this._disposed = true;
	    }

	    public void Dispose()
	    {
		    Dispose(true);
		    GC.SuppressFinalize(this);
	    }
	}
}
