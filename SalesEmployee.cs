/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;

public class SalesEmployee : Employee
{
    private decimal baseSalary;
    private decimal salesRevenue;
    private decimal commissionRate;

    public decimal BaseSalary => baseSalary;
    public decimal SalesRevenue => salesRevenue;
    public decimal CommissionRate => commissionRate;

    // Constructor rút gọn
    public SalesEmployee(
        string employeeId,
        string fullName,
        decimal baseSalary)
        : this(
            employeeId,
            fullName,
            "Unassigned",
            baseSalary,
            0,
            0)
    {
    }

    // Constructor đầy đủ
    public SalesEmployee(
        string employeeId,
        string fullName,
        string department,
        decimal baseSalary,
        decimal salesRevenue,
        decimal commissionRate)
        : base(employeeId, fullName, department)
    {
        if (baseSalary < 0)
            throw new ArgumentException(
                "Luong co ban khong duoc am.");

        if (salesRevenue < 0)
            throw new ArgumentException(
                "Doanh so khong duoc am.");

        if (commissionRate < 0 ||
            commissionRate > 0.3m)
            throw new ArgumentException(
                "Ty le hoa hong phai nam trong khoang 0 den 0.3.");

        this.baseSalary = baseSalary;
        this.salesRevenue = salesRevenue;
        this.commissionRate = commissionRate;
    }

    // Cập nhật doanh số có kiểm soát
    public void updateSalesRevenue(decimal newRevenue)
    {
        if (newRevenue < 0)
            throw new ArgumentException(
                "Doanh so khong duoc am.");

        salesRevenue = newRevenue;
    }

    public override decimal calculateGrossPay()
    {
        return baseSalary
             + salesRevenue * commissionRate
             + MonthlyBonus;
    }

    public override string getEmployeeType()
    {
        return "SalesEmployee";
    }

    public override void displayPayrollInfo()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Loai: {getEmployeeType()}");
        Console.WriteLine($"Ma: {EmployeeId}");
        Console.WriteLine($"Ho ten: {FullName}");
        Console.WriteLine($"Phong ban: {Department}");
        Console.WriteLine($"Luong co ban: {baseSalary:N0}");
        Console.WriteLine($"Doanh so: {salesRevenue:N0}");
        Console.WriteLine(
            $"Hoa hong: {commissionRate:P0}");
        Console.WriteLine($"Thuong: {MonthlyBonus:N0}");
        Console.WriteLine(
            $"Tong thu nhap: {calculateGrossPay():N0}");
    }
}