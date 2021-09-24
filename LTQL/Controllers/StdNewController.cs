using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTQL.Models;

namespace LTQL.Controllers
{
    public class StdNewController : Controller
    {
        LamTrinhQuanLyDBContext db = new LamTrinhQuanLyDBContext();
        AutoGenerateKey genKey = new AutoGenerateKey();
        // GET: StdNew
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Create()
        {
            //sinh ra key cho student
            var stdID = "";
            var countStudent = db.Students.Count();
            if (countStudent == 0)
            {
                //trong turong hopj student chua co du lieu thi de khoa chinh mac dinh la STD001
                stdID = "STD001";
            }
            else
            {
                //lay gia tri studentID moi nhat
                var studentID = db.Students.ToList().OrderByDescending(m => m.StudentID).FirstOrDefault().StudentID;
                //sinh studntiD tu dong
                stdID = genKey.GenerateKey(studentID);
            }
            ViewBag.StudnetID = stdID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                //luu thong tin vao database
                db.Students.Add(std);
                db.SaveChanges();
                //lay du lieuj tu client gui len va luu vao database
                return RedirectToAction("Index");
            }
            return View(std);
            
        }
    }
}