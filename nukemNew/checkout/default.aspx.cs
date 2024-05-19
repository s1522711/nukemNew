using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nukemNew.checkout
{
    public partial class _default : System.Web.UI.Page
    {
        /*
         * this function finds the user in the database and checks if the password is correct
         * input: username, password, dataset
         * output: uid of the user in the dataset, -1 if not found
         */
        protected int FindAndCheckUser(string username, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["username"].ToString() == username)
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
            errorMessage.Visible = false;

            if (IsPostBack)
            {
                if (Request.Form["firstName"] == "")
                {
                    errorMessage.InnerText = "Please enter your first name.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["firstName"].Length < 3)
                {
                    errorMessage.InnerText = "First name is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["firstName"].Length > 50)
                {
                    errorMessage.InnerText = "First name is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["lastName"] == "")
                {
                    errorMessage.InnerText = "Please enter your last name.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["lastName"].Length < 3)
                {
                    errorMessage.InnerText = "Last name is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["lastName"].Length > 50)
                {
                    errorMessage.InnerText = "Last name is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["email"] == "")
                {
                    errorMessage.InnerText = "Email cannot be empty!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["email"].Length > 50)
                {
                    errorMessage.InnerText = "Email is too long!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["email"].Length < 3)
                {
                    errorMessage.InnerText = "Email is too short!";
                    errorMessage.Visible = true;
                }
                else if (!Request.Form["email"].Contains("@") || !Request.Form["email"].Contains("."))
                {
                    errorMessage.InnerText = "Email is invalid!";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["country"] == "")
                {
                    errorMessage.InnerText = "Please select your country.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["country"] == "FR" || Request.Form["country"] == "GF" || Request.Form["country"] == "PF" || Request.Form["country"] == "TF" || Request.Form["country"] == "DE" || Request.Form["country"] == "GI" || Request.Form["country"] == "IL" || Request.Form["country"] == "PT" || Request.Form["country"] == "ES" || Request.Form["country"] == "GB")
                {
                    errorMessage.InnerText = "Shipping to this country is banned by company policy.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["address"] == "")
                {
                    errorMessage.InnerText = "Please enter your address.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["address"].Length < 3)
                {
                    errorMessage.InnerText = "Address is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["address"].Length > 50)
                {
                    errorMessage.InnerText = "Address is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["zip"] == "")
                {
                    errorMessage.InnerText = "Please enter your zip code.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["zip"].Length < 3)
                {
                    errorMessage.InnerText = "Zip code is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["zip"].Length > 50)
                {
                    errorMessage.InnerText = "Zip code is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-name"] == "")
                {
                    errorMessage.InnerText = "Please enter the name on your credit card.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-name"].Length < 3)
                {
                    errorMessage.InnerText = "Name on credit card is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-name"].Length > 50)
                {
                    errorMessage.InnerText = "Name on credit card is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-number"] == "")
                {
                    errorMessage.InnerText = "Please enter your credit card number.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-number"].Length < 15)
                {
                    errorMessage.InnerText = "Credit card number is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-number"].Length > 16)
                {
                    errorMessage.InnerText = "Credit card number is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-expiration"] == "")
                {
                    errorMessage.InnerText = "Please enter your credit card expiration date.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-expiration"].Length < 4)
                {
                    errorMessage.InnerText = "Credit card expiration date is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-expiration"].Length > 5)
                {
                    errorMessage.InnerText = "Credit card expiration date is too long.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-cvv"] == "")
                {
                    errorMessage.InnerText = "Please enter your credit card CVV.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-cvv"].Length < 3)
                {
                    errorMessage.InnerText = "Credit card CVV is too short.";
                    errorMessage.Visible = true;
                }
                else if (Request.Form["cc-cvv"].Length > 4)
                {
                    errorMessage.InnerText = "Credit card CVV is too long.";
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
                    int userId = FindAndCheckUser(Session["username"].ToString(), ds.Tables["users"]);

                    SQLStr = "SELECT * FROM tblOrders";
                    cmd = new SqlCommand(SQLStr, con);
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "orders");



                    DataRow dr = ds.Tables["orders"].NewRow();
                    dr["name"] = Request.Form["firstName"] + " " + Request.Form["lastName"];
                    dr["email"] = Request.Form["email"];
                    dr["country"] = CountryCodeToCountryName(Request.Form["country"]);
                    dr["address"] = Request.Form["address"];
                    dr["zip"] = Request.Form["zip"];
                    dr["last4cc"] = Request.Form["cc-number"].Substring(Request.Form["cc-number"].Length - 4);
                    dr["userId"] = userId;
                    dr["itemName"] = GetProductName(Session["selectedProduct"].ToString());
                    dr["price"] = GetProductPrice(Session["selectedProduct"].ToString());
                    ds.Tables["orders"].Rows.Add(dr);

                    SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = cb.GetInsertCommand();
                    adapter.Update(ds, "orders");


                    adapter.Fill(ds, "orders");
                    if (ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["name"].ToString() == Request.Form["firstName"] + " " + Request.Form["lastName"])
                    {
                        errorMessage.InnerText = "Order placed successfully!";
                        errorMessage.Visible = true;
                        Session["orderId"] = ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["Id"];
                        Response.Redirect("./confirmed");
                    }
                    else
                    {
                        errorMessage.InnerText = "Order failed to place!";
                        errorMessage.Visible = true;
                    }
                }
            }
        }

        protected string CountryCodeToCountryName(string code)
        {
            switch (code)
            {
                case "AF":
                    return "Afghanistan";
                case "AX":
                    return "Åland Islands";
                case "AL":
                    return "Albania";
                case "DZ":
                    return "Algeria";
                case "AS":
                    return "American Samoa";
                case "AD":
                    return "Andorra";
                case "AO":
                    return "Angola";
                case "AI":
                    return "Anguilla";
                case "AQ":
                    return "Antarctica";
                case "AG":
                    return "Antigua and Barbuda";
                case "AR":
                    return "Argentina";
                case "AM":
                    return "Armenia";
                case "AW":
                    return "Aruba";
                case "AU":
                    return "Australia";
                case "AT":
                    return "Austria";
                case "AZ":
                    return "Azerbaijan";
                case "BS":
                    return "Bahamas";
                case "BH":
                    return "Bahrain";
                case "BD":
                    return "Bangladesh";
                case "BB":
                    return "Barbados";
                case "BY":
                    return "Belarus";
                case "BE":
                    return "Belgium";
                case "BZ":
                    return "Belize";
                case "BJ":
                    return "Benin";
                case "BM":
                    return "Bermuda";
                case "BT":
                    return "Bhutan";
                case "BO":
                    return "Bolivia";
                case "BA":
                    return "Bosnia and Herzegovina";
                case "BW":
                    return "Botswana";
                case "BV":
                    return "Bouvet Island";
                case "BR":
                    return "Brazil";
                case "IO":
                    return "British Indian Ocean Territory";
                case "BN":
                    return "Brunei Darussalam";
                case "BG":
                    return "Bulgaria";
                case "BF":
                    return "Burkina Faso";
                case "BI":
                    return "Burundi";
                case "KH":
                    return "Cambodia";
                case "CM":
                    return "Cameroon";
                case "CA":
                    return "Canada";
                case "CV":
                    return "Cape Verde";
                case "KY":
                    return "Cayman Islands";
                case "CF":
                    return "Central African Republic";
                case "TD":
                    return "Chad";
                case "CL":
                    return "Chile";
                case "CN":
                    return "China";
                case "CX":
                    return "Christmas Island";
                case "CC":
                    return "Cocos (Keeling) Islands";
                case "CO":
                    return "Colombia";
                case "KM":
                    return "Comoros";
                case "CG":
                    return "Congo";
                case "CD":
                    return "Congo, Democratic Republic of the";
                case "CK":
                    return "Cook Islands";
                case "CR":
                    return "Costa Rica";
                case "CI":
                    return "Côte d'Ivoire";
                case "HR":
                    return "Croatia";
                case "CU":
                    return "Cuba";
                case "CY":
                    return "Cyprus";
                case "CZ":
                    return "Czech Republic";
                case "DK":
                    return "Denmark";
                case "DJ":
                    return "Djibouti";
                case "DM":
                    return "Dominica";
                case "DO":
                    return "Dominican Republic";
                case "EC":
                    return "Ecuador";
                case "EG":
                    return "Egypt";
                case "SV":
                    return "El Salvador";
                case "GQ":
                    return "Equatorial Guinea";
                case "ER":
                    return "Eritrea";
                case "EE":
                    return "Estonia";
                case "ET":
                    return "Ethiopia";
                case "FK":
                    return "Falkland Islands (Malvinas)";
                case "FO":
                    return "Faroe Islands";
                case "FJ":
                    return "Fiji";
                case "FI":
                    return "Finland";
                case "FR":
                    return "France";
                case "GF":
                    return "French Guiana";
                case "PF":
                    return "French Polynesia";
                case "TF":
                    return "French Southern Territories";
                case "GA":
                    return "Gabon";
                case "GM":
                    return "Gambia";
                case "GE":
                    return "Georgia";
                case "DE":
                    return "Germany";
                case "GH":
                    return "Ghana";
                case "GI":
                    return "Gibraltar";
                case "GR":
                    return "Greece";
                case "GL":
                    return "Greenland";
                case "GD":
                    return "Grenada";
                case "GP":
                    return "Guadeloupe";
                case "GU":
                    return "Guam";
                case "GT":
                    return "Guatemala";
                case "GG":
                    return "Guernsey";
                case "GN":
                    return "Guinea";
                case "GW":
                    return "Guinea-Bissau";
                case "GY":
                    return "Guyana";
                case "HT":
                    return "Haiti";
                case "HM":
                    return "Heard Island and McDonald Islands";
                case "VA":
                    return "Holy See (Vatican City State)";
                case "HN":
                    return "Honduras";
                case "HK":
                    return "Hong Kong";
                case "HU":
                    return "Hungary";
                case "IS":
                    return "Iceland";
                case "IN":
                    return "India";
                case "ID":
                    return "Indonesia";
                case "IR":
                    return "Iran, Islamic Republic of";
                case "IQ":
                    return "Iraq";
                case "IE":
                    return "Ireland";
                case "IM":
                    return "Isle of Man";
                case "IL":
                    return "Israel";
                case "IT":
                    return "Italy";
                case "JM":
                    return "Jamaica";
                case "JP":
                    return "Japan";
                case "JE":
                    return "Jersey";
                case "JO":
                    return "Jordan";
                case "KZ":
                    return "Kazakhstan";
                case "KE":
                    return "Kenya";
                case "KI":
                    return "Kiribati";
                case "KP":
                    return "Korea, Democratic People's Republic of";
                case "KR":
                    return "Korea, Republic of";
                case "KW":
                    return "Kuwait";
                case "KG":
                    return "Kyrgyzstan";
                case "LA":
                    return "Lao People's Democratic Republic";
                case "LV":
                    return "Latvia";
                case "LB":
                    return "Lebanon";
                case "LS":
                    return "Lesotho";
                case "LR":
                    return "Liberia";
                case "LY":
                    return "Libyan Arab Jamahiriya";
                case "LI":
                    return "Liechtenstein";
                case "LT":
                    return "Lithuania";
                case "LU":
                    return "Luxembourg";
                case "MO":
                    return "Macao";
                case "MK":
                    return "Macedonia, the former Yugoslav Republic of";
                case "MG":
                    return "Madagascar";
                case "MW":
                    return "Malawi";
                case "MY":
                    return "Malaysia";
                case "MV":
                    return "Maldives";
                case "ML":
                    return "Mali";
                case "MT":
                    return "Malta";
                case "MH":
                    return "Marshall Islands";
                case "MQ":
                    return "Martinique";
                case "MR":
                    return "Mauritania";
                case "MU":
                    return "Mauritius";
                case "YT":
                    return "Mayotte";
                case "MX":
                    return "Mexico";
                case "FM":
                    return "Micronesia, Federated States of";
                case "MD":
                    return "Moldova, Republic of";
                case "MC":
                    return "Monaco";
                case "MN":
                    return "Mongolia";
                case "ME":
                    return "Montenegro";
                case "MS":
                    return "Montserrat";
                case "MA":
                    return "Morocco";
                case "MZ":
                    return "Mozambique";
                case "MM":
                    return "Myanmar";
                case "NA":
                    return "Namibia";
                case "NR":
                    return "Nauru";
                case "NP":
                    return "Nepal";
                case "NL":
                    return "Netherlands";
                case "AN":
                    return "Netherlands Antilles";
                case "NC":
                    return "New Caledonia";
                case "NZ":
                    return "New Zealand";
                case "NI":
                    return "Nicaragua";
                case "NE":
                    return "Niger";
                case "NG":
                    return "Nigeria";
                case "NU":
                    return "Niue";
                case "NF":
                    return "Norfolk Island";
                case "MP":
                    return "Northern Mariana Islands";
                case "NO":
                    return "Norway";
                case "OM":
                    return "Oman";
                case "PK":
                    return "Pakistan";
                case "PW":
                    return "Palau";
                case "PA":
                    return "Panama";
                case "PG":
                    return "Papua New Guinea";
                case "PY":
                    return "Paraguay";
                case "PE":
                    return "Peru";
                case "PH":
                    return "Philippines";
                case "PN":
                    return "Pitcairn";
                case "PL":
                    return "Poland";
                case "PT":
                    return "Portugal";
                case "PR":
                    return "Puerto Rico";
                case "QA":
                    return "Qatar";
                case "RE":
                    return "Réunion";
                case "RO":
                    return "Romania";
                case "RU":
                    return "Russian Federation";
                case "RW":
                    return "Rwanda";
                case "SH":
                    return "Saint Helena, Ascension and Tristan da Cunha";
                case "KN":
                    return "Saint Kitts and Nevis";
                case "LC":
                    return "Saint Lucia";
                case "PM":
                    return "Saint Pierre and Miquelon";
                case "VC":
                    return "Saint Vincent and the Grenadines";
                case "WS":
                    return "Samoa";
                case "SM":
                    return "San Marino";
                case "ST":
                    return "Sao Tome and Principe";
                case "SA":
                    return "Saudi Arabia";
                case "SN":
                    return "Senegal";
                case "RS":
                    return "Serbia";
                case "SC":
                    return "Seychelles";
                case "SL":
                    return "Sierra Leone";
                case "SG":
                    return "Singapore";
                case "SK":
                    return "Slovakia";
                case "SI":
                    return "Slovenia";
                case "SB":
                    return "Solomon Islands";
                case "SO":
                    return "Somalia";
                case "ZA":
                    return "South Africa";
                case "GS":
                    return "South Georgia and the South Sandwich Islands";
                case "ES":
                    return "Spain";
                case "LK":
                    return "Sri Lanka";
                case "SD":
                    return "Sudan";
                case "SR":
                    return "Suriname";
                case "SJ":
                    return "Svalbard and Jan Mayen";
                case "SZ":
                    return "Swaziland";
                case "SE":
                    return "Sweden";
                case "CH":
                    return "Switzerland";
                case "SY":
                    return "Syrian Arab Republic";
                case "TW":
                    return "Taiwan, Province of China";
                case "TJ":
                    return "Tajikistan";
                case "TZ":
                    return "Tanzania, United Republic of";
                case "TH":
                    return "Thailand";
                case "TL":
                    return "Timor-Leste";
                case "TG":
                    return "Togo";
                case "TK":
                    return "Tokelau";
                case "TO":
                    return "Tonga";
                case "TT":
                    return "Trinidad and Tobago";
                case "TN":
                    return "Tunisia";
                case "TR":
                    return "Turkey";
                case "TM":
                    return "Turkmenistan";
                case "TC":
                    return "Turks and Caicos Islands";
                case "TV":
                    return "Tuvalu";
                case "UG":
                    return "Uganda";
                case "UA":
                    return "Ukraine";
                case "AE":
                    return "United Arab Emirates";
                case "GB":
                    return "United Kingdom";
                case "US":
                    return "United States";
                case "UM":
                    return "United States Minor Outlying Islands";
                case "UY":
                    return "Uruguay";
                case "UZ":
                    return "Uzbekistan";
                case "VU":
                    return "Vanuatu";
                case "VE":
                    return "Venezuela, Bolivarian Republic of";
                case "VN":
                    return "Viet Nam";
                case "VG":
                    return "Virgin Islands, British";
                case "VI":
                    return "Virgin Islands, U.S.";
                case "WF":
                    return "Wallis and Futuna";
                case "EH":
                    return "Western Sahara";
                case "YE":
                    return "Yemen";
                case "ZM":
                    return "Zambia";
                case "ZW":
                    return "Zimbabwe";
                default:
                    return "Unknown";
            }
        }

        protected string GetProductPrice(string product)
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

        protected string GetProductName(string product)
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