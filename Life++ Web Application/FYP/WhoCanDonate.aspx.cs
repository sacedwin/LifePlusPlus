using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WhoCanDonate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblGNews.Visible = false;
        lblBNews.Visible = false;
    }
    
    protected void btnEstimate_Click1(object sender, EventArgs e)
    {
        int height = Convert.ToInt32(ddlHeight.SelectedValue);
        int weight = Convert.ToInt32(ddlWeight.SelectedValue);

        if (height == 149)
        {
            lblGNews.Visible = false;
            lblBNews.Visible = true;
        }

        else if (height >= 150 && weight >= 64)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 152 && weight >= 63)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 153 && weight >= 62)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 154 && weight >= 61)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 156 && weight >= 60)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 157 && weight >= 59)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 158 && weight >= 58)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 159 && weight >= 57)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 161 && weight >= 56)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 162 && weight >= 55)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }
        else if (height >= 163 && weight >= 54)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 164 && weight >= 53)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 165 && weight >= 52)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height >= 167 && weight >= 51)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else if (height == 168)
        {
            lblGNews.Visible = true;
            lblBNews.Visible = false;
        }

        else
        {
            lblGNews.Visible = false;
            lblBNews.Visible = true;
        }
    }
}