using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;
public partial class userprofile : System.Web.UI.Page
{

    int i = 0;
    public String s = "", st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\";
    SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "userhome.aspx";
        try
        {
            s = Session["eid"].ToString();
            Image1.ImageUrl = @"../" +s + @"/Profile.jpg";
        }
        catch (NullReferenceException) { Response.Redirect("home.aspx"); }
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmd = new SqlCommand("select * from EA_PRO where EA_UN='"+s+"'", cond);
        SqlDataReader drt = cmd.ExecuteReader();
        while (drt.Read())
        {

            if (!IsPostBack)
            {
                TextBox1.Text = drt.GetString(2);
                TextBox2.Text = drt.GetString(3);
                TextBox3.Text = drt.GetString(4);
                TextBox4.Text = Convert.ToString(drt.GetDecimal(5));
            } 
        } drt.Close();
        
        SqlCommand cmdd = new SqlCommand("select * from EA_PUB where PB_ATH='"+s+"'", cond);
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
            OleDbCommand cmddd = new OleDbCommand(sql, con);
            OleDbDataReader dr = cmddd.ExecuteReader();
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
            HyperLink myLnkBtn = new HyperLink();
            myLnkBtn.CssClass = "tdfh";
            myLnkBtn.ID = "myLnkBtn" + i;
            myLnkBtn.Target = "_blank";
            myLnkBtn.Attributes.Add("onmouseover", "this.style.color = 'green'");
            myLnkBtn.Attributes.Add("onmouseout", "this.style.color = '#000000'");
            myLnkBtn.NavigateUrl = drr.GetString(3);
            myLnkBtn.Text = "Title :<span style='font-variant:normal'>" + b + "</span>"; 
            myLnkBtn.Font.Size = 13;
            ImageButton im2 = new ImageButton();
            im2.ID = "Cit" + i;
            im2.CommandArgument = drr.GetString(3);
            im2.ToolTip = "Delete Publication";
            im2.ImageUrl = "../Images/delete_property-26.png";
            im2.Command += new CommandEventHandler(Unnamed1_Click);
            im2.CssClass = "imag";
            i++;
            Label n = new Label(); n.CssClass = "tdfg";
            n.Text = "Autors:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + a;

            div1.Controls.Add(n);
            div2.Controls.Add(myLnkBtn);
            div2.Controls.Add(new LiteralControl("</br>"));
            div2.Controls.Add(im2);
            div.Controls.Add(div1); div.Controls.Add(div2);
            phh.Controls.Add(div);
            i++;
        } drr.Close(); cond.Close();
    }
    protected void Unnamed1_Click(object sender, CommandEventArgs e)
    {
        String g = e.CommandArgument.ToString();
        int k = g.LastIndexOf(".pdf");
        int kk = g.LastIndexOf("/");
        kk = kk + 1;
        k=k-kk;
        String fn = g.Substring(kk,k);
       st = st + s + @"\" + fn;
       if (Directory.Exists(st))
        { Directory.Delete(st, true); }
       if (cond.State == ConnectionState.Closed)
           cond.Open();
       SqlCommand cmd = new SqlCommand("delete from EA_PUB where PB_URL='" + g + "'", cond);
       cmd.ExecuteNonQuery();
       Response.Redirect("userprofile.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton4.Visible = true;
        ImageButton1.Visible = false;
        FileUpload1.Visible = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        TextBox1.ReadOnly = false;
        TextBox2.ReadOnly = false;
        TextBox3.ReadOnly = false;
        TextBox4.ReadOnly = false;
        ImageButton3.Visible = true;
        ImageButton2.Visible = false;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (cond.State == ConnectionState.Closed)
            cond.Open();
        SqlCommand cmd = new SqlCommand("update EA_PRO set EA_FN='" + TextBox1.Text + "',EA_LN='"+TextBox2.Text+"',EA_EM='"+TextBox3.Text+"',EA_MN="+Convert.ToDecimal(TextBox4.Text)+" where EA_UN='"+s+"'", cond);
        cmd.ExecuteNonQuery();
        TextBox1.ReadOnly = true;
        TextBox2.ReadOnly = true;
        TextBox3.ReadOnly = true;
        TextBox4.ReadOnly = true;
        ImageButton3.Visible = false;
        ImageButton2.Visible = true;
        cond.Close();
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
            string directory = Server.MapPath(s);
            string fExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            if (fExtension.Equals(".jpg"))
            {
                string fileName = "Profile" + fExtension;
                this.FileUpload1.SaveAs(Path.Combine(directory, fileName));
                Thread.Sleep(1000);
                Response.Redirect("userprofile.aspx");
                String k = @"../" + s + @"/" + fileName;
                if (cond.State == ConnectionState.Closed)
                    cond.Open();
                SqlCommand cmd = new SqlCommand("update EA_GETIN set EA_IMG='" + k + "' where EA_UN='" + s + "'", cond);
                cmd.ExecuteNonQuery();
                cond.Close();
                if (cond.State == ConnectionState.Closed)
                    cond.Open();
                SqlCommand cmdd = new SqlCommand("update EA_PRO set EA_URL='" + k + "' where EA_UN='" + s + "'", cond);
                cmdd.ExecuteNonQuery();
                cond.Close();
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Choose Image in jpg format')", true);
            }
            /*String k = @"../" + s + @"/" + fileName;
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmd = new SqlCommand("update EA_GETIN set EA_IMG='" + k + "' where EA_UN='" + s + "'", cond);
            cmd.ExecuteNonQuery();
            cond.Close();
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("update EA_PRO set EA_URL='" + k + "' where EA_UN='" + s + "'", cond);
            cmdd.ExecuteNonQuery();
            cond.Close();*/
            
    }
}