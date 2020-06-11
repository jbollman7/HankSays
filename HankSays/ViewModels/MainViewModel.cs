using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HankSays.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using HankSays.Views;
//using Xamarin.Forms;


namespace HankSays.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _redChoice;
        private string _yellowChoice;
        private string _greenChoice;
        private string _blueChoice;

        private GameModel GM;
        public MainViewModel()
        {
            resetLevel();
            SetColorsToNormalState();
            GM = new GameModel();
            Initialize();
            UserSelectionCommand = new Command<string> (IncrementUserList);

            
        }

        private void Initialize()
        {
            GM.IncrementAiList();
            
            AiShowsPattern();
            GM.ClearUserSelectionList(GM.UserSelectionList);
                
            
        }
        public Command UserSelectionCommand { get;}

        
        private void IncrementUserList(string choice)
        {
            GM.UserSelectionList.Add(choice);
           CheckLists();
        }
        private void SetColorsToNormalState()
        {
            RedChoice = "Red";
            YellowChoice = "Gold";
            GreenChoice = "DarkGreen";
            BlueChoice = "Blue";
        }

        private async void CheckLists()
        {
            if (GM.UserSelectionList.Count == GM.AiChoiceList.Count)
                if (GM.CompareAiUserList(GM.AiChoiceList, GM.UserSelectionList))
                {
                    Level++;
                    await Task.Delay(800);
                    Initialize();
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new EndView());
                }
        }
        public int Level
        {
            get => Preferences.Get(nameof(Level), 0);
            set
            {
                Preferences.Set(nameof(Level), value);
                var args = new PropertyChangedEventArgs(nameof(Level));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void resetLevel()
        {
            var levelKey = Preferences.ContainsKey(nameof(Level));
            if (levelKey)
                Preferences.Remove(nameof(Level));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        //Visuals
        public async void AiShowsPattern()
        {
            for (var i = 0; i < GM.AiChoiceList.Count; i++)
            {
                switch (GM.AiChoiceList[i])
                {
                    case "R":
                        Task Tomato = Task.Run( () => RedChoice = "Tomato");
                        Tomato.Wait(); 
                        await Task.Delay(800);
                        Task red = Task.Run( () => RedChoice = "Red");
                        red.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "Y":
                        Task yellow = Task.Run( () => YellowChoice = "Yellow");
                        yellow.Wait();
                        await Task.Delay(800);
                        
                        Task gold = Task.Run( () => YellowChoice = "gold");
                        gold.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "G":
                        Task lawngreen = Task.Run( () => GreenChoice = "LawnGreen");
                        lawngreen.Wait();
                        await Task.Delay(800);
                        Task green = Task.Run( () => GreenChoice = "DarkGreen");
                        green.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "B":
                        Task aqua = Task.Run( () => BlueChoice = "SkyBlue");
                        aqua.Wait(); 
                        await Task.Delay(800);
                        Task blue = Task.Run( () => BlueChoice = "Blue");
                        blue.Wait();
                        await Task.Delay(800);
                        
                        break;
                    
                }
            }
        }
        public string RedChoice
        {
            get => _redChoice;
            set
            {
                _redChoice = value;
                var args = new PropertyChangedEventArgs(nameof(RedChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string YellowChoice
        {
            get => _yellowChoice;
            set
            {
                _yellowChoice = value;
                var args = new PropertyChangedEventArgs(nameof(YellowChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string BlueChoice
        {
            get => _blueChoice;
            set
            {
                _blueChoice = value;
                var args = new PropertyChangedEventArgs(nameof(BlueChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string GreenChoice
        {
            get => _greenChoice;
            set
            {
                _greenChoice = value;
                var args = new PropertyChangedEventArgs(nameof(GreenChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}