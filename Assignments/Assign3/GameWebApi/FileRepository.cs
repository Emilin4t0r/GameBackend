using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class FileRepository : IRepository
{
    public static void Main()
    {
        string path = @"D:\School\GameBackend\Assignments\Assign3\GameWebApi\game-dev.txt";
        Player player1 = new Player
        {
            Id = Guid.NewGuid(),
            Name = "plr1",
            Score = 10,
            Level = 5,
            IsBanned = false,
        };

        //File.WriteAllText(path, JsonConvert.SerializeObject(player1));
    }

    public Task<Player> Create(Player player)
    {
        throw new NotImplementedException();
    }

    public Task<Player> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Player[]> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        throw new NotImplementedException();
    }
}