<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="background-color:rgba(255,255,255,0.6);height: 515px; width: 1368px; margin-left: 0px; margin-top: 0px;">
<table><tr><td style="width:512px;"></td><td>
    <table style="margin-top:200px;">
    <tr><td class="hr">
    Old PassWord</td><td class="hr">:</td><td>
    <asp:TextBox ID="oldpw" TextMode="Password" runat="server" CssClass="td" BorderColor="black" placeholder="password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="newpw" 
       ErrorMessage="Old PassWord is Mandatory." ToolTip="Last_Name is required." foreColor="Red"/>   
    </td></tr>
    <tr><td class="hr">
    New PassWord</td><td class="hr">:</td><td>
    <asp:TextBox ID="newpw" TextMode="Password" runat="server" CssClass="td" BorderColor="black" placeholder="New PassWord"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="newpw" 
       ErrorMessage="New PassWord is required." ToolTip="Last_Name is required." foreColor="Red"/>   
      </td></tr>
    <tr><td class="hr">
    Conform New PassWord</td><td class="hr">:</td><td>
    <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" CssClass="td" BorderColor="black" placeholder="New PassWord"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3" 
       ErrorMessage="PassWord is required." ToolTip="Last_Name is required." foreColor="Red"/>   
        <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="TextBox3" controltocompare="newpw" operator="Equal" type="String" 
            errormessage="New PassWords Do'nt Match!" ForeColor="Red"/>
    </td></tr>
    <tr><td></td><td></td><td>
        <asp:Button ID="Button1" runat="server" CssClass="tdd" 
            BorderColor="Transparent" style="margin-left: 62px" 
            Text="Change PassWord.." onclick="Button1_Click" />
        </td></tr>
    </table></td></tr>             
</table>
    </div>
</asp:Content>

