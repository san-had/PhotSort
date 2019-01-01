using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using PhotSortComponent.Extensibility;

namespace ExifLibInAction
{
    public partial class Form1 : Form
    {
        private readonly string IMAGE_START_DIR;

        private readonly IMainSorter mainSorter;

        public Form1(IMainSorter mainSorter)
        {
            InitializeComponent();

            IMAGE_START_DIR = ConfigurationManager.AppSettings["ImageStartDir"].ToString();

            this.mainSorter = mainSorter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtImageDir.Text = IMAGE_START_DIR;
        }

        private void btnSetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txtImageDir.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtImageDir.Text = fbd.SelectedPath;
            }
        }

        private async void btnSortImages_Click(object sender, EventArgs e)
        {
            var folderPath = txtImageDir.Text;

            string[] sequenceLines = txtSeq.Lines;

            txtSortResult.Text = "Sorting pictures please wait patiently!";

            var sortResult = await mainSorter.SortProcessing(folderPath, sequenceLines);

            DisplaySortResult(sortResult);
        }

        private void DisplaySortResult(IList<string> sortResultList)
        {
            var sb = new StringBuilder();

            foreach (var record in sortResultList)
            {
                sb.AppendLine(record);
            }
            txtSortResult.Text = sb.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSeq.Text = string.Empty;
            txtSortResult.Text = string.Empty;
        }
    }
}