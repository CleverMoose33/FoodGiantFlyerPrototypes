﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGiantFlyerGenerator.Model
{
    public class FlyerHistoryModel
    {
        public string ManagerName { get; set; }
        public string TemplateName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreNumber { get; set; }
        public string FlyerCreationDate { get; set; }
        public string FlyerSaleDates { get; set; }
        public bool SupplyChecked { get; set; }
        public bool RaincheckChecked { get; set; }


        public List<FlyerDataModel> flyerItemLst { get; set;}

        public FlyerHistoryModel()
        {

        }

    }
}
