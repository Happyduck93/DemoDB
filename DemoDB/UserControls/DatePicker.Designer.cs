namespace DemoDB.UserControls
{
    partial class DatePicker
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
            this.monCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // monCalendar
            // 
            this.monCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monCalendar.Location = new System.Drawing.Point(0, 0);
            this.monCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monCalendar.Name = "monCalendar";
            this.monCalendar.TabIndex = 0;
            this.monCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monCalendar_DateSelected);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 207);
            this.Controls.Add(this.monCalendar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DatePicker";
            this.Text = "DatePicker";
            this.Load += new System.EventHandler(this.DatePicker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monCalendar;
    }
}