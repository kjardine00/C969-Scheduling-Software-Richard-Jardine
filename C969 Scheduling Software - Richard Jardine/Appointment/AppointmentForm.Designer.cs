
namespace C969_Scheduling_Software___Richard_Jardine
{
    partial class AppointmentForm
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
            this.AppointmentHeader = new System.Windows.Forms.Label();
            this.AppointmentTitleLabel = new System.Windows.Forms.Label();
            this.AppointmentTitleText = new System.Windows.Forms.TextBox();
            this.AppointmentTypeLabel = new System.Windows.Forms.Label();
            this.StartDateTimeLabel = new System.Windows.Forms.Label();
            this.AppointmentStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.AppointmentCustomerPickList = new System.Windows.Forms.ComboBox();
            this.AppointmentCustLabel = new System.Windows.Forms.Label();
            this.AppointmentSaveBtn = new System.Windows.Forms.Button();
            this.AppointmentCancelBtn = new System.Windows.Forms.Button();
            this.AppointmentEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.AppointmentIdText = new System.Windows.Forms.TextBox();
            this.AppointmentIdLabel = new System.Windows.Forms.Label();
            this.AppointmentTypeText = new System.Windows.Forms.TextBox();
            this.AppointmentUserIDPickList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AppointmentHeader
            // 
            this.AppointmentHeader.AutoSize = true;
            this.AppointmentHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AppointmentHeader.Location = new System.Drawing.Point(13, 13);
            this.AppointmentHeader.Name = "AppointmentHeader";
            this.AppointmentHeader.Size = new System.Drawing.Size(182, 24);
            this.AppointmentHeader.TabIndex = 0;
            this.AppointmentHeader.Text = "Update Appointment";
            // 
            // AppointmentTitleLabel
            // 
            this.AppointmentTitleLabel.AutoSize = true;
            this.AppointmentTitleLabel.Location = new System.Drawing.Point(14, 86);
            this.AppointmentTitleLabel.Name = "AppointmentTitleLabel";
            this.AppointmentTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.AppointmentTitleLabel.TabIndex = 1;
            this.AppointmentTitleLabel.Text = "Title";
            // 
            // AppointmentTitleText
            // 
            this.AppointmentTitleText.Location = new System.Drawing.Point(71, 83);
            this.AppointmentTitleText.Name = "AppointmentTitleText";
            this.AppointmentTitleText.Size = new System.Drawing.Size(281, 20);
            this.AppointmentTitleText.TabIndex = 2;
            // 
            // AppointmentTypeLabel
            // 
            this.AppointmentTypeLabel.AutoSize = true;
            this.AppointmentTypeLabel.Location = new System.Drawing.Point(14, 165);
            this.AppointmentTypeLabel.Name = "AppointmentTypeLabel";
            this.AppointmentTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.AppointmentTypeLabel.TabIndex = 6;
            this.AppointmentTypeLabel.Text = "Type";
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Location = new System.Drawing.Point(14, 192);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.StartDateTimeLabel.TabIndex = 7;
            this.StartDateTimeLabel.Text = "Start Date/Time";
            // 
            // AppointmentStartDateTimePicker
            // 
            this.AppointmentStartDateTimePicker.AllowDrop = true;
            this.AppointmentStartDateTimePicker.CustomFormat = "MMMMd, yyyy H:mm ";
            this.AppointmentStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentStartDateTimePicker.Location = new System.Drawing.Point(103, 189);
            this.AppointmentStartDateTimePicker.Name = "AppointmentStartDateTimePicker";
            this.AppointmentStartDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.AppointmentStartDateTimePicker.TabIndex = 8;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(14, 112);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(43, 13);
            this.UserIDLabel.TabIndex = 10;
            this.UserIDLabel.Text = "User ID";
            // 
            // AppointmentCustomerPickList
            // 
            this.AppointmentCustomerPickList.FormattingEnabled = true;
            this.AppointmentCustomerPickList.Location = new System.Drawing.Point(71, 135);
            this.AppointmentCustomerPickList.Name = "AppointmentCustomerPickList";
            this.AppointmentCustomerPickList.Size = new System.Drawing.Size(281, 21);
            this.AppointmentCustomerPickList.TabIndex = 11;
            // 
            // AppointmentCustLabel
            // 
            this.AppointmentCustLabel.AutoSize = true;
            this.AppointmentCustLabel.Location = new System.Drawing.Point(14, 138);
            this.AppointmentCustLabel.Name = "AppointmentCustLabel";
            this.AppointmentCustLabel.Size = new System.Drawing.Size(51, 13);
            this.AppointmentCustLabel.TabIndex = 12;
            this.AppointmentCustLabel.Text = "Customer";
            // 
            // AppointmentSaveBtn
            // 
            this.AppointmentSaveBtn.Location = new System.Drawing.Point(96, 308);
            this.AppointmentSaveBtn.Name = "AppointmentSaveBtn";
            this.AppointmentSaveBtn.Size = new System.Drawing.Size(125, 40);
            this.AppointmentSaveBtn.TabIndex = 13;
            this.AppointmentSaveBtn.Text = "Save";
            this.AppointmentSaveBtn.UseVisualStyleBackColor = true;
            this.AppointmentSaveBtn.Click += new System.EventHandler(this.AppointmentSaveBtn_Click);
            // 
            // AppointmentCancelBtn
            // 
            this.AppointmentCancelBtn.Location = new System.Drawing.Point(227, 308);
            this.AppointmentCancelBtn.Name = "AppointmentCancelBtn";
            this.AppointmentCancelBtn.Size = new System.Drawing.Size(125, 40);
            this.AppointmentCancelBtn.TabIndex = 14;
            this.AppointmentCancelBtn.Text = "Cancel";
            this.AppointmentCancelBtn.UseVisualStyleBackColor = true;
            this.AppointmentCancelBtn.Click += new System.EventHandler(this.AppointmentCancelBtn_Click);
            // 
            // AppointmentEndDateTimePicker
            // 
            this.AppointmentEndDateTimePicker.CustomFormat = "MMMMd, yyyy H:mm ";
            this.AppointmentEndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentEndDateTimePicker.Location = new System.Drawing.Point(103, 215);
            this.AppointmentEndDateTimePicker.Name = "AppointmentEndDateTimePicker";
            this.AppointmentEndDateTimePicker.Size = new System.Drawing.Size(249, 20);
            this.AppointmentEndDateTimePicker.TabIndex = 17;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(14, 221);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(80, 13);
            this.DateTimeLabel.TabIndex = 16;
            this.DateTimeLabel.Text = "End Date/Time";
            // 
            // AppointmentIdText
            // 
            this.AppointmentIdText.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AppointmentIdText.Location = new System.Drawing.Point(71, 57);
            this.AppointmentIdText.Name = "AppointmentIdText";
            this.AppointmentIdText.ReadOnly = true;
            this.AppointmentIdText.Size = new System.Drawing.Size(281, 20);
            this.AppointmentIdText.TabIndex = 19;
            // 
            // AppointmentIdLabel
            // 
            this.AppointmentIdLabel.AutoSize = true;
            this.AppointmentIdLabel.Location = new System.Drawing.Point(14, 60);
            this.AppointmentIdLabel.Name = "AppointmentIdLabel";
            this.AppointmentIdLabel.Size = new System.Drawing.Size(18, 13);
            this.AppointmentIdLabel.TabIndex = 20;
            this.AppointmentIdLabel.Text = "ID";
            // 
            // AppointmentTypeText
            // 
            this.AppointmentTypeText.Location = new System.Drawing.Point(71, 162);
            this.AppointmentTypeText.Name = "AppointmentTypeText";
            this.AppointmentTypeText.Size = new System.Drawing.Size(281, 20);
            this.AppointmentTypeText.TabIndex = 18;
            // 
            // AppointmentUserIDPickList
            // 
            this.AppointmentUserIDPickList.FormattingEnabled = true;
            this.AppointmentUserIDPickList.Location = new System.Drawing.Point(71, 109);
            this.AppointmentUserIDPickList.Name = "AppointmentUserIDPickList";
            this.AppointmentUserIDPickList.Size = new System.Drawing.Size(281, 21);
            this.AppointmentUserIDPickList.TabIndex = 21;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 360);
            this.Controls.Add(this.AppointmentUserIDPickList);
            this.Controls.Add(this.AppointmentIdLabel);
            this.Controls.Add(this.AppointmentIdText);
            this.Controls.Add(this.AppointmentTypeText);
            this.Controls.Add(this.AppointmentEndDateTimePicker);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.AppointmentCancelBtn);
            this.Controls.Add(this.AppointmentSaveBtn);
            this.Controls.Add(this.AppointmentCustLabel);
            this.Controls.Add(this.AppointmentCustomerPickList);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.AppointmentStartDateTimePicker);
            this.Controls.Add(this.StartDateTimeLabel);
            this.Controls.Add(this.AppointmentTypeLabel);
            this.Controls.Add(this.AppointmentTitleText);
            this.Controls.Add(this.AppointmentTitleLabel);
            this.Controls.Add(this.AppointmentHeader);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppointmentHeader;
        private System.Windows.Forms.Label AppointmentTitleLabel;
        private System.Windows.Forms.TextBox AppointmentTitleText;
        private System.Windows.Forms.Label AppointmentTypeLabel;
        private System.Windows.Forms.Label StartDateTimeLabel;
        private System.Windows.Forms.DateTimePicker AppointmentStartDateTimePicker;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.ComboBox AppointmentCustomerPickList;
        private System.Windows.Forms.Label AppointmentCustLabel;
        private System.Windows.Forms.Button AppointmentSaveBtn;
        private System.Windows.Forms.Button AppointmentCancelBtn;
        private System.Windows.Forms.DateTimePicker AppointmentEndDateTimePicker;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TextBox AppointmentIdText;
        private System.Windows.Forms.Label AppointmentIdLabel;
        private System.Windows.Forms.TextBox AppointmentTypeText;
        private System.Windows.Forms.ComboBox AppointmentUserIDPickList;
    }
}