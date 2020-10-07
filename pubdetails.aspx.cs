using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text;

public partial class pubdetails : System.Web.UI.Page
{
    int i=0,pp;
    public String s = "",st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\";
    SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            s = Session["eid"].ToString();
        }
        catch (NullReferenceException) { Response.Redirect("home.aspx"); }
        pp=Convert.ToInt32(Request.QueryString["id"]);
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        Table t = new Table();
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdd = new SqlCommand("select * from EA_PUB where PB_NUM='"+pp+"'", cond);
        SqlDataReader drr = cmdd.ExecuteReader();
        while (drr.Read())
        {
            
            div1.Attributes.Add("Class", "ead");
            ImageButton im4 = new ImageButton();
            im4.ID = "fall" + i;
            im4.CssClass = "imag";
            
            im4.CommandArgument = drr.GetString(3);
            String g = drr.GetString(3);
            int k = g.LastIndexOf(".pdf");
            String fn = g.Substring(0, k);
            String connectio = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
            OleDbConnection conhg = new OleDbConnection(connectio);
            conhg.Open();
            String sqlg = "Select * from fallowers where id='" +s + "'";
            OleDbCommand cmd = new OleDbCommand(sqlg, conhg);
            OleDbDataReader drfg = cmd.ExecuteReader();
            if (drfg.Read())
            {
                im4.ToolTip = "UnFallow";
                im4.ImageUrl = "../Images/handshake-26 - Copy1.jpg";
                im4.Command += new CommandEventHandler(UnFallow_Click);
            }
            else
            {


                im4.ToolTip = "Fallow";
                im4.ImageUrl = "../Images/handshake-26.png";
                im4.Command += new CommandEventHandler(Fallow_Click);
            }
            
            ImageButton im = new ImageButton();
            im.ID = "Cita" + i;
            im.CssClass = "imag";
            im.Command += new CommandEventHandler(Cite_Click);
            im.ToolTip = "Citation";
            im.CommandArgument = drr.GetString(3);
            im.ImageUrl = "../Images/tree_structure-26.png";
            ImageButton im1 = new ImageButton();
            im1.ID = "Ci" + i;
            im1.CssClass = "imag";
            im1.Command += new CommandEventHandler(Bite_Click);
            im1.ToolTip = "Click To Discuss";
            im1.CommandArgument = drr.GetString(3);
            im1.ImageUrl = "../Images/flow_chart-26.png";
            HyperLink nn = new HyperLink();
            nn.ID = "public" + i;
            nn.Target = "_blank";
            nn.CssClass = "imag";
            nn.Font.Bold = true; nn.Font.Size = 13;
            nn.ToolTip = "View Paper";
            nn.NavigateUrl = drr.GetString(3);
            nn.Text = "<img src='../Images/open_in_browser-26.png'/>";
            div1.Controls.Add(im); div1.Controls.Add(im4); div1.Controls.Add(im1); div1.Controls.Add(nn); phh.Controls.Add(div1);
            HtmlGenericControl div = new HtmlGenericControl("div");
            Label l = new Label();
            l.Text = "<span style='font-size:x-large;color:green'>Paper Details..</span>";
            div.Attributes.Add("Class", "eaa");
                ViewState["ffn"] = drr.GetString(3);
                TableCell tc = new TableCell();
                TableCell td = new TableCell();
                TableCell te = new TableCell();
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell td1 = new TableCell();
                TableCell te1 = new TableCell();
                TableRow tr1 = new TableRow();
                TableCell tc2 = new TableCell();
                TableCell td2 = new TableCell();
                TableCell te2 = new TableCell();
                TableRow tr2 = new TableRow();
                TableCell tc3 = new TableCell();
                TableCell td3 = new TableCell();
                TableCell te3 = new TableCell();
                TableRow tr3 = new TableRow();
                tc.Text = "<span style='color:blue'>Title</span>"; te.Text = ":";
                td.Text = drr.GetString(0); td.Width = 400;
                tr.Controls.Add(tc); tr.Controls.Add(te); tr.Controls.Add(td); t.Controls.Add(tr);
                tc1.Text = "<span style='color:blue'>Shared On</span>"; td1.Text = drr.GetString(2); te1.Text = ":";
                tr1.Controls.Add(tc1); tr1.Controls.Add(te1); tr1.Controls.Add(td1); t.Controls.Add(tr1);
                tc2.Text = "<span style='color:blue'>Citations</span>"; td2.Text = drr.GetInt32(4).ToString(); te2.Text = ":";
                tr2.Controls.Add(tc2); tr2.Controls.Add(te2); tr2.Controls.Add(td2); t.Controls.Add(tr2);
                tc3.Text = "<span style='color:blue'>Impact Factor</span>"; td3.Text = Convert.ToString(drr.GetDouble(5)); te3.Text = ":";
                tr3.Controls.Add(tc3); tr3.Controls.Add(te3); tr3.Controls.Add(td3); t.Controls.Add(tr3);
            div.Controls.Add(new LiteralControl("</br>"));
            div.Controls.Add(l);
            div.Controls.Add(t);
            phh.Controls.Add(div);
            String fg = ViewState["ffn"].ToString();
            int kd = fg.LastIndexOf(".pdf");
            String fng = fg.Substring(0, kd);
            String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fng + ".mdb";
            OleDbConnection conh = new OleDbConnection(connection);
            conh.Open();
            String sqll = "Select * from comments";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            OleDbDataReader dr = cmdf.ExecuteReader();
            int kk = 0;
            while (dr.Read())
            {
                ImageButton im2 = new ImageButton();
                im2.ID = "Cit" + kk;
                im2.CssClass = "imag";
                im2.Visible = true;
                String sql = "Select * from votes where cid=" + dr[0].ToString() + " and un='"+s+"'";
                OleDbCommand cmdg = new OleDbCommand(sql, conh);
                OleDbDataReader drf = cmdg.ExecuteReader();
                if (drf.Read())
                {
                    im2.CommandArgument = dr[0].ToString();
                    im2.ToolTip = "UnLike";
                    im2.ImageUrl = "../Images/thumbs_down-26.png";
                    im2.Command += new CommandEventHandler(UnLike_Click);
                }
                else
                {


                    im2.CommandArgument = dr[0].ToString();
                    im2.ToolTip = "Like";
                    im2.ImageUrl = "../Images/thumbs_up-26.png";
                    im2.Command += new CommandEventHandler(Like_Click);
                }
                HtmlGenericControl div2 = new HtmlGenericControl("div"); 
                div2.Attributes.Add("Class", "eae");
                Label lb = new Label();
                TextBox ll = new TextBox();
                ll.ReadOnly = true;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(dr[2].ToString());
                lb.Text = dr[1].ToString();
                ll.Text = sb.ToString(); ll.Attributes.Add("Class", "eag");
                ll.TextMode = TextBoxMode.MultiLine;
                div2.Controls.Add(lb); div2.Controls.Add(im2);div2.Controls.Add(new LiteralControl("<br />")); div2.Controls.Add(ll);
                phh.Controls.Add(div2);
                kk++;
            }
            conh.Close(); i++;
        }

        drr.Close();
        cond.Close();
    }
    protected void UnFallow_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        String fn = g.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "Delete * from fallowers where id='" + s + "'";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select * from EA_PUB where PB_URL='" + g + "'", cond);
            SqlDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                Response.Redirect("pubdetails.aspx?id=" + drr.GetInt32(6) + "");
            }
        }
        catch (OleDbException) { }
        
    }
    protected void Fallow_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        String fn =g.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st+fn+ ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "insert into fallowers values('" + s + "')";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select * from EA_PUB where PB_URL='" + g + "'", cond);
            SqlDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                Response.Redirect("pubdetails.aspx?id=" + drr.GetInt32(6) + "");
            }
        }
        catch (OleDbException) { }
        Response.Redirect("pubdetails.aspx");
    }
    protected void Bite_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        TextBox2.Visible = true; ImageButton1.Visible = true;
    }

    protected void Like_Click(object sender, CommandEventArgs e)
    {
        int f = Convert.ToInt32(e.CommandArgument.ToString());
        String fg = ViewState["ffn"].ToString();
        int k = fg.LastIndexOf(".pdf");
        String fn = fg.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "insert into votes(cid,un) values('" + f + "','" + s + "')";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            Response.Redirect("pubdetails.aspx?id=" + pp + "");
        }
        catch(OleDbException){}

    }
    protected void UnLike_Click(object sender, CommandEventArgs e)
    {
        int f = Convert.ToInt32(e.CommandArgument.ToString());
        String fg = ViewState["ffn"].ToString();
        int k = fg.LastIndexOf(".pdf");
        String fn = fg.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        String sqll = "Delete from votes where cid=" + f + " and un='"+s+"'";
        OleDbCommand cmdf = new OleDbCommand(sqll, conh);
        cmdf.ExecuteNonQuery();
        conh.Close();
        Response.Redirect("pubdetails.aspx?id=" + pp + "");
    }
    protected void Cite_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        String fn = g.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "insert into citations(id) values('" + s + "')";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh); cmdf.ExecuteNonQuery();
            conh.Close();
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select PB_CC from EA_PUB where PB_URL='" + g + "'", cond);
            SqlDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                int j = drr.GetInt32(0);
                drr.Close();
                j = j + 1;
                SqlCommand cmde = new SqlCommand("update EA_PUB set PB_CC=" + j + "where PB_URL='" + g + "'", cond);
                cmde.ExecuteNonQuery();
            }
        }
        catch (OleDbException)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('you Have Already Cited this Paper')", true);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String fg = ViewState["ffn"].ToString();
        int k = fg.LastIndexOf(".pdf");
        String fn = fg.Substring(0, k);
        String g = TextBox2.Text; String fnn = "";
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdk = new SqlCommand("select * from EA_PUB where PB_URL='"+fg+"'", cond);
        SqlDataReader sdr = cmdk.ExecuteReader();
        if (sdr.Read()) { fnn = sdr.GetString(0); } sdr.Close();
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        String sqll = "insert into comments(id,comment) values('" + s + "','" + g + "')";
        OleDbCommand cmdf = new OleDbCommand(sqll, conh); cmdf.ExecuteNonQuery();
        conh.Close();
        String n = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        String stt = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + s + @"\" + s;
        string connec = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + stt + ".mdb";
        OleDbConnection cont = new OleDbConnection(connec);
        cont.Open();
        string sql7 = "select * from fallowers";
        OleDbCommand cmd7 = new OleDbCommand(sql7, cont);
        OleDbDataReader odr = cmd7.ExecuteReader();
        while (odr.Read())
        {
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            String txt = "Commented on "+fnn;
            SqlCommand cmde = new SqlCommand("insert into EA_NOT(NOT_FROM,NOT_TO,NOT_NOT,NOT_DATE) VALUES('" + s + "','" + odr[0].ToString() + "','" + txt + "','" + n + "')", cond);
            cmde.ExecuteNonQuery();
            cond.Close();
        }
        TextBox2.Text = null;
        Response.Redirect("pubdetails.aspx?id=" + pp + "");
    }

    protected void pub()
    {
        String fg = ViewState["ffn"].ToString();
        int k = fg.LastIndexOf(".pdf");
        String fn = fg.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        String sqll = "Select * from comments";
        OleDbCommand cmdf = new OleDbCommand(sqll, conh); cmdf.ExecuteNonQuery();
        OleDbDataReader dr = cmdf.ExecuteReader();
        while (dr.Read())
        {

            HtmlGenericControl div = new HtmlGenericControl("div"); div.Attributes.Add("Class", "eaa");
            Label l = new Label();
            Label ll = new Label();
            Button but = new Button();
            but.Click += new EventHandler(Image_Click);
            l.Text = dr[1].ToString();
            ll.Text = dr[2].ToString();
            div.Controls.Add(l); div.Controls.Add(ll); div.Controls.Add(but);
            phh.Controls.Add(div);
        }
        conh.Close();
    }
    protected void Image_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('you Have')", true);
    }
}