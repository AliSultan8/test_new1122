using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class StudentsList : System.Web.UI.Page
{
    private string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents(0);
        }
    }

    private void LoadStudents(int pageIndex)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"
                SELECT s.StudentID, s.FullName, s.FatherName, s.MotherName, s.BirthDate, s.PhoneNumber, s.Area, g.GradeName
                FROM Students s
                INNER JOIN Grades g ON s.GradeID = g.GradeID
                ORDER BY s.StudentID
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Offset", pageIndex * 10);
            cmd.Parameters.AddWithValue("@PageSize", 10);

            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gvStudents.DataSource = dt;
                gvStudents.PageIndex = pageIndex;
                gvStudents.DataBind();
            }
            catch (Exception ex)
            {
              
            }
        }
    }

    protected void gvStudents_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        LoadStudents(e.NewPageIndex);
    }
}
