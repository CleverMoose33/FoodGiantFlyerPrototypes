using Caliburn.Micro;

namespace FoodGiantFlyerGenerator.Model
{
    /// <summary>
    /// This class holds the variables used to populate values in the FlyerItem classes
    /// </summary>
    public class FlyerDataModel : PropertyChangedBase
    {
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ImgName1 { get; set; }
        public string ImgName2 { get; set; }
        public string ImgName3 { get; set; }

        public string ItemPrice { get; set; }
        public string ItemSize { get; set; }
        public string ItemDesc { get; set; }

        public FlyerDataModel() { }

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