using System.ComponentModel.DataAnnotations.Schema;

namespace ebhApi.Models
{
    public class Sube
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string SubeAdi { get; set; }
        public required string SubeAdresi { get; set; }
        public required string SubeTelefon { get; set; }
        public ICollection<Ekip>? SubeyeAitEkipler { get; set; }
        public ICollection<User>? SubeyeAitKullanicilar { get; set; }
        public ICollection<EbhBasvurular>? SubeyeYapilanBasvurular { get; set; }


    }
}
