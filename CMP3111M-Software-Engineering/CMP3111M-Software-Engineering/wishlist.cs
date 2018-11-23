﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

public class wishlist 
    {

        /* This class deals with the wishlist.
          Wishlists are saved as list of IMDB IDs to prevent issues with multiple films with the same title and detail updates 
          The functions contained within the wishlist object are as follows:

            getWishlist() - Returns a list of type Movie with all movies currently in the wishlist
            addWishlist(string imdbID) - Checks if a movie already exists in the wishlist and if not adds a movie of imdbID to the wishlist. Displays "already in wishlist" if film is already in the wishlist.
            boolean isWishlist(string imdbID) - Checks if a movie is already in the wishlist and returns a bool.
         
         */

        public List<Movie> getWishlist()
        {
            List<Movie> results = new List<Movie>();

            API api = new API(); // create API instance to search the database by ID

            using (StreamReader sr = File.OpenText("wishlist.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                List<Movie> tMov = new List<Movie>();
                    tMov = api.search("IMDb ID", s);
                    if (tMov[0].Poster != null) // check for empty set
                    {
                        results.Add(tMov[0]); // add the first result from searching the ID
                    }
                }
            }
            return results;
        }

        public void addWishlist(string id)
        {
            if (!isWishlist(id))
            {
                using (StreamWriter w = File.AppendText("wishlist.txt"))
                {
                w.WriteLine(id);
                }
            } else
            {
                MessageBox.Show("This film is already in the wishlist!");
            }
        }

        public bool isWishlist(string id)
        {
            bool result = false;
            foreach (var tMov in getWishlist())
            {
                if (tMov.imdbID == id)
                {
                  result = true;
                }
            }

            return result;
        }
 
    }