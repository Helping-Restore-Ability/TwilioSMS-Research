namespace TwilioSMS
{
    partial class TwilioSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwilioSMS));
            this.SendBtn = new System.Windows.Forms.Button();
            this.RecipientsDGV = new System.Windows.Forms.DataGridView();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecipientsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageBody = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RecipientsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(13, 352);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(349, 23);
            this.SendBtn.TabIndex = 3;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // RecipientsDGV
            // 
            this.RecipientsDGV.AllowDrop = true;
            this.RecipientsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecipientsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Phone});
            this.RecipientsDGV.Location = new System.Drawing.Point(81, 23);
            this.RecipientsDGV.Name = "RecipientsDGV";
            this.RecipientsDGV.Size = new System.Drawing.Size(281, 150);
            this.RecipientsDGV.TabIndex = 1;
            this.RecipientsDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecipientsDGV_KeyDown);
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // RecipientsBtn
            // 
            this.RecipientsBtn.Location = new System.Drawing.Point(12, 23);
            this.RecipientsBtn.Name = "RecipientsBtn";
            this.RecipientsBtn.Size = new System.Drawing.Size(72, 150);
            this.RecipientsBtn.TabIndex = 0;
            this.RecipientsBtn.Text = "Add Recipients";
            this.RecipientsBtn.UseVisualStyleBackColor = true;
            this.RecipientsBtn.Click += new System.EventHandler(this.RecipientsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Message Body";
            // 
            // MessageBody
            // 
            this.MessageBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageBody.Location = new System.Drawing.Point(12, 194);
            this.MessageBody.Name = "MessageBody";
            this.MessageBody.Size = new System.Drawing.Size(350, 152);
            this.MessageBody.TabIndex = 5;
            this.MessageBody.Text = "";
            // 
            // TwilioSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 388);
            this.Controls.Add(this.MessageBody);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RecipientsBtn);
            this.Controls.Add(this.RecipientsDGV);
            this.Controls.Add(this.SendBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwilioSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twilio SMS";
            this.Load += new System.EventHandler(this.TwilioSMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RecipientsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.DataGridView RecipientsDGV;
        private System.Windows.Forms.Button RecipientsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        internal System.Windows.Forms.RichTextBox MessageBody;
    }
}

