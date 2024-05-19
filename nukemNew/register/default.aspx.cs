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

namespace nukemNew.register
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

        /*
         * this function finds the user in the database and checks if the password is correct
         * input: username, password, dataset
         * output: index of the user in the dataset, -1 if not found
         */
        protected int FindAndCheckUser(string username, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["username"].ToString() == username)
                {
                    return i;
                }
            }
            return -1;
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
                if (Request.Form["usernameInput"] == "")
                {
                    errorMessage.InnerText = "Username cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["usernameInput"].Length > 50)
                {
                    errorMessage.InnerText = "Username is too long!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["usernameInput"].Length < 3)
                {
                    errorMessage.InnerText = "Username is too short!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["emailInput"] == "")
                {
                    errorMessage.InnerText = "Email cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["emailInput"].Length > 50)
                {
                    errorMessage.InnerText = "Email is too long!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["emailInput"].Length < 3)
                {
                    errorMessage.InnerText = "Email is too short!";
                    errorMessage.Visible = true;
                }
                else if (!Request.Form["emailInput"].Contains("@") || !Request.Form["emailInput"].Contains("."))
                {
                    errorMessage.InnerText = "Email is invalid!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["passwordInput"] == "")
                {
                    errorMessage.InnerText = "Password cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["passwordInput"].Length > 50)
                {
                    errorMessage.InnerText = "Password is too long!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["passwordInput"].Length < 3)
                {
                    errorMessage.InnerText = "Password is too short!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["passwordInput"] != Request.Form["passwordConfirmInput"])
                {
                    errorMessage.InnerText = "Passwords do not match!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["passwordInput"].Contains(" "))
                {
                    errorMessage.InnerText = "Password cannot contain spaces!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["usernameInput"].Contains(" "))
                {
                    errorMessage.InnerText = "Username cannot contain spaces!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["emailInput"].Contains(" "))
                {
                    errorMessage.InnerText = "Email cannot contain spaces!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["termsCheck"] == null)
                {
                    errorMessage.InnerText = "You must agree to the terms!";
                    errorMessage.Visible = true;
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

                    string SQLStr = "SELECT * FROM tblUsers";
                    SqlCommand cmd = new SqlCommand(SQLStr, con);

                    DataSet ds = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "users");

                    if (FindAndCheckUser(Request.Form["usernameInput"], ds.Tables["users"]) != -1)
                    {
                        errorMessage.InnerText = "Username already exists!";
                        errorMessage.Visible = true;
                        return;
                    }

                    DataRow dr = ds.Tables["users"].NewRow();
                    dr["username"] = Request.Form["usernameInput"];
                    dr["email"] = Request.Form["emailInput"];
                    dr["password"] = ComputeSha256Hash(Request.Form["passwordInput"]);
                    dr["admin"] = false;
                    ds.Tables["users"].Rows.Add(dr);

                    SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = cb.GetInsertCommand();
                    adapter.Update(ds, "users");

                    Session["username"] = Request.Form["usernameInput"];
                    Session["login"] = true;
                    Session["admin"] = false;
                    errorMessage.InnerText = "";
                    Response.Redirect("../");
                }
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("../");
        }
    }
}