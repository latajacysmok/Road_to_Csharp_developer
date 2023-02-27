/*Zadanie 3 - stwórz aplikację w której:
użytkownika wprowadza jakiś tekst
tekst zostanie zmanipulowany - odwrócony, wypisany dużymi literami, wypisany małymi literami
ilość znaków w tekście zostanie policzona i wypisana
podzielony na litery i wypisany
skorzystaj z różnych możliwości do łączenia stringów w kodzie
użyj 2 innych metod do manipulacji na stringu*/
using System;
using System.Xml.Linq;

Console.Write("My dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
string word = Console.ReadLine();
char[] wordArray = word.ToCharArray();
Array.Reverse(wordArray);
//Concatenate string using String.Join method 
Console.Write($"Inverted yours text: {String.Join("", wordArray)}\n");
Console.Write($"Your text in capital letters: {word.ToUpper()}\n");
Console.Write($"Your text in lowercase: {word.ToLower()}\n");
Console.Write($"Number of characters in your text: {word.Count()}\n");
for( int c = 0; c < word.Count(); c++)
{
    if( c < word.Count() - 1) Console.Write(word[c] + ", ");
    else if( c == word.Count() - 1) Console.Write(word[c] + ".\n");
}

//Concatenate String Using + Operator
Console.WriteLine("Hello Dear user, " + "your string is: " + word + ".");
//String Interpolation
Console.WriteLine($"Hello Dear user, your string is: {word}.");
//Concatenate string method
Console.WriteLine("Hello Dear user, your string is: {0}.", word);

// Use StringBuilder for concatenation in tight loops.
var sb = new System.Text.StringBuilder();
for (int i = 0; i < 20; i++) sb.AppendLine(i.ToString());
Console.WriteLine(sb.ToString());

//Concatenate string using String.Concate method
string usreName = "Stefek";
string.Concat(usreName, word);

Console.WriteLine("---------------------");
// compare word and usreName
Boolean result1 = word.Equals(usreName);
Console.WriteLine($"Comparing whether \"{word}\" is equal to \"{usreName}\":\t {result1}");

//returns the position of the specified character in the string
Console.Write($"We are looking for the index of the first occurrence of the letter 'x': ");
if (word.IndexOf("x") < 0) Console.WriteLine($"The specified letter \"x\" is missing in the string: {word}");
else Console.WriteLine(word.IndexOf("x"));

//returns substring of a string
Console.WriteLine($"We print now substring which start from index 0 and end in 5 position: {word.Substring(0, 5)} ");

//splits the string into substring
Console.WriteLine($"We print now our string but splits a letter: ");
foreach (string letter in word.Split("")) Console.Write(letter);

Console.ReadKey();


