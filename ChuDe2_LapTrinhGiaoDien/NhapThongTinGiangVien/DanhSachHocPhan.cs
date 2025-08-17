﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapThongTinGiangVien
{
    public class DanhSachHocPhan
    {
        public List<HocPhan> ds;
        public DanhSachHocPhan()
        {
            ds = new List<HocPhan>();
        }
        public HocPhan this[int index]
        {
            get { return ds[index] as HocPhan; }
            set { ds[index] = value; }
        }
        public void Them(HocPhan hp)
        {
            ds.Add(hp);
        }
        public override string ToString()
        {
            string s = "Danh mục môn học: ";
            foreach(object mh in ds)
            {
                s += mh as HocPhan + ";";
            }
            return s;
        }
    }
}
