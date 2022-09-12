using System;
using System.Collections.Generic;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song = new Song();
            song.Input();
            List<Song> songs = song.Store();
            song.Display(songs);
            song.FindSongNameByTypeList(songs);


        }
    }
    class Song
    {
        static String[] listSongs;
        public string TypeList
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Time
        {
            get; set;
        }
        public void Input()
        {
            Console.WriteLine("Enter number of songs please !!!: ");
            int numSongs = int.Parse(Console.ReadLine());
            listSongs = new string[numSongs];
            for (int i = 0; i < numSongs; i++)
            {
                Console.WriteLine("Enter type song {0}:",i+1);
                string type = Console.ReadLine()+"_";
                Console.WriteLine("Enter song name {0}:", i + 1);
                string name = Console.ReadLine()+"_";
                Console.WriteLine("Enter song time {0}:", i + 1);
                string time = Console.ReadLine();
                listSongs[i] = String.Concat(type, name, time);    

            }       
        }
        public List<Song> Store() 
        {
            List<Song> songs = new List<Song>();
            for (int i = 0; i < listSongs.Length; i++)
            {   
              string list = listSongs[i];
              string[] data = list.Split("_");
                Song song = new Song();
                song.TypeList = data[0];
                song.Name = data[1];
                song.Time = data[2];
                songs.Add(song);
               

            }

            return songs;
        }
        public void Display(List<Song> songs)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine("Type song {0} : {1}, Name song {0} : {2}, Time song : {3} ", i + 1, songs[i].TypeList, songs[i].Name, songs[i].Time);

            }

        }
        public void FindSongNameByTypeList(List<Song> songs)
        {
            Console.WriteLine("Enter song's type to check name of the songs ");
            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);

                }


            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }

                }
            }

        }
    }   
}
