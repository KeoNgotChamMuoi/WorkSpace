using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Bai1()
        {
            while (true)
            {
                Console.Write("Nhập điểm (0–10): ");
                double score = double.Parse(Console.ReadLine());

                if (score < 5)
                    Console.WriteLine("Trượt");
                else if (score < 7)
                    Console.WriteLine("Trung bình");
                else if (score < 8.5)
                    Console.WriteLine("Khá");
                else
                    Console.WriteLine("Giỏi");

                Console.Write("Nhập tiếp? (Y/N): ");
                string ans = Console.ReadLine();
                if (ans.Equals("N", StringComparison.OrdinalIgnoreCase))
                    break;
            }
        }

        /// ////////////////////////////////////////////////////////////////////

        static void Bai2()
        {
            Console.Write("Nhập số lượng điểm: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập điểm thứ {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            double avg = arr.Average();
            int max = arr.Max();
            int min = arr.Min();

            Console.WriteLine($"Điểm trung bình: {avg:F2}");
            Console.WriteLine($"Điểm cao nhất: {max}");
            Console.WriteLine($"Điểm thấp nhất: {min}");
        }
        /// //////////////////////////////////////////////////////

        static void Bai3()
        {
            List<string> names = new List<string>();
            Console.WriteLine("Nhập tên sinh viên (gõ 'end' để dừng):");

            while (true)
            {
                string name = Console.ReadLine();
                if (name.Equals("end", StringComparison.OrdinalIgnoreCase))
                    break;
                names.Add(name);
            }

            Console.WriteLine("\nDanh sách sinh viên:");
            foreach (var n in names)
                Console.WriteLine(n);

            string longestName = names.OrderByDescending(s => s.Length).FirstOrDefault();
            Console.WriteLine($"Tên dài nhất: {longestName}");
        }

        /// ///////////////////////////////////////
        static void Bai4()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (true)
            {
                Console.Write("Thêm sinh viên mới? (Y/N): ");
                string ans = Console.ReadLine();
                if (ans.Equals("N", StringComparison.OrdinalIgnoreCase))
                    break;

                Console.Write("Nhập mã SV: ");
                string id = Console.ReadLine();
                Console.Write("Nhập tên SV: ");
                string name = Console.ReadLine();

                dict[id] = name;
            }

            Console.Write("Nhập mã SV để tìm: ");
            string searchId = Console.ReadLine();
            if (dict.ContainsKey(searchId))
                Console.WriteLine($"Tên sinh viên: {dict[searchId]}");
            else
                Console.WriteLine("Không tìm thấy");
        }
/// ///////////////////////////////////////
        class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public double Score { get; set; }

            public Student(string id, string name, double score)
            {
                Id = id;
                Name = name;
                Score = score;
            }

            public void Display()
            {
                Console.WriteLine($"ID: {Id}, Name: {Name}, Score: {Score}");
            }
        }

        /// ///////////////////////////

        static void Bai5_6()
        {
            List<Student> students = new List<Student>();

            Console.WriteLine("Nhập ít nhất 3 sinh viên:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Nhập ID: ");
                string id = Console.ReadLine();
                Console.Write("Nhập tên: ");
                string name = Console.ReadLine();
                Console.Write("Nhập điểm: ");
                double score = double.Parse(Console.ReadLine());

                students.Add(new Student(id, name, score));
            }

            Console.WriteLine("\nDanh sách sinh viên:");
            foreach (var s in students)
                s.Display();

            double maxScore = students.Max(s => s.Score);
            Student top = students.First(s => s.Score == maxScore);
            Console.WriteLine($"\nSV có điểm cao nhất:");
            top.Display();

            Console.WriteLine("\nDanh sách SV điểm >= 8:");
            var good = students.Where(s => s.Score >= 8);
            foreach (var s in good)
                s.Display();

            Console.Write("\nNhập tên SV để tìm: ");
            string searchName = Console.ReadLine();
            var found = students.Where(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (found.Any())
            {
                Console.WriteLine("Kết quả tìm:");
                foreach (var s in found)
                    s.Display();
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU CHỌN BÀI TẬP ===");
                Console.WriteLine("1. Bài 1");
                Console.WriteLine("2. Bài 2");
                Console.WriteLine("3. Bài 3");
                Console.WriteLine("4. Bài 4");
                Console.WriteLine("5. Bài 5 + 6");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn: ");
                string choice = Console.ReadLine();
                    switch (choice)
                {
                    case "1":
                        Bai1();
                        break;
                    case "2":
                        Bai2();
                        break;
                    case "3":
                        Bai3();
                        break;
                    case "4":
                        Bai4();
                        break;
                    case "5":
                        Bai5_6();
                        break;
                    case "0":
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, mời nhập lại!");
                        break;
                }
            }
        }   
    }
}
