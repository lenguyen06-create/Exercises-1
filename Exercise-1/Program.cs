internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Nhap a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap b: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Ex01(a, b);
        Ex02(a, b);
        Ex03(a, b);
        Ex04();
        Ex05();
        Ex06();
        Ex07();
        Ex08();
        Ex09();
        Ex10();
    }
    static void Ex01(int a, int b)
    {
        int c = a + b;
        Console.WriteLine($"a + b la {c}");
    }
    static void Ex02(int a, int b)
    {
        Console.WriteLine($"truoc khi doi a la {a}, b la {b}");
        int tam = a;
        a = b;
        b = tam;
        Console.WriteLine($"sau khi doi a la {a}, b la {b}");
    }
    static void Ex03(float a, float b)
    {
        float ketQua = a * b;
        Console.WriteLine($"a * b = {ketQua}");
    }
    static void Ex04()
    {
        Console.Write("Nhap so feet: ");
        double feet = Convert.ToDouble(Console.ReadLine());
        double meters = feet * 0.3048;
        Console.WriteLine($"{feet} feet = {meters} meters");
    }
    static void Ex05()
    {
        while (true) /*cho phép chọn lại*/
        {
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Celsius -> Fahrenheit");
            Console.WriteLine("2. Fahrenheit -> Celsius");
            Console.Write("Lua chon: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Nhap do C: ");
                double celsius = Convert.ToDouble(Console.ReadLine());
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
                break;
                /*thoát khỏi vòng lập
                 kết thúc sau khi chuyển đổi xong 
                */
            }
            else if (choice == 2)
            {
                Console.Write("Nhap do F: ");
                double fahrenheit = Convert.ToDouble(Console.ReadLine());
                double celsius = (fahrenheit - 32) * 5 / 9;
                Console.WriteLine($"{fahrenheit}°F = {celsius}°C");
                break; // kết thúc sau khi chuyển đổi xong
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le! Vui long chon lai.\n");/*ngắt dòng*/
            }
        }
    }
        static void Ex06()
        {
            Console.WriteLine("Kich thuoc cac kieu du lieu co ban trong C#:");

            Console.WriteLine($"Size of bool: {sizeof(bool)} byte");
            Console.WriteLine($"Size of char: {sizeof(char)} byte");
            Console.WriteLine($"Size of byte: {sizeof(byte)} byte");
            Console.WriteLine($"Size of short: {sizeof(short)} bytes");
            Console.WriteLine($"Size of int: {sizeof(int)} bytes");
            Console.WriteLine($"Size of long: {sizeof(long)} bytes");
            Console.WriteLine($"Size of float: {sizeof(float)} bytes");
            Console.WriteLine($"Size of double: {sizeof(double)} bytes");
            Console.WriteLine($"Size of decimal: {sizeof(decimal)} bytes");
            Console.WriteLine($"size of sbyte: {sizeof(sbyte)}bytes");
            Console.WriteLine($"size of uint: {sizeof(uint)}bytes");
            Console.WriteLine($"size of ulong: {sizeof(ulong)}bytes");
            Console.WriteLine($"size of ushort: {sizeof(ushort)}");
        }
    static void Ex07()
    {
        Console.WriteLine("Nhap 1 ky tu: ");
        char ch = Console.ReadKey().KeyChar;
        Console.WriteLine();
        int ascii = (int)ch;
        Console.WriteLine($"Ky tu'{ch}'co ma ASCII la: {ascii}");
    }
    static void Ex08()
    {
        Console.Write("Nhap ban kinh hinh tron: ");
        string? input = Console.ReadLine();

        if (double.TryParse(input, out double r))
        {
            double area = Math.PI * r * r;
            Console.WriteLine($"Dien tich hinh tron voi ban kinh {r} la: {area}");
        }
        else
        {
            Console.WriteLine("Gia tri nhap vao khong hop le!");
        }
    }

    static void Ex09()
    {
        Console.WriteLine("Nhap do dai canh hinh vuong: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double area = a * a;
        Console.WriteLine($"Dien tich hinh vuong voi canh {a} la: {area}");
    }
    static void Ex10()
    {
        Console.WriteLine("Nhap so ngay");
        int totalDays = Convert.ToInt32(Console.ReadLine());
        int years = totalDays / 365;
        int weeks = (totalDays % 365) / 7;
        int daysLeft = (totalDays % 365) % 7;
        Console.WriteLine($"{totalDays} ngay = {years} nam, {weeks} tuan, {daysLeft} ngay");
    }
    }

