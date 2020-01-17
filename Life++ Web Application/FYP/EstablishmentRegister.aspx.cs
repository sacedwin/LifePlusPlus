using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EstablishmentRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<Establishment> establishments = EstablishmentDB.getAllTempEstablishments();
        int estFound = 0;
        foreach (Establishment tee in establishments)
        {
            if (tbxEmail.Text == tee.Email)
            {
                if (tee.Status == "pending")
                    estFound = 1;
                else if (tee.Status == "approved")
                    estFound = 2;

            }
        }
        if (estFound == 1)
            lblOutput.Text = "Your application is processing.";
        else if (estFound == 2)
            lblOutput.Text = "Your establishment already exists.";
        else
        {
            Establishment te = new Establishment();
            te.Email = tbxEmail.Text;
            te.Name = tbxName.Text;
            te.Password = tbxPassword.Text;
            te.Type = rbtnlstType.SelectedValue;
            te.Phone = Convert.ToInt32(tbxPhone.Text);
            te.Address = tbxAddress.Text;
            te.Status = "pending";
            int num = EstablishmentDB.insertTempEstablishment(te);
            if (num != 1)
            {
                lblOutput.Text = "Cannot";
            }
            else
                lblOutput.Text = "Your application was successful.";
        }

    }
}