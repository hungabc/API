using System;
using System.Collections.Generic;

namespace Model
{
    public class DonhangModel
    {
        public int MADH { get; set; }
        public string TENDANGNHAP { get; set; }
        public DateTime NGAYDATHANG { get; set; }
        public DateTime NGAYYEUCAU { get; set; }
        public string DIACHINGUOINHAN { get; set; }
        public string TINHTRANG { get; set; }
        public string TENKH { get; set; }
        public string EMAIL { get; set; }
        public string SDT { get; set; }
        public List<ChitietDHModel> chitiet { get; set; }
    }
}
