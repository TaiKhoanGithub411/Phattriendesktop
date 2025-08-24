using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapThongTinGiangVien
{
    enum KieuTim
    {
        TheoMa,
        TheoHoTen,
        TheoSDT
    }
    public delegate int SoSanh(object a, object b);
    public class QuanLyGiangVien
    {
        public List<GiangVien> dsgv;
        public QuanLyGiangVien()
        {
            dsgv = new List<GiangVien>();
        }
        public GiangVien this[int index]
        {
            get { return dsgv[index]; }
            set { dsgv[index] = value; }
        }
        public void SapXep(SoSanh ss)
        {
            int n=dsgv.Count;
            for (int i=0; i<n-1;i++)
            {
                for (int j=0; j<n-i-1;j++)
                {
                    if (ss(dsgv[j], dsgv[j+1])>0)
                    {
                        GiangVien temp = dsgv[j];
                        dsgv[j] = dsgv[j+1];
                        dsgv[j+1] = temp;
                    }
                }
            }
        }
        public bool Them(GiangVien gv)
        {
            if (gv == null || dsgv.Any(g => g.MaSo == gv.MaSo))
                return false;
            dsgv.Add(gv);
            return true;
        }
        public GiangVien Tim(object temp, SoSanh ss)
        {
            foreach(GiangVien gv in dsgv)
            {
                if(ss(temp,gv)==0)
                    return gv;
            }
            return null;
        }
        public GiangVien Xoa(object temp, SoSanh ss)
        {
            GiangVien gvcanXoa = Tim(temp,ss);
            if(gvcanXoa != null)
            {
                dsgv.Remove(gvcanXoa);
                return gvcanXoa;
            }
            return null;
        }
    }
}
