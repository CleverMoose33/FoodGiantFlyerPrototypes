using Caliburn.Micro;
using FlyerWPFPrototype.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlyerWPFPrototype
{
    [Export(typeof(DatabaseMaintainerViewModel))]
    public class DatabaseMaintainerViewModel : Screen
    {
        #region Binding Items

        #region Item Parameters
        private string _ItemName;

        public string ItemName
        {
            get
            { return _ItemName; }
            set
            {
                _ItemName = value;
                NotifyOfPropertyChange(() => ItemName);
            }
        }

        private string _ItemCategory;

        public string ItemCategory
        {
            get
            { return _ItemCategory; }
            set
            {
                _ItemCategory = value;
                NotifyOfPropertyChange(() => ItemCategory);
            }
        }

        private string _Price;

        public string Price
        {
            get
            { return _Price; }
            set
            {
                _Price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        private string _Image1Src;

        public string Image1Src
        {
            get
            { return _Image1Src; }
            set
            {
                _Image1Src = value;
                NotifyOfPropertyChange(() => Image1Src);
            }
        }

        private string _Image2Src;

        public string Image2Src
        {
            get
            { return _Image2Src; }
            set
            {
                _Image2Src = value;
                NotifyOfPropertyChange(() => Image2Src);
            }
        }

        private string _Image3Src;

        public string Image3Src
        {
            get
            { return _Image3Src; }
            set
            {
                _Image3Src = value;
                NotifyOfPropertyChange(() => Image3Src);
            }
        }
        #endregion

        #region Button Parameters
        private string _Item1SlctnBtn;

        public string Item1SlctnBtn
        {
            get
            { return _Item1SlctnBtn; }
            set
            {
                _Item1SlctnBtn = value;
                NotifyOfPropertyChange(() => Item1SlctnBtn);
            }
        }

        private string _Item2SlctnBtn;

        public string Item2SlctnBtn
        {
            get
            { return _Item2SlctnBtn; }
            set
            {
                _Item2SlctnBtn = value;
                NotifyOfPropertyChange(() => Item2SlctnBtn);
            }
        }

        private string _Item3SlctnBtn;

        public string Item3SlctnBtn
        {
            get
            { return _Item3SlctnBtn; }
            set
            {
                _Item3SlctnBtn = value;
                NotifyOfPropertyChange(() => Item3SlctnBtn);
            }
        }
        #endregion

        #endregion


        private readonly IEventAggregator _eventAggregator;

        public DatabaseMaintainerViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            ItemName = "Enter Item Name Here";
            ItemCategory = "Enter Item Category Here";
            Price = "$3.50";
            Item1SlctnBtn = Item2SlctnBtn = Item3SlctnBtn = "Select an Image";
        }

        public void AddItemToDatabase()
        {
            //Validate Params

            //dbint.AddItemToDatabase
        }

        #region Image Selection Methods
        public void SelectImage1()
        {
            if (Item1SlctnBtn.Contains("Remove"))
            {
                Image1Src = "";
                Item1SlctnBtn = "Select an Image";
            }
            else
            {
                System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
                opnfldlg.InitialDirectory = Environment.CurrentDirectory;
                opnfldlg.Multiselect = false;
                opnfldlg.Filter = "all supported image formats|*.jpg,*.jpeg,*.bmp,*.png,*.gif|jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

                if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (opnfldlg.CheckFileExists)
                    {
                        Image1Src = opnfldlg.FileName;
                        Item1SlctnBtn = "Remove Image";
                    }
                }
            }
        }

        public void SelectImage2()
        {
            if (Item2SlctnBtn.Contains("Remove"))
            {
                Image2Src = "";
                Item2SlctnBtn = "Select an Image";
            }
            else
            {
                System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
                opnfldlg.InitialDirectory = Environment.CurrentDirectory;
                opnfldlg.Multiselect = false;
                opnfldlg.Filter = "jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

                if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (opnfldlg.CheckFileExists)
                    {
                        Image2Src = opnfldlg.FileName;
                        Item2SlctnBtn = "Remove Image";
                    }
                }
            }
        }

        public void SelectImage3()
        {
            if (Item3SlctnBtn.Contains("Remove"))
            {
                Image3Src = "";
                Item3SlctnBtn = "Select an Image";
            }
            else
            {
                System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
                opnfldlg.InitialDirectory = Environment.CurrentDirectory;
                opnfldlg.Multiselect = false;
                opnfldlg.Filter = "jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

                if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (opnfldlg.CheckFileExists)
                    {
                        Image3Src = opnfldlg.FileName;
                        Item3SlctnBtn = "Remove Image";
                    }
                }
            }
        }
        #endregion


    }
}