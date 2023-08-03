using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace demo1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            // Doc Du lieu tu file có sẵn 

           // ReadCsvFile();

            // Tạo file csv mới và thêm Dữ liệu vào file
            // WriteCsvFile();

            // them Dữ lieu vào file Dã có

            // AddDataToCsvFile();

            //OneSV();

            //writeCSV();

            Console.ReadKey();



        }

        // Tạo ra một file danh sách mới ghi lại tất cả sinh viên của danh sách cũ kể cả đtb

        private static void writeCSV()
        {
            var csvFileDecription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };
            var csvContext = new CsvContext();
            var danhsachsv = csvContext.Read<DanhSach>("DanhSachSV.csv", csvFileDecription);

            var danhsach1 = new List<DanhSach>();
            foreach (var DanhSachSV in danhsachsv)
            {
                double TongDiem1 = DanhSachSV.DiemToan + DanhSachSV.DiemLi + DanhSachSV.DiemHoa;
                danhsach1.Add(new DanhSach { Mssv = DanhSachSV.Mssv, HoVaTen = DanhSachSV.HoVaTen, DiemToan = DanhSachSV.DiemToan, DiemLi = DanhSachSV.DiemLi, DiemHoa = DanhSachSV.DiemHoa, TongDiem = TongDiem1 });
            }

            csvContext.Write(danhsach1, "DanhSachSV03.csv", csvFileDecription);

            Console.WriteLine("Tạo file csv thành công!");
            // tạo ra một file csv mới thêm dữ liệu mới vào file csv
        }

        private static void WriteCsvFile()
        {
            Console.Write("Nhập vào mã số sinh viên : ");
            string Mssv1 = Console.ReadLine();
            Console.Write("Nhập vào họ và tên sinh viên : ");
            string HoVaTen1 = Console.ReadLine();
            Console.Write("Nhập vào điểm toán của sinh viên : ");
            double DiemToan1 = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào điểm lí của sinh viên : ");
            double DiemLi1 = double.Parse(Console.ReadLine());
            Console.Write("Nhập vào điểm hóa của sinh viên : ");
            double DiemHoa1 = double.Parse(Console.ReadLine());

            double TongDiem1 = DiemToan1 + DiemLi1 + DiemHoa1;


            var danhsach1 = new List<DanhSach>
            {
                new DanhSach{ Mssv = Mssv1  , HoVaTen = HoVaTen1 , DiemToan = DiemToan1 , DiemLi = DiemLi1 , DiemHoa = DiemHoa1,TongDiem =TongDiem1 },

            };
            var csvFileDecription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',

            };
            var csvContext = new CsvContext();
            csvContext.Write(danhsach1, "DanhSachSV01.csv", csvFileDecription);

            Console.WriteLine("Tạo file csv thành công !!!!!");
        }
        // Đọc dữ liệu từ file csv có sẵn ra màn hình console và tính dtb của từng sv
        private static void ReadCsvFile()
        {
            var csvFileDecription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };
            var csvContext = new CsvContext();
            var danhsachsv = csvContext.Read<DanhSach>("DanhSachSV.csv", csvFileDecription);

            Console.WriteLine($"MSSV \t\t\t HO VA TEN \t\t DIEM TOAN \t\t DIEM LI \t DIEM HOA ");
            foreach (var DanhSachSV in danhsachsv)
            {
                Console.Write($"{DanhSachSV.Mssv} \t\t| {DanhSachSV.HoVaTen} \t| {DanhSachSV.DiemToan} \t\t| {DanhSachSV.DiemLi} \t\t| {DanhSachSV.DiemHoa} \t\t| ");
                // Console.WriteLine();
                Console.WriteLine(DiemTrungBinh(DanhSachSV.DiemToan, DanhSachSV.DiemLi, DanhSachSV.DiemHoa));
            }
        }



        // Thêm 1 sinh viên vào cuối danh sách đã có 
        private static void AddDataToCsvFile()
        {
            string filePath = @"D:\file csv\demo1\bin\Debug\DanhSachSV.csv";

            if (File.Exists(filePath))
            {
                Console.Write("Nhập vào mã số sinh viên : ");
                string mssv1 = Console.ReadLine();
                Console.Write("Nhập vào họ và tên sinh viên : ");
                string hovaten1 = Console.ReadLine();
                Console.Write("Nhập vào điểm toán của sinh viên : ");
                double diemtoan1 = double.Parse(Console.ReadLine());
                Console.Write("Nhập vào điểm lí của sinh viên : ");
                double diemli1 = double.Parse(Console.ReadLine());
                Console.Write("Nhập vào điểm hóa của sinh viên : ");
                double diemhoa1 = double.Parse(Console.ReadLine());

                using (StreamWriter file = new StreamWriter("DanhSachSV01.csv", true))
                {
                    // Viết dữ liệu mới vào file
                    string newData = mssv1 + "," + hovaten1 + "," + diemtoan1 + "," + diemli1 + "," + diemhoa1;
                    file.WriteLine(newData);
                }
                Console.WriteLine("Thêm dữ liệu vào file csv thành công !!!!");
            }
            else
            {
                // file chưa tồn tại
                Console.WriteLine("File csv không tồn tại !");
            }

        }
        private static double DiemTrungBinh(double a, double b, double c)
        {
            return (a + b + c) / 3;

        }

        //từ MSSV của sv đã biết có thể xem được thông tin của sv có trong ds bao gồm DTB
        private static void OneSV()
        {
            Console.Write("Nhập vào mã số sinh viên : ");
            string mssv1 = Console.ReadLine();
            var csvFileDecription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };
            var csvContext = new CsvContext();
            var danhsachsv = csvContext.Read<DanhSach>("DanhSachSV.csv", csvFileDecription);

            bool flag = false;
            foreach (var DanhSachSV in danhsachsv)
            {
                if (DanhSachSV.Mssv.Equals(mssv1))
                {
                    flag = true;
                    Console.WriteLine($"MSSV \t\t\t HO VA TEN \t\t DIEM TOAN \t\t DIEM LI \t DIEM HOA dIEM TRUNG BINH ");
                    Console.Write($"{DanhSachSV.Mssv} \t\t| {DanhSachSV.HoVaTen} \t| {DanhSachSV.DiemToan} \t\t| {DanhSachSV.DiemLi} \t\t| {DanhSachSV.DiemHoa} \t\t| ");
                    Console.WriteLine(DiemTrungBinh(DanhSachSV.DiemToan, DanhSachSV.DiemLi, DanhSachSV.DiemHoa));
                }
            }
            if (!flag) { Console.WriteLine("Không tìm thấy sinh viên có mã số vừa nhập trong danh sách"); }
        }

    }
}
