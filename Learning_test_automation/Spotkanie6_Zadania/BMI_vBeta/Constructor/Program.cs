﻿using Performer;

namespace Constructor
{
    class Program
    {
        static public void Main(string[] args)
        {
            while (true)
            {
                Announcement announcementVerdict = new Announcement();
                announcementVerdict.ApplicationRunner();
            }
        }
    }
}
