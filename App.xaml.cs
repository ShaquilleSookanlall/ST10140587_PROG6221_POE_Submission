using System.Collections.ObjectModel;
using System.Windows;

namespace ST10140587_PROG6221_POE
{
    public partial class App : Application
    {
        public static ObservableCollection<Recipe> Recipes { get; set; }

        public App()
        {
            Recipes = new ObservableCollection<Recipe>();
        }
    }
}
