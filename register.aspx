<%@ Page Title="registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="background-color:rgba(255,255,255,0.6);height: 515px; width: 1368px; margin-left: 0px; margin-top: 0px;">
<table><tr><td style="width:512px;">
    </td><td>
    <table style="margin-top:50px;">
    <tr><td style="width: 245px">
        <asp:TextBox ID="user_name" runat="server" CssClass="td" ReadOnly="true"></asp:TextBox>
       </td><td class="hr">:</td><td class="hr">
    User_Name</td></tr>
    <tr><td style="width: 245px">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="td" placeholder="Re-Enter UserName"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" 
       ErrorMessage="UserName is required." ToolTip="Last_Name is required." foreColor="Red"/>   
        <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="TextBox1" controltocompare="user_name" operator="Equal" type="String" 
            errormessage="UserNames Do'nt Match!" ForeColor="Red"/>
            </td><td class="hr">:</td><td class="hr">
    Enter Above User_Name</td></tr>
    <tr><td style="width: 245px">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="td" placeholder="First Name"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" 
       ErrorMessage="First_Name is required." ToolTip="First_Name is required." foreColor="Red"/></td><td class="hr">:</td><td class="hr">
    First Name</td></tr>
    <tr><td style="width: 245px">
    <asp:TextBox ID="TextBox3" runat="server" CssClass="td" placeholder="Last Name"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" 
       ErrorMessage="Last_Name is required." ToolTip="Last_Name is required." foreColor="Red"/></td><td class="hr">:</td><td class="hr">
    Last Name</td></tr>
    <tr><td style="width: 245px">
    <asp:TextBox ID="TextBox6" runat="server" CssClass="td" placeholder="Email"></asp:TextBox>
    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="TextBox6" 
       ErrorMessage="E-mail is required." ToolTip="E-mail is required." foreColor="Red"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  runat="server" ControlToValidate="TextBox6" 
       ErrorMessage ="E-mail address not vailid" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"/>
    </td><td class="hr">:</td><td class="hr">
    E-mail</td></tr>
    <tr><td style="width: 245px">
    <asp:TextBox ID="TextBox5" runat="server" CssClass="td" placeholder="Mobile No"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox5" 
       ErrorMessage="Mobile-No is required." ToolTip="Mobile-No is required." foreColor="Red"/>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox5" ErrorMessage="Enter Valid mobile no. " 
                        ValidationExpression="\d{10}" ForeColor="red"/>
                                       </td><td class="hr">:</td><td class="hr">
    Mobile no</td></tr>
    <tr><td></td><td></td><td style="width: 245px">
        <asp:Button ID="Button1" runat="server" CssClass="tdd" 
             style="margin-left: 62px" 
            Text="Register.." onclick="Button1_Click" />
        </td></tr>
    </table></td></tr>             
</table>
    </div>
</asp:Content>

