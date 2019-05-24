using System;
using System.Collections.Generic;
using System.Text;
using Goddess_s_Wardrode1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Goddess_s_Wardrode1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FashionWomen> FashionWomens { get; set; }
        public DbSet<ChineseCheongsam> ChineseCheongsams { get; set; }
    }
}
