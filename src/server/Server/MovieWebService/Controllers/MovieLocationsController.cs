namespace MovieWebService.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Uber.Server.Core;
    using Uber.Server.ServiceModel;

    /// <summary>
    /// Movie location controller
    /// Supports:
    /// Get movielocations/{id}
    /// <Todo>Load origins from config in EnableCors</Todo>
    /// </summary>
     [EnableCors(origins: "http://cinerchweb.azurewebsites.net", headers: "*", methods: "*")]
    public class MovieLocationsController : ApiController
    {
        #region Private Fields

        /// <summary>
        /// Movie repository - Todo: this should not be static
        /// </summary>
        IMovieLocationRepository movieLocationRepository;

        #endregion

        #region Constructor

         /// <summary>
         /// Default constructor
         /// <Todo>Make connection string key as default. Add a post-build task to update connection string based on debug / release builds (test,prod)</Todo>
         /// </summary>
        public MovieLocationsController()
            : this(new MovieLocationRepository(
                new MovieDataStore(new Configuration(System.Configuration.ConfigurationManager.ConnectionStrings["Prod"].ToString()))))
        {

        }
         /// <summary>
         /// Movie location controller with movie location repository 
         /// </summary>
         /// <param name="movieLocationRepository"></param>
        public MovieLocationsController(IMovieLocationRepository movieLocationRepository)
        {
            this.movieLocationRepository = movieLocationRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets movie locations where the movie is played
        /// Web API: Get movielocation/{id}      
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns>Returns a collection of location instance
        /// e.g. json [{"LocationId":250,"Longitude":-122.486214,"Latitude":37.769421,"Name":"Golden Gate Park","FunFacts":"During San Francisco's Gold Rush era, the Park was part of an area designated as the \"Great Sand Waste\". "},...]
        /// </returns>
        public IEnumerable<Location> GetMovieLocations(int id)
        {
            IEnumerable<Location> locations = movieLocationRepository.GetMovieLocations(id);

            if (locations == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return locations;
        }

        #endregion
    }
}
