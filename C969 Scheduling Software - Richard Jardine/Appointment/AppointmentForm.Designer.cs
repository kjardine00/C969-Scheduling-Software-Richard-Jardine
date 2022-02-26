
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
            this.AppointmentUserIDText = new System.Windows.Forms.TextBox();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.AppointmentCustomerPickList = new System.Windows.Forms.ComboBox();
            this.AppointmentCustLabel = new System.Windows.Forms.Label();
            this.AppointmentSaveBtn = new System.Windows.Forms.Button();
            this.AppointmentCancelBtn = new System.Windows.Forms.Button();
            this.AppointmentTypePickList = new System.Windows.Forms.ComboBox();
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
            this.AppointmentTitleLabel.Location = new System.Drawing.Point(14, 70);
            this.AppointmentTitleLabel.Name = "AppointmentTitleLabel";
            this.AppointmentTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.AppointmentTitleLabel.TabIndex = 1;
            this.AppointmentTitleLabel.Text = "Title";
            // 
            // AppointmentTitleText
            // 
            this.AppointmentTitleText.Location = new System.Drawing.Point(71, 67);
            this.AppointmentTitleText.Name = "AppointmentTitleText";
            this.AppointmentTitleText.Size = new System.Drawing.Size(202, 20);
            this.AppointmentTitleText.TabIndex = 2;
            // 
            // AppointmentTypeLabel
            // 
            this.AppointmentTypeLabel.AutoSize = true;
            this.AppointmentTypeLabel.Location = new System.Drawing.Point(14, 149);
            this.AppointmentTypeLabel.Name = "AppointmentTypeLabel";
            this.AppointmentTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.AppointmentTypeLabel.TabIndex = 6;
            this.AppointmentTypeLabel.Text = "Type";
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Location = new System.Drawing.Point(14, 176);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.StartDateTimeLabel.TabIndex = 7;
            this.StartDateTimeLabel.Text = "Start Date/Time";
            // 
            // AppointmentStartDateTimePicker
            // 
            this.AppointmentStartDateTimePicker.CustomFormat = "02/17/2022 17:45";
            this.AppointmentStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentStartDateTimePicker.Location = new System.Drawing.Point(103, 173);
            this.AppointmentStartDateTimePicker.Name = "AppointmentStartDateTimePicker";
            this.AppointmentStartDateTimePicker.Size = new System.Drawing.Size(170, 20);
            this.AppointmentStartDateTimePicker.TabIndex = 8;
            // 
            // AppointmentUserIDText
            // 
            this.AppointmentUserIDText.Location = new System.Drawing.Point(71, 93);
            this.AppointmentUserIDText.Name = "AppointmentUserIDText";
            this.AppointmentUserIDText.Size = new System.Drawing.Size(202, 20);
            this.AppointmentUserIDText.TabIndex = 9;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(14, 96);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(43, 13);
            this.UserIDLabel.TabIndex = 10;
            this.UserIDLabel.Text = "User ID";
            // 
            // AppointmentCustomerPickList
            // 
            this.AppointmentCustomerPickList.FormattingEnabled = true;
            this.AppointmentCustomerPickList.Location = new System.Drawing.Point(71, 119);
            this.AppointmentCustomerPickList.Name = "AppointmentCustomerPickList";
            this.AppointmentCustomerPickList.Size = new System.Drawing.Size(202, 21);
            this.AppointmentCustomerPickList.TabIndex = 11;
            // 
            // AppointmentCustLabel
            // 
            this.AppointmentCustLabel.AutoSize = true;
            this.AppointmentCustLabel.Location = new System.Drawing.Point(14, 122);
            this.AppointmentCustLabel.Name = "AppointmentCustLabel";
            this.AppointmentCustLabel.Size = new System.Drawing.Size(51, 13);
            this.AppointmentCustLabel.TabIndex = 12;
            this.AppointmentCustLabel.Text = "Customer";
            // 
            // AppointmentSaveBtn
            // 
            this.AppointmentSaveBtn.Location = new System.Drawing.Point(17, 235);
            this.AppointmentSaveBtn.Name = "AppointmentSaveBtn";
            this.AppointmentSaveBtn.Size = new System.Drawing.Size(125, 40);
            this.AppointmentSaveBtn.TabIndex = 13;
            this.AppointmentSaveBtn.Text = "Save";
            this.AppointmentSaveBtn.UseVisualStyleBackColor = true;
            this.AppointmentSaveBtn.Click += new System.EventHandler(this.AppointmentSaveBtn_Click);
            // 
            // AppointmentCancelBtn
            // 
            this.AppointmentCancelBtn.Location = new System.Drawing.Point(148, 235);
            this.AppointmentCancelBtn.Name = "AppointmentCancelBtn";
            this.AppointmentCancelBtn.Size = new System.Drawing.Size(125, 40);
            this.AppointmentCancelBtn.TabIndex = 14;
            this.AppointmentCancelBtn.Text = "Cancel";
            this.AppointmentCancelBtn.UseVisualStyleBackColor = true;
            this.AppointmentCancelBtn.Click += new System.EventHandler(this.AppointmentCancelBtn_Click);
            // 
            // AppointmentTypePickList
            // 
            this.AppointmentTypePickList.FormattingEnabled = true;
            this.AppointmentTypePickList.Location = new System.Drawing.Point(71, 146);
            this.AppointmentTypePickList.Name = "AppointmentTypePickList";
            this.AppointmentTypePickList.Size = new System.Drawing.Size(202, 21);
            this.AppointmentTypePickList.TabIndex = 15;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 289);
            this.Controls.Add(this.AppointmentTypePickList);
            this.Controls.Add(this.AppointmentCancelBtn);
            this.Controls.Add(this.AppointmentSaveBtn);
            this.Controls.Add(this.AppointmentCustLabel);
            this.Controls.Add(this.AppointmentCustomerPickList);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.AppointmentUserIDText);
            this.Controls.Add(this.AppointmentStartDateTimePicker);
            this.Controls.Add(this.StartDateTimeLabel);
            this.Controls.Add(this.AppointmentTypeLabel);
            this.Controls.Add(this.AppointmentTitleText);
            this.Controls.Add(this.AppointmentTitleLabel);
            this.Controls.Add(this.AppointmentHeader);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
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
        private System.Windows.Forms.TextBox AppointmentUserIDText;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.ComboBox AppointmentCustomerPickList;
        private System.Windows.Forms.Label AppointmentCustLabel;
        private System.Windows.Forms.Button AppointmentSaveBtn;
        private System.Windows.Forms.Button AppointmentCancelBtn;
        private System.Windows.Forms.ComboBox AppointmentTypePickList;
    }
}