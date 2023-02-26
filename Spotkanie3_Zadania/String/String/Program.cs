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
Console.WriteLine("Hello Dear user, " + "your string is " + word + ".");
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

//Concatenate string using String.Join method 
int[] intArray = { 1, 3, 5, 7, 9 };
String seperator = ", ";
string result = "Int, ";
result += String.Join(seperator, intArray);
Console.WriteLine($"Result: {result}");
Console.ReadKey();

