using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace WorkRestTimer
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        private DateTime periodEndTime;
        private int workDuration, restDuration, totalCycles, currentCycle = 1;
        private bool isWorkPeriod = true;
        private List<string> logs = new();

        public Form1()
        {
            InitializeComponent();
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtWork.Text, out workDuration) ||
                !int.TryParse(txtRest.Text, out restDuration) ||
                !int.TryParse(txtCycles.Text, out totalCycles))
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentCycle = 1;
            isWorkPeriod = true;
            StartPeriod();
        }

        private void StartPeriod()
        {
            int minutes = isWorkPeriod ? workDuration : restDuration;
            periodEndTime = DateTime.Now.AddMinutes(minutes);

            lblStatus.Text = isWorkPeriod ? $"Work ({currentCycle}/{totalCycles})" : $"Rest ({currentCycle}/{totalCycles})";
            lblStatus.BackColor = isWorkPeriod ? Color.LightGreen : Color.LightBlue;

            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            var remaining = periodEndTime - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                countdownTimer.Stop();
                LogPeriod();
                SwitchPeriod();
            }
            else
            {
                lblTimer.Text = $"{remaining:mm\\:ss}";
            }
        }

        private void SwitchPeriod()
        {
            if (!isWorkPeriod)
                currentCycle++;

            if (currentCycle > totalCycles)
            {
                MessageBox.Show("All cycles completed!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExportLogToCSV();
                return;
            }

            isWorkPeriod = !isWorkPeriod;
            StartPeriod();
        }

        private void LogPeriod()
        {
            string periodType = isWorkPeriod ? "Work" : "Rest";
            logs.Add($"{periodType},{DateTime.Now.AddMinutes(-(isWorkPeriod ? workDuration : restDuration)).ToString("s", CultureInfo.InvariantCulture)},{DateTime.Now.ToString("s", CultureInfo.InvariantCulture)}");
        }

        private void ExportLogToCSV()
        {
            string fileName = $"WorkRestLog_{DateTime.Now:yyyyMMddHHmmss}.csv";
            File.WriteAllLines(fileName, new[] { "Period,Start,End" }.Concat(logs));
            MessageBox.Show($"Logs exported to {fileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
