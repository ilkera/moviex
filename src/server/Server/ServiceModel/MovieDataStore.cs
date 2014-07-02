namespace Uber.Server.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Uber.Server.Core;

    /// <summary>
    /// MovieDataStore class
    /// This class connects to database and fetch movie and movie locations
    /// </summary>
    public class MovieDataStore : IMovieDataStore
    {
        #region Private Fields

        /// <summary>
        /// Configuration instance
        /// </summary>
        private Configuration config;

        #endregion

        #region Constructor

        /// <summary>
        /// MovieDataStore constructor
        /// </summary>
        /// <param name="config">Configuration instance</param>
        public MovieDataStore(Configuration config)
        {
            this.config = config;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all movie names from database.
        /// </summary>
        /// <returns>Returns a dictionary object where key is movie name (title) and the value is movie id</returns>
        public Dictionary<string, int> GetAllMovieNames()
        {
            IEnumerable<IDataRecord> movieData = GetAllMovieNamesFromDB();

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var movie in movieData)
            {
                if (movie == null)
                {
                    break;
                }

                result.Add(movie[MovieSchemaColumns.MOVIE_TITLE].ToString(), Convert.ToInt32(movie[MovieSchemaColumns.MOVIE_MOVIEID].ToString()));
            }

            return result;
        }

        /// <summary>
        /// Gets a movie from database by movie id
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns movie instance. Null if no matching movie is found</returns>
        public Movie GetMovie(int movieId)
        {
            Movie result = null;

            string sql = string.Format("select * from {0} where {1} = @movieId", MovieDBTables.MOVIE, MovieSchemaColumns.MOVIE_MOVIEID);

            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@movieId", movieId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            result = new Movie(
                                movieId: Convert.ToInt32(reader[MovieSchemaColumns.MOVIE_MOVIEID]),
                                title: reader[MovieSchemaColumns.MOVIE_TITLE].ToString(),
                                releaseYear: Convert.ToInt32(reader[MovieSchemaColumns.MOVIE_RELEASEYEAR]),
                                productionCompany: reader[MovieSchemaColumns.MOVIE_PRODUCTIONCOMPANY].ToString(),
                                distributor: reader[MovieSchemaColumns.MOVIE_DISTRIBUTOR].ToString(),
                                director: reader[MovieSchemaColumns.MOVIE_DIRECTOR].ToString(),
                                writer: reader[MovieSchemaColumns.MOVIE_WRITER].ToString(),
                                actor1: reader[MovieSchemaColumns.MOVIE_ACTOR1].ToString(),
                                actor2: reader[MovieSchemaColumns.MOVIE_ACTOR2].ToString(),
                                actor3: reader[MovieSchemaColumns.MOVIE_ACTOR3].ToString());
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Gets movie locations by movie id from database
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns a collection of location objects</returns>
        public List<Location> GetMovieLocations(int movieId)
        {
            List<Location> locations = new List<Location>();

            string movieLocationSql = string.Format(
                "select L.{0}, {1}, {2}, {3}, {4} from {5} M inner join {6} L on M.{7} = L.{8} where M.{9} = @movieId",
                LocationSchemaColumns.LOCATION_LOCATIONID,
                LocationSchemaColumns.LOCATION_NAME,
                LocationSchemaColumns.LOCATION_LONGITUDE,
                LocationSchemaColumns.LOCATION_LATITUDE,
                LocationSchemaColumns.LOCATION_FUNFACTS,
                MovieDBTables.MOVIELOCATION,
                MovieDBTables.LOCATION,
                MovieLocationSchemaColumns.MOVIELOCATION_LOCATIONID,
                LocationSchemaColumns.LOCATION_LOCATIONID,
                MovieLocationSchemaColumns.MOVIELOCATION_MOVIEID);

            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(movieLocationSql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@movieId", movieId);
 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Location location = new Location(
                                Convert.ToInt32(reader[LocationSchemaColumns.LOCATION_LOCATIONID].ToString()),
                                Convert.ToDouble(reader[LocationSchemaColumns.LOCATION_LONGITUDE].ToString()),
                                Convert.ToDouble(reader[LocationSchemaColumns.LOCATION_LATITUDE].ToString()),
                                reader[LocationSchemaColumns.LOCATION_NAME].ToString(),
                                reader[LocationSchemaColumns.LOCATION_FUNFACTS].ToString());

                            locations.Add(location);
                        }

                    }
                }
            }

            return locations;
        }

        #endregion

        #region Helper methods (Private)

        /// <summary>
        /// Gets all movie names from database
        /// </summary>
        /// <returns>Returns a list of data reader record</returns>
        private IEnumerable<IDataRecord> GetAllMovieNamesFromDB()
        {
            string sql = string.Format(
                "select {0}, {1} from {2}",
                MovieSchemaColumns.MOVIE_MOVIEID,
                MovieSchemaColumns.MOVIE_TITLE,
                MovieDBTables.MOVIE);

            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader;
                        }
                        yield return null;
                    }
                }
            }
        }

        #endregion
    }
}
