/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;
using System.Collections.Generic;

public class Payroll
{
    private string period;
    private List<Employee> employees;

    public string Period => period;

    public Payroll(string period)
    {
        if (string.IsNullOrWhiteSpace(period))
            throw new ArgumentException(
                "Ky luong khong duoc rong.");

        this.period = period;
        employees = new List<Employee>();
    }

    // Thêm nhân viên, không cho phép trùng mã
    public void addEmployee(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(
                nameof(employee));

        if (findEmployee(employee.EmployeeId) != null)
            throw new ArgumentException(
                "Ma nhan vien da ton tai trong bang luong.");

        employees.Add(employee);
    }

    // Tìm nhân viên theo mã
    public Employee? findEmployee(string employeeId)
    {
        foreach (Employee employee in employees)
        {
            if (employee.EmployeeId == employeeId)
                return employee;
        }

        return null;
    }

    // Tính tổng bảng lương bằng đa hình
    public decimal calculateTotalPayroll()
    {
        decimal total = 0;

        foreach (Employee employee in employees)
        {
            total += employee.calculateGrossPay();
        }

        return total;
    }

    // Tính tổng lương theo phòng ban
    public decimal calculatePayrollByDepartment(
        string department)
    {
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException(
                "Phong ban khong duoc rong.");

        decimal total = 0;

        foreach (Employee employee in employees)
        {
            if (string.Equals(
                employee.Department,
                department,
                StringComparison.OrdinalIgnoreCase))
            {
                total += employee.calculateGrossPay();
            }
        }

        return total;
    }

    // Tìm nhân viên có thu nhập cao nhất
    public Employee? findHighestPaidEmployee()
    {
        if (employees.Count == 0)
            return null;

        Employee highest = employees[0];

        foreach (Employee employee in employees)
        {
            if (employee.calculateGrossPay()
                > highest.calculateGrossPay())
            {
                highest = employee;
            }
        }

        return highest;
    }

    // Hiển thị toàn bộ bảng lương
    public void displayPayroll()
    {
        Console.WriteLine();
        Console.WriteLine(
            $"===== BANG LUONG KY {period} =====");

        if (employees.Count == 0)
        {
            Console.WriteLine(
                "Danh sach nhan vien dang rong.");
            return;
        }

        foreach (Employee employee in employees)
        {
            // Gọi đa hình
            employee.displayPayrollInfo();
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine(
            $"TONG BANG LUONG: {calculateTotalPayroll():N0}");
    }
}