namespace TS3ClientQueryDemo
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxMessage = new System.Windows.Forms.TextBox();
            this.pnlPoke = new System.Windows.Forms.Panel();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.btnSendPoke = new System.Windows.Forms.Button();
            this.txtBoxLog = new System.Windows.Forms.TextBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblNicknameText = new System.Windows.Forms.Label();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblChannelNameText = new System.Windows.Forms.Label();
            this.pnlPoke.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxMessage
            // 
            this.txtBoxMessage.Enabled = false;
            this.txtBoxMessage.Location = new System.Drawing.Point(3, 30);
            this.txtBoxMessage.Multiline = true;
            this.txtBoxMessage.Name = "txtBoxMessage";
            this.txtBoxMessage.Size = new System.Drawing.Size(320, 224);
            this.txtBoxMessage.TabIndex = 0;
            this.txtBoxMessage.Text = "<Test Poke>";
            // 
            // pnlPoke
            // 
            this.pnlPoke.Controls.Add(this.comboBoxClients);
            this.pnlPoke.Controls.Add(this.btnSendPoke);
            this.pnlPoke.Controls.Add(this.txtBoxMessage);
            this.pnlPoke.Enabled = false;
            this.pnlPoke.Location = new System.Drawing.Point(12, 12);
            this.pnlPoke.Name = "pnlPoke";
            this.pnlPoke.Size = new System.Drawing.Size(327, 292);
            this.pnlPoke.TabIndex = 1;
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.Enabled = false;
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(3, 3);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(320, 21);
            this.comboBoxClients.TabIndex = 2;
            // 
            // btnSendPoke
            // 
            this.btnSendPoke.Enabled = false;
            this.btnSendPoke.Location = new System.Drawing.Point(248, 260);
            this.btnSendPoke.Name = "btnSendPoke";
            this.btnSendPoke.Size = new System.Drawing.Size(75, 23);
            this.btnSendPoke.TabIndex = 1;
            this.btnSendPoke.Text = "Send Poke";
            this.btnSendPoke.UseVisualStyleBackColor = true;
            this.btnSendPoke.Click += new System.EventHandler(this.btnSendPoke_Click);
            // 
            // txtBoxLog
            // 
            this.txtBoxLog.Location = new System.Drawing.Point(345, 12);
            this.txtBoxLog.Multiline = true;
            this.txtBoxLog.Name = "txtBoxLog";
            this.txtBoxLog.ReadOnly = true;
            this.txtBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxLog.Size = new System.Drawing.Size(354, 292);
            this.txtBoxLog.TabIndex = 2;
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.lblChannelNameText);
            this.pnlStats.Controls.Add(this.lblChannelName);
            this.pnlStats.Controls.Add(this.lblNicknameText);
            this.pnlStats.Controls.Add(this.lblNickname);
            this.pnlStats.Location = new System.Drawing.Point(12, 310);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(687, 51);
            this.pnlStats.TabIndex = 3;
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(13, 11);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(58, 13);
            this.lblNickname.TabIndex = 0;
            this.lblNickname.Text = "Nickname:";
            // 
            // lblNicknameText
            // 
            this.lblNicknameText.AutoSize = true;
            this.lblNicknameText.Location = new System.Drawing.Point(77, 11);
            this.lblNicknameText.Name = "lblNicknameText";
            this.lblNicknameText.Size = new System.Drawing.Size(27, 13);
            this.lblNicknameText.TabIndex = 1;
            this.lblNicknameText.Text = "N/A";
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Location = new System.Drawing.Point(330, 11);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(77, 13);
            this.lblChannelName.TabIndex = 2;
            this.lblChannelName.Text = "ChannelName:";
            // 
            // lblChannelNameText
            // 
            this.lblChannelNameText.AutoSize = true;
            this.lblChannelNameText.Location = new System.Drawing.Point(413, 11);
            this.lblChannelNameText.Name = "lblChannelNameText";
            this.lblChannelNameText.Size = new System.Drawing.Size(27, 13);
            this.lblChannelNameText.TabIndex = 3;
            this.lblChannelNameText.Text = "N/A";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 373);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.txtBoxLog);
            this.Controls.Add(this.pnlPoke);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "TS3ClientQueryDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.pnlPoke.ResumeLayout(false);
            this.pnlPoke.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMessage;
        private System.Windows.Forms.Panel pnlPoke;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.Button btnSendPoke;
        private System.Windows.Forms.TextBox txtBoxLog;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblChannelNameText;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.Label lblNicknameText;
        private System.Windows.Forms.Label lblNickname;
    }
}

