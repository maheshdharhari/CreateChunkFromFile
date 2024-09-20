using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SearchFromReport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Title = @"Browse Report File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = @"csv Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog1.FileName;
            }
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFilePath.Text) || !File.Exists(textBoxFilePath.Text))
                {
                    MessageBox.Show(@"Please select a valid file.");
                    return;
                }

                await Task.Run(() => ProcessFile(textBoxFilePath.Text, int.Parse(textBoxChunkSize.Text), textBoxNameConvention.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error occurred: {ex.Message}");
            }
        }

        private static void ProcessFile(string filePath, int chunkSize, string fileNamingConvention)
        {
            if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ProcessExcelFile(filePath, chunkSize, fileNamingConvention);
            }
            else if (Path.GetExtension(filePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ProcessCsvFile(filePath, chunkSize, fileNamingConvention);
            }
            else
            {
                throw new NotSupportedException("File type not supported. Please select a CSV or Excel file.");
            }
        }

        private static void ProcessExcelFile(string excelFilePath, int chunkSize, string fileNamingConvention)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                var idFromFile = new List<string>();
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                var rowCount = xlRange.Rows.Count;
                var fileIncremental = 0;

                for (var i = 1; i <= rowCount; i++)
                {
                    var s = xlRange.Cells[i, 1]?.Value2?.ToString();
                    if (string.IsNullOrEmpty(s)) continue;

                    idFromFile.Add(s);
                    if (idFromFile.Count == chunkSize)
                    {
                        fileIncremental++;
                        CreateCsvFile(idFromFile, fileNamingConvention, fileIncremental, chunkSize);
                        idFromFile.Clear();
                    }
                }

                // Write the remaining data if any
                if (idFromFile.Count > 0)
                {
                    fileIncremental++;
                    CreateCsvFile(idFromFile, fileNamingConvention, fileIncremental, chunkSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error processing Excel file: {ex.Message}");
            }
            finally
            {
                CleanupExcelResources(xlApp, xlWorkbook, xlWorksheet, xlRange);
            }
        }

        private static void ProcessCsvFile(string csvFilePath, int chunkSize, string fileNamingConvention)
        {
            try
            {
                var idFromFile = new List<string>();
                var fileIncremental = 0;

                using (var reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line?.Split(',');
                        if (values == null || values.Length == 0) continue;

                        idFromFile.Add(values[0]);
                        if (idFromFile.Count == chunkSize)
                        {
                            fileIncremental++;
                            CreateCsvFile(idFromFile, fileNamingConvention, fileIncremental, chunkSize);
                            idFromFile.Clear();
                        }
                    }
                }

                // Write the remaining data if any
                if (idFromFile.Count > 0)
                {
                    fileIncremental++;
                    CreateCsvFile(idFromFile, fileNamingConvention, fileIncremental, chunkSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error processing CSV file: {ex.Message}");
            }
        }

        private static void CreateCsvFile(IEnumerable<string> data, string fileNamingConvention, int fileIncremental, int chunkSize)
        {
            var fileName = $"{fileNamingConvention}_{fileIncremental}_{chunkSize}.csv";

            try
            {
                using (var sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(string.Join(Environment.NewLine, data));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error creating CSV file: {ex.Message}");
            }
        }

        private static void CleanupExcelResources(Excel._Application xlApp, Excel._Workbook xlWorkbook, Excel.Worksheet xlWorksheet, Excel.Range xlRange)
        {
            // Release Excel COM objects
            if (xlRange != null) Marshal.ReleaseComObject(xlRange);
            if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
            if (xlWorkbook != null)
            {
                xlWorkbook.Close(false);
                Marshal.ReleaseComObject(xlWorkbook);
            }
            if (xlApp != null)
            {
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
