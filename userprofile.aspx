<%@ Page Title="User_Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="userprofile.aspx.cs" Inherits="userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="background-color:rgba(255,255,255,0.8);">
    <table style="width:auto; height: 510px;">
        <tr>
            <td style="border-right-style:solid;border-right-width:thin;width: 325px; ">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" 
                        style="margin-top: 20px;color: #000000; font-size: x-large; font-family: Cambria; font-weight:bold" 
                        Text="User Image:"></asp:Label>
            <asp:Image ID="Image1" runat="server"
                    style="margin-left: 89px; margin-top: 20px" Height="310px" 
    Width="232px"  />
            </iframe>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" 
                    style="margin-left: 90px; margin-top: 9px" Width="230px" Visible="False" />
                <br />
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" CssClass="tdfc" 
                    ImageUrl="~/Images/right_circular-26.png" onclick="ImageButton1_Click" 
                    ToolTip="Edit" />
                <asp:ImageButton ID="ImageButton4" runat="server" CssClass="tdfc" 
                    ImageUrl="~/Images/ok-26.png" onclick="ImageButton4_Click" ToolTip="Submit" 
                    Visible="False" Width="23px" />
            </td>
            <td style="border-right-style:solid;border-right-width:thin;width: 425px">
                <div style="height: 510px; width: 431px; margin-left: 0px;">
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" 
                        style="color: #000000; font-size: x-large; font-family: Cambria; font-weight:bold" 
                        Text="User Details:"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="width: 84%; height: 227px; margin-left: 60px;">
                        <tr>
                            <td style="font-family: Cambria; font-weight:bold; font-size: large; width: 151px; color: #000000">
                                <i>First Name</i></td>
                            <td style="width: 41px; font-size: large; color: #000000">
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="td" ForeColor="Black" 
                                    ReadOnly="True" Width="219px" BorderColor="Black"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 151px; font-family: 'Matura MT Script Capitals'; font-size: large; color: #000000">
                                LastName</td>
                            <td style="width: 41px; color: #000000; font-size: large">
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="td" ForeColor="Black" 
                                    ReadOnly="True" Width="219px" BorderColor="Black"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 151px; font-family: 'Matura MT Script Capitals'; font-size: large; color: #000000">
                                Email</td>
                            <td style="width: 41px; color: #000000; font-size: large">
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="td" ForeColor="Black" 
                                    ReadOnly="True" Width="219px" BorderColor="Black"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 151px; font-family: 'Matura MT Script Capitals'; font-size: large; color: #000000">
                                Mobile_No</td>
                            <td style="width: 41px; font-size: large; color: #000000">
                                <strong>:</strong></td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="td" Font-Size="Large" 
                                    ForeColor="Black" ReadOnly="True" Width="218px" BorderColor="Black"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="tdfc" 
                        ImageUrl="~/Images/right_circular-26.png" onclick="ImageButton2_Click" 
                        ToolTip="Edit" />
                &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" CssClass="tdfc" 
                        ImageUrl="~/Images/ok-26.png" onclick="ImageButton3_Click" ToolTip="Submit" 
                        Visible="False" Width="23px" />
                        </br>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/changepassword.aspx"><span style="font-size: medium; color: #000000; font-family: Cambria; font-weight:bold">Change 
                    Password</span></asp:HyperLink>
                    </div>
            </td>
            <td style="border-right-style:solid;border-right-width:thin;">
                <br />
                <br />
                <span style="font-family: Cambria; font-weight:bold; font-size: x-large; font-style: italic; color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; User Publicatons
                : </span>
                <asp:Panel ID="phh" runat="server" Height="389px" style="margin-left:50px;margin-top: 53px">
                </asp:Panel>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>

