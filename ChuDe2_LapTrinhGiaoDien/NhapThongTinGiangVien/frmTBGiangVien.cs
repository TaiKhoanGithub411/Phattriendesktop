using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NhapThongTinGiangVien
{
    public partial class frmTBGiangVien : Form
    {
        public frmTBGiangVien()
        {
            InitializeComponent();
        }
        public void SetText(string s)
        {
            this.lblThongBao.Text = s;
        }

        private void frmTBGiangVien_Load(object sender, EventArgs e)
        {
            string lienhe = "https://cntt.dlu.edu.vn/";
            this.linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachHP.SelectedItems.Count - 1;
            while (i >= 0)
            {
                this.lbHocPhanDay.Items.Add(lbDanhSachHP.SelectedItems[i]);
                this.lbDanhSachHP.Items.Remove(lbDanhSachHP.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbHocPhanDay.SelectedItems.Count - 1;
            while(i>=0)
            {
                this.lbDanhSachHP.Items.Add(lbHocPhanDay.SelectedItems[i]);
                this.lbHocPhanDay.Items.Remove(lbDanhSachHP.SelectedItems[i]);
                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }
        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
                chklbNgoaiNgu.SetItemChecked(i, false);
            foreach (object ob in this.lbHocPhanDay.Items)
                this.lbDanhSachHP.Items.Add(ob);
            this.lbHocPhanDay.Items.Clear();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            frmTBGiangVien frm = new frmTBGiangVien();
            frm.SetText(GetGiangVien().ToString());
            frm.ShowDialog();
        }
        public GiangVien GetGiangVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiangVien gv = new GiangVien();
            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;
            string ngoaiNgu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaiNgu += chklbNgoaiNgu.Items[i] + ";";
            gv.NgoaiNgu = ngoaiNgu.Split(';');
            DanhSachHocPhan dshp = new DanhSachHocPhan();
            foreach (object hp in lbHocPhanDay.Items)
                dshp.Them(new HocPhan(hp.ToString()));
            gv.dsHocPhan = dshp;
            return gv;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strlink = e.Link.LinkData.ToString();
            Process.Start(strlink);
        }
    }
}
