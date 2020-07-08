using System;
using HankSays.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HankSays.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
           
            InitializeComponent();
            //BindingContext = new MainViewModel();
        }

        async void Red_Scaled_Clicked(object sender, EventArgs e)
        {
            await RedButton.TranslateTo(-70, 0, 300, Easing.BounceOut);
            await RedButton.TranslateTo(0, 0);
        }
        
        async void Pink_Scaled_Clicked(object sender, EventArgs e)
        {
            await PinkButton.TranslateTo(70, 0, 300, Easing.BounceOut);
            await PinkButton.TranslateTo(0, 0);
        }
        
        async void Lavender_Scaled_Clicked(object sender, EventArgs e)
        {
            await LavenderButton.TranslateTo(-70, 0, 300, Easing.BounceOut);
            await LavenderButton.TranslateTo(0, 0);
        }
        
        async void Purple_Scaled_Clicked(object sender, EventArgs e)
        {
            await PurpleButton.TranslateTo(70, 0, 300, Easing.BounceOut);
            await PurpleButton.TranslateTo(0, 0);
        }
    }
}
