using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SureDropAPIAccessLibrary
{
    public static class SureDropAPIAccess
    {

        //-----------------------------------------------------------------------------
        // GET /company
        //
        // Case 1
        //
        // Used to configure the UX expectations before logging in.
        // Things such as the logo, the company name, whether 2FA is mandatory etc.
        //-----------------------------------------------------------------------------
        public static string GetCompanyInfo(string hostUrl, string company)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string restURL = $"{hostUrl}/company?prefix={company}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string content = response.Content.ReadAsStringAsync().Result;

                    return content;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        //----------------------------------------------------
        // POST /session
        // 
        // Case 2
        //
        // Used to obtain a session token (log into Suredrop)
        //----------------------------------------------------
        public static string GetSessionToken(string hostUrl, string company, string username, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string restURL = $"{hostUrl}/session?prefix={company}&username={username}";

                    var jsonObject = new
                    {
                        password = password,
                        timeout = 1,
                        token = ""
                    };

                    string json = JsonConvert.SerializeObject(jsonObject);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(restURL, content).Result;

                    if (response.IsSuccessStatusCode)
                    {

                        string responseBody = response.Content.ReadAsStringAsync().Result;

                        return responseBody;

                    }
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        //=====================================================//
        // GET /user/data
        //
        // Case 3
        //
        // Get generic information on a user for UX purposes
        //====================================================//
        public static string GetUserData(string hostUrl, string company, string username, string token)
        {

            using (HttpClient client = new HttpClient())
            {
                string restURL = $"{hostUrl}/user/data?prefix={company}&username={username}&token={token}";

                HttpResponseMessage response = client.GetAsync(restURL).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result; ;
                }
                else
                {
                    return $"Error: {response}";
                }
            }
        }


        //=====================================================//
        // GET /pinga
        //
        // Case 4
        //
        // Do a authorised ping on the api.
        //====================================================//
        public static string GetPinga(string hostUrl, string company, string username, string token)
        {
            try
            {
                string restURL = $"{hostUrl}/pinga?prefix={company}&username={username}&token={token}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "Error: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"An error occurred: {e.Message}";
            }
        }



        //=====================================================//
        // GET /user
        //
        // Case 5
        //
        // Get information on the user
        //====================================================//
        public static string GetUser(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string restURL = $"{hostUrl}/user?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return $"Error: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"An error occurred: {e.Message}";
            }
        }


        //====================================================//
        // POST /user/data
        //
        // Case 6
        //
        // Save configuration data for a user
        //====================================================//

        public static string PostUserData(string hostUrl, string company, string username, string token,
                                          bool navbarPinned, int failed, int maxRetries, bool navbarCollapsed)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string restURL = $"{hostUrl}/user/data?prefix={company}&username={username}&token={token}";

                    var jsonObject = new
                    {
                        navbarPinned = navbarPinned,
                        username = "crispyjones",
                        FailedLoginAttempt = new
                        {
                            failed = failed,
                            maxRetries = maxRetries
                        },
                        shadow = "",
                        navbarCollapsed = navbarCollapsed, // False
                    };

                    string json = JsonConvert.SerializeObject(jsonObject);

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(restURL, content).Result;

                    return response.Content.ReadAsStringAsync().Result;

                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
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
        public static string GetMesh(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/mesh?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }

        //====================================================//
        // GET /groups
        //
        // Case 8
        //
        // Get a list of groups
        //====================================================//
        public static string GetGroups(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/groups?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }

        }

        //====================================================//
        // GET /group/[group]
        //
        // Case 9
        //
        // Get the details of a group
        //====================================================//
        public static string GetGroupGroup(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restUrl = $"{hostUrl}/group/{group}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restUrl).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /members/[group]/users
        //
        // Case 10
        //
        // Get a list of the group members
        //====================================================//
        public static string GetMembersGroupUsers(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/members/{group}/users?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }

            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }

        //====================================================//
        // GET /folders/[group]
        //
        // Case 11
        //
        // Get a list of the folders in a group
        //====================================================//
        public static string GetFoldersGroup(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/folders/{group}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /templates/[group]/1
        //
        // Case 12
        //
        // Get a list of templates that have been applied to the group
        //====================================================//
        public static string GetTemplatesGroup1(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/templates/{group}/1?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;

                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }

        //====================================================//
        // GET /storage/[group]
        //
        // Case 13
        //
        // Get the storage servers associated with a group
        //====================================================//
        public static string GetStorageGroup(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/storage/{group}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"Error: {(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }

        //====================================================//
        // GET /templates
        //
        // Case 14
        //
        // Get a list of all of the available templates
        //====================================================//
        public static string GetTemplate(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //_token= GetSessionToken();

                    string restURL = $"{hostUrl}/templates?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /storage
        //
        // Case 15
        //
        // Calculate a storage mesh and cache it in suredrop
        //====================================================//
        public static string GetStorage(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/storage?format=cache&prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /template/[template name]
        //
        // Case 16
        //
        // Get the content of a specific template
        //====================================================//
        public static string GetTemplateTemplateName(string hostUrl, string template, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/template/{template}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }

        //====================================================//
        // GET /users
        //
        // Case 17
        //
        // Get a list of the users in a group
        //====================================================//
        public static string GetUsers(string hostUrl, string company, string group, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/users?prefix={company}&username={username}&group={group}&admin=true&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /documents/[group]/path
        //
        // Case 18
        //
        // Get a list of the documents
        //====================================================//
        public static string GetDocumentsGroupPath(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/documents/{group}?deleted=false&prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /settings
        //
        // Case 19
        //
        // Get the settings
        //====================================================//
        public static string GetSettings(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/settings?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /get_summery_stats
        //
        // Case 20
        //
        // Get the summery stats for the user
        //====================================================//
        public static string GetSummaryStats(string hostUrl, string company, string target, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/get_summary_stats?prefix={company}&target_username={target}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /activation
        //
        // Case 21
        //
        // Gets activation details
        //====================================================//
        public static string GetActivation(string hostUrl, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/activation?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // POST /group
        //
        // Case 22
        //
        // Adds a group and returns the group ID
        //====================================================//
        public static string PostGroup(string hostUrl, string company, string username, string token, string name, string description)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {


                    string restURL = $"{hostUrl}/group?prefix={company}&username={username}&token={token}";

                    var groupData = new
                    {
                        name = name,
                        storage = new[] { "Backup", "Primary" },
                        description = description
                    };

                    string jsonData = JsonConvert.SerializeObject(groupData);

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(restURL, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /user/data{Username}
        //
        // Case 23
        //
        // Gets details on a user
        //====================================================//
        public static string GetUserDataUser(string hostUrl, string company, string username, string target, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/user/data?prefix={company}&username={username}&target={target}&token={token}";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // GET /notifications/[group]
        //
        // Case 24
        //
        // Gets all of the notifications that have happened
        // in a group in the last 32 seconds
        //====================================================//
        public static string GetNotificationsGroup(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/notifications/{group}?prefix={company}&username={username}&token={token}&secconds=32";

                    HttpResponseMessage response = client.GetAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // POST /folder/[group]/[folder name]
        //
        // Case 25
        //
        // Create a folder
        //====================================================//
        public static string PostFolderGroupFolderName(string hostUrl, string group, string folderName, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/folder/{group}/{folderName}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.PostAsync(restURL, null).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }

                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // POST /document/[group]/[folder]/[filename]
        //
        // Case 26
        //
        // Upload a simple file to suredrop
        //====================================================//
        public static string PostDocumentGroupPathAndFileName(string hostUrl, string group, string folderName, string file, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    file = file.Trim('\"');
                    string fileName = Path.GetFileName(file.Trim('\"'));

                    string restURL = $"{hostUrl}/document/{group}/{folderName}/{fileName}?prefix={company}&username={username}&token={token}&mesh=&raw=raw";

                    byte[] fileContents = File.ReadAllBytes(file);

                    var content = new ByteArrayContent(fileContents);

                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    HttpResponseMessage response = client.PostAsync(restURL, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }

                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }


        //====================================================//
        // DELETE /group/[group]
        //
        // Case 27
        //
        // Delete a group
        //====================================================//
        public static string DeleteGroupGroup(string hostUrl, string group, string company, string username, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string restURL = $"{hostUrl}/group/{group}?prefix={company}&username={username}&token={token}";

                    HttpResponseMessage response = client.DeleteAsync(restURL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return responseBody;
                    }
                    else
                    {
                        return $"{(int)response.StatusCode}: {response.StatusCode}";
                    }
                }
            }
            catch (Exception e)
            {
                return $"Error: {e}";
            }
        }
    }
}

