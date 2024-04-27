
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bookstore_management_system.DashBoard_v2
{
    public partial class Book_item_db : UserControl
    {
        public Book_item_db(string name, int soluong)
        {
            InitializeComponent();

            if (name.Length > 30)
            {
                label1_item.Text = name.Substring(0, 50) + "...";
            }
            else
            {
                label1_item.Text = name;
            }
                label2_totalcate.Text = soluong.ToString();
        }

    }
}
