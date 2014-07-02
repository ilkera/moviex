namespace Uber.Server.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using Uber.Server.Core;

    /// <summary>
    /// Interface for movie repository
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Gets movie instance by movie id
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns movie instance associated with specified movie id</returns>
        Movie GetMovieById(int movieId);

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>Returns a collection of movies</returns>
        Dictionary<string, int> GetAllMovieNames();
    }
}
