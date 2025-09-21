using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU CHINH ===");
            Console.WriteLine("1. Ex01 - Jagged Array");
            Console.WriteLine("2. Ex02 - Company X");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon bai: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": Ex01(); break;
                case "2": Ex02(); break;
                case "0": return;
                default: Console.WriteLine("Lua chon khong hop le."); break;
            }
        }
    }

    static void Ex01()
    {
        Console.WriteLine("\n=== Ex01: Jagged Array ===");

        // 1. Tạo jagged array với giá trị cho trước
        int[][] arr1 = new int[4][];
        arr1[0] = new int[] { 1, 1, 1, 1, 1 };
        arr1[1] = new int[] { 2, 2 };
        arr1[2] = new int[] { 3, 3, 3, 3 };
        arr1[3] = new int[] { 4, 4 };

        Console.WriteLine("Mang arr1:");
        PrintJagged(arr1);

        // 2. Tạo jagged array từ input
        Console.Write("Nhap so dong cua mang: ");
        int rows = int.Parse(Console.ReadLine());
        int[][] arr2 = new int[rows][];

        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Nhap so phan tu cua dong {i}: ");
            int cols = int.Parse(Console.ReadLine());
            arr2[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                arr2[i][j] = rand.Next(1, 50); // random 1–49
            }
        }

        Console.WriteLine("\nMang arr2:");
        PrintJagged(arr2);

        // Task 1: Max per row + max whole
        Console.WriteLine("\nMax moi dong:");
        int maxAll = int.MinValue;
        for (int i = 0; i < arr2.Length; i++)
        {
            int maxRow = arr2[i].Max();
            Console.WriteLine($"Dong {i}: max = {maxRow}");
            if (maxRow > maxAll) maxAll = maxRow;
        }
        Console.WriteLine($"So lon nhat trong toan mang: {maxAll}");

        // Task 2: Sort each row
        Console.WriteLine("\nMang sau khi sap xep tung dong:");
        for (int i = 0; i < arr2.Length; i++)
        {
            Array.Sort(arr2[i]);
        }
        PrintJagged(arr2);

        // Task 3: Print primes
        Console.WriteLine("\nCac so nguyen to trong mang:");
        for (int i = 0; i < arr2.Length; i++)
        {
            for (int j = 0; j < arr2[i].Length; j++)
            {
                if (IsPrime(arr2[i][j])) Console.Write(arr2[i][j] + " ");
            }
        }
        Console.WriteLine();

        // Task 4: Search positions
        Console.Write("\nNhap so can tim: ");
        int target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Vi tri cua {target}:");
        bool found = false;
        for (int i = 0; i < arr2.Length; i++)
        {
            for (int j = 0; j < arr2[i].Length; j++)
            {
                if (arr2[i][j] == target)
                {
                    Console.WriteLine($"({i},{j})");
                    found = true;
                }
            }
        }
        if (!found) Console.WriteLine("Khong tim thay.");
    }

    static void PrintJagged(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Row " + i + ": " + string.Join(" ", arr[i]));
        }
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

    // ===================== EX02 =====================
    class Member
    {
        public int ID;
        public string Name;
        public int Tasks;

        public Member(int id, string name, int tasks)
        {
            ID = id; Name = name; Tasks = tasks;
        }

        public override string ToString()
        {
            return $"ID={ID}, Name={Name}, Tasks={Tasks}";
        }
    }

    static void Ex02()
    {
        Console.WriteLine("\n=== Ex02: Company X ===");

        // 3 nhóm với số lượng khác nhau
        Member[][] groups = new Member[3][];
        groups[0] = new Member[5];
        groups[1] = new Member[3];
        groups[2] = new Member[6];

        while (true)
        {
            Console.WriteLine("\n--- MENU Company ---");
            Console.WriteLine("1. Khoi tao du lieu");
            Console.WriteLine("2. In tat ca thanh vien");
            Console.WriteLine("3. Tim thanh vien theo ID");
            Console.WriteLine("4. Tim nguoi lam nhieu tasks nhat");
            Console.WriteLine("0. Thoat Ex02");
            Console.Write("Chon: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": InitMembers(groups); break;
                case "2": PrintAll(groups); break;
                case "3": FindByID(groups); break;
                case "4": FindMostTasks(groups); break;
                case "0": return;
                default: Console.WriteLine("Lua chon khong hop le."); break;
            }
        }
    }

    static void InitMembers(Member[][] groups)
    {
        Console.WriteLine("\nNhap du lieu thanh vien:");

        for (int g = 0; g < groups.Length; g++)
        {
            for (int i = 0; i < groups[g].Length; i++)
            {
                Console.Write($"Group {g + 1}, Member {i + 1} - ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Tasks: ");
                int tasks = int.Parse(Console.ReadLine());

                groups[g][i] = new Member(id, name, tasks);
            }
        }
    }

    static void PrintAll(Member[][] groups)
    {
        Console.WriteLine("\nDanh sach tat ca thanh vien:");
        for (int g = 0; g < groups.Length; g++)
        {
            Console.WriteLine($"Group {g + 1}:");
            for (int i = 0; i < groups[g].Length; i++)
            {
                if (groups[g][i] != null)
                    Console.WriteLine("  " + groups[g][i]);
            }
        }
    }

    static void FindByID(Member[][] groups)
    {
        Console.Write("Nhap ID can tim: ");
        int id = int.Parse(Console.ReadLine());

        foreach (var group in groups)
        {
            foreach (var m in group)
            {
                if (m != null && m.ID == id)
                {
                    Console.WriteLine("Tim thay: " + m);
                    return;
                }
            }
        }
        Console.WriteLine("Khong tim thay ID nay.");
    }

    static void FindMostTasks(Member[][] groups)
    {
        Member best = null;
        foreach (var group in groups)
        {
            foreach (var m in group)
            {
                if (m != null)
                {
                    if (best == null || m.Tasks > best.Tasks)
                        best = m;
                }
            }
        }
        if (best != null)
            Console.WriteLine("Thanh vien lam nhieu tasks nhat: " + best);
    }
}