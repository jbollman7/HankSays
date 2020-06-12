using System;
using System.Collections.Generic;
using System.Linq;
using HankSays.Models;
using NUnit.Framework;

namespace UnitTest
{
    public class ViewModelTest : IMainViewModel
    {
        
        private List<AiChoiceGenerator> AiChoiceList;
        private List<AiChoiceGenerator> UserChoiceList;
        
        [SetUp]
        public void Setup()
        {
            IncrementAiList();
           
        }

        [Test]
        public void IncrementAiList()
        {
            AiChoiceList = new List<AiChoiceGenerator>();
            AiChoiceList.Add(AiChoiceGenerator.R);
            AiChoiceList.Add(AiChoiceGenerator.G);
            //mock out list here
        }

        public void ClearUserSelectionList(List<string> userSelectionList)
        {
            throw new NotImplementedException();
        }

        public bool CompareAiUserList(List<string> AiChoiceList, List<string> UserSelectionList)
        {
            throw new NotImplementedException();
        }
    }
}