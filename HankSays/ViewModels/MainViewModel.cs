using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using HankSays.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using HankSays.ViewModels;
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
        private readonly Stopwatch gameStopWatch;
      
        //private List<string> UserSelectionList;
        private GameModel GM;
        public MainViewModel()
        {
            
            gameStopWatch = new Stopwatch();
            gameStopWatch.Start();
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
            GreenChoice = "Green";
            BlueChoice = "Blue";
        }

        private void CheckLists()
        {
            if (GM.UserSelectionList.Count == GM.AiChoiceList.Count)
                if (GM.CompareAiUserList(GM.AiChoiceList, GM.UserSelectionList))
                {
                    Level++;
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
                    case "R":
                        RedChoice = "Tomato";
                        //gameStopWatch.Elapsed.Seconds
                        //SetColorsToNormalState();
                        
                        break;
                    
                    case "Y":
                        //YellowChoice = "Yellow";
                        
                        //SetColorsToNormalState();
                        break;
                    
                    case "G":
                        //GreenChoice = "LawnGreen";
                       
                        //SetColorsToNormalState();
                        break;
                    
                    case "B":
                        //BlueChoice = "Aqua";
                        //Thread.Sleep(TimeSpan.FromMilliseconds(700));
                        //SetColorsToNormalState();
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


//TODO While loop that waits and fires only when the userselection count is the same as the Ai selection count.