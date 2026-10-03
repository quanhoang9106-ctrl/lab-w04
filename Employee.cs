/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;

public abstract class Employee
{
    // Thuộc tính chung của mọi nhân viên
    private string employeeId;
    private string fullName;
    private string department;
    private decimal monthlyBonus;

    // Các thuộc tính chỉ đọc từ bên ngoài
    public string EmployeeId => employeeId;
    public string FullName => fullName;
    public string Department => department;
    public decimal MonthlyBonus => monthlyBonus;

    // Constructor rút gọn
    public Employee(string employeeId, string fullName)
        : this(employeeId, fullName, "Unassigned")
    {
    }

    // Constructor đầy đủ
    public Employee(string employeeId, string fullName, string department)
    {
        if (string.IsNullOrWhiteSpace(employeeId))
            throw new ArgumentException("Ma nhan vien khong duoc rong.");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Ho ten khong duoc rong.");

        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Phong ban khong duoc rong.");

        this.employeeId = employeeId;
        this.fullName = fullName;
        this.department = department;

        // Giá trị mặc định khi bắt đầu kỳ lương
        monthlyBonus = 0;
    }

    // Nạp chồng 1: thưởng số tiền cố định
    public void addBonus(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Tien thuong phai lon hon 0.");

        monthlyBonus += amount;
    }

    // Nạp chồng 2: thưởng cố định kèm lý do
    public void addBonus(decimal amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Ly do thuong khong duoc rong.");

        // Tái sử dụng phiên bản thứ nhất
        addBonus(amount);
    }

    // Nạp chồng 3: thưởng theo tỷ lệ
    public void addBonus(
        decimal rate,
        decimal referenceAmount,
        string reason)
    {
        if (rate <= 0 || rate > 0.5m)
            throw new ArgumentException(
                "Ty le thuong phai lon hon 0 va khong qua 0.5.");

        if (referenceAmount <= 0)
            throw new ArgumentException(
                "Gia tri tham chieu phai lon hon 0.");

        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException(
                "Ly do thuong khong duoc rong.");

        decimal bonusAmount = rate * referenceAmount;
        monthlyBonus += bonusAmount;
    }

    // Đặt lại thưởng khi bắt đầu kỳ lương mới
    public void resetBonus()
    {
        monthlyBonus = 0;
    }

    // Các lớp con phải tự cài đặt
    public abstract decimal calculateGrossPay();

    public abstract string getEmployeeType();

    public abstract void displayPayrollInfo();
}