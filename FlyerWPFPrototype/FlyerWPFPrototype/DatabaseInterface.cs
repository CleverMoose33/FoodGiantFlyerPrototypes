using Caliburn.Micro;
using FlyerWPFPrototype.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FlyerDataModel sampleItem2 = new FlyerDataModel("Pepsi 2 ltr", "Soda", "1.99", "PepsiCola1.jpg", "PepsiCola2.png", "PepsiCola3.jpg");
            FlyerDataModel sampleItem3 = new FlyerDataModel("Tombstone Pizza", "Pizza", "2.99", "tombstone1.jpg", "tombstone2.jpg", "tombstone3.jpg");

            flyerData.Add(sampleItem1);
            flyerData.Add(sampleItem2);
            flyerData.Add(sampleItem3);

            return flyerData;
        }

    }
}
