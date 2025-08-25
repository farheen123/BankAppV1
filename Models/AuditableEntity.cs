namespace BankApp.Models
{
    public class AuditableEntity
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
