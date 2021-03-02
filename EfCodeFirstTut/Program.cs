using EfCodeFirstTut.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstTut {
    class Program {
        static async Task Main(string[] args) {

            #region Customer
            var cCtrl = new CustomerController();

            // // creating cust Walmart
            //var CWal = new Customer {
            //    Id = 0, Code = "WMT", Name = "Walmart", IsNational = true, Sales = 30000m, Created = new DateTime(2021, 3, 2)

            //};
            //var cWalNew = await cCtrl.Create(CWal);
            //Console.WriteLine($" The new Customer is {cWalNew.Name}, and their Id number is {cWalNew.Id}, and their sales total is {cWalNew.Sales}");

            // // creating cust Target
            //var cTar = new Customer {
            //    Id = 0, Code = "TRG", Name = "Target", IsNational = true, Sales = 300m, Created = new DateTime(2021, 3, 2)
            //};
            //var cTarNew = await cCtrl.Create(cTar);
            //Console.WriteLine($" The new Customer is {cTarNew.Name}, and their Id number is {cTarNew.Id}, and their sales total is {cTarNew.Sales}");

            var cust = await cCtrl.GetByPk(1);
            cust.Sales = 3200.86m;
            await cCtrl.Change(cust);
            Console.WriteLine($"Id Number {cust.Id} | Name {cust.Name} | Sales {cust.Sales} ");


            //var customers = await cCtrl.Getall();
            //foreach(var c in customers) {
            //    Console.WriteLine($"Id #{c.Id} | customer name {c.Name} | are they national {c.IsNational} | sales {c.Sales}");
            //}
            #endregion





        }
    }
}
