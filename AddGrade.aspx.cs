using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class AddGrade : System.Web.UI.Page
{
    protected void btnAddGrade_Click(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "INSERT INTO Grades (GradeName) VALUES (@name)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtGradeName.Text);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "✅ تم إضافة الصف بنجاح.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ خطأ: " + ex.Message;
            }
        }
    }
}
