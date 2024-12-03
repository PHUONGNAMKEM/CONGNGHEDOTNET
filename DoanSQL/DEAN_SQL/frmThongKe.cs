using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DEAN_SQL
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

            thongkechiphi();
            thongkedoanhthu();
            thongkechiphi_theoThang(DateTime.Now.Month, DateTime.Now.Year);
            thongkesanphambanchay(DateTime.Now.Month);

        }
        private void thongkechiphi()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = dbconect.constr;

            // Truy vấn SQL để lấy doanh thu theo tháng
            string query = @"
                            SELECT 
                                ISNULL(DoanhThu.Nam, ISNULL(Luong.Nam, TienNhap.Nam)) AS Nam,
                                ISNULL(DoanhThu.Thang, ISNULL(Luong.Thang, TienNhap.Thang)) AS Thang,
                                ISNULL(DoanhThu.DoanhThu, 0) AS DoanhThu,
                                ISNULL(Luong.TongLuong, 0) AS TongLuong,
                                ISNULL(TienNhap.TienNhap, 0) AS TienNhap
                            FROM 
                                (
                                    SELECT 
                                        YEAR(HOADON.NGAYLAP) AS Nam, 
                                        MONTH(HOADON.NGAYLAP) AS Thang, 
                                        SUM(CHITIETHOADON.GIABAN * CHITIETHOADON.SOLUONG) AS DoanhThu
                                    FROM 
                                        HOADON
                                    LEFT JOIN 
                                        CHITIETHOADON ON HOADON.MAHD = CHITIETHOADON.MAHD
                                    GROUP BY 
                                        YEAR(HOADON.NGAYLAP), 
                                        MONTH(HOADON.NGAYLAP)
                                ) AS DoanhThu
                            FULL OUTER JOIN 
                                (
                                    SELECT 
                                        YEAR(CHAMCONG.NGAYLAM) AS Nam,
                                        MONTH(CHAMCONG.NGAYLAM) AS Thang,
                                        SUM(DATEDIFF(HOUR, CHAMCONG.THOIGIANVAO, CHAMCONG.THOIGIANRA) * 20000) AS TongLuong
                                    FROM 
                                        CHAMCONG
                                    GROUP BY 
                                        YEAR(CHAMCONG.NGAYLAM),
                                        MONTH(CHAMCONG.NGAYLAM)
                                ) AS Luong
                            ON 
                                DoanhThu.Nam = Luong.Nam AND DoanhThu.Thang = Luong.Thang
                            FULL OUTER JOIN 
                                (
                                    SELECT 
                                        YEAR(PHIEUNHAP.NGAYNHAP) AS Nam, 
                                        MONTH(PHIEUNHAP.NGAYNHAP) AS Thang, 
                                        SUM(CHITIETPN.GIABAN * CHITIETPN.SOLUONG) AS TienNhap
                                    FROM 
                                        PHIEUNHAP
                                    JOIN 
                                        CHITIETPN ON PHIEUNHAP.MAPN = CHITIETPN.MAPN
                                    GROUP BY 
                                        YEAR(PHIEUNHAP.NGAYNHAP), 
                                        MONTH(PHIEUNHAP.NGAYNHAP)
                                ) AS TienNhap
                            ON 
                                ISNULL(DoanhThu.Nam, Luong.Nam) = TienNhap.Nam AND ISNULL(DoanhThu.Thang, Luong.Thang) = TienNhap.Thang
                            ORDER BY 
                                Nam, Thang;

                            ";

            // Tạo một đối tượng DataTable để chứa kết quả truy vấn
            DataTable dataTable = new DataTable();

            // Sử dụng SqlConnection để kết nối với cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và điền kết quả vào DataTable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                connection.Open();
                dataAdapter.Fill(dataTable);
            }

            // Gắn dữ liệu vào Chart
            chart1.DataSource = dataTable;

            // Xóa tất cả các Series cũ để tránh xung đột
            chart1.Series.Clear();

            // Tạo và cấu hình Series TongBan
            Series doanhThuSeries = new Series("Tổng bán")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueMember = "Thang",
                YValueMembers = "DoanhThu",
                Color = System.Drawing.Color.Blue,
                IsValueShownAsLabel = true, // Hiển thị giá trị
                LabelFormat = "C0" // Hiển thị dưới dạng tiền tệ
            };
            chart1.Series.Add(doanhThuSeries);

            // Tạo và cấu hình Series TongLuong
            Series tongLuongSeries = new Series("Tổng lương")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueMember = "Thang",
                YValueMembers = "TongLuong",
                Color = System.Drawing.Color.Orange,
                IsValueShownAsLabel = true, // Hiển thị giá trị
                LabelFormat = "C0" // Hiển thị dưới dạng tiền tệ
            };
            chart1.Series.Add(tongLuongSeries);

            // Tạo và cấu hình Series TienNhap
            Series tienNhapSeries = new Series("Tiền nhập")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueMember = "Thang",
                YValueMembers = "TienNhap",
                Color = System.Drawing.Color.Red,
                IsValueShownAsLabel = true, // Hiển thị giá trị
                LabelFormat = "C0" // Hiển thị dưới dạng tiền tệ
            };
            chart1.Series.Add(tienNhapSeries);

            // Thêm cột "DoanhThuThuc" vào DataTable
            dataTable.Columns.Add("DoanhThuThuc", typeof(decimal));
            foreach (DataRow row in dataTable.Rows)
            {
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                decimal tongLuong = Convert.ToDecimal(row["TongLuong"]);
                decimal tienNhap = Convert.ToDecimal(row["TienNhap"]);
                row["DoanhThuThuc"] = doanhThu - tongLuong - tienNhap;
            }

            // Tạo và cấu hình Series DoanhThuThuc
            Series doanhThuThucSeries = new Series("Doanh thu thực")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueMember = "Thang",
                YValueMembers = "DoanhThuThuc",
                Color = System.Drawing.Color.LawnGreen, // Màu xanh chuối
                IsValueShownAsLabel = true, // Hiển thị giá trị
                LabelFormat = "C0" // Hiển thị dưới dạng tiền tệ
            };
            chart1.Series.Add(doanhThuThucSeries);


            // Làm mới biểu đồ
            chart1.DataBind();

            // Hiển thị giá trị trên đỉnh mỗi cột của Series "DoanhThu"
            chart1.Series["Tổng bán"].IsValueShownAsLabel = true;
            // Định dạng trục X
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1; // Hiển thị tất cả các tháng
            chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(
                    thang - 0.5, thang + 0.5, $"Tháng {thang}");
            }

            // Hiển thị giá trị trên đỉnh mỗi cột của Series "TongLuong"
            chart1.Series["Tổng lương"].IsValueShownAsLabel = true;
            // Định dạng trục Y
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:###,###,###} VNĐ"; // Hiển thị VNĐ
            chart1.ChartAreas[0].AxisY.Title = "Đơn vị (VNĐ)"; // Tiêu đề trục Y
            chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);


            // Định dạng hiển thị giá trị trên cột cho từng Series
            foreach (var series in chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    // Kiểm tra nếu giá trị là 0, hiển thị "0 VNĐ"
                    if (point.YValues[0] == 0)
                    {
                        point.Label = "0";
                    }
                    else
                    {
                        point.Label = string.Format("{0:###,###,###}", point.YValues[0]);
                    }

                    point.LabelForeColor = System.Drawing.Color.Black;
                    point.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                    point.LabelAngle = 0;
                    point.IsValueShownAsLabel = true;
                }
            }

            // Hiển thị giá trị trên đỉnh mỗi cột của Series "TienNhap"
            chart1.Series["Tiền nhập"].IsValueShownAsLabel = true;
            foreach (var point in chart1.Series["Tiền nhập"].Points)
            {
                if (point.YValues[0] == 0)
                {
                    point.Label = "0";
                }
                else
                {
                    point.Label = string.Format("{0:###,###,###}", point.YValues[0]);
                }
                point.LabelForeColor = System.Drawing.Color.Black;
                point.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            }

            // Hiển thị giá trị trên đỉnh mỗi cột của Series "DoanhThuThuc"
            foreach (var point in chart1.Series["Doanh thu thực"].Points)
            {
                if (point.YValues[0] == 0)
                {
                    point.Label = "0";
                }
                else
                {
                    point.Label = string.Format("{0:###,###,###}", point.YValues[0]);
                }
                point.LabelForeColor = System.Drawing.Color.Black;
                point.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            }
        }
        private void thongkechiphi_theoThang(int month, int year)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = dbconect.constr;

            // Truy vấn SQL để lấy dữ liệu của tháng và năm cụ thể
            string query = @"
                            SELECT 
                                ISNULL(Luong.TongLuong, 0) AS TongLuong,
                                ISNULL(TienNhap.TienNhap, 0) AS TienNhap,
                                ISNULL(DoanhThu.DoanhThu, 0) AS DoanhThu
                            FROM 
                                (
                                    SELECT 
                                        SUM(DATEDIFF(HOUR, CHAMCONG.THOIGIANVAO, CHAMCONG.THOIGIANRA) * 20000) AS TongLuong
                                    FROM 
                                        CHAMCONG
                                    WHERE 
                                        MONTH(CHAMCONG.NGAYLAM) = @Month AND YEAR(CHAMCONG.NGAYLAM) = @Year
                                ) AS Luong,
                                (
                                    SELECT 
                                        SUM(CHITIETPN.GIABAN * CHITIETPN.SOLUONG) AS TienNhap
                                    FROM 
                                        PHIEUNHAP
                                    JOIN 
                                        CHITIETPN ON PHIEUNHAP.MAPN = CHITIETPN.MAPN
                                    WHERE 
                                        MONTH(PHIEUNHAP.NGAYNHAP) = @Month AND YEAR(PHIEUNHAP.NGAYNHAP) = @Year
                                ) AS TienNhap,
                                (
                                    SELECT 
                                        SUM(CHITIETHOADON.GIABAN * CHITIETHOADON.SOLUONG) AS DoanhThu
                                    FROM 
                                        HOADON
                                    JOIN 
                                        CHITIETHOADON ON HOADON.MAHD = CHITIETHOADON.MAHD
                                    WHERE 
                                        MONTH(HOADON.NGAYLAP) = @Month AND YEAR(HOADON.NGAYLAP) = @Year
                                ) AS DoanhThu
                            ";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                }
            }

            DataRow row = dataTable.Rows[0];
            decimal tongLuong = Convert.ToDecimal(row["TongLuong"]);
            decimal tienNhap = Convert.ToDecimal(row["TienNhap"]);
            decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
            // Kiểm tra dữ liệu có tồn tại
            if (dataTable.Rows.Count > 0)
            {
                // Kiểm tra nếu tất cả giá trị là 0
                if (tongLuong == 0 && tienNhap == 0 && doanhThu == 0)
                {
                    //MessageBox.Show("Không có dữ liệu cho tháng " + month + " năm " + year, "Thông báo");
                    return;
                }
            }
            else
            {
                //MessageBox.Show("Không có dữ liệu cho tháng " + month + " năm " + year, "Thông báo");
                return;
            }

            // Tính tổng chi phí
            decimal tongChiPhi = tongLuong + tienNhap + doanhThu;

            // Gắn dữ liệu vào Chart
            chart4.Series.Clear();
            chart4.DataSource = null;

            Series pieSeries = new Series
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "P1" // Hiển thị dưới dạng phần trăm
            };

            // Thêm dữ liệu vào Series
            pieSeries.Points.AddXY("Tổng lương", tongLuong / tongChiPhi);
            pieSeries.Points.AddXY("Tiền nhập", tienNhap / tongChiPhi);
            pieSeries.Points.AddXY("Tổng bán", doanhThu / tongChiPhi);

            // Gắn nhãn cho từng phần
            foreach (var point in pieSeries.Points)
            {
                point.Label = $"{point.AxisLabel}: {point.YValues[0]:P1}";
                point.LabelForeColor = System.Drawing.Color.Black;
            }

            chart4.Series.Add(pieSeries);

            // Tùy chỉnh tiêu đề và các thuộc tính khác của biểu đồ
            chart4.Titles.Clear();
            chart4.Titles.Add($"Chi phí tháng {month} năm {year}");
            chart4.Titles[0].Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
            chart4.Legends.Clear();
            chart4.Legends.Add(new Legend
            {
                Title = "Loại chi phí",
                TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold)
            });
        }
        public void thongkedoanhthu()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = dbconect.constr;

            // Truy vấn SQL để lấy doanh thu theo tháng
            string query = @"
                            SELECT 
                                ISNULL(DoanhThu.Nam, ISNULL(Luong.Nam, TienNhap.Nam)) AS Nam,
                                ISNULL(DoanhThu.Thang, ISNULL(Luong.Thang, TienNhap.Thang)) AS Thang,
                                ISNULL(DoanhThu.DoanhThu, 0) AS DoanhThu,
                                ISNULL(Luong.TongLuong, 0) AS TongLuong,
                                ISNULL(TienNhap.TienNhap, 0) AS TienNhap
                            FROM 
                                (
                                    SELECT 
                                        YEAR(HOADON.NGAYLAP) AS Nam, 
                                        MONTH(HOADON.NGAYLAP) AS Thang, 
                                        SUM(CHITIETHOADON.GIABAN * CHITIETHOADON.SOLUONG) AS DoanhThu
                                    FROM 
                                        HOADON
                                    LEFT JOIN 
                                        CHITIETHOADON ON HOADON.MAHD = CHITIETHOADON.MAHD
                                    GROUP BY 
                                        YEAR(HOADON.NGAYLAP), 
                                        MONTH(HOADON.NGAYLAP)
                                ) AS DoanhThu
                            FULL OUTER JOIN 
                                (
                                    SELECT 
                                        YEAR(CHAMCONG.NGAYLAM) AS Nam,
                                        MONTH(CHAMCONG.NGAYLAM) AS Thang,
                                        SUM(DATEDIFF(HOUR, CHAMCONG.THOIGIANVAO, CHAMCONG.THOIGIANRA) * 20000) AS TongLuong
                                    FROM 
                                        CHAMCONG
                                    GROUP BY 
                                        YEAR(CHAMCONG.NGAYLAM),
                                        MONTH(CHAMCONG.NGAYLAM)
                                ) AS Luong
                            ON 
                                DoanhThu.Nam = Luong.Nam AND DoanhThu.Thang = Luong.Thang
                            FULL OUTER JOIN 
                                (
                                    SELECT 
                                        YEAR(PHIEUNHAP.NGAYNHAP) AS Nam, 
                                        MONTH(PHIEUNHAP.NGAYNHAP) AS Thang, 
                                        SUM(CHITIETPN.GIABAN * CHITIETPN.SOLUONG) AS TienNhap
                                    FROM 
                                        PHIEUNHAP
                                    JOIN 
                                        CHITIETPN ON PHIEUNHAP.MAPN = CHITIETPN.MAPN
                                    GROUP BY 
                                        YEAR(PHIEUNHAP.NGAYNHAP), 
                                        MONTH(PHIEUNHAP.NGAYNHAP)
                                ) AS TienNhap
                            ON 
                                ISNULL(DoanhThu.Nam, Luong.Nam) = TienNhap.Nam AND ISNULL(DoanhThu.Thang, Luong.Thang) = TienNhap.Thang
                            ORDER BY 
                                Nam, Thang;

                            ";

            // Tạo một đối tượng DataTable để chứa kết quả truy vấn
            DataTable dataTable = new DataTable();

            // Sử dụng SqlConnection để kết nối với cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và điền kết quả vào DataTable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                connection.Open();
                dataAdapter.Fill(dataTable);
            }

            // Gắn dữ liệu vào Chart
            chart3.DataSource = dataTable;

            // Xóa tất cả các Series cũ để tránh xung đột
            chart3.Series.Clear();

            // Thêm cột "DoanhThuThuc" vào DataTable
            dataTable.Columns.Add("DoanhThuThuc", typeof(decimal));
            foreach (DataRow row in dataTable.Rows)
            {
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                decimal tongLuong = Convert.ToDecimal(row["TongLuong"]);
                decimal tienNhap = Convert.ToDecimal(row["TienNhap"]);
                row["DoanhThuThuc"] = doanhThu - tongLuong - tienNhap;
            }

            // Chỉ hiển thị biểu đồ DoanhThuThuc dưới dạng đường
            Series doanhThuThucSeries = new Series("Doanh thu thực")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line, // Biểu đồ đường
                XValueMember = "Thang",
                YValueMembers = "DoanhThuThuc",
                Color = System.Drawing.Color.LawnGreen, // Màu xanh chuối
                BorderWidth = 3, // Độ dày của đường
                IsValueShownAsLabel = true, // Hiển thị giá trị trên điểm
                LabelFormat = "", // Hiển thị dưới dạng tiền tệ
                MarkerStyle = MarkerStyle.Circle, // Kiểu marker trên các điểm
                MarkerSize = 10, // Kích thước marker
                MarkerColor = System.Drawing.Color.DarkGreen // Màu marker
            };
            chart3.Series.Add(doanhThuThucSeries);


            // Ẩn các Series khác
            foreach (var series in chart3.Series)
            {
                if (series.Name != "Doanh thu thực")
                {
                    series.Enabled = false; // Ẩn Series
                }
            }


            // Làm mới biểu đồ
            chart3.DataBind();

            // Định dạng lại trục X
            chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 1; // Hiển thị tất cả các tháng
            chart3.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            chart3.ChartAreas[0].AxisX.CustomLabels.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                chart3.ChartAreas[0].AxisX.CustomLabels.Add(
                    thang - 0.5, thang + 0.5, $"Tháng {thang}");
            }

            // Định dạng trục Y
            chart3.ChartAreas[0].AxisY.LabelStyle.Format = "{0:###,###,###} VNĐ"; // Hiển thị VNĐ
            chart3.ChartAreas[0].AxisY.Title = "Đơn vị (VNĐ)"; // Tiêu đề trục Y
            chart3.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            // Làm mới biểu đồ
            chart3.DataBind();
        }
        private void thongkesanphambanchay(int thang)
        {
            string connectionString = dbconect.constr;
            string query = "SELECT HH.TENHANG, SUM(CTHD.SOLUONG) AS TongSoLuong " +
                           "FROM HOADON HD " +
                           "JOIN CHITIETHOADON CTHD ON HD.MAHD = CTHD.MAHD " +
                           "JOIN HANGHOA HH ON CTHD.MAHG = HH.MAHG " +
                           "WHERE MONTH(HD.NGAYLAP) = @Thang " +
                           "GROUP BY HH.TENHANG " +
                           "ORDER BY TongSoLuong DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Thang", thang);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Cấu hình chart
                chart2.Series.Clear();
                chart2.Titles.Clear(); // Xóa các tiêu đề cũ
                chart2.ChartAreas.Clear(); // Xóa các vùng biểu đồ cũ
                chart2.Legends.Clear(); // Xóa các chú thích cũ

                ChartArea chartArea = new ChartArea
                {
                    Name = "ChartArea",
                    AxisX =
                {
                Title = "Tên sản phẩm",
                TitleFont = new Font("Arial", 12, FontStyle.Bold),
                IntervalAutoMode = IntervalAutoMode.VariableCount
                },
                    AxisY =
                {
                Title = "Số lượng sản phẩm",
                TitleFont = new Font("Arial", 12, FontStyle.Bold),
                LabelStyle = { Font = new Font("Arial", 10) }
                }
                };
                chart2.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Doanh số sản phẩm",
                    ChartType = SeriesChartType.Bar, // Biểu đồ cột nằm ngang
                    ChartArea = "ChartArea",
                    IsValueShownAsLabel = true, // Hiển thị giá trị trên cột
                    LabelFormat = "#,##0", // Định dạng số lượng
                };
                chart2.Series.Add(series);

                while (reader.Read())
                {
                    string tenHang = reader.GetString(0);
                    int tongSoLuong = reader.GetInt32(1);

                    series.Points.AddXY(tenHang, tongSoLuong);
                }
            }

            // Thêm tiêu đề cho biểu đồ
            Title chartTitle = new Title
            {
                Text = $"Sản phẩm bán chạy nhất tháng {thang}",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Alignment = ContentAlignment.MiddleCenter
            };
            chart2.Titles.Add(chartTitle);

            // Tùy chỉnh chú thích
            Legend legend = new Legend
            {
                Name = "Legend",
                Docking = Docking.Bottom,
                Font = new Font("Arial", 10),
                IsTextAutoFit = true
            };
            chart2.Legends.Add(legend);
        }

        private void btnapdung_Click(object sender, EventArgs e)
        {
            thongkesanphambanchay(int.Parse(datesp.Value.Month.ToString()));
        }

        private void btnapdungthangnam_Click(object sender, EventArgs e)
        {
            thongkechiphi_theoThang(int.Parse(datechiphi.Value.Month.ToString()), int.Parse(datechiphi.Value.Year.ToString()));
        }
    }
}
