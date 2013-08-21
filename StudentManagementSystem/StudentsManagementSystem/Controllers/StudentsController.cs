#region References
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Repository;
using StudentsBO;
using StudentsBO.DataSeachResults;
#endregion References

namespace StudentsManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        readonly StudentDSR studentsDSR = new StudentDSR();
        readonly StudentRepository studentRepository = new StudentRepository();


        #region HttpGet HomePage()
        //Added by Prasana Sri on 22.07.2013
        /// <summary>
        /// Homes the page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
        #endregion HttpGet HomePage()




       
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            //StudentRepository studentRepository = new StudentRepository();

            var studentRollNumber = studentRepository.AddStudent(student);
            if (studentRollNumber != 0)
            {
                return RedirectToAction("AddStudentMark", "Student", new { id = studentRollNumber });
            }
            else
            {
                ViewData["Message"] = "Error in inserting";
                return View();
            }
        }
        




        #region HttpGet AddStudentMark()
        //Added by Prasana Sri on 18.07.2013
        /// <summary>
        /// Adds the student mark.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddStudentMark()
        {
            return View();
        }
        #endregion HttpGet AddStudentMark()

        #region HttpPost AddStudentMark(StudentMark studentMark, int id)
        //Added by Prasana Sri on 18.07.2013
        /// <summary>
        /// Adds the student mark.
        /// </summary>
        /// <param name="studentMark">The student mark.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddStudentMark(StudentMark studentMark, int id)
        {
            try
            {
                StudentRepository studentRepository = new StudentRepository();
                studentMark.RollNumber = id;
                studentRepository.AddStudentMark(studentMark);
                //ViewData["Message1"] = "Student Marks Inserted Sucessfully";
                //return View();
                return RedirectToAction("Search", "Student");
            }
            catch (Exception ex)
            {
                ViewData["Message2"] = "Error in Inserting";
                return View();
            }
        }
        #endregion HttpPost AddStudentMark(StudentMark studentMark, int id)

        #region HttpGet EditStudent(int id = 0)
        //Added by Prasana Sri on 22.07.2013
        /// <summary>
        /// Edits the student.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStudent(int id = 0)
        {
            var studentDetails = studentRepository.GetStudentByRollNumber(id);

            return View(studentDetails);
        }
        #endregion HttpGet EditStudent(int id = 0)

        #region HttpPost EditStudent(Student student)
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            int studentRollNumber = 0;
            studentRollNumber = student.RollNumber;
            studentRepository.UpdateStudent(student);

            return RedirectToAction("EditStudentMark", "Student", new { id = studentRollNumber });
        }
        #endregion HttpPost EditStudent(Student student)

        #region HttpGet EditStudentMark(int id)
        //Added by Prasana Sri on 22.07.2013
        /// <summary>
        /// Edites the student mark.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStudentMark(int id)
        {

            var studentMarkDetails = studentRepository.GetStudentMarkByRollNumber(id);
            return View(studentMarkDetails);
        }
        #endregion HttpGet EditStudentMark(int id)

        #region HttpPost ActionResult EditStudentMarkUpdate(StudentMark studentMark)
        [HttpPost, ActionName("EditStudentMark")]
        public ActionResult EditStudentMarkUpdate(StudentMark studentMark)
        {
            studentRepository.StudentMarkUpdate(studentMark);

            return RedirectToAction("Search", "Student");
        }
        #endregion HttpPost ActionResult EditStudentMarkUpdate(StudentMark studentMark)

        #region HttpGet Search()
        //Added by Vivek on 22.07.2013
        /// <summary>
        /// Searches this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
            IEnumerable<StudentDSR> model = studentRepository.GetBySearch(studentsDSR);
            // var searchResult = studentRepository.GetBySearch(studentsDSR);
            return View(model);
        }
        #endregion HttpGet Search()

        #region HttpPost Search()
        //Added by Vivek on 22.07.2013
        /// <summary>
        /// Searches the specified student_ name.
        /// </summary>
        /// <param name="Student_Name">Name of the student_.</param>
        /// <param name="Role_Number">The role_ number.</param>
        /// <param name="Result">The result.</param>
        /// <param name="Standard">The standard.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(string Student_Name = null, int Role_Number = 0, string Result = null, string Standard = null)
        {

            studentsDSR.student_name = Student_Name;
            studentsDSR.roll_number = Role_Number;
            if (Result != "")
            {
                studentsDSR.result = Convert.ToChar(Result);
            }
            else
            {
                studentsDSR.result = 'P';
            }
            studentsDSR.standard = Standard;
            IEnumerable<StudentDSR> model = studentRepository.GetBySearch(studentsDSR);
            //var searchResult = studentRepository.GetBySearch(studentsDSR); 

            return View(model);
            //return View();
        }
        #endregion HttpPost Search()

        #region HttpGet ViewStudent(int id)
        //Added by Yogalakshmi on 19.07.2013
        /// <summary>
        /// Views the student.
        /// </summary>
        /// <param name="studentDSR">The student DSR.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewStudent(int id)
        {
            var student = new Student {StudentMarks = new List<StudentMark>()};
            student = studentRepository.GetStudentByRollNumber(id);
            var studentMarkGet = studentRepository.GetStudentMarkByRollNumber(id);
            student.StudentMarks.Add(new StudentMark
            {
                Language = studentMarkGet.Language,
                English = studentMarkGet.English,
                Maths = studentMarkGet.Maths,
                Science = studentMarkGet.Science,
                Social = studentMarkGet.Social,
                Total = studentMarkGet.Total,
                Percentage = studentMarkGet.Percentage,
                Result = studentMarkGet.Result
            });
            return View(student);
        }
        #endregion HttpGet ViewStudent(int id)

        #region HttpGet ActionResult Delete(int id = 0)
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            var studentDetailForDelete = studentRepository.GetStudentInfoByRollNumber(id);
            return View(studentDetailForDelete);
        }
        #endregion HttpGet ActionResult Delete(int id = 0)

        #region HttpPost DeleteConform(int id)
        /// <summary>
        /// Deletes the conform.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConform(int id)
        {
            studentRepository.DeleteStudent(id);
            studentRepository.StudentMarkDelete(id);
            return RedirectToAction("Search", "Student");
        }
        #endregion HttpPost DeleteConform(int id)
    }
}

