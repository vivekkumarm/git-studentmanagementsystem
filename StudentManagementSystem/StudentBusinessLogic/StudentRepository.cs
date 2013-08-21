#region References
using System.Collections.Generic;
using StudentsBO;
using DataService;
using StudentsBO.DataSeachResults;
#endregion

#region StudentRepository Class
namespace Repository
{
    public class StudentRepository
    {
        StudentDataService studentDataService = new StudentDataService();

        #region AddStudent
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Adds the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>Student</returns>
        public int AddStudent(Student student)
        {
            int rollNumber = 0;
            rollNumber = studentDataService.AddStudent(student);
            return rollNumber;
        }
        #endregion AddStudent

        #region AddStudentMark
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Adds the student mark.
        /// </summary>
        /// <param name="studentMark">The student mark.</param>
        /// <returns>StudentMark</returns>
        public int AddStudentMark(StudentMark studentMark)
        {
            return studentDataService.AddStudentMark(studentMark);
        }
        #endregion AddStudentMark

        #region UpdateStudent
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void UpdateStudent(Student student)
        {
            studentDataService.UpdateStudent(student);
        }
        #endregion UpdateStudent

        #region StudentMarkUpdate
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark update.
        /// </summary>
        /// <param name="studentMarkUpdate">The student mark update.</param>
        public void StudentMarkUpdate(StudentMark studentMarkUpdate)
        {
            studentDataService.StudentMarkUpdate(studentMarkUpdate);
        }
        #endregion StudentMarkUpdate

        #region GetStudentByRollNumber
        //Created by Prasanaon 18.07.2013
        /// <summary>
        /// Gets the student by roll number.
        /// </summary>
        /// <param name="rollNumber">The roll number.</param>
        /// <returns>Student</returns>
        public Student GetStudentByRollNumber(int rollNumber)
        {
            return studentDataService.GetStudentByRollNumber(rollNumber);
        }
        #endregion GetStudentByRollNumber

        #region GetStudentmarkByRollNumber
        //Created by Yogalakshmi on 23.07.2013
        /// <summary>
        /// Gets the studentmark by student mark id.
        /// </summary>
        /// <param name="studentMarkId">The student mark id.</param>
        /// <returnsStudentMark></returns>
        public StudentMark GetStudentMarkByRollNumber(int rollNumber)
        {
            return studentDataService.GetStudentMarkByRollNumber(rollNumber);
        }
        #endregion GetStudentmarkByRollNumber

        #region GetStudentmarkByStudentMarkId
        //Created by Prasana on 18.07.2013
        /// <summary>
        /// Gets the studentmark by student mark id.
        /// </summary>
        /// <param name="studentMarkId">The student mark id.</param>
        /// <returnsStudentMark></returns>
        public StudentMark GetStudentmarkByStudentMarkId(int studentMarkId)
        {
            return studentDataService.GetStudentMarkByStudentMarkId(studentMarkId);
        }
        #endregion GetStudentmarkByStudentMarkId

        #region GetStudentInfoByRollNumber
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Gets the student info by roll number.
        /// </summary>
        /// <param name="rollNumber">The roll number.</param>
        /// <returns>Student</returns>
        public StudentDSR GetStudentInfoByRollNumber(int rollNumber)
        {
            return studentDataService.GetStudentInfoByRollNumber(rollNumber);
        }
        #endregion GetStudentInfoByRollNumber

        #region DeleteStudent
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void DeleteStudent(int rollNumber)
        {
            studentDataService.DeleteStudent(rollNumber);
        }
        #endregion DeleteStudent

        #region StudentMarkDelete
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Students the mark delete.
        /// </summary>
        /// <param name="studentDelete">The student delete.</param>
        /// <returns>StudentMark</returns>
        public StudentMark StudentMarkDelete(int rollNumber)
        {
            return studentDataService.StudentMarkDelete(rollNumber);
        }
        #endregion StudentMarkDelete

        #region GetBySearch
        //Created by Vivek on 18.07.2013
        /// <summary>
        /// Gets the by search.
        /// </summary>
        /// <param name="studentDSR">The student DSR.</param>
        /// <returns>StudentDSRList</returns>
        public List<StudentDSR> GetBySearch(StudentDSR studentDSR)
        {
            return studentDataService.GetBySearch(studentDSR);
        }
        #endregion GetBySearch
    }
}
#endregion StudentRepository Class
