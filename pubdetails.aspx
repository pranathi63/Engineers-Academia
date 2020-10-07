<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pubdetails.aspx.cs" Inherits="pubdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Sheet1.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Sample.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Tiles.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:transparent;background-image:none;">
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="phh" runat="server" 
        style="background-color:rgba(255,255,255,0.5);position:relative;width:768px;height:511px; border-bottom-right-radius:25px;
border-top-right-radius:25px; top: -1px; left: 0px; overflow:scroll;" 
        meta:resourcekey="phResource2" >
        
        <asp:ImageButton ID="ImageButton1" runat="server" Height="24px" 
            ImageUrl="~/Images/right_circular-26.png" 
            style="margin-left: 689px; margin-top: 19px" Visible="False" Width="25px" 
            onclick="ImageButton1_Click" />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="tdgk" 
            placeholder="Write Some Thing." TextMode="MultiLine" visible="false"></asp:TextBox>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
