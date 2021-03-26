using System;
using Xunit;
using TestingAssignment.Controllers;
using TestingAssignment.Contracts;
using TestingAssignment.Model;
using TestingAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PassengerTesting
{
    public class PassengerControllerTest
    {
        PassengerController _controller;
        IPassenger _passenger;
        public PassengerControllerTest()
        {
            _passenger = new PassengerServices();
            _controller = new PassengerController(_passenger);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var OkResult = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(OkResult.Result);

        }

        [Fact]
        public void Return_Passenger()
        {
            //Act
            var OkResult = _controller.Get().Result as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<Passenger>>(OkResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Return_Not_Found()
        {
            //Act
            var notFoundResult = _controller.Get(4);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void ReturnOK()
        {
            //Arrange
            int testid = 3;

            //Act
            var okResult = _controller.Get(testid);

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

        }

        [Fact]
        public void ReturnRightPassenger()
        {
            //Arrange
            var testid = 1;

            //Act
            var okResult = _controller.Get(testid).Result as OkObjectResult;

            //Assert
            Assert.IsType<Passenger>(okResult.Value);
            Assert.Equal(testid, (okResult.Value as Passenger).Id);
        }

        [Fact]
        public void ReturnBadRequest()
        {
            //Arrange
            var missingField = new Passenger()
            {
                Id = 4,
                FirstName = "Miti",
                LastName = "Nayak"

            };
            _controller.ModelState.AddModelError("PhoneNumber", "Required");

            //Act
            var badResponse = _controller.Post(missingField);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
         public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            //Arrange
            var testPassnger = new Passenger()
            {
                Id = 4,
                FirstName = "Miti",
                LastName = "Nayak",
                PhoneNumber="12346789"

            };

            //Act
            var createdResponse = _controller.Post(testPassnger);

            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedPassenger()
        {
            //Arrange
            var testPassenger = new Passenger()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "12345678910"
            };

            //Act
            var createdResponse = _controller.Post(testPassenger) as CreatedAtActionResult;
            var passengerattribute = createdResponse.Value as Passenger;

            //Assert
            Assert.IsType<Passenger>(passengerattribute);
            Assert.Equal("Test", passengerattribute.FirstName);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnNotFoundResponse()
        {
            //Arrange
            var notExistingId = 6;

            //Act
            var badResponse = _controller.RemovePassenger(notExistingId);

            //Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void ReturnOkResult()
        {
            //Arrange
            var existingId = 2;

            //Act
            var okResponse = _controller.RemovePassenger(existingId);

            //Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemoveOnePassenger()
        {
            //Arrange
            var existingId = 2;

            //Act
            var okResponse = _controller.RemovePassenger(existingId);

            //Assert
            Assert.Equal(2, _passenger.GetAllPassengers().Count());
        }

        
    }
}
