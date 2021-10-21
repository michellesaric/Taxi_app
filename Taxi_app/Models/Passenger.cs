using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_app.Models;

namespace Taxi_app.Models
{
    public class Passenger : Person
    {
        public ICollection<Ride> Rides { get; set; }
    }
}