using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class Establishments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ddlEChoose_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label2.Text = "";
        if (ddlEChoose.SelectedIndex == 0)
        {
            Panel1.Visible = false;
            PanelEAll.Visible = false;
            PanelPening.Visible = false;
            lblSelectError.Text = "";
        }

        else if (ddlEChoose.SelectedIndex == 1)
        {
            PanelEAll.Visible = true;
            Panel1.Visible = false;
            PanelPening.Visible = false;
            List<Establishment> estlists = EstablishmentDB.getAllTempEstablishments();
            if (estlists.Count == 0)
            {
                lblSelectError.Text = "Sorry! There are no record found.";
            }
            else
            {
                gvTempE.DataSource = estlists;
                gvTempE.DataBind();
                lblSelectError.Text = "There are " + estlists.Count + " records found";
            }
        }

        else if (ddlEChoose.SelectedIndex == 2)
        {
            PanelEAll.Visible = false;
            Panel1.Visible = false;

            List<Establishment> estplists = EstablishmentDB.getAllTempEstablishmentsbyStatus("pending");
            if (estplists.Count == 0)
            {
                lblSelectError.Text = "Sorry! There are no pending request right now.";
                return;
            }
            else
            {

                gvpending.DataSource = estplists;
                gvpending.DataBind();
                lblSelectError.Text = "There are " + estplists.Count + " pending records found";
                PanelPening.Visible = true;
            }
        }

        else if (ddlEChoose.SelectedIndex == 3)
        {
            PanelEAll.Visible = false;
            Panel1.Visible = false;
            PanelPening.Visible = false;
            List<Establishment> estalists = EstablishmentDB.getAllTempEstablishmentsbyStatus("approved");
            if (estalists.Count == 0)
            {
                lblSelectError.Text = "Sorry! There are approved no record found.";
                return;
            }
            else
            {
                gvTempE.DataSource = estalists;
                gvTempE.DataBind();
                lblSelectError.Text = "There are " + estalists.Count + " approved records found";
                PanelEAll.Visible = true;
            }
        }

        else if (ddlEChoose.SelectedIndex == 4)
        {
            PanelEAll.Visible = false;
            Panel1.Visible = false;
            PanelPening.Visible = false;
            List<Establishment> estdlists = EstablishmentDB.getAllTempEstablishmentsbyStatus("dismissed");
            if (estdlists.Count == 0)
            {
                lblSelectError.Text = "Sorry! There are no dismissed record found.";
                return;
            }
            else
            {
                gvTempE.DataSource = estdlists;
                gvTempE.DataBind();
                lblSelectError.Text = "There are " + estdlists.Count + " dismissed records found";
                PanelEAll.Visible = true;

            }
        }
    }

    protected void gvTempE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ddlEChoose.SelectedIndex == 1)
        {
            gvTempE.PageIndex = e.NewPageIndex;
            gvTempE.DataSource = EstablishmentDB.getAllTempEstablishments();
            gvTempE.DataBind();
        }
        else if (ddlEChoose.SelectedIndex == 3)
        {
            gvTempE.PageIndex = e.NewPageIndex;
            gvTempE.DataSource = EstablishmentDB.getAllTempEstablishmentsbyStatus("approved");
            gvTempE.DataBind();
        }

        else if (ddlEChoose.SelectedIndex == 4)
        {
            gvTempE.PageIndex = e.NewPageIndex;
            gvTempE.DataSource = EstablishmentDB.getAllTempEstablishmentsbyStatus("dismissed");
            gvTempE.DataBind();
        }
    }

    protected void gvpending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvpending.PageIndex = e.NewPageIndex;
        gvpending.DataSource = EstablishmentDB.getAllTempEstablishmentsbyStatus("pending");
        gvpending.DataBind();
        Label2.Text = "";
    }

    protected void gvpending_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label2.Text = "";
        Panel1.Visible = true;
        List<Establishment> tempestlists = EstablishmentDB.getAllTempEstablishmentsbyStatus("pending");
        Establishment te = tempestlists[gvpending.PageSize * gvpending.PageIndex + gvpending.SelectedIndex];
        email.Text = te.Email;
        name.Text = te.Name;
        tempEstablishmentID.Text = te.ID;
        phone.Text = te.Phone.ToString();
        address.Text = te.Address;
        Type.Text = te.Type;
        ddlStatus.SelectedValue = te.Status;

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Establishment tempE = EstablishmentDB.getTempEstablishmentByEmail(email.Text);
        if (ddlStatus.SelectedValue == "pending")
        {
            lblOutput.Text = "The status cannot be pending! Please choose approve or dismiss.";
            return;
        }

        else
        {
            tempE.Status = ddlStatus.SelectedValue;
            int num = EstablishmentDB.updatetempStatus(tempE);
            if (num != 1)
                lblOutput.Text = "Cannot Update Status!";
            else
            {
                lblOutput.Text = "";
                Panel1.Visible = false;
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("inft3050@gmail.com", "inft.3050");
                MailMessage msg = new MailMessage("inft3050@gmail.com", tempE.Email);
                if (ddlStatus.SelectedValue == "approved")
                {
                    Admins a = AdminDB.getAdminbyEmail(Session["email"].ToString());
                    Establishment est = new Establishment(tempE.Email, tempE.Name, tempE.Password, tempE.Type, tempE.Phone, tempE.Address, tempE.ID, a);
                    int number = EstablishmentDB.insertEstablishment(est);
                    if (number != 1)
                    {
                        Label2.Text = "Cannot Register to Establishment table!";
                        return;
                    }
                    else
                    {//sending email to establishment when accept 
                        msg.Subject = "Life++ Application!";
                        msg.Body = "Your request for joining Life++ have been approved. You are now part of our system and can start using now.\n\n Thank you for joining our system. \n\n Team Life++";
                        client.Send(msg);
                        Label2.Text = "Information successfully Updated! Approval email sent to " + email.Text + " .";
                    }

                }
                else
                {//sending email to establishment when dismissed 
                    msg.Subject = "Life++ Application!";
                    msg.Body = "Your request for joining Life++ have been dismissed. Thank you for interesting to join our system.\n\n For more information, please contact us at -------@gmail.com \n\n Team Life++ ";
                    client.Send(msg);
                    Label2.Text = "Information successfully Updated! Dismissed email sent to " + email.Text + " .";
                }
                Panel1.Visible = false;
                List<Establishment> tempestlists = EstablishmentDB.getAllTempEstablishmentsbyStatus("pending");
                gvpending.DataSource = tempestlists;
                gvpending.DataBind();
                if (tempestlists.Count == 0)
                {
                    lblSelectError.Text = "There are no pending request left right now.";
                }
                else
                {
                    lblSelectError.Text = "There are " + tempestlists.Count + " records found";
                }

            }
        }
    }
}