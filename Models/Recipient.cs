using System;
using System.ComponentModel.DataAnnotations;

namespace WPMessageApp.Models
{
    public class Recipient
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; } // Mesajın gideceği numara

        [Required]
        public string Name { get; set; } // Kişinin adı (Placeholder için gerekli: {{isim}})

        public string? ExtraInfo { get; set; } // İleride ek bilgi tutmak için (Örn: Masa Numarası)

        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}