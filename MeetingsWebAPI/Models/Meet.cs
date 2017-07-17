using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingsWebAPI.Models
{
    public class Meet
    {
        public int MeetId { get; set; }
        public DateTime DateMeet { get; set; }
        public String Decription { get; set; }

        [ForeignKey("Coffee")]
        public int CoffeeId { get; set; }
        public virtual Coffee Coffee { get; set; }
        public virtual ICollection<Person> Personnes { get; set; }
        public Meet()
        {
            Personnes = new List<Person>();
        }
    }
}