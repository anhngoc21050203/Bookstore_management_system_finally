using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.DashBoard_v2
{
    public partial class Dashboard_v2 : Form
    {
        private Dictionary<string, Dictionary<string, double>> GetDataByCategory = new Dictionary<string, Dictionary<string, double>>();

        public Dashboard_v2()
        {
            InitializeComponent();
            guna2VScrollBar1.BindingContainer = guna2DataGridView1;
            guna2VScrollBar1.AutoScroll = true;

            GetDataByCategory.Add("Sach", new Dictionary<string, double>());
            GetDataByCategory.Add("But", new Dictionary<string, double>());
            GetDataByCategory.Add("Tay", new Dictionary<string, double>());
            GetDataByCategory.Add("Nhan", new Dictionary<string, double>());
            GetDataByCategory.Add("Giay", new Dictionary<string, double>());

        }

        private void Dashboard_v2_Load(object sender, EventArgs e)
        {
            int idx = 0;
            List<string> labels = new List<string>();
            foreach(var item in guna2ComboBox5.Items)
            {
                for(int i = 1; i <= 12; i++)
                {
                    var date = new DateTime(2023, i, 1);
                    string nameMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);

                    int r = guna2DataGridView1.Rows.Add(new object[]
                    {
                        nameMonth, 0
                    });
                    guna2DataGridView1.Rows[r].Tag = item;
                    guna2DataGridView1.Rows[r].Visible = (idx==0);
                    if (idx == 0) labels.Add(nameMonth);
                    switch(idx)
                    {
                        case 0:
                            cSales.DataPoints.Add(nameMonth, 0); break;
                        case 1: 
                            cRevenue.DataPoints.Add(nameMonth, 0); break;
                        case 2:
                            cCommissions.DataPoints.Add(nameMonth, 0); break;
                        case 3:
                            cExpense.DataPoints.Add(nameMonth, 0); break;
                        
                    }
                }
                if(idx == 0)
                {
                    labels.Add(" ");
                }
                idx++;
                gunaChart1.Update();
            }
        }

        private double GetDataForCategory(string category, string month)
        {
            //check if data exists for category and month
            if (GetDataByCategory.ContainsKey(category) && GetDataByCategory[category].ContainsKey(month))
            {
                return GetDataByCategory[category][month];
            }
            return 0;//Defult value in no data exists
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedComBoBoxItem = guna2ComboBox5.Text;
            guna2DataGridView1.Rows.Clear();

            foreach(var item in guna2ComboBox5.Items)
            {
                for (int i = 1; i <= 12; i++)
                {
                    var date = new DateTime(2024, i, 1);
                    string nameMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);

                    int r = guna2DataGridView1.Rows.Add(new object[]
                    {
                    nameMonth,
                       GetDataForCategory(selectedComBoBoxItem, nameMonth)
                    }); 
                    guna2DataGridView1.Rows[r].Tag = item;
                    guna2DataGridView1.Rows[r].Visible = (item.ToString() == selectedComBoBoxItem);
                    
                }
            }
        }

        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string selectedComBoBoxItem = guna2ComboBox5.Text;
            string month = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            double value;
            if (double.TryParse(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), out value))
            {
                if (!GetDataByCategory.ContainsKey(selectedComBoBoxItem))
                {
                    GetDataByCategory[selectedComBoBoxItem] = new Dictionary<string, double>();

                }
                GetDataByCategory[selectedComBoBoxItem][month] = value;

            }
            else
            {
                guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value = GetDataForCategory(selectedComBoBoxItem, month);
            }

            var charts = cSales;
            switch (guna2ComboBox5.SelectedIndex)
            {
                case 1:
                    charts = cRevenue; break;
                case 2:
                    charts = cExpense; break;
                case 3:
                    charts = cCommissions; break;
            }

            charts.DataPoints.Clear();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Visible)
                {
                    var CellValue = row.Cells[1].Value;
                    if (CellValue != null)
                    {
                        if (double.TryParse(CellValue.ToString(), out double value1))
                        {
                            string monthName = row.Cells[0].Value.ToString();
                            charts.DataPoints.Add(monthName, value1);
                        }
                    }
                }
            }
            gunaChart1.Update();
        }
    }
}
