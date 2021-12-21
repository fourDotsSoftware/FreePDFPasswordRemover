using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
 
using System.IO;
using System.Collections;
using System.Windows.Forms;
/*1
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
*/

namespace FreePDFPasswordRemover
{
    class RemovePasswordsHelper
    {                
        private static string DefaultPassword = "";
        public static bool CANCELLED = false;
        public static string ErrMultiple = "";

        public static string RemovePasswordsMultiplePDF(DataTable dt,string OutputDir,bool overwrite,bool keepbackup)
        {
            string err = "";
            CANCELLED = false;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (CANCELLED)
                {
                    return err;
                }

                string outfilepath="";
                string filepath=dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();
                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                if (OutputDir.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");
                }
                else if (OutputDir.StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = OutputDir.Substring(subfolderspos);

                    outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                }
                else if (OutputDir.Trim() == TranslateHelper.Translate("Overwrite PDF Document"))
                {
                    outfilepath = filepath;
                }
                else
                {
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = OutputDir + dep;

                        outfilepath = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath));

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outfilepath));
                        }
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(OutputDir, System.IO.Path.GetFileName(filepath));
                    }
                }

                //bool overwrite = (frmMain.Instance.cmbOutputDir.Text == TranslateHelper.Translate("Overwrite PDF Document"));
                //bool keepbackup = frmMain.Instance.chkKeepBackup.Checked;

                try
                {
                    err += RemovePasswordsSinglePDF(filepath, outfilepath,password,overwrite,keepbackup);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }

                frmMain.Instance.bwRemovePasswords.ReportProgress(1);
            }

            return err;
        }

        public static string RemovePasswordsMultiplePDFCmd(DataTable dt)
        {
            string err = "";
            
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Removing Passwords from PDF file : " + dt.Rows[k]["fullfilepath"].ToString());
                }
                
                string outfilepath = "";
                string filepath = dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();

                if (Module.CmdOutputFolder == string.Empty)
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);

                    if (Module.CmdOutputFile == string.Empty)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, Module.CmdOutputFile.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath)).Replace("[EXT]", System.IO.Path.GetExtension(filepath)));
                    }

                }

                if (Module.CmdOverwritePDF)
                {
                    outfilepath = filepath;
                }

                if (Module.CmdOutputFolder != string.Empty)
                {
                    outfilepath = System.IO.Path.Combine(Module.CmdOutputFolder, System.IO.Path.GetFileName(filepath));
                }
                
                try
                {
                    err += RemovePasswordsSinglePDF(filepath, outfilepath, password, Module.CmdOverwritePDF, Module.CmdKeepBackup);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }

        public static string RemovePasswordsSinglePDF(string InputFile, string OutputFile,string Password,bool Overwrite,bool KeepBackup)
        {
            string err = "";

            try
            {
                FileInfo fi = new FileInfo(InputFile);
                DateTime dtcreated = fi.CreationTime;
                DateTime dtlastmod = fi.LastWriteTime;

                //                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                PdfReader reader = null;

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(OutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));
                    }
                    catch (Exception exd)
                    {
                        err += TranslateHelper.Translate("Error. Could not Create Directory for File") + " : " + InputFile+"\r\n"+exd.Message+"\r\n";
                        return err;
                    }
                }


                try
                {
                    //  reader = new PdfReader(input);

                    while (true)
                    {
                        using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(Password))
                                {
                                    reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                    //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));

                                }
                                else
                                {
                                    reader = new PdfReader(input);
                                }

                                break;
                            }
                            catch (iTextSharp.text.pdf.BadPasswordException ex)
                            {
                                if (reader != null)
                                {
                                    reader.Close();
                                }

                                if (input != null)
                                {
                                    input.Close();
                                }

                                if (Module.IsCommandLine)
                                {
                                    err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                    return err;
                                }

                                //frmMain.Instance.backgroundWorker1.CancelAsync();

                                //while (frmMain.Instance.backgroundWorker1.IsBusy)
                                //{
                                //Application.DoEvents();
                                //}

                                if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DefaultPassword))
                                {
                                    Password = DefaultPassword;
                                }
                                else
                                {
                                    frmProgress.Instance.HideForm();

                                    Module.ShowMessage("Please enter the correct User Password !");

                                    frmPassword f2 = new frmPassword(InputFile);



                                    DialogResult dres = f2.ShowDialog();

                                    frmProgress.Instance.ShowForm();

                                    //frmMain.Instance.backgroundWorker1.RunWorkerAsync();

                                    if (dres == DialogResult.OK)
                                    {
                                        Password = f2.txtPassword.Text;

                                        if (f2.chkPassword.Checked)
                                        {
                                            DefaultPassword = Password;
                                        }

                                    }
                                    else
                                    {
                                        err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                        return err;
                                    }
                                }
                            }
                        }
                    }

                    string TmpFile = "";

                    if (Overwrite)
                    {
                        TmpFile = OutputFile;
                        OutputFile = System.IO.Path.GetTempFileName();
                    }

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfStamper stamper = new PdfStamper(reader, memoryStream);

                        stamper.Close();
                        reader.Close();

                        File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                    }

                    if (TmpFile != string.Empty)
                    {
                        if (KeepBackup)
                        {
                            string bakfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(TmpFile),
                            System.IO.Path.GetFileNameWithoutExtension(TmpFile) + ".bak.pdf");

                            System.IO.File.Move(TmpFile, bakfilepath);
                        }
                        else
                        {
                            System.IO.File.Delete(TmpFile);
                        }

                        System.IO.File.Move(OutputFile, TmpFile);

                        FileInfo fi3 = new FileInfo(TmpFile);

                        if (Properties.Settings.Default.KeepCreationDate)
                        {
                            fi3.CreationTime = dtcreated;
                        }

                        if (Properties.Settings.Default.KeepLastModificationDate)
                        {
                            fi3.LastWriteTime = dtlastmod;
                        }
                    }

                    FileInfo fi2 = new FileInfo(OutputFile);

                    if (Properties.Settings.Default.KeepCreationDate)
                    {
                        fi2.CreationTime = dtcreated;
                    }

                    if (Properties.Settings.Default.KeepLastModificationDate)
                    {
                        fi2.LastWriteTime = dtlastmod;
                    }

                    return err;
                }
                catch (Exception exm)
                {
                    err += TranslateHelper.Translate("An error occured while removing Passwords from PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                err += TranslateHelper.Translate("An error occured while removing Passwords from PDF File") + " : " + InputFile + "\r\n" + ex.Message + "\r\n";
            }

            return err;
        }
    }
}
