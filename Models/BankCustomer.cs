using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class BankCustomer: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Mobile {  get; set; }
 
    }
}
