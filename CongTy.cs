using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTX_LTHDT_2022_12
{
    internal class CongTy
    {
        public string TenCongTy { get; set; }
        public List<NVVP> DanhSachVanPhong { get; set; }
        public List<NVSX> DanhSachSanXuat { get; set; }
        public CongTy()
        {
            DanhSachVanPhong = new List<NVVP>();
            DanhSachSanXuat = new List<NVSX>();
        }
        public void NhapCongTy(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.WriteLine("Nhap ten cong ty:");
            this.TenCongTy = Console.ReadLine();
            // Nhap danh sach van phong
            Console.WriteLine("Nhap so luong nhan vien van phong:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                var nvvp = new NVVP(); // kieu var se tu dong dinh nghia gia tri trong ds nhap vao
                nvvp.Nhap($"Nhap nhan vien van phong thu {i + 1}:");
                this.DanhSachVanPhong.Add(nvvp);
            }
            // Nhap danh sach san xuat
            Console.WriteLine("Nhap so luong nhan vien san xuat:");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                var nvsx = new NVSX();
                nvsx.Nhap($"Nhap nhan vien san xuat thu {i + 1}:");
                this.DanhSachSanXuat.Add(nvsx);
            }
        }

        public double TinhTongLuong()
        {
            double s = 0;
            foreach (var nvvp in this.DanhSachVanPhong)
            {
                s = s + nvvp.TinhLuong();
            }
            foreach (var nvsx in this.DanhSachSanXuat)
            {
                s = s + nvsx.TinhLuong();
            }
            return s;
        }
    }
}
