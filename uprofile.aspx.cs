using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

public partial class uprofile : System.Web.UI.Page
{
    String s = "", st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\";
    SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            s = Session["eid"].ToString();
        }
        catch (NullReferenceException) { Response.Redirect("home.aspx"); }
        String g = Request.QueryString["id"].ToString();
        int k = 0;
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        String p = "", q = "", r = "", ss = "";
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdd = new SqlCommand("select * from EA_PRO where EA_UN='" + g + "'", cond);
        SqlDataReader dr = cmdd.ExecuteReader();
        StringBuilder sb = new StringBuilder();
        Table t = new Table();
        int i = 0;
        if (dr.Read())
        {
            p = "User Name  : " + dr.GetString(0);
            ss = "First Name : " + dr.GetString(2);
            q = "last name   : " + dr.GetString(3);
            r = dr.GetString(6);
            sb.AppendLine(p); sb.AppendLine("<br />");
            sb.AppendLine(ss); sb.AppendLine("<br />");
            sb.AppendLine(q);
            Image im = new Image();
            im.ImageUrl = r; im.CssClass = "ima";
            im.ToolTip = "User Image";
            Label l = new Label();
            l.CssClass = "ppp";
            l.Text = sb.ToString();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            TableCell td = new TableCell();
            TableCell te = new TableCell();
            ImageButton im4 = new ImageButton();
            im4.ID = "fall" + i;
            im4.CssClass = "imag";
            im4.CommandArgument = dr.GetString(0);

            String connectio = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +st+ s +@"\"+ s + ".mdb";
            OleDbConnection conhg = new OleDbConnection(connectio);
            conhg.Open();
            String sql = "Select * from youfallow where id='" + s + "'";
            OleDbCommand cmdg = new OleDbCommand(sql, conhg);
            OleDbDataReader drf = cmdg.ExecuteReader();
            if (drf.Read())
            {
                im4.Command += new CommandEventHandler(UnFallow_Click);
                im4.ToolTip = "UnFallow User";
                im4.ImageUrl = "../Images/handshake-26 - Copy1.jpg";
            }
            else
            {

                im4.Command += new CommandEventHandler(Fallow_Click);
                im4.ToolTip = "Fallow User";
                im4.ImageUrl = "../Images/handshake-26.png";
            }

            
            tc.Controls.Add(im); tc.Controls.Add(new LiteralControl("<br />")); tc.Controls.Add(im4); td.Controls.Add(l);
            tr.Controls.Add(tc); tr.Controls.Add(td);
            t.Controls.Add(tr);
        } dr.Close();
        SqlCommand cmd = new SqlCommand("select * from EA_PUB where PB_ATH='" + g + "'", cond);
        SqlDataReader drr = cmd.ExecuteReader();
        StringBuilder sbb = new StringBuilder();
        Table tt = new Table();
        TableRow trr = new TableRow();
        TableCell tcc = new TableCell();
        tcc.Text = "papers shared By User : "; tcc.CssClass = "tac";
        trr.Controls.Add(tcc);
        tt.Controls.Add(trr);
        while (drr.Read())
        {
            ImageButton im5 = new ImageButton();
            im5.ID = "fallow Paper" + i;
            im5.CssClass = "imag";
            im5.CommandArgument = drr.GetString(3);

            String gg = drr.GetString(3);
            int kd = gg.LastIndexOf(".pdf");
            String fn = gg.Substring(0, kd);
            String connectio = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
            OleDbConnection conhg = new OleDbConnection(connectio);
            conhg.Open();
            String sqlg = "Select * from fallowers where id='" + s + "'";
            OleDbCommand cmdg = new OleDbCommand(sqlg, conhg);
            OleDbDataReader drfg = cmdg.ExecuteReader();
            if (drfg.Read())
            {
                im5.Command += new CommandEventHandler(UnFallowpub_Click);
                im5.ToolTip = "UnFallow";
                im5.ImageUrl = "../Images/handshake-26 - Copy1.jpg";
            }
            else
            {


                im5.Command += new CommandEventHandler(Fallowpub_Click);
                im5.ToolTip = "Fallow";
                im5.ImageUrl = "../Images/handshake-26.png";
            }

            p = drr.GetString(0);
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            TableCell te = new TableCell();
            Label ll = new Label();
            ll.CssClass = "ppr";
            ll.Text = p;
            HyperLink nn = new HyperLink();
            nn.ID = "publ" + k;
            nn.Target = "_blank";
            nn.Font.Bold = true; nn.Font.Size = 13;
            nn.Text = "<span style='color:green;'>View Paper</span>"; nn.CssClass = "ppd";
            nn.NavigateUrl = drr.GetString(3);
            td.Controls.Add(ll); te.Controls.Add(nn); te.Controls.Add(im5);
            tr.Controls.Add(td); tr.Controls.Add(te);
            tt.Controls.Add(tr);
            k++; i++;
        }
        drr.Close();
        div1.Controls.Add(t); div1.Controls.Add(new LiteralControl("<br />"));
        div1.Controls.Add(new LiteralControl("<br />"));
        div1.Controls.Add(tt);
        phh.Controls.Add(div1);
    }

    protected void UnFallow_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + g + @"\" + g + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "Delete * from fallowers where id='" + s + "'";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            String connecti = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + s+ @"\" + s + ".mdb";
            OleDbConnection confg = new OleDbConnection(connecti);
            confg.Open();
            String sql = "Delete * from youfallow where id='" + s + "'";
            OleDbCommand cmd = new OleDbCommand(sql, confg);
            cmd.ExecuteNonQuery();
            confg.Close();
            Response.Redirect("uprofile.aspx?id=" + g + "");
        }
        catch (OleDbException) { }
    }

    protected void Fallow_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st+g +@"\"+ g + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "insert into fallowers values('" + s + "')";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            String connecti = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + s + @"\" + s + ".mdb";
            OleDbConnection confg = new OleDbConnection(connecti);
            confg.Open();
            String sql = "insert into youfallow values('" + s + "')";
            OleDbCommand cmd = new OleDbCommand(sql, confg);
            cmd.ExecuteNonQuery();
            confg.Close();
            Response.Redirect("uprofile.aspx?id="+g+"");
        }
        catch (OleDbException) { }
    }
    protected void Fallowpub_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        String fn = g.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
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
                Response.Redirect("uprofile.aspx?id=" + drr.GetString(1) + "");
            }
        }
        catch (OleDbException) { }
    }

    protected void UnFallowpub_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        String fn = g.Substring(0, k);
        String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
        OleDbConnection conh = new OleDbConnection(connection);
        conh.Open();
        try
        {
            String sqll = "delete * from fallowers where id='" + s + "'";
            OleDbCommand cmdf = new OleDbCommand(sqll, conh);
            cmdf.ExecuteNonQuery();
            conh.Close();
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select * from EA_PUB where PB_URL='" + g + "'", cond);
            SqlDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                Response.Redirect("uprofile.aspx?id=" + drr.GetString(1) + "");
            }
        }
        catch (OleDbException) { }
    }
}