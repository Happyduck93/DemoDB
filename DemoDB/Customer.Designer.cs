namespace DemoDB
{
    partial class Customer
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
            this.pnlSeach = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdCustomer = new System.Windows.Forms.DataGridView();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIRTH_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POINVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSeach
            // 
            this.pnlSeach.BackColor = System.Drawing.SystemColors.Info;
            this.pnlSeach.Controls.Add(this.btnDelete);
            this.pnlSeach.Controls.Add(this.btnSave);
            this.pnlSeach.Controls.Add(this.btnAdd);
            this.pnlSeach.Controls.Add(this.btnSearch);
            this.pnlSeach.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeach.Location = new System.Drawing.Point(0, 0);
            this.pnlSeach.Name = "pnlSeach";
            this.pnlSeach.Size = new System.Drawing.Size(800, 125);
            this.pnlSeach.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(705, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(705, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(705, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(559, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdCustomer
            // 
            this.grdCustomer.AllowUserToAddRows = false;
            this.grdCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUSTOMER_ID,
            this.NAME,
            this.ADDRESS,
            this.PHONE,
            this.BIRTH_DATE,
            this.POINVT});
            this.grdCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomer.Location = new System.Drawing.Point(0, 125);
            this.grdCustomer.Name = "grdCustomer";
            this.grdCustomer.RowHeadersWidth = 51;
            this.grdCustomer.Size = new System.Drawing.Size(800, 325);
            this.grdCustomer.TabIndex = 1;
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.HeaderText = "CUSTOMER ID";
            this.CUSTOMER_ID.MinimumWidth = 6;
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.Width = 125;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "NAME";
            this.NAME.MinimumWidth = 6;
            this.NAME.Name = "NAME";
            this.NAME.Width = 125;
            // 
            // ADDRESS
            // 
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "ADDRESS";
            this.ADDRESS.MinimumWidth = 6;
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.Width = 125;
            // 
            // PHONE
            // 
            this.PHONE.DataPropertyName = "PHONE";
            this.PHONE.HeaderText = "PHONE";
            this.PHONE.MinimumWidth = 6;
            this.PHONE.Name = "PHONE";
            this.PHONE.Width = 125;
            // 
            // BIRTH_DATE
            // 
            this.BIRTH_DATE.DataPropertyName = "BIRTH_DATEVV";
            this.BIRTH_DATE.HeaderText = "BIRTH DATE";
            this.BIRTH_DATE.MinimumWidth = 6;
            this.BIRTH_DATE.Name = "BIRTH_DATE";
            this.BIRTH_DATE.Width = 125;
            // 
            // POINVT
            // 
            this.POINVT.DataPropertyName = "POINVT";
            this.POINVT.HeaderText = "POINT";
            this.POINVT.MinimumWidth = 6;
            this.POINVT.Name = "POINVT";
            this.POINVT.Width = 125;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdCustomer);
            this.Controls.Add(this.pnlSeach);
            this.Name = "Customer";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Customer_Load);
            this.pnlSeach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeach;
        private System.Windows.Forms.DataGridView grdCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIRTH_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn POINVT;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
    }
}