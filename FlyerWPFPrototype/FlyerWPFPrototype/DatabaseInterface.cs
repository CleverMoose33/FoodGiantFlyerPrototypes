using Caliburn.Micro;
using FlyerWPFPrototype.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlyerWPFPrototype
{
    /// <summary>
    /// This class will establish connections to the SQL database and return data based on queries
    /// </summary>
    public class DatabaseInterface
    {
        //private string dbQuery;

        /// <summary>
        /// This class will establish a connection with the database, maybe this should be a interface that other classes can reference?
        /// That way only one instance of the class is active, will be an issue once program moves to server side, may leave in class for now
        /// and work on design via design docs
        /// </summary>
        public DatabaseInterface()
        {
            //List<string> resultsString = new List<string>();
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = @"Data Source=.\SQLEXPRESS;
            //              AttachDbFilename=" + Environment.CurrentDirectory + @"\Database\FoodGiantSQLDatabase.mdf;
            //              Integrated Security=True;
            //              Connect Timeout=30;
            //              User Instance=True";

            //sqlConnection.Open();

            //SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            //cmd.CommandText = "SELECT * FROM Items";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = sqlConnection;

            //sqlConnection.Open();

            //reader = cmd.ExecuteReader();
            //foreach (string resultString in reader)
            //{
            //    resultsString.Add(resultString);
            //}
            //// Data is accessible through the DataReader object here.

            //sqlConnection.Close();
        }

        /// <summary>
        /// Prototype for populating item list, will eventually be db query
        /// Currently manually adds items w/o db connection
        /// </summary>
        /// <returns></returns>
        public BindableCollection<FlyerDataModel> PopulateItemList()
        {
            //Do db query, for now, we will manually populate items
            BindableCollection<FlyerDataModel> flyerData = new BindableCollection<FlyerDataModel>();

            FlyerDataModel sampleItem1 = new FlyerDataModel("Coca-Cola 2 ltr", "Soda", "1.99", "CocaCola1.png", "CocaCola2.png", "CocaCola3.jpg");
            FlyerDataModel sampleItem2 = new FlyerDataModel("Diet Coke 12pk", "Soda", "3.99", "dietcoke1.jpg", "dietcoke2.jpg", "dietcoke3.png");
            FlyerDataModel sampleItem3 = new FlyerDataModel("Pepsi 2 ltr", "Soda", "1.99", "PepsiCola1.jpg", "PepsiCola2.png", "PepsiCola3.jpg");
            FlyerDataModel sampleItem4 = new FlyerDataModel("Tombstone Pizza", "Frozen Pizza", "2.99", "tombstone1.jpg", "tombstone2.jpg", "tombstone3.jpg");
            FlyerDataModel sampleItem5 = new FlyerDataModel("Hot Pocket Double Pack", "Frozen Food", "2.99", "hotpocketham.jpg", "hotpocketmeatball.jpeg", "hotpocketsteak.jpg");
            FlyerDataModel sampleItem6 = new FlyerDataModel("Honey Nut Cheerios 21.6 Oz", "Cereal", "5.99", "honeyNut1.jpg", "", "");

            flyerData.Add(sampleItem1);
            flyerData.Add(sampleItem2);
            flyerData.Add(sampleItem3);
            flyerData.Add(sampleItem4);
            flyerData.Add(sampleItem5);
            flyerData.Add(sampleItem6);

            return flyerData;
        }

    }
}
