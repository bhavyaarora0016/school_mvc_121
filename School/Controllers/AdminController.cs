using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class AdminController : Controller
    {
        SchoolDBEntities scl = null;
        public AdminController()
        {
            scl = new SchoolDBEntities();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult StartPage()
        {
            return View();
        }
        // GET: Admin
        public ActionResult Student()
        {
            List<Student> students = new List<Student>();
            foreach (var item in scl.Students)
            {
                students.Add(new Student { RollNo= item.RollNo,Name=item.Name,DOB=item.DOB,ClassNo=item.ClassNo ,Class= item.Class});
            }
            return View(students);
        }

        // GET: Admin/Details/5
        public ActionResult DetailsStudent(int id)
        {
            return View(scl.Students.ToList().Find(temp => temp.RollNo == id));
        }

        // GET: Admin/Create
        public ActionResult CreateStudent()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateStudent(FormCollection collection)
        {
            try
            {
                Student s = new Student();
                s.RollNo =Int32.Parse( Request["RollNo"]);
                s.Name = Request["Name"];
                s.DOB = DateTime.Parse(Request["DOB"]);
                s.ClassNo = Int32.Parse(Request["ClassNo"]);
                scl.Students.Add(s);
                scl.SaveChanges();
                return RedirectToAction("Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult EditStudent(int id)
        {
            Student s = scl.Students.ToList().Find(temp => temp.RollNo == id);
            return View(s);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditStudent(int id, FormCollection collection)
        {
            //try
            //{
               Student s = scl.Students.ToList().Find(temp => temp.RollNo == id);
                s.DOB =DateTime.Parse( Request["DOB"]);
                s.Name = Request["Name"];
                s.ClassNo = Int32.Parse(Request["ClassNo"]);
                scl.SaveChanges();
                return RedirectToAction("Student");
           // }
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteStudent(int id)
        {
            Student s = scl.Students.ToList().Find(temp => temp.RollNo == id);
            return View(s);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteStudent(int id, FormCollection collection)
        {
            try
            {
                Student s = scl.Students.ToList().Find(temp => temp.RollNo == id);
                scl.Students.Remove(s);
                scl.SaveChanges();
                return RedirectToAction("Student");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Class()
        {
            List<Class> classes = new List<Class>();
            classes = scl.Classes.ToList();
            return View(classes);
        }

        public ActionResult ClassCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClassCreate(FormCollection collection)
        {
            Class c = new Class();
            c.ClassNo = Int32.Parse(Request["ClassNo"]);
            c.RoomNo = Int32.Parse(Request["RoomNo"]);
            c.Strength = Int32.Parse(Request["Strength"]);
            c.ClassTeacher = Request["ClassTeacher"];
            scl.Classes.Add(c);
            scl.SaveChanges();
            return RedirectToAction("Class");
        }
        public ActionResult ClassEdit(int id)
        {
           Class c = scl.Classes.ToList().Find(temp => temp.ClassNo == id);
            return View(c); 
        }
        [HttpPost]
        public ActionResult ClassEdit(int id,FormCollection collection)
        {
            Class c = scl.Classes.ToList().Find(temp => temp.ClassNo == id);
            c.ClassNo = Int32.Parse(Request["ClassNo"]);
            c.RoomNo = Int32.Parse(Request["RoomNo"]);
            c.Strength = Int32.Parse(Request["Strength"]);
            c.ClassTeacher = Request["ClassTeacher"];
            scl.SaveChanges();
            return RedirectToAction("Class");
        }
        public ActionResult ClassDetails(int id)
        {
            Class c = scl.Classes.ToList().Find(temp => temp.ClassNo == id);
            return View(c);
        }
        public ActionResult ClassDelete(int id)
        {
            Class c = scl.Classes.ToList().Find(temp => temp.ClassNo == id);
            return View(c);
        }
        [HttpPost]
        public ActionResult ClassDelete(int id , FormCollection collection)
        {
            Class c = scl.Classes.ToList().Find(temp => temp.ClassNo == id);
            scl.Classes.Remove(c);
            scl.SaveChanges();
            return RedirectToAction("Class");
        }
        public ActionResult Subject()
        {
            List<Subject> subjects = new List<Subject>();
            subjects = scl.Subjects.ToList();
            return View(subjects);
        }
        public ActionResult CreateSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubject(FormCollection collection)
        {
            Subject subject = new Subject();
            subject.SubjectId = Int32.Parse(Request["SubjectId"]);
            subject.SubjectName = Request["SubjectName"];
            subject.ClassNo = Int32.Parse(Request["ClassNo"]);
            subject.Duration = Int32.Parse(Request["Duration"]);
            scl.Subjects.Add(subject);  
            scl.SaveChanges();
            return RedirectToAction("Subject");;
        }

        //*****************************************************************************************
        public ActionResult EditSubject(int id)
        {
            Subject c = scl.Subjects.ToList().Find(temp => temp.SubjectId == id);
            return View(c);
        }
        [HttpPost]
        public ActionResult EditSubject(int id, FormCollection collection)
        {
            Subject c = scl.Subjects.ToList().Find(temp => temp.SubjectId == id);
            c.SubjectId =Convert.ToInt32(Request["SubjectId"]);
            c.ClassNo = Int32.Parse(Request["ClassNo"]);
            c.Duration = Int32.Parse(Request["Duration"]);
            c.SubjectName = Request["SubjectName"];
            scl.SaveChanges();
            return RedirectToAction("Subject");
        }
        //***************************************************************************************
        public ActionResult DetailsSubject(int id)
        {
            Subject c = scl.Subjects.ToList().Find(temp => temp.SubjectId == id);
            return View(c);
        }
        public ActionResult Deletesubject(int id)
        {
            Subject c = scl.Subjects.ToList().Find(temp => temp.SubjectId == id);
            return View(c);
        }
        [HttpPost]
        public ActionResult DeleteSubject(int id, FormCollection collection)
        {
            Subject c = scl.Subjects.ToList().Find(temp => temp.SubjectId == id);
            scl.Subjects.Remove(c);
            scl.SaveChanges();
            return RedirectToAction("Subject");
        }

    }

}
