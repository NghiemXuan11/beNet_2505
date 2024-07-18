using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using WebMVC_NetFrameWork.Models;

namespace WebMVC_NetFrameWork.Models
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}