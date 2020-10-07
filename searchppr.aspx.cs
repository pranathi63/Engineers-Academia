using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class searchppr : System.Web.UI.Page
{
    String T = ""; int i=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "userhome.aspx";
                T = Request.QueryString["srch"];
        SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdd = new SqlCommand("select * from EA_PRO where EA_UN='" + T + "'", cond);
        SqlDataReader dr=cmdd.ExecuteReader();
        naveen(dr); dr.Close();
        SqlCommand cmd = new SqlCommand("select * from EA_PUB where PB_ATH='" + T + "'", cond);
        SqlDataReader drr = cmd.ExecuteReader();
        nav(drr); drr.Close();
        SqlCommand cmd1 = new SqlCommand("select * from EA_PUB where PB_TI='" + T + "'", cond);
        SqlDataReader drf = cmd1.ExecuteReader();
        nav(drf); drf.Close();
        
    }
    protected void naveen(SqlDataReader drr)
    {
        while (drr.Read())
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("Class", "log8");
            LinkButton nn = new LinkButton();
            nn.CssClass = "tdfh";
            nn.ID = "pro" +i;
            nn.Attributes.Add("onmouseover", "this.style.color = '#006699'");
            nn.Attributes.Add("onmouseout", "this.style.color = '#000000'");
            nn.Command += new CommandEventHandler(Unnamed2_Click);
            nn.CommandArgument = drr.GetString(0);
            nn.Font.Bold = true; nn.Font.Size = 13;
            nn.Text = drr.GetString(0) + " : Profile";
            div.Controls.Add(nn); div.Controls.Add(new LiteralControl("<br />"));
            ph.Controls.Add(div);
            i++;
        }
        drr.Close();

    }
    protected void nav(SqlDataReader drr)
    {
        while (drr.Read())
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("Class", "log8");
            LinkButton nn = new LinkButton();
            nn.ID = "pub" + i;
            nn.Attributes.Add("onmouseover", "this.style.color = '#006699'");
            nn.Attributes.Add("onmouseout", "this.style.color = '#000000'");
            nn.Command += new CommandEventHandler(Unnamed3_Click);
            nn.CommandArgument=drr.GetInt32(6).ToString();
            nn.Font.Bold = true; nn.Font.Size = 13;
            nn.Text = drr.GetString(1) +" Shared "+ drr.GetString(0) ;
            div.Controls.Add(nn); div.Controls.Add(new LiteralControl("<br />"));
            ph.Controls.Add(div);
            i++;
        }
        drr.Close();

    }

    protected void Unnamed3_Click(object sender, CommandEventArgs e)
    {
        iff.Visible = true;
        int g = Convert.ToInt32(e.CommandArgument.ToString());
        iff.Attributes["src"] = "pubdetails.aspx?id=" + g + "";
        
    }
    protected void Unnamed2_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        iff.Attributes["src"] = "uprofile.aspx?id=" + g + "";
    }
}