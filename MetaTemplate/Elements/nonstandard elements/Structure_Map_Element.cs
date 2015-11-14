#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools.Forms;
using SobekCM.METS_Editor.Forms;
using SobekCM.METS_Editor.Settings;
using SobekCM.METS_Editor.Template;
using SobekCM.METS_Editor.Tools;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.Divisions;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary>
    /// Summary description for Download_URL_Element.
    /// </summary>
    public class Structure_Map_Element : abstract_Element, iElement
    {
        private Division_Info BibDivInfo;
        private OpenFileDialog addFilesDialog;
        private Round_Button add_files_button;
        private TreeNode additionalNode;
        private Thread checksumThread;
        private Round_Button checksums_button;
        private Round_Button outer_divisions_button;
        private MenuItem childMI;
        private MenuItem collapseMI;
        private ContextMenu contextMenu;
        private MenuItem copyMI;
        private MenuItem deleteMI;
        private string directory;
        private Division_Types_Errors_Table.Division_TypeDataTable divType;

        private MenuItem editDivMI, editPageMI;
        private MenuItem excludeMI;
        private MenuItem expandMI, expandMI2;

        private string fileString = "Files";
        private MenuItem insertMI;
        private MenuItem moveDownMI;
        private MenuItem moveOverMI;
        private MenuItem moveUpMI;
        private string pageFilesString = "Page Images";
        private string pageString = "Page";
        private MenuItem parentMI;
        private string resourceFilesString = "Resource Files";
        private MenuItem seperatorMI, seperatorMI2;
        private Template_Panel templatePanel;
        protected TreeViewDragDrop treeView;
        private MenuItem viewMI;

        #region Constructor

        public Structure_Map_Element()
        {
            // Configure the tree view
            treeView = new TreeViewDragDrop();
            treeView.AllowDrop = true;
            treeView.BackColor = Color.WhiteSmoke;
            treeView.BorderStyle = BorderStyle.FixedSingle;
            treeView.Width = Width-15;
            treeView.Height = Height - 50;
            treeView.Location = new Point( 0, 50 );

            // Add the add_files_button
            add_files_button = new Round_Button();
            add_files_button.BackColor = Color.Transparent;
            add_files_button.Button_Enabled = true;
            add_files_button.Button_Text = "ADD FILES";
            add_files_button.Button_Type = Round_Button.Button_Type_Enum.Standard;
            add_files_button.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            add_files_button.Location = new Point(25, 10 );
            add_files_button.Name = "add_files_button";
            add_files_button.Size = new Size(100, 26);
            add_files_button.Button_Pressed += add_files_button_Button_Pressed;
            Controls.Add(add_files_button);

            // Add the checksums button
            checksums_button = new Round_Button();
            checksums_button.BackColor = Color.Transparent;
            checksums_button.Button_Enabled = true;
            checksums_button.Button_Text = "CHECKSUMS";
            checksums_button.Button_Type = Round_Button.Button_Type_Enum.Standard;
            checksums_button.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            checksums_button.Location = new Point(150, 10);
            checksums_button.Name = "clear_checksums_button";
            checksums_button.Size = new Size(110, 26);
            checksums_button.Button_Pressed += checksums_button_Button_Pressed;
            Controls.Add(checksums_button);

            // Add the outer divisions button
            outer_divisions_button = new Round_Button();
            outer_divisions_button.BackColor = Color.Transparent;
            outer_divisions_button.Button_Enabled = true;
            outer_divisions_button.Button_Text = "OUTER DIVS";
            outer_divisions_button.Button_Type = Round_Button.Button_Type_Enum.Standard;
            outer_divisions_button.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            outer_divisions_button.Location = new Point(280, 10);
            outer_divisions_button.Name = "outer_divisions_button";
            outer_divisions_button.Size = new Size(110, 26);
            outer_divisions_button.Button_Pressed += outer_divisions_button_Button_Pressed;
            Controls.Add(outer_divisions_button);

            // Create the add files diaglog
            addFilesDialog = new OpenFileDialog();
            addFilesDialog.Filter = "All files|*.*|TIF files|*.tif;*.tiff";
            addFilesDialog.Multiselect = true;
            addFilesDialog.Title = "Select files to add to this item";

            treeView.Scrollable = true;
            //   treeView.ItemHeight = 32;
            treeView.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
                                  | AnchorStyles.Left) | AnchorStyles.Right)));
            treeView.DragStart += treeViewDragDrop1_DragStart;
            treeView.DragComplete += treeView_DragComplete;
            Controls.Add( treeView );

            // Set the type of this object
            base.type = Element_Type.Structure_Map;
            base.display_subtype = String.Empty;

            // Set some immutable characteristics
            always_single = true;
            always_mandatory = false;

            // Add treeview events
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;

            // Build the context menu
            contextMenu = new ContextMenu();
            editDivMI = new MenuItem("Edit Division");
            editDivMI.Click += editDivMI_Click;
            editPageMI = new MenuItem("Edit Page Label");
            editPageMI.Click += editPageMI_Click;
            parentMI = new MenuItem("Add new Parent Division");
            parentMI.Click += parentMI_Click;
            insertMI = new MenuItem("Insert new Sibling Division");
            insertMI.Click += insertMI_Click;
            childMI = new MenuItem("Add new Child Division");
            childMI.Click += childMI_Click;
            deleteMI = new MenuItem("Delete");
            deleteMI.Click += deleteMI_Click;
            excludeMI = new MenuItem("Exclude File");
            excludeMI.Click += excludeMI_Click;
            copyMI = new MenuItem("Copy Page");
            copyMI.Click += copyMI_Click;
            expandMI = new MenuItem("Expand To All Page Nodes");
            expandMI.Click += expandMI_Click;
            expandMI2 = new MenuItem("Expand To All File Nodes");
            expandMI2.Click += expandMI2_Click;
            collapseMI = new MenuItem("Collapse All Nodes");
            collapseMI.Click += collapseMI_Click;
            viewMI = new MenuItem("View File");
            viewMI.Click += viewMI_Click;
            seperatorMI = new MenuItem("-");
            moveUpMI = new MenuItem("Move Up");
            moveUpMI.Click += moveUpMI_Click;
            moveUpMI.Shortcut = Shortcut.AltUpArrow;
            moveOverMI = new MenuItem("Move Over");
            moveOverMI.Click += moveOverMI_Click;
            moveOverMI.Shortcut = Shortcut.AltLeftArrow;
            moveDownMI = new MenuItem("Move Down");
            moveDownMI.Click += moveDownMI_Click;
            moveDownMI.Shortcut = Shortcut.AltDownArrow;
            seperatorMI2 = new MenuItem("-");
            contextMenu.MenuItems.Add(viewMI);
            contextMenu.MenuItems.Add(editPageMI);
            contextMenu.MenuItems.Add(editDivMI);
            contextMenu.MenuItems.Add(parentMI);
            contextMenu.MenuItems.Add(insertMI);
            contextMenu.MenuItems.Add(childMI);
            contextMenu.MenuItems.Add(copyMI);
            contextMenu.MenuItems.Add(deleteMI);
            contextMenu.MenuItems.Add(excludeMI);
            contextMenu.MenuItems.Add(seperatorMI);
            contextMenu.MenuItems.Add(moveUpMI);
            contextMenu.MenuItems.Add(moveOverMI);
            contextMenu.MenuItems.Add(moveDownMI);
            contextMenu.MenuItems.Add(seperatorMI2);
            contextMenu.MenuItems.Add(expandMI);
            contextMenu.MenuItems.Add(expandMI2);
            contextMenu.MenuItems.Add(collapseMI);
            treeView.ContextMenu = contextMenu;
            contextMenu.Popup += contextMenu_Popup;

            // Get the correct table
            try
            {
                divType = Division_Types_Errors_Reader.Division_Types_Table;
            }
            catch (Exception ee)
            {
                ErrorMessageBox.Show("Unable to load division type table!    ", "Error Launching", ee);
            }
        }


        void outer_divisions_button_Button_Pressed(object sender, EventArgs e)
        {
            Structure_Map_Outer_Divisions_Form outerDivForm = new Structure_Map_Outer_Divisions_Form(BibDivInfo);
            if (outerDivForm.ShowDialog() == DialogResult.OK)
                base.OnDataChanged();
        }

        void checksums_button_Button_Pressed(object sender, EventArgs e)
        {
            // What sub-action is requested?
            Structure_Map_Checksum_Form subActionForm = new Structure_Map_Checksum_Form();
            subActionForm.ShowDialog();
            Structure_Map_Checksum_Form_Action_Enum action = subActionForm.Selected_Action;

            // Do the requested action
            switch( action )
            {
                case Structure_Map_Checksum_Form_Action_Enum.CLEAR_CHECKSUMS:
                    BibDivInfo.Clear_Checksums();
                    MessageBox.Show("Cleared all existing checksums.     ", "Checksums Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    base.OnDataChanged();
                    break;

                case Structure_Map_Checksum_Form_Action_Enum.CALCULATE_CHECKSUMS:
                    Checksum_Calculator calculator = new Checksum_Calculator(BibDivInfo, true);
                    calculator.Complete += calculator_Complete;
                    checksumThread = new Thread( calculator.Process);
                    checksumThread.Start();
                    break;
            }
        }

        void calculator_Complete(string task, int current_value, int maximum_value)
        {
            MessageBox.Show("Calculated all checksums.     ", "Checksums Calculated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            base.OnDataChanged();
        }

        void add_files_button_Button_Pressed(object sender, EventArgs e)
        {
            // What sub-action is requested?
            Structure_Map_Add_File_Form subActionForm = new Structure_Map_Add_File_Form();
            subActionForm.ShowDialog();
            Structure_Map_Add_File_Form_Action_Enum action = subActionForm.Selected_Action;

            // Perform the requested action
            switch ( action )
            {
                case Structure_Map_Add_File_Form_Action_Enum.ADD_LOCAL:
                    add_local_files();
                    break;

                case Structure_Map_Add_File_Form_Action_Enum.ADD_REMOTE:
                    add_remote_files();
                    break;
            }
        }

        private void add_remote_files()
        {
            // Get the list of files to add
            Structure_Map_Add_Remote_File_Form addFiles = new Structure_Map_Add_Remote_File_Form();
            addFiles.ShowDialog();
            List<string> filesToAdd = addFiles.Files_To_Add;
            if (filesToAdd.Count > 0)
            {
                int files_added = 0;
                int pages_added = 0;

                // Get the list of all divisions and page nodes (with attached files)
                List<abstract_TreeNode> allDivs = BibDivInfo.Physical_Tree.Divisions_PreOrder;

                // Get the list of selected files
                foreach (string thisFile in filesToAdd)
                {
                    // Create the file object, so we can use it we need to
                    SobekCM_File_Info newMetsFile = new SobekCM_File_Info(thisFile);
                    string filename = newMetsFile.File_Name_Sans_Extension;
                    string extension = newMetsFile.File_Extension;

                    // Is this an image file?
                    if ((extension == "TIF") || (extension == "TIFF") || (extension == "JPG") || (extension == "JPEG") ||
                        (extension == "GIF") || (extension == "JP2") || (extension == "JPX") || (extension == "TXT") ||
                        (extension == "PRO"))
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
                                Page_TreeNode pageNode = (Page_TreeNode) thisNode;
                                foreach (SobekCM_File_Info existingFile in pageNode.Files)
                                {
                                    // Does this system name match the filename?
                                    if (existingFile.System_Name.ToUpper().IndexOf(filename + ".") == 0)
                                    {
                                        page_found = true;
                                        if (existingFile.System_Name.ToUpper() == filename + "." + extension)
                                        {
                                            file_found = true;
                                            break;
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
                                        base.OnDataChanged();
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
                            ((Division_TreeNode) BibDivInfo.Physical_Tree.Roots[0]).Nodes.Add(newPage);
                            files_added++;
                            pages_added++;
                            base.OnDataChanged();
                            allDivs = BibDivInfo.Physical_Tree.Divisions_PreOrder;
                        }
                    }
                    else
                    {
                        BibDivInfo.Download_Tree.Add_File(thisFile);
                        files_added++;
                        base.OnDataChanged();
                    }
                }

                // Clear all the child nodes
                treeView.Nodes[0].Nodes.Clear();
                treeView.Nodes[1].Nodes.Clear();

                // Add all the child nodes
                populate_treeview(BibDivInfo);
            }
        }

        private void add_local_files()
        {
            if ((directory.Length > 0) && (Directory.Exists(directory)))
            {
                addFilesDialog.InitialDirectory = directory;
                string[] files = Directory.GetFiles(directory);
                SortedList<string, string> extensions = new SortedList<string, string>();
                foreach (string thisFile in files)
                {
                    FileInfo thisFileInfo = new FileInfo(thisFile);
                    string extension = thisFileInfo.Extension.ToLower();
                    if (!extensions.ContainsKey(extension))
                        extensions[extension] = extension;
                }

                // Also check for thumbnail images
                if (Directory.GetFiles(directory, "*thm.jpg").Length > 0)
                {
                    extensions[".jpgTHUMBNAIL!!!"] = ".jpgTHUMBNAIL!!!";
                }

                StringBuilder filterBuilder = new StringBuilder("All files|*.*");
                foreach (string extension in extensions.Values)
                {
                    if (extension.Length > 1)
                    {
                        switch (extension)
                        {
                            case ".jpgTHUMBNAIL!!!":
                                filterBuilder.Append("|JPEG Thumbnails|*thm.jpg");
                                break;

                            default:
                                filterBuilder.Append("|" + extension.Substring(1).ToUpper() + " files|*" + extension);
                                break;
                        }
                    }
                }
                addFilesDialog.Filter = filterBuilder.ToString();
            }
            else
            {
                addFilesDialog.Filter = "All files|*.*|TIF files|*.tif;*.tiff";
            }

            DialogResult result = addFilesDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                int files_added = 0;
                int pages_added = 0;
                if (Structure_Map_Element_Helper.add_local_files(addFilesDialog.FileNames, BibDivInfo, directory, ref pages_added, ref files_added))
                    base.OnDataChanged();


                // Clear all the child nodes
                treeView.Nodes[0].Nodes.Clear();
                treeView.Nodes[1].Nodes.Clear();

                // Add all the child nodes
                populate_treeview(BibDivInfo);

                // Show message
                if (files_added > 0)
                {
                    if (pages_added == 0)
                    {
                        MessageBox.Show(Number_to_string(files_added, "file was", "files were") + " added to this resource.      ", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Number_to_string(files_added, "file", "files") + " and " + Number_to_string(pages_added, "page", "pages").ToLower() + " were added to this resource.      ", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No files were added to this resource.\n\nAll selected files may already have existed.    ", "No files added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static string Number_to_string(int value, string singular_suffix, string plural_suffix )
        {
            switch (value)
            {
                case 0:
                    return "No " + plural_suffix;

                case 1:
                    return "One " + singular_suffix;

                case 2:
                    return "Two " + plural_suffix;

                case 3:
                    return "Three " + plural_suffix;

                case 4:
                    return "Four " + plural_suffix;

                case 5:
                    return "Five " + plural_suffix;

                case 6:
                    return "Six " + plural_suffix;

                case 7:
                    return "Seven " + plural_suffix;

                case 8:
                    return "Eight " + plural_suffix;

                case 9:
                    return "Nine " + plural_suffix;

                case 10:
                    return "Ten " + plural_suffix;

                default:
                    return value.ToString() + " " + plural_suffix;      
            }
        }

        #endregion

        public Template_Panel TemplatePanel
        {
            set { templatePanel = value; }
        }

        public ImageList ImageList
        {
            set	{		treeView.ImageList = value;		}
        }

        #region Methods Implementing the Abstract Methods from abstract_Element class

        /// <summary> Checks the data in this element for validity. </summary>

        /// <returns> TRUE if valid, otherwise FALSE </returns>
        /// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
        public override bool isValid()
        {
            // Read only, so always true
            return true;
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save( SobekCM_Item Bib )
        {
            // Do nothing
        }


        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib( SobekCM_Item Bib )
        {
            // Save back all the file and division information
            Bib.Divisions.Clear();

            // Copy over the outer divisions 
            if (BibDivInfo.Outer_Division_Count > 0)
            {
                foreach (Outer_Division_Info thisInfo in BibDivInfo.Outer_Divisions)
                {
                    Bib.Divisions.Add_Outer_Division(thisInfo.Label, thisInfo.OrderLabel, thisInfo.Type);
                }
            }

            // Step through each node
            if (treeView.Nodes.Count > 0)
            {
                foreach (TreeNode treeDivNode in treeView.Nodes[0].Nodes)
                {
                    if (((abstract_TreeNode)treeDivNode.Tag).Page)
                    {
                        // Get the old page node
                        Page_TreeNode oldPage = (Page_TreeNode)treeDivNode.Tag;

                        // Create a new page node
                        Page_TreeNode newBibNode = new Page_TreeNode( oldPage.Label );
                        Bib.Divisions.Physical_Tree.Roots.Add(newBibNode);

                        // Now, add each file
                        foreach (SobekCM_File_Info oldFile in oldPage.Files)
                        {
                            // Create the new file object
                            SobekCM_File_Info newFile = new SobekCM_File_Info(oldFile.System_Name);
                            newFile.Checksum = oldFile.Checksum;
                            newFile.Checksum_Type = oldFile.Checksum_Type;
                            newFile.Height = oldFile.Height;
                            newFile.Width = oldFile.Width;
                            newFile.Size = oldFile.Size;

                            // Add this to the new page
                            newBibNode.Files.Add(newFile);
                        }
                    }
                    else
                    {
                        // Get the old div node out
                        Division_TreeNode bibDivNode = (Division_TreeNode)treeDivNode.Tag;

                        // Create a new div node
                        Division_TreeNode newBibNode = new Division_TreeNode(bibDivNode.Type, bibDivNode.Label);
                        Bib.Divisions.Physical_Tree.Roots.Add(newBibNode);

                        // Now, add all the pages and sub divisions
                        add_divs_and_pages(Bib, newBibNode, treeDivNode );
                    }
                }
            }

            if (treeView.Nodes.Count > 1)
            {
                foreach (TreeNode treeDivNode in treeView.Nodes[1].Nodes)
                {
                    if (((abstract_TreeNode)treeDivNode.Tag).Page)
                    {
                        // Get the old page node
                        Page_TreeNode oldPage = (Page_TreeNode)treeDivNode.Tag;

                        // Create a new page node
                        Page_TreeNode newBibNode = new Page_TreeNode(oldPage.Label);
                        Bib.Divisions.Download_Tree.Roots.Add(newBibNode);

                        // Now, add each file
                        foreach (SobekCM_File_Info oldFile in oldPage.Files)
                        {
                            // Create the new file object
                            SobekCM_File_Info newFile = new SobekCM_File_Info(oldFile.System_Name);
                            newFile.Checksum = oldFile.Checksum;
                            newFile.Checksum_Type = oldFile.Checksum_Type;
                            newFile.Height = oldFile.Height;
                            newFile.Width = oldFile.Width;
                            newFile.Size = oldFile.Size;

                            // Add this to the new page
                            newBibNode.Files.Add(newFile);
                        }
                    }
                    else
                    {
                        // Get the old div node out
                        Division_TreeNode bibDivNode = (Division_TreeNode)treeDivNode.Tag;

                        // Create a new div node
                        Division_TreeNode newBibNode = new Division_TreeNode(bibDivNode.Type, bibDivNode.Label);
                        Bib.Divisions.Download_Tree.Roots.Add(newBibNode);

                        // Now, add all the pages and sub divisions
                        add_divs_and_pages(Bib, newBibNode, treeDivNode);
                    }
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib( SobekCM_Item Bib )
        {
            // Save the directory for this bib as well
            directory = Bib.Source_Directory;

            // Save this information
            BibDivInfo = Bib.Divisions;

            // Clear all the old elements
            treeView.Nodes.Clear();
            treeView.BeginUpdate();

            // Add the page images node
            TreeNode mainNode = new TreeNode( pageFilesString );
            mainNode.ImageIndex = 0;
            treeView.Nodes.Add( mainNode );

            // Add the resource files node
            additionalNode = new TreeNode( resourceFilesString );
            additionalNode.ImageIndex = 0;
            treeView.Nodes.Add(additionalNode);

            // Add all the child nodes
            populate_treeview(Bib.Divisions);

            // Expand the tree and select the first node
            treeView.Nodes[0].Expand();
            treeView.SelectedNode = treeView.Nodes[0];
            treeView.Nodes[1].Expand();

            treeView.EndUpdate();
        }

        /// <summary> Gets the flag indicating this element has an entered value </summary>
        public override bool hasValue
        {
            get
            {
                return true;
            }
        }

        /// <summary> Reads the inner data from the Template XML format </summary>
        protected override void Inner_Read_Data( XmlTextReader xmlReader )
        {

        }

        /// <summary> Writes the inner data into Template XML format </summary>
        protected override string Inner_Write_Data( )
        {
            return String.Empty;
        }

        /// <summary> Perform any height setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Height( float new_size )
        {
            //this.Height = 380;	
        }

        /// <summary> Perform any width setting calculations specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Width( int new_width )
        {
            position_boxes();
        }

        private void position_boxes()
        {

            treeView.Width = Width - 15;

            if (base.read_only)
            {
                treeView.Height = Height;
            }
            else
            {
                treeView.Height = Height - 50;
            }
        }

        /// <summary> Perform any readonly functions specific to the
        /// implementation of abstract_Element. </summary>
        protected override void Inner_Set_Read_Only()
        {
            if (base.read_only)
            {
                treeView.AllowDrop = false;
                treeView.Height = Height;
                treeView.Location = new Point(0, 0);
                if (Controls.Contains(add_files_button))
                    Controls.Remove(add_files_button);
            }
            else
            {
                treeView.AllowDrop = true;
                treeView.Height = Height-50;
                treeView.Location = new Point(0, 50);
                if (!Controls.Contains(add_files_button))
                    Controls.Add(add_files_button);
            }
        }

        /// <summary> Clones this element, not copying the actual data
        /// in the fields, but all other values. </summary>
        /// <returns>Clone of this element</returns>
        public override abstract_Element Clone()
        {
            // This will never be repeatable
            return null;
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language( Template_Language newLanguage )
        {
            // Create a hashtable to look up the division type translations
            Hashtable typeNames = new Hashtable();

            // Set the division names
            switch (newLanguage)
            {
                case Template_Language.English:
                    foreach ( Division_Types_Errors_Table.Division_TypeRow thisDivision in divType )
                    {
                        thisDivision.TypeName = thisDivision.English;

                        typeNames[ thisDivision.English ] = thisDivision.English;

                    }
                    pageString = "Page";
                    editDivMI.Text = "Edit Division";
                    editPageMI.Text = "Edit Page Label";
                    parentMI.Text = "Add new Parent Division";
                    insertMI.Text = "Add new Sibling Division";
                    childMI.Text = "Add new Child Division";
                    deleteMI.Text = "Delete";
                    copyMI.Text = "Copy Page";
                    expandMI.Text = "Expand To All Page Nodes";
                    collapseMI.Text = "Collapse All Nodes";
                    viewMI.Text = "View File";
                    moveUpMI.Text = "Move Up";
                    moveOverMI.Text = "Move Over";
                    moveDownMI.Text = "Move Down";

                    add_files_button.Button_Text = "ADD FILES";
                    add_files_button.Location = new Point(25, 10);
                    add_files_button.Size = new Size(100, 26);
                    checksums_button.Button_Text = "CHECKSUMS";
                    checksums_button.Location = new Point(149, 10);
                    checksums_button.Size = new Size(100, 26);
                    pageFilesString = "Page Images";
                    resourceFilesString = "Resource Files";
                    pageString = "Page";
                    fileString = "Files";
                    break;

                case Template_Language.Spanish:
                    foreach (Division_Types_Errors_Table.Division_TypeRow thisDivision in divType)
                    {
                        thisDivision.TypeName = thisDivision.Spanish;
                        typeNames[ thisDivision.English ] = thisDivision.Spanish;
                    }
                    editDivMI.Text = "Corregir la División";
                    editPageMI.Text = "Corregir la Página";
                    parentMI.Text = "Agregar a Nuevo Padre";
                    insertMI.Text = "Insertar a Nuevo Hermano";
                    childMI.Text = "Agregar a Nuevo Niño";
                    deleteMI.Text = "Cancelación";
                    copyMI.Text = "Página Duplicada";
                    expandMI.Text = "Ampliar Todos los Nodos";
                    collapseMI.Text = "Se Derrumban Todos los Nodos";
                    viewMI.Text = "Ver el Archivo";
                    moveUpMI.Text = "Mirar Hacia Arriba";
                    moveOverMI.Text = "Mirar Hacia la Izquierda";
                    moveDownMI.Text = "Mirar Hacia Abajo";

                    add_files_button.Button_Text = "Añadir Archivos";
                    add_files_button.Location = new Point(25, 10);
                    add_files_button.Size = new Size(134, 26);
                    checksums_button.Button_Text = "Las Sumas de Comprobación";
                    checksums_button.Location = new Point(174, 10);
                    checksums_button.Size = new Size(255, 26);
                    pageFilesString = "Página de Imágenes";
                    resourceFilesString = "Archivos de Recursos";
                    pageString = "Página";
                    fileString = "Archivos";
                    break;

                case Template_Language.French:
                    foreach (Division_Types_Errors_Table.Division_TypeRow thisDivision in divType)
                    {
                        thisDivision.TypeName = thisDivision.French;

                        typeNames[ thisDivision.English ] = thisDivision.French;

                    }
                    editDivMI.Text = "Éditer la Division";
                    editPageMI.Text = "Éditer la Page";
                    parentMI.Text = "Ajouter Division Nouveau Parent";
                    insertMI.Text = "Insérer l'enfant de Mêmes Parents";
                    childMI.Text = "Ajouter Division Nouvel Enfant";
                    deleteMI.Text = "Effacement";
                    copyMI.Text = "Page Double";
                    expandMI.Text = "Augmenter Tous les Noeuds";
                    collapseMI.Text = "S'effondrent Tous les Noeuds";
                    viewMI.Text = "Dossier de Vue";
                    moveUpMI.Text = "Déplace vers le haut";
                    moveOverMI.Text = "Déplace vers la gauche";
                    moveDownMI.Text = "Déplace vers la bas";

                    add_files_button.Button_Text = "Ajouter des Fichiers";
                    add_files_button.Location = new Point(25, 10);
                    add_files_button.Size = new Size(154, 26);
                    checksums_button.Button_Text = "Les Sommes de Contrôle";
                    checksums_button.Location = new Point(194, 10);
                    checksums_button.Size = new Size(225, 26);
                    pageFilesString = "Images de la Page";
                    resourceFilesString = "Fichiers de Ressources";
                    pageString = "Page";
                    fileString = "Fichiers";
                    break;
                default:
                    foreach ( Division_Types_Errors_Table.Division_TypeRow thisDivision in divType)
                    {
                        thisDivision.TypeName = thisDivision.English;
                        pageString = "Page";
                        typeNames[ thisDivision.English ] = thisDivision.English;
                    }
                    break;
            }

            // Now, retitle all the division nodes to match the new language
            if (treeView.Nodes.Count > 0)
            {
                foreach (TreeNode thisNode in treeView.Nodes[0].Nodes)
                {
                    recompute_division_names(thisNode, typeNames );
                }
                treeView.Invalidate();
            }
        }

        private void recompute_division_names( TreeNode thisNode, Hashtable typeNames )
        {
            // Only continue if this is a division
            if ((thisNode.Tag != null) && (thisNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.Division_TreeNode"))
            {
                // Get the UFDC Package division information
                Division_TreeNode divNode = (Division_TreeNode)thisNode.Tag;

                // Compute the type in this language
                string languageTypeName = divNode.Type;
                if (typeNames.ContainsKey(divNode.Type))
                    languageTypeName = typeNames[divNode.Type].ToString();

                // Recreate the text
                if (divNode.Label.Length > 0)
                {
                    thisNode.Text = languageTypeName + " : '" + divNode.Label + "'";
                }
                else
                {
                    thisNode.Text = languageTypeName;
                }

                // Check for any subdivisions
                foreach (TreeNode childNode in thisNode.Nodes)
                {
                    recompute_division_names(childNode, typeNames);
                }
            }
        }

        /// <summary> Set the minimum title length specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
        {
            // No title for element.. use the panel for title
        }

        private void add_divs_and_pages(SobekCM_Item Bib, Division_TreeNode bibNode, TreeNode treeNode )
        {
            foreach (TreeNode treeDivNode in treeNode.Nodes)
            {
                // Get the old bib node out
                abstract_TreeNode oldBibNode = (abstract_TreeNode)treeDivNode.Tag;

                // Is this a page or a division?
                if (oldBibNode.Page)
                {
                    // Get the old page node
                    Page_TreeNode oldPage = (Page_TreeNode)treeDivNode.Tag;

                    // Create a new page node
                    Page_TreeNode newBibNode = new Page_TreeNode(oldPage.Label);
                    bibNode.Nodes.Add(newBibNode);

                    // Now, add each file
                    foreach (SobekCM_File_Info oldFile in oldPage.Files)
                    {
                        // Create the new file object
                        SobekCM_File_Info newFile = new SobekCM_File_Info(oldFile.System_Name);
                        newFile.Checksum = oldFile.Checksum;
                        newFile.Checksum_Type = oldFile.Checksum_Type;
                        newFile.Height = oldFile.Height;
                        newFile.Width = oldFile.Width;
                        newFile.Size = oldFile.Size;

                        // Add this to the new page
                        newBibNode.Files.Add(newFile);
                    }
                }
                else
                {
                    // Get the old div node out
                    Division_TreeNode bibDivNode = (Division_TreeNode)treeDivNode.Tag;

                    // Create a new div node
                    Division_TreeNode newBibNode = new Division_TreeNode(bibDivNode.Type, bibDivNode.Label);
                    bibNode.Nodes.Add(newBibNode);

                    // Now, add all the pages and sub divisions
                    add_divs_and_pages(Bib, newBibNode, treeDivNode);
                }
            }
        }


        private void populate_treeview(Division_Info divisionInfo)
        {
            // Add each division from the physical structure map
            List<Page_TreeNode> pages_added = new List<Page_TreeNode>();
            foreach (abstract_TreeNode abstractNode in divisionInfo.Physical_Tree.Roots)
            {
                if (!abstractNode.Page)
                {
                    Division_TreeNode thisNode = (Division_TreeNode)abstractNode;

                    // Compute the type in this language
                    DataRow[] typeNames = divType.Select("English='" + thisNode.Type + "'");
                    string languageTypeName = thisNode.Type;
                    if (typeNames.Length > 0)
                    {
                        languageTypeName = typeNames[0]["TypeName"].ToString();
                    }

                    // Add a root node to this tree
                    TreeNode rootNode = null;
                    if (thisNode.Label.Length > 0)
                    {
                        rootNode = new TreeNode(languageTypeName + " : '" + thisNode.Label + "'");
                    }
                    else
                    {
                        rootNode = new TreeNode(languageTypeName);
                    }

                    if (thisNode.Type.IndexOf("Subdivision") >= 0)
                    {
                        rootNode.ImageIndex = 7;
                        rootNode.SelectedImageIndex = 7;
                    }
                    else
                    {
                        rootNode.ImageIndex = 2;
                        rootNode.SelectedImageIndex = 2;
                    }
                    rootNode.Tag = thisNode;
                    treeView.Nodes[0].Nodes.Add(rootNode);

                    // Recurse through all the child nodes
                    foreach (abstract_TreeNode childNode in thisNode.Nodes)
                    {
                        recurse_through_nodes(childNode, rootNode, pages_added, "Page");
                    }
                }
                else
                {
                    // A page was at the top level!  Just add it
                    recurse_through_nodes(abstractNode, treeView.Nodes[0], pages_added, "Page");
                }
            }

            // Also add the additional files tree node if there should be one
            if (divisionInfo.Download_Tree.Has_Files)
            {
                // Add each division from the physical structure map
                pages_added.Clear();
                foreach (abstract_TreeNode abstractNode in divisionInfo.Download_Tree.Roots)
                {
                    if (!abstractNode.Page)
                    {
                        Division_TreeNode thisNode = (Division_TreeNode)abstractNode;

                        // Compute the type in this language
                        DataRow[] typeNames = divType.Select("English='" + thisNode.Type + "'");
                        string languageTypeName = thisNode.Type;
                        if (typeNames.Length > 0)
                        {
                            languageTypeName = typeNames[0]["TypeName"].ToString();
                        }

                        // Add a root node to this tree
                        TreeNode rootNode = null;
                        if (thisNode.Label.Length > 0)
                        {
                            rootNode = new TreeNode(languageTypeName + " : '" + thisNode.Label + "'");
                        }
                        else
                        {
                            rootNode = new TreeNode(languageTypeName);
                        }

                        if (thisNode.Type.IndexOf("Subdivision") >= 0)
                        {
                            rootNode.ImageIndex = 7;
                            rootNode.SelectedImageIndex = 7;
                        }
                        else
                        {
                            rootNode.ImageIndex = 2;
                            rootNode.SelectedImageIndex = 2;
                        }
                        rootNode.Tag = thisNode;
                        treeView.Nodes[1].Nodes.Add(rootNode);

                        // Recurse through all the child nodes
                        foreach (abstract_TreeNode childNode in thisNode.Nodes)
                        {
                            recurse_through_nodes(childNode, rootNode, pages_added, "Files");
                        }
                    }
                    else
                    {
                        // A page was at the top level!  Just add it
                        recurse_through_nodes(abstractNode, treeView.Nodes[1], pages_added, "Files");
                    }
                }
            }

        }


        private void recurse_through_nodes(abstract_TreeNode childNode, TreeNode parentNode, List<Page_TreeNode> pages_added, string Default_Page_Name )
        {
            // Is this a page or another division?
            if ( childNode.Page )
            {
                // Get the page node
                Page_TreeNode pageNode = ( Page_TreeNode) childNode;

                // Is this page already added?
                TreeNode newNode = null;
                if (pages_added.Contains(pageNode))
                {
                    // Add this as a copy of page
                    if (childNode.Label.Length > 0)
                    {
                        newNode = new TreeNode("Copy of " + Default_Page_Name + " : '" + childNode.Label + "'");
                    }
                    else
                    {
                        newNode = new TreeNode("Copy of " + Default_Page_Name);
                    }
                }
                else
                {
                    // Add this as a page
                    if (childNode.Label.Length > 0)
                    {
                        newNode = new TreeNode(Default_Page_Name + " : '" + childNode.Label + "'");
                    }
                    else
                    {
                        newNode = new TreeNode(Default_Page_Name);
                    }
                    pages_added.Add(pageNode);
                }

                if (childNode.Label.IndexOf("(MULTIPLE)") > 0)
                {
                    newNode.ImageIndex = 6;
                    newNode.SelectedImageIndex = 6;
                }
                else
                {
                    newNode.ImageIndex = 4;
                    newNode.SelectedImageIndex = 4;
                }
                newNode.Tag = pageNode;
                parentNode.Nodes.Add( newNode );

                // Also, add each file under that
                foreach( SobekCM_File_Info thisFile in pageNode.Files )
                {
                    TreeNode fileNode = new TreeNode( thisFile.System_Name );
                    fileNode.ImageIndex = 5;
                    fileNode.SelectedImageIndex = 5;
                    fileNode.Tag = thisFile;
                    newNode.Nodes.Add( fileNode );
                }
            }
            else
            {
                // Compute the type in this language
                DataRow[] typeNames = divType.Select("English='" + childNode.Type + "'");
                string languageTypeName = childNode.Type;
                if (typeNames.Length > 0)
                {
                    languageTypeName = typeNames[0]["TypeName"].ToString();
                }

                // Add a root node to this tree
                TreeNode newNode = null;
                if ( childNode.Label.Length > 0 )
                {
                    newNode = new TreeNode(languageTypeName + " : '" + childNode.Label + "'");
                }
                else
                {
                    newNode = new TreeNode(languageTypeName);
                }
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                newNode.Tag = childNode;
                parentNode.Nodes.Add( newNode );

                // Recurse through all the child nodes
                foreach( abstract_TreeNode newChildNode in (( Division_TreeNode ) childNode).Nodes )
                {
                    recurse_through_nodes(newChildNode, newNode, pages_added, Default_Page_Name);
                }
            }
        }

        #endregion

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "toc";
        }

        public 

        #region Tree View Events

        void treeView_DragComplete(object sender, DragCompleteEventArgs e)
        {
            base.OnDataChanged();
        }

        private void treeViewDragDrop1_DragStart(object sender, DragItemEventArgs e)
        {
            // Example of stopping drag and drop based on the 
            // node being dragged.
            if ((base.read_only) || (e.Node == treeView.Nodes[0]) || ((e.Node.Tag != null) && (e.Node.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")))
            {
                treeView.Cancel_Move_Mode(e.Node);
            }
            else
            {
                treeView.AllowDrop = true;
            }
        }

        void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Nodes.Count == 0) && (e.Node.Tag != null) && ((e.Node.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")))
            {
                
                string file = treeView.SelectedNode.Text;
                if (( file.IndexOf("http:") < 0 ) && ( file.IndexOf("\\\\") != 0 ))
                    file = directory + "\\" + file;

                if ((File.Exists(file)) || (file.IndexOf("http:") >= 0))
                {
                    Process showFile = new Process();
                    showFile.StartInfo = new ProcessStartInfo(file);
                    showFile.Start();
                }
                else
                {
                    MessageBox.Show("File does not exist.         ", "View File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = e.Node;
            }
        }

        #endregion

        public void tabPagePanel_Resize(object sender, EventArgs e)
        {
            if (templatePanel != null)
            {
                int panelWidth = ((Panel)sender).Width;
                templatePanel.Width = panelWidth - 10;
                int panelHeight = ((Panel)sender).Height;
                templatePanel.Height = panelHeight - 20;
            }
        }

        /// <summary> Override the OnPaint method to draw the title before the text box </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call this for the base
            base.OnPaint (e);
        }

        #region Context Menu Events

        #region Context Menu Setup

        void contextMenu_Popup(object sender, EventArgs e)
        {
            // Is there a selected node?
            if ((treeView.SelectedNode != null) && (treeView.SelectedNode.Tag != null))
            {
                // Is this a page or division, or rather a file?
                string type = treeView.SelectedNode.Tag.GetType().ToString();
                if (type == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")
                {
                    seperatorMI.Visible = true;
                    insertMI.Visible = false;
                    editPageMI.Visible = false;
                    editDivMI.Visible = false;
                    deleteMI.Visible = true;
                    deleteMI.Enabled = true;
                    excludeMI.Visible = true;
                    copyMI.Visible = false;
                    viewMI.Visible = true;
                    childMI.Visible = false;
                    parentMI.Visible = false;
                    moveDownMI.Visible = false;
                    moveOverMI.Visible = false;
                    moveUpMI.Visible = false;
                    seperatorMI2.Visible = false;

                    // Visible is selectable only if it exists
                    string file = directory + "\\" + treeView.SelectedNode.Text;
                    if (!File.Exists(file))
                        viewMI.Enabled = false;
                    else
                        viewMI.Enabled = true;
                }
                else
                {
                    if (((abstract_TreeNode)treeView.SelectedNode.Tag).Page)
                    {
                        viewMI.Visible = false;
                        childMI.Visible = false;
                        insertMI.Visible = false;
                        editDivMI.Visible = false;
                        moveOverMI.Visible = false;
                        excludeMI.Visible = false;

                        if (base.read_only)
                        {
                            seperatorMI.Visible = false;
                            editPageMI.Visible = false;
                            deleteMI.Visible = false;
                            copyMI.Visible = false;
                            moveDownMI.Visible = false;
                            moveUpMI.Visible = false;
                            seperatorMI2.Visible = false;
                            parentMI.Visible = false;

                        }
                        else
                        {
                            seperatorMI.Visible = true;
                            editPageMI.Visible = true;
                            deleteMI.Visible = true;
                            copyMI.Visible = true;
                            moveUpMI.Visible = true;
                            moveDownMI.Visible = true;
                            seperatorMI2.Visible = true;
                            parentMI.Visible = true;

                            if (treeView.SelectedNode.Index > 0)
                                moveUpMI.Enabled = true;
                            else
                                moveUpMI.Enabled = false;

                            if (treeView.SelectedNode.Index < treeView.SelectedNode.Parent.Nodes.Count - 1)
                                moveDownMI.Enabled = true;
                            else
                                moveDownMI.Enabled = false;

                            seperatorMI2.Visible = true;

                            // Enable or disable the delete
                            deleteMI.Enabled = true;
                        }
                    }
                    else
                    {
                        copyMI.Visible = false;
                        viewMI.Visible = false;
                        editPageMI.Visible = false;
                        excludeMI.Visible = false;

                        if (base.read_only)
                        {
                            seperatorMI.Visible = false;
                            editDivMI.Visible = false;
                            insertMI.Visible = false;
                            deleteMI.Visible = false;
                            childMI.Visible = false;
                            parentMI.Visible = false;
                            moveDownMI.Visible = false;
                            moveOverMI.Visible = false;
                            moveUpMI.Visible = false;
                            seperatorMI2.Visible = false;
                        }
                        else
                        {
                            seperatorMI.Visible = true;
                            insertMI.Visible = true;
                            editDivMI.Visible = true;
                            deleteMI.Visible = true;
                            childMI.Visible = true;
                            parentMI.Visible = true;
                            seperatorMI2.Visible = true;
                            moveOverMI.Visible = true;
                            moveUpMI.Visible = true;
                            moveDownMI.Visible = true;

                            if (treeView.SelectedNode.Parent.Tag != null)
                                moveOverMI.Enabled = true;
                            else
                                moveOverMI.Enabled = false;

                            if (treeView.SelectedNode.Index > 0)
                                moveUpMI.Enabled = true;
                            else
                                moveUpMI.Enabled = false;
                            if (treeView.SelectedNode.Index < treeView.SelectedNode.Parent.Nodes.Count - 1)
                                moveDownMI.Enabled = true;
                            else
                                moveDownMI.Enabled = false;

                            // Only allow delete if there are no subs
                            if (treeView.SelectedNode.Nodes.Count > 0)
                                deleteMI.Enabled = false;
                            else
                                deleteMI.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                seperatorMI.Visible = false;
                editPageMI.Visible = false;
                editDivMI.Visible = false;
                insertMI.Visible = false;
                deleteMI.Visible = false;
                excludeMI.Visible = false;
                copyMI.Visible = false;
                viewMI.Visible = false;
                childMI.Visible = false;
                parentMI.Visible = false;
                moveDownMI.Visible = false;
                moveOverMI.Visible = false;
                moveUpMI.Visible = false;
                seperatorMI2.Visible = false;
            }
        }

        #endregion

        #region Tree-Related Events

        void deleteMI_Click(object sender, EventArgs e)
        {
            // If this is not selected, or nothing is tagged to the node, do nothing
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null))
                return;

            // Get the node
            TreeNode selected = treeView.SelectedNode;
                
            // If this is a file, ask to verify that the user wants to delete the file
            if (treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")
            {
                SobekCM_File_Info fileInfo = (SobekCM_File_Info)treeView.SelectedNode.Tag;
                DialogResult results = MessageBox.Show("Are you sure you would like to permanently delete this file?             \n\n\t" + fileInfo.System_Name, "Verify delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ( results == DialogResult.Yes )
                {
                    // Try to delete this file
                    if (( Directory.Exists( directory )) && ( File.Exists(directory + "\\" + fileInfo.System_Name)))
                    {
                        try
                        {
                            File.Delete(directory + "\\" + fileInfo.System_Name);
                        }
                        catch
                        {
                            MessageBox.Show("Error encountered while trying to delete the file!    ", "Error encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to find the file in the local directory to delete!    ", "Error encountered", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }

                    // Deal with the parent METS page as well
                    Page_TreeNode fileParent = (Page_TreeNode)selected.Parent.Tag;
                    fileParent.Files.Remove(fileInfo);

                    // Get the parent node
                    TreeNode parentNode = selected.Parent;

                    // Delete this node
                    parentNode.Nodes.Remove(selected);  
                 
                    // If this has no children nodes, remove it
                    if ((parentNode.Nodes.Count == 0) && ( parentNode.Parent != null ))
                    {
                        parentNode.Parent.Nodes.Remove(parentNode);
                    }

                    base.OnDataChanged();
                }

                // Done, so return
                return;
            }                

            // Cast to an abstract tree node
            abstract_TreeNode node = (abstract_TreeNode)treeView.SelectedNode.Tag;

            // If this is a division, make sure no subs
            if ((!node.Page) && (selected.Nodes.Count > 0))
                return;

            // Remove this node
            selected.Parent.Nodes.Remove(selected);

            base.OnDataChanged();
        }

        void moveOverMI_Click(object sender, EventArgs e)
        {
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) || (treeView.SelectedNode.Parent.Tag == null ))
                return;

            TreeNode moveNode = treeView.SelectedNode;
            TreeNode parentNode = moveNode.Parent;
            parentNode.Nodes.Remove(moveNode);
            int parentIndex = parentNode.Index;
            parentNode.Parent.Nodes.Insert(parentIndex, moveNode);
            moveNode.Collapse();
            treeView.SelectedNode = moveNode;
            base.OnDataChanged();
        }

        void moveDownMI_Click(object sender, EventArgs e)
        {
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) || (treeView.SelectedNode.Index == treeView.SelectedNode.Parent.Nodes.Count - 1))
                return;

            TreeNode moveNode = treeView.SelectedNode;
            TreeNode parentNode = moveNode.Parent;
            int index = moveNode.Index;
            parentNode.Nodes.Remove(moveNode);
            parentNode.Nodes.Insert(index + 1, moveNode);
            moveNode.Collapse();
            treeView.SelectedNode = moveNode;
            base.OnDataChanged();
        }

        void moveUpMI_Click(object sender, EventArgs e)
        {
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) || (treeView.SelectedNode.Index == 0 ))
                return;

            TreeNode moveNode = treeView.SelectedNode;
            TreeNode parentNode = moveNode.Parent;
            int index = moveNode.Index;
            parentNode.Nodes.Remove(moveNode);
            parentNode.Nodes.Insert(index - 1, moveNode);
            moveNode.Collapse();
            treeView.SelectedNode = moveNode;
            base.OnDataChanged();
        }

        void collapseMI_Click(object sender, EventArgs e)
        {
            Collapse_Tree();
        }

        private void Collapse_Tree()
        {
            if (treeView.Nodes.Count > 0)
            {
                treeView.CollapseAll();
                treeView.Nodes[0].Expand();
            }
        }

        void expandMI_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count > 0)
            {
                foreach (TreeNode mainNode in treeView.Nodes)
                {
                    mainNode.Expand();
                    foreach (TreeNode rootNodes in treeView.Nodes[0].Nodes)
                        recursively_expand(rootNodes);
                }
            }
        }

        void expandMI2_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count > 0)
            {
                foreach (TreeNode mainNode in treeView.Nodes)
                {
                    mainNode.ExpandAll();
                }
            }
        }

        void recursively_expand(TreeNode thisNode)
        {
            // Is this a division?
            string type = thisNode.Tag.GetType().ToString();
            if ((thisNode.Tag != null) && (type == "SobekCM.Resource_Object.Divisions.Division_TreeNode"))
            {
                thisNode.Expand();

                // Check each child
                foreach (TreeNode childNode in thisNode.Nodes)
                {
                    recursively_expand(childNode);
                }
            }
        }

        #endregion

        #region Division-Related Events

        void editDivMI_Click(object sender, EventArgs e)
        {
            if (( treeView.SelectedNode == null ) || ( treeView.SelectedNode.Tag == null ) || ( treeView.SelectedNode.Tag.GetType().ToString() != "SobekCM.Resource_Object.Divisions.Division_TreeNode"))
                return;

            // Save the selected node
            TreeNode editNode = treeView.SelectedNode;

            // Get the division object
            Division_TreeNode thisDiv = (Division_TreeNode) editNode.Tag;

            // Show the edit form
            Division_Name_Form divName = new Division_Name_Form(false, divType );
            divName.Division_Name = thisDiv.Label;
            divName.Division_Type = thisDiv.Type;
            DialogResult result = divName.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the new name and type
                thisDiv.Label = divName.Division_Name;
                thisDiv.Type = divName.Division_Type;

                // Change text of this node
                if (thisDiv.Label.Length > 0)
                {
                    editNode.Text = thisDiv.Type + " : '" + thisDiv.Label + "'";
                }
                else
                {
                    editNode.Text = thisDiv.Type;
                }

                // 
                if ((thisDiv.Type.IndexOf("Subdivision") >= 0) && ( editNode.Parent == treeView.Nodes[0] ))
                {
                    editNode.ImageIndex = 7;
                    editNode.SelectedImageIndex = 7;
                }
                else
                {
                    editNode.ImageIndex = 2;
                    editNode.SelectedImageIndex = 2;
                }

                base.OnDataChanged();
            }
        }

        void parentMI_Click(object sender, EventArgs e)
        {
            // If this is not a division or page, do nothing
            if ((treeView.SelectedNode == null) || ((treeView.SelectedNode.Tag != null) && (treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")))
                return;

            // If this is the top level node, shouldn't be able to add here
            if ( treeView.SelectedNode.Parent == null )
                return;

            // Get the selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Get the abstract tree node object
            abstract_TreeNode node = (abstract_TreeNode)treeView.SelectedNode.Tag;

            // Create the division object
            Division_TreeNode newDiv = new Division_TreeNode();

            // Create a new tree view node
            TreeNode newNode = new TreeNode("New Division");

            // Show the edit form
            Division_Name_Form divName = new Division_Name_Form(false, divType);
            divName.Division_Name = String.Empty;
            divName.Division_Type = "Chapter";
            DialogResult result = divName.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the new name and type
                newDiv.Label = divName.Division_Name;
                newDiv.Type = divName.Division_Type;

                // Change text of this node
                if (newDiv.Label.Length > 0)
                {
                    newNode.Text = newDiv.Type + " : '" + newDiv.Label + "'";
                }
                else
                {
                    newNode.Text = newDiv.Type;
                }

                // Set the index nodex
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                newNode.Tag = newDiv;

                // Now, insert this node
                TreeNode parentNode = selectedNode.Parent;
                int index = parentNode.Nodes.IndexOf( selectedNode );
                parentNode.Nodes.Insert( index, newNode );
                parentNode.Nodes.Remove( selectedNode );
                newNode.Nodes.Add( selectedNode );
                treeView.SelectedNode = newNode;
                base.OnDataChanged();
            }
        }

        void childMI_Click(object sender, EventArgs e)
        {
            // If this is not a division or page, do nothing
            if ((treeView.SelectedNode == null) || (( treeView.SelectedNode.Tag != null ) && ( treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")))
                return;

            // Get the node
            if (treeView.SelectedNode.Tag != null)
            {
                abstract_TreeNode node = (abstract_TreeNode)treeView.SelectedNode.Tag;
                if (node.Page)
                    return;
            }

            TreeNode addNode = treeView.SelectedNode;
            int index = addNode.Index;

            // Get the division object
            Division_TreeNode thisDiv = new Division_TreeNode();

            // Create a new tree view node
            TreeNode newNode = new TreeNode("New Division");

            // Show the edit form
            Division_Name_Form divName = new Division_Name_Form(false, divType );
            divName.Division_Name = String.Empty;
            divName.Division_Type = "Chapter";
            DialogResult result = divName.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the new name and type
                thisDiv.Label = divName.Division_Name;
                thisDiv.Type = divName.Division_Type;

                // Change text of this node
                if (thisDiv.Label.Length > 0)
                {
                    newNode.Text = thisDiv.Type + " : '" + thisDiv.Label + "'";
                }
                else
                {
                    newNode.Text = thisDiv.Type;
                }

                // Set the index nodex
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                newNode.Tag = thisDiv;
                addNode.Nodes.Insert(0, newNode);
                treeView.SelectedNode = newNode;
                base.OnDataChanged();
            }
        }


        void insertMI_Click(object sender, EventArgs e)
        {
            // If this is not a division or page, do nothing
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) ||
                (treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info"))
                return;

            // Get the node
            abstract_TreeNode node = (abstract_TreeNode)treeView.SelectedNode.Tag;
            TreeNode addNode = treeView.SelectedNode;
            int index = addNode.Index;

            // Make sure this is not a page
            if (node.Page)
                return;

            // Get the division object
            Division_TreeNode thisDiv = new Division_TreeNode();

            // Create a new tree view node
            TreeNode newNode = new TreeNode("New Division");

            // Show the edit form
            Division_Name_Form divName = new Division_Name_Form(false, divType);
            divName.Division_Name = String.Empty;
            divName.Division_Type = "Chapter";
            DialogResult result = divName.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the new name and type
                thisDiv.Label = divName.Division_Name;
                thisDiv.Type = divName.Division_Type;

                // Change text of this node
                if (thisDiv.Label.Length > 0)
                {
                    newNode.Text = thisDiv.Type + " : '" + thisDiv.Label + "'";
                }
                else
                {
                    newNode.Text = thisDiv.Type;
                }

                // Set the index nodex
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                newNode.Tag = thisDiv;
                addNode.Parent.Nodes.Insert(index + 1, newNode);
                treeView.SelectedNode = newNode;

                base.OnDataChanged();
            }
        }

        #endregion

        #region Page-Related Events

        void editPageMI_Click(object sender, EventArgs e)
        {
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) || (treeView.SelectedNode.Tag.GetType().ToString() != "SobekCM.Resource_Object.Divisions.Page_TreeNode"))
                return;

            // For this moment, make no layout changes occur
            treeView.BeginUpdate();

            // Save the selected node
            TreeNode editNode = treeView.SelectedNode;

            // Get the division object
            Page_TreeNode thisPage = (Page_TreeNode)editNode.Tag;

            // Show the edit form
            Page_Name_Form pageName = new Page_Name_Form();
            pageName.Page_Name = thisPage.Label;
            DialogResult result = pageName.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Save the new name and type
                if (thisPage.Label != pageName.Page_Name)
                {
                    // Determine if this is for files or pages
                    string defaultStartString = pageString;
                    TreeNode currentNode = editNode;
                    while (currentNode.Parent != null)
                        currentNode = currentNode.Parent;
                    if (treeView.Nodes.IndexOf(currentNode) != 0)
                        defaultStartString = fileString;

                    // If this is non-blank, continue
                    string newPagenation = pageName.Page_Name;
                    if (!newPagenation.Equals(String.Empty))
                    {
                        // If there was any delimiters, find the last split
                        string[] splitter = newPagenation.Split("_-. ".ToCharArray());
                        string final_part = splitter[splitter.Length - 1];

                        // Was this all number?
                        bool number = true;
                        bool roman = false;
                        int ascii;
                        foreach (char thisFinalChar in final_part)
                        {
                            // get the ascii for this 
                            ascii = Convert.ToInt32(thisFinalChar);

                            // If this is not a number, set to false and break out
                            if ((ascii < 48) || (ascii > 57))
                            {
                                number = false;
                                break;
                            }
                        }

                        // Was this a roman numeral between 1 and 10?
                        if (!number)
                        {
                            int Decimal_Value = Roman_Numeral_Counter.Roman_To_Decimal(final_part);
                            if (Decimal_Value > 0)
                            {
                                roman = true;
                            }
                        }

                        // Was this the entire part?  If so, create pagenation.
                        string pageFeature = String.Empty;
                        if ((final_part.Length == newPagenation.Length) && ((roman) || (number)))
                        {
                            pageFeature = defaultStartString + " ";
                        }
                        else
                        {
                            // Find the feature term used
                            pageFeature = newPagenation.Substring(0, newPagenation.Length - final_part.Length);
                        }

                        // Display the correct pagenation and change the new pagenation as well
                        string finalPagination = pageFeature + final_part;

                        // Assign the new page name
                        thisPage.Label = finalPagination;
                        editNode.Text = defaultStartString + " : '" + finalPagination + "'";

                        // Any automatic numbering selected?
                        if (((roman) || (number)) && (MetaTemplate_UserSettings.Automatic_Numbering != Automatic_Numbering_Enum.None))
                        {
                            // Determine the next new page number, and if this is a roman numeral, if it is in caps
                            int newPageNumber = -1;
                            bool caps = false;
                            if (number)
                            {
                                newPageNumber = (Convert.ToInt32(final_part)) + 1;
                            }
                            else
                            {
                                newPageNumber = Roman_Numeral_Counter.Roman_To_Decimal(final_part) + 1;
                                ascii = Convert.ToInt32(final_part[0]);
                                if (ascii < 90)
                                    caps = true;
                            }

                            // Go up to the parent only if this is in the same division
                            if (MetaTemplate_UserSettings.Automatic_Numbering == Automatic_Numbering_Enum.Division)
                            {
                                TreeNode parentNode = editNode.Parent;
                                if ((parentNode.Tag != null) && (!((abstract_TreeNode)parentNode.Tag).Page))
                                {
                                    int index = parentNode.Nodes.IndexOf(editNode);
                                    for (int i = index + 1; i < parentNode.Nodes.Count; i++)
                                    {
                                        TreeNode thisChildNode = parentNode.Nodes[i];

                                        // If not element or it is not a page, stop automatically numbering this division
                                        if ((thisChildNode.Tag == null) || (!((abstract_TreeNode)thisChildNode.Tag).Page))
                                            break;

                                        // Renumber the tree node and the underlying page node
                                        if (roman)
                                        {
                                            // Set this to the next page number
                                            thisChildNode.Text = defaultStartString + " : '" + pageFeature + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps) + "'";
                                            ((abstract_TreeNode)thisChildNode.Tag).Label = pageFeature + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps); 
                                        }
                                        else
                                        {
                                            // Set this to the next page number
                                            thisChildNode.Text = defaultStartString + " : '" + pageFeature + newPageNumber + "'";
                                            ((abstract_TreeNode)thisChildNode.Tag).Label = pageFeature + newPageNumber; 
                                        }
                                        newPageNumber++;
                                    }
                                }
                            }
                            else
                            {
                                recurse_renumber_up_divisions(editNode.Parent, editNode, ref newPageNumber, defaultStartString + " : '" + pageFeature, pageFeature, roman, caps);
                            }
                        }
                    }
                    else
                    {
                        thisPage.Label = String.Empty;
                        editNode.Text = defaultStartString;
                    }



                    base.OnDataChanged();
                }
            }

            // For this moment, make no layout changes occur
            treeView.EndUpdate();
        }

        private void recurse_renumber_up_divisions(TreeNode treeNode, TreeNode fromNode, ref int newPageNumber, string treeNodeLabelStart, string bibNodeLabelStart, bool roman, bool caps )
        {
            // If this node is null, then at the top of the tree, start back down and end
            if (treeNode == null)
            {
                return;
                //// THIS WOULD MAKE IT GO TO THE NEXT TREE VIEW ( Resource Files, for example )
                //int root_node_index = 0;
                //if ((fromNode != null) && ( treeView.Nodes.IndexOf(fromNode) >= 0))
                //    root_node_index = treeView.Nodes.IndexOf(fromNode);
                //for (int i = root_node_index + 1; i < treeView.Nodes.Count; i++)
                //{
                //    recurse_renumber_down_divisions( treeView.Nodes[i], ref newPageNumber, treeNodeLabelStart, bibNodeLabelStart, roman, caps);
                //}
                //return;
            }

            // Determine the start index
            int index = 0;
            if ((fromNode != null) && (treeNode.Nodes.IndexOf(fromNode) >= 0))
                index = treeNode.Nodes.IndexOf(fromNode);

            // Step through each child node of this tree node, before going up to the parent
            for (int i = index + 1; i < treeNode.Nodes.Count; i++)
            {
                // Get this tree node
                TreeNode childNode = treeNode.Nodes[i];

                // If nothing attached to this node, move on
                if ((childNode.Tag != null) && (!( childNode.Tag is SobekCM_File_Info )))
                {
                    // Get the tag
                    abstract_TreeNode childDivNode = (abstract_TreeNode)childNode.Tag;

                    // Is this a page?
                    if (childDivNode.Page)
                    {
                        // Renumber the tree node and the underlying page node
                        if (roman)
                        {
                            // Set this to the next page number
                            childNode.Text = treeNodeLabelStart + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps) + "'";
                            childDivNode.Label = bibNodeLabelStart + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps);
                        }
                        else
                        {
                            // Set this to the next page number
                            childNode.Text = treeNodeLabelStart + newPageNumber + "'";
                            childDivNode.Label = bibNodeLabelStart + newPageNumber;
                        }
                        newPageNumber++;
                    }
                    else
                    {
                        // This is a division, so now recurse DOWN this division
                        recurse_renumber_down_divisions(childNode, ref newPageNumber, treeNodeLabelStart, bibNodeLabelStart, roman, caps);
                    }
                }
            }

            // Recurse up to the parent of this node
            recurse_renumber_up_divisions(treeNode.Parent, treeNode, ref newPageNumber, treeNodeLabelStart, bibNodeLabelStart, roman, caps);
        }

        private void recurse_renumber_down_divisions(TreeNode treeNode, ref int newPageNumber, string treeNodeLabelStart, string bibNodeLabelStart, bool roman, bool caps)
        {
            // Step through each child node of this tree node
            for (int i = index; i < treeNode.Nodes.Count; i++)
            {
                // Get this tree node
                TreeNode childNode = treeNode.Nodes[i];

                // If nothing attached to this node, move on
                if ((childNode.Tag != null) && (!(childNode.Tag is SobekCM_File_Info)))
                {
                    // Get the tag
                    abstract_TreeNode childDivNode = (abstract_TreeNode)childNode.Tag;

                    // Is this a page?
                    if (childDivNode.Page)
                    {
                        // Renumber the tree node and the underlying page node
                        if (roman)
                        {
                            // Set this to the next page number
                            childNode.Text = treeNodeLabelStart + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps) + "'";
                            childDivNode.Label = bibNodeLabelStart + Roman_Numeral_Counter.Decimal_To_Roman(newPageNumber, caps);
                        }
                        else
                        {
                            // Set this to the next page number
                            childNode.Text = treeNodeLabelStart + newPageNumber + "'";
                            childDivNode.Label = bibNodeLabelStart + newPageNumber;
                        }
                        newPageNumber++;
                    }
                    else
                    {
                        // This is a division, so now recurse DOWN this division
                        recurse_renumber_down_divisions(childNode, ref newPageNumber, treeNodeLabelStart, bibNodeLabelStart, roman, caps);
                    }
                }
            }
        }

        private void relabel_all_nodes()
        {
            foreach (TreeNode thisNode in treeView.Nodes[0].Nodes)
            {
                recurse_relabel(thisNode, pageString);
            }
            foreach (TreeNode thisNode in treeView.Nodes[1].Nodes)
            {
                recurse_relabel(thisNode, fileString);
            }
        }

        private void recurse_relabel(TreeNode thisNode, string baseLabel )
        {

            // Get the SobekCM page node out
            if (thisNode.Tag is abstract_TreeNode)
            {
                abstract_TreeNode thisDiv = (abstract_TreeNode)thisNode.Tag;

                if (thisDiv.Page)
                {
                    Page_TreeNode thisPage = (Page_TreeNode)thisDiv;

                    // Change text of this node
                    string text = baseLabel;
                    if (thisPage.Label.Length > 0)
                    {
                        text = baseLabel + " : '" + thisPage.Label + "'";
                        thisNode.Text = baseLabel + " : '" + thisPage.Label + "'";
                    }
                    else
                    {
                        thisNode.Text = baseLabel;
                    }

                    // Set the image correctly
                    int imageIndex = 4;
                    if (thisPage.Label.IndexOf("(MULTIPLE)") >= 0)
                    {
                        imageIndex = 6;
                        thisNode.ImageIndex = 6;
                        thisNode.SelectedImageIndex = 6;
                    }
                    else
                    {
                        thisNode.ImageIndex = 4;
                        thisNode.SelectedImageIndex = 4;
                    }

                    //// Make sure any other matches also changes
                    //foreach (TreeNode node in treeView.Nodes[0].Nodes)
                    //{
                    //    fix_page_name(node, thisPage, text, imageIndex);
                    //}
                }

                // Recurse through children
                foreach (TreeNode childNodes in thisNode.Nodes)
                {
                    recurse_relabel(childNodes, baseLabel);
                }
            }
        }

        private void fix_page_name(TreeNode node, Page_TreeNode thisPage, string text, int imageIndex )
        {
            if (node.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.Page_TreeNode")
            {
                if (node.Tag == thisPage)
                {
                    node.Text = text;
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                }
            }
            else
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    fix_page_name(childNode, thisPage, text, imageIndex);
                }
            }
        }

        private void copyMI_Click(object sender, EventArgs e)
        {
            // If this is not a division or page, do nothing
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null) ||
                (treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info"))
                return;

            // Get the node
            abstract_TreeNode node = (abstract_TreeNode)treeView.SelectedNode.Tag;

            // Make sure this is a page
            if (!node.Page)
                return;

            // Convert to page node
            Page_TreeNode pageNode = (Page_TreeNode)node;
            base.OnDataChanged();

            // Add this as a page
            TreeNode newNode = null;
            if (node.Label.IndexOf("(MULTIPLE)") > 0)
            {
                node.Label = node.Label.Replace("(MULTIPLE)", "").Trim();
                treeView.SelectedNode.Text = "Page : '" + node.Label + "'";
                treeView.SelectedNode.ImageIndex = 4;
                treeView.SelectedNode.SelectedImageIndex = 4;
            }

            if (node.Label.Length > 0)
            {
                newNode = new TreeNode("Copy of Page : '" + node.Label + "'");
            }
            else
            {
                newNode = new TreeNode("Copy of Page");
            }
            newNode.ImageIndex = 4;
            newNode.SelectedImageIndex = 4;
            newNode.Tag = node;
            int index = treeView.SelectedNode.Index;
            treeView.SelectedNode.Parent.Nodes.Insert(index + 1, newNode);

            // Also, add each file under that
            foreach (SobekCM_File_Info thisFile in pageNode.Files)
            {
                TreeNode fileNode = new TreeNode(thisFile.System_Name);
                fileNode.ImageIndex = 5;
                fileNode.Tag = thisFile;
                newNode.Nodes.Add(fileNode);
            }

            // Select this node
            treeView.SelectedNode = newNode;
        }

        #endregion

        #region File-Related Events

        void viewMI_Click(object sender, EventArgs e)
        {
            string file = directory + "\\" + treeView.SelectedNode.Text;
            if ((File.Exists(file)) || ( file.IndexOf("http:") >= 0 ))
            {
                Process showFile = new Process();
                showFile.StartInfo = new ProcessStartInfo(file);
                showFile.Start();
            }
            else
            {
                MessageBox.Show("File does not exist.         ", "View File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void excludeMI_Click(object sender, EventArgs e)
        {
            // If this is not selected, or nothing is tagged to the node, do nothing
            if ((treeView.SelectedNode == null) || (treeView.SelectedNode.Tag == null))
                return;

            // Get the node
            TreeNode selected = treeView.SelectedNode;

            // If this is a file, ask to verify that the user wants to delete the file
            if (treeView.SelectedNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.SobekCM_File_Info")
            {
                SobekCM_File_Info fileInfo = (SobekCM_File_Info)treeView.SelectedNode.Tag;
                DialogResult results = MessageBox.Show("Are you sure you would like to exclude this file?             \n\n\t" + fileInfo.System_Name, "Verify file exclusion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (results == DialogResult.Yes)
                {
                    // Deal with the parent METS page as well
                    Page_TreeNode fileParent = (Page_TreeNode)selected.Parent.Tag;
                    fileParent.Files.Remove(fileInfo);

                    // Get the parent node
                    TreeNode parentNode = selected.Parent;

                    // Delete this node
                    parentNode.Nodes.Remove(selected);

                    // If this has no children nodes, remove it
                    if ((parentNode.Nodes.Count == 0) && (parentNode.Parent != null))
                    {
                        parentNode.Parent.Nodes.Remove(parentNode);
                    }

                    base.OnDataChanged();
                }
            }          
        }

        #endregion

        #endregion
    }

    public class Checksum_Calculator
    {
        private bool calculateAll;
        private Division_Info divInfo;
        private New_SobekCM_Bib_Package_Progress_Task_Group progressDelegate;
        private Progress_Form showProgressForm;

        public Checksum_Calculator(Division_Info Div_Info, bool Calculate_All)
        {
            showProgressForm = new Progress_Form("Calculating Checksums....", "");
            showProgressForm.Show();

            divInfo = Div_Info;
            progressDelegate = showProgressForm.New_Task;
            calculateAll = Calculate_All;
        }

        public event New_SobekCM_Bib_Package_Progress Complete;

        public void Process()
        {
            showProgressForm.Show();
            divInfo.Calculate_Checksum(calculateAll, progressDelegate);
            showProgressForm.Hide();

            if (Complete != null)
                Complete("", 1, 1);

        }
    }
}
