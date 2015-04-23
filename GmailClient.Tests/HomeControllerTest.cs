using System;
using System.Web.Mvc;
using GmailClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GmailClient.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
