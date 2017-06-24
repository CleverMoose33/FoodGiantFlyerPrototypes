using System;
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
                            string itemName = (string)reader["ItemName"];
                            string itemCat = (string)reader["ItemCategory"];
                            string imageName1 = (string)reader["ImageName1"];

                            string imageName2 = "";
                            if (!string.IsNullOrEmpty(reader["ImageName2"].ToString()))
                            {
                                imageName2 = (string)reader["ImageName2"];
                            }

                            string imageName3 = "";
                            if (!string.IsNullOrEmpty(reader["ImageName3"].ToString()))
                            {
                                imageName3 = (string)reader["ImageName3"];
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
        /// Add new item to database
        /// </summary>
        /// <param name="newItem"></param>
        public bool AddNewItem(FlyerDataModel newItem)
        {
            bool entryAdded = false;
            SqlCommand duplicateChkCmd = new SqlCommand();
            SqlConnection dbConn = new SqlConnection(dbConnStr);

            duplicateChkCmd.Connection = dbConn;
            duplicateChkCmd.CommandType = CommandType.Text;

            try
            {
                //Check if entry already exists in DB

                //Logic to set up appropriate query search string
                string duplicateChkCmdTxt = "SELECT * FROM ItemList WHERE ItemName LIKE @ItemName AND ItemCategory LIKE @ItemCategory" +
                    " AND ImageName1 LIKE @ImageName1";

                //Added params this way for reduction of a (unlikely) SQL Command Line Injection Attack
                duplicateChkCmd.Parameters.AddWithValue("@ItemName", newItem.ItemName);
                duplicateChkCmd.Parameters.AddWithValue("@ItemCategory", newItem.ItemCategory);
                duplicateChkCmd.Parameters.AddWithValue("@ImageName1", newItem.ImgName1);

                if (!string.IsNullOrEmpty(newItem.ImgName2))
                {
                    duplicateChkCmdTxt = duplicateChkCmdTxt + " AND ImageName2 LIKE @ImageName2";
                    duplicateChkCmd.Parameters.AddWithValue("@ImageName2", newItem.ImgName2);
                }

                if (!string.IsNullOrEmpty(newItem.ImgName3))
                {
                    duplicateChkCmdTxt = duplicateChkCmdTxt + " AND ImageName3 LIKE @ImageName3";
                    duplicateChkCmd.Parameters.AddWithValue("@ImageName3", newItem.ImgName3);
                }

                duplicateChkCmd.CommandText = duplicateChkCmdTxt;

                //Open connection and run query
                dbConn.Open();
                SqlDataReader reader = duplicateChkCmd.ExecuteReader();
                bool itemAlreadyExists = reader.HasRows;
                reader.Close();


                if (itemAlreadyExists)
                    MessageBox.Show("Flyer Item Already Exists");
                else
                {
                    //Not duplicate entry, we can add entry to database
                    SqlCommand insertCmd = new SqlCommand();

                    insertCmd.Connection = dbConn;
                    insertCmd.CommandType = CommandType.Text;

                    //Split INSERT and VALUES section due to dynamic query based on number of images
                    string insertCmdTxt = "INSERT INTO ItemList (ItemName, ItemCategory, ImageName1";//,ImageName2,ImageName3
                    string insertValCmdTxt = " VALUES (@ItemName, @ItemCategory, @ImageName1";//,@ImageName2,@ImageName3

                    //Added params this way for reduction of a (unlikely) SQL Command Line Injection Attack
                    insertCmd.Parameters.AddWithValue("@ItemName", newItem.ItemName);
                    insertCmd.Parameters.AddWithValue("@ItemCategory", newItem.ItemCategory);
                    insertCmd.Parameters.AddWithValue("@ImageName1", newItem.ImgName1);

                    if (!string.IsNullOrEmpty(newItem.ImgName2))
                    {
                        insertCmdTxt = insertCmdTxt + ", ImageName2";
                        insertValCmdTxt = insertValCmdTxt + ", @ImageName2";
                        insertCmd.Parameters.AddWithValue("@ImageName2", newItem.ImgName2);
                    }

                    if (!string.IsNullOrEmpty(newItem.ImgName3))
                    {
                        insertCmdTxt = insertCmdTxt + ", ImageName3";
                        insertValCmdTxt = insertValCmdTxt + ", @ImageName3";
                        insertCmd.Parameters.AddWithValue("@ImageName3", newItem.ImgName3);
                    }

                    insertCmdTxt = insertCmdTxt + ")";
                    insertValCmdTxt = insertValCmdTxt + ")";

                    //Append INSERT and VALUE sections together
                    insertCmdTxt = insertCmdTxt + insertValCmdTxt;
                    insertCmd.CommandText = insertCmdTxt;

                    //See if query updated database
                    int insertSuccess = insertCmd.ExecuteNonQuery();

                    if(insertSuccess == 1)
                    {
                        entryAdded = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                dbConn.Close();
            }
            return entryAdded;
        }

    }
}
