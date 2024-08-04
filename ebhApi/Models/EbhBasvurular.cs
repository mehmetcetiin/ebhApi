using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System;

namespace ebhApi.Models
{
    public class EbhBasvurular
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public required string IhbarSahibi { get; set; }
        public required string CepNo1 { get; set; }
        public string? CepNo2 { get; set; }
        public required string HizmetAlacakKisi { get; set; }
        public required int Yas { get; set; }
        public required long Tckn { get; set; }
        public required bool Cinsiyet { get; set; }
        public string? EgitimDurum { get; set; }
        public int? OdaSayi { get; set; }
        public string? BakimDurumu { get; set; }
        public ICollection<Hastalik>? Hastaliklar { get; set; }
        public required ICollection<Sube> EbhBasvuruYapilanSube { get; set; }
        public required string Adres { get; set; }
        public string? Adres2 { get; set; }
        public string? AdresTarif { get; set; }
        public required string IhbarDetay { get; set; }
        public string? Aciklama { get; set; }
        public required string EkipAciklama { get; set; }
        public required bool AcilMi { get; set; }
        public bool? Depremzede { get; set; }
        public bool? Soybis { get; set; }
        public string? Heskod { get; set; }
    }

}