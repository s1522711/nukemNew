using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace nukemNew.checkout.confirmed
{
    public partial class _default : System.Web.UI.Page
    {
        protected int FindOrderIndex(DataSet ds, int orderId)
        {
            for (int i = 0; i < ds.Tables["orders"].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables["orders"].Rows[i]["Id"]) == orderId)
                {
                    return i;
                }
            }
            return -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["login"])
            {
                Response.Redirect("/login/");
            }

            if (!(bool)Session["admin"])
            {
                adminText.Visible = false;
            }

            // Get the order id from the url
            int orderId = Request.QueryString["orderId"] != null ? Convert.ToInt32(Request.QueryString["orderId"]) : 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

            string SQLStr = $"SELECT * FROM tblOrders WHERE Id = @orderId";
            SqlCommand cmd = new SqlCommand(SQLStr, con);
            cmd.Parameters.AddWithValue("@orderId", orderId);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "orders");
            SQLStr = "SELECT * FROM tblUsers WHERE userId = @userId";
            cmd = new SqlCommand(SQLStr, con);
            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "users");

            if (ds.Tables["orders"].Rows.Count == 0)
            {
                orderData.InnerHtml = "<br /><p class=\"lead\">No orders found.</p>";
                return;
            }

            if (ds.Tables["orders"].Rows[0]["userId"].ToString() != Session["userId"].ToString() && !(bool)Session["admin"])
            {
                Response.Redirect("/intruder/");
                return;
            }



            orderData.InnerHtml = "<br /><p class=\"lead\">Your order number is: <strong>#";
            //orderData.InnerHtml += ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count-1]["Id"].ToString();
            orderData.InnerHtml += ds.Tables["orders"].Rows[0]["Id"].ToString();
            orderData.InnerHtml += "</strong></p>";
            orderData.InnerHtml += "<p class=\"lead\">You purchased: <strong>";
            orderData.InnerHtml += ds.Tables["orders"].Rows[0]["itemName"].ToString();
            orderData.InnerHtml += "</strong></p>";
            orderData.InnerHtml += "<p class=\"lead\">Your total was: <strong>$";
            orderData.InnerHtml += ds.Tables["orders"].Rows[0]["price"].ToString();
            orderData.InnerHtml += "</strong></p>";
        }
    }
}