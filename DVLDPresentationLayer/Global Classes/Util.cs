using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            // Generte a new Guid
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static bool CreateFolderIfNotExists(string FolderPath)
        {
            // Check if the folder exists
            if(!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            // Full file name. Change your file name   
            string fileName = SourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\DVLD-People-Images\";
            if(!CreateFolderIfNotExists(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceFile = destinationFile;
            return true;
        }

        public static int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            int years = endDate.Year - startDate.Year;

            if ((endDate.Month == startDate.Month && endDate.Day < startDate.Day) || endDate.Month < startDate.Month)
                years--;

            return years;
        }
    }
}
