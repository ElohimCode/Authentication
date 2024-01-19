using Domain.Common.Enum;

namespace Domain.Common.Entity
{
    public class BaseEntity<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey Id { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
