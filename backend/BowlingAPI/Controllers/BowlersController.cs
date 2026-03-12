using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingAPI.Models;

// BowlersController.cs
// BowlersController class that handles HTTP requests related to bowlers, including
namespace BowlingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlersController : ControllerBase
    {
        private BowlingLeagueContext _context;

        // Constructor that takes a BowlingLeagueContext and assigns it to the _context field
        public BowlersController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        // GET method that retrieves a list of bowlers who are on the Marlins or Sharks teams,
        // including their team name and other details, and returns it as an IEnumerable of anonymous objects
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

            // Return the list of bowlers as an IEnumerable of anonymous objects
            return bowlerList;
        }
    }
}