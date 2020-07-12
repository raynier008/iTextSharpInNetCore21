using System;
using System.Collections.Generic;
using ConsolePDF.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsolePDF.Test
{
    [TestClass]
    public class PdfHelperTest
    {
        #region GeneratePdf

        [TestMethod]
        public void TestGeneratePdfParametersNameRouteNull()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                helper.GeneratePdf(null, null, new List<Paragraph>(), new List<PdfPTable>());
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestGeneratePdfParametersListsEmpty()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                helper.GeneratePdf("name", "ruta", new List<Paragraph>(), new List<PdfPTable>());
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestGeneratePdfDistinctParameters()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                helper.GeneratePdf("name", "ruta", new List<Paragraph>() { new Paragraph("Hello World") }, new List<PdfPTable>());
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestGeneratePdfParameters()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            //Act
            helper.GeneratePdf("name", "ruta", new List<Paragraph>() { new Paragraph("Hello World") }, new List<PdfPTable>() { new PdfPTable(1) });

            //Assert
            Assert.IsTrue(true);
        }

        #endregion

        #region AddCellHeader

        [TestMethod]
        public void TestAddCellHeaderNull()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                _ = helper.AddCellHeader(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestAddCellHeader()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            //Act
            var result = helper.AddCellHeader("dat");

            //Assert
            Assert.AreEqual(new PdfPCell(), result);
        }

        #endregion

        #region AddCellBody

        [TestMethod]
        public void TestAddCellBodyNull()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                _ = helper.AddCellBody(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestAddCellBody()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            //Act
            var result = helper.AddCellBody("dat");

            //Assert
            Assert.AreEqual(new PdfPCell(), result);
        }

        #endregion

        #region AddPdfTable

        [TestMethod]
        public void TestAddPdfTableDistintNumbers()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();

            try
            {
                //Act
                _ = helper.AddPdfTable(2, new float[] { 2 });
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex != null);
            }
        }

        [TestMethod]
        public void TestAddPdfTable()
        {
            //Arrange
            PdfHelper helper = new PdfHelper();
            //Act
            var result = helper.AddPdfTable(2, new float[] { 2, 2 });

            //Assert
            Assert.IsTrue(result != null);
        }

        #endregion
    }
}
