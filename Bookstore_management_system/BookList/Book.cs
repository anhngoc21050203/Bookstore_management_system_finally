using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using Bookstore_management_system.Image_processing;
using System.Text;

namespace Bookstore_management_system.BookList
{
    public delegate void HidePanel3Delegate();
    public partial class Book : UserControl
    {
        private HidePanel3Delegate hidePanel3;
        public event EventHandler BookClick;
        private Control panelToDisplay;
        public Book(Image imgBook ,string title, decimal price, int quantityInStock, string publishingCompany, string descriptionBook, Control panel, HidePanel3Delegate hidePanel3Method)
        {
            InitializeComponent();

            // Gán dữ liệu cho các thuộc tính tương ứng
            imgpath = imgBook;
            productname = title;
            unitprice = price;
            quantityinstock = quantityInStock;
            publishingcompany = publishingCompany;
            description = descriptionBook;
            panelToDisplay = panel;
            hidePanel3 = hidePanel3Method;

            pictureBox1.Click += Book_Click;
            lblTitle.Click += Book_Click;
            lblCost.Click += Book_Click;

        }
        private void Book_Click(object sender, EventArgs e)
        {
            OnBookClick();
        }

        protected virtual void OnBookClick()
        {
            BookClick?.Invoke(this, new BookClickEventArgs(imgpath,productname, unitprice, quantityinstock, publishingcompany, description));
        }
        public class BookClickEventArgs : EventArgs
        {
            public Image imageBook { get; }
            public string ProductName { get; }
            public decimal UnitPrice { get; }
            public int QuantityInStock { get; }
            public string PublishingCompany { get; }
            public string Description { get; }

            public BookClickEventArgs(Image Image, string productName, decimal unitPrice, int quantityInStock, string publishingCompany, string description)
            {
                imageBook = Image;
                ProductName = productName;
                UnitPrice = unitPrice;
                QuantityInStock = quantityInStock;
                PublishingCompany = publishingCompany;
                Description = description;
            }
        }


        private void ShowPanel3()
        {
            if (panelToDisplay != null)
            {
                panelToDisplay.Visible = true;
                // Thực hiện các thao tác cần thiết khi hiển thị panel3
            }
        }

        public void HidePanel3()
        {
            if (panelToDisplay != null)
            {
                panelToDisplay.Visible = false;
            }
        }



        #region Properties
        private Image imageBook;
        private string _title;
        private decimal _price;
        private int _quantityinstock;
        private string _publishingcompany;
        private string _description;

        [Category("Custom Props")]
        public Image imgpath
        {
            get { return imageBook; }
            set
            {
                imageBook = value;
                pictureBox1.Image = value;
            }
        }



        [Category("Custom Props")]
        public string productname
        {
            get { return _title; }
            set
            {
                _title = value;
                lblTitle.AutoSize = false; 
                lblTitle.Size = new Size(140, 295); 

                int maxLength = 20;
                if (value.Length > maxLength)
                {
                    string truncatedText = value.Substring(0, maxLength);

                    if (TextRenderer.MeasureText(truncatedText, lblTitle.Font).Height > lblTitle.Height)
                    {
                        lblTitle.Text = truncatedText;
                    }
                    else
                    {
                        lblTitle.Text = value; 
                    }
                }
                else
                {
                    lblTitle.Text = value; 
                }
            }
        }


        
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }


        [Category("Custom Props")]
        public decimal unitprice
        {
            get { return _price; }
            set { _price = value; lblCost.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int quantityinstock
        {
            get { return _quantityinstock; }
            set {
                _quantityinstock = value;
                if (value < 20)
                {
                    lblStock.Text = "Sắp hết hàng";
                }
                else
                {
                    lblStock.Text = "Còn hàng";
                }
            }
        }
        [Category("Custom Props")]
        public string publishingcompany
        {
            get { return _publishingcompany; }
            set { _publishingcompany = value; }
        }

        [Category("Custom Props")]
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }


        #endregion


        #region Hover Effect
        #endregion
    }
}
