using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RForInter.Models;


namespace RForInter.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-TBIJSU2\\SQLEXPRESS;initial catalog=rForInter;integrated security=true");
        
        public ActionResult Employee()
        {
            return View();
        }


        public JsonResult ShowData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);


        }
        public JsonResult ShowDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showdepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);


        }
        public JsonResult ShowPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditData(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("editemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", obj.id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public void InsertData(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", obj.name);
            cmd.Parameters.AddWithValue("@eage", obj.age);
            cmd.Parameters.AddWithValue("@edepartment", obj.department);
            cmd.Parameters.AddWithValue("@epost", obj.post);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateData(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updateemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", obj.id);
            cmd.Parameters.AddWithValue("@ename", obj.name);
            cmd.Parameters.AddWithValue("@eage", obj.age);
            cmd.Parameters.AddWithValue("@edepartment", obj.department);
            cmd.Parameters.AddWithValue("@epost", obj.post);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public void DeleteData(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("deleteemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", obj.id);
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}