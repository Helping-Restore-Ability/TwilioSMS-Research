using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;



namespace TwilioSMS
{
    public partial class TwilioSMS : Form
    {


        
        public TwilioSMS()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
           
            string accountSid = ConfigurationManager.AppSettings.Get("AccountSid");
            string authToken = ConfigurationManager.AppSettings.Get("AuthToken");
            TwilioClient.Init(accountSid, authToken);
            //var numbersToMessage = new List<string>();
            if (MessageBody.Text == "")
            {
                MessageBox.Show("Please enter a message before continuing.");
                return;
            }
            foreach(DataGridViewRow number in RecipientsDGV.Rows)
            {
                var toNumber = number.Cells["Phone"].Value;
                if(toNumber == null)
                {
                    continue;
                }
                var message = MessageResource.Create(
                body: MessageBody.Text,
                //from: new Twilio.Types.PhoneNumber("8175873983"),
                from: new Twilio.Types.PhoneNumber("18177610889"),
                to: new Twilio.Types.PhoneNumber(toNumber.ToString())
                );
            }     
        }

        private void RecipientsBtn_Click(object sender, EventArgs e)
        {
            AttendantSearch attendantSearch = new AttendantSearch();
            String PhoneNumber = String.Empty;
            var Result = attendantSearch.ShowDialog("Attendant Search", "Please Enter Attendant Name", " ",ref PhoneNumber, true);
            if(Result == DialogResult.OK && PhoneNumber != "")
            {
                RecipientsDGV.Rows.Add(PhoneNumber);
            }
        }

        private void RecipientsDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.V && e.Control )
                {
                DataObject o = (DataObject)Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    foreach (string pastedRow in pastedRows)
                    {
                        string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                        RecipientsDGV.Rows.Add(pastedRowCells[0]);
                    }
                }
            }
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }

        private void TwilioSMS_Load(object sender, EventArgs e)
        {
            InstallUpdateSyncWithInfo();
        }
    }
}
