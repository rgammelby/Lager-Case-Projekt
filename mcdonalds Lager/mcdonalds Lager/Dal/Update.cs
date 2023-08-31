using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Dal
{
    internal class Update
    {
        const int MAX_AMOUNT = 32000;
        #region Update
        public static bool UpdateData(string table, int id, double amount,bool add)
        {
            // amount or litres
            var dt = DataAccessLayer.GetData($"SELECT * FROM {table} ");
            var aol = dt.Columns[dt.Columns.Count - 1];

            var getDataScript = $"SELECT {aol} FROM {table} " +
                $"WHERE {table}_id = '{id}'";

            // retrieves "old" data from database
            var dts = DataAccessLayer.GetData(getDataScript);

            // amount before update
            var oldAmount = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
            var newAmount = 0.0;
            if (add)
            {
                // updated amount
                newAmount = oldAmount + Convert.ToDouble(amount);
            }
            else
            {
                // updated amount
                newAmount = oldAmount - Convert.ToDouble(amount);
            }


            // display error message if attempting to withdraw more items than are present in storage
            if (newAmount < 0 || newAmount >= MAX_AMOUNT)
            {             
                return false;
            }

            string newAmountstring = newAmount.ToString().Replace(',','.');
            // update script
            var script = "USE [StorageDB] " +
                $"UPDATE {table} " +
                $"SET {aol} = {newAmountstring} " +
                $"WHERE {table}_id = {id} ";

            DataAccessLayer.ExecuteScript(script);
            return true;
        }



        #endregion
    }
}
