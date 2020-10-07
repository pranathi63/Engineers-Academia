<%@ Page Title="Publications" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="allpublicatons.aspx.cs" Inherits="allpublicatons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="scrollbar" style="height: 515px; width: 1368px;">
    <table><tr><td><asp:Panel ID="ph" runat="server" 
        style="background-color:rgba(255,255,255,0.8);position:relative; margin-left:100px;width:368px;height:510px;overflow:scroll;overflow-X:hidden;" 
        meta:resourcekey="phResource1" >
    </asp:Panel></td><td>
    <iframe id="iff" runat="server" style="background-color:rgba(255,255,255,0.5);position:relative;width:768px;height:511px;" ></iframe>
    </td></tr></table>
</div>
</asp:Content>

