namespace Ud.Core.DDD.Abstractions
{
    public abstract class BaseEntity(DateTime CreatedDate,
                                     DateTime Modified,
                                     Guid Id)
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Modified()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
