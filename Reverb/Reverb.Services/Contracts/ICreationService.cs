using System.Collections.Generic;

namespace Reverb.Services.Contracts
{
    public interface ICreationService
    {
        void CreateArtist(string name);

        void CreateGenre(string name);

        void CreateAlbum(string title, string artistName);

        void CreateSong(string title, string artistName, string albumName, int? duration, ICollection<string> genres, string lyrics);
    }
}
