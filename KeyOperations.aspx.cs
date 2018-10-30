using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Key_Guard_KS
{
    public partial class KeyOperations : System.Web.UI.Page, ITableHandle
    {
        public bool IsUserExist { get; set; } = false;
        public XLWorkbook exelDataBase1 { get; set; }
        public string User { get; set; } = "UNKNOWN_USER";
        public string BodyforMailHelper { get; set; }
        public DateTime UkraineDateTime { get => DateTime.Now.AddHours(10); }
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
        public DateTime PenaltyTime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateUserFromXL();
            if (!IsUserExist)
            {
                Response.Redirect("Login.aspx");
            }
            if (siteNameQueryString1 != string.Empty)
            {
                GetDataFromXL(siteNameQueryString1, "1:7", true, 1);
            }
        }

        protected void ActionButtonGetOrReturn_Click(object sender, EventArgs e)
        {
            SetDataToXL(siteNameQueryString1, "1:7", true); 
        }

        public void GetDataFromXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey = false, int needColumnNumber = 1)
        {
            HeaderLabel1.Text = siteNameFromUserRequest;
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
                        if (item.Value.ToString().Contains(siteNameFromUserRequest))
                        {
                            ++counter;

                            //создаём строку
                            TableRow rowFromXL = new TableRow();

                            //получаем (диапазон) ячеек cells1
                            var cells1 = item.WorksheetRow().Cells(cellsRange);
                            //var cells1 = item.WorksheetRow().CellsUsed();
                            //получаем ячейку 2
                            var cells2 = item.WorksheetRow().Cell(2);
                            //получаем ячейку 3
                            var cells3 = item.WorksheetRow().Cell(3);

                            if (cells2.GetValue<string>() != string.Empty)
                            {
                                //именуем название кнопки
                                ActionButtonGetOrReturn.Text = "RETURN_key";
                                ActionButtonGetOrReturn.BackColor = Color.Orange;
                            }
                            else if (cells3.GetValue<string>() == string.Empty | cells2.GetValue<string>() == string.Empty)
                            {
                                //именуем название кнопки
                                ActionButtonGetOrReturn.Text = "GET_key";
                                ActionButtonGetOrReturn.BackColor = Color.LightGreen;
                            }

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
                                //добавляем ячейку в строку
                                rowFromXL.Cells.Add(tableHeaderCell);
                                //если эта ячейка первая по счёту - присваиваем ей ссылку
                                if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 0)
                                {
                                    //tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString() + $"?siteName={cellValue}"}'>{cellValue}</a>");
                                    tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString()}'> + {cellValue}" + "</a>");
                                }
                                //if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 7)
                                //{
                                //    tableHeaderCell.Text = "";
                                //    historyLabel1.Text = cellValue;
                                //}
                            }
                            Table1.Rows.Add(rowFromXL);

                        }
                    }
                    else if (isUseUniqueKey)
                    {
                            if (item.Value.ToString() == siteNameFromUserRequest)
                            {
                            ++counter;

                            //создаём строку
                            TableRow rowFromXL = new TableRow();

                            //получаем (диапазон) ячеек cells1
                            var cells1 = item.WorksheetRow().Cells(cellsRange);
                            //var cells1 = item.WorksheetRow().CellsUsed();
                            //получаем ячейку 2
                            var cells2 = item.WorksheetRow().Cell(2);
                            //получаем ячейку 3
                            var cells3 = item.WorksheetRow().Cell(3);

                            if (cells2.GetValue<string>() != string.Empty)
                            {
                                //именуем название кнопки
                                ActionButtonGetOrReturn.Text = "RETURN_key";
                                ActionButtonGetOrReturn.BackColor = Color.Orange;
                            }
                            else if (cells3.GetValue<string>() == string.Empty | cells2.GetValue<string>() == string.Empty)
                            {
                                //именуем название кнопки
                                ActionButtonGetOrReturn.Text = "GET_key";
                                ActionButtonGetOrReturn.BackColor = Color.LightGreen;
                            }

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
                                //добавляем ячейку в строку
                                rowFromXL.Cells.Add(tableHeaderCell);
                                //если эта ячейка первая по счёту - присваиваем ей ссылку
                                if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 0)
                                {
                                    //tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString() + $"?siteName={cellValue}"}'>{cellValue}</a>");
                                    tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString()}'>{cellValue}</a>");
                                }
                                if (rowFromXL.Cells.GetCellIndex(tableHeaderCell) == 6)
                                {
                                    //tableHeaderCell.Text = string.Format($"<a href='{Request.Url.ToString() + $"?siteName={cellValue}"}'>{cellValue}</a>");
                                    tableHeaderCell.ForeColor = Color.SteelBlue;
                                }
                            }
                            Table1.Rows.Add(rowFromXL);

                        }
                    }

                }

                if (counter == 1)
                {
                    ActionButtonGetOrReturn.Visible = true;
                    //RadioButtonList1.Visible = true;
                    if (ActionButtonGetOrReturn.Text == "GET_key")
                    {
                        commentTextBox1.Visible = false;
                    }
                    else
                    {
                        commentTextBox1.Visible = true;
                        LiteralComment.Text = "Оставить комментарий о ВАЖНОМ";
                    }
                }
            }
        }

        public void SetDataToXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey)
        {
            MailHelper mailHelper1 = new MailHelper();
            Random randomNumber1 = new Random();

                commentTextBox1.Visible = true;

                using (exelDataBase1 = new XLWorkbook(Server.MapPath("/App_Data/Tables/Keys_Data.xlsx")))
                {
                var ws = exelDataBase1.Worksheet("keys");
                //var wsQuote = exelDataBase1.Worksheet("quotes");
                //int countRows = wsQuote.RowsUsed().Count();
                //var needQuoteRow = wsQuote.Row(randomNumber1.Next(2, countRows));
                //string needQuoteText = "<div style=\"width: 250px; font-size: 9pt; background:LightCyan;\">'quote': <br><br><i>" + needQuoteRow.Cell(3).Value.ToString() + "</i> <br> <span style=\"color:Grey; font-size: 8pt\"> --- " + needQuoteRow.Cell(2).Value.ToString() + "</span> </div>";
                string needQuoteText = "";

                //запись "Взять ключ"
                if (ActionButtonGetOrReturn.Text == "GET_key")
                    {
                        foreach (var item in ws.FirstColumn().CellsUsed())
                        {
                            //if (item.Value.ToString().Contains(siteNameQueryString1))
                                if (item.Value.ToString() == siteNameFromUserRequest)
                                {
                            
                                mailHelper1.KeyName = item.Value.ToString();

                                var needCellTimeGet = item.WorksheetRow().Cell(2);
                                needCellTimeGet.Value = UkraineDateTime.ToString();

                                //var cells2 = item.WorksheetRow().Cell(2);
                                var cellTimeReturn = item.WorksheetRow().Cell(3);
                                cellTimeReturn.Clear();
                                var deadlineTime = item.WorksheetRow().Cell(4);
                                if (item.Value.ToString().Contains("red"))
                                {
                                    PenaltyTime = UkraineDateTime.AddDays(1); 
                                }
                                else PenaltyTime = UkraineDateTime.AddDays(3);
                                //PenaltyTime = 

                                deadlineTime.Value = PenaltyTime.ToLocalTime().ToString();
                                var whereKey = item.WorksheetRow().Cell(5);
                                whereKey.Value = "у инженера";
                                var logCell = item.WorksheetRow().Cell(6);
                                logCell.Value = needCellTimeGet.Value.ToString() + "-- взял " + User;
                                var history = item.WorksheetRow().Cell(8);
                                history.Value += (needCellTimeGet.Value.ToString() + "-- взял " + User + "<br>");
                                var lastComments = item.WorksheetRow().Cell(7);

                            BodyforMailHelper = string.Format($"<div style=\"font-size: 11pt;\"><b>Название ключа:</b> <a href='{Request.Url.ToString()}'>{item.Value.ToString()}</a> <br><b>Время операции:</b> {needCellTimeGet.Value.ToString()} <br><b>Вернуть до:</b> {deadlineTime.Value.ToString()} <br><b>Последний комментарий:</b> <span style=\"color:Blue; font-size: 9pt\">{lastComments.Value.ToString()}</span><br></div><br><br>{needQuoteText}<br><br><span style=\"color:MediumAquamarine; font-size: 8pt\">Scripted by Max Kimaev</span>");
                            }
                        }
                    
                    //if (DropDownList1.SelectedValue != "choose email")
                    {
                        mailHelper1.SendMail(Request.Cookies["emailCookie"].Value, BodyforMailHelper, "ВЗЯТ");
                    }
                }
                    else if (ActionButtonGetOrReturn.Text == "RETURN_key")
                    {
                        foreach (var item in ws.FirstColumn().CellsUsed())
                        {
                            //if (item.Value.ToString().Contains(siteNameQueryString1))
                                if (item.Value.ToString() == siteNameFromUserRequest)
                                {
                            mailHelper1.KeyName = item.Value.ToString();

                            var cellTimeReturn = item.WorksheetRow().Cell(3);
                                cellTimeReturn.Value = UkraineDateTime.ToString();

                                var needCellTimeGet = item.WorksheetRow().Cell(2);
                                needCellTimeGet.Clear();

                                var deadlineTime = item.WorksheetRow().Cell(4);
                                
                                //PenaltyTime = 
                                deadlineTime.Value = "-";

                                var whereKey = item.WorksheetRow().Cell(5);
                                whereKey.Value = "на стенде";
                                var logCell = item.WorksheetRow().Cell(6);
                                logCell.Value = cellTimeReturn.Value.ToString() + "-- вернул " + User;
                                var commentCell = item.WorksheetRow().Cell(7);
                                if (commentTextBox1.Text != string.Empty)
                                {
                                    commentCell.Value = commentTextBox1.Text + " (" + UkraineDateTime.ToString() + " -- " + User + ")";
                                }
                                var history = item.WorksheetRow().Cell(8);
                                history.Value += (cellTimeReturn.Value.ToString() + "-- вернул " + User + $"({commentTextBox1.Text})" + "<br>");
                            BodyforMailHelper = string.Format($"<div style=\"font-size: 11pt;\"><b>Название ключа:</b> <a href='{Request.Url.ToString()}'>{item.Value.ToString()}</a> <br><b>Время операции:</b> {cellTimeReturn.Value.ToString()}<br><b>Последний комментарий:</b> <span style=\"color:Blue; font-size: 9pt\">{commentCell.Value.ToString()}</span><br></div><br><br>{needQuoteText}<br><br><span style=\"color:MediumAquamarine; font-size: 8pt\">Scripted by Max Kimaev</span>");
                        }
                       }
                        //if (DropDownList1.SelectedValue != "choose email")
                        {
                        mailHelper1.SendMail(Request.Cookies["emailCookie"].Value, BodyforMailHelper, "СДАН");
                    }
                }
                    exelDataBase1.Save();

                }
                Response.Redirect(Request.Url.ToString());

            
        }

        protected void LinkButton1History_Click(object sender, EventArgs e)
        {
            ShowKeyHistory(siteNameQueryString1, "1:8", true, 1);
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

        public void ShowKeyHistory(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey = true, int needColumnNumber = 1)
        {
            HeaderLabel1.Text = siteNameFromUserRequest;
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
                    
                        if (item.Value.ToString() == siteNameFromUserRequest)
                        {

                            //создаём строку
                            TableRow rowFromXL = new TableRow();

                            //получаем ячейку 3
                            var cells8 = item.WorksheetRow().Cell(8);

                            if (cells8.GetValue<string>() != string.Empty)
                            {
                            historyLabel1.Text = cells8.GetValue<string>();

                        }
                        }
                    }

                }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}