#nullable disable

namespace SWAP.DAL.Data
{
    public partial class GameGenre
    {
        public int RelationId { get; set; }

        public int GameId { get; set; }
        public int GenreId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
