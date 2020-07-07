using HankSays.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HankSays.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartView : ContentPage
    {
        public StartView()
        {
         
            InitializeComponent();
            BindingContext = new StartViewModel();
        }
    }
}
