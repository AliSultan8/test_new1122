using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AddSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSubjects();
        }
    }

    private void LoadSubjects()
    {
        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT SubjectID, SubjectName, PassingGrade FROM Subjects";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvSubjects.DataSource = dt;
            gvSubjects.DataBind();
        }
    }

    protected void btnAddSubject_Click(object sender, EventArgs e)
    {
        string name = txtSubjectName.Text.Trim();
        double passingGrade;

        if (string.IsNullOrEmpty(name))
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "❌ يرجى إدخال اسم المادة.";
            return;
        }
        if (!double.TryParse(txtPassingGrade.Text.Trim(), out passingGrade))
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "❌ يرجى إدخال علامة نجاح صحيحة.";
            return;
        }

        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "INSERT INTO Subjects (SubjectName, PassingGrade) VALUES (@name, @grade)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@grade", passingGrade);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "✅ تمت إضافة المادة بنجاح.";
                txtSubjectName.Text = "";
                txtPassingGrade.Text = "";
                LoadSubjects();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ حدث خطأ: " + ex.Message;
            }
        }
    }

    protected void gvSubjects_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        gvSubjects.EditIndex = e.NewEditIndex;
        LoadSubjects();
    }

    protected void gvSubjects_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        gvSubjects.EditIndex = -1;
        LoadSubjects();
    }

    protected void gvSubjects_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        int subjectID = Convert.ToInt32(gvSubjects.DataKeys[e.RowIndex].Value);
        string newName = ((System.Web.UI.WebControls.TextBox)gvSubjects.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
        string passingGradeText = ((System.Web.UI.WebControls.TextBox)gvSubjects.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
        double newPassingGrade;

        if (string.IsNullOrEmpty(newName) || !double.TryParse(passingGradeText, out newPassingGrade))
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "❌ يرجى إدخال بيانات صحيحة.";
            return;
        }

        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "UPDATE Subjects SET SubjectName=@name, PassingGrade=@grade WHERE SubjectID=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", newName);
            cmd.Parameters.AddWithValue("@grade", newPassingGrade);
            cmd.Parameters.AddWithValue("@id", subjectID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "✅ تم تحديث المادة بنجاح.";
                gvSubjects.EditIndex = -1;
                LoadSubjects();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ حدث خطأ: " + ex.Message;
            }
        }
    }
}
