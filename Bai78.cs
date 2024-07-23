using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("BÀI TẬP 78");
        Console.WriteLine("------------------------");
        int choice;
        do
        {
            Console.Write("\nNhập các phần mà bạn muốn tôi giải quyết.\n");
            Console.Write("a. Viết chương trình C# console.\n");
            Console.Write("b. Viết chương trình C# tạo hàm static gọi trong chế độ không đồng bộ với mã lệnh.\n");
            Console.Write("c. So sánh hàm thread và hàm gọi trong chế độ không đồng bộ async/await trong C#.\n");
            Console.Write("\nNhập lựa chọn của bạn: ");
            choice = char.Parse(Console.ReadLine());
            switch (choice)
            {
                case 'a':
                    bai78a();
                    break;
                case 'b':
                    bai78b();
                    break;
                case 'c':
                    bai78c();
                    break;
                case 'x':
                    Console.WriteLine("Exited......");
                    break;
                default:
                    Console.WriteLine("Nhập sai lựa chọn!");
                    break;
            }
        } while (choice != 'x');
    }
    static void bai78a()
    {
        var thread = new Thread(() =>
        {
            Console.WriteLine("Thread bắt đầu.");
            Thread.Sleep(1000);
            Console.WriteLine("Thread kết thúc.");
        });

        thread.Start();
        thread.Join(); // Đợi thread hoàn thành

        Console.WriteLine("Chương trình kết thúc.");
    }

    static void bai78b() 
    {
        static async Task Main(string[] args)
        {
            await async1();
            Console.WriteLine("Chương trình kết thúc.");
        }
        async1();
        Thread.Sleep(2000);
    }
    public static async Task async1()
    {
        Console.WriteLine("Async bắt đầu.");
        await Task.Delay(1000);
        Console.WriteLine("Async kết thúc.");
    }

    static void bai78c() 
    {
        Console.WriteLine("Cách hoạt động:\r\nHàm thread: Yêu cầu quản lý thread một cách trực tiếp, bao gồm tạo, khởi chạy và kết thúc thread.\r\nAsync/await: Không cần quản lý thread trực tiếp. Sử dụng từ khóa async và await để đánh dấu các phương thức và đợi cho các tác vụ không đồng bộ hoàn thành.\r\nĐồng bộ hóa:\r\nHàm thread: Sử dụng thread.Join() để đồng bộ hóa các thread.\r\nAsync/await: Không cần sử dụng thread.Join(), vì chương trình sẽ tự động đợi cho các tác vụ không đồng bộ hoàn thành.\r\nKhả năng mở rộng:\r\nHàm thread: Tạo và quản lý nhiều thread có thể trở nên phức tạp khi số lượng thread tăng lên.\r\nAsync/await: Dễ dàng mở rộng khi cần thêm các tác vụ không đồng bộ, vì việc quản lý thread được ẩn đi khỏi người lập trình.\r\nHiệu suất:\r\nHàm thread: Yêu cầu nhiều overhead để tạo và quản lý thread, có thể ảnh hưởng đến hiệu suất.\r\nAsync/await: Hiệu suất tốt hơn, vì việc quản lý thread được ẩn đi và framework .NET sẽ tối ưu hóa việc sử dụng thread.\r\nĐộ rõ ràng và dễ hiểu:\r\nHàm thread: Yêu cầu hiểu biết sâu về lập trình song song và quản lý thread.\r\nAsync/await: Dễ hiểu hơn, vì người lập trình không cần phải quan tâm đến việc quản lý thread.\r\nSử dụng:\r\nHàm thread: Thích hợp cho các tác vụ yêu cầu kiểm soát trực tiếp thread, như xử lý I/O, tính toán phức tạp.\r\nAsync/await: Thích hợp cho các tác vụ không đồng bộ như gọi API, đọc/ghi file, truy vấn database, v.v.\r\nTóm lại, async/await cung cấp một cách tiếp cận đơn giản hơn, dễ hiểu hơn và hiệu suất tốt hơn so với quản lý thread trực tiếp. Tuy nhiên, trong một số trường hợp cụ thể, sử dụng thread trực tiếp vẫn có thể cần thiết.");
    }
}
