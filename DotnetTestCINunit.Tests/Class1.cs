using DotnetTestCI.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotnetTestCINunit.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void HelloWorldTest()
        {
            Assert.True(true);
        }

        [Test]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetHomeController();
            // Act
            ViewResult result = (ViewResult)controller.Index();

            Console.WriteLine("viewname : " + result.ViewName);
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        private static HomeController GetHomeController()
        {
            HomeController controller = new HomeController();

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }
}
