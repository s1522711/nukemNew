using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.userCp
{
    public partial class _default : System.Web.UI.Page
    {
        /*
         * this function finds the user entries in the dataset
         * input: userId, dataset
         * output: new dataset with only the user entries
         */
        protected DataTable findUserEntries(int userId, DataTable dt)
        {
            DataTable newDt = new DataTable();
            newDt.Columns.Add("Id", typeof(int));
            newDt.Columns.Add("name", typeof(string));
            newDt.Columns.Add("email", typeof(string));
            newDt.Columns.Add("itemName", typeof(string));
            newDt.Columns.Add("price", typeof(double));
            newDt.Columns.Add("country", typeof(string));
            newDt.Columns.Add("address", typeof(string));
            newDt.Columns.Add("zip", typeof(string));
            newDt.Columns.Add("last4cc", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["userId"] == userId)
                {
                    DataRow row = newDt.NewRow();
                    row["Id"] = dt.Rows[i]["Id"];
                    row["name"] = dt.Rows[i]["name"];
                    row["email"] = dt.Rows[i]["email"];
                    row["itemName"] = dt.Rows[i]["itemName"];
                    row["price"] = dt.Rows[i]["price"];
                    row["country"] = dt.Rows[i]["country"];
                    row["address"] = dt.Rows[i]["address"];
                    row["zip"] = dt.Rows[i]["zip"];
                    row["last4cc"] = dt.Rows[i]["last4cc"];
                    newDt.Rows.Add(row);
                }
            }
            return newDt;
        }

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
                table += "</tr>";
            }
            return table;
        }

        /*
         * this function finds the user in the database and checks if the password is correct
         * input: username, password, dataset
         * output: uid of the user in the dataset, -1 if not found
         */
        protected int FindAndCheckUser(string username, DataTable dt, bool returnIndex)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["username"].ToString() == username && returnIndex)
                {
                    return i;
                }
                else if (dt.Rows[i]["username"].ToString() == username)
                {
                    return (int)dt.Rows[i]["userId"];
                }
            }
            return -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["login"])
            {
                Response.Redirect("/intruder/");
            }

            usernameStrDisplay.Visible = (bool)Session["login"];
            logoutBtnDiv.Visible = (bool)Session["login"];
            loginRegisterBtn.Visible = !(bool)Session["login"];
            aboutBtn.Visible = (bool)Session["login"];
            admin.Visible = (bool)Session["admin"] && (bool)Session["login"];

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsers", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            cmd = new SqlCommand("SELECT * FROM tblOrders", con);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "orders");

            int userId = FindAndCheckUser(Session["username"].ToString(), ds.Tables["users"], false);
            int userIndex = FindAndCheckUser(Session["username"].ToString(), ds.Tables["users"], true);

            DataTable dt = findUserEntries(userId, ds.Tables["orders"]);


            orderCountDiv.InnerHtml = "Order list, Order count: " + dt.Rows.Count.ToString();
            string table = buildOrdersTable(dt);
            orderTableBody.InnerHtml = table;

            uidField.InnerText = "#" + userId.ToString();
            usernameField.InnerText = Session["username"].ToString();
            emailField.InnerText = ds.Tables["users"].Rows[userIndex]["email"].ToString();
            passhashField.InnerText = ds.Tables["users"].Rows[userIndex]["password"].ToString();
            adminField.InnerText = ds.Tables["users"].Rows[userIndex]["admin"].ToString();
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