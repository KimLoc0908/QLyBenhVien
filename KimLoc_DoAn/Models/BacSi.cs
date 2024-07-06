using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KimLoc_DoAn.Models
{
    public class BacSi
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string TenBacSi { get; set; } = null!;

        [Required]
        public int NamKinhNghiem { get; set; }

        [StringLength(int.MaxValue)]
        public string? HinhAnh { get; set; }

        [StringLength(int.MaxValue)]
        public string? MoTaBacSi { get; set; }

        [Required]
        public Guid KhoaId { get; set; }

        public virtual Khoa Khoa { get; set; } = null!;

        public virtual ICollection<DatLich> DatLichs { get; set; } = new List<DatLich>();
    }
}
