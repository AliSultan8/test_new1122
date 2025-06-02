
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class QueryByStudent : System.Web.UI.Page
{
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT SubjectName, Mark FROM Marks WHERE StudentName = @student";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@student", txtStudentName.Text);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
