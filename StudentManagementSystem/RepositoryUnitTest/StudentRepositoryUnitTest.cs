#region References
using System;
using StudentsBO;
using Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsBO.DataSeachResults;
#endregion References

#region StudentRepositoryUnitTest CLass
namespace RepositoryUnitTest
{
    [TestClass]
    public class StudentRepositoryUnitTest
    {
        private readonly StudentRepository mStudentRepository = new StudentRepository();
        public static StudentRepository studentRepository = new StudentRepository();

        #region CreateStudent
        //Created by Prasanaon 18.07.2013
        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <returns>Student</returns>
        public static Student CreateStudent()
        {
            var student = new Student
            {
                Name = "Bheem",
                Standard = "VI",
                Section = "A",
                Gender = 'M',
                DateOfBirth = "03.02.1989",
                PhoneNumber = "9874586854",
                Address = "Salem",
                Created_By = 1
            };
            student.RollNumber = studentRepository.AddStudent(student);
            return student;
        }
        #endregion CreateStudent

        #region CreateStudentMark
        //Created by Prasanaon 18.07.2013
        /// <summary>
        /// Creates the student mark.
        /// </summary>
        /// <returns>StudentMark</returns>
        public static StudentMark CreateStudentMark()
        {
            StudentRepository studentRepository = new StudentRepository();
            var studentMark = new StudentMark
            {
                RollNumber = 4,
                Language = 90,
                English = 90,
                Maths = 100,
                Science = 100,
                Social = 100,
                Result = 'P',
                Remarks = "Good",
                Total = 480,
                Percentage = 96,
                Created_By = 1
            };
            studentMark.StudentMarkId = studentRepository.AddStudentMark(studentMark);
            return studentMark;
        }
        #endregion CreateStudentMark

        #region StudentMarkDelete
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark delete.
        /// </summary>
        /// <returns>StudentMark</returns>
        public static StudentMark StudentMarkDelete()
        {
            var markDelete = new StudentMark
            {
                RollNumber = 5,
                Modified_By = 2,
            };
            return markDelete;
        }
        #endregion StudentMarkDelete

        #region StudentSearch
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the search.
        /// </summary>
        /// <returns></returns>
        public static StudentDSR StudentSearch()
        {
            var search = new StudentDSR
            {
                roll_number = 2,
                student_name = "vivek",
                result = 'P',
            };
            return search;
        }
        #endregion StudentSearch

        #region AddStudentTest
        //Created by Prasanaon 18.07.2013
        /// <summary>
        /// Adds the student test.
        /// </summary>
        [TestMethod]
        public void AddStudentTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Getting a Student by RollNumber
            Student expected = mStudentRepository.GetStudentByRollNumber(student.RollNumber);
            Assert.AreEqual(student.RollNumber, expected.RollNumber);
        }
        #endregion AddStudentTest

        #region AddStudentMarkTest
        //Created by Prasanaon 18.07.2013
        /// <summary>
        /// Adds the student mark test.
        /// </summary>
        [TestMethod]
        public void AddStudentMarkTest()
        {
            //Creating StudentMark
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(0, studentMark.StudentMarkId);

            //Getting StudetnMark details by StudentMarkId
            StudentMark expected = mStudentRepository.GetStudentMarkByRollNumber(studentMark.RollNumber);
            Assert.AreEqual(expected.StudentMarkId, studentMark.StudentMarkId);
        }
        #endregion AddStudentMarkTest

        #region UpdateStudentTest
        //Created by Prasanaon 18.07.2013
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
            mStudentRepository.UpdateStudent(student);

            //Getting Student details by RollNumber
            Student expected = mStudentRepository.GetStudentByRollNumber(student.RollNumber);
            Assert.AreEqual(expected.Name, student.Name);
        }
        #endregion UpdateStudentTest

        #region DeleteStudentTest
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Deletes the student test.
        /// </summary>
        [TestMethod]
        public void DeleteStudentTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Deleting a Student
            student.Modified_By = 2;
            mStudentRepository.DeleteStudent(student.RollNumber);

            //Getting Student details by Roll Number
            Student expected = mStudentRepository.GetStudentByRollNumber(student.RollNumber);
            Assert.AreEqual(expected.Modified_By, student.Modified_By);
        }
        #endregion DeleteStudentTest

        #region StudentMarkDeleteTest
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark delete test.
        /// </summary>
        [TestMethod]
        public void StudentMarkDeleteTest()
        {
            //Creating a Student
            Student student = CreateStudent();
            Assert.AreNotEqual(0, student.RollNumber);

            //Creating StudentMark
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(studentMark.StudentMarkId, 0);

            //Searching Student 
            var searchStudent = StudentMarkDelete();

            //Getting Student details
            var expected = mStudentRepository.GetStudentInfoByRollNumber(student.RollNumber);
            Assert.AreEqual(searchStudent.RollNumber, student.RollNumber);
        }
        #endregion StudentMarkDeleteTest

        #region StudentMarkUpdateTest
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark update test.
        /// </summary>
        [TestMethod]
        public void StudentMarkUpdateTest()
        {
            //Creating StudentMark
            StudentMark studentMark = CreateStudentMark();
            Assert.AreNotEqual(studentMark.StudentMarkId,0);

            //Updating a StudentMark
            studentMark.Language = 99;
            studentMark.Modified_By = 2;
            mStudentRepository.StudentMarkUpdate(studentMark);

            //Getting StudentMark Details
            var updatedStudentMark = mStudentRepository.GetStudentMarkByRollNumber(studentMark.RollNumber);
            Assert.AreEqual(studentMark.Language,updatedStudentMark.Language);
        }
        #endregion StudentMarkUpdateTest
    }
}
#endregion StudentRepositoryUnitTest

