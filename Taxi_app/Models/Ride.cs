using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Taxi_app.Models;

namespace Taxi_app.Models
{
    public class Ride
    {
        public int ID { get; set; }

        public int? StartLocationId { get; set; }
        [Display(Name = "Start location")]
        public virtual City StartLocation { get; set; }

        public int? EndLocationId { get; set; }
        [Display(Name = "Final destination")]
        public virtual City EndLocation { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public int? DriverId { get; set; } 
        public virtual Driver Driver { get; set; }

        public int? PassengerId { get; set; }
        [Display(Name = "Passenger")]
        public virtual Passenger Passenger { get; set; }

        [Required]
        public DateTime Time { get; set; }

    }
}