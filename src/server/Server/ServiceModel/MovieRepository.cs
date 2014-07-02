namespace Uber.Server.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using Uber.Server.Core;

    /// <summary>
    /// MovieRepository
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        #region Private Fields
        private IMovieDataStore movieDataStore;
        #endregion

        #region Constructor
        public MovieRepository(IMovieDataStore movieDataStore)
        {
            this.movieDataStore = movieDataStore;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets movie by movie id
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns a movie instance</returns>
        public Movie GetMovieById(int movieId)
        {
            return movieDataStore.GetMovie(movieId);
        }

        /// <summary>
        /// Gets all movies from movie data store.
        /// Used for movie suggestions
        /// </summary>
        /// <returns>Returns a dictionary where key is the movie name and value is the movie id</returns>
        public Dictionary<string, int> GetAllMovieNames()
        {
            return movieDataStore.GetAllMovieNames();
        }
        #endregion
    }
}
