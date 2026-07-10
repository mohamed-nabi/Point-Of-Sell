using NewPOSBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using PdfiumViewer;
using System.Windows.Forms;

namespace NewPOS
{
    public class clsUtil
    {
        clsInvoiceBL InvoiceBL = new clsInvoiceBL();

       public string GeneratePDFInvoice(int InvoiceID)
        {

            //Configuration Of QuestPDF License
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            string folderPath = "D:\\GeneratedInvoices";

            var model = InvoiceBL.GetInvoiceModel(InvoiceID);
            var document = new clsInvoiceDocument(model);


            string fullFilePath = Path.Combine(folderPath,
      $"Invoice_{model.InvoiceNumber}_" +
      $"{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.pdf");


            byte[] pdfBytes = document.GeneratePdf();

            File.WriteAllBytes(fullFilePath,
                pdfBytes);


            return fullFilePath;
           
        }

        public bool PrintPdfFile(string FullFilePath)
        {
            if (Path.GetExtension(FullFilePath).ToLower() != ".pdf")
            {
                return false;
            }


            try
            {
                // 1. فتح ملف الـ PDF
                using (var document = PdfDocument.Load(FullFilePath))
                {
                    // 2. إنشاء إعدادات الطباعة الخاصة بالويندوز
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        // 3. تحديد اسم الطابعة المستهدفة
                        printDocument.PrinterSettings.PrinterName = "EPSON L3110 Series";

                        // إعدادات إضافية (اختيارية):
                        // printDocument.PrinterSettings.Copies = 1; // عدد النسخ

                        // 4. إرسال الملف إلى مستودع الطباعة (Spooler) فوراً وبدون إظهار واجهات للمستخدم
                        printDocument.Print();

                        
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
