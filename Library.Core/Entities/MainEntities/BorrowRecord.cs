namespace Library.Core.Entities.MainEntities
{
    public class BorrowRecord :BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
        public decimal Penalty { get; set; }
    }
}
