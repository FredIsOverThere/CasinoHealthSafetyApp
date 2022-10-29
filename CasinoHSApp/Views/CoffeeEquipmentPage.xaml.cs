using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasinoHSApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        //public string pathDisplay;
        public CoffeeEquipmentPage()
        {
            InitializeComponent();

            IncreaseCount = new Command(OnIncrease);

            BindingContext = this;

            string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MobileAppDatabase.db");
            if (File.Exists(DatabasePath))
            {
                pathDisplay = "Exists";
            }
            else
            {
                pathDisplay = "nope";
            }


        }
        public ICommand IncreaseCount { get; }

        int count = 0;
        string pathDisplay = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

        //Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string countDisplay = "Click Me!";

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay) return;
                countDisplay = value;
                OnPropertyChanged(nameof(CountDisplay));

            }
        }


        public string PathDisplay
        {
            get => pathDisplay;
            set
            {
                //if (value == countDisplay) return;

                //pathDisplay = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); 
                //OnPropertyChanged(nameof(CountDisplay));

            }
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
    }
}