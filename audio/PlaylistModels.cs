using System.Collections.Generic;

namespace BetterMediaControls.audio
{
    public class PlaylistFile
    {
        public List<PlaylistEntry> Playlist;
    }

    public class PlaylistEntry
    {
        public string File;
        public string Title;
        public string Artist;
        public float Volume = 1.0f;
    }
}