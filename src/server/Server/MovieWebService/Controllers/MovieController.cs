namespace MovieWebService.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Uber.Server.Core;
    using Uber.Server.ServiceModel;

    /// <summary>
    /// MovieController
    /// Supports;
    /// GET Movies - Returns all movie names
    /// GET Movie/{id} - Returns a specific movie 
    /// Note: Cors is enabled so that Client can access to we service
    /// <Todo>Load origins url from config</Todo>
    /// </summary>
     [EnableCors(origins: "http://cinerchweb.azurewebsites.net", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        #region Private Fields

        /// <summary>
        /// Movie repository - Todo: this should not be static
        /// </summary>
        IMovieRepository movieRepository;

        #endregion

        #region Constructor

         /// <summary>
         /// Default movie controller constructor
         /// </summary>
        public MovieController() : this(
            new MovieRepository(new MovieDataStore(new Uber.Server.ServiceModel.Configuration(ConfigurationManager.ConnectionStrings["Prod"].ToString()))))
        {

        }

         /// <summary>
         /// Movie controller constructor with a repository
         /// </summary>
         /// <param name="movieRepository">Movie repository</param>
        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        #endregion

        #region Public Methdods

        /// <summary>
        /// Gets all movie titles
        /// Web API: Get movie
        /// </summary>
        /// <returns>Returns a collection of key value pair objects where key is movie title and value is movie id
        /// e.g. json {"data":8,"value":"Alexander's Ragtime Band"}
        /// </returns>
        public HttpResponseMessage GetMovies()
        {
            List<object> list = new List<object>();

            foreach (KeyValuePair<string,int> movie in movieRepository.GetAllMovieNames())
            {
                list.Add(new { data = movie.Value, value = movie.Key });
            }

            return this.Request.CreateResponse(HttpStatusCode.OK,  list);
        }

        /// <summary>
        /// Gets movie by movie id
        /// Web API: Get movie/{id}
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns>Returns movie instance. If movie doesn't exist, 
        /// it will return <c href="HttpResponseException">HttpResponseException</c>
        /// e.g. json {"Id":1,"Title":"A Jitney Elopement","ReleaseYear":1915,"ProductionCompany":"The Essanay Film Manufacturing Company","Distributor":"General Film Company","Director":"Charles Chaplin","Writer":"Charles Chaplin","Actor1":"Charles Chaplin","Actor2":"","Actor3":""}
        /// </returns>
        public Movie GetMovie(int id)
        {
            Movie movie = movieRepository.GetMovieById(id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movie;
        }

        #endregion
    }
}
