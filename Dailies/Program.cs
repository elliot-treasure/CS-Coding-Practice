﻿
using System;
using System.Linq;
using System.Globalization; // Jaden Case Converter

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
            Y2022 activeProblem = Y2022.Jan27th;
            string phrase = "";

            switch (activeProblem)
            {
                #region Jan 2022
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
                #endregion

                default:
                    // Hey goof ball, go change the activeProblem to the corresponding challenge day!
                    break;
            }

        }

        #region Month and Day Enum
        // by default simply assigning int values to an enum doesn't make them enum's, you need to assign a ": type" | https://www.tutorialsteacher.com/csharp/csharp-enum
        private enum Y2022: int 
        {
            Jan23rd = 1,
            Jan24th = 2,
            Jan25th = 3,
            Jan27th = 4
        }
        #endregion

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
                    } else
                    {
                        // There is no other's of the same character
                        if (ii == l-1)
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

        static bool IsTenMinWalk (string[] walk)
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

        static bool IsValidWalkOptimized (string[] walk)
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
    }
}