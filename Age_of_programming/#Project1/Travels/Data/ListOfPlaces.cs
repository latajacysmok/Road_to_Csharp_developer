using Option;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Data
{
    public class ListOfPlaces : Operations<Place>
    {
        private List<Place> placesList;
        public List<Place> PlacesList
        {
            get { return placesList; }
        }

        public ListOfPlaces()
        {
            placesList = new List<Place>();
        }

        public void AddPlace()
        {
            Place place = new Place();
            AddItem(place.GetSpot());
        }

        public override void AddItem(object item)
        {
            placesList.Add((Place)item);
        }

        public bool PrintOut()
        {
            bool ifExit = false;
            StringBuilder listOfPlace = new StringBuilder();

            if (placesList.Count == 0)
            {
                listOfPlace.Append("\nLista miejsc jest pusta! Aby zobaczyć jakąś zawartość wpierw dodaj miejsce.\n");
                ifExit = true;
            }
            else
            {
                listOfPlace.Append("\n------------------------\n");
                listOfPlace.Append("\tMIEJSCA: \n");
                for (int i = 0; i < placesList.Count; i++)
                {
                    listOfPlace.Append($"\t-{i + 1}- {placesList[i]}\n");
                }

                listOfPlace.Append("\n");
            }
                
            string result = listOfPlace.ToString();
            Console.WriteLine(result);
            return ifExit;
        }

        public override void Delete<T>(List<T> list)
        {
            if (PrintOut()) return;
            base.Delete(placesList);
        }

        public override T Select<T>(List<T> list)
        {
            if (PrintOut()) return null;
            else return base.Select(placesList) as T;
        }
    }
}
