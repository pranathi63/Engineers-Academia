using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class mailing : System.Web.UI.Page
{
    String s = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text.Replace(Environment.NewLine, "<br />");
        if (!IsPostBack)
        {
            Tod.Text=Request.QueryString["id"];
        }    
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "userhome.aspx";
        try
        {
            s = Session["eid"].ToString();
        }
        catch (NullReferenceException)
        {
            Response.Redirect("home.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try{
        String g = Tod.Text;
        String gd = msg.Text;
        String su = subj.Text;
        String n = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        String st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + g + @"\" + g+".mdb";
        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+st;
        OleDbConnection con = new OleDbConnection(connection);
        con.Open();
        string sql = "INSERT INTO mails(id,subject,msg,dat) VALUES('" + s + "','" +su+ "','" + gd + "','" + n + "')";
        OleDbCommand cmd = new OleDbCommand(sql, con); 
            cmd.ExecuteNonQuery();
        con.Close();
             SqlConnection cond = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
            if (cond.State == ConnectionState.Closed)
                cond.Open();
            SqlCommand cmdd = new SqlCommand("select EA_CN from EA_GETIN where EA_UN='"+g+"'", cond);
            SqlDataReader dr=cmdd.ExecuteReader();
            if (dr.Read())
            {
                int j = dr.GetInt32(0);
                j = j + 1;
                dr.Close();
                SqlCommand cmde = new SqlCommand("update EA_GETIN set EA_CN="+j+" where EA_UN='"+g+"'", cond);
                cmde.ExecuteNonQuery();
            }
            cond.Close();
        Tod.Text =subj.Text= msg.Text = "";
        stat.Visible = true;
       stat.Text= "Message Sent Successfully...";
        }
                        catch (Exception ef) 
                        {
                            Page.Title = ef.ToString();
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Msg Cant Be Sent..\\n Somethng Went Wrong')", true);
                        }
    }

}