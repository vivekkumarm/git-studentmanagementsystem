#region References
using System;
using System.Collections.Generic;
using StudentsBO;
using DataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsBO.DataSeachResults;
#endregion References

#region StudentDataServiceUnitTest Class
namespace DataServiceUnitTest
{
    [TestClass]
    public class StudentDataServiceUnitTest
    {
        private readonly StudentDataService mStudentDataService = new StudentDataService();
        public static StudentDataService studentDataService = new StudentDataService();

        #region CreateStudent
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <returns></returns>
        public static Student CreateStudent()
        {
            var student = new Student
            {
                Name = "Bheem",
                Standard = "VI",
                Section = "B",
                Gender = 'M',
                DateOfBirth = "03.02.1989",
                PhoneNumber = "7857458745",
                Address = "Chennai",
                Created_By = 1
            };
            student.RollNumber = studentDataService.AddStudent(student);
            return student;
        }
        #endregion CreateStudent

        #region CreateStudentMark
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Creates the student mark.
        /// </summary>
        /// <returns></returns>
        public static StudentMark CreateStudentMark()
        {
            var studentMark = new StudentMark
            {
                RollNumber = 4,
                Language = 100,
                English = 100,
                Maths = 100,
                Science = 100,
                Social = 100,
                Result = 'P',
                Remarks = "Outstanding",
                Total = 500,
                Percentage = 100,
                Created_By = 1
            };
            studentMark.StudentMarkId = studentDataService.AddStudentMark(studentMark);
            return studentMark;
        }
        #endregion CreateStudentMark

        #region StudentSearch
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the search.
        /// </summary>
        /// <returns></returns>
        public static StudentDSR StudentSearch()
        {
            var searchList = new List<StudentDSR>();
            var search = new StudentDSR
            {
                roll_number = 2,
                student_name = "Vivek",
                standard = "X",
                result = 'P',
            };
            searchList = studentDataService.GetBySearch(search);
            return search;
        }
        #endregion StudentSearch

        #region StudentMarkUpdate
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Students the mark update.
        /// </summary>
        /// <returns></returns>
        public static StudentMark StudentMarkUpdate()
        {
            StudentMark studentMark = new StudentMark();
            var updata = new StudentMark
            {
                StudentMarkId = 1,
                RollNumber = 34,
                Language = 50,
                English = 50,
                Maths = 50,
                Science = 50,
                Social = 50,
                Total = 250,
                Percentage = 50,
                Result = 'P',
                Remarks = "Good",
                Modified_By = 1,
            };
            return updata;
        }
        #endregion StudentMarkUpdate

        #region StudentMarkDelete
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark delete.
        /// </summary>
        /// <returns></returns>
        public static StudentMark StudentMarkDelete()
        {
            StudentMark studentMarkDelete = new StudentMark();
            var studentDelete = new StudentMark
            {
                RollNumber = 45,
                Modified_By = 2,
            };
            return studentDelete;
        }
        #endregion StudentMarkDelete

        #region AddStudentTest
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Adds the student test.
        /// </summary>
        [TestMethod]
        public void AddStudentTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Getting Student Details
            Student expected = mStudentDataService.GetStudentByRollNumber(student.RollNumber);
            Assert.AreEqual(student.RollNumber, expected.RollNumber);
        }
        #endregion AddStudentTest

        #region AddStudentMarkTest
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Adds the student mark test.
        /// </summary>
        [TestMethod]
        public void AddStudentMarkTest()
        {
            //Creating StudentMark 
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(0, studentMark.StudentMarkId);

            //Getting StudentMark Details
            StudentMark expected = mStudentDataService.GetStudentMarkByStudentMarkId(studentMark.StudentMarkId);
            Assert.AreEqual(expected.StudentMarkId, studentMark.StudentMarkId);
        }
        #endregion AddStudentMarkTest

        #region UpdateStudentTest
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Updates the student test.
        /// </summary>
        [TestMethod]
        public void UpdateStudentTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Updating a Student
            student.Name = "Ramya";
            student.Modified_By = 1;
            mStudentDataService.UpdateStudent(student);

            //Getting Student Details
            Student expected = mStudentDataService.GetStudentByRollNumber(student.RollNumber);
            Assert.AreEqual(expected.Name, student.Name);
        }
        #endregion UpdateStudentTest

        #region StudentSearchTest
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Students the search test.
        /// </summary>
        [TestMethod]
        public void StudentSearchTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Creating StudentMark 
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(0, studentMark.StudentMarkId);

            //Searching Student Details
            var studentDSR = StudentSearch();

            //Getting Student Info by RollNumber
            var expectedsearchDAR = mStudentDataService.GetStudentInfoByRollNumber(studentDSR.roll_number);
            //Assert.AreEqual(studentDSR.student_name, expectedsearchDAR.Name);
        }
        #endregion StudentSearchTest

        #region StudentDeleteTest
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the delete test.
        /// </summary>
        [TestMethod]
        public void StudentDeleteTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Deleting a Student
            student.Modified_By = 2;
            mStudentDataService.DeleteStudent(student.RollNumber);

            //Getting Student details by RollNumber
            StudentDSR studentDSR = new StudentDSR();
            var expected = mStudentDataService.GetStudentInfoByRollNumber(studentDSR.roll_number);
            Assert.AreEqual(expected.roll_number, student.RollNumber);
        }
        #endregion StudentDeleteTest

        #region UpdateStudentMarkTest
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Updates the student mark test.
        /// </summary>
        [TestMethod]
        public void UpdateStudentMarkTest()
        {
            //Creating StudentMark
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(studentMark.StudentMarkId, 0);

            //Updating StudentMark
            studentMark.Language = 50;
            mStudentDataService.StudentMarkUpdate(studentMark);

            //Getting StudentMark details by StudentMarkId
            var getUpdatedStudentMark = mStudentDataService.GetStudentMarkByStudentMarkId(studentMark.StudentMarkId);
            Assert.AreEqual(studentMark.Language, getUpdatedStudentMark.Language);
        }
        #endregion UpdateStudentMarkTest

        #region DeleteStudentMark
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Deletes the student mark.
        /// </summary>
        [TestMethod]
        public void DeleteStudentMark()
        {
            //Creating StudentMark
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(studentMark.StudentMarkId, 0);

            //Deleting StudentMark
            studentMark.RollNumber = 2;
            var detetedStudent = StudentMarkDelete();

            //Getting StudentMark by StudentMarkId
            var getUpdatedStudentMark = mStudentDataService.GetStudentMarkByStudentMarkId(studentMark.StudentMarkId);
            Assert.AreEqual(studentMark.IsDeleted, getUpdatedStudentMark.IsDeleted);
        }
        #endregion DeleteStudentMark
    }
}
#endregion StudentDataServiceUnitTest Class