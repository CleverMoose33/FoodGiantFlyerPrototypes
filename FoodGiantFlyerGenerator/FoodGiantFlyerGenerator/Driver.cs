using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;

namespace FoodGiantFlyerGenerator
{
    internal class Driver
    {
        public void StubTestForGenericFlyer()
        {
            FlyerSettingsModel settings = new FlyerSettingsModel("Piggly Wiggly", "Some Address at Florida, 32555", "850-111-1111", true, true);
            FlyerDataModel[] flyerData = new FlyerDataModel[7];

            flyerData[0] = new FlyerDataModel();
            flyerData[0].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\cocacola1.png";
            flyerData[0].ItemPrice = "$4.30";
            flyerData[0].ItemSize = "Oz";
            flyerData[0].ItemName = "Some Item";
            flyerData[0].ItemDesc = "Some Desc";

            flyerData[1] = new FlyerDataModel();
            flyerData[1].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\DietCoke1.jpg";
            flyerData[1].ItemPrice = "$4.30";
            flyerData[1].ItemSize = "Oz";
            flyerData[1].ItemName = "Some Item";
            flyerData[1].ItemDesc = "Some Desc";

            flyerData[2] = new FlyerDataModel();
            flyerData[2].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            flyerData[2].ItemPrice = "$4.30";
            flyerData[2].ItemSize = "Oz";
            flyerData[2].ItemName = "Some Item";
            flyerData[2].ItemDesc = "Some Desc";

            flyerData[3] = new FlyerDataModel();
            flyerData[3].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            flyerData[3].ItemPrice = "$4.30";
            flyerData[3].ItemSize = "Oz";
            flyerData[3].ItemName = "Some Item";
            flyerData[3].ItemDesc = "Some Desc";

            flyerData[4] = new FlyerDataModel();
            flyerData[4].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            flyerData[4].ItemPrice = "$4.30";
            flyerData[4].ItemSize = "Oz";
            flyerData[4].ItemName = "Some Item";
            flyerData[4].ItemDesc = "Some Desc";

            flyerData[5] = new FlyerDataModel();
            flyerData[5].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            flyerData[5].ItemPrice = "$4.30";
            flyerData[5].ItemSize = "Oz";
            flyerData[5].ItemName = "Some Item";
            flyerData[5].ItemDesc = "Some Desc";

            flyerData[6] = new FlyerDataModel();
            flyerData[6].ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            flyerData[6].ItemPrice = "$4.30";
            flyerData[6].ItemSize = "Oz";
            flyerData[6].ItemName = "Some Item";
            flyerData[6].ItemDesc = "Some Desc";

            DateTime startDate = new DateTime(2017, 07, 01);
            DateTime endDate = new DateTime(2017, 07, 03);

            WindowManager wm = new WindowManager();
            GenericFlyerViewModel gvcm = new GenericFlyerViewModel(settings, flyerData, startDate, endDate);
            FlyerDisplayControlViewModel fdcvm = new FlyerDisplayControlViewModel(gvcm);

            wm.ShowWindow(fdcvm);
        }

        private void StubTestForItemContainer()
        {
            FlyerDataModel model = new FlyerDataModel();
            model.ImgName1 = @"C:\Users\Kendrick\Documents\UWF Stuff\Capstone!\Git Repo\FoodGiantFlyer\FoodGiantFlyerGenerator\FoodGiantFlyerGenerator\bin\Debug\Images\hotpocketham.jpg";
            model.ItemPrice = "$4.30";
            model.ItemSize = "Oz";
            model.ItemName = "Some Item";
            model.ItemDesc = "Some Desc";

            WindowManager wm = new WindowManager();
            FlyerItemContainerViewModel fcvm = new FlyerItemContainerViewModel();

            fcvm.PopulateFlyerValues(model);
            wm.ShowWindow(fcvm);
        }

    }
}
