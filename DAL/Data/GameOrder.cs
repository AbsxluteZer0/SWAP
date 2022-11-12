#nullable disable

namespace SWAP.DAL.Data
{
    public partial class GameOrder
    {
        public int RelationId { get; set; }

        public int GameId { get; set; }
        public string OrderId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}
