namespace Word
{
    class Program
    {
        //static string word;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome my dear user to a program showing what can be done with a string in C#.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("\nFirst select the operation you want to perform on the string:");
                SelectOptions();
                MakingDecisionYesorNo();
            }
        }

        static void SelectOption()
        {
            bool rightNumber = true;
            
            Console.WriteLine("1: For print your word.");
            Console.WriteLine("2: Inverted word.");
            Console.WriteLine("3: For concatenate string using 'String.Join'.");
            Console.WriteLine("4: If you want to enlarge letters in your word.");
            Console.WriteLine("5: If you want to change the letters in your word to small ones.");
            Console.WriteLine("6: If you want the number of letters in your word.");
            Console.WriteLine("7: If you want to write each letter separately.");
            Console.WriteLine("8: For print the same sentance in diffrent way.");
            Console.WriteLine("9: If you want to compare words.");
            Console.WriteLine("10: For print your word.");
            Console.Write("\nYou choose: ");
            
            while(true)
            {
                switch (EnterNumber())
                {
                    case 1:
                        Console.WriteLine($"Your word is: {TakeaWord()}");
                        break;
                    case 2:
                        Console.WriteLine(ReverseTheWord(TakeaWord()));
                        break;
                    case 3:
                        Console.WriteLine(ConcatenateWords(ChangeWordToArray(TakeaWord())));
                        break;
                    case 4:
                        Console.WriteLine(EnlargeLetters(TakeaWord()));
                        break;
                    case 5:
                        Console.WriteLine(LettersSmaller(TakeaWord()));
                        break;
                    case 6:
                        Console.WriteLine(CountNumberOfLettersInGivenWord(TakeaWord()));
                        break;
                    case 7:
                        SpellWord(TakeaWord());
                        break;
                    case 8:
                        ConcatenateString(TakeaWord());
                        break;
                    case 9:
                        CompareWord(TakeaWord(), TakeaWord());
                        break;
                    case 10:
                        PrintSubstringFromTo(TakeaWord());
                        break;
                    case 11:
                        SplitsString(TakeaWord());
                        break;
                    default:
                        Console.Write("The selected number is not from 1 to 10. Please try again: ");
                        rightNumber = false;
                        break;
                }
                if (rightNumber) break;
                else rightNumber = true;
                
            }
            
        }

        static string TakeaWord()
        {
            string word;
            while (true)
            {
                Console.Write("My dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
                word = Console.ReadLine();
                if (word != null) break;
                else Console.WriteLine("My dear user, provide not empty string.");
            }
            return word;
        }
        static string ReverseTheWord(string word)
        {
            char[] wordeparatedIntoSingleLetters = ChangeWordToArray(word);
            Array.Reverse(wordeparatedIntoSingleLetters);
            return string.Join("", wordeparatedIntoSingleLetters);
        }

        static char[] ChangeWordToArray(string word)
        {
            char[] wordArray = word.ToCharArray();
            return wordArray;
        }
        //Concatenate string using String.Join method 
        static string ConcatenateWords(char[] wordArray)
        {
            return ($"Syllable yours text: {string.Join("-", wordArray)}\n");
        }

        static string EnlargeLetters(string word)
        {
            return ($"Your text in capital letters: {word.ToUpper()}\n");
        }

        static string LettersSmaller(string word)
        {
            return ($"Your text in lowercase: {word.ToLower()}\n");
        }

        static int CountNumberOfLettersInGivenWord(string word)
        {
            return word.Count();
        }

        static void SpellWord(string word)
        {
            Console.WriteLine("Here is your word divided into separate characters: ");
            for (int c = 0; c < word.Count(); c++)
            {
                if (c < word.Count() - 1) Console.Write(word[c] + ", ");
                else if (c == word.Count() - 1) Console.Write(word[c] + ".\n");
            }
        }

        static void ConcatenateString(string word)
        {
            //Concatenate String Using + Operator
            Console.WriteLine("\nPrint below string use: 'Concatenate String Using + Operator'");
            Console.WriteLine("Hello Dear user, " + "your string is: " + word + ".");

            //String Interpolation
            Console.WriteLine("\nPrint below string use: 'String Interpolation'");
            Console.WriteLine($"Hello Dear user, your string is: {word}.");

            //Concatenate string method
            Console.WriteLine("\nPrint below string use: 'Concatenate string method'");
            Console.WriteLine("Hello Dear user, your string is: {0}.", word);

            // Use StringBuilder for concatenation in tight loops.          
            var mutableSeriesOfCharacters = new System.Text.StringBuilder();
            for (int i = 0; i < 20; i++) mutableSeriesOfCharacters.AppendLine(i.ToString());
            Console.WriteLine("\nPrint below string use: 'StringBuilder for concatenation in tight loops'");
            Console.WriteLine(mutableSeriesOfCharacters.ToString());

            //Concatenate string using String.Concate method
            string first = "CokolwiekDoPrzykładu";
            Console.WriteLine("\nPrint below string use: 'String.Concate method'");
            string.Concat(first, word);
        }

        // compare word and usreName
        static void CompareWord(string word1, string word2)
        {
            bool isTheSameWord = word1.Equals(word2);
            Console.WriteLine($"Comparing whether \"{word1}\" is equal to \"{word2}\":\t {isTheSameWord}");
        }

        //returns the position of the specified character in the string
        static void ReturnPositionOfIndicatedCharacter(string word)
        {
            char letterLookingFor;
            while (true)
            {
                Console.Write("We are looking for the index of the first occurrence of the letter you provided, dear user: ");
                if (char.TryParse(Console.ReadLine(), out letterLookingFor))
                {
                    if (Char.IsNumber(letterLookingFor))
                    {
                        break;
                    }
                    else Console.WriteLine("Dear User, you have not entered a letter but a number, please try again.");
                }
                else Console.WriteLine("Dear User, you have not entered a letter, please try again.");
            }
            Console.Write($"We are looking for the index of the first occurrence of the letter '{letterLookingFor}': ");
            if (word.IndexOf(letterLookingFor) < 0) Console.WriteLine($"The specified letter \"{letterLookingFor}\" is missing in the string: {word}");
            else Console.WriteLine(word.IndexOf(letterLookingFor));
        }

        //returns substring of a string
        static void PrintSubstringFromTo(string word)
        {
            Console.Write("We print now substring which start from index what you want position: ");
            int startIndex = EnterNumber();

            Console.Write("We print now substring which end in what you want position: ");
            int endIndex = EnterNumber();

            Console.WriteLine($"We print now substring which start from index {startIndex} and end in {endIndex} position: {word.Substring(startIndex, endIndex)} ");
        }

        static int EnterNumber()
        {
            int numberCandidate;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numberCandidate)) break;
                else Console.Write($"Dear User, this is not a number, please try again: ");
            }
            return numberCandidate;
        }

        static void SplitsString(string word)
        {
            Console.WriteLine($"We print now our string but splits a letter: ");
            foreach (string letter in word.Split("")) Console.Write(letter);
        }

        public static void MakingDecisionYesorNo()
        {
            while (true)
            {
                Console.WriteLine($"Dear user do you want to continue: ");
                Console.WriteLine("If 'Yes' enter: '1'.");
                Console.WriteLine("If 'No' enter: '2'.");
                GoOutOrStay(EnterNumber());
                break;
            }
        }

        public static void GoOutOrStay(double ifExit)
        {
            while (true)
            {
                if (ifExit == 1)
                {
                    Console.WriteLine($"So let's get started again dear user.");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                    break;
                }
                else if (ifExit == 2)
                {
                    Console.WriteLine($"See you soon dear user.");
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine($"Your number is: {ifExit}. The given number must equal 1 if you want to continue and 2 if you want to end the program. Try again");
                }
                ifExit = EnterNumber();
            }
        }
    }
}


