using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class AddTeacher : System.Web.UI.Page
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
            string query = "SELECT SubjectID, SubjectName FROM Subjects";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chkSubjects.DataSource = reader;
                chkSubjects.DataTextField = "SubjectName";
                chkSubjects.DataValueField = "SubjectID";
                chkSubjects.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "خطأ في تحميل المواد: " + ex.Message;
            }
        }
    }

    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        if (txtTeacherBirthDate.Text.Length > 0 && txtTeacherName.Text.Length > 0 && txtTeacherFname.Text.Length > 0 && txtTeacherMname.Text.Length > 0 && txtTeacherPhone.Text.Length > 0)
        {
            DateTime birthDate;
            if (!DateTime.TryParse(txtTeacherBirthDate.Text.Trim(), out birthDate))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ يرجى إدخال تاريخ ميلاد صحيح.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // إدخال المدرس
                    string queryInsertTeacher = @"
                    INSERT INTO Teachers 
                    (FullName, FatherName, MotherName, BirthDate, PhoneNumber) 
                    VALUES (@name, @father, @mother, @birthdate, @phone);
                    SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmdInsertTeacher = new SqlCommand(queryInsertTeacher, conn, transaction);
                    cmdInsertTeacher.Parameters.AddWithValue("@name", txtTeacherName.Text.Trim());
                    cmdInsertTeacher.Parameters.AddWithValue("@father", txtTeacherFname.Text.Trim());
                    cmdInsertTeacher.Parameters.AddWithValue("@mother", txtTeacherMname.Text.Trim());
                    cmdInsertTeacher.Parameters.AddWithValue("@birthdate", birthDate);
                    cmdInsertTeacher.Parameters.AddWithValue("@phone", txtTeacherPhone.Text.Trim());

                    int teacherID = (int)cmdInsertTeacher.ExecuteScalar();

                    // إدخال المواد التي يدرسها المدرس
                    foreach (var item in chkSubjects.Items)
                    {
                        var cb = item as System.Web.UI.WebControls.ListItem;
                        if (cb.Selected)
                        {
                            string queryInsertTeacherSubject = @"
                            INSERT INTO TeacherSubjects (TeacherID, SubjectID) VALUES (@teacherID, @subjectID)";
                            SqlCommand cmdTS = new SqlCommand(queryInsertTeacherSubject, conn, transaction);
                            cmdTS.Parameters.AddWithValue("@teacherID", teacherID);
                            cmdTS.Parameters.AddWithValue("@subjectID", int.Parse(cb.Value));
                            cmdTS.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ تم إضافة المدرس والمواد بنجاح.";

                    // مسح الحقول
                    txtTeacherName.Text = "";
                    txtTeacherFname.Text = "";
                    txtTeacherMname.Text = "";
                    txtTeacherBirthDate.Text = "";
                    txtTeacherPhone.Text = "";
                    foreach (System.Web.UI.WebControls.ListItem item in chkSubjects.Items)
                        item.Selected = false;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();

                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "❌ حدث خطأ: " + ex.Message;
                }
            }
        }
        else {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "❌ يرجى ملأ كل المدخلات ";
        }
    }
}
