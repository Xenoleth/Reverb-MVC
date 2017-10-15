using Reverb.Data.Models;
using System;
using System.Collections.Generic;

namespace Reverb.Services.Contracts
{
    public interface ISongModifyService
    {
        void UpdateSong(Guid id, string title, string artistName, string albumName, int? duration, ICollection<string> selectedGenres, string lyrics, string videoUrl, string coverUrl);

        void DeleteSong(Guid id);
    }
}
