using System;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace My_Notes
{
    public partial class App : Application
    {
        public static string DBPath;
        public static string DBName;

        public App() {
            InitializeComponent();

            MainPage = new MainShell();

        }
        public App(String dbPath, String dbName)
        {
            
            InitializeComponent();
            App.DBPath = dbPath;
            App.DBName = dbName;
            MainPage = new MainShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
