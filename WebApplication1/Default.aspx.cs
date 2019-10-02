using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //SqlCommand cmd = new SqlCommand("Select * from tblProduct", conn);
                //SqlCommand cmd = new SqlCommand("Select Count(ProductId) from tblProduct", conn);
                //SqlCommand cmd = new SqlCommand("Insert into tblProduct values ('Calculators', 100, 230)", conn);
                //SqlCommand cmd = new SqlCommand("update tblProduct set QtyAvailable = 200 where ProductId = 2", conn);
                //conn.Open();

                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();

                //int TotalRows = (int)cmd.ExecuteScalar();
                //Response.Write("Total Rows = " + TotalRows.ToString());

                //int TotalRowsAffected = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows Inserted = " + TotalRowsAffected.ToString());

                //int TotalRowsAffected = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows Updated = " + TotalRowsAffected.ToString());

            } 
        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string sqlQuery = "Select * from tblStudents where ID = " + txtStudentID.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, conn);

            DataSet dSet = new DataSet();
            dataAdapter.Fill(dSet, "Students");

            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = dSet;

            if(dSet.Tables["Students"].Rows.Count > 0)
            {
                DataRow dataRow = dSet.Tables["Students"].Rows[0];
                txtStudentName.Text = dataRow["Name"].ToString();
                txtTotalMarks.Text = dataRow["TotalMarks"].ToString();
                ddlGender.SelectedValue = dataRow["Gender"].ToString();

            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No student record with ID = " + txtStudentID.Text;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter dataAdapter = new SqlDataAdapter((string)ViewState["SQL_QUERY"], conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            DataSet dSet = (DataSet)ViewState["DATASET"];

            if(dSet.Tables["Students"].Rows.Count > 0)
            {
                DataRow dataRow = dSet.Tables["Students"].Rows[0];
                dataRow["Name"] = txtStudentName.Text;
                dataRow["Gender"] = ddlGender.SelectedValue;
                dataRow["TotalMarks"] = txtTotalMarks.Text;
            } 

            int rowsUpdated = dataAdapter.Update(dSet, "Students");

            if (rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated + " row updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No row updated";
            }
        }
    }
    
}