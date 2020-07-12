using ConsolePDF.Models.Enum;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace ConsolePDF.Helpers
{
    public interface IPdfHelper
    {
        void GeneratePdf(string name, string route, List<Paragraph> elements, List<PdfPTable> pTables);
        PdfPCell AddCellHeader(object value, PdfAlign align = PdfAlign.Center, bool isFirstRow = false, bool inBold = false);
        PdfPCell AddCellBody(object value, PdfAlign align = PdfAlign.Center, bool isFirstRow = false, bool inBold = false);
        PdfPTable AddPdfTable(int numColumns, float[] colunmSpace, PdfAlign align = PdfAlign.Center);
        void CheckIfExistsFolder(string urlFolderSharedPdf);
        int GetElementAlignmentHorizontal(PdfAlign pdfAlign);
    }
}
