using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAssignment.Model;

namespace TestingAssignment.Contracts
{
    public interface IPassenger
    {
        IEnumerable<Passenger> GetAllPassengers();
        Passenger AddPassenger(Passenger newPassenger);
        Passenger GetPassengerById(int id);
        void RemovePassenger(int id);
    }
}
