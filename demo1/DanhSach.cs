using LINQtoCSV;
using System;

namespace demo1
{
    [Serializable]
    public class DanhSach
    {
      

       // [CsvColumn(Name = "MSSV", FieldIndex = 1)]
        public string Mssv { get; set; }

      //  [CsvColumn(Name = "HỌ VÀ TÊN", FieldIndex = 2)]
        public string HoVaTen { get; set; }

      //  [CsvColumn(Name = "Điểm Toán cao cấp", FieldIndex = 3)]
        public double DiemToan { get; set; }


       // [CsvColumn(Name = "Điểm Lí", FieldIndex = 4)]
        public double DiemLi { get; set; }


      //  [CsvColumn(Name = "Điểm Hóa", FieldIndex = 5)]
        public double DiemHoa { get; set; }
      //  [CsvColumn(Name = "Tổng điểm", FieldIndex = 6)]
        public double TongDiem { get; set; }
    }
}
