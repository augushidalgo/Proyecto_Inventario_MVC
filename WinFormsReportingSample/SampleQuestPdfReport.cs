using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace WinFormsReportingSample
{
    public class SampleQuestPdfReport : IDocument
    {
        // Placeholder for a data model if needed later
        // public MyReportModel Model { get; }

        // Constructor - can be extended to accept data
        public SampleQuestPdfReport(/* MyReportModel model */)
        {
            // Model = model;
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata
        {
            Title = "Sample Report",
            Author = "QuestPDF Sample Generator"
        };

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50); // Default margin for the page

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().Element(ComposeFooter);
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Text("Sample Report")
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(1, Unit.Centimetre).Column(column =>
            {
                column.Spacing(20);

                column.Item().Table(table =>
                {
                    // Define columns
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50); // ID column width
                        columns.RelativeColumn(3);  // Name column width
                        columns.RelativeColumn();   // Value column width
                    });

                    // Define header
                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderCellStyle).Text("ID");
                        header.Cell().Element(HeaderCellStyle).Text("Name");
                        header.Cell().Element(HeaderCellStyle).Text("Value");

                        static IContainer HeaderCellStyle(IContainer cellContainer) => 
                            cellContainer.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                    });

                    // Add rows
                    table.Cell().Element(DataCellStyle).Text("1");
                    table.Cell().Element(DataCellStyle).Text("Item A");
                    table.Cell().Element(DataCellStyle).Text("100");

                    table.Cell().Element(DataCellStyle).Text("2");
                    table.Cell().Element(DataCellStyle).Text("Item B");
                    table.Cell().Element(DataCellStyle).Text("150");

                    table.Cell().Element(DataCellStyle).Text("3");
                    table.Cell().Element(DataCellStyle).Text("Service C");
                    table.Cell().Element(DataCellStyle).Text("200");
                    
                    table.Cell().Element(DataCellStyle).Text("4");
                    table.Cell().Element(DataCellStyle).Text("Another Item D");
                    table.Cell().Element(DataCellStyle).Text("250");

                    static IContainer DataCellStyle(IContainer cellContainer) => 
                        cellContainer.BorderBottom(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(5);
                });
            });
        }

        void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        }
    }

    // Example data model (can be defined in a separate file or here for simplicity)
    // public class MyReportModel
    // {
    //    public List<DataItem> Items { get; set; }
    // }

    // public class DataItem
    // {
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public decimal Value { get; set; }
    // }
}
