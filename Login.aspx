<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Key_Guard_KS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-image: url(Images/ks_scratchcard.jpg);
            background-repeat:no-repeat;
            background-position:top;
            font-size: 14px;
            
        }
        
        .auto-style1 {
            width: 106px;
            color:gold;
        }
        .auto-style2 {
            margin-left: 600px;
            margin-top: 70px;
            
        }

        
    </style>
</head>
<body bac>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style1" >
                        Введите логин
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxLogin1" runat="server" CssClass="auto-style3" Width="151px" EnableViewState="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        Введите пароль
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword1" runat="server" CssClass="auto-style3" Width="150px" TextMode="Password" EnableViewState="False"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" Text="Войти" OnClick="Button1_Click" style="border-radius: 6px;"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="LabelStatus" runat="server" EnableViewState="False" ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
        <div>
        </div>
        <br />
            <br />
            <br />
            <br />
        <br />
            <br />
            <br />
            <br />
        <br />
            <br />
            <br />
            <br />
        <br />
            <br />
            <br />
            <br />
        <br />
            <br />
            <br />
            <br />
    </form>
</body>
</html>
