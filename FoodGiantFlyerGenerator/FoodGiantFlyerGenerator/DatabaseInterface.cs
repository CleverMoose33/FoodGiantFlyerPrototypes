using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using FoodGiantFlyerGenerator.Model;
using Caliburn.Micro;

namespace FoodGiantFlyerGenerator
{
    /// <summary>
    /// This class will establish connections to the SQL database and return data based on queries
    /// </summary>
    public class DatabaseInterface
    {
        private string dbConnStr;

        private BindableCollection<FlyerDataModel> flyerDBItemsList = new BindableCollection<FlyerDataModel>();

        public DatabaseInterface()
        {
            dbConnStr = Properties.Settings.Default.FoodGiantSQLDatabaseConn;
        }

        /// <summary>
        /// Queries and Populates all items from the ItemList Table
        /// </summary>
        public BindableCollection<FlyerDataModel> PullItems()
        {
            //If we have not already generated list of flyer items, then populate list else, pull existing list of items
            if (flyerDBItemsList.Count == 0)
            {
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
                            IDataRecord record = reader;
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

                            flyerDBItemsList.Add(flyerItem);
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
            return flyerDBItemsList;
        }

        /// <summary>
        /// Add new item to database, clear out flyer list
        /// </summary>
        /// <param name="newItem"></param>
        public void AddNewItem(FlyerDataModel newItem)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection dbConn = new SqlConnection(dbConnStr);

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;

            //Check if data already exists
            cmd.CommandText = "SELECT * FROM INTO ItemList (Item Name, Item Category, Image Name 1, Image Name 2, Image Name 3) VALUES" +
            "'" + newItem.ItemName + "' , '" + newItem.ItemCategory + "' , '" + newItem.ImgName1 + "' , '" + newItem.ImgName2 + "' , '" + newItem.ImgName3;

            dbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            if (reader.HasRows)
                MessageBox.Show("Data Already Exists");
            else
            {
                cmd.CommandText = "INSERT INTO ItemList (Item Name, Item Category, Image Name 1, Image Name 2, Image Name 3) VALUES" +
                    "'" + newItem.ItemName + "' , '" + newItem.ItemCategory + "' , '" + newItem.ImgName1 + "' , '" + newItem.ImgName2 + "' , '" + newItem.ImgName3;
                               
            }
        }
    }
}
