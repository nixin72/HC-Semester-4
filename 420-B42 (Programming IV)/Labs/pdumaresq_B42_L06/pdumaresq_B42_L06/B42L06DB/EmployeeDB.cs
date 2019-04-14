using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B42L06DB
{
    public class EmployeeDB
    {
        public dsNaman.EmployeeDigestDataTable GetEmployeesBtDeptName(String deptName) {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return adapter.GetDataByDeptName(deptName);
        }

        public dsNaman.EmployeeDigestDataTable GetEmployeesByLastName(String lastName) {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return adapter.GetDataByLastName(lastName);
        }

        public int GetCountEmployeesByDept(int deptid) {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return (int) adapter.CountEmployeesInDept(deptid);
        }

        public int GetSumEmployeeSalary() {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return (int)adapter.GetSalarySum();
        }

        public int GetSumSalaryByDept(int deptid) {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return (int)adapter.GetSalaryByDept(deptid);
        }

        public dsNaman.EmployeeDigestDataTable GetEmployeesAboveSalary(int minSalary) {
            dsNamanTableAdapters.EmployeeDigestTableAdapter adapter = new dsNamanTableAdapters.EmployeeDigestTableAdapter();
            adapter.ClearBeforeFill = true;
            return adapter.GetDataBySalary(minSalary);
        }
    }
}
