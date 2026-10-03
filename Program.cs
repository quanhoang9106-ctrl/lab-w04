/*************************************************
Mã sinh viên: 202418971
Họ tên: Hoàng Văn Quân
*************************************************/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding =
            System.Text.Encoding.UTF8;

        Console.WriteLine(
            "HE THONG TINH LUONG VA THUONG NHAN SU");

        // Tạo bảng lương tháng 09/2026
        Payroll payroll = new Payroll("2026-09");

        // =================================================
        // E001 - Nhân viên lương cố định
        // =================================================
        SalariedEmployee employee1 =
            new SalariedEmployee(
                "E001",
                "Nguyen Minh An",
                "Dao tao",
                15_000_000m,
                2_000_000m);

        employee1.addBonus(
            1_000_000m,
            "Thuong co dinh");

        // =================================================
        // E002 - Nhân viên theo giờ, không vượt 160 giờ
        // =================================================
        HourlyEmployee employee2 =
            new HourlyEmployee(
                "E002",
                "Tran Thu Binh",
                "Ho tro",
                100_000m,
                150);

        employee2.addBonus(
            500_000m,
            "Thuong thang");

        // =================================================
        // E003 - Nhân viên theo giờ, có làm thêm
        // =================================================
        HourlyEmployee employee3 =
            new HourlyEmployee(
                "E003",
                "Le Hoang Chi",
                "Ho tro",
                100_000m,
                170);

        // =================================================
        // E004 - Nhân viên kinh doanh
        // =================================================
        SalesEmployee employee4 =
            new SalesEmployee(
                "E004",
                "Pham Quoc Dung",
                "Kinh doanh",
                8_000_000m,
                200_000_000m,
                0.05m);

        employee4.addBonus(
            0.02m,
            50_000_000m,
            "Thuong theo ty le");

        // Thêm các nhân viên vào bảng lương
        payroll.addEmployee(employee1);
        payroll.addEmployee(employee2);
        payroll.addEmployee(employee3);
        payroll.addEmployee(employee4);

        // Hiển thị toàn bộ bảng lương
        payroll.displayPayroll();

        Console.WriteLine();
        Console.WriteLine(
            $"Tong phong Ho tro: " +
            $"{payroll.calculatePayrollByDepartment("Ho tro"):N0}");

        Employee? highest =
            payroll.findHighestPaidEmployee();

        if (highest != null)
        {
            Console.WriteLine(
                $"Nhan vien co thu nhap cao nhat: " +
                $"{highest.FullName} - " +
                $"{highest.calculateGrossPay():N0}");
        }

        // =================================================
        // KIEM THU BIEN VA KIEM THU LOI
        // =================================================

        Console.WriteLine();
        Console.WriteLine(
            "===== KIEM THU BIEN VA LOI =====");

        runTest(
            "1. Ma nhan vien rong",
            () =>
            {
                new SalariedEmployee(
                    "",
                    "Test",
                    10_000_000m);
            });

        runTest(
            "2. Ho ten rong",
            () =>
            {
                new SalariedEmployee(
                    "T002",
                    "",
                    10_000_000m);
            });

        runTest(
            "3. Thuong bang 0",
            () =>
            {
                employee1.addBonus(0);
            });

        runTest(
            "4. Thuong am",
            () =>
            {
                employee1.addBonus(-100_000m);
            });

        runTest(
            "5. Ty le thuong lon hon 0.5",
            () =>
            {
                employee1.addBonus(
                    0.6m,
                    1_000_000m,
                    "Test");
            });

        runTest(
            "6. WorkedHours = 160",
            () =>
            {
                HourlyEmployee test =
                    new HourlyEmployee(
                        "T006",
                        "Test 6",
                        "Test",
                        100_000m,
                        160);

                Console.WriteLine(
                    $"Ket qua: {test.calculateGrossPay():N0}");
            });

        runTest(
            "7. WorkedHours = 250",
            () =>
            {
                HourlyEmployee test =
                    new HourlyEmployee(
                        "T007",
                        "Test 7",
                        "Test",
                        100_000m,
                        250);

                Console.WriteLine(
                    $"Ket qua: {test.calculateGrossPay():N0}");
            });

        runTest(
            "8. WorkedHours = 251",
            () =>
            {
                new HourlyEmployee(
                    "T008",
                    "Test 8",
                    "Test",
                    100_000m,
                    251);
            });

        runTest(
            "9. CommissionRate = 0.3",
            () =>
            {
                SalesEmployee test =
                    new SalesEmployee(
                        "T009",
                        "Test 9",
                        "Test",
                        5_000_000m,
                        10_000_000m,
                        0.3m);

                Console.WriteLine(
                    $"Ket qua: {test.calculateGrossPay():N0}");
            });

        runTest(
            "10. CommissionRate = 0.31",
            () =>
            {
                new SalesEmployee(
                    "T010",
                    "Test 10",
                    "Test",
                    5_000_000m,
                    10_000_000m,
                    0.31m);
            });

        runTest(
            "11. Them trung ma nhan vien",
            () =>
            {
                payroll.addEmployee(employee1);
            });

        Console.WriteLine();
        Console.WriteLine(
            "Chuong trinh ket thuc.");
    }

    // Hàm hỗ trợ chạy từng tình huống kiểm thử
    static void runTest(
        string testName,
        Action testAction)
    {
        Console.WriteLine();
        Console.WriteLine(testName);

        try
        {
            testAction();

            Console.WriteLine(
                "Ket qua: Hop le, khong phat sinh loi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Ket qua: Phat hien loi - {ex.Message}");
        }
    }
}