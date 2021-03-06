namespace Kerr.PromptBuilder
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox parametersGroup;
            System.Windows.Forms.CheckBox hidePassword;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.Label errorCodeLabel;
            System.Windows.Forms.Label bannerLabel;
            System.Windows.Forms.Label messageLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label targetNameLabel;
            System.Windows.Forms.GroupBox helpGroup;
            System.Windows.Forms.LinkLabel msdnLink;
            this.m_saveChecked = new System.Windows.Forms.CheckBox();
            this.m_errorCode = new System.Windows.Forms.TextBox();
            this.m_bannerBrowse = new System.Windows.Forms.Button();
            this.m_banner = new System.Windows.Forms.TextBox();
            this.m_message = new System.Windows.Forms.TextBox();
            this.m_title = new System.Windows.Forms.TextBox();
            this.m_password = new System.Windows.Forms.TextBox();
            this.m_userName = new System.Windows.Forms.TextBox();
            this.m_targetName = new System.Windows.Forms.TextBox();
            this.m_help = new System.Windows.Forms.TextBox();
            this.m_copyCsCode = new System.Windows.Forms.Button();
            this.m_copyCppCode = new System.Windows.Forms.Button();
            this.m_test = new System.Windows.Forms.Button();
            this.flagsGroup = new System.Windows.Forms.GroupBox();
            this.m_validateUserName = new System.Windows.Forms.CheckBox();
            this.m_userNameReadOnly = new System.Windows.Forms.CheckBox();
            this.m_completeUserName = new System.Windows.Forms.CheckBox();
            this.m_showSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.m_requireSmartCard = new System.Windows.Forms.CheckBox();
            this.m_requireCertificate = new System.Windows.Forms.CheckBox();
            this.m_requestAdministrator = new System.Windows.Forms.CheckBox();
            this.m_persist = new System.Windows.Forms.CheckBox();
            this.m_incorrectPassword = new System.Windows.Forms.CheckBox();
            this.m_genericCredentials = new System.Windows.Forms.CheckBox();
            this.m_expectConfirmation = new System.Windows.Forms.CheckBox();
            this.m_excludeCertificates = new System.Windows.Forms.CheckBox();
            this.m_doNotPersist = new System.Windows.Forms.CheckBox();
            this.m_alwaysShowUI = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            parametersGroup = new System.Windows.Forms.GroupBox();
            hidePassword = new System.Windows.Forms.CheckBox();
            errorCodeLabel = new System.Windows.Forms.Label();
            bannerLabel = new System.Windows.Forms.Label();
            messageLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            targetNameLabel = new System.Windows.Forms.Label();
            helpGroup = new System.Windows.Forms.GroupBox();
            msdnLink = new System.Windows.Forms.LinkLabel();
            parametersGroup.SuspendLayout();
            helpGroup.SuspendLayout();
            this.flagsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // parametersGroup
            // 
            parametersGroup.Controls.Add(hidePassword);
            parametersGroup.Controls.Add(this.m_saveChecked);
            parametersGroup.Controls.Add(this.m_errorCode);
            parametersGroup.Controls.Add(errorCodeLabel);
            parametersGroup.Controls.Add(this.m_bannerBrowse);
            parametersGroup.Controls.Add(this.m_banner);
            parametersGroup.Controls.Add(bannerLabel);
            parametersGroup.Controls.Add(this.m_message);
            parametersGroup.Controls.Add(messageLabel);
            parametersGroup.Controls.Add(this.m_title);
            parametersGroup.Controls.Add(titleLabel);
            parametersGroup.Controls.Add(this.m_password);
            parametersGroup.Controls.Add(passwordLabel);
            parametersGroup.Controls.Add(this.m_userName);
            parametersGroup.Controls.Add(userNameLabel);
            parametersGroup.Controls.Add(this.m_targetName);
            parametersGroup.Controls.Add(targetNameLabel);
            parametersGroup.Location = new System.Drawing.Point(12, 12);
            parametersGroup.Name = "parametersGroup";
            parametersGroup.Size = new System.Drawing.Size(324, 254);
            parametersGroup.TabIndex = 0;
            parametersGroup.TabStop = false;
            parametersGroup.Text = "Properties";
            // 
            // hidePassword
            // 
            hidePassword.AutoSize = true;
            hidePassword.Checked = true;
            hidePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            hidePassword.Location = new System.Drawing.Point(217, 79);
            hidePassword.Name = "hidePassword";
            hidePassword.Size = new System.Drawing.Size(96, 17);
            hidePassword.TabIndex = 6;
            hidePassword.Text = "Hide password";
            hidePassword.CheckedChanged += new System.EventHandler(this.HidePasswordEventHandler);
            // 
            // m_saveChecked
            // 
            this.m_saveChecked.AutoSize = true;
            this.m_saveChecked.Location = new System.Drawing.Point(16, 223);
            this.m_saveChecked.Name = "m_saveChecked";
            this.m_saveChecked.Size = new System.Drawing.Size(143, 17);
            this.m_saveChecked.TabIndex = 16;
            this.m_saveChecked.Tag = "Specifies the initial state of the Save check box and receives the state of the S" +
                "ave check box after the user has responded to the dialog box.";
            this.m_saveChecked.Text = "State of Save check box";
            this.m_saveChecked.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_errorCode
            // 
            this.m_errorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_errorCode.Location = new System.Drawing.Point(90, 187);
            this.m_errorCode.Name = "m_errorCode";
            this.m_errorCode.Size = new System.Drawing.Size(219, 21);
            this.m_errorCode.TabIndex = 15;
            this.m_errorCode.Tag = resources.GetString("m_errorCode.Tag");
            this.m_errorCode.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // errorCodeLabel
            // 
            errorCodeLabel.AutoSize = true;
            errorCodeLabel.Location = new System.Drawing.Point(15, 190);
            errorCodeLabel.Name = "errorCodeLabel";
            errorCodeLabel.Size = new System.Drawing.Size(61, 13);
            errorCodeLabel.TabIndex = 14;
            errorCodeLabel.Text = "Error code:";
            // 
            // m_bannerBrowse
            // 
            this.m_bannerBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_bannerBrowse.AutoSize = true;
            this.m_bannerBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_bannerBrowse.Location = new System.Drawing.Point(237, 158);
            this.m_bannerBrowse.Name = "m_bannerBrowse";
            this.m_bannerBrowse.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_bannerBrowse.Size = new System.Drawing.Size(72, 23);
            this.m_bannerBrowse.TabIndex = 13;
            this.m_bannerBrowse.Text = "Browse...";
            this.m_bannerBrowse.Click += new System.EventHandler(this.BannerBrowseEventHandler);
            // 
            // m_banner
            // 
            this.m_banner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_banner.Location = new System.Drawing.Point(90, 158);
            this.m_banner.Name = "m_banner";
            this.m_banner.ReadOnly = true;
            this.m_banner.Size = new System.Drawing.Size(145, 21);
            this.m_banner.TabIndex = 12;
            this.m_banner.Tag = "Bitmap to display in the dialog box. If this property is not set, a default bitma" +
                "p is used. The bitmap size is limited to 320x60 pixels.";
            this.m_banner.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // bannerLabel
            // 
            bannerLabel.AutoSize = true;
            bannerLabel.Location = new System.Drawing.Point(15, 161);
            bannerLabel.Name = "bannerLabel";
            bannerLabel.Size = new System.Drawing.Size(45, 13);
            bannerLabel.TabIndex = 11;
            bannerLabel.Text = "Banner:";
            // 
            // m_message
            // 
            this.m_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_message.Location = new System.Drawing.Point(90, 131);
            this.m_message.Name = "m_message";
            this.m_message.Size = new System.Drawing.Size(219, 21);
            this.m_message.TabIndex = 10;
            this.m_message.Tag = "Contains a brief message to display in the dialog box.";
            this.m_message.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(15, 134);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(53, 13);
            messageLabel.TabIndex = 9;
            messageLabel.Text = "Message:";
            // 
            // m_title
            // 
            this.m_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_title.Location = new System.Drawing.Point(90, 104);
            this.m_title.Name = "m_title";
            this.m_title.Size = new System.Drawing.Size(219, 21);
            this.m_title.TabIndex = 8;
            this.m_title.Tag = "Contains the title for the dialog box. ";
            this.m_title.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(15, 107);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(31, 13);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "Title:";
            // 
            // m_password
            // 
            this.m_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_password.Location = new System.Drawing.Point(90, 77);
            this.m_password.Name = "m_password";
            this.m_password.Size = new System.Drawing.Size(121, 21);
            this.m_password.TabIndex = 5;
            this.m_password.Tag = "Contains the password for the credentials. If a nonzero-length string is specifie" +
                "d, the password option of the dialog box will be prefilled with the string.";
            this.m_password.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(15, 80);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(57, 13);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // m_userName
            // 
            this.m_userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_userName.Location = new System.Drawing.Point(90, 50);
            this.m_userName.Name = "m_userName";
            this.m_userName.Size = new System.Drawing.Size(219, 21);
            this.m_userName.TabIndex = 3;
            this.m_userName.Tag = resources.GetString("m_userName.Tag");
            this.m_userName.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(15, 53);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(62, 13);
            userNameLabel.TabIndex = 2;
            userNameLabel.Text = "User name:";
            // 
            // m_targetName
            // 
            this.m_targetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_targetName.Location = new System.Drawing.Point(90, 23);
            this.m_targetName.Name = "m_targetName";
            this.m_targetName.Size = new System.Drawing.Size(219, 21);
            this.m_targetName.TabIndex = 1;
            this.m_targetName.Tag = resources.GetString("m_targetName.Tag");
            this.m_targetName.Text = "Server";
            this.m_targetName.MouseHover += new System.EventHandler(this.FocusEventHandler);
            this.m_targetName.TextChanged += new System.EventHandler(this.TargetNameChangedEventHandler);
            // 
            // targetNameLabel
            // 
            targetNameLabel.AutoSize = true;
            targetNameLabel.Location = new System.Drawing.Point(15, 27);
            targetNameLabel.Name = "targetNameLabel";
            targetNameLabel.Size = new System.Drawing.Size(72, 13);
            targetNameLabel.TabIndex = 0;
            targetNameLabel.Text = "Target name:";
            // 
            // helpGroup
            // 
            helpGroup.Controls.Add(this.m_help);
            helpGroup.Location = new System.Drawing.Point(12, 272);
            helpGroup.Name = "helpGroup";
            helpGroup.Size = new System.Drawing.Size(686, 100);
            helpGroup.TabIndex = 2;
            helpGroup.TabStop = false;
            helpGroup.Text = "Help";
            // 
            // m_help
            // 
            this.m_help.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_help.Location = new System.Drawing.Point(12, 20);
            this.m_help.Multiline = true;
            this.m_help.Name = "m_help";
            this.m_help.ReadOnly = true;
            this.m_help.Size = new System.Drawing.Size(661, 65);
            this.m_help.TabIndex = 0;
            // 
            // msdnLink
            // 
            msdnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            msdnLink.AutoSize = true;
            msdnLink.LinkArea = new System.Windows.Forms.LinkArea(5, 26);
            msdnLink.Location = new System.Drawing.Point(12, 387);
            msdnLink.Name = "msdnLink";
            msdnLink.Size = new System.Drawing.Size(255, 18);
            msdnLink.TabIndex = 3;
            msdnLink.TabStop = true;
            msdnLink.Tag = "http://msdn.com/library/en-us/secauthn/security/creduipromptforcredentials.asp";
            msdnLink.Text = "View CredUIPromptForCredentials documentation.";
            msdnLink.UseCompatibleTextRendering = true;
            msdnLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClickedEventHandler);
            // 
            // m_copyCsCode
            // 
            this.m_copyCsCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_copyCsCode.AutoSize = true;
            this.m_copyCsCode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_copyCsCode.Location = new System.Drawing.Point(509, 408);
            this.m_copyCsCode.Name = "m_copyCsCode";
            this.m_copyCsCode.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_copyCsCode.Size = new System.Drawing.Size(96, 23);
            this.m_copyCsCode.TabIndex = 6;
            this.m_copyCsCode.Text = "Copy C# Code";
            this.m_copyCsCode.Click += new System.EventHandler(this.CopyCSharpCodeEventHandler);
            // 
            // m_copyCppCode
            // 
            this.m_copyCppCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_copyCppCode.AutoSize = true;
            this.m_copyCppCode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_copyCppCode.Location = new System.Drawing.Point(403, 408);
            this.m_copyCppCode.Name = "m_copyCppCode";
            this.m_copyCppCode.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_copyCppCode.Size = new System.Drawing.Size(104, 23);
            this.m_copyCppCode.TabIndex = 5;
            this.m_copyCppCode.Text = "Copy C++ Code";
            this.m_copyCppCode.Click += new System.EventHandler(this.CopyCppCodeEventHandler);
            // 
            // m_test
            // 
            this.m_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_test.AutoSize = true;
            this.m_test.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_test.Location = new System.Drawing.Point(615, 408);
            this.m_test.Name = "m_test";
            this.m_test.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_test.Size = new System.Drawing.Size(83, 23);
            this.m_test.TabIndex = 7;
            this.m_test.Text = "Test Prompt";
            this.m_test.Click += new System.EventHandler(this.TestEventHandler);
            // 
            // flagsGroup
            // 
            this.flagsGroup.Controls.Add(this.m_validateUserName);
            this.flagsGroup.Controls.Add(this.m_userNameReadOnly);
            this.flagsGroup.Controls.Add(this.m_completeUserName);
            this.flagsGroup.Controls.Add(this.m_showSaveCheckBox);
            this.flagsGroup.Controls.Add(this.m_requireSmartCard);
            this.flagsGroup.Controls.Add(this.m_requireCertificate);
            this.flagsGroup.Controls.Add(this.m_requestAdministrator);
            this.flagsGroup.Controls.Add(this.m_persist);
            this.flagsGroup.Controls.Add(this.m_incorrectPassword);
            this.flagsGroup.Controls.Add(this.m_genericCredentials);
            this.flagsGroup.Controls.Add(this.m_expectConfirmation);
            this.flagsGroup.Controls.Add(this.m_excludeCertificates);
            this.flagsGroup.Controls.Add(this.m_doNotPersist);
            this.flagsGroup.Controls.Add(this.m_alwaysShowUI);
            this.flagsGroup.Location = new System.Drawing.Point(342, 12);
            this.flagsGroup.Name = "flagsGroup";
            this.flagsGroup.Size = new System.Drawing.Size(356, 254);
            this.flagsGroup.TabIndex = 1;
            this.flagsGroup.TabStop = false;
            this.flagsGroup.Text = "Flags";
            // 
            // m_validateUserName
            // 
            this.m_validateUserName.AutoSize = true;
            this.m_validateUserName.Location = new System.Drawing.Point(167, 167);
            this.m_validateUserName.Name = "m_validateUserName";
            this.m_validateUserName.Size = new System.Drawing.Size(117, 17);
            this.m_validateUserName.TabIndex = 13;
            this.m_validateUserName.Text = "Validate user name";
            // 
            // m_userNameReadOnly
            // 
            this.m_userNameReadOnly.AutoSize = true;
            this.m_userNameReadOnly.Location = new System.Drawing.Point(167, 144);
            this.m_userNameReadOnly.Name = "m_userNameReadOnly";
            this.m_userNameReadOnly.Size = new System.Drawing.Size(126, 17);
            this.m_userNameReadOnly.TabIndex = 12;
            this.m_userNameReadOnly.Text = "User name read-only";
            // 
            // m_completeUserName
            // 
            this.m_completeUserName.AutoSize = true;
            this.m_completeUserName.Location = new System.Drawing.Point(15, 50);
            this.m_completeUserName.Name = "m_completeUserName";
            this.m_completeUserName.Size = new System.Drawing.Size(124, 17);
            this.m_completeUserName.TabIndex = 1;
            this.m_completeUserName.Text = "Complete user name";
            // 
            // m_showSaveCheckBox
            // 
            this.m_showSaveCheckBox.AutoSize = true;
            this.m_showSaveCheckBox.Location = new System.Drawing.Point(167, 121);
            this.m_showSaveCheckBox.Name = "m_showSaveCheckBox";
            this.m_showSaveCheckBox.Size = new System.Drawing.Size(129, 17);
            this.m_showSaveCheckBox.TabIndex = 11;
            this.m_showSaveCheckBox.Tag = resources.GetString("m_showSaveCheckBox.Tag");
            this.m_showSaveCheckBox.Text = "Show save check box";
            this.m_showSaveCheckBox.CheckedChanged += new System.EventHandler(this.ShowSaveCheckBoxCheckedChangedEventHandler);
            this.m_showSaveCheckBox.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_requireSmartCard
            // 
            this.m_requireSmartCard.AutoSize = true;
            this.m_requireSmartCard.Location = new System.Drawing.Point(167, 98);
            this.m_requireSmartCard.Name = "m_requireSmartCard";
            this.m_requireSmartCard.Size = new System.Drawing.Size(117, 17);
            this.m_requireSmartCard.TabIndex = 10;
            this.m_requireSmartCard.Tag = " Populate the combo box with certificates or smart cards only. Do not allow a use" +
                "r name to be entered. ";
            this.m_requireSmartCard.Text = "Require smart card";
            this.m_requireSmartCard.CheckedChanged += new System.EventHandler(this.RequireSmartCardCheckedChangedEventHandler);
            this.m_requireSmartCard.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_requireCertificate
            // 
            this.m_requireCertificate.AutoSize = true;
            this.m_requireCertificate.Location = new System.Drawing.Point(167, 75);
            this.m_requireCertificate.Name = "m_requireCertificate";
            this.m_requireCertificate.Size = new System.Drawing.Size(114, 17);
            this.m_requireCertificate.TabIndex = 9;
            this.m_requireCertificate.Tag = "Populate the combo box with certificates and smart cards only. Do not allow a use" +
                "r name to be entered.";
            this.m_requireCertificate.Text = "Require certificate";
            this.m_requireCertificate.CheckedChanged += new System.EventHandler(this.RequireCertificateCheckedChangedEventHandler);
            this.m_requireCertificate.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_requestAdministrator
            // 
            this.m_requestAdministrator.AutoSize = true;
            this.m_requestAdministrator.Location = new System.Drawing.Point(167, 52);
            this.m_requestAdministrator.Name = "m_requestAdministrator";
            this.m_requestAdministrator.Size = new System.Drawing.Size(132, 17);
            this.m_requestAdministrator.TabIndex = 8;
            this.m_requestAdministrator.Tag = "Populate the combo box with local administrators only.";
            this.m_requestAdministrator.Text = "Request administrator";
            this.m_requestAdministrator.CheckedChanged += new System.EventHandler(this.RequestAdministratorCheckedChangedEventHandler);
            this.m_requestAdministrator.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_persist
            // 
            this.m_persist.AutoSize = true;
            this.m_persist.Location = new System.Drawing.Point(167, 26);
            this.m_persist.Name = "m_persist";
            this.m_persist.Size = new System.Drawing.Size(58, 17);
            this.m_persist.TabIndex = 7;
            this.m_persist.Tag = "Do not show the Save check box, but the credential is saved as though the box wer" +
                "e shown and selected.";
            this.m_persist.Text = "Persist";
            this.m_persist.CheckedChanged += new System.EventHandler(this.PersistCheckedChangedEventHandler);
            this.m_persist.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_incorrectPassword
            // 
            this.m_incorrectPassword.AutoSize = true;
            this.m_incorrectPassword.Location = new System.Drawing.Point(15, 165);
            this.m_incorrectPassword.Name = "m_incorrectPassword";
            this.m_incorrectPassword.Size = new System.Drawing.Size(119, 17);
            this.m_incorrectPassword.TabIndex = 6;
            this.m_incorrectPassword.Tag = "Notify the user of insufficient credentials by displaying the \"Logon unsuccessful" +
                "\" balloon tip.";
            this.m_incorrectPassword.Text = "Incorrect password";
            this.m_incorrectPassword.CheckedChanged += new System.EventHandler(this.IncorrectPasswordCheckedChangedEventHandler);
            this.m_incorrectPassword.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_genericCredentials
            // 
            this.m_genericCredentials.AutoSize = true;
            this.m_genericCredentials.Location = new System.Drawing.Point(15, 142);
            this.m_genericCredentials.Name = "m_genericCredentials";
            this.m_genericCredentials.Size = new System.Drawing.Size(117, 17);
            this.m_genericCredentials.TabIndex = 5;
            this.m_genericCredentials.Tag = "Consider the credentials entered by the user to be generic credentials.";
            this.m_genericCredentials.Text = "Generic credentials";
            this.m_genericCredentials.CheckedChanged += new System.EventHandler(this.GenericCredentialsCheckedChangedEventHandler);
            this.m_genericCredentials.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_expectConfirmation
            // 
            this.m_expectConfirmation.AutoSize = true;
            this.m_expectConfirmation.Location = new System.Drawing.Point(15, 119);
            this.m_expectConfirmation.Name = "m_expectConfirmation";
            this.m_expectConfirmation.Size = new System.Drawing.Size(121, 17);
            this.m_expectConfirmation.TabIndex = 4;
            this.m_expectConfirmation.Tag = resources.GetString("m_expectConfirmation.Tag");
            this.m_expectConfirmation.Text = "Expect confirmation";
            this.m_expectConfirmation.CheckedChanged += new System.EventHandler(this.ExpectConfirmationCheckedChangedEventHandler);
            this.m_expectConfirmation.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_excludeCertificates
            // 
            this.m_excludeCertificates.AutoSize = true;
            this.m_excludeCertificates.Location = new System.Drawing.Point(15, 96);
            this.m_excludeCertificates.Name = "m_excludeCertificates";
            this.m_excludeCertificates.Size = new System.Drawing.Size(119, 17);
            this.m_excludeCertificates.TabIndex = 3;
            this.m_excludeCertificates.Tag = "Populate the combo box with user name/password only. Do not display certificates " +
                "or smart cards in the combo box.";
            this.m_excludeCertificates.Text = "Exclude certificates";
            this.m_excludeCertificates.CheckedChanged += new System.EventHandler(this.ExcludeCertificatesCheckedChangedEventHandler);
            this.m_excludeCertificates.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_doNotPersist
            // 
            this.m_doNotPersist.AutoSize = true;
            this.m_doNotPersist.Location = new System.Drawing.Point(15, 73);
            this.m_doNotPersist.Name = "m_doNotPersist";
            this.m_doNotPersist.Size = new System.Drawing.Size(93, 17);
            this.m_doNotPersist.TabIndex = 2;
            this.m_doNotPersist.Tag = "Do not store credentials or display check boxes. You can set the ShowSaveCheckBox" +
                " property to display the Save check box only, and the result is returned in the " +
                "SaveChecked property.";
            this.m_doNotPersist.Text = "Do not persist";
            this.m_doNotPersist.CheckedChanged += new System.EventHandler(this.DoNotPersistCheckedChangedEventHandler);
            this.m_doNotPersist.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // m_alwaysShowUI
            // 
            this.m_alwaysShowUI.AutoSize = true;
            this.m_alwaysShowUI.Location = new System.Drawing.Point(15, 27);
            this.m_alwaysShowUI.Name = "m_alwaysShowUI";
            this.m_alwaysShowUI.Size = new System.Drawing.Size(102, 17);
            this.m_alwaysShowUI.TabIndex = 0;
            this.m_alwaysShowUI.Tag = resources.GetString("m_alwaysShowUI.Tag");
            this.m_alwaysShowUI.Text = "Always show UI";
            this.m_alwaysShowUI.CheckedChanged += new System.EventHandler(this.AlwaysShowUICheckedChangedEventHandler);
            this.m_alwaysShowUI.MouseHover += new System.EventHandler(this.FocusEventHandler);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(32, 10);
            this.linkLabel1.Location = new System.Drawing.Point(11, 413);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(227, 18);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "http://weblogs.asp.net/kennykerr/";
            this.linkLabel1.Text = "PromptForCredentials created by Kenny Kerr";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClickedEventHandler);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.m_test;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 443);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(msdnLink);
            this.Controls.Add(helpGroup);
            this.Controls.Add(this.flagsGroup);
            this.Controls.Add(this.m_test);
            this.Controls.Add(this.m_copyCppCode);
            this.Controls.Add(this.m_copyCsCode);
            this.Controls.Add(parametersGroup);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "PromptforCredentials Builder";
            this.Enter += new System.EventHandler(this.FocusEventHandler);
            parametersGroup.ResumeLayout(false);
            parametersGroup.PerformLayout();
            helpGroup.ResumeLayout(false);
            helpGroup.PerformLayout();
            this.flagsGroup.ResumeLayout(false);
            this.flagsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_message;
        private System.Windows.Forms.TextBox m_title;
        private System.Windows.Forms.TextBox m_password;
        private System.Windows.Forms.TextBox m_userName;
        private System.Windows.Forms.TextBox m_targetName;
        private System.Windows.Forms.Button m_copyCsCode;
        private System.Windows.Forms.Button m_copyCppCode;
        private System.Windows.Forms.Button m_test;
        private System.Windows.Forms.TextBox m_banner;
        private System.Windows.Forms.Button m_bannerBrowse;
        private System.Windows.Forms.TextBox m_errorCode;
        private System.Windows.Forms.CheckBox m_saveChecked;
        private System.Windows.Forms.GroupBox flagsGroup;
        private System.Windows.Forms.CheckBox m_persist;
        private System.Windows.Forms.CheckBox m_incorrectPassword;
        private System.Windows.Forms.CheckBox m_genericCredentials;
        private System.Windows.Forms.CheckBox m_expectConfirmation;
        private System.Windows.Forms.CheckBox m_excludeCertificates;
        private System.Windows.Forms.CheckBox m_doNotPersist;
        private System.Windows.Forms.CheckBox m_alwaysShowUI;
        private System.Windows.Forms.CheckBox m_showSaveCheckBox;
        private System.Windows.Forms.CheckBox m_requireSmartCard;
        private System.Windows.Forms.CheckBox m_requireCertificate;
        private System.Windows.Forms.CheckBox m_requestAdministrator;
        private System.Windows.Forms.TextBox m_help;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox m_completeUserName;
        private System.Windows.Forms.CheckBox m_userNameReadOnly;
        private System.Windows.Forms.CheckBox m_validateUserName;

    }
}