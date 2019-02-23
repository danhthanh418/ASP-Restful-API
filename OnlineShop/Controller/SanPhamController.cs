using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Controller
{
    public class SanPhamController : ApiController
    {
        [HttpGet]
        public List<SanPham> LayToanBoSanPham()
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            List<SanPham> dsSP = context.SanPhams.ToList();
            //khử đệ quy
            foreach(SanPham sp in dsSP)
            {
                sp.DanhMuc = null;
            }
            return dsSP;
        }

        [HttpGet]
        public SanPham SanPhamTheoMa(int id)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == id);
            if (sp != null)
            {
                sp.DanhMuc = null;
            }
            //khử đệ quy
            return sp;
        }

        [HttpGet]

        public List<SanPham> TimSanPhamTrongKhoangDonGia(int bd, int kt)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            List<SanPham> dsSP = context.SanPhams.Where(x =>x.DonGia >= bd && x.DonGia <= kt).ToList();
            foreach(SanPham sp in dsSP)
            {
                sp.DanhMuc = null;
            }
            return dsSP;
        }

        [HttpPost]
        public bool LuuSanPham (int maSP, string tenSP, int donGia, int danhMuc)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                SanPham sp = new SanPham();
                sp.MaSP = maSP;
                sp.TenSP = tenSP;
                sp.DonGia = donGia;
                sp.DanhMuc = danhMuc;

                context.SanPhams.InsertOnSubmit(sp);
                context.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        [HttpPut]
        public bool SuaSanPham(int maSP, string tenSP, int donGia, int danhMuc)
        {
            
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
                if(sp != null)
                {
                    sp.TenSP = tenSP;
                    sp.DonGia = donGia;
                    sp.DanhMuc = danhMuc;
                    context.SubmitChanges();
                    return true;
                }
               
            }
            catch
            {

            }
            return false;
        }

        [HttpDelete]

        public bool XoaSanPham(int maSP)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                SanPham sp = context.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
                if (sp != null)
                {
                    context.SanPhams.DeleteOnSubmit(sp);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
    }
}
