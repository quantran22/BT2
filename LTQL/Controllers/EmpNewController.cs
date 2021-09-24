using LTQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQL.Controllers
{
    public class EmpNewController : Controller
    {
        LamTrinhQuanLyDBContext db = new LamTrinhQuanLyDBContext();
        AutoGenerateKey genKey = new AutoGenerateKey();
        // GET: EmpNew
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            //sinh ra key cho student
            var stdID = "";
            var countStudent = db.Employees.Count();
            if (countStudent == 0)
            {
                //trong turong hopj student chua co du lieu thi de khoa chinh mac dinh la STD001
                stdID = "PERS001";
            }
            else
            {
                //lay gia tri studentID moi nhat
                var studentID = db.Employees.ToList().OrderByDescending(m => m.PersonID).FirstOrDefault().PersonID;
                //sinh studntiD tu dong
                stdID = genKey.GenerateKey(studentID);
            }
            ViewBag.StudnetID = stdID;
            return View();
        }
    }
}