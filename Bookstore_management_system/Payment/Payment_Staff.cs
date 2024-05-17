using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;
using RestSharp;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.IO;
using Bookstore_management_system.DashBoard_v2;
using ZXing.PDF417.Internal;
using Microsoft.Reporting.WinForms;
using ZXing.Common;
using Bookstore_management_system.Image_processing;
using Bookstore_management_system.Print;

namespace Bookstore_management_system.Payment
{
    public partial class Payment_Staff : Form
    {
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private List<Payment_item> paymentItems;
        private List<User_item> userItems;
        private List<Discount_item> discountItems;
        private List<ProductItem> productItems;
        private BookShopEntities3 context;

        public Payment_Staff()
        {
            InitializeComponent();
            userItems = new List<User_item>();
            paymentItems = new List<Payment_item>();
            discountItems = new List<Discount_item>();
            productItems = new List<ProductItem>();
            context = new BookShopEntities3();

        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            // Ensure previous image is disposed to free memory.
            if (guna2PictureBox_imginput.Image != null)
            {
                guna2PictureBox_imginput.Image.Dispose();
            }

            Bitmap bitmap = (Bitmap)e.Frame.Clone();
            guna2PictureBox_imginput.Image = (Bitmap)bitmap.Clone(); // Clone bitmap for UI thread

            // Use the barcode reader with specific settings
            BarcodeReader barcodeReader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    // Specify barcode formats if possible
                    // PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE }
                }
            };

            // Process the barcode in a separate thread to keep the UI responsive
            Task.Run(() =>
            {
                // Clone the bitmap for background processing to avoid cross-thread access
                using (Bitmap bitmapToDecode = (Bitmap)bitmap.Clone())
                {
                    var result = barcodeReader.Decode(bitmapToDecode);

                    // Kiểm tra xem mã vạch đã được giải mã thành công và có tồn tại trong cơ sở dữ liệu không
                    if (result != null)
                    {
                        // Chuyển đổi result từ string sang int
                        if (int.TryParse(result.Text, out int productId))
                        {

                            decimal giaSP;
                            int soluongSP;
                            string tenSP;
                            decimal tongtienSP;
                            var checkProduct = context.products.FirstOrDefault(p => p.productid == productId);

                            if (checkProduct != null)
                            {

                                giaSP = checkProduct.unitprice ?? 0;
                                soluongSP = 1; // Số lượng mặc định là 1
                                tenSP = checkProduct.productname;
                                tongtienSP = giaSP * soluongSP;
                                // Marshal the update back to the UI thread
                                guna2TextBox12_result.Invoke(new MethodInvoker(delegate ()
                                {
                                    guna2TextBox12_result.Text = "";
                                }));


                                // Cập nhật UI với mã vạch mới
                                UpdateUIWithBarcode(productId.ToString(), tenSP, giaSP, soluongSP, tongtienSP);
                            }
                            else
                            {
                                // Mã vạch không tồn tại trong cơ sở dữ liệu
                                guna2TextBox12_result.Invoke(new MethodInvoker(delegate ()
                                {
                                    guna2TextBox12_result.Text = "Sản phẩm không tồn tại";
                                }));
                            }
                        }
                        else
                        {
                            // Không thể chuyển đổi mã vạch sang số nguyên
                            guna2TextBox12_result.Invoke(new MethodInvoker(delegate ()
                            {
                                guna2TextBox12_result.Text = "Mã vạch không hợp lệ";
                            }));
                        }
                    }
                }

                // Dispose of the original bitmap
                bitmap.Dispose();
            });

        }

        private void Payment_Staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payment_MethodDataSet.payment_methods' table. You can move, or remove it, as needed.
            this.payment_methodsTableAdapter.Fill(this.payment_MethodDataSet.payment_methods);
            guna2ShadowForm1.SetShadowForm(this); 

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                guna2ComboBox_inputdevices.Items.Add(filterInfo.Name);
            }
            if (guna2ComboBox_inputdevices.Items.Count > 0)
                guna2ComboBox_inputdevices.SelectedIndex = 0;

            
        }

        private void UpdateUIWithBarcode(string barcode, string productInfo, decimal giaSP, int soluongSP, decimal tongtienSP)
        {
            if (InvokeRequired)
            {
                // Nếu không ở trong luồng UI chính, gửi yêu cầu cập nhật đến luồng UI chính
                Invoke(new MethodInvoker(() => UpdateUIWithBarcode(barcode, productInfo, giaSP, soluongSP, tongtienSP)));
                return;
            }

            if (!PaymentItemExists(barcode))
            {
                // Create a new Payment_item and add it to the list
                Payment_item paymentItem = new Payment_item(barcode, productInfo, giaSP, soluongSP, tongtienSP);
                paymentItems.Add(paymentItem);

                // Display the new Payment_item in the UI
                flowLayoutPanel1_item.Controls.Add(paymentItem);
                paymentItem.DeleteButtonClicked += Payment_Item_DeleteButtonClicked;
                paymentItem.QuantityChanged += PaymentItem_QuantityChanged;

                CalculateTotal();
            }
        }

        private void Payment_Item_DeleteButtonClicked(object sender, EventArgs e)
        {
            Payment_item item = sender as Payment_item;
            if (item != null)
            {
                string barcodeToDelete = item.maSP;
                foreach (Payment_item paymentItem in paymentItems)
                {
                    if (paymentItem.maSP == barcodeToDelete)
                    {
                        flowLayoutPanel1_item.Controls.Remove(paymentItem);
                        paymentItems.Remove(paymentItem);
                        break;
                    }
                }
                CalculateTotal();
            }
        }

        private void PaymentItem_QuantityChanged(object sender, EventArgs e)
        {
            Payment_item item = sender as Payment_item;
            if (item != null)
            {
                string maSPUpdateQuantity = item.maSP;
                foreach (Payment_item paymentItem in paymentItems)
                {
                    if (paymentItem.maSP == maSPUpdateQuantity)
                    {
                        paymentItem.soluongSP = item.soluongSP;
                        break;
                    }
                }
                CalculateTotal();
            }
        }

        private bool PaymentItemExists(string barcode)
        {
            // Check if a Payment_item with the same barcode exists in the paymentItems list
            foreach (Payment_item item in paymentItems)
            {
                if (item.maSP == barcode)
                {
                    return true;
                }
            }
            return false;
        }

        private void guna2Button1_start_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[guna2ComboBox_inputdevices.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void CalculateTotal()
        {
            int totalQuantity = 0;
            decimal totalPrice = 0;
            decimal totalPriceReal = 0;

            foreach (Payment_item item in paymentItems)
            {
                totalQuantity += item.soluongSP;
                totalPrice += item.tongtienSP;
            }

            guna2TextBox_totalproduct.Text = totalQuantity.ToString();
            guna2TextBox_totalpricetemp.Text = totalPrice.ToString();

            string discount = guna2TextBox_discount.Text;
            if (discount != null) // Sử dụng "null" thay vì "mull"
            {
                var perAmount = context.discounts.FirstOrDefault(d => d.discount_id == discount);
                if (perAmount != null) // Kiểm tra xem mã giảm giá có tồn tại không
                {
                    decimal? per = perAmount.discount_amount;
                    totalPriceReal = totalPrice - (totalPrice * (decimal)(per ?? 0)); // Sử dụng toán tử ?? để xác định giá trị mặc định
                    guna2TextBox_totalpricereal.Text = totalPriceReal.ToString();
                }
                else
                {
                    guna2TextBox_totalpricereal.Text = totalPrice.ToString();
                }
            }
            else
            {
                guna2TextBox_totalpricereal.Text = totalPrice.ToString();
            }

            if (decimal.TryParse(guna2TextBox_pricepay.Text, out decimal amountPaid))
            {
               
                decimal change = amountPaid - totalPriceReal;

                if (change >= 0)
                {
                    guna2TextBox_priceexchange.Text = change.ToString();
                }
                else
                {
                    // Nếu số tiền đưa ít hơn tổng tiền, không hiển thị số tiền thừa
                    guna2TextBox_priceexchange.Text = "-" + (change).ToString();
                }
                
            }
        }

        private void guna2Button_addcustomer_Click(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            newCustomer.NewCustomerIdAdded += NewCustomer_NewCustomerIdAdded;
            newCustomer.Show();
        }

        private void NewCustomer_NewCustomerIdAdded(object sender, int newCustomerId)
        {
            // Xử lý ID mới của khách hàng được truyền từ form con tới form cha
            int customerId = newCustomerId;

            guna2TextBox_searchcus.Text = customerId.ToString();
            label_customnew.Text = "Khách hàng mới";


            var discountForNewbie = context.discounts.FirstOrDefault(dc => dc.customer_id == customerId);

            string discount_id_newbiew = discountForNewbie.discount_id;

            guna2TextBox_discount.Text = discount_id_newbiew;

            flowLayoutPanel1_user.Controls.Clear();

            CalculateTotal();

        }
        private void guna2TextBox_pricepay_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(guna2TextBox_totalpricereal.Text, out decimal payReal))
            {
                if (decimal.TryParse(guna2TextBox_pricepay.Text, out decimal amountPaid))
                {
                    decimal change = amountPaid - payReal;

                    if (change >= 0)
                    {
                        guna2TextBox_priceexchange.Text = change.ToString();
                    }
                    else
                    {
                        // Nếu số tiền đưa ít hơn tổng tiền, không hiển thị số tiền thừa
                        guna2TextBox_priceexchange.Text = (change).ToString();
                    }
                }
            }
        }

        private void guna2TextBox_searchcus_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1_user.Controls.Clear();

            string searchKeyword = guna2TextBox_searchcus.Text.Trim();

            if (guna2TextBox_searchcus.TextLength > 0) {
                var listCustomer = from cu in context.customers
                                   where cu.fullname.Contains(searchKeyword) || cu.phone.Contains(searchKeyword) // Lọc theo tên khách hàng chứa từ khóa tìm kiếm
                                   select cu;

                userItems.Clear();

                // Sau khi có danh sách khách hàng, bạn có thể làm bất cứ điều gì bạn muốn với nó, ví dụ:
                foreach (var customer in listCustomer)
                {
                    int cusid = customer.customerid;
                    string fname = customer.fullname;
                    string pho = customer.phone;

                    UpdateUiCustomerUC(cusid, fname, pho);
                    

                }
                flowLayoutPanel1_user.Visible = true; // Hiển thị flowLayoutPanel1_user khi có kết quả tìm kiếm
            }
            else
            {
                flowLayoutPanel1_user.Visible = false; // Ẩn flowLayoutPanel1_user khi không có kết quả tìm kiếm
            }
        }
        private void UpdateUiCustomerUC(int id, string fname, string phone)
        {

            User_item user_Item = new User_item(id, fname, phone);
            userItems.Add(user_Item);

            // Display the new Payment_item in the UI
            flowLayoutPanel1_user.Controls.Add(user_Item);
            user_Item.TakeDiscountForUser += User_Item_ListApplyDiscount;

            UpdateFlowLayoutPanelHeight();

        }

        private void UpdateFlowLayoutPanelHeight()
        {
            // Chiều cao mỗi phần tử trong flowLayoutPanel1_user
            int itemHeight = 50; // Giá trị mặc định cho chiều cao của mỗi phần tử
            int minHeight = 50; // Chiều cao tối thiểu

            // Số lượng phần tử trong flowLayoutPanel1_user
            int itemCount = flowLayoutPanel1_user.Controls.Count;

            // Tính toán chiều cao mới của flowLayoutPanel1_user
            int newHeight = Math.Max(itemHeight * itemCount, minHeight);

            // Thiết lập chiều cao mới cho flowLayoutPanel1_user
            flowLayoutPanel1_user.Height = newHeight;

        }


        private void User_Item_ListApplyDiscount(object sender, EventArgs e)
        {
            DateTime dayNow = DateTime.Today;
            decimal totalPriceTemp;
            if (!decimal.TryParse(guna2TextBox_totalpricetemp.Text, out totalPriceTemp))
            {
                // Nếu không thể chuyển đổi thành công, gán totalPriceTemp bằng 0
                totalPriceTemp = 0;
            }
            User_item item = sender as User_item;
            if (item != null)
            {
                int cusId = item.use_id;
                foreach (User_item uI in userItems)
                {
                    if (item.use_id == cusId)
                    {
                        guna2TextBox_searchcus.Text = cusId.ToString();
                        label_customnew.Text = "Khách hàng đã tồn tại";
                        var discountForAllCustomers = from du in context.discounts
                                                      where du.discount_type_id == 2 &&
                                                            du.min_amount <= totalPriceTemp && du.start_date <= dayNow && du.end_date >= dayNow &&
                                                            du.apply_count > 0
                                                      select du;
                        var discountForSpecificCustomer = from du in context.discounts
                                                          where du.discount_type_id == 2 && du.customer_id == cusId && du.start_date <= dayNow && du.end_date >= dayNow &&
                                                            du.apply_count > 0
                                                          select du;

                        var discountForByDate = from du in context.discounts
                                                          where du.discount_type_id == 2 && du.start_date <= dayNow && du.end_date >= dayNow && du.apply_count > 0
                                                select du;

                        var combinedDiscounts = discountForAllCustomers
                         .Union(discountForSpecificCustomer)
                         .Union(discountForByDate);


                        discountItems.Clear();

                        foreach(var disItem  in combinedDiscounts)
                        {
                            string id = disItem.discount_id;
                            string noteDis = disItem.note;

                            UpdateUiDiscount(id, noteDis);
                        }

                        flowLayoutPanel1_user.Controls.Clear();
                        flowLayoutPanel1_user.Visible = false;
                        flowLayoutPanel_discount.Visible = true;
                        break;
                    }
                }
            }
        }
        private void UpdateUiDiscount(string id, string note)
        {


            Discount_item dc_Item = new Discount_item(id, note);
            discountItems.Add(dc_Item);

            // Display the new Payment_item in the UI
            flowLayoutPanel_discount.Controls.Add(dc_Item);
            dc_Item.ApplyDiscountForUser += Discount_Item_SelectApplyDiscount;

            int itemHeight = 70;
            int minHeight = 70; 

            int itemCount = flowLayoutPanel_discount.Controls.Count;

            int newHeight = Math.Max(itemHeight * itemCount, minHeight);

            flowLayoutPanel_discount.Height = newHeight;

        }

        private void Discount_Item_SelectApplyDiscount(object sender, EventArgs e)
        {
            
            Discount_item item = sender as Discount_item;
            if (item != null)
            {
                string disId = item.id;
                foreach (Discount_item dI in discountItems)
                {
                    if (dI.id == disId)
                    {
                        guna2TextBox_discount.Text = disId;
                        flowLayoutPanel_discount.Controls.Clear();
                        flowLayoutPanel_discount.Visible = false;
                        break;
                    }
                }
            }
            CalculateTotal();
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);


            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void guna2TextBox_productid_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1_searchproduct.Controls.Clear();

            string searchKeyword = guna2TextBox_productid.Text.Trim();

            if (guna2TextBox_productid.TextLength > 0)
            {
                using (var context = new BookShopEntities3())
                {
                    var query = from pr in context.products
                                join cate in context.categories on pr.categoryid equals cate.category_id
                                where pr.productname.Contains(searchKeyword.ToLower()) ||
                                      cate.category_name.Contains(searchKeyword.ToLower())
                                select pr;

                    var products = query.ToList();

                    // Xóa các mục cũ từ danh sách userItems
                    userItems.Clear();

                    if (products.Any()) // Kiểm tra xem có kết quả nào không
                    {
                        foreach (var pro in products)
                        {
                            int cusid = pro.productid;
                            string fname = pro.productname;

                            UpdateUIProduct(cusid, fname);
                        }
                    }
                }

                flowLayoutPanel1_searchproduct.Visible = true;
            }
            else
            {
                flowLayoutPanel1_searchproduct.Visible = false;
            }
        }

        private void UpdateUIProduct(int id, string name)
        {
            ProductItem pr_Item = new ProductItem(id, name);
            productItems.Add(pr_Item);

            // Display the new Payment_item in the UI
            flowLayoutPanel1_searchproduct.Controls.Add(pr_Item);
            pr_Item.TakeProductId += Product_Item_TakeProductID;

        }

        private void Product_Item_TakeProductID(object sender, EventArgs e)
        {

            ProductItem item = sender as ProductItem;

            decimal giaSP;
            int soluongSP;
            string tenSP;
            decimal tongtienSP;
            if (item != null)
            {
                int disId = item.id;
                foreach (ProductItem pI in productItems)
                {
                    if (pI.id == disId)
                    {
                        var productSearch = context.products.FirstOrDefault(p => p.productid == disId);
                        if (productSearch != null)
                        {

                            giaSP = productSearch.unitprice ?? 0;
                            soluongSP = 1; // Số lượng mặc định là 1
                            tenSP = productSearch.productname;
                            tongtienSP = giaSP * soluongSP;

                            // Cập nhật UI với mã vạch mới
                            UpdateUIWithBarcode(disId.ToString(), tenSP, giaSP, soluongSP, tongtienSP);
                        }
                        
                        flowLayoutPanel1_searchproduct.Controls.Clear();
                        flowLayoutPanel1_searchproduct.Visible = false;
                        break;
                    }
                }
            }
        }

        private void guna2ComboBox_payments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pt =1;
            if (guna2ComboBox_payments.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)guna2ComboBox_payments.SelectedItem;
                pt = Convert.ToInt32(selectedRow["payment_method_id"]);
                // Tiếp tục sử dụng giá trị của pt ở đây
            }


            decimal priceEnd =0;

            if (decimal.TryParse(guna2TextBox_totalpricereal.Text, out priceEnd))
            {

            }
            if (pt == 2)
            {

                var apiRequest = new ApiRequest();
                apiRequest.acqId = 970436;
                apiRequest.accountNo = long.Parse("1022888888");
                apiRequest.accountName = "Pham Ngoc Tuan Anh";
                apiRequest.amount = priceEnd;
                apiRequest.format = "text";
                apiRequest.template = "compact";
                var jsonRequest = JsonConvert.SerializeObject(apiRequest);
                var restClient = new RestClient("https://api.vietqr.io/v2/generate");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
                var response = restClient.Execute(request);
                var content = response.Content;
                var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);

                if (dataResult != null && dataResult.data != null && !string.IsNullOrEmpty(dataResult.data.qrDataURL))
                {
                    var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
                    guna2PictureBox_qrpay.Image = image;
                }
                else
                {
                    // Xử lý trường hợp dữ liệu không hợp lệ hoặc thiếu
                    // Ví dụ: Hiển thị thông báo hoặc xử lý khác tùy thuộc vào yêu cầu của ứng dụng
                    MessageBox.Show("Dữ liệu QR không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                guna2PictureBox_qrpay.Image = null; // Gán hình ảnh thành null khi phương thức thanh toán không phải là 2
            }
        }

        private void guna2Button_pay_Click(object sender, EventArgs e)
        {

            if (CreateOrder())
            {
                MessageBox.Show("Đã tạo hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flowLayoutPanel1_item.Controls.Clear();
                flowLayoutPanel_discount.Controls.Clear();

                if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    guna2PictureBox_imginput.Image = null;
                    
                }

                guna2TextBox_searchcus.Text = "";
                guna2TextBox_totalproduct.Text = "";
                guna2TextBox_totalpricetemp.Text = "";
                guna2TextBox_discount.Text = "";
                guna2TextBox_totalpricereal.Text = "";
                guna2TextBox_pricepay.Text = "";
                guna2TextBox_priceexchange.Text = "";
                guna2PictureBox_qrpay.Image = null;
                guna2ComboBox_payments.SelectedIndex = 0;
                paymentItems.Clear();
                discountItems.Clear();
                userItems.Clear();
                discountItems.Clear();

            }
            else
            {
                MessageBox.Show("Tạo hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private bool CreateOrder()
        {
            
            try
            {
                int quantity = int.Parse(guna2TextBox_totalproduct.Text);
                DataRowView selectedRow = (DataRowView)guna2ComboBox_payments.SelectedItem;
                int pt = Convert.ToInt32(selectedRow["payment_method_id"]);
                int customId = int.Parse(guna2TextBox_searchcus.Text);
                int soluong = int.Parse(guna2TextBox_totalproduct.Text);

                string discountused = guna2TextBox_discount.Text;

                var subDiscountUsed = context.discounts.FirstOrDefault(dis => dis.discount_id == discountused);
                if (subDiscountUsed != null)
                {
                    // Giảm đi 1 số lượng sử dụng từ discount đó
                    if (subDiscountUsed.apply_count > 0)
                    {
                        subDiscountUsed.apply_count -= 1;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        context.SaveChanges();
                    }
                }


                decimal totalPrice = decimal.Parse(guna2TextBox_totalpricereal.Text);
                var returnCus = context.customers.FirstOrDefault(cu => cu.customerid == customId);

                if(returnCus != null)
                {
                    if(returnCus.returncount >= 0)
                    {
                        returnCus.returncount += 1;
                        returnCus.point += (totalPrice / 100);

                        context.SaveChanges() ;
                    }
                }

                long orderid = long.Parse(GenerateOrderId(quantity, pt));


                DateTime date = DateTime.Today;
                long stadd_Id = Properties.Settings.Default.LoggedInStaffID; ;
                Bitmap barcode = GenerateBarcode(orderid.ToString(), BarcodeFormat.CODE_128);

                byte[] barcodeEn = ImageProcessor.EncodeImageToVarbinaryv2(barcode);

                var newOrder = Orders.NewOrder(orderid, barcodeEn, stadd_Id, customId, date, totalPrice, discountused, soluong);

                context.orderps.Add(newOrder);
                context.SaveChanges();

                foreach (Payment_item payment_Item in paymentItems)
                {
                    int productId = int.Parse(payment_Item.maSP);
                    int quantity_pro = payment_Item.soluongSP;
                    decimal total_pro = payment_Item.tongtienSP;
                    var updateQuantity = context.products.FirstOrDefault(pr => pr.productid == productId);

                    if(updateQuantity != null )
                    {
                        updateQuantity.quantityinstock -= quantity_pro;
                      
                    }


                    var newOrderDetails = OrdersDetails.CreateOrdersDetails(orderid, productId, quantity_pro, total_pro, pt);

                    context.orderdetails.Add(newOrderDetails);
                }
                    context.SaveChanges();

                PrintBill printBill = new PrintBill(orderid);
                printBill.ShowDialog();



                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
        private string GenerateOrderId(int quantity, int paymentMethodId)
        {
            // Lấy ngày hiện tại và chuyển đổi thành chuỗi dạng "ddMMyy"
            string datePart = DateTime.Now.ToString("ddMMyy");

            // Định dạng số lượng thành chuỗi có 3 chữ số, sử dụng phương pháp PadLeft để thêm số 0 vào trước
            string quantityPart = quantity.ToString().PadLeft(3, '0');

            // Định dạng mã hình thức thanh toán thành chuỗi có 2 chữ số, sử dụng phương pháp PadLeft để thêm số 0 vào trước
            string paymentMethodIdPart = paymentMethodId.ToString().PadLeft(2, '0');

            // Tạo chuỗi chứa 3 số ngẫu nhiên từ 0 đến 9
            Random random = new Random();
            string randomPart = random.Next(0, 1000).ToString().PadLeft(3, '0');

            // Kết hợp các phần thành mã ID cuối cùng
            string orderId = $"{datePart}{quantityPart}{paymentMethodIdPart}{randomPart}";

            return orderId;
        }

        private Bitmap GenerateBarcode(string content, BarcodeFormat format)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = format,
                Options = new EncodingOptions
                {
                    Height = 50, // Chiều cao của mã vạch
                    Width = 270,  // Chiều rộng của mã vạch
                    Margin = 5,
                    PureBarcode = false
                }
            };

            return barcodeWriter.Write(content);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_discount.Visible = false;
        }
    }

}
/*var apiRequest = new ApiRequest();
               apiRequest.acqId = 970436;
               apiRequest.accountNo = long.Parse("1022866666");
               apiRequest.accountName = "Pham Ngoc Tuan Anh";
               apiRequest.amount = priceEnd;
               apiRequest.format = "text";
               apiRequest.template = "compact";

               var jsonRequest = JsonConvert.SerializeObject(apiRequest);

               var client = new RestClient("https://api.vietqr.io/v2/generate");
               var request = new RestRequest();

               request.Method = Method.Post;
               request.AddHeader("Content-Type", "application/json");

               request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

               var response = client.Execute(request);

               var content = response.Content;

               var dataRs = JsonConvert.DeserializeObject<ApiResponse>(content);*/
