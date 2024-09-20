# Report Splitter: Automate Splitting Large CSV and Excel Files Using C#

![image](https://github.com/user-attachments/assets/cd259d24-7a34-4b2b-93c5-727affffa265)

## Overview

This project demonstrates how to create a Windows Forms application in C# that automates the process of splitting large reports (in CSV or Excel format) into smaller, more manageable chunks. It uses **Microsoft Office Interop** for Excel file handling and standard file I/O for CSV file operations.

### Key Features

- **File Support**: Supports splitting both CSV and Excel (.xlsx) files.
- **Customizable Chunk Size**: Users can define the number of rows per output file.
- **File Naming Convention**: Automatically names the output files based on the user-specified naming convention and chunk size.
- **Responsive UI**: Uses asynchronous file processing to keep the UI responsive during lengthy operations.

### Technologies Used

- **C#** with .NET
- **Windows Forms** for the user interface
- **Microsoft Office Interop for Excel** for handling Excel files
- **StreamReader/StreamWriter** for CSV file handling

### Requirements

- **.NET Framework** (4.7.2 or above)
- **Microsoft Office Interop Excel** (included in Microsoft Office)

### How It Works

1. **File Selection**: The user selects either a CSV or Excel file using the file browser.
2. **Define Chunk Size**: The user specifies how many rows should be in each output file.
3. **Output Files**: The application splits the selected file into smaller CSV files, each containing a set number of rows.
4. **Naming Convention**: Output files are named based on the user's chosen naming convention and the size of each chunk.

### Getting Started

#### 1. Clone the repository

```bash
git clone https://github.com/maheshdharhari/report-splitter.git
cd report-splitter
```

#### 2. Install Dependencies

Ensure that **Microsoft Office Interop** is installed in your project. You can do this via NuGet Package Manager:

```bash
Install-Package Microsoft.Office.Interop.Excel
```

#### 3. Build and Run

Open the solution in Visual Studio, build the project, and run the application. You can now browse for files, define chunk sizes, and automatically split reports.

### Usage

1. **Browse for File**: Click the "Browse" button to select the report file.
2. **Define Chunk Size**: Enter the number of rows you want per chunk.
3. **Specify Naming Convention**: Enter a custom name for the output files.
4. **Start Process**: Click "Create" to begin splitting the report into smaller files.

### File Structure

```bash
ReportSplitter/
├── SearchFromReport/
│   ├── MainForm.cs        # The core logic for file handling and UI
│   ├── Program.cs         # Entry point for the application
│   ├── App.config         # Configuration for the application
│   └── ...                # Other files like Form designer and resources
└── README.md              # This file
```

### Contributing

Feel free to open issues or contribute by submitting pull requests. Any feedback or ideas to improve the functionality are welcome!

### License

This project is licensed under the MIT License.
