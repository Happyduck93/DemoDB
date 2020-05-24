using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoDB.UserControls;


namespace DemoDB
{
    public partial class Product : Form
    {
        //window
        // public const string strConnection = @"Server=LAPTOP-EAMRK4NF;database=DemoDatabase;Integrated Security=True;";


        public const string strConnection = @"Server=LAPTOP-EAMRK4NF;database=DemoDatabase;uid=Happy; pwd = Happyduck04;";


        public Product()
        {
            InitializeComponent();
        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {

        }


        private void defaultSetting()
        {
            //접속
            SqlConnection connection = new SqlConnection(strConnection);
            string query = "SELECT CODE_ID, CODE_DESCR" +// can use @ instead of +
                " FROM TB_CODE_MST " +
                " WHERE CATEGORY_ID = 'PRODUCT_TYPE'";
            //명령(왔다갔다 하는 사람)
            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            // 비쥬얼 스튜디오에서 보여지는 테이블 (데이타베이스에서 가져온걸 복붙)
            DataTable comboData = new DataTable();

            // object is valid only insde using brackets
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(comboData);

            }

            connection.Close();

            (grdProduct.Columns["CATEGORY"] as DataGridViewComboBoxColumn).DataSource = comboData;
            (grdProduct.Columns["CATEGORY"] as DataGridViewComboBoxColumn).DisplayMember = "CODE_DESCR";
            (grdProduct.Columns["CATEGORY"] as DataGridViewComboBoxColumn).ValueMember = "CODE_ID";




        }


        private void SearchData()
        {

            //접속
            SqlConnection connection = new SqlConnection(strConnection);

            string query = "select * from TB_PRODUCT_INFO";

            //명령
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();

            DataTable dataSource = new DataTable();

            // object is valid only insde using brackets
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dataSource);

            }

            connection.Close();

            grdProduct.DataSource = dataSource;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //(DataTable)grdProduct.DateSource
            (grdProduct.DataSource as DataTable).Rows.Add();


            //change the last row color
            grdProduct.Rows[grdProduct.RowCount - 1].DefaultCellStyle.BackColor = Color.Yellow;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int rowIndex = grdProduct.RowCount - 1; rowIndex >= 0; rowIndex--)
            {
                //string
                var selected = grdProduct.Rows[rowIndex].Cells["SELECT"].Value;
                if (selected != null && selected.Equals("true")) // string == "true"
                {
                    ((DataTable)grdProduct.DataSource).Rows[rowIndex].Delete();
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //alt + shift 

            DataTable source = grdProduct.DataSource as DataTable;
            //source.GetChanges();
            DataTable updateDt = source.GetChanges(DataRowState.Modified);
            DataTable insertDt = source.GetChanges(DataRowState.Added);
            DataTable deleteDt = source.GetChanges(DataRowState.Deleted);

            //updateDt != null
            if (updateDt != null && updateDt.Rows.Count > 0)
            {
                UpdateData(updateDt);
            }
            if (insertDt != null && insertDt.Rows.Count > 0)
            {
                InsertData(insertDt);
            }
            if (deleteDt != null && deleteDt.Rows.Count > 0)
            {
                DeleteData(deleteDt);
            }
            SearchData();



        }

        private void UpdateData(DataTable dt)
        {
            SqlConnection connection = new SqlConnection(strConnection);
            string query = "UPDATE TB_PRODUCT_INFO" +
                           "   SET PRODUCT_NAME = @productName" +
                           "      ,COLOR        = @color" +
                           "      ,CATEGORY     = @category" +
                           "      ,ARRIVAL_DATE = @arrivalDate" +
                           "      ,ORIGIN       = @origin" +
                           "      ,PRICE        = @price" +
                           "      ,STOCK        = @stock" +
                           " WHERE PRODUCT_ID    = @productId";

            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@productName", dr["PRODUCT_NAME"].ToString());
                    cmd.Parameters.AddWithValue("@color", dr["COLOR"].ToString());
                    cmd.Parameters.AddWithValue("@category", dr["CATEGORY"].ToString());
                    cmd.Parameters.AddWithValue("@arrivalDate", dr["ARRIVAL_DATE"].ToString());
                    cmd.Parameters.AddWithValue("@origin", dr["ORIGIN"].ToString());
                    cmd.Parameters.AddWithValue("@price", dr["PRICE"]);
                    cmd.Parameters.AddWithValue("@stock", dr["STOCK"]);
                    cmd.Parameters.AddWithValue("@productId", dr["PRODUCT_ID"].ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();
        }





        private void InsertData(DataTable dt)
        {
            SqlConnection connection = new SqlConnection(strConnection);
            string query = @"INSERT INTO TB_PRODUCT_INFO
                           (  PRODUCT_ID
                              ,PRODUCT_NAME 
                              ,COLOR          
                              ,CATEGORY         
                              ,ARRIVAL_DATE      
                              ,ORIGIN            
                              ,PRICE
                              ,STOCK  )
                            VALUES
                            ( @productId 
                              ,@productName
                              ,@color
                              ,@category
                              ,@arrivalDate
                              ,@origin
                              ,@price
                              ,@stock)";

            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@productName", dr["PRODUCT_NAME"].ToString());
                    cmd.Parameters.AddWithValue("@color", dr["COLOR"].ToString());
                    cmd.Parameters.AddWithValue("@category", dr["CATEGORY"].ToString());
                    cmd.Parameters.AddWithValue("@arrivalDate", dr["ARRIVAL_DATE"].ToString());
                    cmd.Parameters.AddWithValue("@origin", dr["ORIGIN"].ToString());
                    cmd.Parameters.AddWithValue("@price", dr["PRICE"]);
                    cmd.Parameters.AddWithValue("@stock", dr["STOCK"]);
                    cmd.Parameters.AddWithValue("@productId", dr["PRODUCT_ID"].ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();
        }
        private void DeleteData(DataTable dt)
        {
            //HOMEWORK.. 
           // cmd.Parameters.AddWithValue("@productID", dr["PRODUCT_ID", DataRowVersion.Original].ToString());

            SqlConnection connection = new SqlConnection(strConnection);
            string query = @"DELETE FROM TB_PRODUCT_INFO
                                WHERE PRODUCT_ID =@productID";


            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@productID", dr["PRODUCT_ID", DataRowVersion.Original].ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();


        }

        private void grdProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && !(grdProduct.Rows[e.RowIndex].IsNewRow))
            {
                grdProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
            }
        }

        private void grdProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //sender = 누가 보냄?
            // e = 셀의 정보
            //조건에 맞으면 show dialog

            //if index of column selected == arriaval date column index.
            //DO not hardcode to 5
            if (e.ColumnIndex == grdProduct.Columns["ARRIVAL_DATE"].Index)
            {
                DatePicker dp = new DatePicker();
                DateTime date;
               
                //값이 들어있을떄
                if (!grdProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(string.Empty))
                {
                    date = ((DataTable)grdProduct.DataSource).Rows[e.RowIndex].Field<DateTime>("ARRIVAL_DATE");
                }
                else 
                {
                    //아무값도 안들어있을떄
                    date = DateTime.Today.Date;
                }

                dp.selectedDate = date;
                //달력을 중간에 띄우시오(디폴트는 왼쪽위)
                dp.StartPosition = FormStartPosition.CenterParent;
                //popup > triger load event..
                dp.ShowDialog();

                date = dp.selectedDate;
                grdProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = date.Date;
                //close only the UI
                // dp.Close();

                dp.Dispose(); // <-- delete the object completely. 


            }







        }

        private void Product_Load(object sender, EventArgs e)
        {
            defaultSetting();
        }
    }
}
