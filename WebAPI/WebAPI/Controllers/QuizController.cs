using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	public class QuizController : ApiController
	{
		private readonly IRepository _repository;

		public QuizController()
		{
			this._repository = new Repository(new DBModel());
		}

		public QuizController(IRepository repository)
		{
			this._repository = repository;
		}



		[HttpGet]
		[Route("api/Questions")]
		public HttpResponseMessage GetQuestions()
		{
			return this.Request.CreateResponse(HttpStatusCode.OK, _repository.GetQuestions());
		}

		[HttpPost]
		[Route("api/Answers")]
		public HttpResponseMessage GetAnswers(int[] qIDs)
		{
			using (DBModel db = new DBModel())
			{
				var result = db.Questions
					 .AsEnumerable()
					 .Where(y => qIDs.Contains(y.QnID))
					 .OrderBy(x => { return Array.IndexOf(qIDs, x.QnID); })
					 .Select(z => z.Answer)
					 .ToArray();
				return this.Request.CreateResponse(HttpStatusCode.OK, result);
			}
		}
	}
}
