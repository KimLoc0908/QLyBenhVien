using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KimLoc_DoAn.Models
{
    public class BenhNhan
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string HoTenBenhNhan { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string TenBenh { get; set; } = null!;

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; } = null!;

        public virtual ICollection<DatLich> DatLichs { get; set; } = new List<DatLich>();
    }
}
