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
    public class MonthlyIncomeService
    {
        public static bool TotalIncomeofMonthCreate()
        {

            var monthlyIncome = DataAccessFactory.MonthlyIncomeData().Get();
            foreach (var item in monthlyIncome)
            {
                DataAccessFactory.MonthlyIncomeData().Delete(item.id);

            }

            var allorders = DataAccessFactory.OrderData().Get();
            var janIncome = new MonthlyIncome();
            var febIncome = new MonthlyIncome();
            var marIncome = new MonthlyIncome();
            var aprIncome = new MonthlyIncome();
            var mayIncome = new MonthlyIncome();
            var junIncome = new MonthlyIncome();
            var julIncome = new MonthlyIncome();
            var augIncome = new MonthlyIncome();
            var sepIncome = new MonthlyIncome();
            var octIncome = new MonthlyIncome();
            var novIncome = new MonthlyIncome();
            var decIncome = new MonthlyIncome();

            foreach (var item in allorders)
            {
                if(item.Date.Month == 1)
                {
                    janIncome.income += item.Amount;
                    janIncome.month = "Jnauary";
                }
                else if(item.Date.Month == 2)
                {
                    febIncome.income += item.Amount;
                    febIncome.month = "February";
                }
                else if(item.Date.Month == 3)
                {
                    marIncome.income += item.Amount;
                    marIncome.month = "March";
                }
                else if (item.Date.Month == 4)
                {
                    aprIncome.income += item.Amount;
                    aprIncome.month = "April";
                }
                else if (item.Date.Month == 5)
                {
                    mayIncome.income += item.Amount;
                    mayIncome.month = "May";
                }
                else if (item.Date.Month == 6)
                {
                    junIncome.income += item.Amount;
                    junIncome.month = "June";
                }
                else if (item.Date.Month == 7)
                {
                    julIncome.income += item.Amount;
                    julIncome.month = "July";
                }
                else if (item.Date.Month == 8)
                {
                    augIncome.income += item.Amount;
                    augIncome.month = "August";
                }
                else if (item.Date.Month == 9)
                {
                    sepIncome.income += item.Amount;
                    sepIncome.month = "September";
                }
                else if (item.Date.Month == 10)
                {
                    octIncome.income += item.Amount;
                    octIncome.month = "October";
                }
                else if (item.Date.Month == 11)
                {
                    novIncome.income += item.Amount;
                    novIncome.month = "November";
                }
                else if (item.Date.Month == 12)
                {
                    decIncome.income += item.Amount;
                    decIncome.month = "December";
                }
            }

            DataAccessFactory.MonthlyIncomeData().Create(janIncome);
            DataAccessFactory.MonthlyIncomeData().Create(febIncome);
            DataAccessFactory.MonthlyIncomeData().Create(marIncome);
            DataAccessFactory.MonthlyIncomeData().Create(aprIncome);
            DataAccessFactory.MonthlyIncomeData().Create(mayIncome);
            DataAccessFactory.MonthlyIncomeData().Create(junIncome);
            DataAccessFactory.MonthlyIncomeData().Create(julIncome);
            DataAccessFactory.MonthlyIncomeData().Create(augIncome);
            DataAccessFactory.MonthlyIncomeData().Create(sepIncome);
            DataAccessFactory.MonthlyIncomeData().Create(octIncome);
            DataAccessFactory.MonthlyIncomeData().Create(novIncome);
            return DataAccessFactory.MonthlyIncomeData().Create(decIncome);

         
        }

        public static List<MonthlyIncomeDTO> Get()
        {
            var list1 = new List<MonthlyIncomeDTO>();
            var list2 = DataAccessFactory.MonthlyIncomeData().Get();
            foreach(var item in list2)
            {
                list1.Add(new MonthlyIncomeDTO()
                {
                    id = item.id,
                    month= item.month,
                    income= item.income

                });
            }
            return list1;
        }

       
    }
}
