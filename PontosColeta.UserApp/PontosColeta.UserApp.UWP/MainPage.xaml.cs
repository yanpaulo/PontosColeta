﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PontosColeta.UserApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("6GrVKmno1nG7mSOq8tYy~OQUBI2oHmPubAovj_jyjqQ~AryHeVSG4KGaUIU4At8OPVzZmsUpYmJIecuCTkMcC3yP8ytevM-B2Ecxmz95uUr-");
            LoadApplication(new PontosColeta.UserApp.App());
        }
    }
}
