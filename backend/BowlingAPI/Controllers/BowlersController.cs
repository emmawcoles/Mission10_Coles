using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingAPI.Models;

namespace BowlingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlersController : ControllerBase
    {
        private BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        [HttpGet(Name = "GetBowlers")]
        public IEnumerable<object> Get()
        {
            var bowlerList = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null &&
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
                .Select(b => new
                {
                    BowlerId = b.BowlerId,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerLastName = b.BowlerLastName,
                    TeamName = b.Team != null ? b.Team.TeamName : "",
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber
                })
                .ToList();

            return bowlerList;
        }
    }
}