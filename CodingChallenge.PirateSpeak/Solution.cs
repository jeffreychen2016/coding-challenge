using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.PirateSpeak
{
    public class Solution
    {
        private string AlphabetizeWord(string word) {
            return String.Concat(word.OrderBy(c => c));
        }
 
        public string[] GetPossibleWords(string jumble, string[] dictionary)
        {
            // sort the characters in words and jumble in alphabetical order
            var alphabetizedJumble = AlphabetizeWord(jumble);
            var alphabetizedWordsList = dictionary.ToList().Select(AlphabetizeWord).ToList();

            // check alphabetizedJumble againt alphabetizedWordsList
            // if alphabetizedJumble is same as the word in alphabetizedWordsList, then get original word using the index, otherwise null.
            // then, remove all nulls.
            var resultList = alphabetizedWordsList
                .Select((w, i) => w == alphabetizedJumble ? dictionary[i] : null)
                .Where(w => w != null);

            return resultList.ToArray();
        }
    }
}