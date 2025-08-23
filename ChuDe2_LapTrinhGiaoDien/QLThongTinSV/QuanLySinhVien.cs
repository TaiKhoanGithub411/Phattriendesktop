using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLThongTinSV
{
    public class QuanLySinhVien
    {
        public List<SinhVien> dssv;
        public QuanLySinhVien()
        {
            dssv = new List<SinhVien>();
        }
        public SinhVien this[int index]
        {
            get { return this.dssv[index]; }
            set { dssv[index] = value; }
        }
        public void Them(SinhVien sv)
        {
            this.dssv.Add(sv);
        }
        public delegate int SoSanh(object sv1, object sv2);
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach(SinhVien sv in dssv)
                if(ss(obj,sv)==0)
                {
                    svresult = sv;
                    break;
                }
            return svresult;
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.dssv.Count - 1;
            for(i=0;i<count;i++)
                if(ss(obj,this[i])==0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public void Xoa(object obj, SoSanh ss)
        {
            int i = dssv.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.dssv.RemoveAt(i);
        }
        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            using(StreamReader sr=new StreamReader(new FileStream(filename,FileMode.Open)))
            {
                while ((t=sr.ReadLine())!=null)
                {
                    s = t.Split(';');
                    sv = new SinhVien();
                    sv.MaSo = s[0];
                    sv.HoTen = s[1];
                    sv.NgaySinh = DateTime.Parse(s[2]);
                    sv.DiaChi = s[3];
                    sv.Lop = s[4];
                    sv.Hinh = s[5];
                    sv.GioiTinh = false;
                    if (s[6] == "1")
                        sv.GioiTinh = true;
                    string[] cn = s[7].Split(',');
                    foreach (string c in cn)
                        sv.ChuyenNganh.Add(c);
                    this.Them(sv);
                }
            }
        }
    }
}
