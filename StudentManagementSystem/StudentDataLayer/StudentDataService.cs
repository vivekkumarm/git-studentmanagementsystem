#region References
using System;
using System.Collections.Generic;
using StudentsBO;
using System.Data;
using System.Data.SqlClient;
using StudentsBO.DataSeachResults;
#endregion

#region StudentDataService Class
namespace DataService
{
    public class StudentDataService : BaseDataService
    {
        #region AddStudent
        //Created by Prasana on 17.07.2013
        /// <summary>
        /// Adds the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>RollNumber</returns>
        public int AddStudent(Student student)
        {
            int rollNumber = 0;
            object IdentityValue = 0;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_student_insert]";
                    cmd.Parameters.Add(new SqlParameter("@student_name", student.Name));
                    cmd.Parameters.Add(new SqlParameter("@standard", student.Standard));
                    cmd.Parameters.Add(new SqlParameter("@section", student.Section));
                    cmd.Parameters.Add(new SqlParameter("@gender", student.Gender));
                    cmd.Parameters.Add(new SqlParameter("@date_of_birth", student.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@phone_number", student.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@address", student.Address));
                    cmd.Parameters.Add(new SqlParameter("@created_by", 1));
                    IdentityValue = cmd.ExecuteScalar();
                }
                if (IdentityValue != DBNull.Value)
                {
                    rollNumber = Convert.ToInt32(IdentityValue);
                }
            }
            return rollNumber;
        }
        #endregion AddStudent

        #region UpdateStudent
        //Created by Prasana on 17.07.2013
        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void UpdateStudent(Student student)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_student_update]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@student_name", student.Name));
                    cmd.Parameters.Add(new SqlParameter("@standard", student.Standard));
                    cmd.Parameters.Add(new SqlParameter("@section", student.Section));
                    cmd.Parameters.Add(new SqlParameter("@gender", student.Gender));
                    cmd.Parameters.Add(new SqlParameter("@date_of_birth", student.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@phone_number", student.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@address", student.Address));
                    cmd.Parameters.Add(new SqlParameter("@modified_by", 1));
                    cmd.ExecuteNonQuery();
                }
            }
        } 
        #endregion UpdateStudent

        #region AddStudentMark
        //Created by Prasa on 17.07.2013
        /// <summary>
        /// Adds the student mark.
        /// </summary>
        /// <param name="studentMark">The student mark.</param>
        /// <returns>StudentMarkId</returns>
        public int AddStudentMark(StudentMark studentMark)
        {
            int studentMarkId = 0;
            object IdentityValue = 0;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_student_mark_insert]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", studentMark.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@language", studentMark.Language));
                    cmd.Parameters.Add(new SqlParameter("@english", studentMark.English));
                    cmd.Parameters.Add(new SqlParameter("@maths", studentMark.Maths));
                    cmd.Parameters.Add(new SqlParameter("@science", studentMark.Science));
                    cmd.Parameters.Add(new SqlParameter("@social", studentMark.Social));
                    cmd.Parameters.Add(new SqlParameter("@total", studentMark.Total));
                    cmd.Parameters.Add(new SqlParameter("@percentage", studentMark.Percentage));
                    cmd.Parameters.Add(new SqlParameter("@result", studentMark.Result));
                    cmd.Parameters.Add(new SqlParameter("@remarks", studentMark.Remarks));
                    cmd.Parameters.Add(new SqlParameter("@created_by", 1));
                    IdentityValue = cmd.ExecuteScalar();
                }
                if (IdentityValue != DBNull.Value)
                {
                    studentMarkId = Convert.ToInt32(IdentityValue);
                }
            }
            return studentMarkId;
        }
        #endregion AddStudentMark

        #region StudentMarkUpdate
        //Created By Vivek on 17.07.2013
        /// <summary>
        /// Students the mark update.
        /// </summary>
        /// <param name="studentMarkUpdate">The student mark update.</param>
        public void StudentMarkUpdate(StudentMark studentMarkUpdate)
        {
            using (var sqlcon = new SqlConnection(GetConnectionString()))
            {
                using (var sqlcmd = sqlcon.CreateCommand())
                {
                    sqlcon.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "[dbo].[usp_student_mark_update]";
                    sqlcmd.Parameters.Add(new SqlParameter("@student_mark_id", studentMarkUpdate.StudentMarkId));
                    sqlcmd.Parameters.Add(new SqlParameter("@roll_number", studentMarkUpdate.RollNumber));
                    sqlcmd.Parameters.Add(new SqlParameter("@language", studentMarkUpdate.Language));
                    sqlcmd.Parameters.Add(new SqlParameter("@english", studentMarkUpdate.English));
                    sqlcmd.Parameters.Add(new SqlParameter("@maths", studentMarkUpdate.Maths));
                    sqlcmd.Parameters.Add(new SqlParameter("@science", studentMarkUpdate.Science));
                    sqlcmd.Parameters.Add(new SqlParameter("@social", studentMarkUpdate.Social));
                    sqlcmd.Parameters.Add(new SqlParameter("@total", studentMarkUpdate.Total));
                    sqlcmd.Parameters.Add(new SqlParameter("@percentage", studentMarkUpdate.Percentage));
                    sqlcmd.Parameters.Add(new SqlParameter("@result", studentMarkUpdate.Result));
                    sqlcmd.Parameters.Add(new SqlParameter("@remarks", studentMarkUpdate.Remarks));
                    sqlcmd.Parameters.Add(new SqlParameter("@modified_by", 1));
                    sqlcmd.ExecuteNonQuery();
                }
            }
        }
        #endregion StudentMarkUpdate

        #region GetStudentByRollNumber
        //Created By Prasana on 17.07.2013
        /// <summary>
        /// Gets the student by roll number.
        /// </summary>
        /// <param name="rollNumber">The roll number.</param>
        /// <returns>Student</returns>
        public Student GetStudentByRollNumber(int rollNumber)
        {
            Student student = null;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_get_student_by_roll_number]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", rollNumber));
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            int studetRollNumberOrdinal = dataReader.GetOrdinal("Roll_Number");
                            int studentNameOrdinal = dataReader.GetOrdinal("student_name");
                            int standardOrdinal = dataReader.GetOrdinal("standard");
                            int sectionOrdinal = dataReader.GetOrdinal("section");
                            int genderOrdinal = dataReader.GetOrdinal("gender");
                            int dateOfBirthOrdinal = dataReader.GetOrdinal("date_of_birth");
                            int phoneNumberOrdinal = dataReader.GetOrdinal("phone_number");
                            int addressOrdinal = dataReader.GetOrdinal("address");
                            int modifiedByOrdinal = dataReader.GetOrdinal("modified_by");
                            while (dataReader.Read())
                            {
                                student = new Student
                                {

                                    RollNumber = dataReader.GetInt32(studetRollNumberOrdinal),
                                    Name = dataReader.GetString(studentNameOrdinal),
                                    Standard = dataReader.GetString(standardOrdinal),
                                    Section = dataReader.GetString(sectionOrdinal),
                                    Gender = Convert.ToChar(dataReader.GetValue(genderOrdinal)),
                                    DateOfBirth = dataReader.GetString(dateOfBirthOrdinal),
                                    PhoneNumber = dataReader.GetString(phoneNumberOrdinal),
                                    Address = dataReader.GetString(addressOrdinal),
                                    Modified_By = dataReader.GetInt32(modifiedByOrdinal)
                                };

                            }
                        }

                    }
                }
            }
            return student;
        }
        #endregion GetStudentByRollNumber


        #region GetStudentMarkByRollNumber
        //Created by Yogalakshmi on 23.07.2013
        /// <summary>
        /// Gets the student info by roll number.
        /// </summary>
        /// <param name="rollNumber">The roll number.</param>
        /// <returns>Student</returns>
        public StudentMark GetStudentMarkByRollNumber(int rollNumber)
        {
            StudentMark studentmark = null;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_get_student_mark_by_roll_number]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", rollNumber));
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            int studentMarkIdOrdinal = dataReader.GetOrdinal("student_mark_id");
                            int rollNumberOrdinal = dataReader.GetOrdinal("roll_number");
                            int languageOrdinal = dataReader.GetOrdinal("language");
                            int englishOrdinal = dataReader.GetOrdinal("english");
                            int mathsOrdinal = dataReader.GetOrdinal("maths");
                            int scienceOrdinal = dataReader.GetOrdinal("science");
                            int socialOrdinal = dataReader.GetOrdinal("social");
                            int totalOrdinal = dataReader.GetOrdinal("total");
                            int resultOrdinal = dataReader.GetOrdinal("result");
                            int percentageOrdinal = dataReader.GetOrdinal("percentage");
                            int remarksOrdinal = dataReader.GetOrdinal("remarks");
                            int createdByOrdinal = dataReader.GetOrdinal("modified_by");
                            while (dataReader.Read())
                            {
                                studentmark = new StudentMark();
                                studentmark.StudentMarkId = dataReader.GetInt32(studentMarkIdOrdinal);
                                studentmark.RollNumber = dataReader.GetInt32(rollNumberOrdinal);
                                studentmark.RollNumber = dataReader.GetInt32(rollNumberOrdinal);
                                studentmark.Language = dataReader.GetInt32(languageOrdinal);
                                studentmark.English = dataReader.GetInt32(englishOrdinal);
                                studentmark.Maths = dataReader.GetInt32(mathsOrdinal);
                                studentmark.Science = dataReader.GetInt32(scienceOrdinal);
                                studentmark.Social = dataReader.GetInt32(socialOrdinal);
                                studentmark.Total = dataReader.GetInt32(totalOrdinal);
                                studentmark.Result = Convert.ToChar(dataReader.GetValue(resultOrdinal));
                                studentmark.Percentage = Convert.ToSingle(dataReader.GetValue(percentageOrdinal).ToString());
                                studentmark.Remarks = dataReader.GetString(remarksOrdinal);
                                studentmark.Modified_By = dataReader.GetInt32(createdByOrdinal);

                            }
                        }
                    }
                }
            }
            return studentmark;
        }
        #endregion GetStudentMarkByRollNumber

        #region GetStudentmarkByStudentMarkId
        //Created By Prasana on 17.07.2013
        /// <summary>
        /// Gets the studentmark by student mark id.
        /// </summary>
        /// <param name="studentMarkId">The student mark id.</param>
        /// <returns>Student Mark</returns>
        public StudentMark GetStudentMarkByStudentMarkId(int studentMarkId)
        {
            StudentMark studentMark = null;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_get_student_mark_by_student_mark_id]";
                    cmd.Parameters.Add(new SqlParameter("@student_mark_id", studentMarkId));
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            int rollNumberOrdinal = dataReader.GetOrdinal("roll_number");
                            int languageOrdinal = dataReader.GetOrdinal("language");
                            int englishOrdinal = dataReader.GetOrdinal("english");
                            int mathsOrdinal = dataReader.GetOrdinal("maths");
                            int scienceOrdinal = dataReader.GetOrdinal("science");
                            int socialOrdinal = dataReader.GetOrdinal("social");
                            int totalOrdinal = dataReader.GetOrdinal("total");
                            int percentageOrdinal = dataReader.GetOrdinal("percentage");
                            int resultOrdinal = dataReader.GetOrdinal("result");
                            int remarksOrdinal = dataReader.GetOrdinal("remarks");
                            while (dataReader.Read())
                            {
                                studentMark = new StudentMark
                                {
                                    RollNumber = dataReader.GetInt32(rollNumberOrdinal),
                                    Language = dataReader.GetInt32(languageOrdinal),
                                    English = dataReader.GetInt32(englishOrdinal),
                                    Maths = dataReader.GetInt32(mathsOrdinal),
                                    Science = dataReader.GetInt32(scienceOrdinal),
                                    Social = dataReader.GetInt32(socialOrdinal),
                                    Total = dataReader.GetInt32(totalOrdinal),
                                    Percentage = Convert.ToSingle(dataReader.GetValue(percentageOrdinal).ToString()),
                                    Result = Convert.ToChar(dataReader.GetValue(resultOrdinal)),
                                    Remarks = dataReader.GetString(remarksOrdinal)
                                };
                            }

                        }
                    }
                }
            }
            return studentMark;
        }
        #endregion GetStudentmarkByStudentMarkId

        #region GetStudentInfoByRollNumber
        //Created by Yogalakshmi on 17.07.2013
        //Modified by Vivek on 23.07.2013
        /// <summary>
        /// Gets the student info by roll number.
        /// </summary>
        /// <param name="rollNumber">The roll number.</param>
        /// <returns>Student</returns>
        public StudentDSR GetStudentInfoByRollNumber(int rollNumber)
        {
            StudentDSR studentDSR = null;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_get_student_info_by_roll_number]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", rollNumber));
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            int studentNameOrdinal = dataReader.GetOrdinal("student_name");
                            int standardOrdinal = dataReader.GetOrdinal("standard");
                            int rollNumberOrdinal = dataReader.GetOrdinal("roll_number");
                            int languageOrdinal = dataReader.GetOrdinal("language");
                            int englishOrdinal = dataReader.GetOrdinal("english");
                            int mathsOrdinal = dataReader.GetOrdinal("maths");
                            int scienceOrdinal = dataReader.GetOrdinal("science");
                            int socialOrdinal = dataReader.GetOrdinal("social");
                            int totalOrdinal = dataReader.GetOrdinal("total");
                            int resultOrdinal = dataReader.GetOrdinal("result");
                            while (dataReader.Read())
                            {
                                studentDSR=new StudentDSR()
                                {
                                    roll_number = dataReader.GetInt32(rollNumberOrdinal),
                                    student_name = dataReader.GetString(studentNameOrdinal),
                                    standard = dataReader.GetString(standardOrdinal),
                                    language = dataReader.GetInt32(rollNumberOrdinal),
                                    english = dataReader.GetInt32(englishOrdinal),
                                    maths = dataReader.GetInt32(mathsOrdinal),
                                    science = dataReader.GetInt32(scienceOrdinal),
                                    social = dataReader.GetInt32(socialOrdinal),
                                    total = dataReader.GetInt32(totalOrdinal),
                                    result = Convert.ToChar(dataReader.GetValue(resultOrdinal)),
                                };
                            }
                        }
                    }
                }
            }
            return studentDSR;
        }
        #endregion GetStudentInfoByRollNumber


        #region DeleteStudent
        //Created by Yogalakshmi on 17.07.2013
        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="student">The student.</param>
        public void DeleteStudent(int rollNumber)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_student_delete]";
                    cmd.Parameters.Add(new SqlParameter("@roll_number", rollNumber));
                    cmd.Parameters.Add(new SqlParameter("@modified_by", 1));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion DeleteStudent

        #region StudentMarkDelete
        //Created by Vivek on 17.07.2013
        /// <summary>
        /// Students the mark delete.
        /// </summary>
        /// <param name="studentDelete">The student delete.</param>
        /// <returns>StudentMark</returns>
        public StudentMark StudentMarkDelete(int rollNumber)
        {
            StudentMark sMarkDelete = null;
            using (var sqlcon = new SqlConnection(GetConnectionString()))
            {
                using (var sqlcmd = sqlcon.CreateCommand())
                {
                    sqlcon.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "[dbo].[usp_student_mark_delete]";
                    sqlcmd.Parameters.Add(new SqlParameter("@roll_number", rollNumber));
                    sqlcmd.Parameters.Add(new SqlParameter("@modified_by", 1));
                    sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();
                }
            }
            return sMarkDelete;
        }
        #endregion StudentMarkDelete

        #region GetBySearch
        //Created by Vivek on 17.07.2013
        /// <summary>
        /// Gets the by search.
        /// </summary>
        /// <param name="studentDSR">The student DSR.</param>
        /// <returns>List of StudentDSR</returns>
        public List<StudentDSR> GetBySearch(StudentDSR studentDSR)
        {
            List<StudentDSR> studentLst = null;
            StudentDSR studentDsr = null;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[usp_student_search]";
                    studentDsr = new StudentDSR();
                    if (studentDSR.student_name == null && studentDsr.student_name == string.Empty)
                    {
                        command.Parameters.Add(new SqlParameter("@student_name", SqlDbType.NVarChar)).Value = null;
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@student_name", studentDSR.student_name));
                    }
                    if (studentDSR.roll_number != null)
                    {
                        command.Parameters.Add(new SqlParameter("@roll_number", SqlDbType.Int)).Value = null;
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@roll_number", studentDSR.roll_number));
                    }
                    if (studentDsr.result != null)
                    {
                        command.Parameters.Add(new SqlParameter("@result", SqlDbType.VarChar)).Value = null;
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@result", studentDSR.result));
                    }
                    if (studentDSR.standard == null && studentDsr.standard == string.Empty)
                    {
                        command.Parameters.Add(new SqlParameter("@standard", SqlDbType.NVarChar)).Value = null;
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@standard", studentDSR.standard));
                    }
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            studentLst = new List<StudentDSR>();
                            int regnoOrdinal = dataReader.GetOrdinal("roll_number");
                            int studentsNameOrdinal = dataReader.GetOrdinal("student_name");
                            int standardOrdinal = dataReader.GetOrdinal("standard");
                            int languageOrdinal = dataReader.GetOrdinal("language");
                            int englishOrdinal = dataReader.GetOrdinal("english");
                            int mathsOrdinal = dataReader.GetOrdinal("maths");
                            int ScienceOrdinal = dataReader.GetOrdinal("science");
                            int socialOrdinal = dataReader.GetOrdinal("social");
                            int totalOrdinal = dataReader.GetOrdinal("total");
                            int resultOrdinal = dataReader.GetOrdinal("result");
                            while (dataReader.Read())
                            {
                                studentDsr = new StudentDSR
                                {
                                    roll_number = dataReader.GetInt32(regnoOrdinal),
                                    student_name = dataReader.GetString(studentsNameOrdinal),
                                    standard=dataReader.GetString(standardOrdinal),
                                    language = dataReader.GetInt32(languageOrdinal),
                                    english = dataReader.GetInt32(englishOrdinal),
                                    maths = dataReader.GetInt32(mathsOrdinal),
                                    science = dataReader.GetInt32(ScienceOrdinal),
                                    social = dataReader.GetInt32(socialOrdinal),
                                    total = dataReader.GetInt32(totalOrdinal),
                                    result = Convert.ToChar(dataReader.GetValue(resultOrdinal))
                                };
                                studentLst.Add(studentDsr);
                            }
                        }

                    }
                }
            }
            return studentLst;
        }
        #endregion GetBySearch
    }
}
#endregion StudentDataService Class