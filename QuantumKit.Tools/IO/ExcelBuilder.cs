// This project uses ClosedXML, which internally uses SixLabors.Fonts (Apache-2.0)
// See LICENSES/ for full license texts.
using ClosedXML.Excel;
using System.Globalization;

namespace QuantumKit.IO
{
    public class ExcelBuilder
    {
        private XLWorkbook workbook;
        private IXLWorksheet worksheet;
        private int currentRow = 1;

        public void Create(string sheetName)
        {
            workbook = new XLWorkbook();
            worksheet = workbook.Worksheets.Add(sheetName);
        }

        public void AddRow(string csvColumn)
        {
            if (worksheet == null)
                throw new InvalidOperationException("Debe crear una hoja antes de agregar filas.");

            var values = csvColumn.Split(',');

            for (int col = 0; col < values.Length; col++)
            {
                string raw = values[col].Trim();
                var cell = worksheet.Cell(currentRow, col + 1);

                if (DateTime.TryParseExact(raw, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    cell.Value = date;
                    cell.Style.DateFormat.Format = "dd/MM/yyyy";
                }
                else if (raw.EndsWith("%") && double.TryParse(raw.TrimEnd('%'), out var pct))
                {
                    cell.Value = pct / 100;
                    cell.Style.NumberFormat.Format = "0.00%";
                }
                else if (double.TryParse(raw, out var num))
                {
                    cell.Value = num;
                }
                else
                {
                    cell.Value = raw;
                }
            }

            currentRow++;
        }

        public void Close(string filePath)
        {
            if (workbook == null)
                throw new InvalidOperationException("No hay libro de Excel para guardar.");

            workbook.SaveAs(filePath);
        }
    }
}
