using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingsWebAPI.Models
{
    public class Coffee
    {
        public Coffee()
        {
            Meets = new List<Meet>();
        }
        public int CoffeeId { get; set; }
        public String Nom { get; set; }
        public String Adresse { get; set; }
        public String Tel { get; set; }
        public virtual ICollection<Meet> Meets { get; set; }
        
    }
}