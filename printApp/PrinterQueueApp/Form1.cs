using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterQueueApp
{
    public partial class Form1 : Form
    {// Queue to store print jobs
        private Queue<string> printQueue = new Queue<string>();

        // TextBox to display document contents
        private RichTextBox richTextBox;

        public Form1()
        {
            InitializeComponent();

            // Initialize the RichTextBox to display file content
            richTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(360, 200)
            };
            Controls.Add(richTextBox);

            // Button to open the file dialog
            Button openButton = new Button
            {
                Text = "Open Text Document",
                Location = new System.Drawing.Point(12, 220),
                Size = new System.Drawing.Size(120, 30)
            };
            openButton.Click += OpenButton_Click;
            Controls.Add(openButton);

            // Button to print the document
            Button printButton = new Button
            {
                Text = "Print",
                Location = new System.Drawing.Point(140, 220),
                Size = new System.Drawing.Size(120, 30)
            };
            printButton.Click += PrintButton_Click;
            Controls.Add(printButton);
        }

        // Open file dialog to select a text document
        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                richTextBox.Text = fileContent;

                // Add the print job to the queue
                printQueue.Enqueue(filePath);
            }
        }

        // Simulate the print job process
        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (printQueue.Count > 0)
            {
                string printJob = printQueue.Dequeue();
                MessageBox.Show($"Printing document: {printJob}", "Print Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Simulate print job processing
                Console.WriteLine($"Printing: {printJob}");
            }
            else
            {
                MessageBox.Show("No print jobs in the queue.", "No Jobs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

