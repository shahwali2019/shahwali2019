using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace unlockupdate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = User.Identity.Name.Substring(User.Identity.Name.Length - 6).ToUpper();
            if (lblUser.Text.Trim().Contains("SAFHQ2") || lblUser.Text.Trim().Contains("ISAFHQ") || lblUser.Text.Trim().Contains("KAIA") || lblUser.Text.Trim().Contains("KAIA2") || lblUser.Text.Trim().Contains("SAMSAF") || lblUser.Text.Trim().Contains("MT") || lblUser.Text.Trim().Contains("HAMSHA"))
            {
                txtUserID.Enabled = true;
                txtUserID.Visible = true;
                lblusername.Visible = true;
                // txtUserID.Text = lblUser.Text;
            }
        }

        protected void btnUnlock_Click1(object sender, EventArgs e)
        {
            string workName = lblUser.Text.Trim();
            if (workName.Contains("SAFHQ2") || lblUser.Text.Trim().Contains("ISAFHQ") || workName.Contains("KAIA") || lblUser.Text.Trim().Contains("KAIA2") || workName.Contains("SAMSAF"))
            {
                workName = txtUserID.Text;
            }


            lblMessage.Text = "";
            if (string.IsNullOrEmpty(workName))
                return;
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            OracleConnection oracleCon = new OracleConnection();
            OracleCommand oracleCom = new OracleCommand();
            oracleCom.Connection = oracleCon;
            oracleCon.ConnectionString = "user id=appuser;password=Z__M098765;data source=fccprod";
            //Clear Flexcube======================================================================================================  
            if (clbSystem.Items[0].Selected)
            {
                oracleCom.CommandText = "DELETE FROM FCCPROD.SMTB_CURRENT_USERS where user_id = '" + workName + "'";
                try
                {
                    oracleCon.Open();
                    oracleCom.ExecuteNonQuery();
                    oracleCon.Close();
                    lblMessage.Text += "Flexcube account is unlocked <br />";
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "Problem to unlock Flexcube account" + ex.Message + "<br />";
                }
            }
            //Clear CAMS==========================================================================================================
            if (clbSystem.Items[1].Selected)
            {
                con.ConnectionString = @"server=192.168.0.135;Failover Partner=10.1.2.14;Database=aibOnline;User ID=camsactive;Password=\CamsprodD$&123";
                com.CommandText = @"update R_Users
                                set BadAttemptCount =0,is_loggedin=null where WorkName like ('%" + workName + "')";
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    lblMessage.Text += "CAMS account is unlocked <br />";
                }
                catch
                {
                    lblMessage.Text += "Problem to unlock CAMS account<br />";
                }
            }
            //Clear Fileup=====================================================================================================
            if (clbSystem.Items[2].Selected) //Fileup
            {
                con.ConnectionString = "server=192.168.0.26;Failover Partner=10.1.2.14;Database=Fileup;User ID=fileup_user;Password=fileup_New$1";
                com.CommandText = "update [user] set isLogin='false' where workName='" + workName.ToLower() + "'";
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    lblMessage.Text += "Fileup account is unlocked <br />";
                }
                catch
                {
                    lblMessage.Text += "Problem to unlock Fileup account<br />";
                }
            }

            //-------------------------------------------------------------------------
            //Clear TFL=================================ALAWI====================================================================
            if (clbSystem.Items[3].Selected) //Fileup
            {
                string connectionString = "server=192.168.0.26;Failover Partner=10.1.2.14;Database=Collateral;User ID=sma;Password=1111";
                using (SqlConnection sqlCon2 = new SqlConnection(connectionString))
                {

                    sqlCon2.Open();
                    string Delquery = "DELETE FROM registration WHERE Username='" + lblUser.Text + "'";
                    SqlCommand sqlcmdDel = new SqlCommand(Delquery, sqlCon2);
                    sqlcmdDel.ExecuteNonQuery();
                    sqlCon2.Close();
                }
                lblMessage.Text += "TFL account is unlocked <br />";

            }
        }
    }
}