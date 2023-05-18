using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAC
{
    public class AccessControl
    {
        //r - читать
        //w - записывать
        //d - удалять
        //o - владение
        private string[][] AccessRightsMatrix;
        public AccessControl()
        {
        }
        public void FillingMatrix()
        {
            string[] Books = WorkWithEXCEL.ReadBooksFromExcelForFillingMatrix();
            string[] Users = WorkWithEXCEL.ReadUsersFromExcelForFillingMatrix();
            AccessRightsMatrix = new string[Books.Length][];
            for (int i = 0; i < Books.Length; i++)
            {
                AccessRightsMatrix[i] = new string[Users.Length];
                for (int j = 0; j < Users.Length; j++)
                {
                    if (Users[j] == "student")
                    {
                        AccessRightsMatrix[i][j] = "r";
                    }
                    if (Users[j] == "professor" && int.Parse(Books[i]) != j + 1)
                    {
                        AccessRightsMatrix[i][j] = "rw";
                    }
                    if (Users[j] == "professor" && int.Parse(Books[i]) == j + 1)
                    {
                        AccessRightsMatrix[i][j] = "rwo";
                    }
                    if (Users[j] == "admin")
                    {
                        AccessRightsMatrix[i][j] = "rwdo";
                    }
                }
            }
            WorkWithEXCEL.WriteMatrixToExcel(AccessRightsMatrix);
        }
        public void ReadingMatrix()
        {
            AccessRightsMatrix = WorkWithEXCEL.ReedMatrixFromoExcel(AccessRightsMatrix);
        }
        public string TypeOfAccess(int userIndex, int bookIndex)
        {
            return AccessRightsMatrix[bookIndex][userIndex];
        }
        public void ChangeRights(string user, string book, string new_rights)
        {
            if (user != "" && book != "" && new_rights != "")
            {
                int j = WorkWithEXCEL.SearchUserInExcelForExtendingRights(user);
                int i = WorkWithEXCEL.SearchBookInExcel(book);
                AccessRightsMatrix[i][j] = new_rights.ToString();
                WorkWithEXCEL.WriteNewCellInMatrixToExcel(AccessRightsMatrix, i, j);
            }
        }
        public void DeleteUser(string user)
        {
            if (user != "" )
            {
                int index = WorkWithEXCEL.SearchUserInExcelForExtendingRights(user);
                if (index != -1)
                {
                    WorkWithEXCEL.DeletUserInUserExcel(user);
                    WorkWithEXCEL.DeletUserInMatrixExcel(index);
                    FillingMatrix();
                    MessageBox.Show("Пользователь успешно удален.");
                }
                else
                {
                    MessageBox.Show("Пользователь c таким именем отсутствует.");
                }
            }
        }
        public void DeleteBook(string name)
        {
            if (name != "")
            {
                int index = WorkWithEXCEL.SearchBookInExcel(name);
                WorkWithEXCEL.DeletBookInBookExcel(name);
                WorkWithEXCEL.DeletBookInMatrixExcel(index);
                FillingMatrix();
            }
        }
        public void AddBook(string namebook, string authorname, string authorsurname, int owner)
        {
            WorkWithEXCEL.AddNewBookToExcel(namebook,  authorname,  authorsurname, owner+1);
            FillingMatrix();
        }
        public void Print()
        {
            WorkWithEXCEL.WriteMatrixToExcel(AccessRightsMatrix);
        }

    }
}
