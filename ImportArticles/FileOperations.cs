using Microsoft.Office.Interop.Excel;
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
        /// Read file and insert content into List articles
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of articles in a file</returns>
        public List<Article> ReadFile(string fileName)
        {
            try
            {
                Application app = new Application();
                Workbook wb = app.Workbooks.Open(fileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Worksheet ws = (Worksheet)wb.Sheets[1]; //sheet 1
                Range range = ws.UsedRange;
                
                List<Article> list = new List<Article>();

                for(int i=1; i <= range.Rows.Count; i++)
                {
                    string id = (string)(range.Cells[i, 1] as Range).Value2;
                    string description = (string)(range.Cells[i, 2] as Range).Value2;
                    list.Add(new Article(id, description));
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

                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
