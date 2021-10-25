using Eurovision_Programming_Web.Data;
using Eurovision_Programming_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eurovision_Programming_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        //Initializing the _data
        private EurosongInterface _data;

        //Set data equal to _data
        public SongsController(EurosongInterface data)
        {
            _data = data;
        }

        //Posting a song
        [HttpPost]
        public ActionResult Post([FromBody] Song song)
        {
            _data.addSong(song);
            return Ok("Song was added");
        }

        //Getting all songs
        [HttpGet]
        public ActionResult<IEnumerable<Song>> fetchSongs()
        {
            return Ok(_data.getSongs());
        }

        //Getting specific song on ID
        [HttpGet("{ID}")]
        public ActionResult<Song> SongID(int ID)
        {
            Song s = _data.getSpecificSongOnID(ID);
            if (s != null) return Ok(s);
            return NotFound("Song not found! Try another ID!");
        }

        //Deleting all songs
        [HttpDelete]
        public ActionResult delSong()
        {
            _data.deleteAllSongs();
            return Ok("All songs were deleted");
        }

        //Deleting a specific song on ID
        [HttpDelete("{ID}")]
        public ActionResult Delete(int ID)
        {
            if (_data.getSpecificSongOnID(ID) != null) _data.deleteSongOnID(ID); return Ok("Song was deleted");
            return NotFound("Song was not found & not deleted");
        }

        [HttpPut("{ID}")]
        public ActionResult<Song> songupdate(int ID, Song song)
        {
            Song s = _data.getSpecificSongOnID(ID);
            if (s != null) _data.updateSong(ID, song);  return Ok("Song was updated");
            return NotFound("Song couldn't be found and therefore isn't updated");
        }
    }
}
