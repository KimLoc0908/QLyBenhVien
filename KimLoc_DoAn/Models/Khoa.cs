namespace KimLoc_DoAn.Models
{
    public class Khoa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TenKhoa { get; set; } = null!;
        public virtual ICollection<BacSi> BacSis { get; set; } = new List<BacSi>();
    }
}
