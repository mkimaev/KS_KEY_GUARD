<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeyOperations.aspx.cs" Inherits="Key_Guard_KS.KeyOperations" Culture="ru-RU" UICulture="ru-Ru" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
        <asp:UpdateProgress runat="server">
            <ProgressTemplate>
                <img src="/Images//ajax-loader.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        </div>
            <h2>
                <asp:Label ID="HeaderLabel1" runat="server" Text="empty" ForeColor="#0066FF"></asp:Label>
            </h2>
        <div align="right" style="background-color: RGB(0, 159, 227); color: rgb(255, 216, 0); border-radius: 40px 10px">
            
            <div style="padding-right:20px">
                
                    
                
                <asp:Label ID="LabelUser" runat="server" Text="">        </asp:Label> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">         ВЫЙТИ</asp:LinkButton>
            </div>
        </div>
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Images/home_button_back.jpg" Width="75px" Height="25" style="border-radius: 60px 0 0 60px; border: 1px solid orange;" OnClick="ImageButton1_Click" />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Table ID="Table1" runat="server" BorderStyle="Solid" GridLines="Both" >
                        <asp:TableRow ForeColor="Black" HorizontalAlign="Center" BorderColor="#9999FF" BorderStyle="None" BackColor="#CCCCFF">
                            <asp:TableCell>SiteName</asp:TableCell>
                            <asp:TableCell>Взят</asp:TableCell>
                            <asp:TableCell>Сдан</asp:TableCell>
                            <asp:TableCell BackColor="#FFCCCC">Deadline</asp:TableCell>
                            <asp:TableCell>Нахождение</asp:TableCell>
                            <asp:TableCell>Last User Action</asp:TableCell>
                            <asp:TableCell>Last comment</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ActionButtonGetOrReturn"/>
            </Triggers>
        </asp:UpdatePanel>
           
                <br />
        <br />
        <asp:Literal ID="LiteralComment" runat="server"></asp:Literal>
           
                <br />
        <asp:TextBox ID="commentTextBox1" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
            <br />

                <br />
        <br />
                <asp:Button ID="ActionButtonGetOrReturn" runat="server" Text="" BackColor="#66FF66" style="border-radius: 6px;" Font-Size="Small" Height="25px" Width="116px" Visible="false" OnClick="ActionButtonGetOrReturn_Click"></asp:Button>
                <br />

        
        <br />
        <br />
        
        <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Images/home_button_back.jpg" Width="75px" Height="25" style="border-radius: 60px 0 0 60px; border: 1px solid orange;" OnClick="ImageButton1_Click" />--%>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="background-color: RGB(0, 159, 227); color: rgb(255, 216, 0); border-radius: 40px 10px; width:520px; padding-left:20px"><br />
                    <asp:Panel ID="Panel1" runat="server" GroupingText="История ключа" width="470px" >
                    <asp:LinkButton ID="LinkButton1History" runat="server" OnClick="LinkButton1History_Click">Показать всю историю ключа</asp:LinkButton><br />
            <asp:Label ID="historyLabel1" runat="server" Font-Size="Smaller"></asp:Label>
            </asp:Panel><br />
                </div>
            </ContentTemplate>
            
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LinkButton1History"/>
            </Triggers>
        </asp:UpdatePanel>
        
        <br />
        <br />
        <div align="right" style="background-color: rgb(255, 216, 0); color: rgb(128, 128, 128); border-radius: 40px 10px; height:30px">
            Created by Max Kimaev
        </div>
    </form>
</body>
</html>
