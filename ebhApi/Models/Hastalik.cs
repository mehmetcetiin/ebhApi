using System.ComponentModel.DataAnnotations.Schema;

namespace ebhApi.Models
{
    public class Hastalik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string HastalikAdi { get; set; }
    }
}
