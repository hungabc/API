﻿using System;
using System.Collections.Generic;

namespace Model
{
    public class SanphamModel
    {
        public int MASP { get; set; }
        public string MACODE { get; set; }
        public string TENSP { get; set; }
        public int? GIA { get; set; }
        public int MAGIAMGIA { get; set; }
        public string HINH { get; set; }
        public int SOLUONGTON { get; set; }
        public string NGAYNHAP { get; set; }
        public int BANCHAY { get; set; }
        public string MOTA { get; set; }
        public string KEYWORD { get; set; }
        public int ANHIEN { get; set; }
        public int MALOAI { get; set; }
        public List<SanphamModel> children { get; set; }
        public string type { get; set; }
    }
}
