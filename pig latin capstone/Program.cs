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
                string[] words = input.Split();

                foreach(string word in words) // this does words now and i switched all 'input' with 'word'
                {
                    if (input.Trim().Length == 0) // FINALLY GOT IT TO WORK, JUST MAKE IT IF THE LENGTH OF THE USERINPUT == 0
                    {
                        Console.WriteLine("You must type something");
                    }
                    else
                    {
                        char[] Voids = { '@', '%', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '$', '#', '&' };

                        foreach (char c in lower.ToCharArray())
                        {
                            if (word.Trim().Contains(Voids[0]) || word.Trim().Contains(Voids[1]) || word.Trim().Contains(Voids[2]) || word.Trim().Contains(Voids[3]) || word.Trim().Contains(Voids[4]) || word.Trim().Contains(Voids[5]) || word.Trim().Contains(Voids[6]) || word.Trim().Contains(Voids[7]) || word.Trim().Contains(Voids[8]) || word.Trim().Contains(Voids[9]) || word.Trim().Contains(Voids[10]) || word.Trim().Contains(Voids[11]) || word.Trim().Contains(Voids[12]) || word.Trim().Contains(Voids[13]) || word.Trim().Contains(Voids[14]))
                            {
                                Console.WriteLine(word.Trim());
                                break;
                            }
                            else
                            {
                                bool vowel = IsVowel(word);
                                break;
                            }
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
                else if (userInput.IndexOfAny(Vowels) == -1) //if there are no vowels =)
                {
                    Console.WriteLine(userInput + "ay");
                    return true;
                }
                else
                {
                    // Console.WriteLine("The first vowel in {0} is at index {1}", userInput, userInput.IndexOfAny(Vowels));
                    string[] word = userInput.Split(Vowels);
                    string sub = userInput.Substring(userInput.IndexOfAny(Vowels));

                    Console.WriteLine(sub.Trim() + word[0] + "ay");

                    /*string firstLetter = userInput.Trim().Substring(0, 1);
                    string restOfWord = userInput.Substring(1, userInput.Length - 1); // -1 becasue .lenth will output as many charcters that there is starting at 1 and so itll alawys be one position too far since arrays start at 0 not 1. 
                                                                                        //just moving the first letter idk how to get it to move all the consonants before the first vowel
                    userInput = restOfWord.Trim() + firstLetter.Trim() + "ay";
                    Console.WriteLine(userInput);*/ //this is just nice notes for ranging things
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
