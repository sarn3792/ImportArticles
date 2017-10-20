using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArticles
{
    public class FileOperations
    {
        /// <summary>
        /// Read file and return content into List articles
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of articles in a file</returns>
        public List<Article> ReadFile(string fileName)
        {
            try
            {

                Excel.Application app;
                Excel.Workbook wb;
                Excel.Worksheet ws;
                Excel.Range range;

                app = new Excel.Application();
                wb = app.Workbooks.Open(fileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0); //open file
                ws = (Excel.Worksheet)wb.Sheets[1]; //sheet 1
                range = ws.UsedRange;
                
                List<Article> list = new List<Article>();

                //read excel rows and cells
                for(int i=1; i <= range.Rows.Count; i++)
                {
                    string id = (string)(range.Cells[i, 1] as Excel.Range).Value2;
                    string description = (string)(range.Cells[i, 2] as Excel.Range).Value2;
                    string marca = (string)(range.Cells[i, 3] as Excel.Range).Value2;
                    if (id != null && description != null && marca != null) //Avoid reading "invisible" rows
                    {
                        decimal precioVenta = (decimal)(range.Cells[i, 4] as Excel.Range).Value2;
                        decimal precioLista = (decimal)(range.Cells[i, 5] as Excel.Range).Value2;
                        decimal descuento = (decimal)(range.Cells[i, 6] as Excel.Range).Value2;
                        string proyecto = (string)(range.Cells[i, 7] as Excel.Range).Value2;
                        list.Add(new Article(id, description, marca, precioVenta, precioLista, descuento, proyecto));
                    }
                }
                //using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("iso-8859-1")))
                //{
                //    string line;
                //    string[] columns;
                //    while ((line = sr.ReadLine()) != null)
                //    {
                //        columns = line.Split(',');
                //        list.Add(new Article(columns[0], columns[1]));
                //    }
                //}

                wb.Close(true, null, null);
                app.Quit();

                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
