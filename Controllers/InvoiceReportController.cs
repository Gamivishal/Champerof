using Champerof.Infra;
using Champerof.ServiceRepository.InvoiceReportRepository;
using Champerof.ServiceRepository.InvoiceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Champerof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceReportController : ControllerBase
    {
        private readonly IInvoiceReportRepository _invoiceRepository;
        private readonly CommonViewModel CommonViewModel = new();
        private readonly ValidationService _validation;

        public InvoiceReportController(IInvoiceReportRepository invoiceRepository, ValidationService validation)
        {
            _invoiceRepository = invoiceRepository;
            _validation = validation;
        }

        [HttpGet("[Action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllpage(int start = 0, int length = 10, string sortColumn = "", string sortColumnDir = "asc", string searchValue = "", DateTime? fromDate = null,
    DateTime? toDate = null,
    long? clientId = null,
    string? invoiceType = null,
    string? status = null)
        {
            var data = await _invoiceRepository.InvoiceReport(start, length, sortColumn, sortColumnDir, searchValue, fromDate,
        toDate,
        clientId,
        invoiceType,
        status);

            CommonViewModel.IsSuccess = true;
            CommonViewModel.StatusCode = ResponseStatusCode.Success;
            CommonViewModel.Data = data;

            return Ok(CommonViewModel);
        }



        [HttpGet("ExportInvoicePdf")]
        public async Task<IActionResult> ExportInvoicePdf(
    int start = 0,
    int length = 1000,
    string sortColumn = "",
    string sortColumnDir = "asc",
    string searchValue = "",
    DateTime? fromDate = null,
    DateTime? toDate = null,
    long? clientId = null,
    string? invoiceType = null,
    string? status = null
)
        {
            try
            {
                var result = await _invoiceRepository.InvoiceReport(
                    start, length, sortColumn, sortColumnDir, searchValue,
                    fromDate, toDate, clientId, invoiceType, status
                );

                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

                var pdf = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(20);
                        page.Size(PageSizes.A4);

                        // 🔹 Header
                        page.Header()
                            .Text("Invoice Report")
                            .Bold()
                            .FontSize(18)
                            .AlignCenter();

                        page.Content().PaddingTop(10).Table(table =>
                        {
                            // 🔹 Column widths (10 columns)
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30); // Sr
                                columns.RelativeColumn(2);  // Client
                                columns.RelativeColumn(2);  // Invoice No
                                columns.RelativeColumn(2);  // Invoice Date
                                columns.RelativeColumn(2);  // Due Date
                                columns.RelativeColumn(1.5f); // SubTotal
                                columns.RelativeColumn(1.5f); // Discount
                                columns.RelativeColumn(1.5f); // Final
                                columns.RelativeColumn(1.5f); // Status
                                columns.RelativeColumn(1.5f); // Type
                            });

                            // 🔹 Header
                            table.Header(header =>
                            {
                                HeaderCell(header, "Sr.");
                                HeaderCell(header, "Client Name");
                                HeaderCell(header, "Invoice Number");
                                HeaderCell(header, "Invoice Date");
                                HeaderCell(header, "Due Date");
                                HeaderCell(header, "Sub Total");
                                HeaderCell(header, "Discount");
                                HeaderCell(header, "Final Amount");
                                HeaderCell(header, "Status");
                                HeaderCell(header, "Type");
                            });

                            // 🔹 Data
                            if (result?.Data != null)
                            {
                                int sr = 1;

                                foreach (var item in result.Data)
                                {
                                    BodyCell(table, sr.ToString());
                                    BodyCell(table, item.ClientName);
                                    BodyCell(table, item.InvoiceNumber);
                                    BodyCell(table, item.InvoiceDate?.ToString("dd/MM/yyyy"));
                                    BodyCell(table, item.DueDate?.ToString("dd/MM/yyyy"));
                                    BodyCell(table, item.SubTotal?.ToString("0.##"));
                                    BodyCell(table, item.Discount?.ToString("0.##"));
                                    BodyCell(table, item.FinalAmount?.ToString("0.##"));
                                    BodyCell(table, item.StatusName ?? item.Status);
                                    BodyCell(table, item.InvoiceTypeName ?? item.InvoiceType);

                                    sr++;
                                }
                            }
                        });
                    });
                }).GeneratePdf();

                return File(pdf, "application/pdf", "InvoiceReport.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("ExportInvoiceExcel")]
        public async Task<IActionResult> ExportInvoiceExcel(
    int start = 0,
    int length = 1000,
    string sortColumn = "",
    string sortColumnDir = "asc",
    string searchValue = "",
    DateTime? fromDate = null,
    DateTime? toDate = null,
    long? clientId = null,
    string? invoiceType = null,
    string? status = null
)
        {
            try
            {
                var result = await _invoiceRepository.InvoiceReport(
                    start, length, sortColumn, sortColumnDir, searchValue,
                    fromDate, toDate, clientId, invoiceType, status
                );

                // ✅ EPPlus License
                ExcelPackage.License.SetNonCommercialPersonal("Yash");

                using (var package = new ExcelPackage())
                {
                    var sheet = package.Workbook.Worksheets.Add("Invoice Report");

                    // 🔹 Header Row
                    sheet.Cells[1, 1].Value = "Sr.";
                    sheet.Cells[1, 2].Value = "Client Name";
                    sheet.Cells[1, 3].Value = "Invoice Number";
                    sheet.Cells[1, 4].Value = "Invoice Date";
                    sheet.Cells[1, 5].Value = "Due Date";
                    sheet.Cells[1, 6].Value = "Sub Total";
                    sheet.Cells[1, 7].Value = "Discount";
                    sheet.Cells[1, 8].Value = "Final Amount";
                    sheet.Cells[1, 9].Value = "Status";
                    sheet.Cells[1, 10].Value = "Type";

                    // 🔹 Bold Header
                    sheet.Cells["A1:J1"].Style.Font.Bold = true;

                    int row = 2;
                    int sr = 1;

                    if (result?.Data != null)
                    {
                        foreach (var item in result.Data)
                        {
                            sheet.Cells[row, 1].Value = sr;
                            sheet.Cells[row, 2].Value = item.ClientName;
                            sheet.Cells[row, 3].Value = item.InvoiceNumber;
                            sheet.Cells[row, 4].Value = item.InvoiceDate?.ToString("dd/MM/yyyy");
                            sheet.Cells[row, 5].Value = item.DueDate?.ToString("dd/MM/yyyy");
                            sheet.Cells[row, 6].Value = item.SubTotal;
                            sheet.Cells[row, 7].Value = item.Discount;
                            sheet.Cells[row, 8].Value = item.FinalAmount;
                            sheet.Cells[row, 9].Value = item.StatusName ?? item.Status;
                            sheet.Cells[row, 10].Value = item.InvoiceTypeName ?? item.InvoiceType;

                            row++;
                            sr++;
                        }
                    }

                    // 🔹 Auto fit columns
                    sheet.Cells["A:J"].AutoFitColumns();

                    // 🔥 Optional: number format (better Excel look)
                    sheet.Column(6).Style.Numberformat.Format = "#,##0.00";
                    sheet.Column(7).Style.Numberformat.Format = "#,##0.00";
                    sheet.Column(8).Style.Numberformat.Format = "#,##0.00";

                    using (var stream = new MemoryStream())
                    {
                        package.SaveAs(stream);
                        stream.Position = 0;

                        return File(
                            stream.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "InvoiceReport.xlsx"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void HeaderCell(TableCellDescriptor header, string text)
        {
            header.Cell().Element(c => c
                .Border(1)
                .Background(Colors.Grey.Lighten2)
                .Padding(5)
                .AlignCenter()
                .Text(text ?? "")
                .Bold()
            );
        }

        void BodyCell(TableDescriptor table, string text)
        {
            table.Cell().Element(c => c
                .Border(1)
                .Padding(5)
                .Text(text ?? "")
            );
        }

    }
}
