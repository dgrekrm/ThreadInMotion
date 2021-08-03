using System;

namespace ThreadInMotion.Library.SharedModels.Models
{
    public class BookTransaction
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime ExitDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}
