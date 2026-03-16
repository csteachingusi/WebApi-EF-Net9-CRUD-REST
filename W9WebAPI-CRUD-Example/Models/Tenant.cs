using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9WebAPI_CRUD_Example.Models
{
    public class Tenant
    {
        [Key]
        public int TenantID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        //navigation property, nullable because a tenant might not be assigned to a property yet
        public Property? Property { get; set; }
    }

}
