namespace Uber.Server.ServiceModel
{
    using System.Collections.Generic;
    using Uber.Server.Core;

    /// <summary>
    /// MovieData store interface.
    /// This represents a storage interface
    /// </summary>
    public interface IMovieDataStore
    {
        /// <summary>
        /// Gets all movie names
        /// </summary>
        /// <returns>Returns a dictionary object where key is movie name and id is movie id</returns>
        Dictionary<string, int> GetAllMovieNames();

        /// <summary>
        /// Gets a movie by id
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns a movie object</returns>
        Movie GetMovie(int movieId);

        /// <summary>
        /// Gets movie locations by movie id
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns all movie locations by movie id</returns>
        List<Location> GetMovieLocations(int movieId);
    }
}
