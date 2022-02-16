
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization; // Jaden Case Converter
using System.Text.RegularExpressions;

/// <summary>
/// Hello! This project is intended for the express purpose of practicing coding as often as possible, as well as getting into good habits such as pushing to github.
/// </summary>
namespace Dailies
{
    public static class Program
    {
        /// <summary>
        /// The only thing we control from here is what values get passed into the function, and which active problem we're working on
        /// and go NO FURTHER
        /// </summary>
        /// <param name="args"></param>
        /// 
        // Other recommended daily exercises:
        // https://www.reddit.com/r/dailyprogrammer/
        // https://www.codewars.com/
        static void Main(string[] args)
        {
            // Console.WriteLine("Welcome to the daily grind!");
            Y2022 activeProblem = Y2022.Feb8th;
            string phrase = "";

            switch (activeProblem)
            {
                #region January
                case Y2022.Jan23rd: // Number of steps | broken down into groups
                    int N = 40; // Total number of steps
                    int[] X = { 1, 2 };
                    StepClimber(N, X);
                    break;
                case Y2022.Jan24th: // Jaden Smith casing | kek | COMPLETED - well done me
                    phrase = "if everybody in the wold dropped out of school we would have a much more intelligent society.";
                    Console.WriteLine(ToJadenCase(phrase));
                    // Console.WriteLine(ToJadenCaseOneliner(phrase));
                    break;
                case Y2022.Jan25th: // Duplicate Encoder | COMPLETED
                    phrase = "SuCCeSS";
                    string duplicatesFound = DetermineDuplicate(phrase);
                    Console.WriteLine(duplicatesFound);
                    break;
                case Y2022.Jan27th: // Take a Ten minute Walk | COMPLETED
                    string[] walk = { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" };
                    // Console.WriteLine($"Was it a ten minute walk?: {IsTenMinWalk(walk)}");
                    Console.WriteLine($"Was it a ten minute walk?: {IsValidWalkOptimized(walk)}");
                    break;
                case Y2022.Jan28th: // Stop gninnipS My sdroW! | COMPLETED
                    phrase = "Hey wollef sroirraw";
                    phrase = SpinWords(phrase);
                    // phrase = SpinWordsBestPractices(phrase);
                    Console.WriteLine(phrase);
                    break;
                case Y2022.Jan30th: // Convert string to camel case | COMPLETED
                    phrase = "the_--_-stealth_warrior";
                    phrase = ToCamelCaseRefactor(phrase);
                    Console.WriteLine($"{phrase}");
                    break;
                case Y2022.Jan31st: // Find the unique number | COMPLETED
                    IEnumerable<int> numList = new List<int> { 0, 0, 1, 0 };
                    Console.WriteLine($"{GetUnique(numList)}");
                    break;
                #endregion // January

                #region February
                case Y2022.Feb1st: // Moving Zeros To The End | COMPLETED
                    int[] arr = { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 };
                    arr = MoveZeros(arr);
                    foreach (int display in arr) { Console.Write(display + ","); }
                    break;
                case Y2022.Feb2nd: // Your order, please - COMPLETED
                    string words = "is2 Thi1s T4est 3a";
                    words = OrderWordByNumber(words);
                    Console.WriteLine($"{words}");
                    break;
                case Y2022.Feb5th: // Bit Counting - COMPLETED
                    int bits = 1234;
                    bits = CountBits(bits);
                    Console.WriteLine($"Your bit value is: {bits}");
                    break;
                case Y2022.Feb7th: // Narcissistic Numbers - COMPLETED
                    int value = 153;
                    string isNars = IsNarcissistic(value) ? "yes" : "no";
                    Console.WriteLine($"Is {value} a narsassistic number? {isNars}");
                    break;
                // Feb 8th till today were consumed by lost ark... oof, time to get back int the rhythm!
                case Y2022.Feb15th: // Where my anagrams at?
                    string word = "abba";
                    List<string> wordz = new List<string>() { "aabb", "abcd", "" };
                    Anagrams(word, wordz);
                    break;
                case Y2022.Feb16th: // Most frequently used words in a text 
                    break;
                #endregion // February

                default:
                    // Hey goof ball, go change the activeProblem to the corresponding challenge day!
                    break;
            }

        }

        #region Month and Day Enum
        // by default simply assigning int values to an enum doesn't make them enum's, you need to assign a ": type" | https://www.tutorialsteacher.com/csharp/csharp-enum
        private enum Y2022 : int
        {
            #region 2022
            #region January
            Jan23rd,
            Jan24th,
            Jan25th,
            Jan27th,
            Jan28th,
            Jan29th,
            Jan30th,
            Jan31st,
            #endregion

            #region February
            Feb1st,
            Feb2nd,
            Feb3rd,
            Feb4th,
            Feb5th,
            Feb6th,
            Feb7th,
            Feb8th,
            Feb9th,
            Feb10th,
            Feb11th,
            Feb12th,
            Feb13th,
            Feb14th,
            Feb15th,
            Feb16th,
            Feb17th,
            Feb18th,
            Feb19th,
            Feb20th,
            Feb21st,
            Feb22nd,
            Feb23rd,
            Feb24th,
            Feb25th,
            Feb26th,
            Feb27th,
            Feb28th
            #endregion

            #region March
            #endregion // March

            #endregion // 2022
        }
        #endregion

        #region Source Code
        #region January

        #region Amazon Interview Question - Steps of steps on steps
        static void StepClimber(int n, int[] x)
        {
            // Console.WriteLine("Day one's a bit too easy, but time should make this more interesting.");
            // just kidding, that's a bit toooo easy
            // The idea shouldn't be restricted to doing only interview related questions, or complex things, but more focused on the habits
            // The idea that you won't move a mountain in a weekend, as it's demoralizing to fail at goals you set forth and is, in fact, impossible
            // but if you take one barrel full of rocks per day, over years that moves mountains.
            // Anyways, today lets look into trying to solve programing problems.

            /// Start Daily Exercise ///
            /// Proposed exercise: https://www.dailycodingproblem.com/
            /* 
             * There's a staircase with N steps, and you can climb 1 or 2 steps at a time. 
             * Given N, write a function that returns the number of unique ways you can climb the staircase.
             * The order of the steps matter, for instance: If N is 4, then there are 5 unique ways
             *  1,1,1,1 | 2,1,1 | 1,2,1 | 1,1,2 | 2,2
             *  
             *  What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of
             *  positive integers X? For example, if X = { 1, 3, 5 }, you could climb 1, 3, or 5 steps at a time.
             *  Generalize your function to take in X
             */
            /// Internal Thought Process ///
            /*
             * So the inputs we're going to get are N which is the total number of steps
             * We're also getting X which is the number of steps that can be climbed at a time
             * So, per delimiting value of X we're going to need to recusively determine the number of unique ways we can climb the staircase
             * and also order said steps afterwords
             * 
             * in the switch above we have variables set so we can pass through both the total steps and an array of integers to iterate through
             * what we should expect to return is not "void" but a delimited array, example:
             * int[,] rList = new int [numberInArray, x.count()] 
             * {
             *    {1,2,3,4},
             *    {5,6,7,8},
             *    {4,3,2,1},
             *    {8,7,6,5}
             * };
             * 
             */
        }
        #endregion

        #region Jaden Case Converter - 1/24/2022
        /*
         * Jaden Smith, the son of Will Smith, is the star of films such as The Karate Kid (2010) and After Earth (2013). 
         * Jaden is also known for some of his philosophy that he delivers via Twitter. When writing on Twitter, he is known for 
         * almost always capitalizing every word. For simplicity, you'll have to capitalize each word, check out how contractions are expected to be in the example below.
         * Your task is to convert strings to how they would be written by Jaden Smith. The strings are actual quotes from Jaden Smith, 
         * but they are not capitalized in the same way he originally typed them.
         */

        static string ToJadenCase(this string phrase)
        {
            // Garbage in garbage out, lets clean this up first with some guards
            if (phrase.Length == 0) // the string is empty, there's nothing for us to change here, you can have your "phrase" back now :)
            {
                Console.WriteLine($"You have entered in {phrase} which appears to be an empty string. Please provide a sentance.");
                return phrase;
            }

            // This is what we're going to give them back
            string rPhrase = "";

            // First we need to split up the sentence into bite sized peices, in this case separating by whitespace
            string[] subs = phrase.Split(' '); // https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0

            // For each of the "substrings" (words) we want to capitalize the first letter and ONLY the first letter
            foreach (var sub in subs)
            {
                string s = char.ToUpper(sub[0]) + sub.Substring(1);
                rPhrase += s;
                rPhrase += " ";
            }
            return rPhrase.TrimEnd();
        }
        static string ToJadenCaseOneliner(this string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }
        #endregion

        #region Duplicate Encoder - 1/25/2022
        /// <summary>
        /// The goal of today's exercise is to convert a string to a new string where each character in the new string is "(" if that character
        /// appears only once in the original string, or ")" if that character appears more than once in the original string.
        /// Ignore capitalization when determining if a character is a duplicate.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        static string DetermineDuplicate(string msg)
        {
            string output = "";
            string singleInput = "(";
            string multipleInpout = ")";
            int l = msg.Length;

            // We want to ignore whether the characters are uppercase or lowercase when determining a match
            // so it really doesn't have to be this weird mix match case we can simply make them all uniform first
            msg = msg.ToLower();

            // debugging stuffs
            // Console.WriteLine(l);
            // Console.WriteLine(msg);

            // We're going to go through each character in the string we recieved and determine if the letter is occuring once, or more than once in the entire string.
            // Notably this should also include spaces, for reasons??
            // We have two loops here, the first is to go through each of the characters in the string to determine a match and the second is so we don't skip past the beginning characters.

            for (int i = 0; i < l; i++)
            {
                // Console.WriteLine($"i = {i} | {msg[i]}");

                // bool isDuplicate = false;
                for (int ii = 0; ii < l; ii++)
                {
                    if (msg[i] == msg[ii] && i != ii)
                    {
                        // There is at least one other of the same character
                        // Console.WriteLine($"we found a match! {msg[i]} = {msg[ii]}"); // debug
                        output += multipleInpout;
                        break;
                    }
                    else
                    {
                        // There is no other's of the same character
                        if (ii == l - 1)
                        {
                            // Console.WriteLine($"No match was found :("); // debug
                            output += singleInput;
                        }
                    }
                }

            }

            return output;
        }

        #endregion

        #region Take a Ten Minute Walk - 1/27/2022
        /// <summary>
        /// You live in the city of Cartesia where all roads are laid out in a perfect grid. You arrived ten minutes too early to an appointment, 
        /// so you decided to take the opportunity to go for a short walk. The city provides its citizens with a Walk Generating App on their phones -- 
        /// everytime you press the button it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']). 
        /// You always walk only a single block for each letter (direction) and you know it takes you one minute to traverse one city block, so create a 
        /// function that will return true if the walk the app gives you will take you exactly ten minutes (you don't want to be early or late!) and will, 
        /// of course, return you to your starting point. Return false otherwise.
        /// </summary>
        /// <param name="walk"></param>
        /// <returns></returns>

        static bool IsTenMinWalk(string[] walk)
        {
            bool isTenWalk;
            bool didReturnToStart = false;
            int count = 0;

            // Lets make it all lowercase to make things easier on us
            walk = walk.Select(s => s.ToLower()).ToArray();
            // foreach (var item in walk) { Console.WriteLine($"{item.ToString()}"); } // Debug | validate array is lowercase

            // Are we getting the expected data?
            // if anything that was given to us is garbage (whitespaces or null), then we can't determine if it's a ten minute walk
            for (int i = 0; i < walk.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(walk[i]))
                {
                    Console.WriteLine("We have recieved a empy, whitespace, or null reference. Please provide valid information.");
                    return isTenWalk = false;
                }
            }

            // Did we at least walk 10 minutes?
            // Also, did we return to our starting location?
            int EW = 0; // East is positive, west is negative
            int NS = 0; // North is positive, west is negative
            for (int i = 0; i < walk.Length; i++)
            {
                if (walk[i] == "n" || walk[i] == "s" || walk[i] == "e" || walk[i] == "w")
                {
                    if (walk[i] == "n") { NS += 1; }
                    if (walk[i] == "s") { NS -= 1; }
                    if (walk[i] == "e") { EW += 1; }
                    if (walk[i] == "w") { EW -= 1; }

                    count += 1;
                }
            }

            isTenWalk = count >= 10 ? true : false;
            didReturnToStart = EW == 0 && NS == 0 ? true : false;

            return isTenWalk = isTenWalk == true && didReturnToStart == true ? true : false;
        }

        static bool IsValidWalkOptimized(string[] walk)
        {
            if (walk.Length != 10) return false;
            var x = 0; var y = 0;

            foreach (var dir in walk)
            {
                if (dir == "n") x++;
                else if (dir == "s") x--;
                else if (dir == "e") y++;
                else if (dir == "w") y--;
            }

            return x == 0 && y == 0;
        }

        #endregion

        #region Stop gninnipS My sdroW! - 1/28/2022

        /// <summary>
        /// Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed 
        /// (Just like the name of this Kata). Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.
        /// Examples: spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw" spinWords( "This is a test") => returns "This is a test" 
        /// spinWords( "This is another test" )=> returns "This is rehtona test"
        /// </summary>
        /// <param name="phrase"></param>
        static string SpinWordsInit(string phrase) // This was the inital attempt at this problem
        {
            // Does this string contain a whitespace?
            bool hasWhiteSpace = phrase.Contains(" ");
            string rPhrase = "";
            int pl = phrase.Length;

            if (hasWhiteSpace)
            {
                // we need to split the string up so we can manipulate each word
                string[] pArr = phrase.Split(' ');

                // Break it down so we're working word by word
                foreach (var p in pArr)
                {
                    // With each of the words we're going to reverse them if they're greater than 5 letters 
                    for (int i = 0; i <= p.Length; i++)
                    {
                        if (p.Length >= 5)
                        {
                            if (i != p.Length)
                            {
                                rPhrase += p[p.Length - 1 - i];
                            }
                            else
                            {
                                if (i == p.Length)
                                {
                                    rPhrase += " ";
                                }
                            }
                        }
                        else
                        {
                            rPhrase += $"{p} ";
                            break;
                        }
                    }
                    Console.WriteLine($"{p}");
                }

            }
            else
            {
                if (pl >= 5)
                {
                    // Lets reverse the word
                    for (int i = 0; i < pl; i++)
                    {
                        rPhrase += phrase[pl - 1 - i];
                    }
                }
                Console.WriteLine($"{phrase}");
            }

            return rPhrase;
        }

        static string SpinWords(string sentence) // This was the first refactoring attempt at this problem
        {
            // Lets clean this up first
            sentence = sentence.TrimStart();
            // sentence = sentence.TrimEnd();

            // Init
            bool hasWhitespace = sentence.Contains(' ');
            string rSentence = "";
            int sLength = sentence.Length;
            int minWordLength = 5;


            // Adjusting from real to whole number
            if (sLength > 0) sLength--;

            // If we have any whitespaces then we probably have multiple sentences
            if (hasWhitespace)
            {
                // Break up the sentence into a 1d array of words
                string[] sArr = sentence.Split(' ');
                int wLength = 0;

                // Per word, we need to determine if it has the minum amount of letters required in it
                // If it does not then we don't need to make any changes to it
                foreach (var word in sArr)
                {
                    wLength = word.Length;

                    // No reason to reverse any words, just add it to the return and lets move on
                    if (wLength >= minWordLength)
                    {
                        for (int i = 0; i <= wLength; i++)
                        {
                            if (i == wLength)
                            {
                                rSentence += $" ";
                                /// Console.WriteLine(word[wLength - i]);
                            }
                            else
                            {
                                rSentence += word[wLength - 1 - i];
                            }
                        }
                    }

                    if (wLength < minWordLength)
                    {
                        rSentence += $"{word} ";
                    }
                }
            }

            if (sLength >= minWordLength && !hasWhitespace)
            {
                // Lets reverse the word
                for (int i = 0; i <= sLength; i++)
                {
                    rSentence += sentence[sLength - i];
                }
            }

            return rSentence.TrimEnd();
        }

        static string SpinWordsBestPractices(string sentence) // This is the least verbose solution to this problem
        {
            return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
        }

        #endregion

        #region Convert string to camel case - 1/30/2022
        /// <summary>
        /// Complete the method/function so that it converts dash/underscore delimited words into camel casing. 
        /// The first word within the output should be capitalized only if the original word was capitalized 
        /// (known as Upper Camel Case, also often referred to as Pascal case).
        /// 
        /// "the-stealth-warrior" gets converted to "theStealthWarrior"
        /// "The_Stealth_Warrior" gets converted to "TheStealthWarrior"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string ToCamelCaseOriginal(string str)
        {
            // Init
            string rstr = "";
            string[] sArr;

            if (str.Contains('-') && str.Contains('_'))
            {
                char ch = '-';
                int countDash = str.Count(f => (f == ch));
                ch = '_';
                int countUnderscore = str.Count(f => (f == ch));

                // If the dash occurs first
                if (countDash > countUnderscore)
                {
                    var c = "_";
                    str = str.Replace(c.ToString(), String.Empty);
                }
                // if the underscore occurs first=
                if (countDash < countUnderscore)
                {
                    var c = "-";
                    str = str.Replace(c.ToString(), String.Empty);
                }
            }

            if (str.Contains('-'))
            {
                sArr = str.Split('-');

                foreach (var word in sArr)
                {
                    Console.WriteLine($"{word}");
                    rstr += word[0].ToString().ToUpper(); // Capitalize the first letter
                    rstr += word.Substring(1); // Get everything after the first letter
                }
            }
            else if (str.Contains('_'))
            {
                sArr = str.Split('_');
                foreach (var word in sArr)
                {
                    Console.WriteLine($"{word}");
                    // if (word == " " || string.IsNullOrEmpty(word.ToString())) continue;
                    if (word == sArr[0])
                    {
                        rstr += word[0].ToString().ToLower(); // Lowercase the first letter
                        rstr += word.Substring(1); // Get everything after the first letter
                    }
                    if (word != sArr[0])
                    {
                        rstr += word[0].ToString().ToUpper();
                        rstr += word.Substring(1);
                    }
                }
            }

            return rstr;
        }

        static string ToCamelCaseRefactor(string str)
        {
            string rstr = "";

            if (str.Contains('-') || str.Contains('_'))
            {
                string[] sArr = str.Split('-', '_');
                foreach (var word in sArr)
                {
                    if (String.IsNullOrEmpty(word)) continue; // Skip entries that are blank/null after removing the characters
                    if (word == sArr[0]) { rstr += word; continue; } // if it's the first word just output that and go to the next word
                    rstr += word[0].ToString().ToUpper(); // capitalize the first letter
                    rstr += word.Substring(1); // output the remainder of the word
                }
            }

            return rstr;
        }

        static string ToCamelCaseBestPractice(string str)
        {
            return Regex.Replace(str, @"[_-](\w)", m => m.Groups[1].Value.ToUpper());
        }

        #endregion

        #region Find the unique number - 1/31/2022 & 2/1/2022
        /// <summary>
        /// There is an array with some numbers. All numbers are equal except for one. Try to find it! 
        /// findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
        /// findUniq([ 0, 0, 0.55, 0, 0 ]) === 0.55
        /// It’s guaranteed that array contains at least 3 numbers.
        /// The tests contain some very huge arrays, so think about performance.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static int GetUnique(IEnumerable<int> numbers)
        {
            // init
            int rnum;
            int lastNum = -9999;
            int numOne = 0, numOneCount = 0, numTwo = 0, numTwoCount = 0;

            foreach (int num in numbers)
            {
                if (lastNum == -9999) { lastNum = num; numOne = num; } // Only needed for first itteration
                if (numOne == numTwo) numTwo--; // there should never be a case where these two are equal
                if (numTwoCount < 1 && numTwo != num && numOne != num) numTwo = num; // If number two's count is 0 then we have to set the number still
                if (num == numOne) numOneCount++;
                if (num == numTwo) numTwoCount++;
                // Console.WriteLine($"Last Number: {lastNum}| Current Number: {num}| Number One: {numOne}| Num One Count: {numOneCount}| Number two: {numTwo}| Num Two Count: {numTwoCount}"); // Debug
            }

            return rnum = numOneCount < numTwoCount ? numOne : numTwo;
        }

        #endregion

        #endregion // January

        #region February

        #region Move zero's to the end - Feb 1st and 2nd 2022
        /// <summary>
        /// Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int[] MoveZeros(int[] arr)
        {
            // Compare each entry in the array to its neighbor, then move as needed
            for (int i = 0; i < arr.Length; i++)
            {
                var num = arr[i]; // current number
                var cIndex = i; // current index

                // Compare our current num to it's neighbor and only change if it's 0
                // Notably, this can be easily changed to sort from lowest to highest by swapping out the '== 0' for '> num'
                // or from highest to lowest by swapping '== 0' for '< num'!
                while (cIndex > 0 && arr[cIndex - 1] == 0)
                {
                    arr[cIndex] = arr[cIndex - 1];
                    cIndex--;
                }
                arr[cIndex] = num;
            }
            return arr;
        }

        private static int[] MoveZerosCompact(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var num = arr[i]; var cIndex = i; // init
                while (cIndex > 0 && arr[cIndex - 1] == 0) { arr[cIndex] = arr[cIndex - 1]; cIndex--; }
                arr[cIndex] = num;
            }
            return arr;
        }

        private static int[] MoveZerosForCheaters(int[] arr)
        {
            return arr.OrderBy(x => x == 0).ToArray();
        }
        #endregion // 1st and 2nd

        #region Your order, please - Feb 2nd & 3rd 2022
        /// <summary>
        /// Your task is to sort a given string. Each word in the string will contain a single number. This number is the position the word should have in the result.
        /// Note: Numbers can be from 1 to 9. So 1 will be the first word(not 0).
        /// If the input string is empty, return an empty string. The words in the input String will only contain valid consecutive numbers.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string OrderWordByNumber(string words)
        {
            // Looks like we can reliably dilimit the string based on spaces, and we can also expect each word to "contain" a number
            string ret = "";
            string[] arr = words.Split(' '); // We need to dilimit the word's in words by space to make this easier to parse through
            string[] retArr = new string[arr.Length]; // Now that we know the length of what we're working with lets store those words in the order we want

            // Lets check to see what number the word contains, then we're going to add it to the array based on that number
            foreach (var word in arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (word.Contains($"{i + 1}")) retArr[i] = word; // Change i to a real number from a whole number, and set the value based on entry
                }
            }
            foreach (var word in retArr) ret += $"{word} "; // let's add this to our output and return the string they requested

            return ret.TrimEnd();
        }

        public static string OrderWordByNumberBirdie(string words)
        {
            if (string.IsNullOrEmpty(words)) return words;
            return string.Join(" ", words.Split(' ').OrderBy(s => s.ToList().Find(c => char.IsDigit(c))));
        }

        #endregion // your order, please

        #region Bit Counting - Feb 3rd - 5th 2022
        /// <summary>
        /// Write a function that takes an integer as input, and returns the number of bits that are equal to one in 
        /// the binary representation of that number. You can guarantee that input is non-negative.
        /// Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <thoughts>
        /// The description could be a bit better buuuut, it looks like what they're trying to say is that we need to find the number of 1's in the 
        /// bionary representation, in example 10011010010 there are 5 "1's" total so we should return "5".
        /// But first we need to take whatever number is provided to us, then convert that into its bionary representation.
        /// 
        /// </thoughts>
        private static int CountBits(int n)
        {
            // Convert the value that was passed through into a binary string
            string binary = Convert.ToString(n, 2);
            // Count the number of time's "1" occurs within the "binary" string
            n = 0;
            foreach(var bit in binary) { if (bit.ToString() == "1") n++; }
            return n;
        }

        private static int CountBitsHoleInOne(int n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }

        #endregion

        #region Narcissistic Numbers - Feb7th
        /// <summary>
        /// A Narcissistic Number is a positive number which is the sum of its own digits, each raised to the 
        /// power of the number of digits in a given base. In this Kata, we will restrict ourselves to decimal (base 10).
        /// For example, take 153 (3 digits), which is narcisstic:
        ///     1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
        /// and 1652 (4 digits), which isn't:
        ///     1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938
        /// The Challenge:
        /// Your code must return true or false (not 'true' and 'false') depending upon whether the given number is a Narcissistic 
        /// number in base 10. This may be True and False in your language, e.g.PHP.
        /// Error checking for text strings or other invalid inputs is not required, only valid positive non-zero integers 
        /// will be passed into the function.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNarcissistic(long n)
        {
            int nLength = (int)n.ToString().Length; // number of digits in 'value'
            int r = 0; // returned value
            int p = 0; // 'to the power of' done the 'hard way' as it's more performant than Math.Pow(x,y);
            string val = n.ToString();

            for (int i = 0; i < nLength; i++)
            {
                int v = (int)Char.GetNumericValue(val[i]);
                p = v;
                for (int ii = 1; ii < nLength; ii++) { p *= v; } // to the power of...
                r += p;
            }
            return r == (int)n ? true : false;
        }

        public static bool IsNarcissisticHIO(long n)
        {
            return n.ToString().Sum(c => (long)Math.Pow(long.Parse(c.ToString()), n.ToString().Length)) == n;
        }


        #endregion // Does my number look big in this

        #region Most frequently used words in a text

        private static List<string> GetTop3UsedWords(string s)
        {
            return null;
        }

        #endregion // Most frequently used words in a text

        #region Where my anagrams at?

        public static List<string> Anagrams(string word, List<string> words)
        {
            throw new NotImplementedException();
        }

        #endregion // Where my anagrams at?

        #endregion // February

        #endregion // Source Code


    }
}