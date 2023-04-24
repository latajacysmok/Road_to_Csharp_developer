using Option;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ListOfPeople : Operations<Person>
    {
        private List<Person> peopleList;

        public List<Person> PeopleList
        {
            get { return peopleList; }
        }

        public ListOfPeople()
        {
            peopleList = new List<Person>();
        }

        public override void AddItem(object item)
        {
            peopleList.Add((Person)item);
        }

        public bool PrintOut()
        {
            bool ifExit = false;
            StringBuilder listOfPeople = new StringBuilder();

            if (this.peopleList.Count == 0)
            {
                listOfPeople.Append("\nLista osób jest pusta! Aby zobaczyć jakąś zawartość wpierw dodaj osobę.\n");
                ifExit = true;
            }
            else
            {
                listOfPeople.Append("\n---------\n");
                listOfPeople.Append("OSOBY: \n");
                for (int i = 0; i < this.peopleList.Count; i++)
                {
                    listOfPeople.Append($"{i + 1} - {this.peopleList[i]}\n");
                }
                listOfPeople.Append("\n");
            }
                      
            string result = listOfPeople.ToString();
            Console.WriteLine(result);
            return ifExit;
        }

        public override void Delete<T>(List<T> list)
        {
            if (PrintOut()) return;
            base.Delete(list);
        }

        public override T Select<T>(List<T> list)
        {
            if (PrintOut()) return null;
            else return base.Select(peopleList) as T;
        }
    }
}
