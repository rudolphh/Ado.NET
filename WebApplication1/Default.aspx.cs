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

        }

        private void GetDataFromDB()
        {
            SqlConnection conn = new SqlConnection(connStr);

            string selectQueryStr = "Select * from tblStudents";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQueryStr, conn);

            DataSet dSet = new DataSet();
            dataAdapter.Fill(dSet, "Students");

            dSet.Tables["Students"].PrimaryKey = new DataColumn[] { dSet.Tables["Students"].Columns["ID"] };
            Cache.Insert("DATASET", dSet, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            gvStudents.DataSource = dSet;
            gvStudents.DataBind();

            lblMessage.Text = "Data loaded from Database.";
        }

        private void GetDataFromCache()
        {
            if(Cache["DATASET"] != null)
            {
                DataSet dataSet = (DataSet)Cache["DATASET"];
                gvStudents.DataSource = dataSet;
                gvStudents.DataBind();
            }
        }

        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if(Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvStudents.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr.Delete();

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
            }
        }

        protected void btnUpdateDB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string selectQueryStr = "Select * from tblStudents";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQueryStr, conn);

            DataSet ds = (DataSet)Cache["DATASET"];

            string strUpdateCommand = "Update tblStudents set Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks where Id = @Id";
            SqlCommand updateCommand = new SqlCommand(strUpdateCommand, conn);
            updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
            updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            updateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            dataAdapter.UpdateCommand = updateCommand;


            string strDeleteCommand = "Delete from tblStudents where Id = @Id";
            SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, conn);
            deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            dataAdapter.DeleteCommand = deleteCommand;


            dataAdapter.Update(ds, "Students");

            lblMessage.Text = "Database Table Updated.";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            
            foreach(DataRow dr in ds.Tables["Students"].Rows)
            {
                if(dr.RowState == DataRowState.Deleted) { 
                    Response.Write(dr["ID", DataRowVersion.Original].ToString() + " - " + dr.RowState.ToString() + "<br/>");
                } 
                else
                {
                    Response.Write(dr["ID", DataRowVersion.Original].ToString() + " - " + dr.RowState.ToString() + "<br/>");
                }
            }
        }
    }
    
}