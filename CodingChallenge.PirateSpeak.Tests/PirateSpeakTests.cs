﻿using NUnit.Framework;
using System;

namespace CodingChallenge.PirateSpeak.Tests
{
    public class PirateSpeakTests
    {
        [TestCase("trisf", new[] { "first" }, new[] { "first" })]
        [TestCase("oob", new[] { "bob", "baobob" }, new string[0])]
        [TestCase("ainstuomn", new[] { "mountains", "hills", "mesa" }, new[] { "mountains" })]
        [TestCase("oopl", new[] { "donkey", "pool", "horse", "loop" }, new[] { "pool", "loop" })]
        [TestCase("oprst", new[] { "sport", "ports", "ball", "bat", "port" }, new[] { "sport", "ports" })]
        // additional test case from the Program.cs file
        [TestCase("boop", new[] { "oops", "poo", "boo", "noop" }, new string[0])]
        public void TestPirateVocabulary(string jumble, string[] dictionary, object expectedResult)
        {
            var actualResult = new Solution().GetPossibleWords(jumble, dictionary);
            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}

