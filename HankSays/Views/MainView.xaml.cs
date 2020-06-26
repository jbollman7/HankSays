using HankSays.ViewModels;
using Xamarin.Forms;

namespace HankSays.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
