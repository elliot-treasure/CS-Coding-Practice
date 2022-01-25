
using System;
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
            int activeProblem = 3;
            string phrase = "";

            switch (activeProblem)
            {
                case 1: // Number of steps | broken down into groups
                    int N = 40; // Total number of steps
                    int[] X = { 1, 2 };
                    StepClimber(N, X);
                    break;
                case 2: // Jaden Smith casing | kek | COMPLETED - well done me
                    phrase = "if everybody in the wold dropped out of school we would have a much more intelligent society.";
                    Console.WriteLine(ToJadenCase(phrase));
                    // Console.WriteLine(ToJadenCaseOneliner(phrase));
                    break;
                case 3: // Duplicate Encoder | COMPLETED
                    phrase = "SuCCeSS";
                    string duplicatesFound = DetermineDuplicate(phrase);
                    Console.WriteLine(duplicatesFound);
                    break;
                default:
                    // Hey goof ball, go change the activeProblem to the corresponding challenge day!
                    break;
            }

        }

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
    }
}