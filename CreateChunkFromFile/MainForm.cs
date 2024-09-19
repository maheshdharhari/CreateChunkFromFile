using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Title = @"Browse Report File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = @"csv Files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var excelFilePath = textBox1.Text;
            var limitToDivideCsv = int.Parse(textBox2.Text.Trim());


            if (!File.Exists(excelFilePath))
                return;
            var fileNamingConvention = textBox3.Text.Trim();
            if (Path.GetExtension(excelFilePath) == ".xlsx")
            {
                var idFromFile = new List<string>();
                //Create COM Objects. Create a COM object for everything that is referenced
                var xlApp = new Excel.Application();
                var xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
                var xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                var rowCount = xlRange.Rows.Count;
                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                string fileName;
                var fileIncremental = 0;
                string fileExtenstion;
                string stringValue;
                string newFileWithExtension;
                for (var i = 1; i <= rowCount; i++)
                {
                    var s = xlRange.Cells[i, 1].Value2.ToString();
                    idFromFile.Add(s);
                    if (idFromFile.Count != limitToDivideCsv) continue;
                    fileIncremental++;
                    fileName = fileNamingConvention + fileIncremental;
                    fileExtenstion = ".csv";
                    newFileWithExtension = fileName + fileExtenstion;
                    stringValue = string.Join(Environment.NewLine, idFromFile.ToArray());
                    if (File.Exists(newFileWithExtension))
                        File.Delete(newFileWithExtension);
                    using (var sw = new StreamWriter(newFileWithExtension))
                    {
                        sw.WriteLine(stringValue);
                    }

                    idFromFile = new List<string> { "DataID" };
                }

                fileIncremental++;
                fileName = fileNamingConvention + fileIncremental;
                fileExtenstion = ".csv";
                newFileWithExtension = fileName + fileExtenstion;
                stringValue = string.Join(Environment.NewLine, idFromFile.ToArray());

                using (var sw = new StreamWriter(newFileWithExtension))
                {
                    sw.WriteLine(stringValue);
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [something].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }

            if (Path.GetExtension(excelFilePath).ToLower() == ".csv")
            {
                var idFromFile = new List<string>();

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                string fileName;
                var fileIncremental = 0;
                string stringValue;
                string newFileWithExtension;
                string fileExtenstion;

                using (var reader = new StreamReader(excelFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        {
                            var line = reader.ReadLine();
                            var values = line?.Split(',');
                            if (values != null)
                            {
                                var s = values.FirstOrDefault();
                                idFromFile.Add(s);
                            }

                            if (idFromFile.Count != limitToDivideCsv) continue;
                            fileIncremental++;
                            fileName = fileNamingConvention + fileIncremental;
                            fileExtenstion = ".csv";
                            newFileWithExtension = fileName + "_" + limitToDivideCsv.ToString().TrimEnd('0') + "K" +
                                                   fileExtenstion;
                            stringValue = string.Join(Environment.NewLine, idFromFile.ToArray());
                            if (File.Exists(newFileWithExtension))
                                File.Delete(newFileWithExtension);

                            using (var sw = new StreamWriter(newFileWithExtension))
                            {
                                sw.WriteLine(stringValue);
                            }

                            idFromFile = new List<string> { "DataID" };
                        }
                    }
                }

                fileIncremental++;
                fileName = fileNamingConvention + fileIncremental;
                fileExtenstion = ".csv";
                newFileWithExtension = fileName + "_" + limitToDivideCsv.ToString().TrimEnd('0') + "K" + fileExtenstion;
                stringValue = string.Join(Environment.NewLine, idFromFile.ToArray());

                using (var sw = new StreamWriter(newFileWithExtension))
                {
                    sw.WriteLine(stringValue);
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}