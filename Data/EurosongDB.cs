using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using System.Threading.Tasks;
using Eurovision_Programming_Web.Models;

namespace Eurovision_Programming_Web.Data
{
    public class EurosongDB : EurosongInterface
    {
        LiteDatabase data = new LiteDatabase("Eurovision.db");

        //Add song
        public void addSong(Song song)
        {
            data.GetCollection<Song>("Songs").Insert(song);
        }

        //Fetch all songs
        public IEnumerable<Song> getSongs()
        {
            return data.GetCollection<Song>("Songs").FindAll();
        }

        //Get specific song based on the inputted ID
        public Song getSpecificSongOnID(int ID)
        {
            return data.GetCollection<Song>("Songs").FindById(ID);
        }

        //Delete all songs
        public void deleteAllSongs()
        {
            data.GetCollection<Song>("Songs").DeleteAll();
        }

        //Delete song on ID
        public void deleteSongOnID(int ID)
        {
            data.GetCollection<Song>("Songs").Delete(ID);
        }

        public void updateSong(int ID, Song song)
        {
            data.GetCollection<Song>("Songs").Update(ID, song);
        }

        //Add artist
        public void addArtist(Artist artist)
        {
            data.GetCollection<Artist>("Artists").Insert(artist);
        }
        //Get all artists
        public IEnumerable<Artist> getArtists()
        {
            return data.GetCollection<Artist>("Artists").FindAll();
        }

        //Get specific artist based on the inputted ID
        public Artist getSpecificArtistOnID(int ID)
        {
            return data.GetCollection<Artist>("Artists").FindById(ID);
        }

        //Delete all artists
        public void deleteAllArtists()
        {
            data.GetCollection<Artist>("Artists").DeleteAll();
        }

        //Delete artist on ID
        public void deleteArtistOnID(int ID)
        {
            data.GetCollection<Artist>("Artists").Delete(ID);
        }


        public void updateArtist(int ID, Artist artist)
        {
            data.GetCollection<Artist>("Artists").Update(ID, artist);
        }


        public void addVote(Vote vote)
        {
            data.GetCollection<Vote>("Votes").Insert(vote);
        }

        public void deleteAllVotes()
        {
            data.GetCollection<Vote>("Votes").DeleteAll();
        }

        public void deleteVoteOnID(int ID)
        {
            data.GetCollection<Vote>("Votes").Delete(ID);
        }

        public IEnumerable<Vote> getVotes()
        {
            return data.GetCollection<Vote>("Votes").FindAll();
        }

        public Vote getSpecificVoteOnID(int ID)
        {
            return data.GetCollection<Vote>("Votes").FindById(ID);
        }


        public void updateVotes(int ID, Vote vote)
        {
            data.GetCollection<Vote>("Votes").Update(ID, vote);
        }
    }
}
