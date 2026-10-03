/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;

public class HourlyEmployee : Employee
{
    private decimal hourlyRate;
    private decimal workedHours;

    public decimal HourlyRate => hourlyRate;
    public decimal WorkedHours => workedHours;

    // Constructor rút gọn
    public HourlyEmployee(
        string employeeId,
        string fullName,
        decimal hourlyRate)
        : this(
            employeeId,
            fullName,
            "Unassigned",
            hourlyRate,
            0)
    {
    }

    // Constructor đầy đủ
    public HourlyEmployee(
        string employeeId,
        string fullName,
        string department,
        decimal hourlyRate,
        decimal workedHours)
        : base(employeeId, fullName, department)
    {
        if (hourlyRate < 0)
            throw new ArgumentException(
                "Don gia gio khong duoc am.");

        if (workedHours < 0 || workedHours > 250)
            throw new ArgumentException(
                "So gio lam phai nam trong khoang 0 den 250.");

        this.hourlyRate = hourlyRate;
        this.workedHours = workedHours;
    }

    public override decimal calculateGrossPay()
    {
        decimal basePay;

        if (workedHours <= 160)
        {
            basePay = workedHours * hourlyRate;
        }
        else
        {
            basePay =
                160 * hourlyRate
                + (workedHours - 160)
                * hourlyRate
                * 1.5m;
        }

        return basePay + MonthlyBonus;
    }

    public override string getEmployeeType()
    {
        return "HourlyEmployee";
    }

    public override void displayPayrollInfo()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Loai: {getEmployeeType()}");
        Console.WriteLine($"Ma: {EmployeeId}");
        Console.WriteLine($"Ho ten: {FullName}");
        Console.WriteLine($"Phong ban: {Department}");
        Console.WriteLine($"Don gia gio: {hourlyRate:N0}");
        Console.WriteLine($"So gio lam: {workedHours}");
        Console.WriteLine($"Thuong: {MonthlyBonus:N0}");
        Console.WriteLine(
            $"Tong thu nhap: {calculateGrossPay():N0}");
    }
}