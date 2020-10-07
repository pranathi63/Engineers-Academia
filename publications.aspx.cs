using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class publications : System.Web.UI.Page
{
    String s = "";
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings.Get("con"));
    protected void Page_Load(object sender, EventArgs e)
    {
      HyperLink h= (HyperLink)Master.FindControl("Hyper");
      h.NavigateUrl = "userhome.aspx";
        try
        {
            s = Session["eid"].ToString();
            TextBox2.Text = s;
        }
        catch (NullReferenceException)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Session Expired..')", true);
            Response.Redirect("home.aspx");
        }
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
       if (FileUploadControl.HasFile)
        {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                if (!Path.GetExtension(filename).Equals(".pdf")) 
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Must Be In .pdf Format.')", true);
                }
                else{
                int k = filename.LastIndexOf(".pdf");

                String fn = filename.Substring(0, k);
                String st = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + s + @"\" + fn;
                if (System.IO.Directory.Exists(st))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Exits Rename The File \\n Before Uploading')", true);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(st);
                    if (System.IO.File.Exists("../" + st + "/" + fn))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Exits Rename The File \\n Before Uploading')", true);
                    }

                    else
                    {
                        try
                        {
                            int i = 0;
                            String pp = st + @"\" + fn;
                            FileUploadControl.SaveAs(Server.MapPath(s + "/" + fn + "/") + filename);
                            String[] a = new String[] { "", "", "", "", "" };
                            a[0] = TextBox2.Text; a[1] = TextBox3.Text; a[2] = TextBox4.Text; a[3] = TextBox5.Text; a[4] = TextBox6.Text;
                            String ti = TextBox1.Text;
                            String url = s + @"/" + fn + @"/" + filename;
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            String n = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            SqlCommand cmdd = new SqlCommand("insert into EA_PUB(PB_TI,PB_ATH,PB_DT,PB_URL,PB_CC,PB_IF) VALUES('" + ti + "','" + s + "','" + n + "','" + url + "',0,0.001)", conn);
                            cmdd.ExecuteNonQuery();
                            conn.Close();
                            ADOX.CatalogClass cat = new ADOX.CatalogClass();
                            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pp + ".mdb;Jet OLEDB:Engine Type=5");
                            cat = null;
                            string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pp + ".mdb";
                            OleDbConnection con = new OleDbConnection(connection);
                            con.Open();
                            string sql = "create table citations(id TEXT PRIMARY KEY)";
                            string sql1 = "create table authors(name TEXT)";
                            string sql2 = "create table votes(num Counter,cid DECIMAL,un TEXT)";
                            string sql3 = "create table comments(num Counter,id TEXT,comment TEXT)";
                            string sql4 = "create table fallowers(id TEXT PRIMARY KEY)";
                            OleDbCommand cmd = new OleDbCommand(sql, con); cmd.ExecuteNonQuery();
                            OleDbCommand cmd1 = new OleDbCommand(sql1, con); cmd1.ExecuteNonQuery();
                            OleDbCommand cmd2 = new OleDbCommand(sql2, con); cmd2.ExecuteNonQuery();
                            OleDbCommand cmd3 = new OleDbCommand(sql3, con); cmd3.ExecuteNonQuery();
                            OleDbCommand cmd4 = new OleDbCommand(sql4, con); cmd4.ExecuteNonQuery();
                            while (i < 5)
                            {
                                String v = a[i];
                                if (v == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string sql6 = "INSERT INTO authors VALUES('" + v + "')";
                                    OleDbCommand cmd6 = new OleDbCommand(sql6, con);
                                    cmd6.ExecuteNonQuery();
                                    i++;
                                }
                            } con.Close();
                            String stt = @"C:\Users\Karnati\Documents\Visual Studio 2013\WebSites\Web3\" + s + @"\" + s;
                            string connec= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + stt + ".mdb";
                            OleDbConnection cont = new OleDbConnection(connec);
                            cont.Open();
                            string sql7 = "select * from fallowers";
                            OleDbCommand cmd7 = new OleDbCommand(sql7, cont);
                            OleDbDataReader odr = cmd7.ExecuteReader();
                            while (odr.Read())
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                String txt = "Published A Paper About " + TextBox1.Text;
                                SqlCommand cmde = new SqlCommand("insert into EA_NOT(NOT_FROM,NOT_TO,NOT_NOT,NOT_DATE) VALUES('" + s + "','" + odr[0].ToString() + "','"+txt+"','" +n+ "')", conn);
                                cmde.ExecuteNonQuery();
                                conn.Close();
                            }
                            TextBox1.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text = null;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Uploading Completed')", true);
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Uploading Failed..\\n Somethng Went Wrong')", true);
                            if (Directory.Exists(st))
                            { Directory.Delete(st, true); }
                        }
                    }
                }
        }
    }
       }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton1.Visible = false;
        ImageButton2.Visible = true;
        TextBox3.Visible = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton2.Visible = false;
        ImageButton3.Visible = true;
        TextBox4.Visible = true;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton3.Visible = false;
        ImageButton4.Visible = true;
        TextBox5.Visible = true;
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton4.Visible = false;
        TextBox6.Visible = true;
    }
}