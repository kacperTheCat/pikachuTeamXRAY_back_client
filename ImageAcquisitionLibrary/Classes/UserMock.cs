using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            //salt generation

            var userList = new List<UserMock>();
            var userMock = new UserMock() {
                username = "doctor",
                password = hashPassword("doctor"),
                permission = "user"
            };
            var auditorMock = new UserMock()
            {
                username = "auditor",
                password = hashPassword("auditor"),
                permission = "auditor"
            };
            var adminMock = new UserMock()
            {
                username = "admin",
                password = hashPassword("admin"),
                permission = "admin"
            };
            userList.Add(userMock);
            userList.Add(auditorMock);
            userList.Add(adminMock);

            return userList;
        }

        public string hashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //hashing password
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            //placing hash and salt to array
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //convert to string
            string passwordHashString = Convert.ToBase64String(hashBytes);
            return passwordHashString;
        }
    }
}
