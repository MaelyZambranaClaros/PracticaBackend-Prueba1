using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaPruba1.Controllers;
using PracticaPruba1.Models;

namespace admPracticaPruba1.Tests.Controllers
{
    [TestClass]
    public class UnitTestPruba1
    {
        [TestMethod]
        public void TestGetPruba1()
        {
            //Arrange
            Pruba1Controller pruba1Controller = new Pruba1Controller(); //objeto

            //Act
            var ListaPruba1 = pruba1Controller.GetPruba1();

            //Assert
            Assert.IsNotNull(ListaPruba1);
        }

        [TestMethod]
        public void TestPostPruba1()
        {
            //Arrange
            Pruba1Controller pruba1Controller = new Pruba1Controller();
            Pruba1 PruebaEsperada = new Pruba1()
            {
                FriendofZambrana = "Daniel Zambrana",
                ZambranaID = 1,
                Email = "daniel@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo

            };

            //Act
            IHttpActionResult actionResult = pruba1Controller.PostPruba1(PruebaEsperada);
            var Pruba1Actual = actionResult as CreatedAtRouteNegotiatedContentResult<Pruba1>;


            //Assert
            Assert.IsNotNull(Pruba1Actual);
            Assert.AreEqual("DefaultApi", Pruba1Actual.RouteName);
            Assert.AreEqual(PruebaEsperada.FriendofZambrana, Pruba1Actual.Content.FriendofZambrana);
            Assert.AreEqual(PruebaEsperada.Email, Pruba1Actual.Content.Email);
            Assert.AreEqual(PruebaEsperada.Birthdate, Pruba1Actual.Content.Birthdate);
            Assert.AreEqual(PruebaEsperada.Place, Pruba1Actual.Content.Place);
        }

        [TestMethod]
        public void TestDelerePruba1()
        {
            //Arrange
            Pruba1Controller pruba1Controller = new Pruba1Controller();
            Pruba1 PruebaEsperada = new Pruba1()
            {
                FriendofZambrana = "Daniel Zambrana",
                ZambranaID = 1,
                Email = "daniel@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo

            };

            //Act
            IHttpActionResult actionResult=pruba1Controller.DeletePruba1(PruebaEsperada.ZambranaID);

            //Assert
            Assert.IsNotInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void TestPutPruba1()
        {
            //Arrange
            Pruba1Controller pruba1Controller = new Pruba1Controller();
            Pruba1 PruebaEsperada = new Pruba1()
            {
                FriendofZambrana = "Daniel Zambrana",
                ZambranaID = 1,
                Email = "daniel@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo

            };
            String newname = "Maely Zambrana";

            //Act
            var actionResult = pruba1Controller.PostPruba1(PruebaEsperada);
            PruebaEsperada.FriendofZambrana = newname;
            var actionResultPut = pruba1Controller.PutPruba1(PruebaEsperada.ZambranaID, PruebaEsperada) as StatusCodeResult;


            //Assert
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
}

