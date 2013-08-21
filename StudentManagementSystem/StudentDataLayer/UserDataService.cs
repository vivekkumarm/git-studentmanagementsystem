/****************************************************************************************
                         CREATED BY  : Yogalakshmi
                         DESCRIPTION : UserDataService Class
                         CREATED ON  : 18.07.2013 
 ****************************************************************************************/

#region References
using System;
using System.Data.SqlClient;
using StudentsBO;
using System.Data;
#endregion

#region UserDataService Class
namespace DataService
{
    public class UserDataService : BaseDataService
    {
        #region InsertUser
        //Created by Yogalakshmi on 17.07.2013
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>UserId</returns>
        public int InsertUser(User user)
        {
            int userId = 0;
            object IdentityValue = 0;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_user_insert]";
                    cmd.Parameters.Add(new SqlParameter("user_name", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("confirm_password", user.ConfirmPassword));
                    cmd.Parameters.Add(new SqlParameter("created_by", user.CreatedBy));
                    IdentityValue = cmd.ExecuteScalar();
                }
                if (IdentityValue != DBNull.Value)
                {
                    userId = Convert.ToInt32(IdentityValue);
                }
            }
            return userId;
        }
        #endregion InsertUser


        #region GetAllUser
        //Created by Yogalakshmi on 17.07.2013
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns>List of User</returns>
        public User GetAllUser(User user)
        {
            User userid = new User();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[usp_get_all_user]";
                    cmd.Parameters.Add(new SqlParameter("@user_name", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int userIDOrdinal = dr.GetOrdinal("user_id");
                            int userNameOrdinal = dr.GetOrdinal("user_name");
                            while (dr.Read())
                            {
                                user = new User();
                                user.UserName = dr.GetString(userNameOrdinal);
                                user.UserId = dr.GetInt32(userIDOrdinal);
                            }
                        }
                    }

                }
            }
            return user;

        }
        #endregion GetAllUser



        //Created by Vivek on 19.07.2013
        #region GetAllUserDetail
        /// <summary>
        /// Gets all user detail.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        public int GetAllUserDetail(User userDetail)
        {
            int result = 0;
            using (var sqlcon = new SqlConnection(GetConnectionString()))
            {
                using (var sqlcmd = sqlcon.CreateCommand())
                {
                    sqlcon.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "[dbo].[usp_user_insert]";
                    sqlcmd.Parameters.Add(new SqlParameter("@user_name", userDetail.UserName));
                    sqlcmd.Parameters.Add(new SqlParameter("@password", userDetail.Password));
                    sqlcmd.Parameters.Add(new SqlParameter("@confirm_password", userDetail.ConfirmPassword));
                    result = sqlcmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        #endregion GetAllUserDetail

        #region UserAvailablityCheck

        public int UserAvailablityCheck(string input)
        {
            int result = 0;
            using (var sqlcon=new SqlConnection(GetConnectionString()))
            {
                using (var sqlcmd=sqlcon.CreateCommand())
                {
                    sqlcon.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "usp_get_username_availablity";
                    sqlcmd.Parameters.Add(new SqlParameter("@user_name", input));
                    result=(int)sqlcmd.ExecuteScalar();           
                }
            }
            return result;
        }

        #endregion
    }
}
#endregion UserDataService Class

