using System;
using System.Collections.Generic;

namespace HankSays.Models
{
    public class GameModel : IGame
    {
        //public List<AiChoiceGenerator> AiChoiceList;
        public List<string> AiChoiceList;
        public List<string> UserSelectionList;
        
        //private List<string> UserChoiceList;

        public GameModel()
        {
            //AiChoiceList = new List<AiChoiceGenerator>();
            AiChoiceList = new List<string>();
            UserSelectionList = new List<string>();
        }
        public void IncrementAiList()
        {
            var values = Enum.GetValues(typeof(AiChoiceGenerator));
            var random = new Random();
            var randomColor = (AiChoiceGenerator)values.GetValue(random.Next(values.Length));
            //AiChoiceList.Add(randomColor);
            AiChoiceList.Add((randomColor.ToString()));
        }

        public void ClearUserSelectionList(List<string> UserSelectionList)
        {
            UserSelectionList.Clear();
        }

        public bool CompareAiUserList(List<string>AiChoiceList, List<string> UserSelectionList )
        {
            for (var i = 0; i < AiChoiceList.Count; i++)
            {
                if (AiChoiceList[i] != UserSelectionList[i])
                    return false;
               
            }

            return true;
        }
        public bool CheckLists()
        {
            if (UserSelectionList.Count == AiChoiceList.Count)
                if (CompareAiUserList(AiChoiceList, UserSelectionList))
                {
                    return true;
                }

            return false;
        }
    }
}