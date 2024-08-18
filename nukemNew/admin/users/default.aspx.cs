using System;
using System.Collections.Generic;
using System.Configuration;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];

            if (!IsPostBack)
            {
                if (!(bool)Session["login"] || !(bool)Session["admin"])
                {
                    Response.Redirect("/intruder/");
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsers", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                userRepeater.DataSource = dt;
                userRepeater.DataBind();
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("/");
        }

        protected void Admin_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int userId = int.Parse(btn.CommandArgument);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UPDATE tblUsers SET admin = ~admin WHERE userId = @userId", con);
            cmd.Parameters.AddWithValue("@userId", userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            if (userId == int.Parse(Session["userId"].ToString()))
            {
                Session["admin"] = !(bool)Session["admin"];
            }
            Response.Redirect("/admin/users/");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int userId = int.Parse(btn.CommandArgument);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblUsers WHERE userId = @userId", con);
            cmd.Parameters.AddWithValue("@userId", userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/admin/users/");
        }
    }
}