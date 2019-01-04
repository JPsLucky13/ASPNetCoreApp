using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Entities
{
    public class Person
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        [ConcurrencyCheck]
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        [NotMapped]
        public List<Address> Addresses{get; set;}
    }
}
