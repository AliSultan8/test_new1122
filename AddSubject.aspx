using System;
using System.Activities.Expressions;
using System.Configuration;
using System.Data.SqlClient;

public partial class AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrades();
        }
    }

    private void LoadGrades()
    {
        string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT GradeID, GradeName FROM Grades";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlGrades.DataSource = reader;
                ddlGrades.DataValueField = "GradeID";
                ddlGrades.DataTextField = "GradeName";
                ddlGrades.DataBind();

                ddlGrades.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Grade --", "0"));
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error loading grades: " + ex.Message;
            }
        }
    }

    protected void btnAddStudent_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        if (txtDate.Text.Length > 0 && txtStudent.Text.Length > 0 && txtFname.Text.Length > 0 && txtMname.Text.Length > 0 && txtRegion.Text.Length > 0 && txtPhone.Text.Length > 0)
        {
            DateTime birthDate;
            if (!DateTime.TryParse(txtDate.Text.Trim(), out birthDate))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Please enter a valid birth date.";
                return;
            }

            int gradeID;
            if (!int.TryParse(ddlGrades.SelectedValue, out gradeID) || gradeID == 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Please select the correct grade.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["StudentRegistrationSystem"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                INSERT INTO Students 
                (FullName, FatherName, MotherName, BirthDate, PhoneNumber, Area, GradeID) 
                VALUES 
                (@name, @father, @mother, @birthdate, @phone, @area, @gradeID)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", txtStudent.Text.Trim());
                cmd.Parameters.AddWithValue("@father", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@mother", txtMname.Text.Trim());
                cmd.Parameters.AddWithValue("@birthdate", birthDate);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@area", txtRegion.Text.Trim());
                cmd.Parameters.AddWithValue("@gradeID", gradeID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ Student added successfully.";

                    // Clear fields after insertion
                    txtStudent.Text = "";
                    txtFname.Text = "";
                    txtMname.Text = "";
                    txtDate.Text = "";
                    txtPhone.Text = "";
                    txtRegion.Text = "";
                    ddlGrades.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "❌ Error occurred while adding student: " + ex.Message;
                }
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "❌ Please fill all fields";
        }
    }
}