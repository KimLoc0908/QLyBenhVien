using System;
using System.ComponentModel.DataAnnotations;

namespace KimLoc_DoAn.Models
{
    public class DatLich
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid BenhNhanId { get; set; }

        [Required]
        public Guid BacSiId { get; set; }

        [Required]
        public DateTime NgayDatLich { get; set; }

        [Required]
        public DateTime NgayHenKham { get; set; } 

        [StringLength(500)]
        public string? GhiChu { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; } = "Chờ xác nhận";

        public virtual BenhNhan BenhNhan { get; set; } = null!;
        public virtual BacSi BacSi { get; set; } = null!;
    }
}
