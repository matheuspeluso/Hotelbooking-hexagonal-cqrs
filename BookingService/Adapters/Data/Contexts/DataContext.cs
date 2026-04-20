using Data.Maps;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        //DBSETS
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestMap());
            modelBuilder.ApplyConfiguration(new BookingMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
        }
    }
}
