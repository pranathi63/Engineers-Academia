<%@ Page Title="Inbox" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="inbox.aspx.cs" Inherits="inbox" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="scrollbar" style="height: 515px; width: 1368px;">
    <table><tr><td><asp:Panel ID="ph" runat="server" 
        style="background-color:rgba(255,255,255,0.8);position:relative; margin-left:100px;width:368px;height:510px;overflow:scroll;overflow-X:hidden;" 
        meta:resourcekey="phResource1" >
    </asp:Panel></td><td>
    <asp:Panel ID="phh" runat="server" 
        style="background-color:rgba(255,255,255,0.8);position:relative;width:768px;height:510px;" 
        meta:resourcekey="phResource2" >
    </asp:Panel></td></tr></table>
</div>
</asp:Content>

