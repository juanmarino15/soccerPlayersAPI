
using Microsoft.AspNetCore.Mvc;
using soccerPlayersApp.Data.Interfaces;

namespace soccerPlayersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        private readonly ISPRepository _spRepository;
       public SPController(ISPRepository sPRepository)
       {
        _spRepository = sPRepository;
       }

       [HttpGet("GetPlayer")]
       public async Task<Player> GetPlayer(string name, int jerseyNumber)
       {
        var x = await _spRepository.GetPlayer(name, jerseyNumber);
        return x;
       }

       [HttpGet("GetPlayerList")]
       public async Task<List<Player>> GetyPlayerList()
       {
        var x = await _spRepository.GetPlayerList();
        return x;
       }

       [HttpGet("CreatePlayer")]
       public async Task<int> CreatePlayer(int jerseyNumber, string name)
       {
        var x = await _spRepository.CreatePlayer(jerseyNumber, name);
        return x;
       }


    }
}