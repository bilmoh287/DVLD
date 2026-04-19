using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer.Global_Classes
{
    internal class clsGlobal
    {
        public static clsUser CurrentUser;

        // Holds the institute the logged-in user belongs to.
        // NULL means the user is a Department user (full access).
        // Non-null means the user is a School Manager (scoped access).
        public static int? CurrentInstituteID = null;

        // global variable to hold for the current user permissions
        public static int CurrentUserPermissions = 0;
        public static bool HasPermission(clsUserPermission.enPermissions permission)
        {
            return clsUserPermission.HasPermission(CurrentUserPermissions, permission);
        }

        // File path for saved credentials (inside AppData)
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DVLDApp",
            "data.txt"
        );

        // Encrypt text using Windows Data Protection API
        private static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";
            
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encrypted);
        }

        // Decrypt text
        private static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";

            byte[] data = Convert.FromBase64String(cipherText);
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decrypted);
        }

        // Save or delete credentials depending on checkbox
        public static bool RememberUsernameAndPassword(string username, string password)
        {
            try
            {
                string folderPath = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // if username is empty, delete saved file
                if (string.IsNullOrEmpty(username) && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                // Encrypt before saving
                string dataToSave = Encrypt(username) + "#//#" + Encrypt(password);

                using (StreamWriter writer = new StreamWriter(FilePath, false))
                {
                    writer.WriteLine(dataToSave);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving credentials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Retrieve stored credentials
        public static bool GetStoredCredential(ref string username, ref string password)
        {
            try
            {
                if (!File.Exists(FilePath))
                    return false;

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        return false;

                    string[] parts = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    if (parts.Length != 2)
                        return false;

                    username = Decrypt(parts[0]);
                    password = Decrypt(parts[1]);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading saved credentials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Clear user session when exiting
        public static void Logout()
        {
            CurrentUser        = null;
            CurrentInstituteID = null;
        }
    }
}
