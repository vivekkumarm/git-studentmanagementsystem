/****************************************************************************************
                         CREATED BY  : Prasana
                         DESCRIPTION : BaseDataService Class
                         CREATED ON  : 16.07.2013 
 ****************************************************************************************/
#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading.Tasks;
using System.Configuration;
#endregion References

#region BaseDataService Class
namespace DataService
{
    public class BaseDataService
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>ConnectionString</returns>
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings[Constants.ConnectionString];
        }
    }
}
#endregion BaseDataService Class
