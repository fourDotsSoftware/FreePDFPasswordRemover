using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FreePDFPasswordRemover
{ 
    class ArgsHelper
    {        
        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;

            //MessageBox.Show(args[0]);
            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {

                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }
                }
                else if (Module.IsFromWindowsExplorer)
                {

                }
                else
                {
                    Module.IsCommandLine = true;

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k]);
                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFolder(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().Trim() == "-overwrite"
                            || Module.args[k].ToLower().Trim() == "/overwrite")
                        {
                            Module.CmdOverwritePDF = true;
                        }
                        else if (Module.args[k].ToLower().Trim() == "-nosubdirs"
                            || Module.args[k].ToLower().Trim() == "/nosubdirs")
                        {
                            Module.CmdAddSubdirectories = false;
                        }
                        else if (Module.args[k].ToLower().Trim() == "-backup"
                            || Module.args[k].ToLower().Trim() == "/backup")
                        {
                            Module.CmdKeepBackup = true;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/userpassword:") ||
                        Module.args[k].ToLower().StartsWith("-userpassword:"))
                        {
                            Module.CmdUserPassword = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outfilename:") ||
Module.args[k].ToLower().StartsWith("-outfilename:"))
                        {
                            Module.CmdOutputFile = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outfolder:") ||
        Module.args[k].ToLower().StartsWith("-outfolder:"))
                        {
                            Module.CmdOutputFolder = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outputfolder:") ||
        Module.args[k].ToLower().StartsWith("-outputfolder:"))
                        {
                            Module.CmdOutputFolder = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/l:") ||
        Module.args[k].ToLower().StartsWith("-l:"))
                        {
                            Module.CmdImportListFile = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/log:") ||
        Module.args[k].ToLower().StartsWith("-log:"))
                        {
                            Module.CmdLogFile = GetParameter(Module.args[k]);
                        }
                        else if (Module.args[k].ToLower() == "/h" ||
                        Module.args[k].ToLower() == "-h" ||
                        Module.args[k].ToLower() == "-?" ||
                        Module.args[k].ToLower() == "/?")
                        {
                            ShowCommandUsage();
                            return true;
                        }

                    }

                    if (Module.CmdOutputFolder != String.Empty && !System.IO.Directory.Exists(Module.CmdOutputFolder))
                    {
                        Module.ShowMessage("Please specify an existing output folder !");
                        ShowCommandUsage();
                        return false;
                    }

                    if (Module.CmdUserPassword != string.Empty)
                    {
                        for (int m = 0; m < frmMain.Instance.dt.Rows.Count; m++)
                        {
                            frmMain.Instance.dt.Rows[m]["userpassword"] = Module.CmdUserPassword;
                        }
                    }

                    if (Module.CmdImportListFile != string.Empty && !System.IO.File.Exists(Module.CmdImportListFile))
                    {
                        Module.ShowMessage("Import List File does not exist !");
                        ShowCommandUsage();
                        return false;
                    }

                    if (Module.CmdLogFile != string.Empty && !Module.IsLegalFilename(Module.CmdLogFile))
                    {
                        Module.ShowMessage("Please enter a legal log filename !");
                        ShowCommandUsage();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }


            return true;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }

        public static string GetCommandUsage()
        {
            string msg = "Removes Password and Restrictions from PDF documents.\n\n"+
            "PDFPasswordRemover.exe "+
            "[[file|directory]]"+
            "[/userpassword:USER_PASSWORD_VALUE] " +
            "[/nosubdirs] " +
            "[/overwrite]" +
            "[/backup]" +
            "[outfilename:OUTPUT_FILE_VALUE] " +
            "[outputfolder:OUTPUT_FOLDER_VALUE] " +
            "[/l:IMPORT_LIST_FILE_VALUE]" +
            "[/log:LOG_FILE_VALUE]" +
            "[/?]\n\n\n" +
            "file : one or more pdf or image files to be processed.\n" +
            "directory : one or more directories containing pdf files to be processed.\n" +            
            "userpassword: Document user password (password for opening, not for restrictions).\n" +
            "nosubdirs : do not process also subdirectories of PDF documents input directories\n" +
            "overwrite : overwrite existing PDF document\n" +
            "backup : keep backup in case of overwrite\n" +
            "outfilename : Output filename. If not specified the file will have the same filename but will end with \"_unprotected\".\n" +
            "Enter [FILENAME] for document's filename without extension and [EXT] for document's extension.\n" +
            "/l : Import list of files to be processed from a text file. One file or folder on each line. In case the document has a password it's line should be comma separated.\n" +
            "/log : Logfile where output messages should be logged.\n" +            
            "outputfolder: Output folder value (if different than the folder of the first file)\n" +
            "/? : show help\n";

            return msg;
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started removing Passwords from PDF documents !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }

                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    err += "Please specify PDF Files to Compress !";
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                try
                {
                    err += RemovePasswordsHelper.RemovePasswordsMultiplePDFCmd(frmMain.Instance.dt);
                    finished = true;
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }
            finally
            {
                if (Module.CmdLogFile == string.Empty)
                {
                    if (err == string.Empty && finished)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }
                    else
                    {
                        Module.ShowMessage("An error occured !\n" + err);
                    }
                }
                else
                {
                    if (err == string.Empty && finished)
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Operation completed successfully !");
                    }
                    else
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] An error occured !\n" + err);
                    }
                }

                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.Flush();
                    Module.CmdLogFileWriter.Close();
                }
            }
            Environment.Exit(0);
        }


   
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
