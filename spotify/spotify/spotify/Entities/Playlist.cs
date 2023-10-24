using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify.Entities

{
    internal class Playlist
    {

        public Guid Id { get; set; }
        private List<Song> Songs { get; set; }
        private Random random;
        public Playlist()
        {
            Id = Guid.NewGuid();
            Songs = new List<Song>();
        }
        public Playlist(Song firstSong) : this()
        {
            AddSong(firstSong);
            random = new Random();
        }
        public void AddSong(Song song)
        {
            if (song != null)
            {
                Songs.Add(song);
            }
        }
        public string GetSongs()
        {
            return string.Join("\n", Songs.Select(song => song.Title));

        }
        public void ShuffleSongs()
        {
            int countOfSongs = Songs.Count;
            while (countOfSongs > 0)
            {
           
                countOfSongs--;
                Song song = Songs[countOfSongs];
                int randomIndex = random.Next(countOfSongs);
                Songs[countOfSongs] = Songs[randomIndex];

                Songs[randomIndex] = song;
            }
        }

    }
}