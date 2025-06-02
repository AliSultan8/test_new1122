
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class QueryBySubject : System.Web.UI.Page
{
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT StudentName, Mark FROM Marks WHERE SubjectName = @subject";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
