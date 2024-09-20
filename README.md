# CreateChunkFromFile

![image](https://github.com/user-attachments/assets/df8c44ff-0b42-4832-902f-82e3f96aac8a)

## Overview

`CreateChunkFromFile` is a Windows Forms application that processes CSV and Excel files to extract data and divide large datasets into smaller CSV files. This tool is useful for managing and breaking down large Excel or CSV reports based on a predefined limit.

## Features

- **File Selection**: Allows users to browse and select CSV or Excel files for processing.
- **Data Splitting**: Splits large CSV or Excel reports into smaller chunks based on a user-defined row limit.
- **Supports Multiple Formats**: Processes both `.csv` and `.xlsx` files.
- **Background Processing**: Uses a background worker to handle file operations without freezing the UI.
  
## Prerequisites

- .NET Framework
- Microsoft Excel installed (for Excel Interop)

## Dependencies

- [Microsoft.Office.Interop.Excel](https://learn.microsoft.com/en-us/office/vba/library-reference/concepts/excel-object-model)

## How to Use

1. **Select a File**  
   Click the "Browse" button to select a CSV or Excel (`.xlsx`) report file.

2. **Set the Chunk Size**  
   Enter the number of rows to include in each split CSV file (e.g., `1000`).

3. **Start the Process**  
   Click the "Create" button to begin processing and splitting the file. The application will run the file processing in the background to avoid freezing the user interface.

4. **Check Results**  
   After processing, the generated CSV files will be named according to the user-defined naming convention and will be saved in the same directory.

## Code Structure

- **MainForm.cs**: Contains the main logic for file selection, data splitting, and UI interactions.
  
### Key Methods:

- **button1_Click**: Opens a file dialog to allow the user to select a report file.
- **button3_Click**: Starts the background worker that processes the file.
- **backgroundWorker1_DoWork**: Processes the selected file (either `.csv` or `.xlsx`) and splits it into smaller CSV files based on the user-defined limit.

### Excel Processing:

- The application uses Excel Interop to read Excel files (`.xlsx`).
- After processing, COM objects are released to ensure no Excel process remains running in the background.

## Example Usage

1. Click "Browse" to select a report file (`.csv` or `.xlsx`).
2. Set the Chunk Size, e.g., `1000`.
3. Click "Create" to process and split the file.
4. The program will output multiple CSV files, each containing the specified number of rows.

## Cleanup

The code uses garbage collection and releases COM objects after processing Excel files to prevent memory leaks or background Excel processes.

For any questions or suggestions, feel free to reach out!
