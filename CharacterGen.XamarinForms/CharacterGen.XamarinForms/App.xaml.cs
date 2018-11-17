using CharacterGen.DataStorage;
using CharacterGen.DataTypes;
using CharacterGen.SharedLogic;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CharacterGen.XamarinForms
{
    public partial class App : Application
    {
        IDataStructure dataStore;
        public App()
        {
            InitializeComponent();


            //string dbPath = null;
            //string dbName = "flashcards.db";
            //switch (Device.RuntimePlatform)
            //{
            //    case Device.Android:
            //        dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            //        break;
            //    case Device.iOS:
            //        dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbName);
            //        SQLitePCL.Batteries_V2.Init();
            //        break;
            //    default:
            //        dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
            //        break;
            //}
            //dataStore = new SqliteDataStore(dbPath);
            //MainPage = new MainPage(new MainViewModel(dataStore));

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
