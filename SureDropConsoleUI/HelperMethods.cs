using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static SureDropAPIAccessLibrary.SureDropAPIAccess;


namespace SureDropConsoleUI
{

    public class HelperMethods
    {
        static string hostUrl = "https://alpha.suredrop.dev/rest";
        static string token;
        static string company;
        static string username;
        static string password;
        static string group;
        static string template;
        static string target;
        static string name;
        static string description;
        static string folderName;
        static string file;
        static string fileName;


        //-----------------------------------------------------------------------------
        // GET /company
        //
        // Case 1
        //
        // Used to configure the UX expectations before logging in.
        // Things such as the logo, the company name, whether 2FA is mandatory etc.
        //-----------------------------------------------------------------------------
        public static void RunGetCompanyInfo()
        {
            ConsoleClear();
            Console.WriteLine(GetCompanyInfo(hostUrl, company));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //----------------------------------------------------
        // POST /session
        // 
        // Case 2
        //
        // Used to obtain a session token (log into Suredrop)
        //----------------------------------------------------
        public static void RunGetSessionToken()
        {
            ConsoleClear();
            Console.WriteLine(GetSessionToken(hostUrl, company, username, password));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //=====================================================//
        // GET /user/data
        //
        // Case 3
        //
        // Get generic information on a user for UX purposes
        //====================================================//
        public static void RunGetUserData()
        {
            ConsoleClear();
            Console.WriteLine(GetUserData(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //=====================================================//
        // GET /pinga
        //
        // Case 4
        //
        // Do a authorised ping on the api.
        //====================================================//
        public static void RunGetPinga()
        {
            ConsoleClear();
            Console.WriteLine(GetPinga(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //=====================================================//
        // GET /user
        //
        // Case 5
        //
        // Get information on the user
        //====================================================//
        public static void RunGetUser()
        {
            ConsoleClear();
            Console.WriteLine(GetUser(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // POST /user/data
        //
        // Case 6
        //
        // Save configuration data for a user
        //====================================================//
        public static void RunPostUserData()
        {

            ConsoleClear();
            bool navbarPinned;
            int failed;
            int maxRetries;
            bool navbarCollapsed;

            Console.WriteLine("Enter configuration data to change on a user for UX purposes.");
            Console.WriteLine();


            Console.Write("navbarPinned (true/false): ");

            string navPin = Console.ReadLine();
            if (navPin == "true")
            {
                navbarPinned = true;
            }
            else
            {
                navbarPinned = false;
            }

            Console.Write("navbarCollapsed (true/false): ");
            string navColl = Console.ReadLine();
            if (navColl == "true")
            {
                navbarCollapsed = true;
            }
            else
            {
                navbarCollapsed = false;
            }

            Console.Write("FailedLoginAttempt failed (int): ");
            string failedString = Console.ReadLine();
            failed = int.Parse(failedString);

            Console.Write("FailedLoginAttempt maxRetries (int): ");
            string maxRetriesString = Console.ReadLine();
            maxRetries = int.Parse(maxRetriesString);


            Console.WriteLine(PostUserData(hostUrl, company, username, token, navbarPinned, failed, maxRetries, navbarCollapsed));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /mesh
        //
        // Case 7
        //
        // Get a storage mesh. This is an expensive operation,
        // so it is done once and passed back in when uploading a file.
        // However this is an optional parameter when uploading a file,
        // if it is missing the file upload will generate a mesh automatically for evey upload.
        //====================================================//
        public static void RunGetMesh()
        {
            ConsoleClear();
            Console.WriteLine(GetMesh(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /groups
        //
        // Case 8
        //
        // Get a list of groups
        //====================================================//
        public static void RunGetGroups()
        {
            ConsoleClear();
            Console.WriteLine(GetGroups(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /group/[group]
        //
        // Case 9
        //
        // Get the details of a group
        //====================================================//
        public static void RunGetGroupGroup()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetGroupGroup(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /members/[group]/users
        //
        // Case 10
        //
        // Get a list of the group members
        //====================================================//
        public static void RunGetMembersGroupUsers()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetMembersGroupUsers(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /folders/[group]
        //
        // Case 11
        //
        // Get a list of the folders in a group
        //====================================================//
        public static void RunGetFoldersGroup()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetFoldersGroup(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /templates/[group]/1
        //
        // Case 12
        //
        // Get a list of templates that have been applied to the group
        //====================================================//
        public static void RunGetTemplatesGroup1()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetTemplatesGroup1(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /storage/[group]
        //
        // Case 13
        //
        // Get the storage servers associated with a group
        //====================================================//
        public static void RunGetStorageGroup()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetStorageGroup(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }

        //====================================================//
        // GET /templates
        //
        // Case 14
        //
        // Get a list of all of the available templates
        //====================================================//

        public static void RunGetTemplate()
        {
            ConsoleClear();
            Console.WriteLine(GetTemplate(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /storage
        //
        // Case 15
        //
        // Calculate a storage mesh and cache it in suredrop
        //====================================================//
        public static void RunGetStorage()
        {
            ConsoleClear();
            Console.WriteLine(GetStorage(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /template/[template name]
        //
        // Case 16
        //
        // Get the content of a specific template
        //====================================================//
        public static void RunGetTemplateTemplateName()
        {
            ConsoleClear();
            Console.Write("Enter Template: ");

            template = Console.ReadLine();

            Console.WriteLine(GetTemplateTemplateName(hostUrl, template, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /users
        //
        // Case 17
        //
        // Get a list of the users in a group
        //====================================================//
        public static void RunGetUsers()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetUsers(hostUrl, company, group, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /documents/[group]/path
        //
        // Case 18
        //
        // Get a list of the documents
        //====================================================//
        public static void RunGetDocumentsGroupPath()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetDocumentsGroupPath(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /settings
        //
        // Case 19
        //
        // Get the settings
        //====================================================//
        public static void RunGetSettings()
        {
            ConsoleClear();
            Console.WriteLine(GetSettings(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /get_summary_stats
        //
        // Case 20
        //
        // Get the summary stats for the user
        //====================================================//
        public static void RunGetSummaryStats()
        {
            ConsoleClear();
            Console.Write("Enter the username: ");

            target = Console.ReadLine();
            Console.WriteLine(GetSummaryStats(hostUrl, company, target, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /activation
        //
        // Case 21
        //
        // Gets activation details
        //====================================================//
        public static void RunGetActivation()
        {
            ConsoleClear();
            Console.WriteLine(GetActivation(hostUrl, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }

        //====================================================//
        // POST /group
        //
        // Case 22
        //
        // Adds a group and returns the group ID
        //====================================================//
        public static void RunPostGroup()
        {
            ConsoleClear();
            Console.Write("Enter the name for the new group: ");

            name = Console.ReadLine();
            Console.Write("Enter a description for the group: ");
            description = Console.ReadLine();
            Console.WriteLine(PostGroup(hostUrl, company, username, token, name, description));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /user/data{Username}
        //
        // Case 23
        //
        // Gets details on the current user
        //====================================================//
        public static void RunGetUserDataUser()
        {
            ConsoleClear();
            Console.Write("Enter user you would like to retrieve infomation for: ");

            target = Console.ReadLine();
            Console.WriteLine(GetUserDataUser(hostUrl, company, username, target, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // GET /notifications/[group]
        //
        // Case 24
        //
        // Gets all of the notifications that have happened
        // in a group in the last 32 seconds
        //====================================================//
        public static void RunGetnotificationsGroup()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");

            group = Console.ReadLine();
            Console.WriteLine(GetNotificationsGroup(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // POST /folder/[group]/[folder name]
        //
        // Case 25
        //
        // Create a folder
        //====================================================//
        public static void RunPostFolderGroupFolderName()
        {
            ConsoleClear();
            Console.Write("Enter the group ID where you want to create the folder: ");
            group = Console.ReadLine();
            Console.Write("Enter folder name to create: ");
            folderName = Console.ReadLine();
            Console.WriteLine(PostFolderGroupFolderName(hostUrl, group, folderName, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // POST /document/[group]/[folder]/[filename]
        //
        // Case 26
        //
        // Upload a simple file to suredrop
        //====================================================//
        public static void RunPostDocumentGroupPathAndFileName()
        {
            ConsoleClear();
            Console.Write("Enter the group ID: ");
            group = Console.ReadLine();

            Console.Write("Enter folder name \"if it doesnt exist it will be created\": ");
            folderName = Console.ReadLine();

            Console.Write("Enter the full path to file to upload: ");
            file = Console.ReadLine();

            Console.WriteLine(PostDocumentGroupPathAndFileName(hostUrl, group, folderName, file, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // DELETE /group/[group]
        //
        // Case 27
        //
        // Delete a group
        //====================================================//
        public static void RunDeleteGroupGroup()
        {
            ConsoleClear();
            Console.Write("Enter the group ID to delete: ");

            group = Console.ReadLine();
            Console.WriteLine(DeleteGroupGroup(hostUrl, group, company, username, token));
            Console.WriteLine();
            Console.Write("Press enter to return to the method selection menu.");
            Console.ReadLine();
        }


        //====================================================//
        // Clear Console
        //
        // Clears console and buffer 
        //====================================================//
        public static void ConsoleClear()
        {
            Console.Write("\u001bc\x1b[3J");
        }


        //====================================================//
        // Login
        //
        // Logs in and gets a session token
        //====================================================//
        public static void Login()
        {
            Console.WriteLine("Please provide credentials to begin.");
            Console.WriteLine();
            Console.Write("Company name: ");
            company = Console.ReadLine();

            Console.Write("Username: ");
            username = Console.ReadLine();

            Console.Write("Password: ");
            password = GetPassword();

            try
            {
                string tokenString = GetSessionToken(hostUrl, company, username, password);

                JObject tokenJson = JObject.Parse(tokenString);

                if (tokenJson.ContainsKey("token"))
                {
                    Console.WriteLine("Login Successful.");
                    token = tokenJson["token"].ToString();
                    Thread.Sleep(1000);
                }
                else
                {
                    ConsoleClear();
                    Console.WriteLine($"Error: {tokenJson["error"]?.ToString() ?? "Unknown error occurred."}");
                    Console.WriteLine("Press enter to try again.");
                    Console.ReadLine();
                    ConsoleClear();
                    Banner();
                    Login();
                }
            }
            catch (JsonReaderException ex)
            {
                ConsoleClear();
                Console.WriteLine("Invalid response from server. Please try again.");
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
                Login();
            }
            catch (Exception ex)
            {
                ConsoleClear();
                Console.WriteLine("An error occurred while logging in. Please try again.");
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
                Login();
            }
        }


        //====================================================//
        // Get Password
        //
        // Gets password input and hides characters
        //====================================================//
        public static string GetPassword()
        {
            string password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }


        //====================================================//
        // Menu
        //
        // Prints the menu
        //====================================================//
        public static void Menu()
        {
            Console.WriteLine(@"Select a method to run:

  1. Get Company Info                15. Get Storage Cache
  2. Get Session Token               16. Get Template Content
  3. Get User UX Data                17. Get Group Users
  4. Get Pinga                       18. Get Group Documents List
  5. Get User Data                   19. Get Settings
  6. Post User Data                  20. Get User Summary Stats
  7. Get Mesh Info                   21. Get Activation Details
  8. Get Groups                      22. Post a Group
  9. Get Group Details               23. Get a Users Details
 10. Get Group Members               24. Get Group Notifications
 11. Get Group Folders               25. Post a Folder
 12. Get Group Templates             26. Post a File
 13. Get Group Storage Server        27. Delete a Group
 14. Get All Templates               
");
        }

        public static void Banner()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Welcome to Suredrop's interactive API Console UI!");
            Console.WriteLine("Version: 1.0.0");
            Console.WriteLine("Developed by Christian Jones");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
    }
}
