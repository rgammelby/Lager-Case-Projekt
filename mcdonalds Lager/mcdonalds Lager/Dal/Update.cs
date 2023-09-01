﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcdonalds_Lager.Dal
{
    internal class Update
    {
        const int MAX_AMOUNT = 99999;
        #region Update
        public static bool UpdateData(string table, int id, double amount,bool add)
        {
            // amount or litres
            var dts = DataAccessLayer.GetData($"SELECT * FROM {table} ");
            var aol = dts.Columns[dts.Columns.Count - 1];
            //Gets the name of the id
            var idName = dts.Columns[0];

            var getDataScript = $"SELECT {aol} FROM {table} " +
                $"WHERE {idName} = '{id}'";

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
            if (newAmount < 0 || newAmount >= MAX_AMOUNT)
            {             
                return false;
            }

            string newAmountstring = newAmount.ToString().Replace(',','.');
            // update script
            var script = "USE [StorageDB] " +
                $"UPDATE {table} " +
                $"SET {aol} = {newAmountstring} " +
                $"WHERE {idName} = {id} ";

            DataAccessLayer.ExecuteScript(script);
            return true;
        }



        #endregion
    }
}
