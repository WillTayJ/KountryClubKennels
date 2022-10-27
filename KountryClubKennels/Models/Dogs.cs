//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KountryClubKennels.Models
{
    public class Dogs
    {
        public int id { get; set; }
        [Display(Name = "Photo")]
        public string photoPath { get; set; }
        [Display(Name = "Breed")]
        public string breed { get; set; }
        [Display(Name = "AKC Type")]
        public string akctype { get; set; }
        [Display(Name = "Birthday")]
        public DateTime birthday { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
    }

    public class KCKContext : DbContext
    {
        public DbSet<Dogs> dogs { get; set; }
    }
}