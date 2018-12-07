using CA_Bulk.Data;
using System.Collections.Generic;

namespace CA_Bulk.BulkData
{
    public class BulkTableList
    {
        public List<BulkTable> Data(int size)
        {
            List<BulkTable> list = new List<BulkTable>();
            for (int i = 0; i < size; i++)
            {
                BulkTable item = new BulkTable { Name = "Bulk", Surname = "insert" };
                list.Add(item);
            }
            return list;
        }
    }
}