
using soccerPlayersApp.Data.Interfaces;

namespace soccerPlayersApp.Data.Repositories
{
    public class SPRepository : ISPRepository
    {
        public readonly JuanDevContext _databaseContext;
        public SPRepository(JuanDevContext dbContext)
        {
            _databaseContext = dbContext;
        }

        //receving the amount of rows that were modified
        public async Task<int> CreatePlayer(int jerseyNumber, string name)
        {
            //for non read operations we use "Database" and "executesqlinterpolated" instead of "player"
           var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec CreatePlayer @jerseyNumber = {jerseyNumber}, @name={name}");
            return affectedRows;
        }

        public Task<dynamic> GetJoinedPlayerList()
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayer(string name, int jerseyNumber)
        {
            var playersObject = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayer @jerseyNumber = {jerseyNumber}, @name={name}").ToListAsync();
            return playersObject.FirstOrDefault();
        }

        public async Task<List<Player>> GetPlayerList()
        {
            var playersObject = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayersList").ToListAsync();
            return playersObject;
        }

        public Task<int> UpdatePlayer(int teamId, int playerId)
        {
            throw new NotImplementedException();
        }
    }
}