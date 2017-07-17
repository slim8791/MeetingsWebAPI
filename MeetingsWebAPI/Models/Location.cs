using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingsWebAPI.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}