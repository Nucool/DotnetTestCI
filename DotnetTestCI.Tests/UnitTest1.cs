using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotnetTestCI.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;
using System;

namespace DotnetTestCI.Tests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            //// Arrange
            //var controller = GetHomeController();
            //// Act
            //ViewResult result = (ViewResult)controller.Index();

            //Console.WriteLine("viewname : " + result.ViewName);
            //// Assert
            //Assert.AreEqual("Index", result.ViewName);
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
