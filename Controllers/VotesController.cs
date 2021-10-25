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
    public class VotesController : ControllerBase
    {
        //Initializing the _data
        private EurosongInterface _data;

        //Set data equal to _data
        public VotesController(EurosongInterface data)
        {
            _data = data;
        }

        //Posting a vote
        [HttpPost]
        public ActionResult Post([FromBody] Vote vote)
        {
            _data.addVote(vote);
            return Ok("Vote was added");
        }

        //Getting all votes
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> fetchVotes()
        {
            return Ok(_data.getVotes());
        }

        //Getting specific vote on ID
        [HttpGet("{ID}")]
        public ActionResult<Artist> voteID(int ID)
        {
            Vote v = _data.getSpecificVoteOnID(ID);
            if (v != null) return Ok(v);
            return NotFound("Vote not found! Try another ID!");
        }

        //Deleting all songs
        [HttpDelete]
        public ActionResult delVote()
        {
            _data.deleteAllVotes();
            return Ok("All votes were deleted");
        }

        //Deleting a specific song on ID
        [HttpDelete("{ID}")]
        public ActionResult deleteVote(int ID)
        {
            if (_data.getSpecificVoteOnID(ID) != null) _data.deleteVoteOnID(ID); return Ok("Vote was deleted");
            return NotFound("Vote was not found & not deleted");
        }

        [HttpPut("{ID}")]
        public ActionResult<Vote> voteupdate(int ID, Vote vote)
        {
            Vote v = _data.getSpecificVoteOnID(ID);
            if (v != null) _data.updateVotes(ID, vote); return Ok("Vote was updated");
            return NotFound("Vote couldn't be found and therefore isn't updated");
        }
    }
}
