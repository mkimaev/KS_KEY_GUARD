<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Key_Guard_KS.Default"Culture="ru-RU" UICulture="ru-Ru" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div align="right" style="background-color: RGB(0, 159, 227); color: rgb(255, 216, 0); border-radius: 40px 10px">
        <div style="padding-right:20px">
            <asp:Label ID="LabelUser" runat="server" ></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">ВЫЙТИ</asp:LinkButton>
        </div>
    </div>
    <div style="text-align:center">
        <image src="/Images/ks_guard_image.jpg" alt="logotype" width="200" height="100"></image><br />
        
    </div>
        ЭЛЕКТРОННЫЙ ЖУРНАЛ УЧЁТА КЛЮЧЕЙ (г. Харьков)
    <br />
    <br />
        <div>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;" bgcolor="#FFF5EE" bordercolor="grey" border="0">
                        <tr>
                            <td> <fieldset> <legend>Поиск по <span style="background-color:SkyBlue">названию ключа:</span></legend>
                                Введите № Location <span style="color:grey">
                                
                                (например: kha015)</span>&nbsp;<br />
                                <asp:TextBox ID="TextBox1" runat="server"  EnableViewState="False" Text="kha" ForeColor="#999966"></asp:TextBox>
                                <asp:Button ID="SearchButton1" runat="server" Text="Поиск" BackColor="#99CCFF" BorderColor="Silver" ForeColor="Black" OnClick="SearchButton1_Click" Font-Size="9pt" ></asp:Button>
                            </fieldset>
                                </td>
                            <td><fieldset> <legend>Поиск по <span style="background-color:GreenYellow">нахождению:</span></legend>
                                <asp:DropDownList ID="DropDownList1whereButton" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1whereButton_SelectedIndexChanged">
                                    <asp:ListItem>--не выбран</asp:ListItem>
                                    <asp:ListItem>на стенде</asp:ListItem>
                                    <asp:ListItem>у инженера</asp:ListItem>
                                </asp:DropDownList>
                            </fieldset>
                                </td>
                            <td><fieldset> <legend>Поиск по <span style="background-color:Orange">User Name:</span></legend>
                                Введите имя User
                                
                                (<span style="color:grey">например: kimaev</span>)&nbsp;<br />
                                <asp:TextBox ID="TextBox2searchUser" runat="server" ></asp:TextBox>
                                <asp:Button ID="Button1searchUser" runat="server" BackColor="#FF9900" BorderColor="Silver" Font-Size="9pt" Text="Поиск" OnClick="Button1searchUser_Click" />
                            </fieldset>
                                </td>
                                <td><fieldset> <legend>Показать <span style="background-color:Yellow">весь</span> список ключей</legend>
                                <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="9pt" OnClick="LinkButton1_Click" BackColor="#FFFF66">Показать</asp:LinkButton>
                                    
                                </td>
                            
                        </tr>
                    </table>
                    <br />
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" GridLines="Both">
                        <asp:TableRow ForeColor="#3333FF" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="None">
                            <asp:TableCell>SiteName</asp:TableCell>
                            <asp:TableCell>Взят</asp:TableCell>
                            <asp:TableCell>Сдан</asp:TableCell>
                            <asp:TableCell BackColor="#FFCCFF">deadline</asp:TableCell>
                            <asp:TableCell>Нахождение</asp:TableCell>
                            <asp:TableCell>Last User Action</asp:TableCell>
                            <asp:TableCell>Last comments</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            <br />
            <br />
            <br />

            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="выберите 1 ключ" ForeColor="#FF3300" EnableViewState="False"></asp:RequiredFieldValidator>--%>
            <br />
            <br />
            <br />
            <br />
            
            <br />
            <br />
            <br />
        
        <div align="right" style="background-color: rgb(255, 216, 0); color: rgb(128, 128, 128); border-radius: 40px 10px; height:30px">
            <asp:Label ID="Label1" runat="server" Text="Идея - Володька Рузаев <br> Реализация - Max Kimaev" Font-Size="9pt" ForeColor="Gray"></asp:Label>
        </div>
    </form>
</body>
</html>
