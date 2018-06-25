using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IRepository : IDisposable
    {
	    IEnumerable<object> GetQuestions();

	    IEnumerable<Question> GetAnswers(int qIDs);
    }
}
