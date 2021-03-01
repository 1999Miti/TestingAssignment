using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAssignment.Model;
using TestingAssignment.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace TestingAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassenger _service;

        public PassengerController(IPassenger service)
        {
            _service = service;
        }

        //GET api/Passenger
        [HttpGet]
        public ActionResult<IEnumerable<Passenger>> Get()
        {
            var passengers = _service.GetAllPassengers();
            return Ok(passengers);
        }

        //GET api/passenger/5
        [HttpGet("{id}")]
        public ActionResult<Passenger> Get(int id)
        {
            var passengers = _service.GetPassengerById(id);
            if(passengers == null)
            {
                return NotFound();
            }
            return Ok(passengers);
        }

        //POST api/passenger
        [HttpPost]
        public ActionResult Post([FromBody] Passenger value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passengers = _service.AddPassenger(value);
            return CreatedAtAction("Get", new { id = passengers.Id }, passengers);
        }

        //DELETE api/passenger/5
        [HttpDelete("{id}")]
        public ActionResult RemovePassenger(int id)
        {
            var existingPassenger = _service.GetPassengerById(id);
            if (existingPassenger == null)
            {
                return NotFound();
            }
            _service.RemovePassenger(id);
            return Ok();
        }
    }
}
