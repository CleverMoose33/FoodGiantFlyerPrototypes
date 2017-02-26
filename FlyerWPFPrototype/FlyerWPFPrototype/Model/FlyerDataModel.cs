using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyerWPFPrototype.Model
{
    /// <summary>
    /// This class will hold the variables used to create each ad in the eventual flyer.aspx page
    /// This allows us to store and generate as many ad items as the manager needs
    /// </summary>
    public class FlyerDataModel
    {
        public string itemName;
        public string itemCategory;
        public string itemPrice;
        public string imageName1;
        public string imageName2;
        public string imageName3;

        public FlyerDataModel(string itemName, string itemCategory, string itemPrice, string imageName1, string imageName2, string imageName3)
        {
            if (!string.IsNullOrEmpty(itemName))
                this.itemName = itemName;

            if (!string.IsNullOrEmpty(itemCategory))
                this.itemCategory = itemCategory;

            if (!string.IsNullOrEmpty(itemPrice))
                this.itemPrice = itemPrice;

            if (!string.IsNullOrEmpty(imageName1))
                this.imageName1 = imageName1;

            if (!string.IsNullOrEmpty(imageName2))
                this.imageName2 = imageName2;

            if (!string.IsNullOrEmpty(imageName3))
                this.imageName3 = imageName3;
        }

    }
}
