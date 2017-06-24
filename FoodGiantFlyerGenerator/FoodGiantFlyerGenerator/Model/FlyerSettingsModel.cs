using Caliburn.Micro;
using System;

namespace FoodGiantFlyerGenerator.Model
{
    /// <summary>
    /// This class will hold the variables used to create each ad in the eventual flyer.aspx page
    /// This allows us to store and generate as many ad items as the manager needs
    /// </summary>
    public class FlyerSettingsModel : PropertyChangedBase
    {
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreNumber { get; set; }
        public bool SupplyChkd { get; set; }
        public bool RainChkd { get; set; }
        public DateTime SaleDates { get; set; }

        public FlyerSettingsModel(string storeName, string storeAddress, string storeNumber, bool supplyChkd, bool rainChkd)
        {
            StoreName = storeName;
            StoreAddress = storeAddress;
            StoreNumber = storeNumber;
            SupplyChkd = supplyChkd;
            RainChkd = rainChkd;
        }

    }
}