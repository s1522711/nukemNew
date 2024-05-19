using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.checkout.confirmed
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\Database.mdf;Integrated Security=True");

            string SQLStr = "SELECT * FROM tblOrders";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "orders");

            if (Session["orderId"].ToString() != ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["Id"].ToString())
            {
                Response.Redirect("/intruder/");
                return;
            }

            if (ds.Tables["orders"].Rows.Count == 0)
            {
                orderData.InnerHtml = "<br /><p class=\"lead\">No orders found.</p>";
                return;
            }

            orderData.InnerHtml = "<br /><p class=\"lead\">Your order number is: <strong>#";
            //orderData.InnerHtml += ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count-1]["Id"].ToString();
            orderData.InnerHtml += Session["orderId"].ToString();
            orderData.InnerHtml += "</strong></p>";
            orderData.InnerHtml += "<p class=\"lead\">You purchased: <strong>";
            orderData.InnerHtml += ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["itemName"].ToString();
            orderData.InnerHtml += "</strong></p>";
            orderData.InnerHtml += "<p class=\"lead\">Your total was: <strong>$";
            orderData.InnerHtml += ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["price"].ToString();
            orderData.InnerHtml += "</strong></p>";
        }
    }
}