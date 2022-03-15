using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReactCRUD.Models;

namespace ReactCRUD.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        CrudDemo DB = new CrudDemo();
        [Route("AddStudent")]
        [HttpPost]
        public object AddotrUpdatestudent(Student st)
        {
            try
            {
                if (st.Id == 0)
                {
                    DB.Configuration.ProxyCreationEnabled = false;
                    studentmaster sm = new studentmaster();
                    sm.Name = st.Name;
                    sm.RollNo = st.Rollno;
                    sm.Address = st.Address;
                    sm.Class = st.Class;
                    DB.studentmasters.Add(sm);
                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    DB.Configuration.ProxyCreationEnabled = false;
                    var obj = DB.studentmasters.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {

                        obj.Name = st.Name;
                        obj.RollNo = st.Rollno;
                        obj.Address = st.Address;
                        obj.Class = st.Class;
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }
        [Route("Studentdetails")]
        [HttpGet]
        public object Studentdetails()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            //var a = DB.studentmaster.ToList();

            return DB.studentmasters.ToList();
        }

        [Route("StudentdetailById")]
        [HttpGet]
        public object StudentdetailById(int id)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            var obj = DB.studentmasters.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("Deletestudent")]
        [HttpDelete]
        public object Deletestudent(int id)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            var obj = DB.studentmasters.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.studentmasters.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}