using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Key_Guard_KS
{
    public partial class Login : System.Web.UI.Page
    {
        public string UserPasswordFromXL { get; set; }
        public XLWorkbook exelDataBase1 { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie1 = new HttpCookie("userNameCookie", TextBoxLogin1.Text.ToUpper());
            HttpCookie cookie2 = new HttpCookie("passwordCookie", TextBoxPassword1.Text);
            cookie1.Expires = DateTime.Now.AddMonths(1);
            cookie2.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie1);
            Response.Cookies.Add(cookie2);
            ValidateUserFromXL();
            
        }

        protected void ValidateUserFromXL()
        {

            using (exelDataBase1 = new XLWorkbook(Server.MapPath("/App_Data/Tables/Keys_Data.xlsx")))
            {
                var ws = exelDataBase1.Worksheet("users");
                foreach (var item in ws.FirstColumn().CellsUsed())
                {
                    if (TextBoxLogin1.Text.ToUpper() == item.Value.ToString().ToUpper())
                    {
                        if (TextBoxPassword1.Text == item.CellRight().Value.ToString())
                        {
                            HttpCookie cookie3 = new HttpCookie("emailCookie", item.CellRight(2).Value.ToString());
                            cookie3.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(cookie3);
                            Response.Redirect("Default.aspx");
                        }
                        LabelStatus.Text += "Пароль введён не верно!<br>";
                    }
                    
                }
                
            }
            LabelStatus.Text += "Вход не выполнен!<br>";
        }
    }
}