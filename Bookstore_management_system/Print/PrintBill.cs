using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Print
{
    public partial class PrintBill : Form
    {
        private long _order_id;

        // Constructor nhận dataset từ form chính
        public PrintBill(long orderid)
        {
            InitializeComponent();
            _order_id = orderid;
        }

        private void PrintBill_Load(object sender, EventArgs e)
        {
            this.billDataSet.Clear();
            using (var context = new BookShopEntities3())
            {
                var order = context.orderps.FirstOrDefault(o => o.orderid == _order_id);

                if (order != null)
                {
                    decimal totalAmount = order.totalamount ?? 0; // Sử dụng null coalescing để xác định giá trị mặc định
                    DateTime orderDate = order.orderdate ?? DateTime.MinValue; // Sử dụng null coalescing để xác định giá trị mặc định

                    this.billDataSet.Orders.AddOrdersRow(_order_id, order.staffid, order.paycustomerid, order.barcode, orderDate, totalAmount, order.discountused);
                }


                var orderDetails = from od in context.orderdetails
                                   join p in context.products on od.productid equals p.productid
                                   where od.orderid == _order_id
                                   select new
                                   {
                                       OrderDetail = od,
                                       ProductName = p.productname,
                                       UnitPrice = p.unitprice
                                   };

                foreach (var item in orderDetails)
                {
                    decimal totalItemPrice = item.OrderDetail.totalprice ?? 0;
                    int quantityPro = item.OrderDetail.quantity ?? 0;
                    decimal unitPrice = item.UnitPrice ?? 0;
                    this.billDataSet.OrderDetails.AddOrderDetailsRow(item.ProductName, quantityPro, totalItemPrice, unitPrice);
                }

            }


            // Sử dụng dataset để đổ dữ liệu vào báo cáo
            ReportDataSource ordersDataSource = new ReportDataSource("Orders", billDataSet.Tables["Orders"]);
            ReportDataSource orderDetailsDataSource = new ReportDataSource("OrderDetails", billDataSet.Tables["OrderDetails"]);

            reportViewer1.LocalReport.DataSources.Add(ordersDataSource);
            reportViewer1.LocalReport.DataSources.Add(orderDetailsDataSource);
            reportViewer1.RefreshReport();
        }
    }

}
