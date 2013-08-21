/****************************************************************************************
                         CREATED BY  : Yogalakshmi
                         DESCRIPTION : UserRepositoryUnitTest Class
                         CREATED ON  : 18.07.2013 
 ****************************************************************************************/

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentBusinessLogic;
using StudentsBO;
#endregion References

#region UserRepositoryUnitTest Class
namespace RepositoryUnitTest
{
    [TestClass]
    public class UserRepositoryUnitTest
    {
        private readonly UserRepository mUserRepository = new UserRepository();
        public static UserRepository userRepository = new UserRepository();

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
                UserName = "Prachu",
                Password = "sri",
                ConfirmPassword = "sri",
                CreatedBy = 1,
                CreatedAt = DateTime.Now
            };
            user.UserId = userRepository.InsertUser(user);
            return user;
        }
        #endregion CreateUser

        #region CreateUserTest
        //Created by Yogalakshmi on 18.07.2013
        /// <summary>
        /// Creates the user test.
        /// </summary>
        [TestMethod]
        public void CreateUserTest()
        {
            User user = CreateUser();
            Assert.AreNotEqual(0, user.UserId);

            //var allUser = mUserRepository.GetAllUser();
            //foreach (var eachUser in allUser)
            //{
            //    if (user.UserName == eachUser.UserName)
            //    {
            //        Assert.AreEqual(user.UserName, eachUser.UserName);
            //    }
            //}
        }
        #endregion CreateUserTest
    }
}
#endregion UserRepositoryUnitTest Class