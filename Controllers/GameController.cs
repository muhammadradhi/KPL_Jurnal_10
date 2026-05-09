using Microsoft.AspNetCore.Mvc;
using Modul10_103022400055.Model;

namespace Modul10_103022400055.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> gameList = new List<Game>
        {
            new Game
            {
                Id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = new List<string> {"PC"}, Mode = new List<string> {"Multiplayer"}, IsOnline = true, Harga = 0
            },
            new Game
            {
                Id = 2, Nama = "GTA V", Developer = "Riot Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = new List<string> {"PC", "PS4", "PS5", "Xbox"}, Mode = new List<string> {"Singleplayer", "Multiplayer"}, IsOnline = true, Harga = 300000
            },
            new Game
            {
                Id = 3, Nama = "The Witcher 3", Developer = "CD Projekt RED", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = new List<string> {"RPG"}, Mode = new List<string> {"Singleplayer"}, IsOnline = true, Harga = 250000
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
        {
            return Ok(gameList);
        }

        [HttpGet("{index}")]
        public ActionResult<Game> GetByIndex(int index)
        {
            if (index < 0 || index >= gameList.Count) return NotFound();

            return Ok(gameList[index]);
        }

        [HttpPost]
        public ActionResult Post(Game baru)
        {
            gameList.Add(baru);
            return Ok(gameList);
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= gameList.Count) return NotFound();

            gameList.RemoveAt(index);
            return Ok(new { message = "Film berhasil dihapus" });
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Game game) { gameList.Add(game); }
    }
}
    