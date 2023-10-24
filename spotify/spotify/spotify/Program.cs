using spotify.Entities;
using spotify.Services;
using _spotify.Services;
using spotify.Entities;

Console.WriteLine();
var song1 = new Song("Haydi Gel Benimle Ol", "Sezen Aksu", "Netd", "Aysel Gürel");
var playlist1 = new Playlist(song1);
playlist1.AddSong(song1);

Console.WriteLine("Before Shuffle:");
Console.WriteLine(playlist1.GetSongs());
playlist1.ShuffleSongs();
Console.WriteLine("\n\nAfter Shuffle:");
Console.WriteLine(playlist1.GetSongs());
NotepadService notepadService = new();
notepadService.PlaylistToNotepad(playlist1);

Console.ReadLine();
