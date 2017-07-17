using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingsWebAPI.Models
{
    public class PersonMeet
    {
       [Key, Column(Order = 0), ForeignKey("Meet")]
       public int MeetId { get; set; }
       [Key, Column(Order = 1), ForeignKey("Person")]
       public int PersonId { get; set; }

        public virtual Meet Meet { get; set; }
        public virtual Person Person { get; set; }
    }
}