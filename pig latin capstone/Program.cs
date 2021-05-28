using System;
using System.Linq;
namespace pig_latin_capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool again = true;
            while(again == true)
            {
                Console.WriteLine("Please write a word to be translated");
                string input = Console.ReadLine();
                string lower = input.ToLower();
                

                if (input == null)
                {
                    Console.WriteLine("You must type something");
                    again = GoAgain();
                }
                else
                {
                    char[] Voids = { '@', '%', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '$', '#', '&' };
                    foreach (string letter in lower.Split())
                    {
                        if (input.Trim().Contains(Voids[0]) || input.Trim().Contains(Voids[1]) || input.Trim().Contains(Voids[2]) || input.Trim().Contains(Voids[3]) || input.Trim().Contains(Voids[4]) || input.Trim().Contains(Voids[5]) || input.Trim().Contains(Voids[6]) || input.Trim().Contains(Voids[7]) || input.Trim().Contains(Voids[8]) || input.Trim().Contains(Voids[9]) || input.Trim().Contains(Voids[10]) || input.Trim().Contains(Voids[11]) || input.Trim().Contains(Voids[12]) || input.Trim().Contains(Voids[13]) || input.Trim().Contains(Voids[14]))
                        {
                            Console.WriteLine(input.Trim());
                            break;
                        }
                        else
                        {
                            bool vowel = IsVowel(input);
                            break;
                        }
                    }
                }
                again = GoAgain();
            }
            
        }

        public static bool IsVowel(string userInput) 
        {
            string low = userInput.ToLower();

            char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };
         
            foreach (char c in low.ToCharArray())
            {
                if (Vowels.Contains(c))
                {
                    string translate = userInput.Trim() + "way";
                    Console.WriteLine(translate);
                    return true;
                }
                else
                {
                    Console.WriteLine("The first vowel in {0} is at index {1}", userInput, userInput.IndexOfAny(Vowels));
                    string[] word = userInput.Split(Vowels);
                    string sub = userInput.Substring(userInput.IndexOfAny(Vowels), userInput.Length - 1);

                    Console.WriteLine(sub + word[0] + "ay");

                    string firstLetter = userInput.Trim().Substring(0, 1);
                    string restOfWord = userInput.Substring(1, userInput.Length - 1); // -1 becasue .lenth will output as many charcters that there is starting at 1 and so itll alawys be one position too far since arrays start at 0 not 1. 
                                                                                        //just moving the first letter idk how to get it to move all the consonants before the first vowel
                    userInput = restOfWord.Trim() + firstLetter.Trim() + "ay";
                    Console.WriteLine(userInput);
                    return true;
                }
            }
            return IsVowel(userInput);

        }

        public static bool GoAgain()
        {
            Console.Write("Would you like to translate again? Y/N ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y" || input.ToUpper() == "YES")
            {
                Console.WriteLine("");
                Console.WriteLine("");
                return true;
            }
            else if (input.ToUpper() == "N" || input.ToUpper() == "NO")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Must input a valid response.");
                return GoAgain();
            }
        }
    }
}
