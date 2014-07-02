namespace Uber.Server.Core
{
    /// <summary>
    /// Location Class
    /// </summary>
    public class Location
    {
        #region Properties
        /// <summary>
        /// LocationId
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Location Friendly Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Fun facts
        /// </summary>
        public string FunFacts { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Location constructor
        /// </summary>
        /// <param name="locationId">Location Id</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="locationName">Location name</param>
        /// <param name="funFacts">Fun facts about location</param>
        public Location(int locationId, double longitude, double latitude, string locationName, string funFacts)
        {
            LocationId = locationId;
            Latitude = latitude;
            Longitude = longitude;
            Name = locationName;
            FunFacts = funFacts;
        }
        #endregion

    }
}
