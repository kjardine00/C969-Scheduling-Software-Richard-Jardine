
namespace C969_Scheduling_Software___Richard_Jardine
{
    partial class Dashboard
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
            this.ReportsTab = new System.Windows.Forms.TabControl();
            this.CustomerTab = new System.Windows.Forms.TabPage();
            this.DeleteCustBtn = new System.Windows.Forms.Button();
            this.UpdateCustBtn = new System.Windows.Forms.Button();
            this.AddNewCustBtn = new System.Windows.Forms.Button();
            this.CustomerDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentTab = new System.Windows.Forms.TabPage();
            this.DeleteAppointmentBtn = new System.Windows.Forms.Button();
            this.UpdateAppointmentBtn = new System.Windows.Forms.Button();
            this.AddNewAppointmentBtn = new System.Windows.Forms.Button();
            this.ByMonthRadio = new System.Windows.Forms.RadioButton();
            this.ByWeekRadio = new System.Windows.Forms.RadioButton();
            this.AppointmenttDGV = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GenerateReportBtn = new System.Windows.Forms.Button();
            this.ReportsDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.AppointmentsByTypeRadio = new System.Windows.Forms.RadioButton();
            this.ConsultantSchedulesRadio = new System.Windows.Forms.RadioButton();
            this.CustomerCountRadio = new System.Windows.Forms.RadioButton();
            this.AllAppointmentsRadio = new System.Windows.Forms.RadioButton();
            this.ReportsTab.SuspendLayout();
            this.CustomerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).BeginInit();
            this.AppointmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmenttDGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportsTab
            // 
            this.ReportsTab.Controls.Add(this.CustomerTab);
            this.ReportsTab.Controls.Add(this.AppointmentTab);
            this.ReportsTab.Controls.Add(this.tabPage3);
            this.ReportsTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReportsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ReportsTab.Location = new System.Drawing.Point(0, 52);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.SelectedIndex = 0;
            this.ReportsTab.Size = new System.Drawing.Size(874, 470);
            this.ReportsTab.TabIndex = 0;
            // 
            // CustomerTab
            // 
            this.CustomerTab.Controls.Add(this.DeleteCustBtn);
            this.CustomerTab.Controls.Add(this.UpdateCustBtn);
            this.CustomerTab.Controls.Add(this.AddNewCustBtn);
            this.CustomerTab.Controls.Add(this.CustomerDGV);
            this.CustomerTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CustomerTab.Location = new System.Drawing.Point(4, 27);
            this.CustomerTab.Name = "CustomerTab";
            this.CustomerTab.Padding = new System.Windows.Forms.Padding(3);
            this.CustomerTab.Size = new System.Drawing.Size(866, 439);
            this.CustomerTab.TabIndex = 0;
            this.CustomerTab.Text = "Customers";
            this.CustomerTab.UseVisualStyleBackColor = true;
            // 
            // DeleteCustBtn
            // 
            this.DeleteCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DeleteCustBtn.Location = new System.Drawing.Point(269, 381);
            this.DeleteCustBtn.Name = "DeleteCustBtn";
            this.DeleteCustBtn.Size = new System.Drawing.Size(125, 40);
            this.DeleteCustBtn.TabIndex = 3;
            this.DeleteCustBtn.Text = "Delete Selected";
            this.DeleteCustBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateCustBtn
            // 
            this.UpdateCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpdateCustBtn.Location = new System.Drawing.Point(141, 381);
            this.UpdateCustBtn.Name = "UpdateCustBtn";
            this.UpdateCustBtn.Size = new System.Drawing.Size(125, 40);
            this.UpdateCustBtn.TabIndex = 2;
            this.UpdateCustBtn.Text = "Update Selected";
            this.UpdateCustBtn.UseVisualStyleBackColor = true;
            // 
            // AddNewCustBtn
            // 
            this.AddNewCustBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddNewCustBtn.Location = new System.Drawing.Point(13, 381);
            this.AddNewCustBtn.Name = "AddNewCustBtn";
            this.AddNewCustBtn.Size = new System.Drawing.Size(125, 40);
            this.AddNewCustBtn.TabIndex = 1;
            this.AddNewCustBtn.Text = "Add New";
            this.AddNewCustBtn.UseVisualStyleBackColor = true;
            // 
            // CustomerDGV
            // 
            this.CustomerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomerDGV.Location = new System.Drawing.Point(3, 3);
            this.CustomerDGV.Name = "CustomerDGV";
            this.CustomerDGV.Size = new System.Drawing.Size(860, 344);
            this.CustomerDGV.TabIndex = 0;
            // 
            // AppointmentTab
            // 
            this.AppointmentTab.Controls.Add(this.AllAppointmentsRadio);
            this.AppointmentTab.Controls.Add(this.DeleteAppointmentBtn);
            this.AppointmentTab.Controls.Add(this.UpdateAppointmentBtn);
            this.AppointmentTab.Controls.Add(this.AddNewAppointmentBtn);
            this.AppointmentTab.Controls.Add(this.ByMonthRadio);
            this.AppointmentTab.Controls.Add(this.ByWeekRadio);
            this.AppointmentTab.Controls.Add(this.AppointmenttDGV);
            this.AppointmentTab.Location = new System.Drawing.Point(4, 27);
            this.AppointmentTab.Name = "AppointmentTab";
            this.AppointmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.AppointmentTab.Size = new System.Drawing.Size(866, 439);
            this.AppointmentTab.TabIndex = 1;
            this.AppointmentTab.Text = "Appointments";
            this.AppointmentTab.UseVisualStyleBackColor = true;
            this.AppointmentTab.Click += new System.EventHandler(this.AppointmentTab_Click);
            // 
            // DeleteAppointmentBtn
            // 
            this.DeleteAppointmentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DeleteAppointmentBtn.Location = new System.Drawing.Point(269, 381);
            this.DeleteAppointmentBtn.Name = "DeleteAppointmentBtn";
            this.DeleteAppointmentBtn.Size = new System.Drawing.Size(125, 40);
            this.DeleteAppointmentBtn.TabIndex = 5;
            this.DeleteAppointmentBtn.Text = "Delete Selected";
            this.DeleteAppointmentBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateAppointmentBtn
            // 
            this.UpdateAppointmentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpdateAppointmentBtn.Location = new System.Drawing.Point(141, 381);
            this.UpdateAppointmentBtn.Name = "UpdateAppointmentBtn";
            this.UpdateAppointmentBtn.Size = new System.Drawing.Size(125, 40);
            this.UpdateAppointmentBtn.TabIndex = 4;
            this.UpdateAppointmentBtn.Text = "Update Selected";
            this.UpdateAppointmentBtn.UseVisualStyleBackColor = true;
            // 
            // AddNewAppointmentBtn
            // 
            this.AddNewAppointmentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddNewAppointmentBtn.Location = new System.Drawing.Point(13, 381);
            this.AddNewAppointmentBtn.Name = "AddNewAppointmentBtn";
            this.AddNewAppointmentBtn.Size = new System.Drawing.Size(125, 40);
            this.AddNewAppointmentBtn.TabIndex = 3;
            this.AddNewAppointmentBtn.Text = "Add New";
            this.AddNewAppointmentBtn.UseVisualStyleBackColor = true;
            // 
            // ByMonthRadio
            // 
            this.ByMonthRadio.AutoSize = true;
            this.ByMonthRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ByMonthRadio.Location = new System.Drawing.Point(249, 353);
            this.ByMonthRadio.Name = "ByMonthRadio";
            this.ByMonthRadio.Size = new System.Drawing.Size(96, 21);
            this.ByMonthRadio.TabIndex = 2;
            this.ByMonthRadio.TabStop = true;
            this.ByMonthRadio.Text = "This Month";
            this.ByMonthRadio.UseVisualStyleBackColor = true;
            this.ByMonthRadio.CheckedChanged += new System.EventHandler(this.ByMonthRadio_CheckedChanged);
            // 
            // ByWeekRadio
            // 
            this.ByWeekRadio.AutoSize = true;
            this.ByWeekRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ByWeekRadio.Location = new System.Drawing.Point(150, 354);
            this.ByWeekRadio.Name = "ByWeekRadio";
            this.ByWeekRadio.Size = new System.Drawing.Size(93, 21);
            this.ByWeekRadio.TabIndex = 1;
            this.ByWeekRadio.TabStop = true;
            this.ByWeekRadio.Text = "This Week";
            this.ByWeekRadio.UseVisualStyleBackColor = true;
            // 
            // AppointmenttDGV
            // 
            this.AppointmenttDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmenttDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.AppointmenttDGV.Location = new System.Drawing.Point(3, 3);
            this.AppointmenttDGV.Name = "AppointmenttDGV";
            this.AppointmenttDGV.Size = new System.Drawing.Size(860, 344);
            this.AppointmenttDGV.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CustomerCountRadio);
            this.tabPage3.Controls.Add(this.ConsultantSchedulesRadio);
            this.tabPage3.Controls.Add(this.AppointmentsByTypeRadio);
            this.tabPage3.Controls.Add(this.GenerateReportBtn);
            this.tabPage3.Controls.Add(this.ReportsDGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(866, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GenerateReportBtn
            // 
            this.GenerateReportBtn.Location = new System.Drawing.Point(704, 380);
            this.GenerateReportBtn.Name = "GenerateReportBtn";
            this.GenerateReportBtn.Size = new System.Drawing.Size(142, 40);
            this.GenerateReportBtn.TabIndex = 1;
            this.GenerateReportBtn.Text = "Generate Report";
            this.GenerateReportBtn.UseVisualStyleBackColor = true;
            // 
            // ReportsDGV
            // 
            this.ReportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportsDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReportsDGV.Location = new System.Drawing.Point(3, 3);
            this.ReportsDGV.Name = "ReportsDGV";
            this.ReportsDGV.Size = new System.Drawing.Size(860, 344);
            this.ReportsDGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scheduler Assistant Dashboard";
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LogOutBtn.Location = new System.Drawing.Point(774, 12);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(88, 26);
            this.LogOutBtn.TabIndex = 2;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // AppointmentsByTypeRadio
            // 
            this.AppointmentsByTypeRadio.AutoSize = true;
            this.AppointmentsByTypeRadio.Location = new System.Drawing.Point(11, 370);
            this.AppointmentsByTypeRadio.Name = "AppointmentsByTypeRadio";
            this.AppointmentsByTypeRadio.Size = new System.Drawing.Size(245, 22);
            this.AppointmentsByTypeRadio.TabIndex = 2;
            this.AppointmentsByTypeRadio.TabStop = true;
            this.AppointmentsByTypeRadio.Text = "Number of Appointments by Type";
            this.AppointmentsByTypeRadio.UseVisualStyleBackColor = true;
            // 
            // ConsultantSchedulesRadio
            // 
            this.ConsultantSchedulesRadio.AutoSize = true;
            this.ConsultantSchedulesRadio.Location = new System.Drawing.Point(11, 398);
            this.ConsultantSchedulesRadio.Name = "ConsultantSchedulesRadio";
            this.ConsultantSchedulesRadio.Size = new System.Drawing.Size(170, 22);
            this.ConsultantSchedulesRadio.TabIndex = 3;
            this.ConsultantSchedulesRadio.TabStop = true;
            this.ConsultantSchedulesRadio.Text = "Consultant Schedules";
            this.ConsultantSchedulesRadio.UseVisualStyleBackColor = true;
            // 
            // CustomerCountRadio
            // 
            this.CustomerCountRadio.AutoSize = true;
            this.CustomerCountRadio.Location = new System.Drawing.Point(272, 370);
            this.CustomerCountRadio.Name = "CustomerCountRadio";
            this.CustomerCountRadio.Size = new System.Drawing.Size(136, 22);
            this.CustomerCountRadio.TabIndex = 4;
            this.CustomerCountRadio.TabStop = true;
            this.CustomerCountRadio.Text = "Customer Count";
            this.CustomerCountRadio.UseVisualStyleBackColor = true;
            // 
            // AllAppointmentsRadio
            // 
            this.AllAppointmentsRadio.AutoSize = true;
            this.AllAppointmentsRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AllAppointmentsRadio.Location = new System.Drawing.Point(13, 353);
            this.AllAppointmentsRadio.Name = "AllAppointmentsRadio";
            this.AllAppointmentsRadio.Size = new System.Drawing.Size(131, 21);
            this.AllAppointmentsRadio.TabIndex = 6;
            this.AllAppointmentsRadio.TabStop = true;
            this.AllAppointmentsRadio.Text = "All Appointments";
            this.AllAppointmentsRadio.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 522);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReportsTab);
            this.Name = "Dashboard";
            this.Text = "Scheduler Assistant - Dashboard";
            this.ReportsTab.ResumeLayout(false);
            this.CustomerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).EndInit();
            this.AppointmentTab.ResumeLayout(false);
            this.AppointmentTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmenttDGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ReportsTab;
        private System.Windows.Forms.TabPage CustomerTab;
        private System.Windows.Forms.TabPage AppointmentTab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView CustomerDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteCustBtn;
        private System.Windows.Forms.Button UpdateCustBtn;
        private System.Windows.Forms.Button AddNewCustBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button DeleteAppointmentBtn;
        private System.Windows.Forms.Button UpdateAppointmentBtn;
        private System.Windows.Forms.Button AddNewAppointmentBtn;
        private System.Windows.Forms.RadioButton ByMonthRadio;
        private System.Windows.Forms.RadioButton ByWeekRadio;
        private System.Windows.Forms.DataGridView AppointmenttDGV;
        private System.Windows.Forms.Button GenerateReportBtn;
        private System.Windows.Forms.DataGridView ReportsDGV;
        private System.Windows.Forms.RadioButton CustomerCountRadio;
        private System.Windows.Forms.RadioButton ConsultantSchedulesRadio;
        private System.Windows.Forms.RadioButton AppointmentsByTypeRadio;
        private System.Windows.Forms.RadioButton AllAppointmentsRadio;
    }
}