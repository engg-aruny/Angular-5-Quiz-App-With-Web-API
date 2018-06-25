using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Controllers;
using WebAPI.Models;

namespace Quiz.Integration.Test
{
	[TestClass]
	public class QuizControllerTest
	{
		private readonly IRepository _repository;

		public QuizControllerTest()
		{
			this._repository = new Repository(new DBModel());
		}

		[TestMethod]
		public void GetQuestions()
		{
			// Arrange
			var controller = new QuizController(_repository)
			{
				Request = new HttpRequestMessage(),
				Configuration = new HttpConfiguration()
			};

			// Act
			var response = controller.GetQuestions();

			// Assert
			Object question;
			Assert.IsTrue(response.TryGetContentValue<object>(out question));
			Assert.IsNotNull(question);

		}
	}
}
