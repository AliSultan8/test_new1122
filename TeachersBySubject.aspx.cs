using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class TeachersBySubject : System.Web.UI.Page
{
    private string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSubjects();
        }
    }

    private void LoadSubjects()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT SubjectID, SubjectName FROM Subjects";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlSubjects.DataSource = reader;
                ddlSubjects.DataTextField = "SubjectName";
                ddlSubjects.DataValueField = "SubjectID";
                ddlSubjects.DataBind();

                ddlSubjects.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر المادة --", "0"));
            }
            catch (Exception ex)
            {
               
            }
        }
    }

    protected void btnQueryTeachers_Click(object sender, EventArgs e)
    {
        int subjectID;
        if (!int.TryParse(ddlSubjects.SelectedValue, out subjectID) || subjectID == 0)
        {
            // Optionally show message
            return;
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"
               SELECT t.TeacherID, t.FullName, t.PhoneNumber
FROM Teachers t
INNER JOIN TeacherSubjects ts ON t.TeacherID = ts.TeacherID
WHERE ts.SubjectID = @subjectID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectID", subjectID);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                gvTeachers.DataSource = dt;
                gvTeachers.Visible = true;
                gvTeachers.DataBind();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
