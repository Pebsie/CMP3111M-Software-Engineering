﻿
//public class Movie // the movie class for containing information about a movie
//{
//    public string Poster { get; set; } //image URL (.jpg)
//    public string Title { get; set; }
//    public string Year { get; set; } //string because some dates are ranges
//    public string imdbID { get; set; } //format: tt1234567
//    public string Type { get; set; }
//}

//public class OMDB
//{
//  //Default Constructor
//	public OMDB() {}

//	public List<Movie> search(string searchType, string userInput)
//	{
//		List<Movie> results = new List<Movie>();

//        using (WebClient web = new WebClient())
//        {
//            string jsonString = "";
//            JObject json;

//            switch (searchType)
//            {
//                case "Title":
//                    jsonString = web.DownloadString("http://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85");

//                    json = JObject.Parse(jsonString);

//                    foreach (var result in json["Search"])
//                    {
//                        Movie movTitle = new Movie();
//                        movTitle.Poster = result["Poster"].ToString();
//                        movTitle.Title = result["Title"].ToString();
//                        movTitle.Year = result["Year"].ToString();
//                        movTitle.imdbID = result["imdbID"].ToString();
//                        movTitle.Type = result["Type"].ToString();
//                        results.Add(movTitle);
//                    }

//                    break;

//                case "IMDb ID":
//                    jsonString = web.DownloadString("http://www.omdbapi.com/?i=" + userInput + "&apikey=ffa0df85");

//                    json = JObject.Parse(jsonString);

//                    Movie movID = new Movie();
//                    movID.Poster = json["Poster"].ToString();
//                    movID.Title = json["Title"].ToString();
//                    movID.Year = json["Year"].ToString();
//                    movID.imdbID = json["imdbID"].ToString();
//                    movID.Type = json["Type"].ToString();
//                    results.Add(movID);
//                    break;

//                default:
//                    //error
//                    break;
//            }
//        }
//        return results;
//	}
//}

//public class TMDB
//{
//    public TMDB() { }

//    public List<Movie> search(string searchType, string userInput)
//    {
//        List<Movie> results = new List<Movie>();

//        using (WebClient web = new WebClient())
//        {
//            string jsonString = "";
//            JObject json;
//            JObject idResponse;

//            switch (searchType)
//            {
//                case "Title":
//                    jsonString = web.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=ce3d10763b9e4dc46748c25948f710bc&query=" + userInput + "&page=1");

//                    json = JObject.Parse(jsonString);

//                    foreach (var result in json["results"])
//                    {
//                        Movie movTitle = new Movie();
//                        movTitle.Poster = "https://image.tmdb.org/t/p/w200" + result["poster_path"].ToString();
//                        movTitle.Title = result["title"].ToString();
//                        movTitle.Year = result["release_date"].ToString();

//                        string tmdbID = result["id"].ToString();
//                        string jsonTMDB = web.DownloadString("https://api.themoviedb.org/3/movie/" + tmdbID + "?api_key=ce3d10763b9e4dc46748c25948f710bc");
//                        idResponse = JObject.Parse(jsonTMDB);
//                        movTitle.imdbID = idResponse["imdb_id"].ToString();


//                        movTitle.Type = "Movie";
//                        results.Add(movTitle);
//                    }

//                    break;

//                case "IMDb ID":
//                    jsonString = web.DownloadString("https://api.themoviedb.org/3/find/" + userInput + "?api_key=ce3d10763b9e4dc46748c25948f710bc&external_source=imdb_id");

//                    json = JObject.Parse(jsonString);

//                    foreach (var result in json["movie_results"])
//                    {
//                        Movie movID = new Movie();
//                        movID.Poster = "https://image.tmdb.org/t/p/w200" + result["poster_path"].ToString();
//                        movID.Title = result["title"].ToString();
//                        movID.Year = result["release_date"].ToString();
//                        movID.imdbID = userInput;
//                        movID.Type = "Movie";
//                        results.Add(movID);
//                    }

//                    break;

//                default:
//                    //error
//                    break;
//            }
//        }
//        return results;
//    }
//}
