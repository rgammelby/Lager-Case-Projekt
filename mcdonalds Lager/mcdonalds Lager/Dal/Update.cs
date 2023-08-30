using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Dal
{
    internal class Update
    {
        #region Update

        public static bool UpdateData(string table, int id, double amount,bool add)
        {
            // amount or litres
            var aol = "";

            if (table.ToLower() == "water")
                aol = "amount";
            else
                aol = "litres";

            var getDataScript = $"SELECT {aol} FROM {table} " +
                $"WHERE {table}_id = '{id}'";

            // retrieves "old" data from database
            var dt = DataAccessLayer.GetData(getDataScript);

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
            if (newAmount < 0 || newAmount >= 32000)
            {             
                return false;
            }


            // testing
            //Console.Write($"\nOld amount: {oldAmount} \nAmount withdrawn: {amount} \nNew amount: {newAmount} \n");

            string newAmountstring = newAmount.ToString().Replace(',','.');
            // update script
            var script = "USE [Storage] " +
                $"UPDATE {table} " +
                $"SET {aol} = {newAmountstring} " +
                $"WHERE {table}_id = {id} ";

            DataAccessLayer.ExecuteScript(script);
            return true;
        }



        #endregion
    }
}
