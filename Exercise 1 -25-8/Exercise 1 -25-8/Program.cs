using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Ex01();
        Ex02();
        Ex03();
        //Ẽx02//
        Ex04();
        Ex05();
        Ex06();
        Ex07();
    }

    // Bài 1: Chuyển đổi độ C sang F và K 
    static void Ex01()
    {
        Console.Write("Nhap do C: ");
        double c;
        while (!double.TryParse(Console.ReadLine(), out c))
        {
            Console.WriteLine("Gia tri khong hop le! Vui long nhap lai");
            Console.Write("Nhap lai do C: ");
        }

        double fahrenheit = (c * 1.8) + 32;     // công thức chuẩn
        Console.WriteLine($"{c}°C = {fahrenheit}°F");

        double kelvin = c + 273.15;             // chuẩn hơn so với +273
        Console.WriteLine($"{c}°C = {kelvin}K");
    }

    // Bài 2: Tính diện tích và thể tích hình cầu
    static void Ex02()//trùng câu bài Ex02 nên em không làm//
    {
        Console.Write("Enter radius: ");
        float radius;
        while (!float.TryParse(Console.ReadLine(), out radius) || radius <= 0)
        {
            Console.WriteLine("Gia tri khong hop le! Ban kinh phai la so duong.");
            Console.Write("Nhap lai radius: ");
        }

        double surface = 4 * Math.PI * Math.Pow(radius, 2);
        double volume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);  // sửa 4/3 -> 4.0/3.0

        Console.WriteLine($"Sphere with radius = {radius}:\n" +
            $"\tsurface = {surface}\n" +
            $"\tvolume = {volume}");
    }

    // Bài 3: Các phép toán với 2 số nguyên
    static void Ex03()
    {
        Console.Write("Nhap a = ");
        int a;
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Gia tri khong hop le! Vui long nhap lai so nguyen.");
            Console.Write("Nhap lai a = ");
        }

        Console.Write("Nhap b = ");
        int b;
        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Gia tri khong hop le! Vui long nhap lai so nguyen.");
            Console.Write("Nhap lai b = ");
        }

        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");

        if (b != 0)
        {
            Console.WriteLine($"{a} / {b} = {(double)a / b}");   // ép double để ra kết quả thập phân
            Console.WriteLine($"{a} % {b} = {a % b}");
        }
        else
        {
            Console.WriteLine("Khong the chia cho 0!");
        }
    }
    static void Ex04()
    {
        double num1, num2;
        char op;

        // Nhập số thứ nhất
        Console.Write("Nhap so thu nhat: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai so thu nhat: ");
        }

        // Nhập số thứ hai
        Console.Write("Nhap so thu hai: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai so thu hai: ");
        }

        // Nhập toán tử
        Console.Write("Nhap phep toan (+, -, *, /, %): ");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.Length == 1 && "+-*/%".Contains(input))
            {
                op = input[0];
                break;
            }
            Console.Write("Toan tu khong hop le! Vui long nhap lai (+, -, *, /, %): ");
        }

        // Tính toán
        switch (op)
        {
            case '+':
                Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                break;

            case '-':
                Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                break;

            case '*':
                Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                break;

            case '/':
                if (num2 != 0)
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                else
                    Console.WriteLine("Loi: Khong the chia cho 0!");
                break;

            case '%':
                if (num2 != 0)
                    Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
                else
                    Console.WriteLine("Loi: Khong the chia cho 0!");
                break;
        }
    }
    static void Ex05()
    {
        Console.WriteLine("\nBang gia tri x = y^2 + 2y + 1 (voi y tu -5 den 5):");
        for (int y = -5; y <= 5; y++)
        {
            int x = y * y + 2 * y + 1;
            Console.WriteLine($"y = {y}, x = {x}");
        }
    }
    static void Ex06()
    {
        double distance;
        Console.Write("Nhap quang duong (km): ");
        while (!double.TryParse(Console.ReadLine(), out distance) || distance <= 0)
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai quang duong: ");
        }

        int hours, minutes, seconds;

        Console.Write("Nhap gio: ");
        while (!int.TryParse(Console.ReadLine(), out hours) || hours < 0)
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai gio: ");
        }

        Console.Write("Nhap phut: ");
        while (!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || minutes >= 60)
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai phut: ");
        }

        Console.Write("Nhap giay: ");
        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds < 0 || seconds >= 60)
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai giay: ");
        }

        double totalHours = hours + (minutes / 60.0) + (seconds / 3600.0);

        if (totalHours == 0)
        {
            Console.WriteLine("Thoi gian khong hop le (bang 0)!");
            return;
        }

        double speedKmH = distance / totalHours;
        double speedMilesH = speedKmH * 0.621371;

        Console.WriteLine($"Toc do: {speedKmH:F2} km/h ({speedMilesH:F2} miles/h)");
    }
    static void Ex07()
    {
        Console.Write("\nNhap 1 ky tu: ");
        char ch;
        while (!char.TryParse(Console.ReadLine(), out ch))
        {
            Console.Write("Gia tri khong hop le! Vui long nhap lai 1 ky tu: ");
        }

        if ("aeiouAEIOU".Contains(ch))
        {
            Console.WriteLine($"{ch} la nguyen am.");
        }
        else if (char.IsDigit(ch))
        {
            Console.WriteLine($"{ch} la chu so.");
        }
        else
        {
            Console.WriteLine($"{ch} la ky tu khac.");
        }
    }
}
