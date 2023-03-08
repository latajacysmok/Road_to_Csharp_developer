namespace Word
{
    class PossibleWordOperation
    {
        ChoiceOptions choiceOptions = new ChoiceOptions();

        public void ReverseWord(string word)
        {
            char[] wordeparatedLetters = ChangeWordToArray(word);
            Array.Reverse(wordeparatedLetters);
            Console.WriteLine(string.Join("", wordeparatedLetters));
        }

        public char[] ChangeWordToArray(string word)
        {
            char[] wordArray = word.ToCharArray();
            return wordArray;
        }
        //Concatenate string using String.Join method 
        public void ConcatenateWords(char[] wordArray)
        {
            Console.WriteLine($"Syllable yours text: {string.Join("-", wordArray)}\n");
        }

        public void ToUpper(string word)
        {
            Console.WriteLine($"Your text in capital letters: {word.ToUpper()}\n");
        }

        public void ToLower(string word)
        {
            Console.WriteLine($"Your text in lowercase: {word.ToLower()}\n");
        }

        public void CountNumberOfLettersInGivenWord(string word)
        {
            Console.WriteLine(word.Count());
        }

        public void SpellWord(string word)
        {
            Console.WriteLine("Here is your word divided into separate characters: ");
            for (int c = 0; c < word.Count(); c++)
            {
                if (c < word.Count() - 1) Console.Write(word[c] + ", ");
                else if (c == word.Count() - 1) Console.Write(word[c] + ".\n");
            }
        }

        public void ConcatenateString(string word)
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
        public void CompareWord(string word1)
        {
            Console.Write("Give me now word to compare: ");
            string word2 = choiceOptions.TakeWord();
            bool isTheSameWord = word1.Equals(word2);
            Console.WriteLine($"Comparing whether \"{word1}\" is equal to \"{word2}\":\t {isTheSameWord}");
        }

        //returns the position of the specified character in the string
        public void ReturnPositionOfIndicatedCharacter(string word)
        {
            char letterLookingFor;
            while (true)
            {
                Console.Write("We are looking for the index of the first occurrence of the letter you provided, dear user: ");
                if (char.TryParse(Console.ReadLine(), out letterLookingFor))
                {
                    if (Char.IsNumber(letterLookingFor)) Console.WriteLine("Dear User, you have not entered a letter but a number.");//This is only information for user
                    break;
                }
                else Console.WriteLine("Dear User, you have not entered a letter, please try again.");
            }
            Console.WriteLine($"We are looking for the index of the first occurrence of the letter '{letterLookingFor}'.");
            string result = word.IndexOf(letterLookingFor) < 0 ? $"The specified letter \"{letterLookingFor}\" is missing in the string: {word}" : $"Dear User first occurance in phrase \"{word}\" appear on index: {word.IndexOf(letterLookingFor)}";
            Console.WriteLine(result);
        }

        public void PrintSubstringFromTo(string word)
        {
            int startIndex;
            int endIndex;

            while (true)
            {
                Console.Write("We print now substring which start from index what you want position: ");
                startIndex = choiceOptions.EnterNumber();
                if (startIndex < 0 || word.Length < startIndex)
                {
                    Console.WriteLine($"Your start index: {startIndex} is smaller than 0 or larger than your word length. Try again please.");
                    continue;
                }

                Console.Write("We print now substring which end in what you want position: ");
                endIndex = choiceOptions.EnterNumber();

                if (endIndex < 0 || word.Length < endIndex)
                {
                    Console.WriteLine($"Your end index: {endIndex} is smaller than 0 or larger than your word length. Try again please.");
                    continue;
                }
                else if (startIndex > endIndex)
                {
                    Console.WriteLine($"You entered start index: {startIndex} larger than end index: {endIndex}. Try again please.");
                }
                else break;
            }
            Console.WriteLine($"We print now substring which start from index {startIndex} and end in {endIndex} position: {word.Substring(startIndex, endIndex)} ");
        }

        public void SplitString(string word)
        {
            Console.WriteLine($"We print now our string but splits a letter: ");
            string[] words = word.Split(' ');

            foreach (var letter in words)
            {
                Console.WriteLine($"<{letter}>");
            }
            Console.WriteLine("");
        }

        public void PrintWord(string word)
        {
            Console.WriteLine($"Your word is: {word}");
        }
    }
}




