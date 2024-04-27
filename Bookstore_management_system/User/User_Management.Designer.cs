using System.Windows.Forms;

namespace Bookstore_management_system.User
{
    partial class User_Management
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Management));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1_upload = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ComboBox_role = new Guna.UI2.WinForms.Guna2ComboBox();
            this.roleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopRole = new Bookstore_management_system.BookShopRole();
            this.guna2ComboBox_calam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.shiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopShift = new Bookstore_management_system.BookShopShift();
            this.label17 = new System.Windows.Forms.Label();
            this.guna2TextBox_hesoluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2TextBox_cccd = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2TextBox_address = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2TextBox_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.guna2TextBox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2TextBox_mnv = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2TextBox_phone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2TextBox_email = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox_img = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker_dateofbirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2CustomRadioButton_nu = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2CustomRadioButton_nam = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2TextBox_name = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button_add = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_update = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_del = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_save = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_print = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1_tb = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.roleTableAdapter = new Bookstore_management_system.BookShopRoleTableAdapters.roleTableAdapter();
            this.shiftTableAdapter = new Bookstore_management_system.BookShopShiftTableAdapters.shiftTableAdapter();
            this.shiftname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luongcoban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avatar = new System.Windows.Forms.DataGridViewImageColumn();
            this.cccd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Management";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.Controls.Add(this.guna2Button1_upload);
            this.guna2Panel2.Controls.Add(this.guna2ComboBox_role);
            this.guna2Panel2.Controls.Add(this.guna2ComboBox_calam);
            this.guna2Panel2.Controls.Add(this.label17);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_hesoluong);
            this.guna2Panel2.Controls.Add(this.label16);
            this.guna2Panel2.Controls.Add(this.label15);
            this.guna2Panel2.Controls.Add(this.label14);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_cccd);
            this.guna2Panel2.Controls.Add(this.label13);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_address);
            this.guna2Panel2.Controls.Add(this.label12);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_password);
            this.guna2Panel2.Controls.Add(this.label11);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_username);
            this.guna2Panel2.Controls.Add(this.label10);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_mnv);
            this.guna2Panel2.Controls.Add(this.label9);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_phone);
            this.guna2Panel2.Controls.Add(this.label8);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_email);
            this.guna2Panel2.Controls.Add(this.guna2PictureBox_img);
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Controls.Add(this.guna2DateTimePicker_dateofbirth);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.guna2CustomRadioButton_nu);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.guna2CustomRadioButton_nam);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.guna2TextBox_name);
            this.guna2Panel2.Location = new System.Drawing.Point(17, 84);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1203, 285);
            this.guna2Panel2.TabIndex = 4;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // guna2Button1_upload
            // 
            this.guna2Button1_upload.BorderRadius = 12;
            this.guna2Button1_upload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1_upload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1_upload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1_upload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1_upload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2Button1_upload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1_upload.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1_upload.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1_upload.Image")));
            this.guna2Button1_upload.Location = new System.Drawing.Point(33, 231);
            this.guna2Button1_upload.Name = "guna2Button1_upload";
            this.guna2Button1_upload.Size = new System.Drawing.Size(150, 34);
            this.guna2Button1_upload.TabIndex = 31;
            this.guna2Button1_upload.Text = "Tải ảnh lên";
            this.guna2Button1_upload.Click += new System.EventHandler(this.guna2Button1_upload_Click);
            // 
            // guna2ComboBox_role
            // 
            this.guna2ComboBox_role.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox_role.DataSource = this.roleBindingSource;
            this.guna2ComboBox_role.DisplayMember = "rolename";
            this.guna2ComboBox_role.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox_role.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox_role.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guna2ComboBox_role.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox_role.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2ComboBox_role.HoverState.ForeColor = System.Drawing.Color.Black;
            this.guna2ComboBox_role.ItemHeight = 30;
            this.guna2ComboBox_role.Location = new System.Drawing.Point(1022, 22);
            this.guna2ComboBox_role.Name = "guna2ComboBox_role";
            this.guna2ComboBox_role.Size = new System.Drawing.Size(148, 36);
            this.guna2ComboBox_role.TabIndex = 30;
            this.guna2ComboBox_role.ValueMember = "roleid";
            // 
            // roleBindingSource
            // 
            this.roleBindingSource.DataMember = "role";
            this.roleBindingSource.DataSource = this.bookShopRole;
            // 
            // bookShopRole
            // 
            this.bookShopRole.DataSetName = "BookShopRole";
            this.bookShopRole.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // guna2ComboBox_calam
            // 
            this.guna2ComboBox_calam.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox_calam.DataSource = this.shiftBindingSource;
            this.guna2ComboBox_calam.DisplayMember = "name";
            this.guna2ComboBox_calam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox_calam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox_calam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox_calam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox_calam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox_calam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox_calam.ItemHeight = 30;
            this.guna2ComboBox_calam.Location = new System.Drawing.Point(1022, 135);
            this.guna2ComboBox_calam.Name = "guna2ComboBox_calam";
            this.guna2ComboBox_calam.Size = new System.Drawing.Size(148, 36);
            this.guna2ComboBox_calam.TabIndex = 29;
            this.guna2ComboBox_calam.ValueMember = "shiftid";
            // 
            // shiftBindingSource
            // 
            this.shiftBindingSource.DataMember = "shift";
            this.shiftBindingSource.DataSource = this.bookShopShift;
            // 
            // bookShopShift
            // 
            this.bookShopShift.DataSetName = "BookShopShift";
            this.bookShopShift.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(939, 147);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 16);
            this.label17.TabIndex = 28;
            this.label17.Text = "Ca làm việc";
            // 
            // guna2TextBox_hesoluong
            // 
            this.guna2TextBox_hesoluong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_hesoluong.DefaultText = "";
            this.guna2TextBox_hesoluong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_hesoluong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_hesoluong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_hesoluong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_hesoluong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_hesoluong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_hesoluong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_hesoluong.Location = new System.Drawing.Point(665, 201);
            this.guna2TextBox_hesoluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_hesoluong.Name = "guna2TextBox_hesoluong";
            this.guna2TextBox_hesoluong.PasswordChar = '\0';
            this.guna2TextBox_hesoluong.PlaceholderText = "";
            this.guna2TextBox_hesoluong.SelectedText = "";
            this.guna2TextBox_hesoluong.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_hesoluong.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(585, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 16);
            this.label16.TabIndex = 26;
            this.label16.Text = "Hệ số lương";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(939, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "Role";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(204, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "CCCD";
            // 
            // guna2TextBox_cccd
            // 
            this.guna2TextBox_cccd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_cccd.DefaultText = "";
            this.guna2TextBox_cccd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_cccd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_cccd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_cccd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_cccd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_cccd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_cccd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_cccd.Location = new System.Drawing.Point(286, 155);
            this.guna2TextBox_cccd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_cccd.Name = "guna2TextBox_cccd";
            this.guna2TextBox_cccd.PasswordChar = '\0';
            this.guna2TextBox_cccd.PlaceholderText = "";
            this.guna2TextBox_cccd.SelectedText = "";
            this.guna2TextBox_cccd.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_cccd.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(203, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Địa chỉ";
            // 
            // guna2TextBox_address
            // 
            this.guna2TextBox_address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_address.DefaultText = "";
            this.guna2TextBox_address.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_address.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_address.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_address.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_address.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_address.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_address.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_address.Location = new System.Drawing.Point(286, 247);
            this.guna2TextBox_address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_address.Name = "guna2TextBox_address";
            this.guna2TextBox_address.PasswordChar = '\0';
            this.guna2TextBox_address.PlaceholderText = "";
            this.guna2TextBox_address.SelectedText = "";
            this.guna2TextBox_address.Size = new System.Drawing.Size(633, 24);
            this.guna2TextBox_address.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(585, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Password";
            // 
            // guna2TextBox_password
            // 
            this.guna2TextBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_password.DefaultText = "";
            this.guna2TextBox_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_password.Location = new System.Drawing.Point(665, 155);
            this.guna2TextBox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_password.Name = "guna2TextBox_password";
            this.guna2TextBox_password.PasswordChar = '\0';
            this.guna2TextBox_password.PlaceholderText = "";
            this.guna2TextBox_password.SelectedText = "";
            this.guna2TextBox_password.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_password.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(585, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Username";
            // 
            // guna2TextBox_username
            // 
            this.guna2TextBox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_username.DefaultText = "";
            this.guna2TextBox_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_username.Location = new System.Drawing.Point(665, 112);
            this.guna2TextBox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_username.Name = "guna2TextBox_username";
            this.guna2TextBox_username.PasswordChar = '\0';
            this.guna2TextBox_username.PlaceholderText = "";
            this.guna2TextBox_username.SelectedText = "";
            this.guna2TextBox_username.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_username.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(587, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "MNV";
            // 
            // guna2TextBox_mnv
            // 
            this.guna2TextBox_mnv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_mnv.DefaultText = "";
            this.guna2TextBox_mnv.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_mnv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_mnv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_mnv.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_mnv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_mnv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_mnv.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_mnv.Location = new System.Drawing.Point(665, 64);
            this.guna2TextBox_mnv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_mnv.Name = "guna2TextBox_mnv";
            this.guna2TextBox_mnv.PasswordChar = '\0';
            this.guna2TextBox_mnv.PlaceholderText = "";
            this.guna2TextBox_mnv.ReadOnly = true;
            this.guna2TextBox_mnv.SelectedText = "";
            this.guna2TextBox_mnv.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_mnv.TabIndex = 15;
            this.guna2TextBox_mnv.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(586, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "SĐT";
            // 
            // guna2TextBox_phone
            // 
            this.guna2TextBox_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_phone.DefaultText = "";
            this.guna2TextBox_phone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_phone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_phone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_phone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_phone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_phone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_phone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_phone.Location = new System.Drawing.Point(665, 22);
            this.guna2TextBox_phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_phone.Name = "guna2TextBox_phone";
            this.guna2TextBox_phone.PasswordChar = '\0';
            this.guna2TextBox_phone.PlaceholderText = "";
            this.guna2TextBox_phone.SelectedText = "";
            this.guna2TextBox_phone.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_phone.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Email";
            // 
            // guna2TextBox_email
            // 
            this.guna2TextBox_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_email.DefaultText = "";
            this.guna2TextBox_email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_email.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_email.Location = new System.Drawing.Point(286, 200);
            this.guna2TextBox_email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_email.Name = "guna2TextBox_email";
            this.guna2TextBox_email.PasswordChar = '\0';
            this.guna2TextBox_email.PlaceholderText = "";
            this.guna2TextBox_email.SelectedText = "";
            this.guna2TextBox_email.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_email.TabIndex = 11;
            // 
            // guna2PictureBox_img
            // 
            this.guna2PictureBox_img.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox_img.Image")));
            this.guna2PictureBox_img.ImageRotate = 0F;
            this.guna2PictureBox_img.Location = new System.Drawing.Point(33, 25);
            this.guna2PictureBox_img.Name = "guna2PictureBox_img";
            this.guna2PictureBox_img.Size = new System.Drawing.Size(147, 200);
            this.guna2PictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox_img.TabIndex = 9;
            this.guna2PictureBox_img.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ngày sinh";
            // 
            // guna2DateTimePicker_dateofbirth
            // 
            this.guna2DateTimePicker_dateofbirth.BackColor = System.Drawing.Color.White;
            this.guna2DateTimePicker_dateofbirth.Checked = true;
            this.guna2DateTimePicker_dateofbirth.CustomFormat = "dd/MM/yyyy";
            this.guna2DateTimePicker_dateofbirth.FillColor = System.Drawing.Color.DarkGray;
            this.guna2DateTimePicker_dateofbirth.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2DateTimePicker_dateofbirth.ForeColor = System.Drawing.Color.White;
            this.guna2DateTimePicker_dateofbirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker_dateofbirth.Location = new System.Drawing.Point(286, 109);
            this.guna2DateTimePicker_dateofbirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker_dateofbirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker_dateofbirth.Name = "guna2DateTimePicker_dateofbirth";
            this.guna2DateTimePicker_dateofbirth.Size = new System.Drawing.Size(254, 27);
            this.guna2DateTimePicker_dateofbirth.TabIndex = 7;
            this.guna2DateTimePicker_dateofbirth.Value = new System.DateTime(2024, 3, 14, 15, 32, 55, 367);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nữ";
            // 
            // guna2CustomRadioButton_nu
            // 
            this.guna2CustomRadioButton_nu.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton_nu.CheckedState.BorderThickness = 0;
            this.guna2CustomRadioButton_nu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton_nu.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CustomRadioButton_nu.Location = new System.Drawing.Point(407, 68);
            this.guna2CustomRadioButton_nu.Name = "guna2CustomRadioButton_nu";
            this.guna2CustomRadioButton_nu.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomRadioButton_nu.TabIndex = 4;
            this.guna2CustomRadioButton_nu.Text = "guna2CustomRadioButton2";
            this.guna2CustomRadioButton_nu.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CustomRadioButton_nu.UncheckedState.BorderThickness = 2;
            this.guna2CustomRadioButton_nu.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomRadioButton_nu.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nam";
            // 
            // guna2CustomRadioButton_nam
            // 
            this.guna2CustomRadioButton_nam.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton_nam.CheckedState.BorderThickness = 0;
            this.guna2CustomRadioButton_nam.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton_nam.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CustomRadioButton_nam.Location = new System.Drawing.Point(286, 68);
            this.guna2CustomRadioButton_nam.Name = "guna2CustomRadioButton_nam";
            this.guna2CustomRadioButton_nam.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomRadioButton_nam.TabIndex = 2;
            this.guna2CustomRadioButton_nam.Text = "guna2CustomRadioButton1";
            this.guna2CustomRadioButton_nam.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CustomRadioButton_nam.UncheckedState.BorderThickness = 2;
            this.guna2CustomRadioButton_nam.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomRadioButton_nam.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // guna2TextBox_name
            // 
            this.guna2TextBox_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox_name.DefaultText = "";
            this.guna2TextBox_name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox_name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox_name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox_name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox_name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox_name.Location = new System.Drawing.Point(286, 25);
            this.guna2TextBox_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox_name.Name = "guna2TextBox_name";
            this.guna2TextBox_name.PasswordChar = '\0';
            this.guna2TextBox_name.PlaceholderText = "";
            this.guna2TextBox_name.SelectedText = "";
            this.guna2TextBox_name.Size = new System.Drawing.Size(254, 24);
            this.guna2TextBox_name.TabIndex = 0;
            // 
            // guna2Button_add
            // 
            this.guna2Button_add.BorderRadius = 12;
            this.guna2Button_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_add.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button_add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_add.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_add.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_add.Image")));
            this.guna2Button_add.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button_add.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button_add.Location = new System.Drawing.Point(16, 47);
            this.guna2Button_add.Name = "guna2Button_add";
            this.guna2Button_add.Size = new System.Drawing.Size(180, 35);
            this.guna2Button_add.TabIndex = 5;
            this.guna2Button_add.Text = "Thêm";
            this.guna2Button_add.Click += new System.EventHandler(this.guna2Button_add_Click);
            // 
            // guna2Button_update
            // 
            this.guna2Button_update.BorderRadius = 12;
            this.guna2Button_update.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_update.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_update.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_update.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button_update.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_update.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_update.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_update.Image")));
            this.guna2Button_update.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button_update.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button_update.Location = new System.Drawing.Point(219, 47);
            this.guna2Button_update.Name = "guna2Button_update";
            this.guna2Button_update.Size = new System.Drawing.Size(180, 35);
            this.guna2Button_update.TabIndex = 6;
            this.guna2Button_update.Text = "Sửa";
            this.guna2Button_update.Click += new System.EventHandler(this.guna2Button_update_Click);
            // 
            // guna2Button_del
            // 
            this.guna2Button_del.BorderRadius = 12;
            this.guna2Button_del.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_del.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_del.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_del.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_del.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button_del.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_del.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_del.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_del.Image")));
            this.guna2Button_del.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button_del.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button_del.Location = new System.Drawing.Point(423, 47);
            this.guna2Button_del.Name = "guna2Button_del";
            this.guna2Button_del.Size = new System.Drawing.Size(180, 35);
            this.guna2Button_del.TabIndex = 7;
            this.guna2Button_del.Text = "Xóa";
            this.guna2Button_del.Click += new System.EventHandler(this.guna2Button_del_Click);
            // 
            // guna2Button_save
            // 
            this.guna2Button_save.BorderRadius = 12;
            this.guna2Button_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_save.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button_save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_save.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_save.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_save.Image")));
            this.guna2Button_save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button_save.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button_save.Location = new System.Drawing.Point(626, 47);
            this.guna2Button_save.Name = "guna2Button_save";
            this.guna2Button_save.Size = new System.Drawing.Size(180, 35);
            this.guna2Button_save.TabIndex = 8;
            this.guna2Button_save.Text = "Lưu";
            this.guna2Button_save.Click += new System.EventHandler(this.guna2Button_save_Click);
            // 
            // guna2Button_print
            // 
            this.guna2Button_print.BorderRadius = 12;
            this.guna2Button_print.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_print.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_print.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_print.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_print.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button_print.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_print.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_print.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_print.Image")));
            this.guna2Button_print.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button_print.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button_print.Location = new System.Drawing.Point(825, 47);
            this.guna2Button_print.Name = "guna2Button_print";
            this.guna2Button_print.Size = new System.Drawing.Size(180, 35);
            this.guna2Button_print.TabIndex = 9;
            this.guna2Button_print.Text = "In";
            this.guna2Button_print.Click += new System.EventHandler(this.guna2Button_print_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 12;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button1.Location = new System.Drawing.Point(1028, 47);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 35);
            this.guna2Button1.TabIndex = 10;
            this.guna2Button1.Text = "Thoát";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2HtmlLabel1_tb
            // 
            this.guna2HtmlLabel1_tb.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1_tb.Location = new System.Drawing.Point(224, 16);
            this.guna2HtmlLabel1_tb.Name = "guna2HtmlLabel1_tb";
            this.guna2HtmlLabel1_tb.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel1_tb.TabIndex = 11;
            this.guna2HtmlLabel1_tb.Text = null;
            // 
            // roleTableAdapter
            // 
            this.roleTableAdapter.ClearBeforeFill = true;
            // 
            // shiftTableAdapter
            // 
            this.shiftTableAdapter.ClearBeforeFill = true;
            // 
            // shiftname
            // 
            this.shiftname.FillWeight = 56.19431F;
            this.shiftname.HeaderText = "Ca";
            this.shiftname.MinimumWidth = 6;
            this.shiftname.Name = "shiftname";
            // 
            // rolename
            // 
            this.rolename.FillWeight = 56.19431F;
            this.rolename.HeaderText = "Role";
            this.rolename.MinimumWidth = 6;
            this.rolename.Name = "rolename";
            // 
            // luongcoban
            // 
            this.luongcoban.FillWeight = 56.19431F;
            this.luongcoban.HeaderText = "Lương cơ bản";
            this.luongcoban.MinimumWidth = 6;
            this.luongcoban.Name = "luongcoban";
            // 
            // password
            // 
            this.password.FillWeight = 56.19431F;
            this.password.HeaderText = "Password";
            this.password.MinimumWidth = 6;
            this.password.Name = "password";
            // 
            // username
            // 
            this.username.FillWeight = 56.19431F;
            this.username.HeaderText = "Username";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            // 
            // avatar
            // 
            this.avatar.FillWeight = 56.19431F;
            this.avatar.HeaderText = "Ảnh đại diện";
            this.avatar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.avatar.MinimumWidth = 6;
            this.avatar.Name = "avatar";
            this.avatar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.avatar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cccd
            // 
            this.cccd.FillWeight = 56.19431F;
            this.cccd.HeaderText = "CCCD";
            this.cccd.MinimumWidth = 6;
            this.cccd.Name = "cccd";
            // 
            // email
            // 
            this.email.FillWeight = 56.19431F;
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            // 
            // phone
            // 
            this.phone.FillWeight = 56.19431F;
            this.phone.HeaderText = "Điện thoại ";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            // 
            // address
            // 
            this.address.HeaderText = "Địa chỉ";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            // 
            // date_of_birth
            // 
            this.date_of_birth.FillWeight = 56.19431F;
            this.date_of_birth.HeaderText = "Ngày sinh";
            this.date_of_birth.MinimumWidth = 6;
            this.date_of_birth.Name = "date_of_birth";
            // 
            // sex
            // 
            this.sex.FillWeight = 56.19431F;
            this.sex.HeaderText = "Giới tính";
            this.sex.MinimumWidth = 6;
            this.sex.Name = "sex";
            // 
            // fullname
            // 
            this.fullname.FillWeight = 56.19431F;
            this.fullname.HeaderText = "Họ và tên";
            this.fullname.MinimumWidth = 6;
            this.fullname.Name = "fullname";
            // 
            // mnv
            // 
            this.mnv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mnv.FillWeight = 60F;
            this.mnv.HeaderText = "Mã nhân viên";
            this.mnv.MinimumWidth = 6;
            this.mnv.Name = "mnv";
            this.mnv.Width = 113;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 30;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mnv,
            this.fullname,
            this.sex,
            this.date_of_birth,
            this.address,
            this.phone,
            this.email,
            this.cccd,
            this.avatar,
            this.username,
            this.password,
            this.luongcoban,
            this.rolename,
            this.shiftname});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1203, 330);
            this.guna2DataGridView1.TabIndex = 0;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 30;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.guna2DataGridView1);
            this.guna2Panel1.Location = new System.Drawing.Point(17, 371);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1203, 330);
            this.guna2Panel1.TabIndex = 3;
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchUser.DefaultText = "";
            this.txtSearchUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchUser.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearchUser.IconRight")));
            this.txtSearchUser.Location = new System.Drawing.Point(218, 6);
            this.txtSearchUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.PasswordChar = '\0';
            this.txtSearchUser.PlaceholderText = "";
            this.txtSearchUser.SelectedText = "";
            this.txtSearchUser.Size = new System.Drawing.Size(447, 38);
            this.txtSearchUser.TabIndex = 13;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.txtSearchUser_TextChanged);
            // 
            // User_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 701);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.guna2HtmlLabel1_tb);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button_print);
            this.Controls.Add(this.guna2Button_save);
            this.Controls.Add(this.guna2Button_del);
            this.Controls.Add(this.guna2Button_update);
            this.Controls.Add(this.guna2Button_add);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_Management";
            this.Text = "User_Management";
            this.Load += new System.EventHandler(this.User_Management_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button_add;
        private Guna.UI2.WinForms.Guna2Button guna2Button_update;
        private Guna.UI2.WinForms.Guna2Button guna2Button_del;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_name;
        private Guna.UI2.WinForms.Guna2Button guna2Button_save;
        private Guna.UI2.WinForms.Guna2Button guna2Button_print;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CustomRadioButton_nu;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CustomRadioButton_nam;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox_img;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker_dateofbirth;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_password;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_username;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_mnv;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_phone;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_email;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_address;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_cccd;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox_hesoluong;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox_role;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox_calam;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2Button guna2Button1_upload;     
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1_tb;
        private BookShopRole bookShopRole;
        private BindingSource roleBindingSource;
        private BookShopRoleTableAdapters.roleTableAdapter roleTableAdapter;
        private BookShopShift bookShopShift;
        private BindingSource shiftBindingSource;
        private BookShopShiftTableAdapters.shiftTableAdapter shiftTableAdapter;
        private DataGridViewTextBoxColumn shiftname;
        private DataGridViewTextBoxColumn rolename;
        private DataGridViewTextBoxColumn luongcoban;
        private DataGridViewTextBoxColumn password;
        private DataGridViewTextBoxColumn username;
        private DataGridViewImageColumn avatar;
        private DataGridViewTextBoxColumn cccd;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn date_of_birth;
        private DataGridViewTextBoxColumn sex;
        private DataGridViewTextBoxColumn fullname;
        private DataGridViewTextBoxColumn mnv;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchUser;
    }
}