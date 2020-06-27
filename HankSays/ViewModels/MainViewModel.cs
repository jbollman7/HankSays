using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HankSays.Models;
using HankSays.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
//using Xamarin.Forms;


namespace HankSays.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IMainViewModel
    {
        private string _yellowChoice;
        private string _orangeChoice;
        private string _redChoice;
        private string _pinkChoice;
        private string _lavenderChoice;
        private string _purpleChoice;

        //private List<string> UserSelectionList;
        private GameModel GM;
        public MainViewModel()
        {
            
            //gameStopWatch = new Stopwatch();
            //gameStopWatch.Start();
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
            YellowChoice = "#FFBB13";
            OrangeChoice = "#FF653E";
            RedChoice = "#FF2F2F";
            PinkChoice = "DeepPink";
            LavenderChoice = "MediumOrchid";
            PurpleChoice = "BlueViolet";

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
                    //Console.WriteLine("YO");
                    //await Application.Current.MainPage.DisplayAlert("Alert", "Wrong", "OK");
                    //EndscreenPlayAgain?
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
                    case "Y":
                        Task flash = Task.Run( () => YellowChoice = "Yellow");
                        flash.Wait(); 
                        await Task.Delay(800);
                        Task yellow = Task.Run( () => YellowChoice = "#FFBB13");
                        yellow.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "O":
                        Task flash1 = Task.Run( () => OrangeChoice = "Yellow");
                        flash1.Wait();
                        await Task.Delay(800);
                        Task orange = Task.Run( () => OrangeChoice = "#FF653E");
                        orange.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "R":
                        Task flash2 = Task.Run( () => RedChoice = "Yellow");
                        flash2.Wait();
                        await Task.Delay(800);
                        Task red = Task.Run( () => RedChoice = "#FF2F2F");
                        red.Wait();
                        await Task.Delay(800);
                        break;
                    
                    case "P":
                        Task flash3 = Task.Run( () => PinkChoice = "Yellow");
                        flash3.Wait(); 
                        await Task.Delay(800);
                        Task pink = Task.Run( () => PinkChoice = "DeepPink");
                        pink.Wait();
                        await Task.Delay(800);
                        break;
                    case "L":
                        Task flash4 = Task.Run(() => LavenderChoice = "Yellow");
                        flash4.Wait();
                        await Task.Delay(800);
                        Task lavender = Task.Run(() => LavenderChoice = "MediumOrchid");
                        lavender.Wait();
                        await Task.Delay(800);
                        break;

                    case "PURP":
                        Task flash5 = Task.Run(() => PurpleChoice = "Yellow");
                        flash5.Wait();
                        await Task.Delay(800);
                        Task purp = Task.Run(() => PurpleChoice = "BlueViolet");
                        purp.Wait();
                        await Task.Delay(800);
                        break;

                }
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
        public string OrangeChoice
        {
            get => _orangeChoice;
            set
            {
                _orangeChoice = value;
                var args = new PropertyChangedEventArgs(nameof(OrangeChoice));
                PropertyChanged?.Invoke(this, args);
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
        public string PinkChoice
        {
            get => _pinkChoice;
            set
            {
                _pinkChoice = value;
                var args = new PropertyChangedEventArgs(nameof(PinkChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string LavenderChoice
        {
            get => _lavenderChoice;
            set
            {
                _lavenderChoice = value;
                var args = new PropertyChangedEventArgs(nameof(LavenderChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string PurpleChoice
        {
            get => _purpleChoice;
            set
            {
                _purpleChoice = value;
                var args = new PropertyChangedEventArgs(nameof(PurpleChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }


    }
}


//TODO While loop that waits and fires only when the userselection count is the same as the Ai selection count.