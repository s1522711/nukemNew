using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.admin.users
{
    public partial class _default : System.Web.UI.Page
    {
        /*
         * Builds the main body of the users table
         * input: DataTable dt
         * output: html table body string
         */
        protected string buildUsersTable(DataTable dt)
        {
            string table = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                table += "<tr>";
                table += "<th scope=\"row\">" + dt.Rows[i]["userId"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["username"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["email"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["password"].ToString() + "</th>";
                if ((bool)dt.Rows[i]["admin"])
                {
                    table += "<th>Yes</th>";
                }
                else
                {
                    table += "<th>No</th>";
                }
                table += "</tr>";
            }
            return table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["login"] || !(bool)Session["admin"])
            {
                Response.Redirect("../../intruder/");
            }

            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];

            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\Database.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsers", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string table = buildUsersTable(dt);
            userTableBody.InnerHtml = table;
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("../../");
        }
    }
}