using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.admin.orders
{
    public partial class _default : System.Web.UI.Page
    {
        /*
         * Builds the main body of the orders table
         * input: DataTable dt
         * output: html table body string
         */
        protected string buildOrdersTable(DataTable dt)
        {
            string table = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                table += "<tr>";
                table += "<th scope=\"row\">" + dt.Rows[i]["Id"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["name"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["email"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["itemName"].ToString() + "</th>";
                table += "<th>$" + dt.Rows[i]["price"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["country"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["address"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["zip"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["last4cc"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["userId"].ToString() + "</th>";
                table += "</tr>";
            }
            return table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["login"] || !(bool)Session["admin"])
            {
                Response.Redirect("/intruder/");
            }

            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];

            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblOrders", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                orderRepeater.DataSource = dt;
                orderRepeater.DataBind();
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["admin"] = false;
            Session["username"] = "Guest";
            Response.Redirect("/");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int orderId = int.Parse(btn.CommandArgument);
            // Delete the order from the database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string SQLStr = "DELETE FROM tblOrders WHERE Id = @orderId";
            SqlCommand cmd = new SqlCommand(SQLStr, con);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/admin/orders/");
        }
    }
}