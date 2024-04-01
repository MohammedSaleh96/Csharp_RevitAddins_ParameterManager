﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ParaManager
{
    internal class ExtApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // Create the tab                    //CHANGE THE TAB NAME
            application.CreateRibbonTab("MS");

            // Create the Panel                  //CHANGE THE TAB AND THE PANEL NAME
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("MS", "Parameter Manager");

            // Create the Button                  
            String path = Assembly.GetExecutingAssembly().Location; // need NameSpace using System.Reflection; 
                                                                    //CHANGE THE BUTTON NAME AND THE ExtCmd
            PushButtonData pushbuttondata = new PushButtonData("sssddd", "ParaManager", path, "ParaManager.ExtCmd");
            PushButton pushButton = ribbonPanel.AddItem(pushbuttondata) as PushButton;

            // Put image in the button, after insert the image in the visual 
            pushButton.Image = new BitmapImage(new Uri("pack://application:,,,/ParaManager;component/Resources/Image.png"));// you need to add namespace to this using System.Windows.Media.Imaging; 
            pushButton.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ParaManager;component/Resources/Image.png")); // Change the project name and folder name and the imagine name
            return Result.Succeeded;
           

        }
    }
}
