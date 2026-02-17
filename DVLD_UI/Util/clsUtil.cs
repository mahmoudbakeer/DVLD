using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

    }

}
