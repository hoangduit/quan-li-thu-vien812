using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    static class Ham
    {
        static public void ThemLuocSu(Decimal MaCB, String TenFrom, String ThaoTac, String TomTac)
        {
            try
            {
                clLuocSu ojpLS = new clLuocSu();
                Decimal LuocSu = 0;
                ojpLS.MaCB = MaCB;
                ojpLS.TenFrom = TenFrom;
                ojpLS.ThaoTac = ThaoTac;
                ojpLS.ThoiGian = DateTime.Now;
                ojpLS.TomTac = TomTac;
                LuocSu = ojpLS.Them(ojpLS);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
