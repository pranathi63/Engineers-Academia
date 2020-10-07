using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
public partial class userhome : System.Web.UI.Page
{
    String p = ""; String n = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    protected void Page_Load(object sender, EventArgs e)
    {

        ques.Visible = false;
        try
        {
            p = Session["eid"].ToString();

            ImageButton1.ImageUrl = @"../"+p+@"/Profile.jpg";
            HyperLink h = (HyperLink)Master.FindControl("Hyper");
            h.NavigateUrl = "userhome.aspx";
            SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select EA_CN from EA_GETIN where EA_UN='" + p + "'", cond);
            SqlDataReader drd = cmdd.ExecuteReader();
            if (drd.Read())
            {
                int j = drd.GetInt32(0);
                mails.Text = j.ToString();
            }
            drd.Close();double fp = 0;
            SqlCommand cmdde = new SqlCommand("select * from EA_PUB where PB_ATH='"+p+"'", cond);
            SqlDataReader drde = cmdde.ExecuteReader();
            while (drde.Read())
            {
                fp = fp + drde.GetDouble(5);
            }
            drde.Close(); EA.Text = fp.ToString();
            SqlCommand cmddf = new SqlCommand("update EA_GETIN set EA_EA="+fp+" where EA_UN='" + p + "'", cond);
            cmddf.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("select * from EA_PUB ORDER BY PB_NUM DESC", cond);
            SqlDataReader drr = cmd1.ExecuteReader();
            String a, b, pn = "";
            int po = 1;
            
            while (drr.Read())
            {
                if (po <= 10)
                {
                    pn = pn + "</br>";
                    a = drr.GetString(0); b = drr.GetString(1);
                    SqlConnection cone = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
                    if (cone.State == ConnectionState.Closed)
                        cone.Open();
                    SqlCommand cmd2 = new SqlCommand("select EA_LN from EA_PRO where EA_UN='" + b + "'", cone);
                    SqlDataReader drrr = cmd2.ExecuteReader(); String pd = "";
                    if (drrr.Read())
                    { pd = drrr.GetString(0); }
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<span style='color:Yellow;font-size:x-large;font-variant:small-caps;'>" + pd + "</span>" + " Shared >>" + a);
                    pn = pn + sb.ToString().Replace(Environment.NewLine, " ");
                    my_label.Text = pn;
                    po = po + 1;
                }
                else
                {
                    break;   
                }
            } drr.Close();
            SqlCommand cmd5 = new SqlCommand("select * from EA_NOT where NOT_TO='"+p+"' ORDER BY NOT_ID DESC", cond);
            SqlDataReader dr1 = cmd5.ExecuteReader();
             String ppn ="";
            while (dr1.Read())
            {
                     ppn=ppn + "</br>";
                    StringBuilder sbb = new StringBuilder();
                    sbb.AppendLine("<span style='color:Yellow;font-size:large;font-variant:small-caps;'>" + dr1.GetString(1) + ">></span>" + dr1.GetString(3)+" on " +dr1.GetString(4));
                    ppn = ppn + sbb.ToString().Replace(Environment.NewLine, " ");
                    my_label1.Text = ppn;
                
            } dr1.Close();
            cond.Close();

            String pq = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("select * from EA_PRO where EA_UN='" + p + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                Page.Title = dr.GetString(2) + " " + dr.GetString(3);
            }
            dr.Close();
            con.Close();
        }
        catch (NullReferenceException)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex+"' )", true);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Session Expired..')", true);
            Response.Redirect("home.aspx");
        }
        SqlConnection coned = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (coned.State == ConnectionState.Closed)
            coned.Open();
        SqlCommand cm = new SqlCommand("select * from EA_QUES where Q_ST='Q' ORDER BY Q_ID DESC", coned);
        SqlDataReader dtr = cm.ExecuteReader();
        int i = 0;
        while(dtr.Read())
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            Label l = new Label();
            l.Font.Size = 14;
            ImageButton myLnkBtn1 = new ImageButton();
            myLnkBtn1.ID = "ans" + i;
            myLnkBtn1.CssClass = "rep";
            myLnkBtn1.Command += new CommandEventHandler(Unnamed2_Click);
            myLnkBtn1.CommandArgument = dtr.GetInt32(0).ToString();
            myLnkBtn1.ImageUrl = "../Images/plus-26.png";
            myLnkBtn1.ToolTip = "Answer"; 
            l.Text = "Q:<span style='color:Blue;font-family:magento;'>" + dtr.GetString(1)+"</span>";
            TextBox t = new TextBox();
            t.ReadOnly = true;
            t.CssClass = "ques";
            t.TextMode = TextBoxMode.MultiLine;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(dtr.GetString(2));
            sb.AppendLine();
            t.Text = sb.ToString();
            div1.Controls.Add(l); 
            div1.Controls.Add(t); 
            div1.Controls.Add(myLnkBtn1);
            string pd=dtr.GetInt32(0).ToString()+"A";
            SqlConnection cod = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
            if (cod.State == ConnectionState.Closed)
                cod.Open();
            SqlCommand cme = new SqlCommand("select * from EA_QUES where Q_ST='" + pd + "' ORDER BY Q_ID DESC", cod);
            SqlDataReader dtrr = cme.ExecuteReader();
            while (dtrr.Read())
            {
                Label ll = new Label();
                ll.Font.Size = 14; ll.CssClass = "lab";
                ll.Text = "A:<span style='color:green;font-family:magento;'>" + dtrr.GetString(1) + "</span>";
                TextBox tt = new TextBox();
                tt.CssClass = "ans";
                tt.TextMode = TextBoxMode.MultiLine;
                tt.ReadOnly = true;
                StringBuilder sbb = new StringBuilder();
                sbb.AppendLine(dtrr.GetString(2));
                sbb.AppendLine();
                tt.Text = sbb.ToString();
                div2.Controls.Add(ll);
                div2.Controls.Add(tt);
            } dtrr.Close();
            cod.Close();
            div.Controls.Add(div1);
            div.Controls.Add(new LiteralControl("<br />"));
            div.Controls.Add(div2);
            phh.Controls.Add(div);
            i++;
        }
        dtr.Close();
        coned.Close();
    }
    protected void Unnamed2_Click(object sender, CommandEventArgs e)
    {
        ViewState["qid"] = e.CommandArgument.ToString();
        ImageButton45.Visible = true;
        ques.Visible = true;
        ImageButton38.Visible = true;
        ImageButton44.Visible = false;
        
    }
    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/inbox.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("publications.aspx");
    }
    protected void click_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("allpublicatons.aspx");
    }
    protected void ImageButton22_Click(object sender, ImageClickEventArgs e)
    {
        String s = search.Text;
        Response.Redirect("searchppr.aspx?srch="+s+"");
    }
    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/mailing.aspx?id=" + null + "");
    }
    protected void Unnamed2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userprofile.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        String s = ques.Text;
        SqlConnection coned = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (coned.State == ConnectionState.Closed)
            coned.Open();
        SqlCommand cm = new SqlCommand("insert into EA_QUES(Q_UID,Q_TXT,Q_ST) values('" + p + "','" + s + "','Q')", coned);
        cm.ExecuteNonQuery();
        String stt = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + p + @"\" + p;
        string connec = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + stt + ".mdb";
        OleDbConnection cont = new OleDbConnection(connec);
        cont.Open();
        string sql7 = "select * from fallowers";
        OleDbCommand cmd7 = new OleDbCommand(sql7, cont);
        OleDbDataReader odr = cmd7.ExecuteReader();
        while (odr.Read())
        {
            String txt = "Asked a Question ";
            SqlCommand cmde = new SqlCommand("insert into EA_NOT(NOT_FROM,NOT_TO,NOT_NOT,NOT_DATE) VALUES('" + p + "','" + odr[0].ToString() + "','" + txt + "','" + n + "')", coned);
            cmde.ExecuteNonQuery();

        } coned.Close();
        ques.Text = null;
        Response.Redirect("userhome.aspx");
    }
    protected void ImageButton45_Click(object sender, ImageClickEventArgs e)
    {
        int j=Convert.ToInt32(ViewState["qid"].ToString());
        String pp=j.ToString()+"A";
        String s = ques.Text;
        SqlConnection coned = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (coned.State == ConnectionState.Closed)
            coned.Open();
        SqlCommand cm = new SqlCommand("insert into EA_QUES(Q_UID,Q_TXT,Q_ST) values('"+p+"','"+s+"','"+pp+"')", coned);
        cm.ExecuteNonQuery();
        coned.Close();
        String stt = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + p + @"\" + p;
        string connec = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + stt + ".mdb";
        OleDbConnection cont = new OleDbConnection(connec);
        cont.Open();
        string sql7 = "select * from fallowers";
        OleDbCommand cmd7 = new OleDbCommand(sql7, cont);
        OleDbDataReader odr = cmd7.ExecuteReader();
        while (odr.Read())
        {
            if (coned.State == ConnectionState.Closed)
                coned.Open();
            String txt = "Gave Answer To a Question";
            SqlCommand cmde = new SqlCommand("insert into EA_NOT(NOT_FROM,NOT_TO,NOT_NOT,NOT_DATE) VALUES('" + p + "','" + odr[0].ToString() + "','" + txt + "','" + n + "')", coned);
            cmde.ExecuteNonQuery();

        } coned.Close();
        ques.Text = null;
        Response.Redirect("userhome.aspx");
    }
    protected void ImageButton44_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton44.Visible = false;
        ImageButton33.Visible = true;
        ImageButton38.Visible = true;
        ques.Visible = true;
    }
    protected void Not_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton38_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton45.Visible = false;
        ImageButton44.Visible = true;
        ImageButton33.Visible = false;
        ques.Text = "";
        ques.Visible = false;
        ImageButton38.Visible = false;
    }
}