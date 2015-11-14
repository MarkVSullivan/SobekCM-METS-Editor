using System;
using System.Collections.Generic;
using System.Text;

namespace DLC.Tools.IO
{
    public enum Recursion_Rule_Enum
    {
        Parents_Of_Unactionable_Folder_Are_Unactionable = 1,
        Children_Of_Unactionable_Folder_Are_Unactionable,
        Unactionable_Folders_Do_Not_Impact_Parents_Or_Children
    }

    public class Recursive_Folder_Actioner
    {
        public delegate bool Folder_Actionable_Delegate(string directory);
        public delegate void Folder_Action_Delegate(string directory);

        public void Act_On_All_Actionable_Folders(string parentdirectory, Recursion_Rule_Enum recursion_rule, Folder_Actionable_Delegate folder_actionable_method, Folder_Action_Delegate folder_action_method)
        {
            // Create the root node
            Recursive_Folder_TreeNode parentNode = new Recursive_Folder_TreeNode(parentdirectory);
            if (!folder_actionable_method(parentdirectory))
                parentNode.isActionable = false;

            // Step through each subdirectory recursively
            string[] subdirs = System.IO.Directory.GetDirectories(parentdirectory);
            foreach (string thisSubDir in subdirs)
                recursively_check_children(thisSubDir, parentNode, recursion_rule, folder_actionable_method);

            // Post-order traverse the build tree and each actionable directory
            List<Recursive_Folder_TreeNode> postOrderNodes = new List<Recursive_Folder_TreeNode>();
            recursively_post_order_traverse_tree(parentNode, postOrderNodes);


            // Step through and act on each directory
            foreach (Recursive_Folder_TreeNode actionNode in postOrderNodes)
            {
                try
                {
                    folder_action_method(actionNode.Directory);
                }
                catch (Exception e)
                { 
                }
            }
        }

        
        private void recursively_check_children(string directory, Recursive_Folder_TreeNode parentNode, Recursion_Rule_Enum recursion_rule, Folder_Actionable_Delegate folder_actionable_method)
        {
            // Is this folder actionable
            bool node_is_actionable = true;
            if (!folder_actionable_method(directory))
            {
                // Does this rule out any parents?
                if (recursion_rule == Recursion_Rule_Enum.Parents_Of_Unactionable_Folder_Are_Unactionable)
                {
                    // If not, then none of its parents can be actioned
                    parentNode.isActionable = false;
                    while ((parentNode.Parent_Node != null) && (parentNode.Parent_Node.isActionable))
                    {
                        parentNode = parentNode.Parent_Node;
                        parentNode.isActionable = false;
                    }
                }

                // Also, this node can't be actioned (but maybe some children can)
                node_is_actionable = false;
            }

            // Can the children still be actionable?
            if ((recursion_rule != Recursion_Rule_Enum.Children_Of_Unactionable_Folder_Are_Unactionable) || ( node_is_actionable))
            {
                // Add this node to the tree and check its children
                Recursive_Folder_TreeNode childNode = new Recursive_Folder_TreeNode(directory, node_is_actionable);
                childNode.Parent_Node = parentNode;
                parentNode.Child_Nodes.Add(childNode);

                // Step through each subdirectory recursively
                string[] subdirs = System.IO.Directory.GetDirectories(directory);
                foreach (string thisSubDir in subdirs)
                    recursively_check_children(thisSubDir, childNode, recursion_rule, folder_actionable_method);
            }
        }

        private void recursively_post_order_traverse_tree(Recursive_Folder_TreeNode parentNode, List<Recursive_Folder_TreeNode> postOrderNodes)
        {
            // Check children first
            foreach (Recursive_Folder_TreeNode childNode in parentNode.Child_Nodes)
                recursively_post_order_traverse_tree(childNode, postOrderNodes);

            // Visit this node next
            if (parentNode.isActionable)
                postOrderNodes.Add(parentNode);
        }

        private class Recursive_Folder_TreeNode
        {
            // Pointers for this doubly-linked tree
            public Recursive_Folder_TreeNode Parent_Node;
            public List<Recursive_Folder_TreeNode> Child_Nodes;

            // Values for this tree node
            public bool isActionable;
            public string Directory;

            #region Constructors

            /// <summary> Constructor for a new instace of the Recursive_Folder_TreeNode class </summary>
            /// <param name="directory"> Directory for this node </param>
            public Recursive_Folder_TreeNode( string directory )
            {
                // Save the parameter
                this.Directory = directory;

                // Set defaults and prepare objects
                Child_Nodes = new List<Recursive_Folder_TreeNode>();
                isActionable = true;
            }

            /// <summary> Constructor for a new instace of the Recursive_Folder_TreeNode class </summary>
            /// <param name="directory"> Directory for this node </param>
            /// <param name="isActionable">Is this folder actionable</param>
            public Recursive_Folder_TreeNode(string directory, bool isActionable )
            {
                // Save the parameter
                this.Directory = directory;
                this.isActionable = isActionable;

                // Set defaults and prepare objects
                Child_Nodes = new List<Recursive_Folder_TreeNode>();
            }

            #endregion
        }
    }    
}
