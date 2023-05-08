using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTX_LTHDT_2022_12
{
    internal class NVVP
    {
        public string MaNhanVien { get ; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public double HeSo { get; set; }
        public void Nhap(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.WriteLine("Nhap ma nhan vien:");
            this.MaNhanVien = Console.ReadLine();
            Console.WriteLine("Nhap ten nhan vien:");
            this.HoTen = Console.ReadLine();
            Console.WriteLine("Nhap dia chi nhan vien:");
            this.DiaChi = Console.ReadLine();   
            Console.WriteLine("Nhap he so luong:");
            this.HeSo = double.Parse(Console.ReadLine());
        }

        public double TinhLuong()
        {
            return this.HeSo * 100;
        }
    }
}
