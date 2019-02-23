using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Controller
{
    public class DanhMucController : ApiController
    {
        [HttpGet]
        public List<DanhMuc> LayToanBoDanhMuc()
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            List<DanhMuc> dsDM = context.DanhMucs.ToList();
            foreach(DanhMuc dm in dsDM)
            {
                dm.SanPhams.Clear();
            }
            return dsDM;
        }

        [HttpGet]
        public DanhMuc DoanhMucTheoMa(int id)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDM == id);
            if (dm != null)
            {
                dm.SanPhams.Clear();
            }
            return dm;
        }

        [HttpPost]
        public bool LuuDanhMuc(int maDM, string tenDM)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                DanhMuc dm = new DanhMuc();
                dm.MaDM = maDM;
                dm.TenDM = tenDM;
 
                context.DanhMucs.InsertOnSubmit(dm);
                context.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        [HttpPut]
        public bool SuaDanhMuc(int maDM, string tenDM)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDM == maDM);
                if (dm != null)
                {
                    dm.TenDM = tenDM;
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

        public bool XoaDanhMuc(int maDM)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext();
                DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDM == maDM);
                if (dm != null)
                {
                    if (dm.SanPhams.Count > 0) return false;
                    context.DanhMucs.DeleteOnSubmit(dm);
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
