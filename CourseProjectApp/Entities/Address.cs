﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Entities
{
    [Table("Addresses",Schema = "Address")]
    public class Address
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int AddressId { get; set; }

        
        [Column("StreetAddress",TypeName ="varchar(300)")]
        public string StreetName{ get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [MaxLength(500)]
        public string ZipCode { get; set; }
        public int PersonId { get; set; }
        [NotMapped]
        public Person MyPerson{ get; set; }
    }
}
