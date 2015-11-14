#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.Resource_Object.Divisions;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    class Structure_Map_Element_Helper
    {
        public static bool add_local_files(string[] files, Division_Info BibDivInfo, string directory, ref int pages_added, ref int files_added )
        {
            bool returnValue = false;
            files_added = 0;
            pages_added = 0;

            // Get the list of all divisions and page nodes (with attached files)
            List<abstract_TreeNode> allDivs = BibDivInfo.Physical_Tree.Divisions_PreOrder;

            // Get the full name for the current directory, normalized
            string package_normalized_dirname = (new DirectoryInfo(directory)).FullName.ToUpper();

            // Store the hashtable between directory and relative directory (computed as necessary)
            Dictionary<string, string> directory_to_relative = new Dictionary<string, string>();

            // Get the list of selected files
            foreach (string thisFile in files)
            {
                // Get the basic file information
                FileInfo thisFileInfo = new FileInfo(thisFile);

                // Get the normalized directoryname for this
                string this_normalized_dirname = thisFileInfo.Directory.FullName.ToUpper();

                // Is this from the same directory?
                bool abort = false;
                string relative_directory = String.Empty;
                if (!this_normalized_dirname.Equals(package_normalized_dirname))
                {
                    // Is this in a subdirectory
                    if (this_normalized_dirname.Contains(package_normalized_dirname))
                    {
                        // Was the relative directory already computed?
                        if (directory_to_relative.ContainsKey(this_normalized_dirname))
                            relative_directory = directory_to_relative[this_normalized_dirname];
                        else
                        {
                            // Compute the relative directory here
                            StringBuilder relativeBuilder = new StringBuilder();
                            DirectoryInfo relativeDirIterator = thisFileInfo.Directory;
                            relativeBuilder.Append(relativeDirIterator.Name);
                            int binding_counter = 0;
                            while ((relativeDirIterator.Parent.FullName.ToUpper() != package_normalized_dirname) && (binding_counter < 10))
                            {
                                relativeDirIterator = relativeDirIterator.Parent;
                                relativeBuilder.Insert(0, relativeDirIterator.Name + "\\");
                                binding_counter++;
                            }
                            if (binding_counter >= 10)
                            {
                                abort = true;
                                MessageBox.Show("Error finding relative directory of file directory.   ");
                            }

                            // Set the relative directory and save it
                            relative_directory = relativeBuilder.ToString();
                            directory_to_relative[this_normalized_dirname] = relative_directory;
                        }
                    }
                    else
                    {
                        // Not in a subdirectory, so look at potentially moving this file over
                        if (File.Exists(directory + "\\" + thisFileInfo.Name))
                        {
                            DialogResult thisResult = MessageBox.Show("New file matches existing file in the resource directory.\n\nWould you like to copy and overwrite the existing file?     ", "Overwrite?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (thisResult != DialogResult.Yes)
                                abort = true;
                            else
                            {
                                File.Copy(thisFile, directory + "\\" + thisFileInfo.Name, true);
                                thisFileInfo = new FileInfo(directory + "\\" + thisFileInfo.Name);
                            }
                        }
                        else
                        {
                            File.Copy(thisFile, directory + "\\" + thisFileInfo.Name, true);
                            thisFileInfo = new FileInfo(directory + "\\" + thisFileInfo.Name);
                        }
                    }
                }

                // Create the file object, so we can use it we need to
                SobekCM_File_Info newMetsFile = new SobekCM_File_Info(relative_directory.Length == 0 ? thisFileInfo.Name : relative_directory + "\\" + thisFileInfo.Name);

                if (!abort)
                {

                    // Get the short filename for inserting into the structure map
                    string filename = newMetsFile.File_Name_Sans_Extension;
                    if (MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page)
                    {
                        if (filename.IndexOf("\\") > 0)
                        {
                            string[] slash_splitter = filename.Split("\\".ToCharArray());
                            filename = slash_splitter[slash_splitter.Length - 1];
                        }
                    }

                    string extension = newMetsFile.File_Extension;

                    // Is this an image file?
                    if ((extension == "TIF") || (extension == "TIFF") || (extension == "JPG") || (extension == "JPEG") || (extension == "GIF") || (extension == "JP2") || (extension == "JPX") || (extension == "TXT") || (extension == "PRO") || (extension == "PNG"))
                    {
                        bool file_found = false;
                        bool page_found = false;

                        // Does this match an existing page file?
                        foreach (abstract_TreeNode thisNode in allDivs)
                        {
                            // Is this a page?
                            if (thisNode.Page)
                            {
                                // Step through all the files in this page
                                Page_TreeNode pageNode = (Page_TreeNode)thisNode;
                                foreach (SobekCM_File_Info existingFile in pageNode.Files)
                                {
                                    // Get the filename for this
                                    string existingFileName = existingFile.System_Name.ToUpper();
                                    if (MetaTemplate_UserSettings.Page_Images_In_Seperate_Folders_Can_Be_Same_Page)
                                    {
                                        if (existingFileName.IndexOf("\\") > 0)
                                        {
                                            string[] slash_splitter = existingFileName.Split("\\".ToCharArray());
                                            existingFileName = slash_splitter[slash_splitter.Length - 1];
                                        }
                                    }

                                    // Does this system name match the filename?
                                    if (existingFileName.IndexOf(filename + ".") == 0)
                                    {
                                        page_found = true;
                                        if (existingFileName == filename + "." + extension)
                                        {
                                            // Since we strip THM.JPG from the filename, let's do one last check for this
                                            if (existingFile.System_Name.ToUpper() == newMetsFile.System_Name.ToUpper())
                                            {
                                                file_found = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                // Is this a matching page?
                                if (page_found)
                                {
                                    // If the file was not found, add this to the page
                                    if (!file_found)
                                    {
                                        pageNode.Files.Add(newMetsFile);
                                        files_added++;
                                        returnValue = true;
                                    }

                                    break;
                                }
                            }
                        }

                        // If not found, add this as a new page at the bottom
                        if (!page_found)
                        {
                            // If there is no root division yet, make one
                            if (BibDivInfo.Physical_Tree.Roots.Count == 0)
                            {
                                Division_TreeNode newRoot = new Division_TreeNode("Main", String.Empty);
                                BibDivInfo.Physical_Tree.Roots.Add(newRoot);
                            }

                            // Create a mage node
                            Page_TreeNode newPage = new Page_TreeNode();
                            newPage.Files.Add(newMetsFile);
                            ((Division_TreeNode)BibDivInfo.Physical_Tree.Roots[0]).Nodes.Add(newPage);
                            files_added++;
                            pages_added++;
                            returnValue = true;

                            // Woah!  This call below should be refactored since this is a time-expensive operation to 
                            // pull the entire nodes each time they list is altered.
                            allDivs = BibDivInfo.Physical_Tree.Divisions_PreOrder;
                        }
                    }
                    else
                    {
                        BibDivInfo.Download_Tree.Add_File(thisFileInfo.Name);
                        files_added++;
                        returnValue = true;
                    }
                }
            }

            return returnValue;
        }
    }
}
