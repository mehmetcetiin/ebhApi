using System.ComponentModel.DataAnnotations.Schema;

namespace ebhApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string UserName { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
        public Ekip? KullanicininEkipleri { get; set; }
        public Sube? KullanicininSubesi { get; set; }


    }
}


/* 
  {
    "userName": "admin",
    "password": "admin"
   } 
*/