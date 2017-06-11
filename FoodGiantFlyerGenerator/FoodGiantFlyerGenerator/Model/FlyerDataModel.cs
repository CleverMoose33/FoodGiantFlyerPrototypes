using Caliburn.Micro;

namespace FoodGiantFlyerGenerator.Model
{
    /// <summary>
    /// This class will hold the variables used to create each ad in the eventual flyer.aspx page
    /// This allows us to store and generate as many ad items as the manager needs
    /// </summary>
    public class FlyerDataModel : PropertyChangedBase
    {
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ImgName1 { get; set; }
        public string ImgName2 { get; set; }
        public string ImgName3 { get; set; }

        public FlyerDataModel(string itemName, string itemCategory, string imgName1, string imgName2, string imgName3)
        {
            if (!string.IsNullOrEmpty(itemName))
                ItemName = itemName;

            if (!string.IsNullOrEmpty(itemCategory))
                ItemCategory = itemCategory;

            if (!string.IsNullOrEmpty(imgName1))
                ImgName1 = imgName1;

            if (!string.IsNullOrEmpty(imgName2))
                ImgName2 = imgName2;

            if (!string.IsNullOrEmpty(imgName3))
                ImgName3 = imgName3;
        }

    }
}