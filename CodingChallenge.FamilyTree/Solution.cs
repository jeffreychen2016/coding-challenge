using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        // take in a Person (tree) and flatten all of its direct and indirect descendants into single list
        public static List<Person> Flatten(Person root)
        {
            var flattened = new List<Person> { root };
            var descendants = root.Descendants;

            if (descendants != null)
            {
                foreach (var descendant in descendants)
                {
                    flattened.AddRange(Flatten(descendant));
                }
            }

            return flattened;
        }
        public string GetBirthMonth(Person person, string descendantName)
        {
            var allDescendants = Flatten(person);
            var descendant = allDescendants.Where(d => d.Name == descendantName).FirstOrDefault();

            if (descendant != null) {
                return descendant.Birthday.ToString("MMMM");
            } else {
                return String.Empty;
            };
        }
    }
}