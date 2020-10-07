<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="userhome.aspx.cs" Inherits="userhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">

    function DisableBackButton() {
        window.history.forward()
    }
    DisableBackButton();
    window.onload = DisableBackButton;
    window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
    window.onunload = function () { void (0) }
</script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="~/Styles/Tiles.css" rel="stylesheet" type="text/css" />
 <table>
 <tr>
 <td id="Div0" class="onn">
     <div class="on">
  <span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">
         &nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Cambria; font-weight:bold"> </span> </span>
         <span style="font-family: Cambria; font-weight:bold">
         <span style="font-size: xx-large; font-variant: small-caps; color: #000000;">P</span><span 
             style="color: #000000; font-size: xx-large; font-variant: small-caps;">rofile &amp; Notifi</span><span 
             style="font-size: xx-large; font-variant: small-caps; color: #000000">cations</span></span><span 
             
             
             style="font-variant: small-caps; font-size: xx-large; color: #000000; background-color: transparent">&nbsp;</span><span 
             
             style="font-variant: small-caps; font-size: xx-large; background-color: transparent"><span 
             style="font-family: Cambria; font-weight:bold; color: #000000">:</span></span><span 
             style="font-variant: small-caps; font-size: x-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;&nbsp; </span>
     &nbsp;
     <table><tr>
     <td>
     <table>
         <tr><td>
         <div class="log1" style="background-color:rgba(102,102,255,0.6);">
 <table><tr><td title="Edit Your Profile">
     <asp:ImageButton ID="ImageButton1" runat="server" cssclass="profile1" 
         Height="133px" Width="120px" onclick="ImageButton1_Click1"/></td>
     <td style="color:black;font-family:Cambria;font-variant:small-caps;font-size:20pt;"> Heyy<br /><%=Page.Title%></td></tr>
     </table>
 </div>
         </td></tr><td>
         <table><tr>
                 <td>            <div style="width:284px;height:290px; background-color:rgba(199,21,133,0.8);border-bottom-right-radius:25px;border-top-left-radius:25px;">
                     <table style="width:284px;height:284px;"><tr><td>
                         <marquee scrollamount="3" 
                             behavior="scroll" direction="up" 
                             style="width:244px;height:227px;margin-left:20px; margin-top: 4px;">
                 <asp:Label ID="my_label1" runat="server" Text="No Notifications" Style="font-size:large;color:White;"></asp:Label></marquee></td></tr>
                     <tr><td style="height:20px; font-size: large; font-family: Cambria; font-weight:bold;">
                         Notifications From Your Fallowers</td></tr></table>
                </div></td></tr>   </table></td>
     </table> </td>
         <td>
             <table><tr>
                 <td>            <div style="width:284px;height:290px; background-color:rgba(220,20,60,0.8);border-bottom-right-radius:25px;border-top-left-radius:25px;">
                     <table style="width:284px;height:284px;"><tr><td><marquee scrollamount="4" 
                             behavior="scroll" direction="up" 
                             style="width:244px;height:227px;margin-left:20px; margin-top: 17px;">
                 <asp:Label ID="my_label" runat="server" Text="No Publications" Style="font-size:large;color:White;"></asp:Label></marquee></td></tr>
                     <tr><td style="height:20px;">
                         <span style="font-family: Cambria; font-weight:bold; font-size: large">NOTIFICATIONS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         </span>
                         <asp:ImageButton ID="click" runat="server" Height="23px" 
                             ImageUrl="~/Images/right_circular-26.png" style="margin-left: 4px" 
                             title="Click For All Publications" onclick="click_Click" />
                         </td></tr></table>
                </div></td></tr> <tr><td>
         <div class="log1" style="background-color:rgba(0,204,204,0.9);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Images/electrical_sensor-128.png" 
                           onclick="ImageButton7_Click" title="EA VALUE"/>
               </td><td>
                   <center><asp:Label runat="server" id="EA" style="color:white;font-family:Cambria;font-size:60px;" Text=""></asp:Label></center> </td></tr>
               </table>
               </div>
         </td></tr>  </table>
         </td>
            </tr></table> 
     </div></td>
     <td id="Td1" class="onn">
 <div class="onq">
 <table>
 <tr>
 <td><span style="font-family: Cambria; font-weight:bold; font-size: x-large; color: #000000">QUESTIONS & ANSWERS
     </span>
     <asp:Panel  id="phh" runat="server" style="overflow:scroll; margin-top: 11px;" 
         class="ond">
     <asp:ImageButton ID="ImageButton38" runat="server" CssClass="tdfc" style="margin-right:20px;margin-top:20px;"
             ImageUrl="~/Images/cancel-26.png" onclick="ImageButton38_Click" 
             ToolTip="Submit" Visible="False"/>
         <asp:ImageButton ID="ImageButton33" runat="server" CssClass="tdfc" style="margin-right:20px;margin-top:20px;"
             ImageUrl="~/Images/ok-26.png" onclick="ImageButton3_Click" 
             ToolTip="Submit" Visible="False"/>
         <asp:ImageButton ID="ImageButton44" runat="server" CssClass="tdfc"
             ImageUrl="~/Images/question_shield-26.png" 
             style="margin-left:450px;margin-top:20px;position:relative;" onclick="ImageButton44_Click" 
             ToolTip="Ask/Say SomeThng">
         </asp:ImageButton>
         <asp:ImageButton ID="ImageButton45" runat="server" CssClass="tdfc" 
             ImageUrl="~/Images/ok-26.png" onclick="ImageButton45_Click" 
             style="margin-right:20px;margin-top:20px; width: 26px;" ToolTip="Submit" 
             Visible="False" />
         <br />
         <asp:TextBox id="ques" runat="server" CssClass="tdgkk" 
            placeholder="Write Some Thing." TextMode="MultiLine" 
             Visible="False"></asp:TextBox>
     </asp:Panel>
 </td>
 </tr>
 </table>
 </div>
 </td>
 <td id="Div1" class="onp">
 <div class="op" >
 <span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">
     &nbsp;&nbsp;</span><span 
         style="font-variant: small-caps; font-size: x-large; color: #808080; background-color: transparent">&nbsp;&nbsp; </span>
     <span style="font-variant: small-caps; font-size: x-large; color: #000000; background-color: transparent; font-family: Cambria; font-weight:bold;">
     Basic TILes:</span><span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;&nbsp; </span>
     &nbsp;
     <table><tr><td>
     <table>
      <tr><td>
        <div class="log1" style="background-color:rgba(199,21,133,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/search-128.png" 
                           onclick="ImageButton22_Click" title="Search"/>
               </td><td>
                   <asp:TextBox ID="search" runat="server" CssClass="tb" placeholder="search"></asp:TextBox></td></tr>
               </table>
        </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(0,250,154,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/Images/package-128.png" 
                           onclick="ImageButton2_Click" title="Upload Publication"/>
               </td><td style="color:black;font-family:Cambria;font-size:20pt;">Upload Publication</td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(0,153,153,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/Images/send_file-128.png" 
                           onclick="ImageButton11_Click" title="EA-Mail"/>
               </td><td style="color:black;font-family:Cambria;font-size:xx-large;">
                       <span style="margin-left:50px;font-size:x-small; font-style: italic"><a style="color: #FFFFFF">Compose Mail</a></span>
                   <asp:ImageButton runat="server" id="Compose" ImageUrl="~/Images/comments-26.png" 
                           onclick="Unnamed1_Click" Width="19px" title="compose mail">
                   </asp:ImageButton>
                       </br>EA-Mail
                       <br />
                       <asp:Label runat="server" ID="mails" Style="margin-left:110px" Text="0"></asp:Label>
                       </td>
               </tr>
               </table>
               </div>
         </td></tr>
         
     </table></td></tr></table>
 </div>
 </tr></table>
</asp:Content>

