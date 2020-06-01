using System;
using System.Collections.Generic;
using HankSays.Models;
using Xamarin.Forms;
using HankSays.ViewModels;


namespace HankSays.ViewModels
{
    public class MainViewModel
    {
       
        private int level = 0;
        //private List<string> UserSelectionList;
        private GameModel GM;
        public MainViewModel()
        {
            GM = new GameModel();
            Initialize();
           UserSelectionCommand = new Command<string> (IncrementUserList);
          
           
        }

        private void Initialize()
        {
            GM.IncrementAiList();
            level++;
            //UserSelectedEnoughChoicies();
        }
        public Command UserSelectionCommand { get; }

        
        private bool UserSelectedEnoughChoicies()
        {
            //
            return GM.AiChoiceList.Count == GM.UserSelectionList.Count;
        }


        private void IncrementUserList(string choice)
        {
            GM.UserSelectionList.Add(choice);
            if (GM.UserSelectionList.Count == GM.AiChoiceList.Count)
                if (GM.CompareAiUserList(GM.AiChoiceList, GM.UserSelectionList))
                {
                    //Application.Current.MainPage.DisplayAlert("Alert", "Correct", "OK").Wait();
                    Initialize();
                }
                else
                {
                    Console.WriteLine("YO");//Application.Current.MainPage.DisplayAlert("Alert", "Wrong", "OK").Wait();
                    //EndscreenPlayAgain?
                }
            
        }
        
        /*
        private void IncrementUserList(string choice)
        {
            if (GM.UserSelectionList.Count == GM.AiChoiceList.Count)
            {
                if (GM.CompareAiUserList(GM.AiChoiceList, GM.UserSelectionList))
                    Application.Current.MainPage.DisplayAlert("Alert", "Correct", "OK").Wait();
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Wrongo", "OK").Wait();
                }
            }
            else
            {
                GM.UserSelectionList.Add(choice);
            }
            
        }
        */
        //if (UserSelectedEnoughChoicies())
            //    GM.CompareAiUserList(GM.AiChoiceList, GM.UserSelectionList);
        //}
        
    }
}


//TODO While loop that waits and fires only when the userselection count is the same as the Ai selection count.