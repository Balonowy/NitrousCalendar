using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NitrousCalendar
{
    public partial class frmMain : Form
    {
        private CalendarManager manager;

        public frmMain()
        {
            InitializeComponent();
            tsmiB12.Tag = CalendarEntry.B12;
            tsmiN2O.Tag = CalendarEntry.N2O;

            manager = new CalendarManager(Properties.Strings.CalendarFileName);
            manager.Load();

            TabPage currentMonthsTab = null;
            var now = DateTime.Now;
            var monthsCounter = new DateTime(now.Year, now.Month, 1).AddMonths(-6);
            for (int i = 0; i < 12; i++)
            {
                TabPage month = new TabPage(monthsCounter.ToString(Properties.Strings.TabDateFormat));
                month.Tag = monthsCounter.Month;

                FlowLayoutPanel flpDays = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill
                };

                for (int day = 0; day < DateTime.DaysInMonth(monthsCounter.Year, monthsCounter.Month); day++)
                {
                    var date = monthsCounter.AddDays(day);
                    var entry = manager[date];
                    var today = DateTime.Now.Date == date;

                    if (today)
                        currentMonthsTab = month;

                    Button btn = new Button
                    {
                        Tag = date,
                        Size = new Size(64, 64),
                        Text = date.ToString(Properties.Strings.DayDateFormat),
                        ContextMenuStrip = cmsDay,
                    };
                    UpdateButton(btn, date, entry);
                    btn.Font = new Font(Font.FontFamily, 15);
                    btn.Click += delegate
                    {
                        cmsDay.Show(btn, new Point(btn.Width - cmsDay.Width, btn.Height));
                    };
                    flpDays.Controls.Add(btn);
                }

                month.Controls.Add(flpDays);
                tcMonths.TabPages.Add(month);
                monthsCounter = monthsCounter.AddMonths(1);
            }

            tcMonths.SelectedTab = currentMonthsTab;
            UpdateSuggestion();
        }

        private void UpdateButton(Button btn, DateTime date, CalendarEntry entry)
        {
            btn.ForeColor = DateTime.Now.Date == date ? Color.Red : entry.GetForeColor();
            btn.BackColor = entry.GetBackColor();
        }

        private void cmsDay_Opening(object sender, CancelEventArgs e)
        {
            if (sender is ContextMenuStrip cms)
            {
                if (cms.SourceControl is Button btn)
                {
                    if (btn.Tag is DateTime date)
                    {
                        var entry = manager[date];
                        tsmiB12.Checked = entry.IsFlagSet(CalendarEntry.B12);
                        tsmiN2O.Checked = entry.IsFlagSet(CalendarEntry.N2O);
                    }
                }
            }
        }

        private void tsmi_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                if (tsmi.Tag is CalendarEntry targetEntry)
                {
                    if (tsmi.Owner is ContextMenuStrip cms)
                    {
                        if (cms.SourceControl is Button btn)
                        {
                            if (btn.Tag is DateTime date)
                            {
                                var entry = manager[date];
                                entry = entry.SetFlags(targetEntry, !entry.IsFlagSet(targetEntry));
                                manager[date] = entry;
                                manager.Write();
                                UpdateButton(btn, date, entry);
                                UpdateSuggestion();
                            }
                        }
                    }
                }
            }
        }

        private void UpdateSuggestion()
        {
            var todayEntry = manager[DateTime.Now.Date];
            if (!todayEntry.HasFlag(CalendarEntry.B12))
            {
                lbSuggestion.Text = Properties.Strings.TakeB12;
                return;
            }

            var countOfN2OPartiesDuringLastTwoWeeks = 0;
            for (int i = 0; i < 14; i++)
            {
                var entry = manager[DateTime.Now.AddDays(-i).Date];
                if (entry.HasFlag(CalendarEntry.N2O))
                    countOfN2OPartiesDuringLastTwoWeeks++;
            }

            if (countOfN2OPartiesDuringLastTwoWeeks <= 1)
            {
                var parties = manager.Where(e => e.Value.HasFlag(CalendarEntry.N2O)).OrderBy(e => e.Key).ToArray();
                if (parties.Length > 0)
                {
                    var lastParty = parties.Last();
                    int daysSince = (int)(DateTime.Now.Date - new DateTime(lastParty.Key).Date).TotalDays;

                    if (daysSince > 0)
                        lbSuggestion.Text = string.Format(Properties.Strings.DaysSince, daysSince);
                    else
                        lbSuggestion.Text = Properties.Strings.NoSuggestions;
                }
                else
                    lbSuggestion.Text = Properties.Strings.NoSuggestions;
            }
            else if (countOfN2OPartiesDuringLastTwoWeeks <= 2)
                lbSuggestion.Text = string.Format(Properties.Strings.Overuse1, countOfN2OPartiesDuringLastTwoWeeks);
            else if (countOfN2OPartiesDuringLastTwoWeeks <= 4)
                lbSuggestion.Text = string.Format(Properties.Strings.Overuse2, countOfN2OPartiesDuringLastTwoWeeks);
            else if (countOfN2OPartiesDuringLastTwoWeeks <= 7)
                lbSuggestion.Text = string.Format(Properties.Strings.Overuse3, countOfN2OPartiesDuringLastTwoWeeks);
            else
                lbSuggestion.Text = string.Format(Properties.Strings.Overuse4, countOfN2OPartiesDuringLastTwoWeeks);
        }

        DateTime lastDate = DateTime.Now.Date;
        private void tmrDayChange_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Date != lastDate.Date)
            {
                tmrDayChange.Enabled = false;
                Application.Restart();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (OperatingSystem.IsWindows())
            {
                CheckAutoStart();
                cbRunOnStartup.Enabled = true;
            }
            else
                cbRunOnStartup.Enabled = false;
        }
        private void CheckAutoStart()
        {
            cbRunOnStartup.Checked = AutoStartManager.AutoStart;
        }
        private void cbRunOnStartup_Click(object sender, EventArgs e)
        {
            AutoStartManager.AutoStart = !cbRunOnStartup.Checked;
            CheckAutoStart();
        }
    }
}
