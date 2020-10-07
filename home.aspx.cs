using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using System.Web.Security;
//using System.Speech.Synthesis;
public partial class _Default : System.Web.UI.Page
{
    OpenIdRelyingParty openid = new OpenIdRelyingParty();
    String UN, pw,pp,pq;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Contents.RemoveAll();
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "home.aspx";
        if (!IsPostBack)
        {
            // Google Login
            HandleOpenIDProviderResponse();
        }
    }
    protected void HandleOpenIDProviderResponse()
    {
        var response = openid.GetResponse();

        if (response != null)
        {
            if (response.Status == AuthenticationStatus.Authenticated)
            {
                var fResponse = response.GetExtension<FetchResponse>();
                Session["fResponse"] = fResponse;
                var res = Session["fResponse"] as FetchResponse;

                String email = res.GetAttributeValue(WellKnownAttributes.Contact.Email);
                String fn=res.GetAttributeValue(WellKnownAttributes.Name.First);
                String ln=res.GetAttributeValue(WellKnownAttributes.Name.Last);
                int j = 0,k;
                j = email.IndexOf("@nmrec.edu.in");
                k=email.IndexOf("@");
                String pq = email.Substring(0,k);
                try
                {
                    //Session["fname"] = fn; Session["lname"] = ln;
                    Session["uname"] = pq;
                    // You can redirect user to your home page also.
                    //Response.Redirect("~/LoginFromSocial.aspx", false);
                    //String ss= "User Login Successfully. Name: " + fullName + "Email: " + email + " birthdate:" + birthDate + " mobile:" + mobile;
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ss+"')", true);
                    if(j>0)
                    {
                        Response.Redirect("register.aspx");
                    }
                        
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You must Login With \\nEmail Id Provided By College.\\nBefore That Close And Reopen You Browser\\nOr Login Into Gmail And Logout From It')", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex+"')", true);
                }
            }
            else if (response.Status == AuthenticationStatus.Canceled)
            {
                //"Cancelled.";
                //FailureText.Text = "Login Cancelled.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Login Cancelled...')", true);
                Response.Redirect("home.aspx");
            }
            else if (response.Status == AuthenticationStatus.Failed)
            {
                //"Login Failed.";
                //FailureText.Text = "Login Failed.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You Have Provided Wrong Credentials' )", true);
               
            }
        }
        else
        {
            return;
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        UN = TextBox2.Text;
        pw = TextBox3.Text;

        try
        {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (con.State == ConnectionState.Closed)
                con.Open();
        String[] a = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "1", "2", "3", "4", "5", "j", "k", "l", "m", "n", "o", "p", "6", "7", "8", "9", "0", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i <pw.Length; i++)
        {
            string d = pw.Substring(i, 1);
            int j = Array.IndexOf(a, d);
             if(j<10)
                {
                pp=pp+"0"+j.ToString();
                }
                    else{
                        pp=pp+j.ToString();
                    }
            
        }
            SqlCommand cmd = new SqlCommand("select * from EA_GETIN where EA_UN='"+UN+"' and EA_PW='"+pp+"'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["eid"] = UN;
                    Response.Redirect("userhome.aspx");

            }
            else
            {
                //SpeechSynthesizer reader = new SpeechSynthesizer();
                //reader.Speak("This is my first speech project");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credentials...' )", true);
            }
                

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex+"')", true);
        }
       }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
            string discoveryUri = "https://www.google.com/accounts/o8/id";
            var b = new UriBuilder(Request.Url) { Query = "" };
            var req = openid.CreateRequest(discoveryUri, b.Uri, b.Uri);
            var fetchRequest = new FetchRequest();
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
            req.AddExtension(fetchRequest);
            req.RedirectToProvider();
    }
    private static string GetFullname(string first, string last)
    {
        var _first = first ?? "";
        var _last = last ?? "";
        if (string.IsNullOrEmpty(_first) || string.IsNullOrEmpty(_last))
            return "";

        return _first + " " + _last;
    }
    protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://www.researchgate.org");
    }
    protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://www.linkedin.com");

    }
    protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://www.facebook.com/");
    }
    protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mainmoto.aspx");
    }
    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("qualifications.aspx");

    }
    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EA.aspx");
    }
    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("history.aspx");
    }
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("systa.aspx");
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("cse.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ece.aspx");
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mech.aspx");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("IT.aspx");
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("civil.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        String p = TextBox1.Text;
        Response.Redirect("https://www.google.co.in/search?q="+p);
    }

}