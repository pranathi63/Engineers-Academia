using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink h = (HyperLink)Master.FindControl("Hyper");
        h.NavigateUrl = "home.aspx";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String UN = Session["eid"].ToString();
        String pw=oldpw.Text,pp="";
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
        if (con.State == ConnectionState.Closed)
            con.Open();
        String[] a = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "1", "2", "3", "4", "5", "j", "k", "l", "m", "n", "o", "p", "6", "7", "8", "9", "0", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i < pw.Length; i++)
        {
            string d = pw.Substring(i, 1);
            int j = Array.IndexOf(a, d);
            if (j < 10)
            {
                pp = pp + "0" + j.ToString();
            }
            else
            {
                pp = pp + j.ToString();
            }

        }
        
            SqlCommand cmd = new SqlCommand("select * from EA_GETIN where EA_UN='"+UN+"' and EA_PW='"+pp+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                pp = "";
                String pw1 = newpw.Text;
                for (int i = 0; i < pw1.Length; i++)
                {
                    string d = pw1.Substring(i, 1);
                    int j = Array.IndexOf(a, d);
                    if (j < 10)
                    {
                        pp = pp + "0" + j.ToString();
                    }
                    else
                    {
                        pp = pp + j.ToString();
                    }

                }
                dr.Close();
                SqlCommand cmd1 = new SqlCommand("update EA_GETIN set EA_PW='" + pp + "' where EA_UN='" + UN + "'", con);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("update EA_PRO set EA_PW='" + pp + "' where EA_UN='" + UN + "'", con);
                cmd2.ExecuteNonQuery();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('old PassWord Does'nt Match..')", true);
            }
        con.Close();
        }
}