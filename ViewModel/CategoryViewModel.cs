

using System.ComponentModel.DataAnnotations;

namespace Korntest.ViewModel{

public partial class CustomerViewModel

    {
        public int TrAutoId { get; set; }

        public int SdAutoId { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูลชื่อบริษัท")]
        public string? Name1 { get; set; }
        [Required(ErrorMessage = "กรุณากรอกเบอร์โทร")]
        public int? Tel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกเลขโซนการขนส่ง")]
        public int? TransportZone { get; set; }
        [Required(ErrorMessage = "กรุณากรอกโซนการขนส่ง")]
        public string? TransportDescription { get; set; }

        public DateOnly? CreateDate { get; set; }

        public TimeOnly? CreateTime { get; set; }

        public string? CreateBy { get; set; }
        [Required(ErrorMessage = "กรุณากรอก Status")]
        public string? Status { get; set; }
    }
}