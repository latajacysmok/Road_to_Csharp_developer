using System;
using System.Collections.Generic;

namespace Option
{
    public class Operations<T>
    {
        protected List<T> itemList = new List<T>();
        public virtual void Delete<T>(List<T> list) where T : class
        {
            //if (PrintOut()) return;
            int numer = Security.GetNumber();
            list.RemoveAt(numer - 1);
        }
        
        public virtual T Select<T>(List<T> list) where T : class
        {
            //if (PrintOut()) return;
            int numer = Security.GetNumber();
            return list[numer - 1];
        }

        public virtual void AddItem(object item)
        {
            itemList.Add((T)item);
        }
    }
}
