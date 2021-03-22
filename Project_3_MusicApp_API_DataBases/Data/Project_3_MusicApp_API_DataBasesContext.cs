using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_3_MusicApp_API_DataBases.Models;

namespace Project_3_MusicApp_API_DataBases.Data
{
    public class Project_3_MusicApp_API_DataBasesContext : DbContext
    {
        public DbSet<Project_3_MusicApp_API_DataBases.Models.Song> Song { get; set; }

        public Project_3_MusicApp_API_DataBasesContext (DbContextOptions<Project_3_MusicApp_API_DataBasesContext> options)
            : base(options)
        {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Song>().HasData(new Models.Song() { ID = new Guid("551E9DAB-B73E-4322-8200-BFAB4A214D9F"), Name = "I'll Live in Glory", Composer = "Whisnants", Year = 2007 });
            modelBuilder.Entity<Models.Song>().HasData(new Models.Song() { ID = new Guid("D20287C1-F990-46D2-9698-6897F81E23E0"), Name = "East to West", Composer = "Casting Crowns", Year = 2010});
            modelBuilder.Entity<Models.Song>().HasData(new Models.Song() { ID = new Guid("5DCCA768-86E0-4745-A93D-9F2E268A75C1"), Name = "What Faith Can Do", Composer = "Kutless", Year = 2009});
        }

    }
}
