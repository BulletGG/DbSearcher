using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbSearcher
{
    public partial class Form1 : Form
    {
        string filePath = @"";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file.");
                return;
            }
            string query = querytxt.Text;

            try
            {
                // Get all matches
                var matches = FileSearcher
                    .SearchLines(filePath, query, exactMatch: exactmatches.Checked, caseSensitive: casesensitive.Checked)
                    .ToList();

                if (matches.Any())
                {
                    var directory = Path.GetDirectoryName(filePath) ?? Environment.CurrentDirectory;
                    var outFileName = Path.GetFileName(filePath) + ".matches.txt";
                    var outPath = Path.Combine(directory, outFileName);

                    using (var sw = new StreamWriter(outPath, false, Encoding.UTF8))
                    {
                        sw.WriteLine($"Search Query: {query}");
                        sw.WriteLine($"Source File: {filePath}");
                        sw.WriteLine($"Found Matches: {matches.Count}");
                        sw.WriteLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        sw.WriteLine(new string('-', 60));
                        foreach (var m in matches)
                        {
                            sw.WriteLine(m.ToString());
                        }
                    }

                    MessageBox.Show($"Wrote {matches.Count} matches to:\n{outPath}");
                }
                else
                {
                    MessageBox.Show("No match found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }


        }

        private void choosefilebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dbFile = new OpenFileDialog();
            if (dbFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = dbFile.FileName;
            }
        }
    }
}