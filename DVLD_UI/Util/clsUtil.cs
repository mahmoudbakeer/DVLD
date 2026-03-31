using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_UI.Util
{
    public static class clsUtil
    {


          public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
         public static string CopyWithGuidName(string sourcePath, string destinationFolder)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Source file not found.", sourcePath);

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            // keep original extension
            string extension = Path.GetExtension(sourcePath);

            // generate GUID filename
            string newFileName = Guid.NewGuid().ToString("N") + extension;

            string destinationPath = Path.Combine(destinationFolder, newFileName);

            File.Copy(sourcePath, destinationPath);

            // return the new file path in case caller needs it
            return destinationPath;
        }
        public static bool DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true; // deleted successfully
                }
                return false; // file wasn't there
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete failed: " + ex.Message);
                return false;
            }
        }
        public static bool IsOnlyNumbers(string input)
        {
            return int.TryParse(input, out _);
        }
        public static bool SaveInfoInFile(string userName, string password, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;

                string value = $"{userName},{password}";
                File.WriteAllText(filePath, value);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
        public static void ClearFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return;

                File.WriteAllText(filePath, string.Empty);
                return;
            }
            catch (IOException)
            {
                return;
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
        public static bool GetInfoFromFile(ref string userName, ref string password, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;

                string value = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(value))
                    return false;

                string[] cred = value.Split(',');

                if (cred.Length < 2)
                    return false;

                userName = cred[0];
                password = cred[1];
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
        
    }

}
