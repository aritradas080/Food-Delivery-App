using Finalv1BLL.ModelDTOs;
using Finalv1DAL.Models;
using Finalv1DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public class CuisineService
    {
        public static List<CuisineDTO> Get()
        {
            var list1 = DataAccessFactory.CuisineData().Get();
            var list2 = new List<CuisineDTO>();
            foreach (var item in list1)
            {
                list2.Add(new CuisineDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price_Range = item.Price_Range,
                    Spice_Level = item.Spice_Level,
                    Time_To_Prep = item.Time_To_Prep
                });
            }
            return list2;
        }

        public static CuisineDTO Get(int id)
        {
            var allcui = Get();
            var cui = (from item in allcui
                       where item.Id == id
                       select item).SingleOrDefault();
            return cui;
        }

        public static bool Create(CuisineDTO cuisinedto)
        {
            var cuisine = new Cuisine();
            cuisine.Id = cuisinedto.Id;
            cuisine.Name = cuisinedto.Name;
            cuisine.Price_Range = cuisinedto.Price_Range;
            cuisine.Spice_Level = cuisinedto.Spice_Level;
            cuisine.Time_To_Prep = cuisinedto.Time_To_Prep;

            return DataAccessFactory.CuisineData().Create(cuisine);
        }

        public static bool Update(CuisineDTO cuisinedto)
        {
            var cuisine = new Cuisine();
            cuisine.Id = cuisinedto.Id;
            cuisine.Name = cuisinedto.Name;
            cuisine.Price_Range = cuisinedto.Price_Range;
            cuisine.Spice_Level = cuisinedto.Spice_Level;
            cuisine.Time_To_Prep = cuisinedto.Time_To_Prep;

            return DataAccessFactory.CuisineData().Update(cuisine);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CuisineData().Delete(id);
        }

        public static List<CuisineDTO> SearchBySpiceLevel(String spice)
        {
            var spicelevel = Get();
            var spiceadd = (from i in spicelevel
                            where i.Spice_Level == spice
                           select i).ToList();
            return spiceadd;

        }
    }
}
