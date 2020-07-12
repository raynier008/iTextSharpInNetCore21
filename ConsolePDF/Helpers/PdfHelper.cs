using ConsolePDF.Models.Enum;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsolePDF.Helpers
{
    public class PdfHelper : IPdfHelper
    {
        #region Properties

        private readonly string lineBreak = " ";
        private readonly string errorMsg = " ";     //"str_error_pdf_nombre_ruta";
        private readonly string errorMsg2 = " ";    // "str_error_pdf_not_null";
        private readonly string errorMsg3 = " ";    //"str_error_pdf_num_column_list_distinct";
        private readonly string errorMsg4 = " ";    //"str_error_pdf_num_column_element_distinct";
        private readonly string fontName = "Tahoma";
        private readonly Single zeroSingle = 0f;
        private readonly Single eigthSingle = 8f;
        private readonly Single twentySingle = 20f;
        private readonly int widthPercentage = 100;

        #endregion

        #region Public Methods

        /// <summary>
        /// The Generation of the tables is from the elements "elements" that is to say, an element and a table are generated
        /// </summary>
        /// <param name="name">Name PDF</param>
        /// <param name="route">Route to Save PDF</param>
        /// <param name="elements">Title Table</param>
        /// <param name="pTables">Table</param>
        public void GeneratePdf(string name, string route, List<Paragraph> elements, List<PdfPTable> pTables)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(route) || (elements.Count == 0 && pTables.Count == 0))
                throw new Exception(errorMsg);
            else if (elements.Count != pTables.Count)
                throw new Exception(errorMsg4);

            //CHECK
            CheckIfExistsFolder(route);

            //CREATE PDF
            FileStream fs = new FileStream(@route + name, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.A4, zeroSingle, zeroSingle, zeroSingle, zeroSingle);
            doc.SetPageSize(PageSize.A4);
            doc.SetMargins(twentySingle, twentySingle, twentySingle, twentySingle);
            PdfWriter.GetInstance(doc, fs);
            doc.Open();

            for (int i = 0; i < elements.Count; i++)
            {
                doc.Add(new Paragraph(elements[i]));
                doc.Add(new Paragraph(lineBreak));
                doc.Add(pTables[i]);
                doc.Add(new Paragraph(lineBreak));
            }

            doc.Close();

            PdfReader reader = new PdfReader(route + name);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
        }

        public PdfPCell AddCellHeader(object value, PdfAlign align = PdfAlign.Center, bool isFirstRow = false, bool inBold = false)
        {
            if (value == null)
                throw new Exception(errorMsg2);

            Font font = FontFactory.GetFont(fontName, eigthSingle, (inBold) ? 1 : 0);
            return new PdfPCell(new Phrase(value.ToString(), font))
            {
                HorizontalAlignment = GetElementAlignmentHorizontal(align),
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Border = PdfPCell.NO_BORDER,
                BorderWidthBottom = 1,
                BorderColorBottom = isFirstRow ? BaseColor.WHITE : BaseColor.ORANGE,
                BackgroundColor = BaseColor.WHITE,
                ExtraParagraphSpace = 0
            };
        }

        public PdfPCell AddCellBody(object value, PdfAlign align = PdfAlign.Center, bool isFirstRow = false, bool inBold = false)
        {
            if (value == null)
                throw new Exception(errorMsg2);

            Font font = FontFactory.GetFont(fontName, eigthSingle, (inBold) ? 1 : 0);
            return new PdfPCell(new Phrase(value.ToString(), font))
            {
                HorizontalAlignment = GetElementAlignmentHorizontal(align),
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Border = PdfPCell.NO_BORDER,
                BorderWidthTop = 1,
                BorderColorTop = (isFirstRow) ? BaseColor.WHITE : BaseColor.LIGHT_GRAY,
                BackgroundColor = BaseColor.WHITE,
                ExtraParagraphSpace = 0
            };
        }

        public PdfPTable AddPdfTable(int numColumns, float[] colunmSpace, PdfAlign align = PdfAlign.Center)
        {
            if (numColumns != colunmSpace.Count())
                new Exception(errorMsg3);

            var pTable = new PdfPTable(numColumns)
            {
                WidthPercentage = widthPercentage,
                HorizontalAlignment = GetElementAlignmentHorizontal(align)
            };
            pTable.SetWidths(colunmSpace);

            return pTable;
        }

        public void CheckIfExistsFolder(string urlFolderSharedPdf)
        {
            if (!Directory.Exists(urlFolderSharedPdf))
                Directory.CreateDirectory(urlFolderSharedPdf);
        }

        public int GetElementAlignmentHorizontal(PdfAlign pdfAlign)
        {
            switch (pdfAlign)
            {
                case PdfAlign.Center: return Element.ALIGN_CENTER;
                case PdfAlign.Left: return Element.ALIGN_LEFT;
                case PdfAlign.Right: return Element.ALIGN_RIGHT;
                case PdfAlign.Justified: return Element.ALIGN_JUSTIFIED;
                default: return Element.ALIGN_CENTER;
            }
        }

        #endregion

    }
}
