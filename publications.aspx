<%@ Page Title="Publications" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="publications.aspx.cs" Inherits="publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="background-color:rgba(255,255,255,0.8);height: 510px; width: 1368px; margin-left: 0px; margin-top: 0px;">
<table>             
        <tr><td style="width:512px;">
        <center style="color: #000000; font-family: Magneto; font-size: medium">
            <span style="font-size: large">Terms And Conditions To Uplaod Publications:</span><br /></br></center>
            <span style="margin-left:80px;font-size: medium; color: #000000">1.File Must Be in .pdf Format.<br /></span>
            <span style="margin-left:80px;font-size: medium; color: #000000">2.Title and FileName Should'nt match.
            <br /></span>
            <span style="margin-left:80px;font-size: medium; color: #000000">3.Authors List Limits to 5. </span>
            
    </td>
            <td>
                <table style="margin-top:100px;">
                <tr><td style="width: 260px;">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="td" placeholder="Title Of Paper"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" 
       ErrorMessage="Title is required." ToolTip="Required." foreColor="Red"/></td><td class="hr">:</td><td class="hr">
    Title Of Paper</td></tr>
                <tr><td style="width: 260px">
    <asp:TextBox ID="TextBox2" runat="server" CssClass="td" ReadOnly="true"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/plus-26.png" OnClick="ImageButton1_Click" Width="30px" />
                    </td>
    <td class="hr">:</td><td class="hr">Author Name(s) </td>
                   </tr>
                    <tr><td style="width: 260px">
    <asp:TextBox ID="TextBox3" runat="server" CssClass="td" Visible="false"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/plus-26.png" OnClick="ImageButton2_Click" Width="30px" Visible="false"/></td></tr>
                      <tr><td style="width: 260px">
    <asp:TextBox ID="TextBox4" runat="server" CssClass="td" Visible="false"></asp:TextBox>
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/plus-26.png" OnClick="ImageButton3_Click" Width="30px" Visible="false"/></td></tr>
                      <tr><td style="width: 260px">
    <asp:TextBox ID="TextBox5" runat="server" CssClass="td" Visible="false"></asp:TextBox>
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/plus-26.png" OnClick="ImageButton4_Click" Width="30px" Visible="false"/></td></tr>
                      <tr><td style="width: 250px">
    <asp:TextBox ID="TextBox6" runat="server" CssClass="td"  Visible="false"></asp:TextBox>
                          </td></tr>
                      <tr>
                        <td style="width: 219px"><asp:FileUpload id="FileUploadControl" runat="server" CssClass="td" EnableTheming="True" ViewStateMode="Disabled" style="width: 225px"/>
    </td><td></td><td ><asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" CssClass="tdd"/>
                    </td>
                    </tr>
                </table>
            </td></tr>
    </table>
    </div>
</asp:Content>

