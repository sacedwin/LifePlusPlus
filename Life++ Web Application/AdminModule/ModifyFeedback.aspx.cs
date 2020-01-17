using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModifyFeedback : System.Web.UI.Page
{
    List<AFeedback> alllist = AFeedbackDB.getallFeedbacks();
    List<AFeedback> answeredlist = AFeedbackDB.getFeedbacksbyStatus("answered");
    List<AFeedback> unansweredlist = AFeedbackDB.getFeedbacksbyStatus("unanswered");
    List<AFeedback> reportlist = AFeedbackDB.getFeedbacksbyStatus("reported");

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlFBChoose.SelectedIndex == 0)
        {
            PanelFBAll.Visible = false;
            Panel1.Visible = false;
            lblSelectError.Text = "";
			Panel1.Visible = false;


		}

        else if (ddlFBChoose.SelectedIndex == 1)
        {
			Panel1.Visible = false;
			if (alllist.Count==0)
            {
                lblSelectError.Text = "Sorry there is no feedback found in the moment!";
                PanelFBAll.Visible = false;
			}
            else
            {
                PanelFBAll.Visible = true;
                gvFB.DataSource = AFeedbackDB.getallFeedbacks();
                gvFB.DataBind();
                lblSelectError.Text = "The are " + alllist.Count + " Feedback found!";
            }
            

        }

        else if (ddlFBChoose.SelectedIndex == 2)
        {
			Panel1.Visible = false;
			if (answeredlist.Count == 0)
            {
                PanelFBAll.Visible = false;
                lblSelectError.Text = "Sorry there is no answered feedback found in the moment!";
				
			}
            else
            {
                PanelFBAll.Visible = true;
              
                gvFB.DataSource = answeredlist;
                gvFB.DataBind();
                Session["ftemp"] = 2;
                lblSelectError.Text = "The are " + answeredlist.Count + " Answered Feedback found!";

            }
        }

        else if (ddlFBChoose.SelectedIndex == 3)
        {
			Panel1.Visible = false;
			if (unansweredlist.Count == 0)
            {
                PanelFBAll.Visible = false;
				
				lblSelectError.Text = "Sorry there is no unanswered feedback found in the moment!";
            }
            else
            {
                PanelFBAll.Visible = true;
               
                gvFB.DataSource = unansweredlist;
                gvFB.DataBind();
                Session["ftemp"] = 3;
                lblSelectError.Text = "The are " + unansweredlist.Count + " Unanswered Feedback found!";
            }

        }
        else if (ddlFBChoose.SelectedIndex == 4)
        {
			Panel1.Visible = false;
			if (reportlist.Count == 0)
            {
                PanelFBAll.Visible = false;
				lblSelectError.Text = "Sorry there is no reported feedback found in the moment!";
            }
            else
            {
                PanelFBAll.Visible = true;
                gvFB.DataSource = reportlist;
                gvFB.DataBind();
                Session["ftemp"] = 4;
                lblSelectError.Text = "The are " + reportlist.Count + " Reported Feedback found!";
            }
        }
    }

    protected void gvFB_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;

        if (Session["ftemp"].ToString() == "2")
        {
            AFeedback afa = answeredlist[gvFB.PageSize * gvFB.PageIndex + gvFB.SelectedIndex];
            FillForm(afa);
        }
        else if (Session["ftemp"].ToString() == "3")
        {
            AFeedback afu = unansweredlist[gvFB.PageSize * gvFB.PageIndex + gvFB.SelectedIndex];
            FillForm(afu);
        }
        else if (Session["ftemp"].ToString() == "4")
        {
            AFeedback afr = reportlist[gvFB.PageSize * gvFB.PageIndex + gvFB.SelectedIndex];
            FillForm(afr);
        }
        else
        {
            List<AFeedback> allfeebacks = AFeedbackDB.getallFeedbacks();
            AFeedback af = allfeebacks[gvFB.PageSize * gvFB.PageIndex + gvFB.SelectedIndex];
            FillForm(af);

        }

    }
    protected void gvFB_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFB.PageIndex = e.NewPageIndex;
        if (Session["ftemp"].ToString() == "2")
        {
            gvFB.DataSource = answeredlist;
            gvFB.DataBind();
        }
        else if (Session["ftemp"].ToString() == "3")
        {
            gvFB.DataSource = unansweredlist;
            gvFB.DataBind();
        }
        else if (Session["ftemp"].ToString() == "4")
        {
            gvFB.DataSource = reportlist;
            gvFB.DataBind();
        }
        else
        {
            gvFB.DataSource = AFeedbackDB.getallFeedbacks();
            gvFB.DataBind();
        }

    }

	//class to fill the form 
    public void FillForm(AFeedback af)
    {
        tbxfeedbackID.Text = af.feedbackID;
        tbxName.Text = af.name;
        tbxEmail.Text = af.email;
        tbxQuestion.Text = af.question;
        tbxsubject.Text = af.subject;
        if (af.answer == null)
        {
            tbxAnswer.Text = "";
        }
        else
        {
            tbxAnswer.Text = af.answer;
        }
        ddlStatus.SelectedValue = af.status;
    }

	//update status by admin 
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AFeedback af = AFeedbackDB.getFeedbackbyID(tbxfeedbackID.Text);
        if (tbxAnswer.Text == "")
        {
            af.answer = "null";
        }
        else
            af.answer = tbxAnswer.Text;
        af.status = ddlStatus.SelectedValue;
        Admins a = AdminDB.getAdminbyEmail(Session["email"].ToString());
        af.Answerby = a.AdminId;
        int num =AFeedbackDB.updateFeedback(af);
		if (num != 1)
			lblOutput.Text = "Cannot Update Feedback!";
		else
		{
			lblOutput.Text = "Update Successful!";
			if (ddlFBChoose.SelectedIndex == 1)
			{
				gvFB.DataSource = AFeedbackDB.getallFeedbacks();
				gvFB.DataBind();
			}
			else if (ddlFBChoose.SelectedIndex == 2)
			{
				gvFB.DataSource = answeredlist;
				gvFB.DataBind();
			}
			else if (ddlFBChoose.SelectedIndex == 3)
			{
				gvFB.DataSource = unansweredlist;
				gvFB.DataBind();
			}
			else if (ddlFBChoose.SelectedIndex == 4)
			{
				gvFB.DataSource = reportlist;
				gvFB.DataBind();
			}

		}
    }
}