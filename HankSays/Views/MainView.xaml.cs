using HankSays.ViewModels;
using Xamarin.Forms;

namespace HankSays.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
