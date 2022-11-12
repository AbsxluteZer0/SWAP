#nullable disable

namespace SWAP.DAL.Data
{
    public partial class Order
    {
        public string TransactionKey { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }

        public virtual User User { get; set; }
    }
}
