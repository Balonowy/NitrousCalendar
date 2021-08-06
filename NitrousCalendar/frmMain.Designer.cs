
namespace NitrousCalendar
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMonths = new System.Windows.Forms.TabControl();
            this.cbRunOnStartup = new System.Windows.Forms.CheckBox();
            this.lbWhite = new System.Windows.Forms.Label();
            this.lbNoEntry = new System.Windows.Forms.Label();
            this.lbToday = new System.Windows.Forms.Label();
            this.lbRed = new System.Windows.Forms.Label();
            this.lbNitrous = new System.Windows.Forms.Label();
            this.lbOrange = new System.Windows.Forms.Label();
            this.lbB12 = new System.Windows.Forms.Label();
            this.lbGreen = new System.Windows.Forms.Label();
            this.lbSuggestion = new System.Windows.Forms.Label();
            this.cmsDay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiB12 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiN2O = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrDayChange = new System.Windows.Forms.Timer(this.components);
            this.cmsDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMonths
            // 
            resources.ApplyResources(this.tcMonths, "tcMonths");
            this.tcMonths.Name = "tcMonths";
            this.tcMonths.SelectedIndex = 0;
            // 
            // cbRunOnStartup
            // 
            this.cbRunOnStartup.AutoCheck = false;
            resources.ApplyResources(this.cbRunOnStartup, "cbRunOnStartup");
            this.cbRunOnStartup.Name = "cbRunOnStartup";
            this.cbRunOnStartup.UseVisualStyleBackColor = true;
            this.cbRunOnStartup.Click += new System.EventHandler(this.cbRunOnStartup_Click);
            // 
            // lbWhite
            // 
            this.lbWhite.BackColor = System.Drawing.Color.White;
            this.lbWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbWhite, "lbWhite");
            this.lbWhite.Name = "lbWhite";
            // 
            // lbNoEntry
            // 
            resources.ApplyResources(this.lbNoEntry, "lbNoEntry");
            this.lbNoEntry.Name = "lbNoEntry";
            // 
            // lbToday
            // 
            resources.ApplyResources(this.lbToday, "lbToday");
            this.lbToday.Name = "lbToday";
            // 
            // lbRed
            // 
            this.lbRed.BackColor = System.Drawing.Color.Red;
            this.lbRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbRed, "lbRed");
            this.lbRed.Name = "lbRed";
            // 
            // lbNitrous
            // 
            resources.ApplyResources(this.lbNitrous, "lbNitrous");
            this.lbNitrous.Name = "lbNitrous";
            // 
            // lbOrange
            // 
            this.lbOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbOrange, "lbOrange");
            this.lbOrange.Name = "lbOrange";
            // 
            // lbB12
            // 
            resources.ApplyResources(this.lbB12, "lbB12");
            this.lbB12.Name = "lbB12";
            // 
            // lbGreen
            // 
            this.lbGreen.BackColor = System.Drawing.Color.Green;
            this.lbGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbGreen, "lbGreen");
            this.lbGreen.Name = "lbGreen";
            // 
            // lbSuggestion
            // 
            resources.ApplyResources(this.lbSuggestion, "lbSuggestion");
            this.lbSuggestion.AutoEllipsis = true;
            this.lbSuggestion.Name = "lbSuggestion";
            // 
            // cmsDay
            // 
            this.cmsDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiB12,
            this.tsmiN2O});
            this.cmsDay.Name = "cmsDay";
            resources.ApplyResources(this.cmsDay, "cmsDay");
            this.cmsDay.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDay_Opening);
            // 
            // tsmiB12
            // 
            this.tsmiB12.Name = "tsmiB12";
            resources.ApplyResources(this.tsmiB12, "tsmiB12");
            this.tsmiB12.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tsmiN2O
            // 
            this.tsmiN2O.Name = "tsmiN2O";
            resources.ApplyResources(this.tsmiN2O, "tsmiN2O");
            this.tsmiN2O.Click += new System.EventHandler(this.tsmi_Click);
            // 
            // tmrDayChange
            // 
            this.tmrDayChange.Enabled = true;
            this.tmrDayChange.Interval = 1000;
            this.tmrDayChange.Tick += new System.EventHandler(this.tmrDayChange_Tick);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSuggestion);
            this.Controls.Add(this.lbNitrous);
            this.Controls.Add(this.lbOrange);
            this.Controls.Add(this.lbB12);
            this.Controls.Add(this.lbGreen);
            this.Controls.Add(this.lbToday);
            this.Controls.Add(this.lbRed);
            this.Controls.Add(this.lbNoEntry);
            this.Controls.Add(this.lbWhite);
            this.Controls.Add(this.cbRunOnStartup);
            this.Controls.Add(this.tcMonths);
            this.Name = "frmMain";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.cmsDay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMonths;
        private System.Windows.Forms.CheckBox cbRunOnStartup;
        private System.Windows.Forms.Label lbWhite;
        private System.Windows.Forms.Label lbNoEntry;
        private System.Windows.Forms.Label lbToday;
        private System.Windows.Forms.Label lbRed;
        private System.Windows.Forms.Label lbNitrous;
        private System.Windows.Forms.Label lbOrange;
        private System.Windows.Forms.Label lbB12;
        private System.Windows.Forms.Label lbGreen;
        private System.Windows.Forms.Label lbSuggestion;
        private System.Windows.Forms.ContextMenuStrip cmsDay;
        private System.Windows.Forms.ToolStripMenuItem tsmiB12;
        private System.Windows.Forms.ToolStripMenuItem tsmiN2O;
        private System.Windows.Forms.Timer tmrDayChange;
    }
}

