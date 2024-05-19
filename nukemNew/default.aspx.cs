using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace nukemNew
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            productsDiv.Visible = (bool)Session["login"];
            notLoggedinDiv.Visible = !(bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("./");
        }

        protected void tsarBombaBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "TsarBomba";
            Response.Redirect("~/checkout");
        }

        protected void dukeNukemBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "DukeNukem";
            Response.Redirect("~/checkout");
        }

        protected void csBombBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "CS2Bomb";
            Response.Redirect("~/checkout");
        }

        protected void giladDollBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "GiladDoll";
            Response.Redirect("~/checkout");
        }

        protected void breakingServiceBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "CBS";
            Response.Redirect("~/checkout");
        }

        protected void tamirGtaBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "TamirGTA";
            Response.Redirect("~/checkout");
        }

        protected void nickBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "Nick";
            Response.Redirect("~/checkout");
        }

        protected void littleBoyBtn_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = "LittleBoy";
            Response.Redirect("~/checkout");
        }

        public string GetProductPrice(string product)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["itemCode"].ToString() == product)
                {
                    return dt.Rows[i]["price"].ToString();
                }
            }
            return "0";
        }

        public string GetProductName(string product)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["itemCode"].ToString() == product)
                {
                    return dt.Rows[i]["itemName"].ToString();
                }
            }
            return "N/A";
        }
    }
}