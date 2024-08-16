using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace nukemNew.admin.items
{
    public partial class Default : System.Web.UI.Page
    {
        /*
         * Builds the main body of the users table
         * input: DataTable dt
         * output: html table body string
         */
        protected string buildItemTable(DataTable dt)
        {
            string table = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                table += "<tr>";
                table += "<th scope=\"row\">" + dt.Rows[i]["Id"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["itemCode"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["itemName"].ToString() + "</th>";
                table += "<th>$" + dt.Rows[i]["price"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["imageLocation"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["flairColorClass"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["flairTextColorClass"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["flairText"].ToString() + "</th>";
                table += "<th>" + dt.Rows[i]["flairLink"].ToString() + "</th>";
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
                // build the table (repeater
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                itemRepeater.DataSource = dt;
                itemRepeater.DataBind();
            }
            //string table = buildItemTable(dt);
            //userTableBody.InnerHtml = table;
            errorMessage.Visible = false;
            /*
            if (IsPostBack)
            {
                string itemCode = Request.Form["itemCode"];
                string itemName = Request.Form["itemName"];
                string price = Request.Form["itemPrice"];
                string imageLocation = "tbd";
                string flairColorClass = $"text-bg-{Request.Form["flairColor"]}";
                string flairTextColorClass = $"text-{Request.Form["flairTextColor"]}";
                string flairText = Request.Form["flairText"];
                string flairLink = Request.Form["flairLink"];

                if (itemCode == "")
                {
                    errorMessage.InnerText = "Item code cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (itemCode.Length < 3)
                {
                    errorMessage.InnerText = "Item code is too short!";
                    errorMessage.Visible = true;
                }
                else if (itemCode.Length > 50)
                {
                    errorMessage.InnerText = "Item code is too long!";
                    errorMessage.Visible = true;
                }
                else if (itemCode.Contains(" ") || itemCode.Contains(",") || itemCode.Contains(";") || itemCode.Contains(":") || itemCode.Contains("'") || itemCode.Contains("\"") || itemCode.Contains("\\") || itemCode.Contains("/"))
                {
                    errorMessage.InnerText = "Item code cannot contain special characters!";
                    errorMessage.Visible = true;
                }
                else if (itemName == "")
                {
                    errorMessage.InnerText = "Item name cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (itemName.Length < 3)
                {
                    errorMessage.InnerText = "Item name is too short!";
                    errorMessage.Visible = true;
                }
                else if (itemName.Length > 50)
                {
                    errorMessage.InnerText = "Item name is too long!";
                    errorMessage.Visible = true;
                }
                else if (price == "")
                {
                    errorMessage.InnerText = "Price cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (price.Length > 50)
                {
                    errorMessage.InnerText = "Price is too long!";
                    errorMessage.Visible = true;
                }
                else if (!imageUpload.HasFile)
                {
                    errorMessage.InnerText = "Please upload an image!";
                    errorMessage.Visible = true;
                }
                else if (flairText == "")
                {
                    errorMessage.InnerText = "Flair text cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (flairText.Length < 3)
                {
                    errorMessage.InnerText = "Flair text is too short!";
                    errorMessage.Visible = true;
                }
                else if (flairText.Length > 50)
                {
                    errorMessage.InnerText = "Flair text is too long!";
                    errorMessage.Visible = true;
                }
                else if (flairLink.Length < 3 && flairLink != "")
                {
                    errorMessage.InnerText = "Flair link is too short!";
                    errorMessage.Visible = true;
                }
                else if (flairLink.Length > 50)
                {
                    errorMessage.InnerText = "Flair link is too long!";
                    errorMessage.Visible = true;
                }
                else if (flairColorClass == "")
                {
                    errorMessage.InnerText = "Flair color cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (flairTextColorClass == "")
                {
                    errorMessage.InnerText = "Flair text color cannot be empty!";
                    errorMessage.Visible = true;
                }
                else
                {
                    // validate that item code is unique
                    cmd = new SqlCommand("SELECT * FROM tblItems WHERE itemCode='" + itemCode + "'", con);
                    adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        errorMessage.InnerText = "Item code already exists!";
                        errorMessage.Visible = true;
                        return;
                    }

                    // validate image
                    string fileExt = System.IO.Path.GetExtension(imageUpload.FileName);
                    if (fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".png" || fileExt.ToLower() == ".jpeg")
                    {
                        string fileName = System.IO.Path.GetFileName(imageUpload.FileName);
                        imageUpload.SaveAs(Server.MapPath("/img/index/") + fileName);
                        imageLocation = "/img/index/" + fileName;
                    }
                    else
                    {
                        errorMessage.InnerText = "Invalid image type!";
                        errorMessage.Visible = true;
                        return;
                    }

                    string query = "INSERT INTO tblItems (itemCode, itemName, price, imageLocation, flairColorClass, flairTextColorClass, flairText, flairLink) VALUES ('" + itemCode + "', '" + itemName + "', '" + price + "', '" + imageLocation + "', '" + flairColorClass + "', '" + flairTextColorClass + "', '" + flairText + "', '" + flairLink + "')";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("/admin/items/");
                }

                /*
                string query = "INSERT INTO tblItems (itemCode, itemName, price) VALUES ('" + itemCode + "', '" + itemName + "', '" + price + "')";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("/admin/items/");
                */
            //}
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
            int userId = int.Parse(btn.CommandArgument);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string imageLocation = dt.Rows[0]["imageLocation"].ToString();
            System.IO.File.Delete(Server.MapPath(imageLocation));
            cmd = new SqlCommand("DELETE FROM tblItems WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/admin/items/");
        }

        protected void Create_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string itemCode = Request.Form["itemCode"];
            string itemName = Request.Form["itemName"];
            string price = Request.Form["itemPrice"];
            string imageLocation = "tbd";
            string flairColorClass = $"text-bg-{Request.Form["flairColor"]}";
            string flairTextColorClass = $"text-{Request.Form["flairTextColor"]}";
            string flairText = Request.Form["flairText"];
            string flairLink = Request.Form["flairLink"];

            if (itemCode == "")
            {
                errorMessage.InnerText = "Item code cannot be empty!";
                errorMessage.Visible = true;
            }
            else if (itemCode.Length < 3)
            {
                errorMessage.InnerText = "Item code is too short!";
                errorMessage.Visible = true;
            }
            else if (itemCode.Length > 50)
            {
                errorMessage.InnerText = "Item code is too long!";
                errorMessage.Visible = true;
            }
            else if (itemCode.Contains(" ") || itemCode.Contains(",") || itemCode.Contains(";") || itemCode.Contains(":") || itemCode.Contains("'") || itemCode.Contains("\"") || itemCode.Contains("\\") || itemCode.Contains("/"))
            {
                errorMessage.InnerText = "Item code cannot contain special characters!";
                errorMessage.Visible = true;
            }
            else if (itemName == "")
            {
                errorMessage.InnerText = "Item name cannot be empty!";
                errorMessage.Visible = true;
            }
            else if (itemName.Length < 3)
            {
                errorMessage.InnerText = "Item name is too short!";
                errorMessage.Visible = true;
            }
            else if (itemName.Length > 50)
            {
                errorMessage.InnerText = "Item name is too long!";
                errorMessage.Visible = true;
            }
            else if (price == "")
            {
                errorMessage.InnerText = "Price cannot be empty!";
                errorMessage.Visible = true;
            }
            else if (price.Length > 50)
            {
                errorMessage.InnerText = "Price is too long!";
                errorMessage.Visible = true;
            }
            else if (!imageUpload.HasFile)
            {
                errorMessage.InnerText = "Please upload an image!";
                errorMessage.Visible = true;
            }
            else if (flairText == "")
            {
                errorMessage.InnerText = "Flair text cannot be empty!";
                errorMessage.Visible = true;
            }
            else if (flairText.Length < 3)
            {
                errorMessage.InnerText = "Flair text is too short!";
                errorMessage.Visible = true;
            }
            else if (flairText.Length > 50)
            {
                errorMessage.InnerText = "Flair text is too long!";
                errorMessage.Visible = true;
            }
            else if (flairLink.Length < 3 && flairLink != "")
            {
                errorMessage.InnerText = "Flair link is too short!";
                errorMessage.Visible = true;
            }
            else if (flairLink.Length > 50)
            {
                errorMessage.InnerText = "Flair link is too long!";
                errorMessage.Visible = true;
            }
            else if (flairColorClass == "")
            {
                errorMessage.InnerText = "Flair color cannot be empty!";
                errorMessage.Visible = true;
            }
            else if (flairTextColorClass == "")
            {
                errorMessage.InnerText = "Flair text color cannot be empty!";
                errorMessage.Visible = true;
            }
            else
            {
                // validate that item code is unique
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblItems WHERE itemCode='" + itemCode + "'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    errorMessage.InnerText = "Item code already exists!";
                    errorMessage.Visible = true;
                    return;
                }

                // validate image
                string fileExt = System.IO.Path.GetExtension(imageUpload.FileName);
                if (fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".png" || fileExt.ToLower() == ".jpeg")
                {
                    // check if image already exists and if so, append a number to the end of the file name
                    if (System.IO.File.Exists(Server.MapPath("/img/index/") + imageUpload.FileName))
                    {
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(imageUpload.FileName);
                        int i = 1;
                        while (System.IO.File.Exists(Server.MapPath("/img/index/") + fileName + i.ToString() + fileExt))
                        {
                            i++;
                        }
                        imageUpload.SaveAs(Server.MapPath("/img/index/") + fileName + i.ToString() + fileExt);
                        imageLocation = "/img/index/" + fileName + i.ToString() + fileExt;
                    }
                    else
                    {
                        imageUpload.SaveAs(Server.MapPath("/img/index/") + imageUpload.FileName);
                        imageLocation = "/img/index/" + imageUpload.FileName;
                    }
                }
                else
                {
                    errorMessage.InnerText = "Invalid image type!";
                    errorMessage.Visible = true;
                    return;
                }

                string query = "INSERT INTO tblItems (itemCode, itemName, price, imageLocation, flairColorClass, flairTextColorClass, flairText, flairLink) VALUES ('" + itemCode + "', '" + itemName + "', '" + price + "', '" + imageLocation + "', '" + flairColorClass + "', '" + flairTextColorClass + "', '" + flairText + "', '" + flairLink + "')";
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("/admin/items/");
            }
        }
    }
}