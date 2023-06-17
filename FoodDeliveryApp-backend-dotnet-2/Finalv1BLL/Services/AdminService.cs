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
    public class AdminService
    {
        public static bool Create( AdminDTOs adminDTOs)
        {
            var user = new Admin();
            user.Id = adminDTOs.Id;
            user.Username = adminDTOs.Username;
            user.Password = adminDTOs.Password;
            user.Email = adminDTOs.Email;
            user.Name= adminDTOs.Name;


            DataAccessFactory.AdminData().Create(user);

            var getuser = (from i in DataAccessFactory.AdminData().Get()
                           where i.Username == adminDTOs.Username &&
                           i.Password == adminDTOs.Password
                           select i).SingleOrDefault();
            var alluser = new AllUser();
            alluser.UId = getuser.Id;
            alluser.Role = "Admin";
            alluser.Username = adminDTOs.Username;
            alluser.Password = adminDTOs.Password;

            return DataAccessFactory.AllUserData().Create(alluser);
        }
        public static List<AdminDTOs> Get()
        {
            var list1 = DataAccessFactory.AdminData().Get();
            var list2 = new List<AdminDTOs>();
            foreach (var item in list1)
            {
                list2.Add(new AdminDTOs()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Username = item.Username,
                    Password = item.Password, 
                    Email= item.Email,
                  
                });
            }
            return list2;
        }


        public static bool Update(AdminDTOs adminDTOs)
        {
            var user = new Admin();
            user.Id = adminDTOs.Id;
            user.Name = adminDTOs.Name;
            user.Username = adminDTOs.Username;
            user.Email = adminDTOs.Email;
            user.Password = adminDTOs.Password;

            return DataAccessFactory.AdminData().Update(user);
        }
    }
}
