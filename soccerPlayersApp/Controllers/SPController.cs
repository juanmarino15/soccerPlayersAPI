
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
    }
}