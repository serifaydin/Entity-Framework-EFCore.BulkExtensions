using CA_Bulk.BulkData;
using CA_Bulk.Data;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CA_Bulk
{
    class Program
    {
        private static BulkDbContext context = new BulkDbContext();

        static void Main(string[] args)
        {
            EFAddRange();
            Console.ReadKey();
        }

        public async static void EFBulkInsert()
        {
            Console.WriteLine("EFBulkInsert methoduna girdi");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var subEntities = new List<BulkTable>();

            BulkTableList bulkData = new BulkTableList();
            List<BulkTable> _data = bulkData.Data(400000);

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var entity in _data)
                {
                    subEntities.Add(new BulkTable
                    {
                        Name = entity.Name,
                        Surname = entity.Surname
                    });
                }
                await context.BulkInsertAsync(subEntities);
                transaction.Commit();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds / 1000 + "Saniye ");
        }

        public static void EFAddRange()
        {
            Console.WriteLine("EFAddRange methoduna girdi");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            BulkTableList bulkData = new BulkTableList();
            List<BulkTable> _data = bulkData.Data(4000);
            context.BulkTable.AddRange(_data);
            context.SaveChanges();
            sw.Stop();

            long ms = sw.ElapsedMilliseconds / 1000;

            Console.WriteLine(ms.ToString());
        }
    }
}
