using System;
using System.Collections.Generic;
using System.Linq;
using HankSays.Models;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ModelTest : IGame
    {
        
        private List<string> AiChoiceList;
        private List<string> UserChoiceList;
        
        [SetUp]
        public void Setup()
        {
           
            AiChoiceList = new List<string>();
            UserChoiceList = new List<string>();
           
        }

        [Test]
        public void ListNotEqual()
        {
            
            AiChoiceList.Add("R");
            AiChoiceList.Add("G");
            AiChoiceList.Add("G");
        
           UserChoiceList.Add("R");
           UserChoiceList.Add("R");
           UserChoiceList.Add("G");
            //mock out list here
            Assert.IsFalse(AiChoiceList.SequenceEqual(UserChoiceList));

        }
        [Test]
        public void ListAreEqual()
        {
            
            AiChoiceList.Add("R");
            AiChoiceList.Add("G");
            AiChoiceList.Add("B");
        
            UserChoiceList.Add("R");
            UserChoiceList.Add("G");
            UserChoiceList.Add("B");
            //mock out list here
            Assert.IsTrue(AiChoiceList.SequenceEqual(UserChoiceList));

        }

        public void IncrementAiList()
        {
            throw new NotImplementedException();
        }

        public void ClearUserSelectionList(List<string> userSelectionList)
        {
            throw new NotImplementedException();
        }

        public bool CompareAiUserList(List<string> AiChoiceList, List<string> UserSelectionList)
        {
            for (var i = 0; i < AiChoiceList.Count; i++)
            {
                if (AiChoiceList[i] != UserSelectionList[i])
                    return false;
               
            }

            return true;
        }
    }
}