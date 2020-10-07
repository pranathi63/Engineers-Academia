using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = true;
        Label1.Text = Page.Title;
        Label1.ForeColor =Color.Yellow;
        if (Label1.Text.Length > 15)
        { Label1.Font.Size = 16; }
        else { Label1.Font.Size =25; }
            
    }
}
