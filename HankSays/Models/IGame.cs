using System.Collections.Generic;

namespace HankSays.Models
{
    public interface IGame
    {
        public void IncrementAiList();

        public void ClearUserSelectionList(List<string> userSelectionList);
        public bool CompareAiUserList(List<string> AiChoiceList, List<string> UserSelectionList);

    }
}