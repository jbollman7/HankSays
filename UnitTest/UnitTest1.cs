using System;
using System.Collections.Generic;
using System.Linq;
using HankSays.Models;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests : IGame
    {
        
        private List<AiChoiceGenerator> AiChoiceList;
        private List<AiChoiceGenerator> UserChoiceList;
        
        [SetUp]
        public void Setup()
        {
            IncrementAiList();
            BuildUserList();
        }

        [Test]
        public void CompareAIandUserList()
        {
            CompareAiUserList();
        }

        public void IncrementAiList()
        {
            AiChoiceList = new List<AiChoiceGenerator>();
            AiChoiceList.Add(AiChoiceGenerator.R);
            AiChoiceList.Add(AiChoiceGenerator.G);
            //mock out list here
        }

        public void BuildUserList()
        {
            UserChoiceList = new List<AiChoiceGenerator>();
            UserChoiceList.Add(AiChoiceGenerator.R);
            UserChoiceList.Add(AiChoiceGenerator.G);
        }

        public void CompareAiUserList()
        {
            var firstNotSecond = AiChoiceList.Except(UserChoiceList).ToList();
        }
    }
}