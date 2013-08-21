/****************************************************************************************
                         CREATED BY  : Yogalakshmi
                         DESCRIPTION : UserDataService Class
                         CREATED ON  : 18.07.2013 
 ****************************************************************************************/

#region References
using StudentsBO;
using DataService;
#endregion References

#region UserRepository Class
namespace StudentBusinessLogic
{
    public class UserRepository
    {
        UserDataService userDataService = new UserDataService();

        #region InsertUser
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public int InsertUser(User user)
        {
            return userDataService.InsertUser(user);
        }
        #endregion

        #region GetAllUser
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        public User GetAllUser(User user)
        {
            var getUser = userDataService.GetAllUser(user);
            return getUser;
        }
        #endregion


        #region

        public int UserAvailablityCheck(string input)
        {
            return userDataService.UserAvailablityCheck(input);
        }
        #endregion

        #region GetAllUserDetail
        //Created by Vivek on 19.07.2013
        /// <summary>
        /// Gets all user detail.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        public int GetAllUserDetail(User userDetail)
        {
            return userDataService.GetAllUserDetail(userDetail);
        }
        #endregion GetAllUserDetail
    }
}
#endregion UserRepository Class