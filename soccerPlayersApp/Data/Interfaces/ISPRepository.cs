namespace soccerPlayersApp.Data.Interfaces
{
    public interface ISPRepository
    {
        Task<Player>GetPlayer(string name, int jerseyNumber);
        Task<List<Player>>GetPlayerList();
        Task<dynamic>GetJoinedPlayerList();
        Task<int> UpdatePlayer(int teamId, int playerId);
        Task<int> CreatePlayer(int jerseyNumber, string name);
    }
}