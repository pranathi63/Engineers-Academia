<%@ Page  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="_Default"%>

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
    <head><link href="~/Styles/Sheet1.css" rel="stylesheet" type="text/css" /></head>
    <a href="#Div0"><div id="side" class="tw" title="Home"></div></a>
    <a href="#Div2"><div id="Div5" class="tww" title="Updates"></div></a>
    <a href="#Div3"><div id="Div7" class="twi" title="Search"></div></a>
    <a href="#Div3"><div id="Div6" class="twj" title="Login"></div></a>
 <table id="tpp">
 <tr>
 <td id="Div0" class="onn">
 <div class="on">
     <span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;&nbsp;</span><span 
         style="font-variant: small-caps; color: #000000; background-color: transparent"><span 
         style="font-family: Magneto; font-size: x-large"> Our Inspiration</span></span><span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;&nbsp;</span><span 
         style="font-variant: small-caps; color: #000000; background-color: transparent"><span 
         style="font-family: Magneto; font-size: x-large">&nbsp;&amp; About us:</span></span><span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent"> </span>&nbsp;
     <table><tr><td>
     <table>
         <tr><td>
         <div class="log1">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/ResearchGate_Logo (1).png"  
                           OnClientClick="window.document.forms[0].target='_blank';" onclick="ImageButton16_Click" title="Research Gate" CssClass="log3"/>
               </td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/linkedin.jpg" 
                           OnClientClick="window.document.forms[0].target='_blank';" onclick="ImageButton15_Click" title="Linkedin" CssClass="log3"/>
               </td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/facebook.jpg" 
                           OnClientClick="window.document.forms[0].target='_blank';" onclick="ImageButton14_Click" title="Facebook" CssClass="log3"/>
               </td></tr>
               </table>
               </div>
         </td></tr>
     </table></td>
     <td>
     <table>
         <tr><td>
         <div class="log1" style="background-color:rgba(255,123,255,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/quill_with_ink-128.png" 
                           onclick="ImageButton13_Click" title="Motto"/>
               </td><td style="color:black;font-family:Cambria;font-size:xx-large;">Main<br />Motto</td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(0,250,154,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/Images/graduation_cap-128.png" 
                           onclick="ImageButton12_Click" title="Qualification"/>
               </td><td style="color:black;font-family:Cambria;font-size:20pt;">Qualification</td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(220,20,60,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/Images/creek-128.png" 
                           onclick="ImageButton11_Click" title="Engineers Academia"/>
               </td><td style="color:black;font-family:Cambria;font-size:xx-large;">Engineers<br />Academia</td>
               </tr>
               </table>
               </div>
         </td></tr>
     </table> </td></tr></table>
 </div>
 </td>
 <td id="div12" class="onn">
 <div class="on">
 <span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;</span><span 
         style="font-variant: small-caps; color: #000000; background-color: transparent"><span 
         style="font-family: Magneto; font-size: x-large">&nbsp;About Engineering&nbsp;&nbsp;:</span></span><span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp; </span>
     &nbsp;
     <table><tr><td>
     <table>
         <tr><td>
         <div >
               <table>
               <tr><td class="log2" style="background-color:rgba(0,204,204,0.8);">
                   <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/historical-128.png" 
                           onclick="ImageButton10_Click" title="History"/>
               </td><td class="log2" style="background-color:rgba(0,128,0,0.7);">

               <asp:ImageButton ID="ImageButton16" runat="server" ImageUrl="~/Images/bobbin-128.png" 
                           onclick="ImageButton9_Click" title="Sustainability"/>
               </td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(255,255,0,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/system_information-128.png" 
                           onclick="ImageButton8_Click" title="CSE"/>
               </td><td style="color:black;font-family:Cambria;font-size:x-large;">Computer<br />Science<br />Engineering</td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(199,21,133,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Images/electronics-128.png" 
                           onclick="ImageButton7_Click" title="Electrical"/>
               </td><td style="color:black;font-family:Cambria;font-size:x-large;">Electrical<br />Engineering</td></tr>
               </table>
               </div>
         </td></tr>
     </table></td><td>
     <table>
         <tr><td>
         <div class="log1" style="background-color:rgba(250,8,49,0.7);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Images/stepper_motor-128.png" 
                           onclick="ImageButton6_Click" title="Mechanical"/>
               </td><td style="color:black;font-family:Cambria;font-size:x-large;">Mechanical</br>Engineering</td>
               </tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(188,143,143,0.7);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/Images/informatics-128.png" 
                           onclick="ImageButton5_Click" title="IT"/>
               </td><td style="color:black;font-family:Cambria;font-size:x-large;">Information</br>Technology</td></tr>
               </table>
               </div>
         </td></tr>
         <tr><td>
         <div class="log1" style="background-color:rgba(0,255,0,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton15" runat="server" ImageUrl="~/Images/church-128.png" 
                           onclick="ImageButton4_Click" title="Civil"/>
               </td><td style="color:black;font-family:Cambria;font-size:20pt;">&nbsp;&nbsp;&nbsp;&nbsp;Civil</br>Engineering</td></tr>
               </table>
               </div>
         </td></tr>
     </table> </td></tr></table>
 </div>
 </td>
 <td id="Div3" class="onp">
 <div class="op">
     <span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;</span><span 
         style="font-variant: small-caps; color: #000000; background-color: transparent"><span 
         style="font-family: Magneto; font-size: x-large">Basic Tiles:</span></span><span style="font-variant: small-caps; font-size: xx-large; color: #808080; background-color: transparent">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </span>
     
 <table><tr><td>
               <div class="log1" style="background-color:rgba(0,204,204,0.8);">
               <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/search-128.png" 
                           OnClientClick="window.document.forms[0].target='_blank';" onclick="ImageButton2_Click" title="Search"/>
               </td><td>
                   <asp:TextBox ID="TextBox1" runat="server" CssClass="tb" placeholder="search"></asp:TextBox></td></tr>
               </table>
        </div></td></tr>
        <tr>
        <td><div class="log1" style="background-color:rgba(102,204,0,0.8);">
        <table>
               <tr><td>
                   <span style="font-variant: small-caps; font-size: x-large; color: #000000"><center>Login</center></span></td><td><a href="changepassword.aspx">
                   <img src="Images/password1-26.png" alt="Forgot Password" title="Recover PassWord"/></a><span style="font-size: x-small; font-style: italic"><a style="color: #FFFFFF">ForgotPassword</a></span></td>
                       </tr><tr><td>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="tb" placeholder="UserName"/>
                   <asp:TextBox ID="TextBox3" TextMode="password" runat="server" CssClass="tb" placeholder="passWord"/>
               </td><td>
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/login-128.png" 
                           onclick="ImageButton1_Click" title="Login" Height="87px" Width="96px"/>
               </td>
               </tr>
               </table>
        </div>
        </td>
        </tr>
        <tr>
        <td>
        <div class="log1" style="background-color:rgba(250,8,49,0.8); width: 285px;">
        
        <table>
               <tr><td>
                   <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/dossier-128.png" OnClick="ImageButton3_Click" style="font-style: italic" />
               </td><td style="color:white;font-family:Cambria;font-size:x-large;">Are You New user..??<br />Register Now </td></tr>
               </table>
        </div>
        </td>
        </tr>
        </table>
 </div>
 </td>
 </tr>  
       </table>
</asp:Content>

