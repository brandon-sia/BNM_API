using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClosedXML.Excel;

namespace BNM_API
{
    public interface IExcelExportable<T>
    {
        void ExportToExcel(string sheetName);
    }
    class ExcelHelper
    {


    }

    public class ListExcelExportable<T> : IExcelExportable<List<T>>
    {
        private List<T> list;
        private string defaultFileName;

        public ListExcelExportable(List<T> list, string defaultFileName)
        {
            this.list = list;
            this.defaultFileName = defaultFileName;
        }

        public void ExportToExcel(string sheetName)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    var properties = typeof(T).GetProperties();

                    // Write the headers to the worksheet
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = properties[i].Name;
                    }

                    // Write the data to the worksheet
                    for (int i = 0; i < list.Count; i++)
                    {
                        var item = list[i];

                        for (int j = 0; j < properties.Length; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = properties[j].GetValue(item)?.ToString();
                        }
                    }

                    // Create a new MemoryStream and write the workbook to it
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

                        // Open the Excel application and the workbook from the MemoryStream
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE",
                            Arguments = "\"" + defaultFileName + "\""
                        });
                    }
                }

           
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex}");
            }
        }
    }

    public class DictionaryExcelExportable<TKey, TValue> : IExcelExportable<Dictionary<TKey, TValue>>
    {
        private Dictionary<TKey, TValue> dictionary;
        private string defaultFileName;

        public DictionaryExcelExportable(Dictionary<TKey, TValue> dictionary, string defaultFileName)
        {
            this.dictionary = dictionary;
            this.defaultFileName = defaultFileName;
        }

        public void ExportToExcel(string sheetName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);

                var keys = new List<TKey>(dictionary.Keys);
                var properties = typeof(TValue).GetProperties();

                // Write the headers to the worksheet
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                // Write the data to the worksheet
                for (int i = 0; i < keys.Count; i++)
                {
                    var key = keys[i];
                    var value = dictionary[key];

                    for (int j = 0; j < properties.Length; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = properties[j].GetValue(value)?.ToString();
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    // Save the exported file to disk
                    var fileStream = new FileStream(defaultFileName, FileMode.Create, FileAccess.Write);
                    stream.WriteTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();

                    // Open the exported file in Excel
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = @"excel.exe",
                        Arguments = "\"" + defaultFileName + "\""
                    });
                }

            }

        }

    }


}