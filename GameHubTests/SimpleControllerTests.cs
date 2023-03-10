using GameHub.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GameHubTests
{
    // this file contains unit tests for the methods in the GameHub web app SimpleController file
    [TestClass]
    public class SimpleControllerTests
    {
        [TestMethod]
        public void IndexReturnsSomething()
        {
            // arrange - set up conditions to try the Index method 
            var controller = new SimpleController();

            // act - execute the Index method
            var result = controller.Index();

            // assert - did the method return something and not a null reponse?
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            // arrange - set up conditions to try the Index method 
            var controller = new SimpleController();

            // act - execute the Index method
            var result = (ViewResult)controller.Index();

            // assert - is the result the Index view?
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexViewDataShowsCurrentDate()
        {
            // arrange
            var controller = new SimpleController();

            // act
            var result = (ViewResult)controller.Index();

            // assert
            Assert.AreEqual("Today is " + DateTime.Today.ToString(), result.ViewData["Message"].ToString());
        }
    }
}