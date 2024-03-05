using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace KidKinder.Entities;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-A6C5CRN\\MSSQLSERVER01;database=KidKinderDb;Trusted_Connection=True;TrustServerCertificate=True");
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<KidClass> KidClasses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<GetInTouch> GetInTouches { get; set; }
    public DbSet<Kid> Kids { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}
