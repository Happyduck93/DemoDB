using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDB.UserControls
{
    public partial class DatePicker : Form
    {
        public DateTime selectedDate;
        public DatePicker()
        {
            InitializeComponent();
        }

        private void DatePicker_Load(object sender, EventArgs e)
        {
            //when popUp

            monCalendar.SetDate(selectedDate);

        }


        private void monCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = monCalendar.SelectionRange.Start;
            //close
            this.Close();
        }
    }
}
