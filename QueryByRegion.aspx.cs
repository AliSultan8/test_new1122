using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class QueryByRegion : System.Web.UI.Page
{
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string region = txtRegion.Text.Trim();
        if (string.IsNullOrEmpty(region))
        {
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "❌ يرجى إدخال اسم المنطقة.";
            return;
        }

        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT COUNT(*) FROM Students WHERE Area = @region";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@region", region);

            try
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "عدد الطلاب في المنطقة  هو:"+count.ToString();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "❌ حدث خطأ: " + ex.Message;
            }
        }
    }
}
