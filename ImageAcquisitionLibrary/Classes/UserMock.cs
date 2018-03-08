using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAcquisitionLibrary.Classes
{
    public class UserMock
    {
        public string username;
        public string password;
        public string permission;
    

        public List<UserMock> GenerateMockUsers()
        {

            var userList = new List<UserMock>();
            var userMock = new UserMock() {
                username = "doctor",
                password = "doctor",
                permission = "user"
            };
            var auditorMock = new UserMock()
            {
                username = "auditor",
                password = "auditor",
                permission = "auditor"
            };
            var adminMock = new UserMock()
            {
                username = "admin",
                password = "admin",
                permission = "admin"
            };
            userList.Add(userMock);
            userList.Add(auditorMock);
            userList.Add(adminMock);

            return userList;
        }
    }
}
