using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace quiz4
{
    class ComplaintRepository
    {
        public List<Complaint> getData(string month)
        {
            List<Complaint> list = new List<Complaint>();
            try
            {
                using (StreamReader reader = new StreamReader(month+".csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] arr = line.Split(',');
                        if (arr.Length >= 5)
                        {
                            if (string.IsNullOrEmpty(arr[0]))
                            {
                                continue;
                            }
                            var cmp = new Complaint()
                            {
                                monthname = Convert.ToString(arr[0]),
                                c1 = Convert.ToInt32(arr[1]),
                                c2 = Convert.ToInt32(arr[2]),
                                c3 = Convert.ToInt32(arr[3]),
                                c4 = Convert.ToInt32(arr[4]),
                                c5 = Convert.ToInt32(arr[5]),
                            };
                            list.Add(cmp);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
        public bool saveData(string filename,List<Complaint>items)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename+".csv"))
                {
                    foreach (var item in items)
                    {
                        writer.WriteLine(string.Join(",", item.monthname, item.c1, item.c2, item.c3,item.c4,item.c5));
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
