using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text;

public partial class inbox : System.Web.UI.Page
{
    OleDbConnection con; String s = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "userhome.aspx";
        try
        {
             s= Session["eid"].ToString();
        }
        catch (NullReferenceException) { Response.Redirect("home.aspx"); }
        SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmdd = new SqlCommand("select EA_CN from EA_GETIN where EA_UN='" + s + "'", cond);
        SqlDataReader drr = cmdd.ExecuteReader();
        if (drr.Read())
        {
            drr.Close();
            SqlCommand cmde = new SqlCommand("update EA_GETIN set EA_CN=0 where EA_UN='" + s + "'", cond);
            cmde.ExecuteNonQuery();
        }
        cond.Close();
        String st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + s + @"\" + s;
        string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + st + ".mdb";
        con = new OleDbConnection(connection);
        con.Open();
        string sql = "select * from mails ORDER BY num DESC";
        OleDbCommand cmd=new OleDbCommand(sql,con);
        OleDbDataReader dr=cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            // create the div to wrap around the comment
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div.Attributes.Add("Class", "log7");
            ImageButton myLnkBtn = new ImageButton();
            myLnkBtn.CssClass="tdf";
            myLnkBtn.ID = "myLnkBtn"+i;
            myLnkBtn.Command+=new CommandEventHandler(Unnamed1_Click);
            myLnkBtn.CommandArgument = dr[1].ToString();
            myLnkBtn.ImageUrl = "../Images/right_circular-26.png"; 
            myLnkBtn.ToolTip="Reply";
            ImageButton myLnkBtn1 = new ImageButton();
            myLnkBtn1.CssClass = "tdf";
            myLnkBtn1.ID = "Btn1" + i;
            myLnkBtn1.Command += new CommandEventHandler(Unnamed2_Click);
            myLnkBtn1.CommandArgument = dr[0].ToString();
            myLnkBtn1.ImageUrl = "../Images/trash-26.png";
            myLnkBtn1.ToolTip = "Delete"; 
            LinkButton nn = new LinkButton();
            nn.CssClass = "tdfh";
            nn.ID = "nn" + i;
            nn.Attributes.Add("onmouseover", "this.style.color = '#006699'");
            nn.Attributes.Add("onmouseout", "this.style.color = '#000000'");
            nn.Command += new CommandEventHandler(Unnamed3_Click);
            nn.CommandArgument = dr[0].ToString();
            nn.Font.Size = 12;
            div1.Attributes.Add("Class", "log5");
            Label n = new Label(); div2.Attributes.Add("Class", "log6"); 
            n.CssClass = "tdfg";
            nn.Text = "Subject:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<span style='font-variant:normal;font-weight:normal;'>" + dr[2].ToString() + "</span>";
            n.Text = "From:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + dr[1].ToString();  
           
            div1.Controls.Add(n); 
            div2.Controls.Add(nn); div2.Controls.Add(new LiteralControl("</br>"));
            div2.Controls.Add(myLnkBtn1); div2.Controls.Add(myLnkBtn); 
            div.Controls.Add(div1);
            div.Controls.Add(div2);ph.Controls.Add(div);
            i++;
        } dr.Close(); con.Close();
    }
    protected void Unnamed2_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        con.Open();
        string sqll = "delete from mails where num=" + g + "";
        OleDbCommand cmdd = new OleDbCommand(sqll, con);
        cmdd.ExecuteNonQuery();
        Context.Response.Redirect("inbox.aspx");
        // Response.Redirect("mailing.aspx?id=" + g + "")
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Uploading Completed" + g + "')", true);
    }
    protected void Unnamed3_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        con.Open();
        string sqll = "select * from mails where num=" + g + "";
        OleDbCommand cmdd = new OleDbCommand(sqll, con);
        OleDbDataReader drr = cmdd.ExecuteReader();
        HtmlGenericControl div1 = new HtmlGenericControl("div");
        TextBox t = new TextBox(); t.TextMode = TextBoxMode.MultiLine;
        t.CssClass = "dfh";
        Label nm = new Label(); nm.CssClass = "tdf"; 
        StringBuilder sb = new StringBuilder();

        if (drr.Read())
        {
            sb.AppendLine(drr[3].ToString());
            nm.Text = "Received Time: " + drr[4].ToString();
        }
        sb.AppendLine();
        t.Text = sb.ToString();
        div1.Controls.Add(nm); div1.Controls.Add(new LiteralControl("<br />"));
        div1.Controls.Add(t);
        phh.Controls.Add(div1);
        // Response.Redirect("mailing.aspx?id=" + g + "");
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Uploading Completed" + g + "')", true);
    }
        protected void Unnamed1_Click(object sender, CommandEventArgs e)
        {
            String g=e.CommandArgument.ToString();
            Response.Redirect("mailing.aspx?id="+g+"");
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Uploading Completed"+g+"')", true);
        }
}