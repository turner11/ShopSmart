using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarlosAg.ExcelXmlWriter;
using ShopSmart.Dal;

namespace FileExporter
{
    /// <summary>
    /// Exports a shop list to excel
    /// </summary>
    public class ExcelExporter
    {
        /// <summary>
        /// The shop list to export
        /// </summary>
        private ShopList _shopList;

        private List<ShoplistItem> _items;
        /// <summary>
        /// Gets a sholow cache of lists items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        private List<ShoplistItem> Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = this._shopList.ShoplistItems.ToList(); 
                }
                return this._items;
                
            }
        }

        public ExcelExporter()
        {
            
        }


        public Workbook Generate(ShopList shopList)
        {
            this._shopList = shopList;
            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Author = "";
            book.Properties.LastAuthor = "";
            book.Properties.Created = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);
            book.Properties.Version = "12.00";
            book.ExcelWorkbook.WindowHeight = 10035;
            book.ExcelWorkbook.WindowWidth = 23955;
            book.ExcelWorkbook.WindowTopX = 0;
            book.ExcelWorkbook.WindowTopY = 90;
            book.ExcelWorkbook.ProtectWindows = false;
            book.ExcelWorkbook.ProtectStructure = false;
            // -----------------------------------------------
            //  Generate Styles
            // -----------------------------------------------
            this.GenerateStyles(book.Styles);
            // -----------------------------------------------
            //  Generate Sheet1 Worksheet
            // -----------------------------------------------
            this.GenerateShopListWorksheet(book.Worksheets);

           return book;




            }
        

        private void GenerateStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Font.FontName = "Arial";
            Default.Font.Size = 11;
            Default.Font.Color = "#000000";
            Default.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s63
            // -----------------------------------------------
            WorksheetStyle s63 = styles.Add("s63");
            s63.Font.FontName = "Times New Roman";
            s63.Font.Size = 20;
            s63.Font.Color = "#FFFFFF";
            s63.Interior.Color = "#000000";
            s63.Interior.Pattern = StyleInteriorPattern.Solid;
            s63.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s63.Alignment.Vertical = StyleVerticalAlignment.Center;
            s63.Alignment.WrapText = true;
            s63.Alignment.ReadingOrder = StyleReadingOrder.RightToLeft;
            // -----------------------------------------------
            //  s64
            // -----------------------------------------------
            WorksheetStyle s64 = styles.Add("s64");
            s64.Font.FontName = "Times New Roman";
            s64.Font.Size = 11;
            s64.Font.Color = "#FFFFFF";
            s64.Interior.Color = "#000000";
            s64.Interior.Pattern = StyleInteriorPattern.Solid;
            s64.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s64.Alignment.Vertical = StyleVerticalAlignment.Top;
            s64.Alignment.WrapText = true;
            s64.Alignment.ReadingOrder = StyleReadingOrder.RightToLeft;
            // -----------------------------------------------
            //  s65
            // -----------------------------------------------
            WorksheetStyle s65 = styles.Add("s65");
            s65.Font.FontName = "Times New Roman";
            s65.Font.Size = 12;
            s65.Font.Color = "#333399";
            s65.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s65.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s65.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            // -----------------------------------------------
            //  s66
            // -----------------------------------------------
            WorksheetStyle s66 = styles.Add("s66");
            s66.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s66.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s67
            // -----------------------------------------------
            WorksheetStyle s67 = styles.Add("s67");
            s67.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s67.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            // -----------------------------------------------
            //  s68
            // -----------------------------------------------
            WorksheetStyle s68 = styles.Add("s68");
            s68.Font.FontName = "Times New Roman";
            s68.Font.Size = 12;
            s68.Font.Color = "#333333";
            s68.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s68.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s68.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            // -----------------------------------------------
            //  s69
            // -----------------------------------------------
            WorksheetStyle s69 = styles.Add("s69");
            s69.Font.FontName = "Times New Roman";
            s69.Font.Size = 12;
            s69.Font.Color = "#333333";
            s69.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s69.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s69.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            s69.NumberFormat = "Currency";
            // -----------------------------------------------
            //  s70
            // -----------------------------------------------
            WorksheetStyle s70 = styles.Add("s70");
            s70.Font.FontName = "Times New Roman";
            s70.Font.Size = 11;
            s70.Font.Color = "#000000";
            s70.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s70.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s70.NumberFormat = "Currency";
            // -----------------------------------------------
            //  s71
            // -----------------------------------------------
            WorksheetStyle s71 = styles.Add("s71");
            s71.Font.FontName = "Times New Roman";
            s71.Font.Size = 12;
            s71.Font.Color = "#333399";
            s71.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s71.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s71.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            // -----------------------------------------------
            //  s72
            // -----------------------------------------------
            WorksheetStyle s72 = styles.Add("s72");
            s72.Font.FontName = "Segoe UI";
            s72.Font.Size = 12;
            s72.Font.Color = "#333333";
            s72.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s72.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s72.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            // -----------------------------------------------
            //  s73
            // -----------------------------------------------
            WorksheetStyle s73 = styles.Add("s73");
            s73.Font.FontName = "Arial";
            s73.Font.Size = 12;
            s73.Font.Color = "#333333";
            s73.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s73.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s73.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            s73.NumberFormat = "Currency";
            // -----------------------------------------------
            //  s74
            // -----------------------------------------------
            WorksheetStyle s74 = styles.Add("s74");
            s74.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s74.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s74.NumberFormat = "Currency";
            // -----------------------------------------------
            //  s75
            // -----------------------------------------------
            WorksheetStyle s75 = styles.Add("s75");
            s75.Font.FontName = "Arial";
            s75.Font.Size = 12;
            s75.Font.Color = "#000000";
            s75.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            s75.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s75.Alignment.ReadingOrder = StyleReadingOrder.LeftToRight;
            // -----------------------------------------------
            //  s76
            // -----------------------------------------------
            WorksheetStyle s76 = styles.Add("s76");
            s76.Font.Bold = true;
            s76.Font.Italic = true;
            s76.Font.FontName = "Times New Roman";
            s76.Font.Size = 12;
            s76.Font.Color = "#333399";
            s76.Interior.Color = "#FFFF99";
            s76.Interior.Pattern = StyleInteriorPattern.Solid;
            s76.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s76.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s76.Alignment.ReadingOrder = StyleReadingOrder.RightToLeft;
            // -----------------------------------------------
            //  s77
            // -----------------------------------------------
            WorksheetStyle s77 = styles.Add("s77");
            s77.Font.Bold = true;
            s77.Font.Italic = true;
            s77.Font.FontName = "Times New Roman";
            s77.Font.Size = 12;
            s77.Font.Color = "#333399";
            s77.Interior.Color = "#FFFF99";
            s77.Interior.Pattern = StyleInteriorPattern.Solid;
            s77.Alignment.Horizontal = StyleHorizontalAlignment.Right;
            s77.Alignment.Vertical = StyleVerticalAlignment.Bottom;
            s77.Alignment.ReadingOrder = StyleReadingOrder.RightToLeft;
            s77.NumberFormat = "\"¤\"\\ #,##0.00";
        }

        private void GenerateShopListWorksheet(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("ShopList");
            sheet.Names.Add(new WorksheetNamedRange("Print_Area", "=Sheet1!R1C1:R24C6", false));
            sheet.Table.DefaultRowHeight = 14.25F;
            sheet.Table.DefaultColumnWidth = 54F;
            //sheet.Table.ExpandedColumnCount = 6;
            //sheet.Table.ExpandedRowCount = 24;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            WorksheetColumn column0 = sheet.Table.Columns.Add();
            column0.Index = 5;
            column0.Width = 177;

            GenerateHeaders(sheet);

            GenerateDataRows(sheet);
            // -----------------------------------------------
            GenerateFooterRow(sheet);
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.Selected = true;
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Header.Margin = 0.3F;
            sheet.Options.PageSetup.Footer.Margin = 0.3F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.75F;
            sheet.Options.PageSetup.PageMargins.Left = 0.7F;
            sheet.Options.PageSetup.PageMargins.Right = 0.7F;
            sheet.Options.PageSetup.PageMargins.Top = 0.75F;
            sheet.Options.Print.PaperSizeIndex = 9;
            sheet.Options.Print.HorizontalResolution = 1200;
            sheet.Options.Print.VerticalResolution = 1200;
            sheet.Options.Print.ValidPrinterInfo = true;
        }

        private void GenerateHeaders(Worksheet sheet)
        {
            // -----------------------------------------------
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.Height = 25;
            Row0.AutoFitHeight = false;
            WorksheetCell cell;
            cell = Row0.Cells.Add();
            cell.StyleID = "s63";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "רשימת קניות";
            cell.MergeAcross = 5;
            cell.NamedCell.Add("Print_Area");
            // -----------------------------------------------
            WorksheetRow Row1 = sheet.Table.Rows.Add();
            Row1.Height = 15;
            Row1.AutoFitHeight = false;
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.NamedCell.Add("Print_Area");
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "שם המוצר";
            cell.NamedCell.Add("Print_Area");
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "כמות";
            cell.NamedCell.Add("Print_Area");
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "מחיר";
            cell.NamedCell.Add("Print_Area");
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "הערות";
            cell.NamedCell.Add("Print_Area");
            cell = Row1.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "סה\"כ";
            cell.NamedCell.Add("Print_Area");
            // -----------------------------------------------

        }

        private void GenerateDataRows(Worksheet sheet)
        {
            String lastCategoryName = String.Empty;
            
            for (int i = 0; i < this.Items.Count; i++)
            {
                ShoplistItem currItem = this.Items[i];

                bool addCategoryRow = lastCategoryName != currItem.Product.Category.Name;

                if (addCategoryRow)
                {
                    WorksheetRow workSHeetCategoryRow = sheet.Table.Rows.Add();
                    workSHeetCategoryRow.Height = 15;
                    workSHeetCategoryRow.AutoFitHeight = false;
                    WorksheetCell cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s65";
                    cell.Data.Type = DataType.String;
                    cell.Data.Text = currItem.Product.Category.Name;
                    cell.NamedCell.Add("Print_Area");
                    cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s66";
                    cell.NamedCell.Add("Print_Area");
                    cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s66";
                    cell.NamedCell.Add("Print_Area");
                    cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s66";
                    cell.NamedCell.Add("Print_Area");
                    cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s66";
                    cell.NamedCell.Add("Print_Area");
                    cell = workSHeetCategoryRow.Cells.Add();
                    cell.StyleID = "s66";
                    cell.NamedCell.Add("Print_Area");

                }


                WorksheetRow workSHeetDataRow = sheet.Table.Rows.Add();
                workSHeetDataRow.Height = 15;
                workSHeetDataRow.AutoFitHeight = false;
                WorksheetCell workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.StyleID = "s67";
                workSHeetDatacell.NamedCell.Add("Print_Area");
                workSHeetDatacell.StyleID = "s68";
                workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.Data.Type = DataType.String;
                workSHeetDatacell.Data.Text = currItem.Product.ProductName;
                workSHeetDatacell.NamedCell.Add("Print_Area");
                workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.StyleID = "s68";
                workSHeetDatacell.Data.Type = DataType.Number;
                workSHeetDatacell.Data.Text = currItem.Quantity.ToString("N0");
                workSHeetDatacell.NamedCell.Add("Print_Area");
                workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.StyleID = "s69";
                workSHeetDatacell.Data.Type = DataType.Number;
                workSHeetDatacell.Data.Text = currItem.Product.Price.ToString();
                workSHeetDatacell.NamedCell.Add("Print_Area");
                workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.StyleID = "s68";
                workSHeetDatacell.Data.Type = DataType.String;
                workSHeetDatacell.Data.Text = currItem.Product.Notes;
                workSHeetDatacell.NamedCell.Add("Print_Area");
                workSHeetDatacell = workSHeetDataRow.Cells.Add();
                workSHeetDatacell.StyleID = "s70";
                workSHeetDatacell.Data.Type = DataType.Number;
                workSHeetDatacell.Data.Text = "11.58";
                workSHeetDatacell.Formula = "=RC[-3]*RC[-2]";
                workSHeetDatacell.NamedCell.Add("Print_Area");

                lastCategoryName = currItem.Product.Category.Name;
            }

        }

        private static void GenerateFooterRow(Worksheet sheet)
        {
            WorksheetRow Row23 = sheet.Table.Rows.Add();
            WorksheetCell cell = Row23.Cells.Add();
            Row23.Height = 25;
            Row23.AutoFitHeight = false;
            cell = Row23.Cells.Add();
            cell.StyleID = "s76";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "סה\"כ";
            cell.Index = 5;
            cell.NamedCell.Add("Print_Area");
            cell = Row23.Cells.Add();
            cell.StyleID = "s77";
            cell.Data.Type = DataType.Number;
            cell.Data.Text = "150.54000000000002";
            cell.Formula = "=SUM(R[-21]C:R[-2]C)";
            cell.NamedCell.Add("Print_Area");
        }
    }
}
