using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAC
{
    public class WorkWithEXCEL
    {
        public static void ReadUsersFromExcelForListBox(List<string> UsersListBox)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            for (int i = 2; i <= rows; i++)
            {
                UsersListBox.Add(excelRange.Cells[i, 3].Value2.ToString());
            }
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static void ReadFromExcelForInternalSystemWindow(List<string> BooksListComboBox)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            for (int i = 2; i <= rows; i++)
            {
                BooksListComboBox.Add(excelRange.Cells[i, 3].Value2.ToString());
            }
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static string ReadFromExcelForSingIn(string pass, string log)
        {
            string flag = null;
            if (pass != "" && log != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 2] != null && excelRange.Cells[i, 2].Value2 != null)
                    {
                        if (excelRange.Cells[i, 2].Value2.ToString() == pass && excelRange.Cells[i, 3].Value2.ToString() == log)
                        {
                            flag = excelRange.Cells[i, 1].Value2.ToString();
                            app.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                            return flag;
                        }
                    }
                }
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            return flag;
        }
        public static void WriteToExcelForSingUp(string pas, string stat, string log)
        {
            if (pas != "" && stat != "" && log != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                if (stat == "Администратор")
                {
                    sheet.Cells[rows + 1, 1] = "admin".ToString();
                }
                if (stat == "Преподаватель")
                {
                    sheet.Cells[rows + 1, 1] = "professor".ToString();
                }
                if (stat == "Студент")
                {
                    sheet.Cells[rows + 1, 1] = "student".ToString();
                }
                sheet.Cells[rows + 1, 2] = pas.ToString();
                sheet.Cells[rows + 1, 3] = log.ToString();
                int a = int.Parse(excelRange.Cells[rows, 4].Value2.ToString());
                sheet.Cells[rows + 1, 4] = (a + 1).ToString();
                wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }
        public static void AddNewBookToExcel(string namebook, string authorname, string authorsurname, int owner)
        {
            if (namebook != "" && authorname != "" && authorsurname != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                sheet.Cells[rows + 1, 1] = authorname.ToString();
                sheet.Cells[rows + 1, 2] = authorsurname.ToString();
                sheet.Cells[rows + 1, 3] = namebook.ToString();
                sheet.Cells[rows + 1, 4] = owner.ToString();
                wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }
        public static string[] ReadBooksFromExcelForFillingMatrix()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            string[] Books = new string[rows - 1];
            for (int i = 2; i <= rows; i++)
            {
                Books[i - 2] = excelRange.Cells[i, 4].Value2.ToString();
            }
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            return Books;
        }
        public static string[] ReadUsersFromExcelForFillingMatrix()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            string[] Users = new string[rows - 1];
            for (int i = 2; i <= rows; i++)
            {
                Users[i - 2] = excelRange.Cells[i, 1].Value2.ToString();
            }
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            return Users;
        }
        public static void WriteMatrixToExcel(string[][] AccessRightsMatrix)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            int i = 1, j = 1;
            foreach (string[] row in AccessRightsMatrix)
            {
                foreach (string number in row)
                {
                    sheet.Cells[i, j] = number.ToString();
                    j++;
                }
                j = 1;
                i++;
            }
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static string[][] ReedMatrixFromoExcel(string[][] AccessRightsMatrix)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            AccessRightsMatrix = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                AccessRightsMatrix[i] = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    AccessRightsMatrix[i][j] = excelRange.Cells[i + 1, j + 1].Value2.ToString();
                }
            }
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            return AccessRightsMatrix;
        }
        public static int SearchUserInExcel(string user, string pas)
        {
            int index = -1;
            if (user != null && pas != null)
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 3].Value2.ToString() == user && excelRange.Cells[i, 2].Value2.ToString() == pas)
                    {
                        index = i - 2;
                        break;
                    }
                }
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            return index;
        }
        public static int SearchUserInExcelForExtendingRights(string user)
        {
            int index = -1;
            if (user != "" )
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 3].Value2.ToString() == user)
                    {
                        index = i - 2;
                        break;
                    }
                }
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            return index;
        }
        public static int SearchBookInExcel(string book)
        {
            int index = 0;
            if (book != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 3].Value2.ToString() == book)
                    {
                        index = i - 2;
                        break;
                    }
                }
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            return index;
        }
        public static void WriteNewCellInMatrixToExcel(string[][] AccessRightsMatrix, int i, int j)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            sheet.Cells[i + 1, j + 1] = AccessRightsMatrix[i][j].ToString();
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static void DeletUserInMatrixExcel(int ind)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            sheet.Columns[ind].Delete();
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static void DeletUserInUserExcel(string user)
        {
            if (user != "" )
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 3].Value2.ToString() == user.ToString())
                    {
                        sheet.Rows[i].Delete();
                        for (int j = i; j < rows; j++)
                            sheet.Cells[j, 4]= j - 1;
                        break;
                    }
                }
                wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Users.xlsx");
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }
        public static void DeletBookInMatrixExcel(int ind)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            sheet.Rows[ind].Delete();
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static void ChangeOwnerBookInMatrixExcel(int idbook,int idowner)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            sheet.Cells[idbook, 4] = idowner;
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        public static void DeletBookInBookExcel(string name)
        {
            if (name != "")
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                app.SheetsInNewWorkbook = 2;
                Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                Range excelRange = sheet.UsedRange;
                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    if (excelRange.Cells[i, 3].Value2.ToString() == name.ToString())
                    {
                        sheet.Rows[i].Delete();
                        break;
                    }
                }
                wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books.xlsx");
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }

        public static void ClearMatrix()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Open(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            Range excelRange = sheet.UsedRange;
            sheet.Rows.Delete();
            wb.SaveAs(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\AccesMatrix.xlsx");
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
    }
}
