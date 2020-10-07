using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    String p = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "home.aspx";
      /*  TextBox2.Text=Request.QueryString["fn"];
        TextBox3.Text = Request.QueryString["ln"];
        user_name.Text = Request.QueryString["un"];*/
        try
        {
            //TextBox2.Text = Session["fname"].ToString();
            //TextBox3.Text = Session["lname"].ToString();
            user_name.Text = Session["uname"].ToString();
            p = user_name.Text;
        }
        catch (NullReferenceException) { Response.Redirect("home.aspx"); }
    }
    protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (e.Equals(user_name))
            e.IsValid = true;
        else
        {
            e.IsValid = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String pw1="",pw = "";
        try
        {
            String[] a = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "1", "2", "3", "4", "5", "j", "k", "l", "m", "n", "o", "p", "6", "7", "8", "9", "0", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int p = r.Next(0, 35);
                pw = pw + a[p];
                if(p<10)
                {
                pw1=pw1+"0"+p.ToString();
                }
                    else{
                        pw1=pw1+p.ToString();
                    }
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
            String un = user_name.Text;
            String fn = TextBox2.Text;
            String ln = TextBox3.Text;
            String mn = TextBox5.Text;
            String em = TextBox6.Text;
            if (!System.IO.Directory.Exists(@"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + un))
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + un);
            }

            String frm = "engineers.academia@gmail.com";
            String pwd = "636496c0";
            String dest = em;
            String sub = "Welcome To The World Of Researchers and Scholars.";
            String body = " You can access your account from <a href='EngineersAcademia.com'>Engineers Academia</a> </br> Thanx for Registering..</br> your Password to access your acount is " + pw;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(frm, pwd);
            MailMessage mail = new MailMessage(frm, dest, sub, body);
            smtp.Send(mail);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("insert into EA_PRO VALUES('" + un + "','" + pw1 + "','" + fn + "','" + ln + "','" + em + "'," + mn + ",'../Images/nav.jpg')", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into EA_GETIN VALUES('" + un + "','" + pw1 + "',0,'Web3/Images/nav.jpg',0.001)", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            String st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + un+@"\"+un;
            ADOX.CatalogClass cat = new ADOX.CatalogClass();
            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +st+".mdb;Jet OLEDB:Engine Type=5");
            cat = null;
            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st+ ".mdb";
            OleDbConnection con2 = new OleDbConnection(connection);
            OleDbConnection con3 = new OleDbConnection(connection);
            con2.Open();
            con3.Open();
            //DataSet dbset = new DataSet();
            string sql = "create table fallowers(id TEXT PRIMARY KEY)";
            string sql1 = "create table mails(num Counter,id TEXT,subject TEXT,msg TEXT,dat TEXT)";
            string sql2 = "create table youfallow(id TEXT PRIMARY KEY)";
            //OleDbDataAdapter adr = new OleDbDataAdapter(sql, con);
            OleDbCommand cmd2 = new OleDbCommand(sql, con2); cmd2.ExecuteNonQuery(); con2.Close();
            OleDbCommand cmd3 = new OleDbCommand(sql1, con3); cmd3.ExecuteNonQuery(); 
            OleDbCommand cmd4 = new OleDbCommand(sql2, con3); cmd4.ExecuteNonQuery(); con3.Close();
            Response.Redirect("home.aspx");
        }
        catch (Exception ex)
        {
            Page.Title = ex.ToString();
               
        }
    }
}