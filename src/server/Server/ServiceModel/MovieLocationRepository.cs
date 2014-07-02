namespace Uber.Server.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using Uber.Server.Core;

    /// <summary>
    /// Movie Location Repository
    /// This class is used from Web API
    /// <Todo>Add cache/memcache so that we don't have to fetch from database for each request if item is in the cache already</Todo>
    /// </summary>
    public class MovieLocationRepository : IMovieLocationRepository
    {
        #region Private Fields
        private IMovieDataStore movieDataStore;
        #endregion

        #region Constructor

        /// <summary>
        /// MovieLocationRepository constructor
        /// </summary>
        /// <param name="movieDataStore">Movie data store interface</param>
        public MovieLocationRepository(IMovieDataStore movieDataStore)
        {
            this.movieDataStore = movieDataStore;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets movie locations by movie id from movie data store
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns a collection of locations</returns>
        public IEnumerable<Location> GetMovieLocations(int movieId)
        {
            return movieDataStore.GetMovieLocations(movieId);
        }

        #endregion
    }
}
