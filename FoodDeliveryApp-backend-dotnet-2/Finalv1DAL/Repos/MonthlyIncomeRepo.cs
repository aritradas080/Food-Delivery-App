using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class MonthlyIncomeRepo : Repo, IRepo<MonthlyIncome, int, bool>
    {
        public bool Create(MonthlyIncome type)
        {
            db.MonthlyIncomes.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exmoi = Get(id);
            db.MonthlyIncomes.Remove(exmoi);
            return db.SaveChanges() > 0;
        }

        public List<MonthlyIncome> Get()
        {
            return db.MonthlyIncomes.ToList();

        }

        public MonthlyIncome Get(int id)
        {
            return db.MonthlyIncomes.Find(id);
        }

        public bool Update(MonthlyIncome type)
        {
            var exmoi = (from item in db.MonthlyIncomes
                         where item.id == type.id
                         select item).SingleOrDefault();
            exmoi.id = type.id;
            exmoi.month = type.month;
            exmoi.income = type.income;
            return db.SaveChanges() > 0;
        }
    }
}
