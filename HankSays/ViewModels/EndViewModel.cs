using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HankSays.Annotations;
using HankSays.Views;
using Xamarin.Forms;

namespace HankSays.ViewModels
{
    public class EndViewModel : INotifyPropertyChanged
    {

        public EndViewModel()
        {
            BackToStartCommand = new Command(() =>
            {
                Application.Current.MainPage = new NavigationPage(new StartView());
            });
        }
        public ICommand BackToStartCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}