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
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var list1 = DataAccessFactory.ProductData().Get();
            var list2 = new List<ProductDTO>();
            foreach (var item in list1)
            {
                list2.Add(new ProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price= item.Price,
                    Quantity= item.Quantity,
                    Rid= item.Rid,
                    Cid = item.Cid
                });
            }
            return list2;
        }

        public static ProductDTO Get(int id)
        {
            var allpro = Get();
            var pro = (from item in allpro
                       where item.Id == id
                       select item).SingleOrDefault();
            return pro;
        }

        public static bool Create(ProductDTO productdto)
        {
            var product = new Product();
            product.Id = productdto.Id;
            product.Name = productdto.Name;
            product.Price = productdto.Price;
            product.Quantity = productdto.Quantity;
            product.Rid = productdto.Rid;
            product.Cid = productdto.Cid;
            

            return DataAccessFactory.ProductData().Create(product);
        }

        public static bool Update(ProductDTO productdto)
        {
            var product = new Product();
            product.Id = productdto.Id;
            product.Name = productdto.Name;
            product.Price = productdto.Price;
            product.Quantity = productdto.Quantity;
            product.Rid = productdto.Rid;
            product.Cid = productdto.Cid;

            return DataAccessFactory.ProductData().Update(product);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }
    }
}
