#nullable disable

namespace SWAP.DAL.Data
{
    public partial class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
