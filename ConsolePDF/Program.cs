using ConsolePDF.Helpers;
using ConsolePDF.Models.Enum;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;

namespace ConsolePDF
{
    class Program
    {
        private static readonly PdfHelper _helper = new PdfHelper();

        static void Main(string[] args)
        {
            Console.WriteLine("Inicializate Program");
            
            Console.WriteLine("Generate PDF");

            //ELEMENT TO USE
            List<Paragraph> elements = new List<Paragraph>();
            List<PdfPTable> pTables = new List<PdfPTable>();
            string namePdf = "TestPdf.pdf";
            string folderPdf = "C:/TestPdf/";
            
            //Generate HeaderAndBodyTable
            var table = SetHeaderTable();
            table = SetRowsTable(table);

            //ADD TWO TABLES IN THIS EXAMPLE
            elements.Add(new Paragraph("Header of this table 1"));
            pTables.Add(table);
            elements.Add(new Paragraph("Header of this table 2"));
            pTables.Add(table);

            _helper.GeneratePdf(namePdf, folderPdf, elements, pTables);

            Console.WriteLine("End Program");
        }

        private static PdfPTable SetHeaderTable()
        {
            var align = PdfAlign.Left;
            PdfPTable table = _helper.AddPdfTable(4, new float[] { 250f, 250f, 250f, 250f });
            table.AddCell(_helper.AddCellHeader("Column 1", align, true,true));
            table.AddCell(_helper.AddCellHeader("Column 2", align, true));
            table.AddCell(_helper.AddCellHeader("Column 3", align, true,true));
            table.AddCell(_helper.AddCellHeader("Column 4", align, true));

            return table;
        }

        private static PdfPTable SetRowsTable(PdfPTable table)
        {
            var align = PdfAlign.Left;
            bool bold = true;
            //ROW1
            table.AddCell(_helper.AddCellBody("Row 1.1", align, true));
            table.AddCell(_helper.AddCellBody("Row 1.2", align, true, bold));
            table.AddCell(_helper.AddCellBody("Row 1.3", align, true));
            table.AddCell(_helper.AddCellBody("Row 1.4", align, true, bold));
            //ROW2
            table.AddCell(_helper.AddCellBody("Row 2.1", align, false));
            table.AddCell(_helper.AddCellBody("Row 2.2", align, false, bold));
            table.AddCell(_helper.AddCellBody("Row 2.3", align, false));
            table.AddCell(_helper.AddCellBody("Row 2.4", align, false, bold));
            //ROW3
            table.AddCell(_helper.AddCellBody("Row 3.1", align, false));
            table.AddCell(_helper.AddCellBody("Row 3.2", align, false, bold));
            table.AddCell(_helper.AddCellBody("Row 3.3", align, false));
            table.AddCell(_helper.AddCellBody("Row 3.4", align, false, bold));

            return table;
        }
    }
}
