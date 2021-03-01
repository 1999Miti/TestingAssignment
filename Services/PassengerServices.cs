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
                new Passenger(){Id=1,FirstName="Miti",LastName="Nayak",PhoneNumber="12345678910"},
                new Passenger(){Id=2,FirstName="Jahnavi",LastName="Shah",PhoneNumber="324567891"},
                new Passenger(){Id=3,FirstName="Riya",LastName="Patel",PhoneNumber="4563782900"}
        };
        }

        public IEnumerable<Passenger> GetAllPassengers()
        {
               return _passengerlist;
        }

        public Passenger AddPassenger(Passenger newPassenger)
        {
            newPassenger.Id = newPassenger.Id;
            _passengerlist.Add(newPassenger);
            return newPassenger;

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
