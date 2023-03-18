namespace String
{
    class OptionSelector
    {
        public int WritingOptions()
        {
            Console.Write("\nMy dear user, I am asking you to choose one of the numbers below: \n\n");
            Console.WriteLine("1: For print your word.");
            Console.WriteLine("2: Inverted word.");
            Console.WriteLine("3: For concatenate string using 'String.Join'.");
            Console.WriteLine("4: If you want to enlarge letters in your word.");
            Console.WriteLine("5: If you want to change the letters in your word to small ones.");
            Console.WriteLine("6: If you want the number of letters in your word.");
            Console.WriteLine("7: If you want to write each letter separately.");
            Console.WriteLine("8: For print the same sentance in diffrent way.");
            Console.WriteLine("9: If you want to compare words.");
            Console.WriteLine("10: For print your substring.");
            Console.WriteLine("11: For print write out specially separately from the sentence you wrote the words.");
            Console.WriteLine("12: For find index number occurrence of the character you selected from the sentence you wrote the words.");
            Console.Write("\nYour choice is(1-12): ");
            return EnterNumber();
        }
        public void PerformedOption()
        {
            PossibleWordOperation possibleWordOperation = new PossibleWordOperation();
            bool rightNumber = true;
            string word = TakeWord();

            while (true)
            {
                switch (WritingOptions())
                {
                    case 1:
                        possibleWordOperation.PrintWord(word);
                        return;
                    case 2:
                        possibleWordOperation.ReverseWord(word);
                        return;
                    case 3:
                        possibleWordOperation.ConcatenateWords(possibleWordOperation.ChangeWordToArray(word));
                        return;
                    case 4:
                        possibleWordOperation.ToUpper(word);
                        return;
                    case 5:
                        possibleWordOperation.ToLower(word);
                        return;
                    case 6:
                        possibleWordOperation.CountNumberOfLettersInGivenWord(word);
                        return;
                    case 7:
                        possibleWordOperation.SpellWord(word);
                        return;
                    case 8:
                        possibleWordOperation.ConcatenateString(word);
                        return;
                    case 9:
                        possibleWordOperation.CompareWord(word);
                        return;
                    case 10:
                        possibleWordOperation.PrintSubstringFromTo(word);
                        return;
                    case 11:
                        possibleWordOperation.SplitString(word);
                        return;
                    case 12:
                        possibleWordOperation.ReturnPositionOfIndicatedCharacter(word);
                        return;
                    default:
                        Console.Write("The selected number is not from 1 to 10. Please try again: ");
                        rightNumber = false;
                        break;
                }
            }

        }

        public string TakeWord()
        {
            while (true)
            {
                Console.Write("\nMy dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
                string word = Console.ReadLine();
                if (!string.IsNullOrEmpty(word)) return word;
                else Console.WriteLine("My dear user, provide not empty string.");
            }          
        }

        public int EnterNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numberCandidate)) return numberCandidate;
                else Console.Write($"Dear User, this is not a number, please try again: ");
            }          
        }
    }
}
