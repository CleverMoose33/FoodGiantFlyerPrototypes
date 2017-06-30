using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(ProgramSelectorViewModel))]
    public class ProgramSelectorViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

        public ProgramSelectorViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
            
            StubTestForGenericFlyer();
            //WindowManager wm = new WindowManager();
            //FlyerCreatorViewModel fcvm = new FlyerCreatorViewModel();
            //wm.ShowWindow(fcvm);

        }

        private void StubTestForGenericFlyer()
        {
            FlyerSettingsModel settings = new FlyerSettingsModel("Piggly Wiggly", "Some Address at Florida, 32555", "850-111-1111", true, true);
            FlyerDataModel[] flyerData = new FlyerDataModel[3];
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


            DateTime startDate = new DateTime(2017, 07, 01);
            DateTime endDate = new DateTime(2017, 07, 03);

            WindowManager wm = new WindowManager();
            GenericFlyerViewModel gvcm = new GenericFlyerViewModel(settings, flyerData, startDate, endDate);
            wm.ShowWindow(gvcm);
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

        public void FlyerCreatorClicked()
        {
            WindowManager wm = new WindowManager();
            FlyerCreatorViewModel fcvm = new FlyerCreatorViewModel();
            wm.ShowWindow(fcvm);
        }

        public void DatabaseClicked()
        {
            WindowManager wm = new WindowManager();
            DatabaseMaintainerViewModel dbvm = new DatabaseMaintainerViewModel();
            wm.ShowWindow(dbvm);
        }

        public void FlyerHistoryClicked()
        {
            WindowManager wm = new WindowManager();
            //FlyerHistoryViewModel fhvm = new FlyerHistoryViewModel();
            //wm.ShowWindow(fhvm);
        }
    }
}