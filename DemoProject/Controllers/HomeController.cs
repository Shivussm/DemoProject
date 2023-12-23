using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration.Provider;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=sharedmssql10.znetindia.net,1234;Initial Catalog=Jaymaasailani;Persist Security Info=True;User ID=Jaymaa;Password=Nde3c^052");
        Businesslayer Businesslayer = new Businesslayer();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactModal lc)
        {
            SqlCommand cmd = new SqlCommand("GetLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@UserName", lc.Name);
            cmd.Parameters.AddWithValue("@Password", lc.Password);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Session.Timeout = 5;
                Session["UserName"] = lc.Name.ToString();
                return RedirectToAction("Dashboard");
            }
          
            con.Close();
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModal contactModal)
        {
            Businesslayer.Contact(contactModal);

            return View();
        }
        public ActionResult project()
        {
            return View();
        }
        public ActionResult service()
        {
            return View();
        }
        public ActionResult team()
        {
            return View();
        }
     
        public ActionResult Dashboard()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.contactusdeatil = Businesslayer.getcontactus();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

    }
}