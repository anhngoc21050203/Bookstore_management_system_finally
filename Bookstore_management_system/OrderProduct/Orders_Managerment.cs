using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.OrderProduct
{
    public partial class Orders_Managerment : Form
    {
        private List<OrderSearch> orderSearches;
        private BookShopEntities3 context;
        public Orders_Managerment()
        {
            InitializeComponent();
            LoadDataForm();
            orderSearches = new List<OrderSearch>();
            context = new BookShopEntities3();
            guna2DateTimePicker2_to.Value = DateTime.Now;
        }

        private List<OrderItem> orderItemLists = new List<OrderItem>();
        private void LoadDataForm()
        {
            using (var context = new BookShopEntities3())
            {
                var listOrder = from o in context.orderps
                                join s in context.staffs on o.staffid equals s.id
                                orderby o.orderdate descending
                                select new
                                {
                                    Order = o,
                                    Staffname = s.fullname
                                };
                orderItemLists.Clear();
        
                foreach(var order in listOrder)
                {
                    decimal totalPrice = order.Order.totalamount ?? 0;
                    int number = order.Order.number ?? 0;
                    string staffName = order.Staffname ?? "Unknown"; // Xử lý trường hợp tên nhân viên là null
                    DateTime? dateOr = order.Order.orderdate;


                    // Kiểm tra xem dateOr có giá trị null không trước khi truy cập
                    DateTime orderDate = dateOr ?? DateTime.MinValue;

                    OrderItem orderItem = new OrderItem(order.Order.orderid, staffName, number, totalPrice, order.Order.discountused, order.Order.barcode, orderDate);
                    orderItem.OrderdetailsItemCick += OrderdetailsItemClick;
                    orderItemLists.Add(orderItem);
                    flowLayoutPanel2.Controls.Add(orderItem);
                }
            }
        }

        private void guna2TextBox_productid_TextChanged(object sender, EventArgs e)
        {
            foreach (var orderSearch in orderSearches)
            {
                orderSearch.OrderdetailsCick -= OrderdetailsSearchClick;
            }
            orderSearches.Clear();
            // Xóa các controls trong flowLayoutPanel1
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel3.Controls.Clear(); 
            flowLayoutPanel2.Controls.Clear();

            if(guna2TextBox_productid.Text.Length > 0)
            {
                using(var context = new BookShopEntities3())
                {
                    string searchString = guna2TextBox_productid.Text;
                    var listOrderById = from o in context.orderps
                                        orderby o.orderdate descending
                                        join s in context.staffs on o.staffid equals s.id
                                        where s.fullname.Contains(searchString)  || o.discountused.Contains(searchString) || SqlFunctions.StringConvert((decimal)o.orderid).Contains(searchString)
                                        select new
                                        {
                                            Order = o.orderid,
                                            Staffname = s.fullname
                                        };
                    foreach (var item in listOrderById)
                    {

                        OrderSearch orderSearch = new OrderSearch(item.Order, item.Staffname);
                        orderSearches.Add(orderSearch);
                        orderSearch.OrderdetailsCick += OrderdetailsSearchClick;
                        flowLayoutPanel1.Controls.Add(orderSearch);
                    }
                }
            }
            else
            {
                LoadDataForm();
            }
        }
        private void OrderdetailsItemClick(object sender, EventArgs e)
        {
            OrderItem item = (OrderItem)sender;
            if (item != null)
            {
                long orderId = item.order_id;
                flowLayoutPanel3.Controls.Clear();
                foreach(OrderItem item2 in orderItemLists)
                {
                    if(item2.order_id == orderId)
                    {
                        var orderDetails1 = from o in context.orderps
                                            join od in context.orderdetails on o.orderid equals od.orderid
                                            join p in context.products on od.productid equals p.productid
                                            where o.orderid == orderId
                                            select new
                                            {
                                                ProductName = p.productname,
                                                Price = p.unitprice,
                                                Quantity = od.quantity,
                                                Totalprice = od.totalprice,
                                            };
                        foreach (var order in orderDetails1)
                        {
                            decimal totalPrice = order.Totalprice ?? 0;
                            int quantity = order.Quantity ?? 0;
                            decimal unitPrice = order.Price ?? 0;

                            OrderDetailsItem orderDetailsItem = new OrderDetailsItem(order.ProductName, unitPrice, quantity, totalPrice);
                            flowLayoutPanel3.Controls.Add(orderDetailsItem);
                        }
                    }
                }
            }
        }

        private void OrderdetailsSearchClick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            OrderSearch orderSearch = (OrderSearch)sender;
            if(orderSearch != null)
            {
                long orderId = orderSearch.order_id;
                foreach (OrderSearch orderSearch1 in orderSearches) 
                {
                    if(orderSearch1.order_id == orderId)
                    {

                        var orderDetails = from o in context.orderps
                                            join s in context.staffs on o.staffid equals s.id
                                            where o.orderid == orderId
                                            select new
                                            {
                                                Order = o,
                                                Staffname = s.fullname
                                            };
                        foreach(var order in orderDetails)
                        {
                        
                            decimal totalPrice1 = order.Order.totalamount ?? 0;
                            int number = order.Order.number ?? 0;
                            DateTime? dateOr = order.Order.orderdate;

                            OrderItem orderItem = new OrderItem(order.Order.orderid, order.Staffname, number, totalPrice1, order.Order.discountused, order.Order.barcode, (DateTime)dateOr);
                            orderItem.OrderdetailsItemCick += OrderdetailsItemClick;
                            flowLayoutPanel2.Controls.Add(orderItem);

                        }

                        var orderDetails1 = from o in context.orderps
                                           join od in context.orderdetails on o.orderid equals od.orderid
                                           join p  in context.products on od.productid equals p.productid
                                           where o.orderid == orderId
                                           select new
                                           {
                                               ProductName = p.productname,
                                               Price = p.unitprice,
                                               Quantity = od.quantity,
                                               Totalprice = od.totalprice,
                                           };
                        foreach (var order in orderDetails1)
                        {
                            decimal totalPrice = order.Totalprice ?? 0;
                            int quantity = order.Quantity ?? 0;
                            decimal unitPrice = order.Price ?? 0;

                            OrderDetailsItem orderDetailsItem = new OrderDetailsItem(order.ProductName, unitPrice, quantity, totalPrice);
                            flowLayoutPanel3.Controls.Add(orderDetailsItem);
                        }
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = guna2DateTimePicker1_form.Value.AddDays(-1);
            DateTime endDate = guna2DateTimePicker2_to.Value;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            var listOrderCustomerDate = from o in context.orderps
                                        join s in context.staffs on o.staffid equals s.id
                                        where o.orderdate >= startDate && o.orderdate <= endDate
                                        orderby o.orderdate descending
                                        select new
                                        {
                                            Order = o,
                                            Staffname = s.fullname
                                        };
            orderItemLists.Clear();

            foreach (var order in listOrderCustomerDate)
            {
                decimal totalPrice = order.Order.totalamount ?? 0;
                int number = order.Order.number ?? 0;
                string staffName = order.Staffname ?? "Unknown"; // Xử lý trường hợp tên nhân viên là null
                DateTime? dateOr = order.Order.orderdate;


                // Kiểm tra xem dateOr có giá trị null không trước khi truy cập
                DateTime orderDate = dateOr ?? DateTime.MinValue;

                OrderItem orderItem = new OrderItem(order.Order.orderid, staffName, number, totalPrice, order.Order.discountused, order.Order.barcode, orderDate);
                orderItem.OrderdetailsItemCick += OrderdetailsItemClick;
                orderItemLists.Add(orderItem);
                flowLayoutPanel2.Controls.Add(orderItem);
            }
        }
    }
}
