using MyMovieBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyMovieBookingApp.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
    }
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public class MovieData : DbContext
    {
        public MovieData() : base("ODD_Exam Aymeric Leclerre") { }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}

