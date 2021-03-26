using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAssignment.Contracts;
using TestingAssignment.Model;

namespace TestingAssignment.Services
{
    public class PassengerServices : IPassenger 
    {
        private  List<Passenger> _passengerlist;
        public PassengerServices()
        {
            _passengerlist = new List<Passenger>()
            {
                new Passenger(){Id=1,FirstName="Test",LastName="Test",PhoneNumber="12345678910"},
                new Passenger(){Id=2,FirstName="Test 1",LastName="Test1",PhoneNumber="4889516548"},
                new Passenger(){Id=3,FirstName="test 2",LastName="test2",PhoneNumber="84891561548"}
        };
        }

        public IEnumerable<Passenger> GetAllPassengers()
        {
               return _passengerlist;
        }

        public Passenger AddPassenger(Passenger model)
        {
            model.Id = model.Id;
            _passengerlist.Add(model);
            return model;

        }

        public Passenger GetPassengerById(int id)
        {
            return _passengerlist.Where(a => a.Id == id).FirstOrDefault();
        }

        public void RemovePassenger(int id)
        {
            var existing = _passengerlist.First(async => async.Id == id);
            _passengerlist.Remove(existing);
        }
    }
}
