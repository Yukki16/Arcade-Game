using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SFX : GameObject
    {
        public enum Songs
        {
            Song1,
            Song2,
            Song3,
            None
        }

        //Songs possibleSong;
        private SoundChannel currentSongPlaying;

        public Sound Song_1;
        public Sound Song_2;
        public Sound Song_3;
        public SFX()
        {
            
        }

        public void LoadSongs()
        {
            Song_1 = new Sound("Music/song_1.mp3");
            Song_2 = new Sound("Music/song_1.mp3");
            Song_3 = new Sound("Music/song_1.mp3");     
        }

        public void PlaySong(Songs songToPlay)
        {
            if(currentSongPlaying != null)
            currentSongPlaying.Stop();

            if (songToPlay == SFX.Songs.Song1)
            {
                currentSongPlaying = Song_1.Play(false, 0, 0.5f, 0);
            }
            else if (songToPlay == SFX.Songs.Song2)
            {
                currentSongPlaying = Song_2.Play(false, 0, 0.5f, 0);
            }
            else if (songToPlay == SFX.Songs.Song3)
            {
                currentSongPlaying = Song_3.Play(false, 0, 0.5f, 0);
            }
        }
    }
}
