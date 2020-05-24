using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DemoDB
{
    public partial class Order : Form
    {

        public const string strConnection = @"Server=LAPTOP-EAMRK4NF;database=DemoDatabase;Integrated Security=True;";

        public Order()
        {
            InitializeComponent();
        }

        private void SearchData()
        {


            //connection
            SqlConnection connection = new SqlConnection(strConnection);


            //string query = "select * from TB_ORDER_INFO";

            //command
            SqlCommand cmd = new SqlCommand("dbo.SP_SEARCH_ORDER_INFO", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();

            // DataTable dataSource = new DataTable();
            var table = new DataTable();
            // object is valid only insde using brackets.
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(table);

            }

            connection.Close();

            grdOrder.DataSource = table;


        }



        


        private void UpdateData(DataTable dt)
        {
            SqlConnection connection = new SqlConnection(strConnection);
            string query = "UPDATE TB_ORDER_INFO" +
                           "   SET CUSTOMER_ID       = @customerId" +
                           "      ,PRODUCT_ID        = @productId" +
                           "      ,ORDER_DATE        = @orderDate" +
                           "      ,QUANTITY          = @quantity" +
                           "      ,TOTAL_PRICE       = @totalPrice" +
                           "      ,PAY_TYPE          = @payType" +
                           " WHERE ORDER_ID    = @orderId";

            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@customerId", dr["CUSTOMER_ID"].ToString());
                    cmd.Parameters.AddWithValue("@productId", dr["PRODUCT_ID"].ToString());
                    cmd.Parameters.AddWithValue("@orderDate", dr["ORDER_DATE"].ToString());
                    cmd.Parameters.AddWithValue("@quantity", dr["QUANTITY"].ToString());
                    cmd.Parameters.AddWithValue("@totalPrice", dr["TOTAL_PRICE"].ToString());
                    cmd.Parameters.AddWithValue("@payType", dr["PAY_TYPE"]);
                    cmd.Parameters.AddWithValue("@orderID", dr["ORDER_ID"].ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();
        }


        private void InsertData(DataTable dt)
        {
            SqlConnection connection = new SqlConnection(strConnection);
            string query = @"INSERT INTO TB_ORDER_INFO
                           (  ORDER_ID
                              ,CUSTOMER_ID 
                              ,PRODUCT_ID          
                              ,ORDER_DATE         
                              ,QUANTITY      
                              ,TOTAL_PRICE            
                              ,PAY_TYPE)
                            VALUES
                            ( @orderId 
                              ,@customerId
                              ,@productId
                              ,@orderDate
                              ,@quantity
                              ,@totalPrice
                              ,@payType )";

            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@customerId", dr["CUSTOMER_ID"].ToString());
                    cmd.Parameters.AddWithValue("@productId", dr["PRODUCT_ID"].ToString());
                    cmd.Parameters.AddWithValue("@orderDate", dr["ORDER_DATE"].ToString());
                    cmd.Parameters.AddWithValue("@quantity", dr["QUANTITY"].ToString());
                    cmd.Parameters.AddWithValue("@totalPrice", dr["TOTAL_PRICE"].ToString());
                    cmd.Parameters.AddWithValue("@payType", dr["PAY_TYPE"]);
                    cmd.Parameters.AddWithValue("@orderID", dr["ORDER_ID"].ToString());

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
            string query = @"DELETE FROM TB_ORDER_INFO
                                WHERE ORDER_ID =@orderID";


            connection.Open();
            foreach (DataRow dr in dt.Rows)
            {
                //use this object only insde using bracket
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@orderID", dr["ORDER_ID", DataRowVersion.Original].ToString());

                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();


        }





        #region : Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }
        private void grdOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //(DataTable)grdOrder.DateSource
            (grdOrder.DataSource as DataTable).Rows.Add();


            //change the last row color
            grdOrder.Rows[grdOrder.RowCount - 1].DefaultCellStyle.BackColor = Color.Yellow;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            for (int rowIndex = grdOrder.RowCount - 1; rowIndex >= 0; rowIndex--)
            {
                //string-(true/false)
                var selected = grdOrder.Rows[rowIndex].Cells["SELECT"].Value;
                if (selected != null && selected.Equals("true")) // string == "true"
                {
                    ((DataTable)grdOrder.DataSource).Rows[rowIndex].Delete();
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //alt + shift to eddit multiple lines

            DataTable source = grdOrder.DataSource as DataTable;
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


        private void defaultSetting()
        {
            //접속
            SqlConnection connection = new SqlConnection(strConnection);
            string query = "SELECT CODE_ID, CODE_DESCR" +// can use @ instead of +
                " FROM TB_CODE_MST " +
                " WHERE CATEGORY_ID = 'PAY_TYPE'";
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

            (grdOrder.Columns["PAY_TYPE"] as DataGridViewComboBoxColumn).DataSource = comboData;
            (grdOrder.Columns["PAY_TYPE"] as DataGridViewComboBoxColumn).DisplayMember = "CODE_DESCR";
            (grdOrder.Columns["PAY_TYPE"] as DataGridViewComboBoxColumn).ValueMember = "CODE_ID";




        }



        #endregion

        private void Order_Load(object sender, EventArgs e)
        {
            defaultSetting();
        }


    }
}
