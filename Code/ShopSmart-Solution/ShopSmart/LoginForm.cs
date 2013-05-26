using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopSmart.Dal;

namespace ShopSmart.Client
{
    /// <summary>
    /// The form that uses ti collect information for login
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Data members
        /// <summary>
        /// The forms text to display when used for login
        /// </summary>
        const string LOGIN_HEADER_TEXT = "כניסת משתמשים רשומים";
        /// <summary>
        /// The forms text to display when used for create new user
        /// </summary>
        const string CREATE_USER_HEADER_TEXT = "יצירת משתמש חדש";
        /*Validation error messages*/
        const string ERROR_BLANK_USERNAME = "שם משתמש לא יכול להיות ריק.";
        const string ERROR_BLANK_PASSWORD = "סיסמא לא יכולה להיות ריקה.";
        const string ERROR_PASSWORD_MISSMATCH = "הסיסמאות אינן תואמות.";
        const string ERROR_USERID_ERROR = "מספר הזהות אינו תקין.";

        /// <summary>
        /// The login mode (login / create user)
        /// </summary>
        LoginType _loginMode;

        /// <summary>
        /// Indicates if the form is for admin user
        /// </summary>
        private bool _isAdmin;

        /// <summary>
        /// Gets the user name typed by user.
        /// </summary>       
        public string UserName
        {
            get { return this.txbUserName.Text; }
        }

        /// <summary>
        /// Gets the password typed by user
        /// </summary>       
        public string Password
        {
            get { return this.txbPassword.Text; }
        }

        /// <summary>
        /// Gets the type of the user. if for non admin or when logging in, will be null
        /// </summary>
        /// <value>
        /// The type of the user.
        /// </value>
        public UserTypes? UserType
        {
            get
            {
                UserTypes? retVal = null;
                //the cases when it is relevant
                if (!this._isAdmin && this._loginMode == LoginType.CreateNewUser)
                {
                    retVal = this.cmbUserTypes.SelectedItem as UserTypes?;
                }
                return retVal;
            }
        }
        /// <summary>
        /// Gets user Id. if for non admin or when logging in, will be null
        /// </summary>
        public string UserId
        {
            get
            {
                string retVal = null;
                //the cases when it is relevant
                if (this._isAdmin && this._loginMode == LoginType.CreateNewUser)
                {
                    retVal = this.txbUserId.Text;
                }
                return retVal;
            }
        }



        #endregion
        
        #region C'tor
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="isOwnerAdministrator">if set to <c>true</c> Administration options will be enabled.</param>
        public LoginForm(LoginType mode, bool isOwnerAdministrator)
        {
            InitializeComponent();
            this._loginMode = mode;
            this._isAdmin = isOwnerAdministrator;
            this.InitGui();
           
        }
        #endregion

        #region Private functions

        /// <summary>
        /// Initializess the GUI.
        /// </summary>
        private void InitGui()
        {

            string headerText;
            #region Setting data related to create user /login
            switch (this._loginMode)
            {
                case LoginType.CreateNewUser:
                    headerText = LoginForm.CREATE_USER_HEADER_TEXT;
                    break;
                case LoginType.Login:
                    /*Hide the confirm password row. It is set to autosize. Hiding the controls will hide the row*/
                    this.lblConfirmPassword.Hide();
                    this.txbConfirmPassword.Hide();
                     //not relevent for creating new user
                     this.lblUserType.Hide();
                     this.cmbUserTypes.Hide();
                     this.lblUserId.Hide();
                     this.txbUserId.Hide();
                    headerText = LoginForm.LOGIN_HEADER_TEXT;
                    break;
                default:
                    headerText = "נתוני משתמש";
                    break;
            } 
            #endregion

            #region Setting data related to administration
            //setting admin controls
            if (!this._isAdmin)
            {
                this.lblUserType.Hide();
                this.cmbUserTypes.Hide();
            } 
            #endregion

            this.cmbUserTypes.Items.AddRange(Enum.GetNames(typeof(UserTypes)));
            int index = this.cmbUserTypes.Items.IndexOf(Enum.GetName(typeof(UserTypes),UserTypes.User));
            this.cmbUserTypes.SelectedIndex = Math.Max(index,0);
            

            this.Text = headerText;
        } 
        /// <summary>
        /// Validates the credentials typed by user. and sets error provider notification
        /// </summary>
        /// <param name="message">The error message if validation failed.</param>
        /// <returns></returns>
        private bool ValidateCredentials(out string message)
        {
            message = String.Empty;
            bool hasUserName = !String.IsNullOrWhiteSpace(this.txbUserName.Text);
            bool hasPassword = !String.IsNullOrWhiteSpace(this.txbPassword.Text);
            bool passwordsMatch = this._loginMode == LoginType.Login 
                                || this.txbPassword.Text == this.txbConfirmPassword.Text;

            int dummy;
            bool hasUserId = true;
            //if we are just logging in, we do not care about ID
            if (this._loginMode == LoginType.CreateNewUser)
            {
                hasUserId = this.txbUserId.Text.Length == 9 && int.TryParse(this.txbUserId.Text, out dummy);
            }
           
            #region Set error mesasge and errorprovider
            /*Construct message*/
            if (!hasUserName)
            {
                this._errorProvider.SetError(this.txbUserName, LoginForm.ERROR_BLANK_USERNAME);
                message += LoginForm.ERROR_BLANK_USERNAME;
            }
            if (!hasPassword)
            {
                this._errorProvider.SetError(this.txbPassword, LoginForm.ERROR_BLANK_PASSWORD);
                message += Environment.NewLine+ LoginForm.ERROR_BLANK_PASSWORD;
            }
            if (!passwordsMatch)
            {
                this._errorProvider.SetError(this.txbConfirmPassword, LoginForm.ERROR_PASSWORD_MISSMATCH);
                message += Environment.NewLine+LoginForm.ERROR_PASSWORD_MISSMATCH;
            }
            if (!hasUserId)
            {
                this._errorProvider.SetError(this.txbUserId, LoginForm.ERROR_USERID_ERROR);
                message += Environment.NewLine + LoginForm.ERROR_USERID_ERROR;
            }

            message = message.Trim();

            #endregion

            bool isValid = hasUserName && hasPassword && passwordsMatch && hasUserId;
            return isValid;
        }	
	#endregion

        #region Event Handlers
        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
           
            string message;
            bool valid = this.ValidateCredentials(out message);

            if (!valid)
            {
                MessageBox.Show(this,"שגיאה בנתונים שהוקלדו:\n"
                                +message);

            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the TextChanged event of the one of the "Credential TextBoxes" control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CredentialTextBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null)
            {
                //clear error
                this._errorProvider.SetError(ctrl, String.Empty);
                //check again for errors
                string msg;
                this.ValidateCredentials(out msg);
            }
            
        }

        /// <summary>
        /// Handles the KeyPress event of the txbUserId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void txbUserId_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Allow only 9 digits
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                || this.txbUserId.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Sub classes
        public enum LoginType
        {
            CreateNewUser = 1,
            Login = 2
        } 
        #endregion



        

    }
}
