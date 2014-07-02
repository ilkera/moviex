namespace Uber.Server.Core
{
    /// <summary>
    /// Movie entity class
    /// </summary>
    public class Movie
    {
        #region Public Properties

        /// <summary>
        /// Movie Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Movie Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Movie Release Year
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Movie Production Company
        /// </summary>
        public string ProductionCompany { get; set; }

        /// <summary>
        /// Movie Distributor
        /// </summary>
        public string Distributor { get; set; }

        /// <summary>
        /// Movie Director
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// Movie Writer
        /// </summary>
        public string Writer { get; set; }
        
        /// <summary>
        /// Movie Actor 1
        /// </summary>
        public string Actor1 { get; set; }

        /// <summary>
        /// Movie Actor 2
        /// </summary>
        public string Actor2 { get; set; }

        /// <summary>
        /// Movie Actor 3
        /// </summary>
        public string Actor3 { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Movie Constructor
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="title"></param>
        /// <param name="releaseYear"></param>
        /// <param name="productionCompany"></param>
        /// <param name="distributor"></param>
        /// <param name="director"></param>
        /// <param name="writer"></param>
        /// <param name="actor1"></param>
        /// <param name="actor2"></param>
        /// <param name="actor3"></param>
        public Movie(
            int movieId,
            string title,
            int releaseYear,
            string productionCompany = null,
            string distributor = null, 
            string director = null, 
            string writer = null, 
            string actor1 = null,
            string actor2 = null,
            string actor3 = null)
        {
            Id = movieId;
            Title = title;
            ReleaseYear = releaseYear;
            ProductionCompany = productionCompany;
            Distributor = distributor;
            Director = director;
            Writer = writer;
            Actor1 = actor1;
            Actor2 = actor2;
            Actor3 = actor3;
        }

        #endregion
    }
}
