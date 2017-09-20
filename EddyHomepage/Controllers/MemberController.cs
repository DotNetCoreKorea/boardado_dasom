 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EddyHomepage.Models;
using System.Data.Entity;

namespace EddyHomepage.Controllers
{
    public class MemberController : Controller
    {
        EddyHomePageEntities db = new EddyHomePageEntities();

        public ActionResult Entry()
        {
            Member member = new Member();
            return View(member);
        }

        [HttpPost]
        public ActionResult Entry(Member member)
        {
            member.EntityDate = DateTime.Now;
            try
            {
                db.Member.Add(member);
                db.SaveChanges();
                ViewBag.Result = "OK";
            }
            catch(Exception ex)
            {
                ViewBag.Result = "FAIL";
            }
            return RedirectToAction("Index","Home");
           
        }

        public JsonResult IDCheck(string memberid)
        {
            string result = string.Empty;
            Member member = new Member();

            if(member == null)
            {
                result = "OK";
            }
            else
            {
                result = "FAIL";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Member
        public ActionResult List()
        {
            List<Member> list = db.Member.OrderByDescending(o => o.EntityDate).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(string memberid)
        {
            Member member = db.Member.Where(c => c.MemberID == memberid).FirstOrDefault();
            return View(member);
        }

        public ActionResult Edit(Member member)
        {
            Member dbMember = db.Member.Find(member.MemberID);
            try
            {
                dbMember.MemberName = member.MemberName;
                dbMember.MemberPWD = member.MemberPWD;
                dbMember.Email = member.Email;
                dbMember.Telephone = member.Telephone;

                db.Entry(dbMember).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Result = "OK";
            }
            catch(Exception ex)
            {
                ViewBag.Result = "FAIL";
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(string memberid)
        {
            Member dbMember = db.Member.Find(memberid);
            db.Member.Remove(dbMember);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}