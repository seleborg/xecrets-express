namespace Kerr.CredentialSetManager
{
    partial class EditCredentialDialog
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
            System.Windows.Forms.Label targetNameLabel;
            System.Windows.Forms.GroupBox typeGroupBox;
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Button cancel;
            System.Windows.Forms.GroupBox persistenceGroupBox;
            this.m_typeGeneric = new System.Windows.Forms.RadioButton();
            this.m_typeDomainVisiblePassword = new System.Windows.Forms.RadioButton();
            this.m_typeDomainPassword = new System.Windows.Forms.RadioButton();
            this.m_typeDomainCertificate = new System.Windows.Forms.RadioButton();
            this.m_persistenceEnterprise = new System.Windows.Forms.RadioButton();
            this.m_persistenceLocalComputer = new System.Windows.Forms.RadioButton();
            this.m_persistenceSession = new System.Windows.Forms.RadioButton();
            this.m_targetName = new System.Windows.Forms.TextBox();
            this.m_userName = new System.Windows.Forms.TextBox();
            this.m_password = new System.Windows.Forms.TextBox();
            this.m_description = new System.Windows.Forms.TextBox();
            this.m_ok = new System.Windows.Forms.Button();
            targetNameLabel = new System.Windows.Forms.Label();
            typeGroupBox = new System.Windows.Forms.GroupBox();
            userNameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            cancel = new System.Windows.Forms.Button();
            persistenceGroupBox = new System.Windows.Forms.GroupBox();
            typeGroupBox.SuspendLayout();
            persistenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetNameLabel
            // 
            targetNameLabel.AutoSize = true;
            targetNameLabel.Location = new System.Drawing.Point(12, 15);
            targetNameLabel.Name = "targetNameLabel";
            targetNameLabel.Size = new System.Drawing.Size(68, 13);
            targetNameLabel.TabIndex = 0;
            targetNameLabel.Text = "Target name:";
            // 
            // typeGroupBox
            // 
            typeGroupBox.Controls.Add(this.m_typeGeneric);
            typeGroupBox.Controls.Add(this.m_typeDomainVisiblePassword);
            typeGroupBox.Controls.Add(this.m_typeDomainPassword);
            typeGroupBox.Controls.Add(this.m_typeDomainCertificate);
            typeGroupBox.Location = new System.Drawing.Point(13, 50);
            typeGroupBox.Name = "typeGroupBox";
            typeGroupBox.Size = new System.Drawing.Size(202, 129);
            typeGroupBox.TabIndex = 2;
            typeGroupBox.TabStop = false;
            typeGroupBox.Text = "Type of credential";
            // 
            // m_typeGeneric
            // 
            this.m_typeGeneric.Checked = true;
            this.m_typeGeneric.Enabled = false;
            this.m_typeGeneric.Location = new System.Drawing.Point(16, 27);
            this.m_typeGeneric.Name = "m_typeGeneric";
            this.m_typeGeneric.Size = new System.Drawing.Size(150, 17);
            this.m_typeGeneric.TabIndex = 0;
            this.m_typeGeneric.Tag = "";
            this.m_typeGeneric.Text = "Generic";
            // 
            // m_typeDomainVisiblePassword
            // 
            this.m_typeDomainVisiblePassword.Enabled = false;
            this.m_typeDomainVisiblePassword.Location = new System.Drawing.Point(16, 73);
            this.m_typeDomainVisiblePassword.Name = "m_typeDomainVisiblePassword";
            this.m_typeDomainVisiblePassword.Size = new System.Drawing.Size(150, 17);
            this.m_typeDomainVisiblePassword.TabIndex = 2;
            this.m_typeDomainVisiblePassword.Tag = "";
            this.m_typeDomainVisiblePassword.Text = "Domain Visible Password";
            // 
            // m_typeDomainPassword
            // 
            this.m_typeDomainPassword.Enabled = false;
            this.m_typeDomainPassword.Location = new System.Drawing.Point(16, 50);
            this.m_typeDomainPassword.Name = "m_typeDomainPassword";
            this.m_typeDomainPassword.Size = new System.Drawing.Size(150, 17);
            this.m_typeDomainPassword.TabIndex = 1;
            this.m_typeDomainPassword.Tag = "";
            this.m_typeDomainPassword.Text = "Domain Password";
            // 
            // m_typeDomainCertificate
            // 
            this.m_typeDomainCertificate.Enabled = false;
            this.m_typeDomainCertificate.Location = new System.Drawing.Point(16, 96);
            this.m_typeDomainCertificate.Name = "m_typeDomainCertificate";
            this.m_typeDomainCertificate.Size = new System.Drawing.Size(150, 17);
            this.m_typeDomainCertificate.TabIndex = 3;
            this.m_typeDomainCertificate.Tag = "";
            this.m_typeDomainCertificate.Text = "Domain Certificate";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(12, 204);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(58, 13);
            userNameLabel.TabIndex = 4;
            userNameLabel.Text = "User name:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(12, 231);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(53, 13);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Password:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(12, 268);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(60, 13);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Description:";
            // 
            // cancel
            // 
            cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancel.Location = new System.Drawing.Point(330, 328);
            cancel.Name = "cancel";
            cancel.Size = new System.Drawing.Size(75, 23);
            cancel.TabIndex = 11;
            cancel.Text = "Cancel";
            // 
            // persistenceGroupBox
            // 
            persistenceGroupBox.Controls.Add(this.m_persistenceEnterprise);
            persistenceGroupBox.Controls.Add(this.m_persistenceLocalComputer);
            persistenceGroupBox.Controls.Add(this.m_persistenceSession);
            persistenceGroupBox.Location = new System.Drawing.Point(221, 50);
            persistenceGroupBox.Name = "persistenceGroupBox";
            persistenceGroupBox.Size = new System.Drawing.Size(184, 129);
            persistenceGroupBox.TabIndex = 3;
            persistenceGroupBox.TabStop = false;
            persistenceGroupBox.Text = "Persistence";
            // 
            // m_persistenceEnterprise
            // 
            this.m_persistenceEnterprise.Location = new System.Drawing.Point(16, 73);
            this.m_persistenceEnterprise.Name = "m_persistenceEnterprise";
            this.m_persistenceEnterprise.Size = new System.Drawing.Size(125, 17);
            this.m_persistenceEnterprise.TabIndex = 2;
            this.m_persistenceEnterprise.TabStop = false;
            this.m_persistenceEnterprise.Text = "Enterprise";
            // 
            // m_persistenceLocalComputer
            // 
            this.m_persistenceLocalComputer.Checked = true;
            this.m_persistenceLocalComputer.Location = new System.Drawing.Point(16, 50);
            this.m_persistenceLocalComputer.Name = "m_persistenceLocalComputer";
            this.m_persistenceLocalComputer.Size = new System.Drawing.Size(125, 17);
            this.m_persistenceLocalComputer.TabIndex = 1;
            this.m_persistenceLocalComputer.Text = "Local Computer";
            // 
            // m_persistenceSession
            // 
            this.m_persistenceSession.Location = new System.Drawing.Point(16, 27);
            this.m_persistenceSession.Name = "m_persistenceSession";
            this.m_persistenceSession.Size = new System.Drawing.Size(125, 17);
            this.m_persistenceSession.TabIndex = 0;
            this.m_persistenceSession.TabStop = false;
            this.m_persistenceSession.Text = "Session";
            // 
            // m_targetName
            // 
            this.m_targetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_targetName.Location = new System.Drawing.Point(86, 12);
            this.m_targetName.Name = "m_targetName";
            this.m_targetName.ReadOnly = true;
            this.m_targetName.Size = new System.Drawing.Size(319, 21);
            this.m_targetName.TabIndex = 1;
            this.m_targetName.TabStop = false;
            // 
            // m_userName
            // 
            this.m_userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_userName.Location = new System.Drawing.Point(86, 201);
            this.m_userName.Name = "m_userName";
            this.m_userName.Size = new System.Drawing.Size(319, 21);
            this.m_userName.TabIndex = 5;
            // 
            // m_password
            // 
            this.m_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_password.Location = new System.Drawing.Point(86, 228);
            this.m_password.Name = "m_password";
            this.m_password.Size = new System.Drawing.Size(319, 21);
            this.m_password.TabIndex = 7;
            // 
            // m_description
            // 
            this.m_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_description.Location = new System.Drawing.Point(86, 265);
            this.m_description.Multiline = true;
            this.m_description.Name = "m_description";
            this.m_description.Size = new System.Drawing.Size(319, 43);
            this.m_description.TabIndex = 9;
            // 
            // m_ok
            // 
            this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ok.Location = new System.Drawing.Point(249, 328);
            this.m_ok.Name = "m_ok";
            this.m_ok.Size = new System.Drawing.Size(75, 23);
            this.m_ok.TabIndex = 10;
            this.m_ok.Text = "OK";
            this.m_ok.Click += new System.EventHandler(this.OkEventHandler);
            // 
            // EditCredentialDialog
            // 
            this.AcceptButton = this.m_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = cancel;
            this.ClientSize = new System.Drawing.Size(417, 363);
            this.Controls.Add(persistenceGroupBox);
            this.Controls.Add(this.m_ok);
            this.Controls.Add(cancel);
            this.Controls.Add(this.m_description);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.m_password);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.m_userName);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(typeGroupBox);
            this.Controls.Add(this.m_targetName);
            this.Controls.Add(targetNameLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCredentialDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Credential";
            typeGroupBox.ResumeLayout(false);
            persistenceGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_targetName;
        private System.Windows.Forms.RadioButton m_typeGeneric;
        private System.Windows.Forms.RadioButton m_typeDomainPassword;
        private System.Windows.Forms.RadioButton m_typeDomainCertificate;
        private System.Windows.Forms.RadioButton m_typeDomainVisiblePassword;
        private System.Windows.Forms.TextBox m_userName;
        private System.Windows.Forms.TextBox m_password;
        private System.Windows.Forms.TextBox m_description;
        private System.Windows.Forms.Button m_ok;
        private System.Windows.Forms.RadioButton m_persistenceSession;
        private System.Windows.Forms.RadioButton m_persistenceEnterprise;
        private System.Windows.Forms.RadioButton m_persistenceLocalComputer;
    }
}