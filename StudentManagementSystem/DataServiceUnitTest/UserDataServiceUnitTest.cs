/****************************************************************************************
                         CREATED BY  : Yogalakshmi
                         DESCRIPTION : UserDataServiceUnitTest Class
                         CREATED ON  : 18.07.2013 
 ****************************************************************************************/

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;
using StudentsBO;
#endregion

#region UserDataServiceUnitTest Class
namespace DataServiceUnitTest
{
    [TestClass]
    public class UserDataServiceUnitTest
    {
        private readonly UserDataService mUserDataService = new UserDataService();
        public List<string> allUser = new List<string>();
        public static UserDataService userDataService = new UserDataService();

        #region CreateUser
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns></returns>
        public static User CreateUser()
        {
            var user = new User()
            {
                UserName="Wazter",
                Password="phelo",
                ConfirmPassword = "phelo",
                CreatedBy=1,
                CreatedAt=DateTime.Now
            };
            user.UserId = userDataService.InsertUser(user);
            return user;
        }
        #endregion CreateUser

        #region RegisterUser

        public static User UserDetail()
        {
            var userDetail = new User
            {
                UserName="vivek",
                Password="d45ghyA@%",
                ConfirmPassword = "d45ghyA@%",
            };
           
            return userDetail;
        }

        #endregion

        #region

        public static User UserCheck()
        {
            var Check = new User
            {
                UserName="vivek",
                UserId=2,
            };
            return Check;
        }

        #endregion

        #region CreateUserTest
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Creates the user test.
        /// </summary>
        [TestMethod]
        public void  CreateUserTest()
        {
            User user = CreateUser();
            Assert.AreNotEqual(0, user.UserId);

            //var allUser = mUserDataService.GetAllUser(User user);
            //foreach (var eachUser in allUser)
            //{
            //    if (user.UserName == eachUser.UserName)
            //    {
            //        Assert.AreEqual(user.UserName, eachUser.UserName);
            //    }
            //}

        }
        #endregion CreateUserTest

        #region GetUserDetailTest

        /// <summary>
        /// Checks the user test.
        /// </summary>
        [TestMethod]
        public void CheckUserTest()
        {
            //create user
            User user = UserCheck();
            Assert.AreNotEqual(0, user.UserName);

            //User expected = mUserDataService.UserAvailablityCheck(user.UserName);
        }
        #endregion
    }
}
#endregion UserDataServiceUnitTest Class