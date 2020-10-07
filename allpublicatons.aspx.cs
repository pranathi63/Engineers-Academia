using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class allpublicatons : System.Web.UI.Page
{
    int i = 0;
    public String s = "",st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\";
    SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "userhome.aspx";
        s = Session["eid"].ToString();
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdd = new SqlCommand("select * from EA_PUB ORDER BY PB_NUM DESC", cond);
        SqlDataReader drr = cmdd.ExecuteReader();
        while (drr.Read())
        {
            String a = "", b = drr.GetString(0), c = drr.GetString(2), d = drr.GetString(3);
            int k = d.LastIndexOf(".pdf");
            String fn = d.Substring(0, k);
            String connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + fn + ".mdb";
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + fn + "')", true);
            OleDbConnection con = new OleDbConnection(connection);
            con.Open();
            string sql = "select * from authors";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr[0].ToString().Equals(null))
                    a = a + dr[0].ToString() + " ";
            } dr.Close();
            con.Close();
            // create the div to wrap around the comment
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("Class", "logg");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div1.Attributes.Add("Class", "log5");
            div2.Attributes.Add("Class", "log6");
            LinkButton myLnkBtn = new LinkButton();
            myLnkBtn.CssClass = "tdfh";
            myLnkBtn.ID = "myLnkBtn" + i;
            myLnkBtn.Attributes.Add("onmouseover", "this.style.color = '#006699'");
            myLnkBtn.Attributes.Add("onmouseout", "this.style.color = '#000000'");
            myLnkBtn.Command += new CommandEventHandler(Unnamed1_Click);
            myLnkBtn.CommandArgument = drr.GetInt32(6).ToString();
            myLnkBtn.Text = "Title :<span style='font-variant:normal'>" + b + "</span>"; myLnkBtn.Font.Size = 13;
            i++;
            Label n = new Label(); n.CssClass = "tdfg";
            n.Text = "Autors:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + a;
            
            div1.Controls.Add(n);
            div2.Controls.Add(myLnkBtn);
            div.Controls.Add(div1); div.Controls.Add(div2);
            // add the div to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old div.
            ph.Controls.Add(div);
            i++;
        } drr.Close(); cond.Close();
    }

    protected void Unnamed1_Click(object sender, CommandEventArgs e)
    {
        int g = Convert.ToInt32(e.CommandArgument.ToString());
        iff.Attributes["src"] = "pubdetails.aspx?id="+g+"";
    }
}