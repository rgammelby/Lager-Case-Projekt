using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Logic
{
    internal class Getdata
    {
        /// <summary>
        /// Gets alle the data from a chosen table from the sql database(DB)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static DataTable GetDatabaseItems(string table)
        {
            var dt = DataAccessLayer.GetData($"SELECT * FROM {table}");
            return dt;
        }
    }
}
