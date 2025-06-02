using System;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure; // Added for IDocument, though SampleQuestPdfReport itself implements it.
using System.Diagnostics;
using System.IO;

namespace WinFormsReportingSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Manually attach the event handler
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Create an instance of the SampleQuestPdfReport class.
                var document = new SampleQuestPdfReport();

                // 2. Generate the PDF document.
                // GeneratePdf returns a byte array. For testing or direct saving:
                // byte[] pdfBytes = document.GeneratePdf();

                // For opening directly, it's often easier to generate to a stream/file if QuestPDF supports it directly,
                // or generate to memory and then write to a file.
                // QuestPDF's typical pattern is GeneratePdf(filePath) or GeneratePdf(stream).
                // Let's use GeneratePdf() which returns byte[] and then save manually.

                byte[] pdfBytes = document.GeneratePdf();

                // 3. Define a temporary file path for the PDF.
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "SampleReport.pdf");

                // 4. Write the generated PDF bytes to this temporary file.
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 5. Launch the default system PDF viewer for the generated file.
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                };
                Process.Start(psi);

                // 6. (Optional) Display a success message.
                MessageBox.Show("Report generated and opened successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 6. (Optional) Display an error message.
                MessageBox.Show($"Error generating or opening report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
