using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CodingChallenge.FamilyTree.Tests
{
    [TestFixture]
    public class TreeTests
    {
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(22)]
        public void if_the_person_exists_in_tree_the_result_should_be_their_birthday(int index)
        {
            var tree = FamilyTreeGenerator.Make();
            var result = new Solution().GetBirthMonth(tree, "Name" + index);
            // 1. the original assertion had actualResult and expectedResult in wrong order
            // which causes the test error to be little confusing.
            // example: Expected: null But was:  "June".
            // original assertion:
            // Assert.AreEqual(result,DateTime.Now.AddDays(index - 1).ToString("MMMM"));
            // 2. the test results are inconsistent due to FamilyTreeGenerator.Make() generates different test fixture everytime
            // example: sometimes the fixture tree does not create Person with the Name33, but the assertion expects a valid month instead of emptry string.
            // i attached tree1.json and tree2.json for your reference (JsonConvert.SerializeObject(tree);)
            Assert.AreEqual(DateTime.Now.AddDays(index - 1).ToString("MMMM"), result);
        }

        [Test]
        public void if_the_person_does_not_exist_in_the_tree_the_result_should_be_empty()
        {
            var tree = FamilyTreeGenerator.Make();
            var result = new Solution().GetBirthMonth(tree, "Jeebus");
            Assert.AreEqual("",result);
        }
    }
}
