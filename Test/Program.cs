using CommonLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnStr.connStr = "data source=sjk.taoliu.com.cn;Database=sq_taoliu2;uid=sq_taoliu2;pwd=taoliu123";
            TasksClass c = new TasksClass();
            DataTable t=c.downTask("", "", 6152);

        }
    }
}
