using MyMovieBookingApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyMovieBookingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            using (var db = new MovieData())
            {
                var movieTitles = db.Movie
                                    .OrderBy(m => m.Title)
                                    .Select(m => m.Title)
                                    .ToList();

                MovieListBox.ItemsSource = movieTitles;
            }
        }

        private void InitDb_Click(object sender, RoutedEventArgs e)
        {
            TestDatabase.CreateAndSeed();
            MessageBox.Show("Base de données initialisée !");
            LoadMovies();
        }
    }

    public class TestDatabase
    {
        public static void CreateAndSeed()
        {
            using (var db = new MovieData())
            {
                if (!db.Movie.Any())
                {
                    var movie1 = new Movie
                    {
                        Title = "Inception",
                        ImageName = "inception.jpg",
                        Description = "A mind-bending thriller",
                        Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt"
                    };

                    var movie2 = new Movie
                    {
                        Title = "Interstellar",
                        ImageName = "interstellar.jpg",
                        Description = "A journey through space and time",
                        Cast = "Matthew McConaughey, Anne Hathaway"
                    };

                    var booking1 = new Booking
                    {
                        BookingDate = DateTime.Now,
                        NumberOfTickets = 2,
                        Movie = movie1
                    };

                    var booking2 = new Booking
                    {
                        BookingDate = DateTime.Now.AddDays(1),
                        NumberOfTickets = 4,
                        Movie = movie2
                    };

                    db.Movie.Add(movie1);
                    db.Movie.Add(movie2);
                    db.Booking.Add(booking1);
                    db.Booking.Add(booking2);
                    db.SaveChanges();
                }
            }
        }
    }
}
