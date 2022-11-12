#nullable disable

namespace SWAP.DAL.Data
{
    public partial class ShoppingCart
    {
        public int RelationId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
    }
}
