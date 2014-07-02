namespace Uber.Server.ServiceModel
{
    /// <summary>
    /// Configuration class
    /// </summary>
    public class Configuration
    {
        #region Constructor
        /// <summary>
        /// Configuration constructor
        /// </summary>
        /// <param name="connectionString">Connection string to be used</param>
        public Configuration(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString { get; private set; }

        #endregion
    }
}
