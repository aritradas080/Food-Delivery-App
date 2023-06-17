using Finalv1BLL.ModelDTOs;
using Finalv1DAL;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public class LogService
    {
        public static bool LogCheck(AllUserDTO allUserDTO)
        {
            var allusers = DataAccessFactory.AllUserData().Get();
            var user=(from i in allusers
                      where i.Username== allUserDTO.Username
                      && i.Password==allUserDTO.Password
                      && i.Role==allUserDTO.Role
                      select i).SingleOrDefault();
            if(user==null)
            {
                return false;
            }
            return true;
        }
        public static AllUser LogUIdCheck(AllUserDTO allUserDTO)
        {
            var allusers = DataAccessFactory.AllUserData().Get();
            var user = (from i in allusers
                        where i.Username == allUserDTO.Username
                        && i.Password == allUserDTO.Password
                        && i.Role == allUserDTO.Role
                        select i).SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public static string LogIn(AllUserDTO allUserDTO)
        {
            var isuser=LogCheck(allUserDTO);
            var user2 = LogUIdCheck(allUserDTO);
            if (isuser)
            {
                var Token = new Token()
                {
                    Tokens = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now,
                    UId = user2.UId,
                    Role = allUserDTO.Role,
                    ExpTime=null
                };
                DataAccessFactory.TokenData().Create(Token);
                return Token.Tokens;
            }
            return null;
        }
        public static bool LogOut(string token)
        {
            var onetoken=CheckTokenstring(token);
            if(onetoken.Equals(null))
            {
                return false;
            }
            onetoken.ExpTime = DateTime.Now;
            DataAccessFactory.TokenData().Update(onetoken);
            return true;

        }
        public static bool CheckToken(string token)
        {
            var tokens=DataAccessFactory.TokenData().Get();
            var onetoke = (from i in tokens
                           where i.Tokens.Equals(token)
                           && i.ExpTime.Equals(null)
                           select i).SingleOrDefault();
            if(onetoke==null) { return false;}
            return true;
        }
        public static Token CheckTokenstring(string token)
        {
            var tokens = DataAccessFactory.TokenData().Get();
            var onetoke = (from i in tokens
                           where i.Tokens.Equals(token)
                           && i.ExpTime.Equals(null)
                           select i).SingleOrDefault();
            if (onetoke == null) { return null; }
            return onetoke;
        }
        public static bool checkUser(string token,string role)
        {
            var onetoken = CheckTokenstring(token);
            if(onetoken==null)
            { return false; }
            else if(onetoken.Role==role) { return true; } else { return false; }
        }
        public static bool checkUser2(string token, string frole, string lrole)
        {
            var onetoken = CheckTokenstring(token);
            if (onetoken == null)
            { return false; }
            else if (onetoken.Role == frole) { 
                return true; 
                
            }
            else if (onetoken.Role == lrole)
            {
                return true;
            }

            else { return false; }
        }
    }
}
