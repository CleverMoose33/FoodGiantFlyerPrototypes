using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using FoodGiantFlyerGenerator.Model;

namespace FoodGiantFlyerGenerator
{
    /// <summary>
    /// This class will establish connections to the SQL database and return data based on queries
    /// </summary>
    public class DatabaseInterface
    {
        string dbConnStr;
        public DatabaseInterface()
        {
            dbConnStr = Properties.Settings.Default.FoodGiantSQLDatabaseConn;
        }

        /// <summary>
        /// Queries and Populates all items from the ItemList Table
        /// </summary>
        public void PullItems()
        {
            List<string> resultsString = new List<string>();

            SqlCommand cmd = new SqlCommand();
            SqlConnection dbConn = new SqlConnection(dbConnStr);

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ItemList";

            dbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            try
            {
                while (reader.Read())
                {
                    try
                    {
                        IDataRecord record = (IDataRecord)reader;
                        string itemName = (string)reader["Item Name"];
                        string itemCat = (string)reader["Item Category"];
                        string imageName1 = (string)reader["Image Name 1"];

                        string imageName2 = "";
                        if (!string.IsNullOrEmpty(reader["Image Name 2"].ToString()))
                        {
                            imageName2 = (string)reader["Image Name 2"];
                        }

                        string imageName3 = "";
                        if (!string.IsNullOrEmpty(reader["Image Name 3"].ToString()))
                        {
                            imageName3 = (string)reader["Image Name 3"];
                        }

                        FlyerDataModel flyerItem = new FlyerDataModel(itemName, itemCat, imageName1, imageName2, imageName3);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Has Occured");
                    }

                }
            }
            finally
            {
                reader.Close();
            }
            dbConn.Close();
        }

        public void AddNewItem(FlyerDataModel newItem)
        {

        }
    }
}
