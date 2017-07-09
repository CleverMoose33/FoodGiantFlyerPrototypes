using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using FoodGiantFlyerGenerator.Model;
using Caliburn.Micro;
using System.Collections.Generic;

namespace FoodGiantFlyerGenerator
{
    /// <summary>
    /// This class will establish connections to the SQL database and return data based on queries
    /// </summary>
    public class DatabaseInterface
    {
        private string _DbConnStr;

        private BindableCollection<FlyerDataModel> flyerDBItemsList = new BindableCollection<FlyerDataModel>();

        public DatabaseInterface()
        {
            _DbConnStr = Properties.Settings.Default.FoodGiantSQLDatabaseConn;
        }

        /// <summary>
        /// Delete Flyer Item from database
        /// </summary>
        /// <param name="item"></param>
        public void DeleteItem(string itemName)
        {
            SqlConnection dbConn = new SqlConnection(_DbConnStr);
            SqlCommand cmd = new SqlCommand();

            string additionString = "DELETE FROM FlyerHistory" + " WHERE ItemName = " + itemName;

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ItemList";

            SqlDataReader reader = cmd.ExecuteReader();
            bool itemAlreadyExists = reader.HasRows;
            reader.Close();


            //cmd.ExecuteNonQuery();
        }

        #region Flyer History Queries
        /// <summary>
        /// Added Flyer History to database.
        /// Future improevment, find out parameters to set for duplicate check like add new item method
        /// </summary>
        /// <param name="flyerHistory"></param>
        public void AddNewFlyerHistoryEntry(FlyerHistoryModel flyerHistory)
        {
            SqlConnection dbConn = new SqlConnection(_DbConnStr);

            //Check for duplicate entry before we add entry to database
            SqlCommand insertCmd = new SqlCommand();
            try
            {
                insertCmd.Connection = dbConn;
                insertCmd.CommandType = CommandType.Text;

                //Split INSERT and VALUES section due to dynamic query based on number of images
                string insertCmdTxt = "INSERT INTO FlyerHistory (ManagerName, TemplateName, StoreName, StoreAddress, StoreNumber, FlyerCreationDate," +
                    " FlyerStartDate, FlyerEndDate, SupplyChecked, RaincheckChecked";
                string insertValCmdTxt = " VALUES (@ManagerName, @TemplateName, @StoreName, @StoreAddress, @StoreNumber, @FlyerCreationDate," +
                    " @FlyerStartDate, @FlyerEndDate, @SupplyChecked, @RaincheckChecked";

                //Added params this way for reduction of a (unlikely) SQL Command Line Injection Attack
                insertCmd.Parameters.AddWithValue("@ManagerName", flyerHistory.ManagerName);
                insertCmd.Parameters.AddWithValue("@TemplateName", flyerHistory.TemplateName);
                insertCmd.Parameters.AddWithValue("@StoreName", flyerHistory.StoreName);
                insertCmd.Parameters.AddWithValue("@StoreAddress", flyerHistory.StoreAddress);
                insertCmd.Parameters.AddWithValue("@StoreNumber", flyerHistory.StoreNumber);
                insertCmd.Parameters.AddWithValue("@FlyerCreationDate", flyerHistory.FlyerCreationDate);
                insertCmd.Parameters.AddWithValue("@FlyerStartDate", flyerHistory.FlyerStartDate);
                insertCmd.Parameters.AddWithValue("@FlyerEndDate", flyerHistory.FlyerEndDate);
                insertCmd.Parameters.AddWithValue("@SupplyChecked", flyerHistory.SupplyChecked);
                insertCmd.Parameters.AddWithValue("@RaincheckChecked", flyerHistory.RaincheckChecked);

                //Loop for adding all flyer items
                int currentItemNum = 1;
                foreach (FlyerDataModel flyerDataMdl in flyerHistory.flyerItemLst)
                {
                    insertCmdTxt = insertCmdTxt + ", Item" + currentItemNum + "Name, Item"
                        + currentItemNum + "Price, Item" + currentItemNum + "Image, Item" + currentItemNum + "Size";
                    insertValCmdTxt = insertValCmdTxt + ", @Item" + currentItemNum + "Name, @Item"
                    + currentItemNum + "Price, @Item" + currentItemNum + "Image, @Item" + currentItemNum + "Size";

                    insertCmd.Parameters.AddWithValue("@Item" + currentItemNum + "Name", flyerDataMdl.ItemName);
                    insertCmd.Parameters.AddWithValue("@Item" + currentItemNum + "Price", flyerDataMdl.ItemPrice);
                    insertCmd.Parameters.AddWithValue("@Item" + currentItemNum + "Image", flyerDataMdl.ImgName1);
                    insertCmd.Parameters.AddWithValue("@Item" + currentItemNum + "Size", flyerDataMdl.ItemSize);

                    if (!string.IsNullOrEmpty(flyerDataMdl.ItemDesc))
                    {
                        insertCmdTxt = insertCmdTxt + ", Item" + currentItemNum + "Desc";
                        insertValCmdTxt = insertValCmdTxt + ", @Item" + currentItemNum + "Desc";
                        insertCmd.Parameters.AddWithValue("@Item" + currentItemNum + "Desc", flyerDataMdl.ItemDesc);
                    }
                    currentItemNum++;
                }

                insertCmdTxt = insertCmdTxt + ")";
                insertValCmdTxt = insertValCmdTxt + ")";

                //Append INSERT and VALUE sections together
                insertCmdTxt = insertCmdTxt + insertValCmdTxt;
                insertCmd.CommandText = insertCmdTxt;

                dbConn.Open();
                //See if query updated database
                int insertSuccess = insertCmd.ExecuteNonQuery();
            }
            catch (Exception e) { Console.Write(e); }
            finally { dbConn.Close(); }
        }

        /// <summary>
        /// Return all Flyer History Items in database
        /// </summary>
        /// <returns></returns>
        public List<FlyerHistoryModel> GetFlyerHistoryItems()
        {
            List<FlyerHistoryModel> flyerHisLst = new List<FlyerHistoryModel>();

            SqlConnection dbConn = new SqlConnection(_DbConnStr);
            SqlCommand cmd = new SqlCommand();

            string additionString = "SELECT * FROM FlyerHistory";

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = additionString;
            
            try
            {
                dbConn.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read())
                {
                    try
                    {
                        IDataRecord record = reader;
                        flyerHisLst.Add(GenerateDataItem(reader));
                    }
                    catch (Exception)
                    {
                        reader.Close();
                        MessageBox.Show("Error Has Occured");
                    }
                }
            }
            finally
            {
                dbConn.Close();
            }

            return flyerHisLst;
        }

        /// <summary>
        /// Return List of all managers that have created flyers
        /// </summary>
        /// <returns></returns>
        public List<string> GetManagerList()
        {
            List<string> managerLst = new List<string>();

            SqlConnection dbConn = new SqlConnection(_DbConnStr);
            SqlCommand cmd = new SqlCommand();

            string additionString = "SELECT ManagerName FROM FlyerHistory";

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = additionString;

            dbConn.Open();

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            try
            {
                while (reader.Read())
                {
                    try
                    {
                        IDataRecord record = reader;
                        managerLst.Add((string)reader["ManagerName"]);
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
                dbConn.Close();
            }
            return managerLst;
        }

        /// <summary>
        /// Gets Flyer History Items by managername
        /// </summary>
        /// <param name="managerName"></param>
        /// <returns>List of Flyer Histories</returns>
        public List<FlyerHistoryModel> GetFlyerHistoryItemsByManager(string managerName)
        {
            List<FlyerHistoryModel> flyerHisLst = new List<FlyerHistoryModel>();

            SqlConnection dbConn = new SqlConnection(_DbConnStr);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM FlyerHistory WHERE ManagerName LIKE @ManagerName";

            //Added params this way for reduction of a (unlikely) SQL Command Line Injection Attack
            cmd.Parameters.AddWithValue("@ManagerName", managerName);

            try
            {
                dbConn.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read())
                {
                    try
                    {
                        IDataRecord record = reader;
                        flyerHisLst.Add(GenerateDataItem(reader));
                    }
                    catch (Exception)
                    {
                        reader.Close();
                        MessageBox.Show("Error Has Occured");
                    }
                }
            }
            finally
            {
                dbConn.Close();
            }

            return flyerHisLst;
        }

        /// <summary>
        /// Gets Flyer History Items by selected date type
        /// </summary>
        /// <param name="searchDate"></param>
        /// <returns>List of Flyer Histories</returns>
        public List<FlyerHistoryModel> GetFlyerHistoryItemsByDate(DateTime searchDate, string dateSearchType)
        {
            //Field for date search type
            string dateSearchParam;
            if(dateSearchType.Contains("start"))
            {
                dateSearchParam = "FlyerStartDate";
            }
            else if (dateSearchType.Contains("end"))
            {
                dateSearchParam = "FlyerEndDate";
            }
            else
            {
                dateSearchParam = "FlyerCreationDate";
            }

            List<FlyerHistoryModel> flyerHisLst = new List<FlyerHistoryModel>();

            SqlConnection dbConn = new SqlConnection(_DbConnStr);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = dbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM FlyerHistory WHERE " + dateSearchParam + " LIKE @" + dateSearchParam;

            //Added params this way for reduction of a (unlikely) SQL Command Line Injection Attack
            cmd.Parameters.AddWithValue("@" + dateSearchParam, searchDate.ToShortDateString());
            
            try
            {
                dbConn.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read())
                {
                    try
                    {
                        IDataRecord record = reader;
                        flyerHisLst.Add(GenerateDataItem(reader));
                    }
                    catch (Exception)
                    {
                        reader.Close();
                        MessageBox.Show("Error Has Occured");
                    }
                }
            }
            finally
            {
                dbConn.Close();
            }

            return flyerHisLst;
        }

        /// <summary>
        /// Enter Flyer History Item into database
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Complete Flyer History Model object</returns>
        private FlyerHistoryModel GenerateDataItem(SqlDataReader reader)
        {
            FlyerHistoryModel flyerHisMdl = new FlyerHistoryModel();
            try
            {
                flyerHisMdl.ManagerName = (string)reader["ManagerName"];
                flyerHisMdl.TemplateName = (string)reader["TemplateName"];
                flyerHisMdl.StoreName = (string)reader["StoreName"];
                flyerHisMdl.StoreAddress = (string)reader["StoreAddress"];
                flyerHisMdl.StoreNumber = (string)reader["StoreNumber"];
                flyerHisMdl.FlyerCreationDate = (string)reader["FlyerCreationDate"];
                flyerHisMdl.FlyerStartDate = (string)reader["FlyerStartDate"];
                flyerHisMdl.FlyerEndDate = (string)reader["FlyerEndDate"];
                flyerHisMdl.SupplyChecked = (bool)reader["SupplyChecked"];
                flyerHisMdl.RaincheckChecked = (bool)reader["RaincheckChecked"];
                flyerHisMdl.FlyerHistoryCmboBoxDispName = "Manager: " + flyerHisMdl.ManagerName + " on date " + flyerHisMdl.FlyerCreationDate;

                //Method to populate flyer items
                flyerHisMdl.flyerItemLst = new List<FlyerDataModel>();
                FlyerDataModel tempModel;
                bool addedAllItems = false;
                int currentItemNum = 1;
                while (!addedAllItems)
                {
                    if (!string.IsNullOrEmpty(reader["Item" + currentItemNum + "Name"].ToString()))
                    {
                        tempModel = new FlyerDataModel();
                        tempModel.ItemName = (string)reader["Item" + currentItemNum + "Name"];
                        tempModel.ItemPrice = (string)reader["Item" + currentItemNum + "Price"];
                        tempModel.ImgName1 = (string)reader["Item" + currentItemNum + "Image"];
                        tempModel.ItemSize = (string)reader["Item" + currentItemNum + "Size"];

                        if (!string.IsNullOrEmpty(reader["Item" + currentItemNum + "Desc"].ToString()))
                            tempModel.ItemDesc = (string)reader["Item" + currentItemNum + "Desc"];
                        flyerHisMdl.flyerItemLst.Add(tempModel);
                        currentItemNum++;
                    }
                    else
                        addedAllItems = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Has Occured");
            }
            return flyerHisMdl;
        }
        #endregion

        #region Flyer Item Queries
        /// <summary>
        /// Queries and Populates all items from the ItemList Table
        /// </summary>
        public BindableCollection<FlyerDataModel> PullItems()
        {
            //If we have not already generated list of flyer items, then populate list else, pull existing list of items
            if (flyerDBItemsList.Count == 0)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection dbConn = new SqlConnection(_DbConnStr);

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
                    dbConn.Close();
                }
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
            SqlConnection dbConn = new SqlConnection(_DbConnStr);

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
        #endregion
    }
}
