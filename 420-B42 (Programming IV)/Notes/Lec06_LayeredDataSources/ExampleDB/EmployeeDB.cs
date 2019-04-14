using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDB
{
    public class EmployeeDB
    {
        public dsNaman.DataTableEmpInfoDataTable getFullEmployeeInfo()
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return myAdapter.GetData();
        }

        public dsNaman.DataTableEmpInfoDataTable getEmployeeById(int empId)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return myAdapter.GetDataByEmpId(empId);
        }

        public int getTotalSalary()
        {
            dsNamanTableAdapters.NN_EMPLOYEETableAdapter myAdapter = new dsNamanTableAdapters.NN_EMPLOYEETableAdapter();
            myAdapter.ClearBeforeFill = true;
            int retVal = Convert.ToInt32(myAdapter.SumSalary());
            return retVal;
        }
    }
}
