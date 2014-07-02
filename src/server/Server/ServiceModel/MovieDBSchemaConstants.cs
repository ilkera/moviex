using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Server.ServiceModel
{   
    /// <summary>
    /// MovieDB Tables 
    /// </summary>
    public class MovieDBTables
    {
        public static readonly string MOVIE = "Movie";
        public static readonly string LOCATION = "Location";
        public static readonly string MOVIELOCATION = "MovieLocation";
    }

    /// <summary>
    /// Location schema columns mapping
    /// </summary>
    public class LocationSchemaColumns
    {

        public static readonly string LOCATION_LOCATIONID = "locationId";
        public static readonly string LOCATION_NAME = "name";
        public static readonly string LOCATION_LONGITUDE = "longitude";
        public static readonly string LOCATION_LATITUDE = "latitude";
        public static readonly string LOCATION_FUNFACTS = "funfacts";
    }

    /// <summary>
    /// Movie schema columns mapping
    /// </summary>
    public class MovieSchemaColumns
    {
        public static readonly string MOVIE_MOVIEID = "movieId";
        public static readonly string MOVIE_TITLE = "title";
        public static readonly string MOVIE_RELEASEYEAR = "releaseYear";
        public static readonly string MOVIE_PRODUCTIONCOMPANY = "productionCompany";
        public static readonly string MOVIE_DISTRIBUTOR = "distributor";
        public static readonly string MOVIE_DIRECTOR = "director";
        public static readonly string MOVIE_WRITER = "writer";
        public static readonly string MOVIE_ACTOR1 = "actor1";
        public static readonly string MOVIE_ACTOR2 = "actor2";
        public static readonly string MOVIE_ACTOR3 = "actor3";
    }

    /// <summary>
    /// Movie location schema columns mapping
    /// </summary>
    public class MovieLocationSchemaColumns
    {
        public static readonly string MOVIELOCATION_MOVIEID = "movieId";
        public static readonly string MOVIELOCATION_LOCATIONID = "locationId";
    }
}
