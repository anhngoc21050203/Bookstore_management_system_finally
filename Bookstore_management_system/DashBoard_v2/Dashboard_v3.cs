using Bookstore_management_system.Image_processing;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookstore_management_system.DashBoard_v2
{
    public partial class Dashboard_v3 : Form
    {
        private Dictionary<string, int> customerCategoryCounts;
        Dictionary<string, int> totalProductBestSeller;
        public Dashboard_v3()
        {
            InitializeComponent();
            guna2TabControl1.SelectedTab = tabPage1;
            customerCategoryCounts = new Dictionary<string, int>
            {
                { "Khách quay lại", 0 },
                { "Khách hàng thân thiết", 0 },
                { "Khách hàng mới", 0 },
                { "Khách không quay lại", 0 }
            };
            totalProductBestSeller = new Dictionary<string, int>();
        }

        private void Dashboard_v3_Load(object sender, EventArgs e)
        {
            LoadDataForTab1();
            guna2DateTimePicker2.Value = DateTime.Now;
            guna2DateTimePicker3_customer.Value = DateTime.Now;
            guna2DateTimePicker_from.Value = DateTime.Now;
            guna2DateTimePicker3_customer.Value = DateTime.Now;

        }

        private void LoadDataForTab1()
        {
            using (var context = new BookShopEntities3())
            {
                // Thực hiện truy vấn LINQ để lấy danh sách đơn hàng từ cơ sở dữ liệu
                var orders = context.orderps.ToList();
                decimal? totalAmount = context.orderps.Sum(o => o.totalamount);
                decimal? totalCpital = context.products.Sum(p => p.unitprice * p.quantityinstock);

                // Tính tổng số đơn hàng
                int totalOrders = orders.Count;

                label6_totalorder.Text = totalOrders.ToString();
                label7_totalamount.Text = totalAmount.ToString();
                decimal? totalProfit = totalAmount * 0.2m;
                label8_profit.Text = totalProfit.ToString();
                label13_capital.Text = totalCpital.ToString();

                // Tạo một Dictionary để lưu trữ số đơn hàng bán được trong mỗi tháng
                Dictionary<int, int> monthlyOrderCounts = new Dictionary<int, int>();

                // Lặp qua từng đơn hàng và tính tổng số đơn hàng bán được trong mỗi tháng
                foreach (var order in orders)
                {
                    // Kiểm tra xem orderdate có giá trị không
                    if (order.orderdate.HasValue)
                    {
                        // Lấy tháng của orderdate
                        int month = order.orderdate.Value.Month;

                        // Kiểm tra xem Dictionary đã có tháng này chưa, nếu chưa thì thêm vào và gán giá trị ban đầu là 1, nếu có thì tăng giá trị lên 1
                        if (!monthlyOrderCounts.ContainsKey(month))
                        {
                            monthlyOrderCounts[month] = 1;
                        }
                        else
                        {
                            monthlyOrderCounts[month]++;
                        }
                    }
                }
                // Tạo dữ liệu để hiển thị trên GunaChart
                var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                dataset.PointRadius = 10;
                dataset.PointStyle = PointStyle.Circle;
                dataset.Label = "Đơn hàng theo năm";
                dataset.FillColor = Color.DodgerBlue;
                dataset.BorderColor = Color.DodgerBlue;

                // Lặp qua từng tháng để thêm dữ liệu vào dataset
                for (int i = 1; i <= 12; i++)
                {
                    // Kiểm tra xem có dữ liệu cho tháng này không, nếu không có thì gán giá trị là 0
                    int orderCount = monthlyOrderCounts.ContainsKey(i) ? monthlyOrderCounts[i] : 0;

                    // Thêm dữ liệu vào dataset
                    dataset.DataPoints.Add(i.ToString(), orderCount);
                }

                // Thêm dataset vào GunaChart và cập nhật
                gunaChart1.Datasets.Add(dataset);
                gunaChart1.Update();

            }

        }

        private void guna2Button5_year_Click(object sender, EventArgs e)
        {
            gunaChart1.Datasets.Clear();
            LoadDataForTab1();

        }

        private void guna2Button4_month_Click(object sender, EventArgs e)
        {
            gunaChart1.Datasets.Clear();

            using (var context = new BookShopEntities3())
            {
                int monthCurrent = DateTime.Now.Month;
                var ordersInMonthCurrent = context.orderps.Where(o => o.orderdate.Value.Month == monthCurrent).ToList();

                int totalOrderInMonth = ordersInMonthCurrent.Count();

                decimal? totalAmount = ordersInMonthCurrent.Sum(o => o.totalamount);

                // Tính lợi nhuận
                decimal? totalProfit = totalAmount * 0.2m;
                decimal? totalCapital = context.products
                         .Where(p => p.quantityinstock > 0 && p.created_at.Value.Month == monthCurrent)
                         .Sum(p => p.unitprice * p.quantityinstock);


                // Hiển thị kết quả
                label6_totalorder.Text = totalOrderInMonth.ToString();
                label7_totalamount.Text = totalAmount.ToString();
                label8_profit.Text = totalProfit.ToString();
                label13_capital.Text = totalCapital.ToString();

                int yearCurrent = DateTime.Now.Year;
                int daysInMonth = DateTime.DaysInMonth(yearCurrent, monthCurrent);

                Dictionary<int, int> daylyOrderCounts = new Dictionary<int, int>();


                for (int day = 1; day <= daysInMonth; day++)
                {
                    // Lấy danh sách đơn hàng trong ngày hiện tại
                    var ordersInDay = ordersInMonthCurrent.Where(o => o.orderdate.Value.Day == day).ToList();

                    // Đếm số đơn hàng trong ngày
                    int orderCountInDay = ordersInDay.Count();

                    // Lưu vào Dictionary
                    daylyOrderCounts.Add(day, orderCountInDay);
                }

                // Tạo dataset để hiển thị trên GunaChart
                var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                dataset.PointRadius = 10;
                dataset.PointStyle = PointStyle.Circle;
                dataset.Label = "Đơn hàng trong tháng";
                dataset.FillColor = Color.SandyBrown;
                dataset.BorderColor = Color.SandyBrown;

                // Thêm dữ liệu vào dataset
                for (int day = 1; day <= daysInMonth; day++)
                {
                    int orderCountInDay = daylyOrderCounts.ContainsKey(day) ? daylyOrderCounts[day] : 0;
                    dataset.DataPoints.Add(day.ToString(), orderCountInDay);
                }

                // Thêm dataset vào GunaChart và cập nhật
                gunaChart1.Datasets.Add(dataset);
                gunaChart1.Update();
            }

        }

       
        private void guna2Button1_custom_Click(object sender, EventArgs e)
        {
            DateTime startDate = guna2DateTimePicker1.Value.AddDays(-1);
            DateTime endDate = guna2DateTimePicker2.Value.AddDays(1);

            if (startDate >= endDate)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại và không tiếp tục xử lý
            }

            else
            {
                gunaChart1.Datasets.Clear();

                using (var context = new BookShopEntities3())
                {
                    // Lấy danh sách đơn hàng trong khoảng thời gian từ startDate đến endDate
                    var ordersInRange = context.orderps.Where(o => o.orderdate >= startDate && o.orderdate <= endDate).ToList();

                    // Tính tổng số đơn hàng trong khoảng thời gian này
                    int totalOrdersInRange = ordersInRange.Count;

                    // Tính tổng số tiền của các đơn hàng trong khoảng thời gian này
                    decimal? totalAmountInRange = ordersInRange.Sum(o => o.totalamount);

                    // Tính lợi nhuận
                    decimal? totalProfitInRange = totalAmountInRange * 0.2m;

                    decimal? totalCapital = context.products
                         .Where(p => p.quantityinstock > 0 && p.created_at >= startDate && p.created_at <= endDate)
                         .Sum(p => p.unitprice * p.quantityinstock);

                    // Hiển thị kết quả
                    label6_totalorder.Text = totalOrdersInRange.ToString();
                    label7_totalamount.Text = totalAmountInRange.ToString();
                    label8_profit.Text = totalProfitInRange.ToString();
                    label13_capital.Text = totalCapital.ToString(); 

                    // Tiếp tục xử lý dữ liệu hoặc cập nhật giao diện người dùng tại đây
                    Dictionary<int, int> tosDayformeDayOrderCounts = new Dictionary<int, int>();

                    // Lặp qua từng ngày trong khoảng và đếm số đơn hàng trong mỗi ngày
                    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                    {
                        int orderCountInDay = ordersInRange.Count(o => o.orderdate == date.Date);
                        tosDayformeDayOrderCounts[date.Day] = orderCountInDay;
                    }

                    var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                    dataset.PointRadius = 10;
                    dataset.PointStyle = PointStyle.Circle;
                    dataset.Label = "Đơn hàng theo ngày chọn";
                    dataset.FillColor = Color.Turquoise;
                    dataset.BorderColor = Color.Turquoise;

                    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                    {
                        int orderCountInDay = tosDayformeDayOrderCounts.ContainsKey(date.Day) ? tosDayformeDayOrderCounts[date.Day] : 0;
                        dataset.DataPoints.Add(date.ToString("dd/MM"), orderCountInDay);
                    }

                    // Thêm dataset vào GunaChart và cập nhật
                    gunaChart1.Datasets.Add(dataset);
                    gunaChart1.Update();
                }
            }
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == tabPage2)
            {
                gunaChart2.Datasets.Clear();
                flowLayoutPanel1_list.Controls.Clear();
                LoadDataForTab2();
            }
            else if (guna2TabControl1.SelectedTab == tabPage3)
            {
                gunaChart4.Datasets.Clear();
                flowLayoutPanel_customer.Controls.Clear();
                LoadDataForTab3();
            }
        }

        private void LoadDataForTab2()
        {
            DateTime currentDate = DateTime.Now;
            // Calculate the first day of the current month
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            // Calculate the last day of the previous month
            DateTime lastDayOfPreviousMonth = firstDayOfMonth.AddDays(-1);
            // Calculate the first day of the previous month to use as a boundary for new products
            DateTime firstDayOfPreviousMonth = lastDayOfPreviousMonth.AddDays(-lastDayOfPreviousMonth.Day + 1);
            totalProductBestSeller.Clear();
            using (var context = new BookShopEntities3())
            {
                int? totalProductInYear = context.orderdetails.Sum(ord => (int?)ord.quantity);
                label7_totalbest.Text = totalProductInYear?.ToString() ?? "0";

                // Calculate newProductInInventory
                var newProductInInventory = context.products
                            .Where(p => p.created_at >= firstDayOfPreviousMonth && p.created_at <= lastDayOfPreviousMonth)
                            .Sum(p => (int?)p.quantityinstock) ?? 0;
                label17.Text = newProductInInventory.ToString();

                // Calculate oldProductInInventory
                var oldProductInInventory = context.products
                                            .Where(p => p.created_at < firstDayOfPreviousMonth)
                                            .Sum(p => (int?)p.quantityinstock) ?? 0;
                label18.Text = oldProductInInventory.ToString();
                // Lấy dữ liệu từ cơ sở dữ liệu và chèn vào Dictionary
                var bestSellingCategories = (from od in context.orderdetails
                                             join p in context.products on od.productid equals p.productid
                                             join c in context.categories on p.categoryid equals c.category_id
                                             join ord in context.orderps on od.orderid equals ord.orderid
                                             where ord.orderdate.Value.Month <= 12
                                             group od by c.category_name into g
                                             orderby g.Sum(x => x.quantity) descending
                                             select new
                                             {
                                                 CategoryName = g.Key,
                                                 TotalQuantity = g.Sum(x => x.quantity)
                                             }).Take(5);
                var bestSellers = (from od in context.orderdetails
                                   join p in context.products on od.productid equals p.productid
                                   join ord in context.orderps on od.orderid equals ord.orderid
                                   where ord.orderdate.Value.Month <= 12
                                   group new { p, od } by new { p.productname } into g
                                   orderby g.Sum(x => x.od.quantity) descending
                                   select new
                                   {
                                       ProductName = g.Key.productname,
                                       TotalQuantity = g.Sum(x => x.od.quantity)
                                   }).Take(5);

                foreach (var od in bestSellers)
                {
                    totalProductBestSeller.Add(od.ProductName, (int)od.TotalQuantity);

                }
                // Duyệt qua kết quả và thêm vào Dictionary
                foreach (var item in bestSellingCategories)
                {

                    Book_item_db book_Item_Db = new Book_item_db(item.CategoryName, (int)item.TotalQuantity);
                    flowLayoutPanel1_list.Controls.Add(book_Item_Db);
                }

                //Chart configuration 
                gunaChart2.YAxes.GridLines.Display = true;

                //Create a new dataset 
                var dataset = new Guna.Charts.WinForms.GunaHorizontalBarDataset();
                // Thêm dữ liệu từ Dictionary vào dataset
                foreach (var kvp in totalProductBestSeller)
                {
                    dataset.DataPoints.Add(kvp.Key, kvp.Value);
                }

                // Thêm dataset vào GunaChart2
                gunaChart2.Datasets.Add(dataset);

                // Cập nhật để render biểu đồ
                gunaChart2.Update();

            }
        }

        private void guna2Button_spweek_Click(object sender, EventArgs e)
        {
            gunaChart2.Datasets.Clear();
            flowLayoutPanel1_list.Controls.Clear();
            totalProductBestSeller.Clear();
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            // Tìm ngày đầu tiên và cuối cùng của tuần hiện tại
            DateTime firstDayOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            using (var context = new BookShopEntities3())
            {
                var ordersInWeek = from order in context.orderps
                                   where order.orderdate >= firstDayOfWeek && order.orderdate <= lastDayOfWeek
                                   join orderDetail in context.orderdetails on order.orderid equals orderDetail.orderid
                                   select orderDetail.quantity;

                int? totalProductInWeek = ordersInWeek.Sum();
                label7_totalbest.Text = totalProductInWeek.ToString();

                var bestSellingCategories = (from od in context.orderdetails
                                             join p in context.products on od.productid equals p.productid
                                             join c in context.categories on p.categoryid equals c.category_id
                                             join ord in context.orderps on od.orderid equals ord.orderid
                                             where ord.orderdate >= firstDayOfWeek && ord.orderdate <= lastDayOfWeek
                                             group od by c.category_name into g
                                             orderby g.Sum(x => x.quantity) descending
                                             select new
                                             {
                                                 CategoryName = g.Key,
                                                 TotalQuantity = g.Sum(x => x.quantity)
                                             }).Take(5);
                var bestSellers = (from od in context.orderdetails
                                   join p in context.products on od.productid equals p.productid
                                   join ord in context.orderps on od.orderid equals ord.orderid
                                   where ord.orderdate >= firstDayOfWeek && ord.orderdate <= lastDayOfWeek
                                   group new { p, od } by new { p.productname } into g
                                   orderby g.Sum(x => x.od.quantity) descending
                                   select new
                                   {
                                       ProductName = g.Key.productname,
                                       TotalQuantity = g.Sum(x => x.od.quantity)
                                   }).Take(5);

                foreach (var od in bestSellers)
                {
                    totalProductBestSeller.Add(od.ProductName, (int)od.TotalQuantity);

                }
                // Duyệt qua kết quả và thêm vào Dictionary
                foreach (var item in bestSellingCategories)
                {

                    Book_item_db book_Item_Db = new Book_item_db(item.CategoryName, (int)item.TotalQuantity);
                    flowLayoutPanel1_list.Controls.Add(book_Item_Db);
                }

                //Chart configuration 
                gunaChart2.YAxes.GridLines.Display = false;

                //Create a new dataset 
                var dataset = new Guna.Charts.WinForms.GunaHorizontalBarDataset();

                dataset.Label = "Best seller trong tuần này";

                // Thêm dữ liệu từ Dictionary vào dataset
                foreach (var kvp in totalProductBestSeller)
                {
                    dataset.DataPoints.Add(kvp.Key, kvp.Value);
                }

                // Thêm dataset vào GunaChart2
                gunaChart2.Datasets.Add(dataset);

                // Cập nhật để render biểu đồ
                gunaChart2.Update();
            }
        }

        private void guna2Button_spyear_Click(object sender, EventArgs e)
        {
            gunaChart2.Datasets.Clear();
            flowLayoutPanel1_list.Controls.Clear();
            LoadDataForTab2();
        }

        private void guna2Button_spmonth_Click(object sender, EventArgs e)
        {
            gunaChart2.Datasets.Clear();
            flowLayoutPanel1_list.Controls.Clear();
            totalProductBestSeller.Clear();

            using (var context = new BookShopEntities3())
            {
                int monthCurrent = DateTime.Now.Month;
                int yearCurrent = DateTime.Now.Year;

                // Lấy tổng số lượng sản phẩm bán được trong tháng hiện tại
                var ordersInMonth = from order in context.orderps
                                    where order.orderdate.Value.Month == monthCurrent && order.orderdate.Value.Year == yearCurrent
                                    join orderDetail in context.orderdetails on order.orderid equals orderDetail.orderid
                                    select orderDetail.quantity;

                int? totalProductInMonth = ordersInMonth.Sum();


                label7_totalbest.Text = totalProductInMonth.ToString();

                var bestSellingCategories = (from od in context.orderdetails
                                             join p in context.products on od.productid equals p.productid
                                             join c in context.categories on p.categoryid equals c.category_id
                                             join ord in context.orderps on od.orderid equals ord.orderid
                                             where ord.orderdate.Value.Month == monthCurrent
                                             group od by c.category_name into g
                                             orderby g.Sum(x => x.quantity) descending
                                             select new
                                             {
                                                 CategoryName = g.Key,
                                                 TotalQuantity = g.Sum(x => x.quantity)
                                             }).Take(5);
                var bestSellers = (from od in context.orderdetails
                                   join p in context.products on od.productid equals p.productid
                                   join ord in context.orderps on od.orderid equals ord.orderid
                                   where ord.orderdate.Value.Month == monthCurrent
                                   group new { p, od } by new { p.productname } into g
                                   orderby g.Sum(x => x.od.quantity) descending
                                   select new
                                   {
                                       ProductName = g.Key.productname,
                                       TotalQuantity = g.Sum(x => x.od.quantity)
                                   }).Take(5);

                foreach (var od in bestSellers)
                {
                    totalProductBestSeller.Add(od.ProductName, (int)od.TotalQuantity);

                }
                // Duyệt qua kết quả và thêm vào Dictionary
                foreach (var item in bestSellingCategories)
                {

                    Book_item_db book_Item_Db = new Book_item_db(item.CategoryName, (int)item.TotalQuantity);
                    flowLayoutPanel1_list.Controls.Add(book_Item_Db);
                }
                //Chart configuration 
                gunaChart2.YAxes.GridLines.Display = false;

                //Create a new dataset 
                var dataset = new Guna.Charts.WinForms.GunaHorizontalBarDataset();

                dataset.Label = "Best seller trong tháng này";

                // Thêm dữ liệu từ Dictionary vào dataset
                foreach (var kvp in totalProductBestSeller)
                {
                    dataset.DataPoints.Add(kvp.Key, kvp.Value);
                }

                // Thêm dataset vào GunaChart2
                gunaChart2.Datasets.Add(dataset);

                // Cập nhật để render biểu đồ
                gunaChart2.Update();
            }

        }

        private void guna2Button_sptoday_Click(object sender, EventArgs e)
        {

            gunaChart2.Datasets.Clear();
            flowLayoutPanel1_list.Controls.Clear();
            totalProductBestSeller.Clear();

            DateTime startDate = guna2DateTimePicker_to.Value.AddDays(-1);
            DateTime endDate = guna2DateTimePicker_from.Value.AddDays(1);

            using (var context = new BookShopEntities3())
            {

                // Lấy tổng số lượng sản phẩm bán được trong tháng hiện tại
                var ordersInMonth = from order in context.orderps
                                    where order.orderdate >= startDate && order.orderdate <= endDate
                                    join orderDetail in context.orderdetails on order.orderid equals orderDetail.orderid
                                    select orderDetail.quantity;

                int? totalProductInMonth = ordersInMonth.Sum();


                label7_totalbest.Text = totalProductInMonth.ToString();

                var bestSellingCategories = (from od in context.orderdetails
                                             join p in context.products on od.productid equals p.productid
                                             join c in context.categories on p.categoryid equals c.category_id
                                             join ord in context.orderps on od.orderid equals ord.orderid
                                             where ord.orderdate >= startDate && ord.orderdate <= endDate
                                             group od by c.category_name into g
                                             orderby g.Sum(x => x.quantity) descending
                                             select new
                                             {
                                                 CategoryName = g.Key,
                                                 TotalQuantity = g.Sum(x => x.quantity)
                                             }).Take(5);
                var bestSellers = (from od in context.orderdetails
                                   join p in context.products on od.productid equals p.productid
                                   join ord in context.orderps on od.orderid equals ord.orderid
                                   where ord.orderdate >= startDate && ord.orderdate <= endDate
                                   group new { p, od } by new { p.productname } into g
                                   orderby g.Sum(x => x.od.quantity) descending
                                   select new
                                   {
                                       ProductName = g.Key.productname,
                                       TotalQuantity = g.Sum(x => x.od.quantity)
                                   }).Take(5);

                foreach (var od in bestSellers)
                {
                    totalProductBestSeller.Add(od.ProductName, (int)od.TotalQuantity);

                }
                // Duyệt qua kết quả và thêm vào Dictionary
                foreach (var item in bestSellingCategories)
                {

                    Book_item_db book_Item_Db = new Book_item_db(item.CategoryName, (int)item.TotalQuantity);
                    flowLayoutPanel1_list.Controls.Add(book_Item_Db);
                }

                //Chart configuration 
                gunaChart2.YAxes.GridLines.Display = false;

                //Create a new dataset 
                var dataset = new Guna.Charts.WinForms.GunaHorizontalBarDataset();

                dataset.Label = "Best seller trong khoảng";

                // Thêm dữ liệu từ Dictionary vào dataset
                foreach (var kvp in totalProductBestSeller)
                {
                    dataset.DataPoints.Add(kvp.Key, kvp.Value);
                }

                // Thêm dataset vào GunaChart2
                gunaChart2.Datasets.Add(dataset);

                // Cập nhật để render biểu đồ
                gunaChart2.Update();
            }
        }

        private void LoadDataForTab3()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime startDate = currentDateTime.AddDays(-30);
            int totalCus = 0;
            // Initialize the dictionary to store note categories and their counts
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var customerStats = context.customers
                        .GroupBy(c => 1) // Group all customers to perform aggregate functions
                        .Select(g => new
                        {
                            TotalCustomer = g.Count(),
                            TotalCountReturn = g.Count(c => c.returncount >= 2 && c.returncount < 5),
                            TotalCountClose = g.Count(c => c.returncount >=5),
                            TotalCountNew = g.Count(c => c.datein >= startDate && c.returncount == 1),
                            NotReturningCustomersCount = g.Count(c => c.datein < startDate && c.returncount == 1)
                        }).FirstOrDefault();

                    customerCategoryCounts["Khách quay lại"] = customerStats.TotalCountReturn;
                    customerCategoryCounts["Khách hàng thân thiết"] = customerStats.TotalCountClose;
                    customerCategoryCounts["Khách hàng mới"] = customerStats.TotalCountNew;
                    customerCategoryCounts["Khách không quay lại"] = customerStats.NotReturningCustomersCount;
                    totalCus = customerStats.TotalCustomer;

                    var listCustomerTop10 = context.customers.Where(c => c.point > 0 && c.returncount >= 5) 
                                            .Take(10) 
                                            .ToList();
                    foreach(var customer in listCustomerTop10)
                    {
                        decimal pointBill = customer.point ?? 0;
                        int reCount = customer.returncount ?? 0;
                        Customer_Item customer_Item = new Customer_Item(customer.fullname, customer.phone, pointBill, reCount);
                        flowLayoutPanel_customer.Controls.Add(customer_Item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }

            gunaChart4.Title.Text = "Chỉ số giữ chân khách hàng";
            gunaChart4.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            gunaChart4.XAxes.Display = false;
            gunaChart4.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaRadarDataset();
            dataset.BorderWidth = 2;
            dataset.PointStyle = PointStyle.Circle;
            dataset.FillColor = Color.SpringGreen;
            dataset.BorderColor = Color.SpringGreen;
            dataset.Label = "Tỏng số khách hàng: " + totalCus;
            foreach (var category in customerCategoryCounts)
            {
                dataset.DataPoints.Add(category.Key, category.Value); 
            }
                gunaChart4.Datasets.Add(dataset); // Thêm dataset vào biểu
            // An update was made to re-render the chart
            gunaChart4.Update();

        }

        private void guna2Button_year_customer_Click(object sender, EventArgs e)
        {
            gunaChart4.Datasets.Clear();
            flowLayoutPanel_customer.Controls.Clear();
            LoadDataForTab3();
        }

        private void guna2Button_month_customer_Click(object sender, EventArgs e)
        {
            gunaChart4.Datasets.Clear();
            flowLayoutPanel_customer.Controls.Clear();
            DateTime currentDateTime = DateTime.Now;
            DateTime startDate = currentDateTime.AddDays(-30);
            int monthCurrent = DateTime.Now.Month;
            int yearCurrent = DateTime.Now.Year;
            int totalCus = 0;
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var customerStats = context.customers
                        .Where(c => c.datein.Value.Month == monthCurrent && c.datein.Value.Year == yearCurrent)
                        .GroupBy(c => 1) // Group all customers to perform aggregate functions
                        .Select(g => new
                        {
                            TotalCustomer = g.Count(),
                            TotalCountReturn = g.Count(c => c.returncount >= 2 && c.returncount < 5),
                            TotalCountClose = g.Count(c => c.returncount >= 5),
                            TotalCountNew = g.Count(c => c.datein >= startDate && c.returncount == 1),
                            NotReturningCustomersCount = g.Count(c => c.datein < startDate && c.returncount == 1)
                        }).FirstOrDefault();

                    customerCategoryCounts["Khách quay lại"] = customerStats.TotalCountReturn;
                    customerCategoryCounts["Khách hàng thân thiết"] = customerStats.TotalCountClose;
                    customerCategoryCounts["Khách hàng mới"] = customerStats.TotalCountNew;
                    customerCategoryCounts["Khách không quay lại"] = customerStats.NotReturningCustomersCount;
                    totalCus = customerStats.TotalCustomer;

                    var listCustomerTop10 = context.customers.Where(c => c.point > 0 && c.returncount >= 5 && c.datein.Value.Month == monthCurrent && c.datein.Value.Year == yearCurrent)
                                            .Take(10)
                                            .ToList();
                    foreach (var customer in listCustomerTop10)
                    {
                        decimal pointBill = customer.point ?? 0;
                        int reCount = customer.returncount ?? 0;
                        Customer_Item customer_Item = new Customer_Item(customer.fullname, customer.phone, pointBill, reCount);
                        flowLayoutPanel_customer.Controls.Add(customer_Item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }

            gunaChart4.Title.Text = "Chỉ số giữ chân khách hàng tháng này";
            gunaChart4.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            gunaChart4.XAxes.Display = false;
            gunaChart4.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaRadarDataset();
            dataset.BorderWidth = 2;
            dataset.PointStyle = PointStyle.Circle;
            dataset.FillColor = Color.SpringGreen;
            dataset.BorderColor = Color.SpringGreen;
            dataset.Label = "Tỏng số khách hàng tháng hiện tại: " + totalCus;
            foreach (var category in customerCategoryCounts)
            {
                dataset.DataPoints.Add(category.Key, category.Value);
            }
            gunaChart4.Datasets.Add(dataset); // Thêm dataset vào biểu
            // An update was made to re-render the chart
            gunaChart4.Update();

        }

        private void guna2Button_option_customer_Click(object sender, EventArgs e)
        {
            gunaChart4.Datasets.Clear();
            flowLayoutPanel_customer.Controls.Clear();
            DateTime currentDateTime = DateTime.Now;
            DateTime startDate = guna2DateTimePicker3_to.Value;
            DateTime startDate_dur = currentDateTime.AddDays(-30);
            int totalCus = 0;
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var customerStats = context.customers
                        .Where(c => c.datein <= currentDateTime && c.datein >= startDate)
                        .GroupBy(c => 1) // Group all customers to perform aggregate functions
                        .Select(g => new
                        {
                            TotalCustomer = g.Count(),
                            TotalCountReturn = g.Count(c => c.returncount >= 2 && c.returncount < 5),
                            TotalCountClose = g.Count(c => c.returncount >= 5),
                            TotalCountNew = g.Count(c => c.datein >= startDate_dur && c.returncount == 1),
                            NotReturningCustomersCount = g.Count(c => c.datein < startDate_dur && c.returncount == 1)
                        }).FirstOrDefault();

                    customerCategoryCounts["Khách quay lại"] = customerStats.TotalCountReturn;
                    customerCategoryCounts["Khách hàng thân thiết"] = customerStats.TotalCountClose;
                    customerCategoryCounts["Khách hàng mới"] = customerStats.TotalCountNew;
                    customerCategoryCounts["Khách không quay lại"] = customerStats.NotReturningCustomersCount;
                    totalCus = customerStats.TotalCustomer;

                    var listCustomerTop10 = context.customers.Where(c => c.point > 0 && c.returncount >= 5 && c.datein <= currentDateTime && c.datein >= startDate)
                                            .Take(10)
                                            .ToList();
                    foreach (var customer in listCustomerTop10)
                    {
                        decimal pointBill = customer.point ?? 0;
                        int reCount = customer.returncount ?? 0;
                        Customer_Item customer_Item = new Customer_Item(customer.fullname, customer.phone, pointBill, reCount);
                        flowLayoutPanel_customer.Controls.Add(customer_Item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }

            gunaChart4.Title.Text = "Chỉ số giữ chân khách hàng tùy chọn";
            gunaChart4.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            gunaChart4.XAxes.Display = false;
            gunaChart4.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaRadarDataset();
            dataset.BorderWidth = 2;
            dataset.PointStyle = PointStyle.Circle;
            dataset.FillColor = Color.SpringGreen;
            dataset.BorderColor = Color.SpringGreen;
            dataset.Label = "Tỏng số khách hàng tháng tùy chọn: " + totalCus;
            foreach (var category in customerCategoryCounts)
            {
                dataset.DataPoints.Add(category.Key, category.Value);
            }
            gunaChart4.Datasets.Add(dataset); // Thêm dataset vào biểu
            // An update was made to re-render the chart
            gunaChart4.Update();
        }

        /*private void guna2Button3_week_Click(object sender, EventArgs e)
        {
            gunaChart1.Datasets.Clear();

            using (var context = new BookShopEntities3())
            {
                DateTime currentDate = DateTime.Now;
                int currentYear = currentDate.Year;
                int currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                // Tìm ngày đầu tiên và cuối cùng của tuần hiện tại
                DateTime firstDayOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
                DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

                // Lọc các đơn hàng trong tuần hiện tại
                var ordersInWeek = context.orderps.Where(o => o.orderdate >= firstDayOfWeek && o.orderdate <= lastDayOfWeek).ToList();

                int totalOrderInWeek = ordersInWeek.Count();
                decimal? totalAmount = ordersInWeek.Sum(o => o.totalamount);
                decimal? totalProfit = totalAmount * 0.2m;

                // Hiển thị kết quả
                label6_totalorder.Text = totalOrderInWeek.ToString();
                label7_totalamount.Text = totalAmount.ToString();
                label8_profit.Text = totalProfit.ToString();

                Dictionary<int, int> dailyOrderCounts = new Dictionary<int, int>();

                // Lặp qua từng ngày trong tuần và đếm số đơn hàng trong mỗi ngày
                for (DateTime date = firstDayOfWeek; date <= lastDayOfWeek; date = date.AddDays(1))
                {
                    int orderCountInDay = ordersInWeek.Count(o => o.orderdate == date.Date);
                    dailyOrderCounts[date.Day] = orderCountInDay;
                }

                // Tạo dataset để hiển thị trên GunaChart
                var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                dataset.PointRadius = 10;
                dataset.PointStyle = PointStyle.Circle;
                dataset.Label = "Đơn hàng trong tuần";
                dataset.FillColor = Color.SpringGreen;
                dataset.BorderColor = Color.SpringGreen;

                // Thêm dữ liệu vào dataset
                for (int day = 1; day <= 7; day++)
                {
                    DateTime currentDay = currentDate.AddDays(-((int)currentDate.DayOfWeek - day));

                    // Lấy số đơn hàng trong ngày
                    int orderCountInDay = dailyOrderCounts.ContainsKey(day) ? dailyOrderCounts[day] : 0;

                    // Thêm dữ liệu vào dataset
                    dataset.DataPoints.Add(currentDay.ToString("dd/MM"), orderCountInDay);
                }

                // Thêm dataset vào GunaChart và cập nhật
                gunaChart1.Datasets.Add(dataset);
                gunaChart1.Update();
            }
        }*/
    }
}
