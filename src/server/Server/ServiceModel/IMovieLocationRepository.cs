namespace Uber.Server.ServiceModel
{
    using System.Collections.Generic;
    using Uber.Server.Core;

    /// <summary>
    /// IMovieLocationRepository interface
    /// Represents a repository interface for movie location clients
    /// </summary>
    public interface IMovieLocationRepository
    {
        /// <summary>
        /// Gets a collection of locations where the movie is played
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <returns>Returns a collection of locations</returns>
        IEnumerable<Location> GetMovieLocations(int movieId);
    }
}
