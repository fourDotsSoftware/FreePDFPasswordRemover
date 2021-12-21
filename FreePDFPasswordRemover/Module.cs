﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FreePDFPasswordRemover
{
    class Module
    {
        public static string ApplicationTitle = "Free PDF Password Remover 4dots V3.4 - 4dots Software";
        public static string ShortApplicationTitle = "Free PDF Password Remover 4dots V3.4";

        public static string DownloadURL = "http://www.4dots-software.com/d/FreePDFPasswordRemover/";
        public static string HelpURL = "http://www.4dots-software.com/free-pdf-password-remover/how-to-use.php";
        public static string LangURL = "http://www.4dots-software.com/free-pdf-password-remover/lang/";
        public static string TipText = "Great free tool for Removing Passwords from PDF Documents !";

        public static string VersionURL = "http://cssspritestool.com/versions/free-pdf-password-remover.txt";


        public static string StoreUrl = "http://www.pdfdocmerge.com/store/";
        public static string SelectedLanguage = "en-US";

        public static string[] args = null;
        public static bool IsCommandLine = false;
        public static bool IsFromWindowsExplorer = false;

        public static string UserDocumentsFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Free PDF Password Remover";

        public static bool CmdAddSubdirectories = true;
        public static string CmdUserPassword = "";
        public static string CmdOutputFile = "";
        public static string CmdOutputFolder = "";
        public static bool CmdOverwritePDF = false;
        public static bool CmdKeepBackup = false;               
        public static string CmdLogFile = "";
        public static string CmdImportListFile = "";
        public static StreamWriter CmdLogFileWriter = null;

        
        public static List<string> CmdFiles = new List<string>();

        public static List<string> SelectedFilepaths = new List<string>();
        public static List<string> SelectedOperations = new List<string>();
        public static List<string> SelectedParameters = new List<string>();

        public static string PresetFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ImgTransformer\Presets.xml";
        public static string ImageFilter = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png|Jpeg 2000 Images (*.jp2)|*.jp2|Images Files (*.jpg;*.jpeg;*.gif;*.png;*.bmp)|" +
        "*.jpg;*.jpeg;*.gif;*.png;*.bmp|All Files (*.*)|*.*";

        public static string ImageFilterForSave = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png";

        public static string DialogFilesFilter = "PDF Files (*.pdf)|*.pdf|JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png|All Files (*.*)|*.*";


        public static string ImagePattern = "*.jpeg;*.jpg;*.gif;*.bmp;*.png;*.tiff;*.ico;*.jp2;*.wmf;*.exif";
        public static bool DoNotOverwriteFiles = false;
        public static bool AskBeforeOverwrite = false;
        public static bool LeaveSameDateTime = false;

        [DllImport("shell32.dll")]
		public static extern Int32 SHParseDisplayName(
			[MarshalAs(UnmanagedType.LPWStr)]
			String pszName,
			IntPtr pbc,
			out IntPtr ppidl,
			UInt32 sfgaoIn,
			out UInt32 psfgaoOut);

        [DllImport("shell32.dll", ExactSpelling=true, SetLastError=true, CharSet=CharSet.Unicode)]
        public static extern Int32 SHOpenFolderAndSelectItems(IntPtr pidlFolder , UInt32 cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl , UInt32 dwFlags);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
                
        public static string GetRelativePath(string mainDirPath, string absoluteFilePath)
        {
            string[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (
                !firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }

        public static void ShowMessage(string msg)
        {
            if (Module.IsCommandLine)
            {
                Console.WriteLine(TranslateHelper.Translate(msg));
            }
            else
            {
                MessageBox.Show(TranslateHelper.Translate(msg));
            }
        }

        public static DialogResult ShowQuestionDialog(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
        }


        public static void ShowError(Exception ex)
        {
            ShowError("Error", ex);
        }

        public static void ShowError(string msg)
        {
            if (Module.IsCommandLine)
            {
                Console.WriteLine("Error:" + msg);
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static void ShowError(string msg, Exception ex)
        {
            ShowError(msg + "\n\n" + ex.Message);
        }

        public static void ShowError(string msg, string exstr)
        {
            ShowError(msg + "\n\n" + exstr);
        }

        public static DialogResult ShowQuestionDialogYesFocus(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }


        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {           
            
        }

        public static bool IsImage(string filepath)
        {
            try
            {
                filepath = filepath.ToLower();
                FileInfo fi = new FileInfo(filepath);

                if (fi.Extension != String.Empty && Module.ImagePattern.IndexOf(fi.Extension) >= 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public static int _Modex64 = -1;

        public static bool Modex64
        {
            get
            {
                if (_Modex64 == -1)
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        _Modex64 = 1;
                        return true;
                    }
                    else
                    {
                        _Modex64 = 0;
                        return false;
                    }
                }
                else if (_Modex64 == 1)
                {
                    return true;
                }
                else if (_Modex64 == 0)
                {
                    return false;
                }
                return false;
            }
        }

        public static bool IsLegalFilename(string name)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteApplicationSettingsFile()
        {
            try
            {
                string settingsFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();

                System.IO.FileInfo fi = new FileInfo(settingsFile);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class GetTitleAndNumberOfPagesResult
    {
        public string Title = "";
        public int NumberOfPages = -1;
    }

    
}
