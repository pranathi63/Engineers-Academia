<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="mailing.aspx.cs" Inherits="mailing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="background-color:rgba(255,255,255,0.8);height: 515px; width: 1368px; margin-left: 0px; margin-top: 0px;">
<table><tr><td style="width:512px;">
    </td><td>
    <table>
    <tr><td class="hr">
    To :</td></tr>
    <tr><td>
        <asp:TextBox ID="Tod" runat="server" CssClass="td"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tod" 
       ErrorMessage="Destination not Specified" ToolTip="Destination not Specified" foreColor="Red"/>  
       </td></tr>
       <tr><td class="hr">
    Subject:</td></tr>
    <tr><td>
    <asp:TextBox ID="subj" runat="server" CssClass="tdeg" placeholder="Subject For Message." ></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="subj" 
       ErrorMessage="Must Write SomeThing." ToolTip="Subject For Message." foreColor="Red"/>        
        </td></tr>
       <tr><td class="hr">
    Write Your Message:</td></tr>
    <tr><td>
    <asp:TextBox ID="msg" runat="server" CssClass="tde" 
            placeholder="Write Some Thing." TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="msg" 
       ErrorMessage="Must Write SomeThing." ToolTip="Write Some Thing." foreColor="Red"/>        
        </td></tr>
        <tr><td>
        <asp:Label runat="server" ID="stat" Text="" style="Color:Black;"></asp:Label>
            <asp:LinkButton  runat="server" CssClass="tdg" 
            BorderColor="Transparent" style="color:green;float:right;" 
            Text="Send.." onclick="Button1_Click" >send..</asp:LinkButton>
        </td></tr>
    </table></td></tr>             
</table>
    </div>
</asp:Content>

