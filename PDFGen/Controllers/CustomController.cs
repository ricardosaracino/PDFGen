using System.Web.Http;
using Foxit.PDF;
using Foxit.PDF.PageElements;

namespace PDFGen.Controllers
{
    [RoutePrefix("api/pdf")]
    public class CustomController : ApiController
    {
        [Route("custom")]
        public void Get()
        {
            Document document = new Document();
            document.Creator = "TableReport.aspx";
            document.Author = "Foxit Software";
            document.Title = "Table Report";


            //Create a Table and set it's properties
            Table table = new Table(0, 0, 512, 676, Font.Helvetica, 12);
            table.Border.Width = 1f;
            table.CellDefault.Border.Width = 1f;
            table.Border.Color = Grayscale.Black;
            table.RepeatColumnHeaderCount = 1;
            table.RepeatRowHeaderCount = 1;

            // Builds the report
            BuildTable(table);
            int currentRow = 0;
            int currentColumn = 0;
            do
            {
                currentRow++;
                currentColumn = 1;
                AddTableToPage(document, table, currentRow, currentColumn);
                Table overflowTable = table.GetOverflowColumns();
                do
                {
                    currentColumn++;
                    AddTableToPage(document, overflowTable, currentRow, currentColumn);
                    overflowTable = overflowTable.GetOverflowColumns();
                } while (overflowTable != null);

                table = table.GetOverflowRows();
            } while (table != null);
            
            
            
            document.DrawToWeb("0875-20200511.pdf");

        }
        
        private void AddTableToPage( Document document, Table table, int currentRow, int currentColumn )
        {
            Page page = new Page( PageSize.Letter );
            if( table != null )
                page.Elements.Add( table );
            page.Elements.Add( new Label( "(" + currentRow + "," + currentColumn + ")", 0, page.Dimensions.Body.Height - 12, page.Dimensions.Body.Width, 12, Font.Helvetica, 12, TextAlign.Center ) );
            document.Pages.Add( page );
        }

        private void BuildTable(Table table)
        {
            CreateColumns(table);
            CreateRowHeadings(table);
            CreateRow(table);
            CreateRow(table);
            CreateRow(table);
            CreateRow(table);
            CreateRow(table);
            CreateRow(table);
            CreateRow(table);
        }

        private void CreateRowHeadings(Table table)
        {
            Row row = table.Rows.Add(40, Font.TimesBold, 12, RgbColor.Black, RgbColor.LightGrey);
            row.CellDefault.Align = TextAlign.Center;
            row.CellDefault.VAlign = VAlign.Top;
            row.Cells.Add("ID");
            row.Cells.Add("Product Name");
            row.Cells.Add("Supplier ID");
            row.Cells.Add("Category ID");
            row.Cells.Add("Quantity Per Unit");
            row.Cells.Add("Unit Price");
            row.Cells.Add("Unit In Stock");
            row.Cells.Add("Units On Order");
            row.Cells.Add("Reorder Level");
            row.Cells.Add("Discontinued");
        }


        private void CreateColumns(Table table)
        {
            table.Columns.Add(25);
            table.Columns.Add(150);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(120);
            table.Columns.Add(60);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);
        }

        private void CreateRow(Table table)
        {
            Row row = table.Rows.Add(20);
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            row.Cells.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }
    }
}