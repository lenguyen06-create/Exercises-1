using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // 1. Tính trung bình
    static double Average(int[] arr)
    {
        return arr.Average();
    }

    // 2. Kiểm tra mảng có chứa giá trị hay không
    static bool Contains(int[] arr, int value)
    {
        return arr.Contains(value);
    }

    // 3. Tìm chỉ số phần tử
    static int FindIndex(int[] arr, int value)
    {
        return Array.IndexOf(arr, value);
    }

    // 4. Xoá phần tử
    static int[] RemoveElement(int[] arr, int value)
    {
        return arr.Where(x => x != value).ToArray();
    }

    // 5. Tìm max, min
    static (int max, int min) FindMaxMin(int[] arr)
    {
        return (arr.Max(), arr.Min());
    }

    // 6. Đảo ngược mảng
    static int[] ReverseArray(int[] arr)
    {
        int[] reversed = (int[])arr.Clone();
        Array.Reverse(reversed);
        return reversed;
    }

    // 7. Tìm phần tử trùng lặp
    static List<int> FindDuplicates(int[] arr)
    {
        return arr.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(g => g.Key)
                  .ToList();
    }

    // 8. Xoá phần tử trùng lặp
    static int[] RemoveDuplicates(int[] arr)
    {
        return arr.Distinct().ToArray();
    }

    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Linear Search (trong mảng string)
    static int LinearSearch(string[] words, string target)
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Equals(target, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        Random rand = new Random();
        int[] randomArray = new int[10];
        for (int i = 0; i < randomArray.Length; i++)
        {
            randomArray[i] = rand.Next(1, 20); // số từ 1-20
        }

        Console.WriteLine("Mang ban dau: " + string.Join(", ", randomArray));
        Console.WriteLine("Trung binh: " + Average(randomArray));
        Console.WriteLine("Co chua so 5? " + Contains(randomArray, 5));
        Console.WriteLine("Chi so cua so 7: " + FindIndex(randomArray, 7));
        Console.WriteLine("Mang sau khi xoa so 5: " + string.Join(", ", RemoveElement(randomArray, 5)));

        var (max, min) = FindMaxMin(randomArray);
        Console.WriteLine("Max: " + max + ", Min: " + min);

        Console.WriteLine("Mang dao nguoc: " + string.Join(", ", ReverseArray(randomArray)));
        Console.WriteLine("Phan tu trung lap: " + string.Join(", ", FindDuplicates(randomArray)));
        Console.WriteLine("Mang sau khi xoa trung lap: " + string.Join(", ", RemoveDuplicates(randomArray)));

        // --- Bài tập Bubble Sort ---
        Console.WriteLine("\nNhap 10 so nguyen:");
        int[] userArr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Nhap so {i + 1}: ");
            userArr[i] = int.Parse(Console.ReadLine());
        }

        BubbleSort(userArr);
        Console.WriteLine("Mang sau khi sap xep (Bubble Sort): " + string.Join(", ", userArr));

        // --- Bài tập Linear Search ---
        Console.WriteLine("\nNhap 1 cau:");
        string sentence = Console.ReadLine();
        Console.WriteLine("Nhap tu can tim:");
        string word = Console.ReadLine();

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int index = LinearSearch(words, word);

        if (index >= 0)
            Console.WriteLine($"Tu '{word}' xuat hien tai vi tri {index}.");
        else
            Console.WriteLine($"Khong tim thay tu '{word}' trong cau.");
    }
}