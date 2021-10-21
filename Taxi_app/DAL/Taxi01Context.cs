using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taxi_app.Models;

namespace Taxi_app.DAL
{
    public class Taxi01Context : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<City> Cities { get; set; }

        public System.Data.Entity.DbSet<Taxi_app.Models.Person> People { get; set; }
    }
}