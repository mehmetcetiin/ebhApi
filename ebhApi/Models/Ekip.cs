using System.ComponentModel.DataAnnotations.Schema;

namespace ebhApi.Models
{
    public class Ekip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Ad { get; set; }
        public string? Gorev { get; set; }
        public required ICollection<Sube> EkipSubesi { get; set; }
        public string? Aciklama { get; set; }
        public required ICollection<User> EkipUyeleri { get; set; }
        public required ICollection<EbhBasvurular> EkibeAitBasvurular { get; set; }

    }
}
