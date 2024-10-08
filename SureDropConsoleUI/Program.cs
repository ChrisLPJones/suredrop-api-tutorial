using static SureDropConsoleUI.HelperMethods;

namespace SureDropConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Banner();

            Login();

            while (true)
            {
                SelectMethod();
            }
        }

        private static void SelectMethod()
        {
            ConsoleClear();

            Banner();

            Menu();

            Console.Write("Enter selection: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": RunGetCompanyInfo(); break;

                case "2": RunGetSessionToken(); break;

                case "3": RunGetUserData(); break;

                case "4": RunGetPinga(); break;

                case "5": RunGetUser(); break;

                case "6": RunPostUserData(); break;

                case "7": RunGetMesh(); break;

                case "8": RunGetGroups(); break;

                case "9": RunGetGroupGroup(); break;

                case "10": RunGetMembersGroupUsers(); break;

                case "11": RunGetFoldersGroup(); break;

                case "12": RunGetTemplatesGroup1(); break;

                case "13": RunGetStorageGroup(); break;

                case "14": RunGetTemplate(); break;

                case "15": RunGetStorage(); break;

                case "16": RunGetTemplateTemplateName(); break;

                case "17": RunGetUsers(); break;

                case "18": RunGetDocumentsGroupPath(); break;

                case "19": RunGetSettings(); break;

                case "20": RunGetSummaryStats(); break;

                case "21": RunGetActivation(); break;

                case "22": RunPostGroup(); break;

                case "23": RunGetUserDataUser(); break;

                case "24": RunGetnotificationsGroup(); break;

                case "25": RunPostFolderGroupFolderName(); break;

                case "26": RunPostDocumentGroupPathAndFileName(); break;

                case "27": RunDeleteGroupGroup(); break;

                default:

                    Console.WriteLine("Invalid selection, please try again.");

                    break;
            }
        }
    }
}