using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Ex01(); // Largest number
        Ex02(); // Factorial
        Ex03(); // Prime check
        Ex04(); // Print primes
        Ex05(); // Perfect numbers
        Ex06(); // Pangram check
    }

    static int InputInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        int value;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out value) || value < minValue || value > maxValue)
        {
            Console.WriteLine("Gia tri khong hop le! Vui long nhap lai so nguyen.");
            Console.Write(message);
        }
        return value;
    }

    static string InputLetters(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
        {
            Console.WriteLine("Gia tri khong hop le! Vui long chi nhap chu cai (a-z, A-Z).");
            Console.Write(message);
            input = Console.ReadLine();
        }
        return input;
    }

    // ====== Bài 1: Largest Number ======
    static void Ex01()
    {
        Console.WriteLine("=== Bài 1: Largest Number ===");

        int a = InputInt("Nhap so thu nhat: ");
        int b = InputInt("Nhap so thu hai: ");
        int c = InputInt("Nhap so thu ba: ");

        int max3 = Math.Max(a, Math.Max(b, c));
        Console.WriteLine($"So lon nhat trong 3 so: {max3}");

        Console.Write("Nhap day so (cach nhau boi dau cach): ");
        int[] arr;
        while (true)
        {
            try
            {
                arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                break;
            }
            catch
            {
                Console.Write("Gia tri khong hop le! Nhap lai day so: ");
            }
        }
        Console.WriteLine($"So lon nhat trong day: {arr.Max()}");
    }

    // ====== Bài 2: Factorial ======
    static void Ex02()
    {
        Console.WriteLine("\n=== Bài 2: Factorial ===");

        int n = InputInt("Nhap so nguyen khong am: ", 0);
        long fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;

        Console.WriteLine($"{n}! = {fact}");
    }

    // ====== Bài 3: Prime check ======
    static void Ex03()
    {
        Console.WriteLine("\n=== Bài 3: Prime Check ===");

        int n = InputInt("Nhap so nguyen: ");
        Console.WriteLine(IsPrime(n)
            ? $"{n} la so nguyen to."
            : $"{n} KHONG phai so nguyen to.");
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    // ====== Bài 4: Print primes ======
    static void Ex04()
    {
        Console.WriteLine("\n=== Bài 4: Print Primes ===");

        int N = InputInt("Nhap mot so N: ", 2);
        Console.WriteLine($"Cac so nguyen to nho hon {N}:");
        for (int i = 2; i < N; i++)
            if (IsPrime(i)) Console.Write(i + " ");
        Console.WriteLine();

        int count = InputInt("Nhap so luong nguyen to muon in: ", 1);
        Console.WriteLine($"First {count} primes:");
        int found = 0, num = 2;
        while (found < count)
        {
            if (IsPrime(num))
            {
                Console.Write(num + " ");
                found++;
            }
            num++;
        }
        Console.WriteLine();
    }

    // ====== Bài 5: Perfect numbers ======
    static void Ex05()
    {
        Console.WriteLine("\n=== Bài 5: Perfect Numbers ===");

        int n = InputInt("Nhap so can kiem tra: ", 1);
        Console.WriteLine(IsPerfect(n)
            ? $"{n} la so hoan hao."
            : $"{n} KHONG phai so hoan hao.");

        Console.WriteLine("Cac so hoan hao < 1000:");
        for (int i = 2; i < 1000; i++)
            if (IsPerfect(i)) Console.Write(i + " ");
        Console.WriteLine();
    }

    static bool IsPerfect(int n)
    {
        if (n <= 1) return false;
        int sum = 1;
        for (int i = 2; i <= n / 2; i++)
            if (n % i == 0) sum += i;
        return sum == n;
    }

    // ====== Bài 6: Pangram ======
    static void Ex06()
    {
        Console.WriteLine("\n=== Bài 6: Pangram ===");

        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        Console.WriteLine(IsPangram(s)
            ? "Chuoi nay la pangram."
            : "Chuoi nay KHONG phai pangram.");
    }

    static bool IsPangram(string s)
    {
        s = s.ToLower();
        for (char c = 'a'; c <= 'z'; c++)
            if (!s.Contains(c)) return false;
        return true;
    }
}