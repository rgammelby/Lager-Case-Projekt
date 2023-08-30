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

        static void UpdateData(string table, int id, int amount)
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
            var oldAmount = Convert.ToInt32(dt.Rows[0].ItemArray[0]);

            // updated amount
            var newAmount = Convert.ToInt32(oldAmount) - amount;

            // display error message if attempting to withdraw more items than are present in storage
            if (newAmount < 0)
            {
                WithdrawError(oldAmount, amount);
                return;
            }

            // testing
            //Console.Write($"\nOld amount: {oldAmount} \nAmount withdrawn: {amount} \nNew amount: {newAmount} \n");

            // update script
            var script = "USE [Storage] " +
                $"UPDATE {table} " +
                $"SET {aol} = {newAmount} " +
                $"WHERE {table}_id = {id} ";

            DataAccessLayer.ExecuteScript(script);
        }

        static void WithdrawError(int oldAmount, int amount)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You cannot withdraw more items than there are currently present in the database. \n" +
                $"There are currently {oldAmount} units in storage. You are trying to withdraw {amount} units. ");
            Console.ResetColor();
            Console.ReadLine();
        }

        #endregion
    }
}
