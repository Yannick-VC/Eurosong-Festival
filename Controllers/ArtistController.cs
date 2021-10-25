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
    public class ArtistController : ControllerBase
    {
        //Initializing the _data
        private EurosongInterface _data;

        //Set data equal to _data
        public ArtistController(EurosongInterface data)
        {
            _data = data;
        }

        //Posting a song
        [HttpPost]
        public ActionResult Post([FromBody] Artist artist)
        {
            _data.addArtist(artist);
            return Ok("Artist was added");
        }

        //Getting all songs
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> fetchArtists()
        {
            return Ok(_data.getArtists());
        }

        //Getting specific song on ID
        [HttpGet("{ID}")]
        public ActionResult<Artist> artistID(int ID)
        {
            Artist s = _data.getSpecificArtistOnID(ID);
            if (s != null) return Ok(s);
            return NotFound("Artist not found! Try another ID!");
        }

        //Deleting all songs
        [HttpDelete]
        public ActionResult delArt()
        {
            _data.deleteAllArtists();
            return Ok("All artists were deleted");
        }

        //Deleting a specific song on ID
        [HttpDelete("{ID}")]
        public ActionResult delete(int ID)
        {
            if (_data.getSpecificArtistOnID(ID) != null) _data.deleteArtistOnID(ID); return Ok("Artist was deleted");
            return NotFound("Artist was not found & not deleted");
        }

        [HttpPut("{ID}")]
        public ActionResult<Song> artistupdate(int ID, Artist artist)
        {
            Artist art = _data.getSpecificArtistOnID(ID);
            if (art != null) _data.updateArtist(ID, artist); return Ok("Artist was updated");
            return NotFound("Artist couldn't be found and therefore isn't updated");
        }
    }
}
