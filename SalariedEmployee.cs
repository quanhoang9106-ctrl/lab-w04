/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;

public class SalariedEmployee : Employee
{
    private decimal monthlySalary;
    private decimal responsibilityAllowance;

    public decimal MonthlySalary => monthlySalary;
    public decimal ResponsibilityAllowance => responsibilityAllowance;

    // Constructor rút gọn
    public SalariedEmployee(
        string employeeId,
        string fullName,
        decimal monthlySalary)
        : this(
            employeeId,
            fullName,
            "Unassigned",
            monthlySalary,
            0)
    {
    }

    // Constructor đầy đủ
    public SalariedEmployee(
        string employeeId,
        string fullName,
        string department,
        decimal monthlySalary,
        decimal responsibilityAllowance)
        : base(employeeId, fullName, department)
    {
        if (monthlySalary < 0)
            throw new ArgumentException(
                "Luong thang khong duoc am.");

        if (responsibilityAllowance < 0)
            throw new ArgumentException(
                "Phu cap trach nhiem khong duoc am.");

        this.monthlySalary = monthlySalary;
        this.responsibilityAllowance = responsibilityAllowance;
    }

    // Ghi đè công thức tính lương
    public override decimal calculateGrossPay()
    {
        return monthlySalary
             + responsibilityAllowance
             + MonthlyBonus;
    }

    public override string getEmployeeType()
    {
        return "SalariedEmployee";
    }

    public override void displayPayrollInfo()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Loai: {getEmployeeType()}");
        Console.WriteLine($"Ma: {EmployeeId}");
        Console.WriteLine($"Ho ten: {FullName}");
        Console.WriteLine($"Phong ban: {Department}");
        Console.WriteLine($"Luong thang: {monthlySalary:N0}");
        Console.WriteLine(
            $"Phu cap: {responsibilityAllowance:N0}");
        Console.WriteLine($"Thuong: {MonthlyBonus:N0}");
        Console.WriteLine(
            $"Tong thu nhap: {calculateGrossPay():N0}");
    }
}