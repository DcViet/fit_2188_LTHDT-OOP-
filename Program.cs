using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTTX_LTHDT_2022_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CongTy ct = new CongTy();
            ct.NhapCongTy("Nhap thong tin cong ty:");
            double kq = ct.TinhTongLuong();
            Console.WriteLine(kq);
        }
    }
}
