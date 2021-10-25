using Eurovision_Programming_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurovision_Programming_Web.Data
{
    public interface EurosongInterface
    {

        /// SONGS ///
        
        //Voids 
        void addSong(Song song);
        void deleteAllSongs();
        void deleteSongOnID(int ID);
        void updateSong(int ID, Song song);

        //OO's
        IEnumerable<Song> getSongs();
        Song getSpecificSongOnID(int ID);

        /// ARTISTS /// 

        //Voids
        void addArtist(Artist artist);
        void deleteAllArtists();
        void deleteArtistOnID(int ID);
        void updateArtist(int ID, Artist artist);


        //OO's
        IEnumerable<Artist> getArtists();
        Artist getSpecificArtistOnID(int ID);

        /// Votes /// 

        //Voids
        void addVote(Vote vote);
        void deleteAllVotes();
        void deleteVoteOnID(int ID);
        void updateVotes(int ID, Vote vote);


        //OO's
        IEnumerable<Vote> getVotes();
        Vote getSpecificVoteOnID(int ID);
    }
}
