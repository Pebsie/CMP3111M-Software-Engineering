﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MovieDatabase
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window
	{
		APIFactory apiFactory = new ConcreteAPIFactory();
		IAPI api;
		List<Movie> movies = new List<Movie>();
        public static List<Movie> wishList = new List<Movie>();
        

        public MainWindow()
		{
            InitializeComponent();
		}

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            wishList = read();
        }

        private void Search_OnClick(object sender,RoutedEventArgs e)
        {
			string searchType = cmbSearchType.Text;
			//reset movie output
			lbMovies.ItemsSource = "";

			if (cmbDatabase.Text == "OMDB")
			{
				api = apiFactory.createAPI(cmbDatabase.Text);
				movies = api.search(searchType, SearchBar.Text);
			}
			if (cmbDatabase.Text == "TMDB")
			{
				api = apiFactory.createAPI(cmbDatabase.Text);
				movies = api.search(searchType, SearchBar.Text);
			}

			lbMovies.ItemsSource = movies;

		}


        private void DeactivateWindow(Window current)
        {
            current.Hide();   
        }

            
        private void SearchInt(object sender, RoutedEventArgs e)
        {
            DeactivateWindow(this);
            MainWindow homepage = new MainWindow();
            homepage.Show();
        }

        private void WishInt(object sender, RoutedEventArgs e)
        {
            DeactivateWindow(this);
            WishList wishpage = new WishList();
            wishpage.Show();
        }

        private void AddToWish(object sender, RoutedEventArgs e)
        {         
            //Get current selection
            Movie CurrentSelection = lbMovies.SelectedItem as Movie;
            bool exists = false;

			if (CurrentSelection != null)
			{
				foreach (Movie mov in wishList)
				{
					if (mov.imdbID == CurrentSelection.imdbID)
					{
						MessageBox.Show("You already have this movie in your wishlist");
						exists = true;
					}
				}

				if (exists == false)
				{
					//Add to list 
					wishList.Add(CurrentSelection);
					write(wishList);

				}
			}
        }

        private void write(List<Movie> wish)
        {
            using (StreamWriter w = new StreamWriter("wishlist.txt", false))
            {
                foreach (Movie mov in wish)
                {
                    w.WriteLine(mov.imdbID);
                }
            }
        }

        private List<Movie> read()
        {
            List<Movie> results = new List<Movie>();

            if (File.Exists("wishlist.txt"))
            {
                using (StreamReader sr = File.OpenText("wishlist.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        List<Movie> wish = new List<Movie>();

						api = apiFactory.createAPI("OMDB");
						wish = api.search("IMDb ID", s);

                        if (wish.Count != 0) // check for empty set
                        {
                            results.Add(wish[0]); // add the first result from searching the ID
                        }
                    }
                }
            }
            return results;
        }

        private void Random_Id(object sender, RoutedEventArgs e)
        {
            
            //reset movie output
            lbMovies.ItemsSource = "";

            Random rng = new Random();

            int random_seed = rng.Next(0100000, 0500000);
            string random_string = random_seed.ToString();

            Console.WriteLine(random_seed);

			api = apiFactory.createAPI("OMDB");
			movies = api.search("IMDb ID", "tt" + "0" + random_string);

			lbMovies.ItemsSource = movies;

            
        }
    }
}
