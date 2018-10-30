using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Drawing;

namespace Key_Guard_KS
{
    public partial class Default : System.Web.UI.Page, ITableHandle
    {
        public bool IsUserExist { get; set; } = false;
        public XLWorkbook exelDataBase1 { get; set; }
        public string User { get; set; } = "UNKNOWN_USER";
        public string SiteNameFromRadioButton { get; set; }
        public string siteNameQueryString1
        {

            get
            {
                string tempSite = Request.QueryString["siteName"];
                if (string.IsNullOrEmpty(tempSite))
                {
                    return string.Empty; ;
                }
                return tempSite;
            }

            set
            {
                Request.QueryString["siteName"] = value;
            }
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            
            //another table
            Table1.BorderWidth = 1;
            Table1.BorderStyle = BorderStyle.Solid;
            Table1.Font.Size = 10;
            Table1.Rows[0].BackColor = Color.LightBlue;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateUserFromXL();
            if (!IsUserExist)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void SearchButton1_Click(object sender, EventArgs e)
        {
            GetDataFromXL(TextBox1.Text, "1:7", false, 1);
        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ShowAllDataFromTable("1:7");
            
        }
        
        protected void ShowAllDataFromTable(string cellsRange)
        {
            
            TableCell tableHeaderCell;

            using (exelDataBase1 = new XLWorkbook(Server.MapPath("/App_Data/Tables/Keys_Data.xlsx")))
            {
                
                var ws = exelDataBase1.Worksheet("keys");
                foreach (var item in ws.FirstColumn().CellsUsed())
                {
                    {
                        TableRow rowFromXL = new TableRow();


                        var cells1 = item.WorksheetRow().Cells(cellsRange);
                        var cells2 = item.WorksheetRow().Cell(2);
                        var cells3 = item.WorksheetRow().Cell(3);

                        foreach (var item2 in cells1)
                        {
                            tableHeaderCell = new TableCell();

                            tableHeaderCell.Text = (string)item2.Value.ToString();
                            tableHeaderCell.BackColor = Color.AliceBlue;
                            if (tableHeaderCell.Text == "на стенде")
                            { tableHeaderCell.BackColor = Color.LightGreen; }
                            else if (tableHeaderCell.Text == "у инженера")
                            {
                                tableHeaderCell.BackColor = Color.Orange;
                            }
                            rowFromXL.Cells.Add(tableHeaderCell);
                            if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 0)
                            {
                                string linkName = Request.Url.ToString().Replace("Default.aspx", "KeyOperations.aspx");
                                tableHeaderCell.Text = string.Format($"<a href='{linkName}?siteName={tableHeaderCell.Text}'>{tableHeaderCell.Text}</a>");
                            }
                        }
                        Table1.Rows.Add(rowFromXL);

                    }

                }
                Table1.Rows.RemoveAt(1);
            }
            
        }

        public void GetDataFromXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey, int needColumnNumber = 1)
        {
            //счётчик
            int counter = 0;

            //создаём ячейку таблицы
            TableCell tableHeaderCell;
            using (exelDataBase1 = new XLWorkbook(Server.MapPath("/App_Data/Tables/Keys_Data.xlsx")))
            {
                //получаем лист
                var ws = exelDataBase1.Worksheet("keys");

                //пробегаем по используемым ячейкам первой колнки
                foreach (var item in ws.Column(needColumnNumber).CellsUsed())
                {
                    if (!isUseUniqueKey)
                    {
                        //юзаем те ячейки, которые содержат значение с TextBox1.Text
                        if (item.Value.ToString().ToLower().Contains(siteNameFromUserRequest.ToLower()) & siteNameFromUserRequest != string.Empty)
                        {
                            ++counter;

                            //создаём строку
                            TableRow rowFromXL = new TableRow();

                            //получаем (диапазон) ячеек cells1
                            var cells1 = item.WorksheetRow().Cells(cellsRange);
                            //получаем ячейку 2
                            var cells2 = item.WorksheetRow().Cell(2);
                            //получаем ячейку 3
                            var cells3 = item.WorksheetRow().Cell(3);

                            //заполняем значения по всем ячейкам
                            foreach (var item2 in cells1)
                            {

                                string cellValue = (string)item2.Value.ToString();
                                tableHeaderCell = new TableCell();
                                tableHeaderCell.Text = cellValue;
                                //если ячейка содержит, то красим ее отдельным цветом
                                if (tableHeaderCell.Text == "на стенде")
                                { tableHeaderCell.BackColor = Color.LightGreen; }
                                //иначе тоже цветом
                                else if (tableHeaderCell.Text == "у инженера")
                                {
                                    tableHeaderCell.BackColor = Color.Orange;
                                }
                                else if (tableHeaderCell.Text.Contains("_red"))
                                {
                                    tableHeaderCell.BackColor = Color.Moccasin;
                                }
                                //добавляем ячейку в строку
                                rowFromXL.Cells.Add(tableHeaderCell);
                                //если эта ячейка первая по счёту - присваиваем ей ссылку
                                if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 0)
                                {
                                    string linkName = Request.Url.ToString().Replace("Default.aspx", "KeyOperations.aspx");
                                    tableHeaderCell.Text = string.Format($"<a href='{linkName}?siteName={tableHeaderCell.Text}'>{tableHeaderCell.Text}</a>");
                                }
                                if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 6)
                                {
                                    tableHeaderCell.ForeColor = Color.SteelBlue;
                                }


                            }
                            Table1.Rows.Add(rowFromXL);

                        }
                    }
                    //else if (isUseUniqueKey)
                    //{
                    //    if (item.Value.ToString() == siteNameFromUserRequest)
                    //    {
                    //        ++counter;

                    //        //создаём строку
                    //        TableRow rowFromXL = new TableRow();

                    //        //получаем (диапазон) ячеек cells1
                    //        var cells1 = item.WorksheetRow().Cells(cellsRange);
                    //        //var cells1 = item.WorksheetRow().CellsUsed();
                    //        //получаем ячейку 2
                    //        var cells2 = item.WorksheetRow().Cell(2);
                    //        //получаем ячейку 3
                    //        var cells3 = item.WorksheetRow().Cell(3);

                    //        if (cells2.GetValue<string>() != string.Empty)
                    //        {
                    //            //именуем название кнопки
                    //            SearchButton1.Text = "RETURN_key";
                    //            SearchButton1.BackColor = Color.Orange;
                    //        }
                    //        else if (cells3.GetValue<string>() == string.Empty | cells2.GetValue<string>() == string.Empty)
                    //        {
                    //            //именуем название кнопки
                    //            SearchButton1.Text = "GET_key";
                    //            SearchButton1.BackColor = Color.LightGreen;
                    //        }

                    //        //заполняем значения по всем ячейкам
                    //        foreach (var item2 in cells1)
                    //        {
                    //            string cellValue = (string)item2.Value.ToString();
                    //            tableHeaderCell = new TableCell();
                    //            tableHeaderCell.Text = cellValue;
                    //            //если ячейка содержит, то красим ее отдельным цветом
                    //            if (tableHeaderCell.Text == "на стенде")
                    //            { tableHeaderCell.BackColor = Color.LightGreen; }
                    //            //иначе тоже цветом
                    //            else if (tableHeaderCell.Text == "у инженера")
                    //            {
                    //                tableHeaderCell.BackColor = Color.Orange;
                    //            }
                    //            //добавляем ячейку в строку
                    //            rowFromXL.Cells.Add(tableHeaderCell);
                    //            //если эта ячейка первая по счёту - присваиваем ей ссылку
                    //            if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 0)
                    //            {
                    //                //tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString() + $"?siteName={cellValue}"}'>{cellValue}</a>");
                    //                tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString()}'>{cellValue}</a>");
                    //            }
                    //        }
                    //        Table1.Rows.Add(rowFromXL);

                    //    }
                    //}

                }

            }

        }

        public void SetDataToXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey)
        {
            //
        }

        protected void DropDownList1whereButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataFromXL(DropDownList1whereButton.SelectedValue, "1:7", false, 5);
        }

        protected void Button1searchUser_Click(object sender, EventArgs e)
        {
            GetDataFromXL(TextBox2searchUser.Text, "1:7", false, 6);
        }

        protected void ValidateUserFromXL()
        {

            if (Request.Cookies["userNameCookie"] != null)
            {
                using (exelDataBase1 = new XLWorkbook(Server.MapPath("/App_Data/Tables/Keys_Data.xlsx")))
                {
                    var ws = exelDataBase1.Worksheet("users");
                    foreach (var item in ws.FirstColumn().CellsUsed())
                    {
                        if (Request.Cookies["userNameCookie"].Value == item.Value.ToString().ToUpper())
                        {
                            if (Request.Cookies["passwordCookie"].Value == item.CellRight().Value.ToString())
                            {
                                User = Request.Cookies["userNameCookie"].Value;
                                LabelUser.Text = "user (" + Request.Cookies["userNameCookie"].Value + ")<br>";
                                IsUserExist = true;
                            }

                        }

                    }

                } 
            }

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            HttpCookie cookie1 = Request.Cookies["userNameCookie"];

            cookie1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie1);
            cookie1 = Request.Cookies["passwordCookie"];
            cookie1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie1);
            cookie1 = Request.Cookies["emailCookie"];
            cookie1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie1);

            Response.Redirect("Login.aspx");
        }
    }
}