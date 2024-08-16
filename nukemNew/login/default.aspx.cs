using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.login
{
    public partial class _default : System.Web.UI.Page
    {
        /*
         * this function computes the SHA256 hash of a string
         * input: string
         * output: SHA256 hash of the string
         */
        protected string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];

            errorMessage.Visible = false;
            if (IsPostBack)
            {
                // connect to the database and get the user data from the database
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT userId, username, password, admin FROM tblUsers WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", Request.Form["username"]);
                cmd.Parameters.AddWithValue("@password", ComputeSha256Hash(Request.Form["password"]));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["username"] = Request.Form["username"]; // store the username in the session
                    Session["login"] = true; // set the login session variable to true
                    Session["admin"] = (bool)dt.Rows[0]["admin"]; // set the admin session variable to the value from the database
                    Session["userId"] = dt.Rows[0]["userId"].ToString(); // set the userId session variable to the value from the database
                                                                      //errorMessage.Visible = false;
                    errorMessage.InnerText = ""; // clear the error message
                    Response.Redirect("../"); // redirect to the home page
                }
                else
                {
                    Session["username"] = "Guest";
                    Session["login"] = false;
                    Session["admin"] = false;
                    Session["userId"] = -1;
                    errorMessage.Visible = true;
                    errorMessage.InnerText = "Invalid username or password";
                }
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("/");
        }
    }
}