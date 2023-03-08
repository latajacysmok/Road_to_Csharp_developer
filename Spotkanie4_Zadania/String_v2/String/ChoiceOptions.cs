namespace Word
{
    class ChoiceOptions
    {
        public void PossibleOption()
        {
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
        }
        public void ExecutionOption()
        {
            PossibleWordOperation possibleWordOperation = new PossibleWordOperation();
            bool rightNumber = true;
            string word = TakeWord();

            while (true)
            {
                switch (EnterNumber())
                {
                    case 1:
                        possibleWordOperation.PrintWord(word);
                        break;
                    case 2:
                        possibleWordOperation.ReverseWord(word);
                        break;
                    case 3:
                        possibleWordOperation.ConcatenateWords(possibleWordOperation.ChangeWordToArray(word));
                        break;
                    case 4:
                        possibleWordOperation.ToUpper(word);
                        break;
                    case 5:
                        possibleWordOperation.ToLower(word);
                        break;
                    case 6:
                        possibleWordOperation.CountNumberOfLettersInGivenWord(word);
                        break;
                    case 7:
                        possibleWordOperation.SpellWord(word);
                        break;
                    case 8:
                        possibleWordOperation.ConcatenateString(word);
                        break;
                    case 9:
                        possibleWordOperation.CompareWord(word);
                        break;
                    case 10:
                        possibleWordOperation.PrintSubstringFromTo(word);
                        break;
                    case 11:
                        possibleWordOperation.SplitString(word);
                        break;
                    case 12:
                        possibleWordOperation.ReturnPositionOfIndicatedCharacter(word);
                        break;

                    default:
                        Console.Write("The selected number is not from 1 to 10. Please try again: ");
                        rightNumber = false;
                        break;
                }
                if (rightNumber) break;// a dobra już sobie przypomniałem to musi być jak liczba nie jest 1-12 to znowu pyta, default tego nie załatwia
                else rightNumber = true;
            }

        }

        public string TakeWord()
        {
            string word;
            while (true)
            {
                Console.Write("My dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
                word = Console.ReadLine();
                if (!String.IsNullOrEmpty(word)) break;
                else Console.WriteLine("My dear user, provide not empty string.");
            }
            return word;
        }

        public int EnterNumber()
        {
            int numberCandidate;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numberCandidate)) break;
                else Console.Write($"Dear User, this is not a number, please try again: ");
            }
            return numberCandidate;
        }
    }
}
