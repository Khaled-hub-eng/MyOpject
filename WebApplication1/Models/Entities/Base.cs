namespace WebApplication1.Models.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
        public Base() { 
          this.CreatedDate = DateTime.Now;
            this.IsActive = true;
        }
    }
}
