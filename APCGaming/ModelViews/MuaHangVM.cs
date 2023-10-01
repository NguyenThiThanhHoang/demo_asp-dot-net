using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APCGaming.ModelViews
{
    public class MuaHangVM
    {
        public int KhachHangId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ")]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string Ten { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ nhập số điện thoại")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
       
        public string Note { get; set; }
    }
}
