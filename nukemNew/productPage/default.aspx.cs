using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.productPage
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

            string itemCode = Request.QueryString["itemCode"] != null ? Request.QueryString["itemCode"] : "";
            if (itemCode == "")
            {
                Response.Redirect("/");
            }

            if (!IsPostBack)
            {
                // Get all items from the database and display them in the repeater (table)
                // (See nukemNew/admin/items/Default.aspx.cs for the same functionality)
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems WHERE itemCode = @itemCode", con);
                cmd.Parameters.AddWithValue("@itemCode", itemCode);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                // if the item does not exist, redirect to the home page
                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("/");
                }
                itemRepeater.DataSource = dt;
                itemRepeater.DataBind();
            }

        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("/");
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["selectedProduct"] = btn.CommandArgument.ToString();
            Response.Redirect($"/checkout?itemCode={btn.CommandArgument.ToString()}");
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