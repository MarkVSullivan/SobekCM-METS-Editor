#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SobekCM.Resource_Object.Divisions;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	// - Implements:
	//   + Auto scrolling
	//   + Target node highlighting when over a node
	//   + Custom cursor when dragging
	//   + Custom ghost icon + label when dragging
	//   + Escape key to cancel drag
	//	 + Blocks certain nodes from being dragged via cancel event
	//   + Sanity checks for dragging (no parent into children nodes, target isn't the source)

	// Gotchas:
	// - Explorer can tell if you have the treeview node selected or not
	// - The drag icon has to be dragged to the right, not in the center (or the form has 
	//  a fight with the treeview over focus)
	// - No auto opening of items

	public delegate void DragCompleteEventHandler(object sender,DragCompleteEventArgs e);
	public delegate void DragItemEventHandler(object sender,DragItemEventArgs e);

	#region TreeViewDragDrop class

	/// <summary>
	/// A treeview with inbuilt drag-drop support and custom cursor/icon dragging.
	/// </summary>
	public class TreeViewDragDrop : TreeView
	{
		#region Win32 api import

		[DllImport("user32.dll")]
		private static extern int SendMessage (IntPtr hWnd, int wMsg, IntPtr wParam,int lParam);

		#endregion

		#region Private members

		private Color _dragOverNodeForeColor = SystemColors.HighlightText;
		private Color _dragOverNodeBackColor = SystemColors.Highlight;
		private TreeNode selectedNode;
		private TreeNode dragNode;
        private TreeNode lastSelectedNode;
		private BitmapCursor dragBitmapCursor;
		private Cursor thisNodeDragCursor;

		#endregion

		#region Events

		/// <summary>
		/// Occurs when an item is starting to be dragged. This
		/// event can be used to cancel dragging of particular items.
		/// </summary>
		public event DragItemEventHandler DragStart;

		/// <summary>
		/// Occurs when an item is dragged and dropped onto another.
		/// </summary>
		public event DragCompleteEventHandler DragComplete;
		
		/// <summary>
		/// Occurs when an item is dragged, and the drag is cancelled.
		/// </summary>
		public event DragItemEventHandler DragCancel;

		#endregion

		#region Constructor
		public TreeViewDragDrop()
		{
			AllowDrop = true;
		}
		#endregion

		#region Public properties
		
		/// <summary>
		/// The background colour of the node being dragged over.
		/// </summary>
		public Color DragOverNodeBackColor
		{
			get
			{
				return _dragOverNodeBackColor;
			}
			set
			{
				_dragOverNodeBackColor = value;
			}
		}

		/// <summary>
		/// The foreground colour of the node being dragged over.
		/// </summary>
		public Color DragOverNodeForeColor
		{
			get
			{
				return _dragOverNodeForeColor;
			}
			set
			{
				_dragOverNodeForeColor = value;
			}
		}

		#endregion

		public void Cancel_Move_Mode( TreeNode selectNode )
		{
			Cursor = Cursors.Default;
			AllowDrop = false;
			dragNode = null;
			dragBitmapCursor = null;
			SelectedNode = selectNode;
		}

		#region Over-ridden methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			//System.Diagnostics.Debug.WriteLine(m);
			// Stop erase background message
			if (m.Msg == 0x0014 )
			{
				m.Msg = 0x0000; // Set to null
			} 
			
			base.WndProc(ref m);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
		{
			if ( dragNode == null )
			{
				Cursor = Cursors.Default;
			}
			else
			{
				e.UseDefaultCursors = false;
				if (( thisNodeDragCursor == null ) && ( dragNode != null ))
				{
					thisNodeDragCursor = CreateDragCursor( dragNode );
				}

				if ( thisNodeDragCursor != null )
				{
					Cursor = thisNodeDragCursor;
				}
			}

		//	base.OnGiveFeedback( e );
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnItemDrag(ItemDragEventArgs e)
		{
			// Save the selected node
			selectedNode = (TreeNode) e.Item;
			dragNode = (TreeNode) e.Item;
			SelectedNode = dragNode;

			if ( dragNode == null )
			{
				MessageBox.Show("Drag started with Item == null" );
				// Get the target node from the mouse coords
				//Point pt = ((TreeView)this).PointToClient(new Point(e.X, e.Y));
				//selectedNode = this.GetNodeAt(pt);
			}

			if ( dragNode != null )
			{
				// Create and use the cursor
				thisNodeDragCursor = CreateDragCursor( dragNode );
				Cursor = thisNodeDragCursor;

				// Call dragstart event
				if ( DragStart != null )
				{
					DragStart(this,new DragItemEventArgs( dragNode ));
				}

				// Start drag drop
				DoDragDrop( e.Item, DragDropEffects.Move );
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDragOver(DragEventArgs e)
		{
            // Get the node from the mouse position, colour it
            Point pt = (this).PointToClient(new Point(e.X, e.Y));
            TreeNode treeNode = GetNodeAt(pt);
            SelectedNode = treeNode; 
		
			// Scrolling down/up
			if ( pt.Y +10 > ClientSize.Height )
				SendMessage( Handle,277,(IntPtr) 1,0 );
			else if ( pt.Y < Top +10 )
				SendMessage( Handle,277,(IntPtr) 0,0 );

			base.OnDragOver(e);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDragLeave(EventArgs e)
		{
			if ( selectedNode != null )
			{
				SelectedNode = selectedNode;
			}

			Cursor = Cursors.Default;
			thisNodeDragCursor = null;

			// Call cancel event
			if ( DragCancel != null )
			{
				DragCancel(this,new DragItemEventArgs(selectedNode));
			}

			//base.OnDragLeave(e);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDragEnter(DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;

			// Reset the previous node var
			selectedNode = null;

			base.OnDragEnter(e);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDragDrop(DragEventArgs e)
		{
			// Custom cursor handling
			Cursor = Cursors.Default;

			// Check it's a treenode being dragged
			if( e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false) )
			{
				// Get the target node from the mouse coords
				Point pt = (this).PointToClient(new Point(e.X, e.Y));
				TreeNode targetNode = GetNodeAt(pt);
						
				// 1) Check we're not dragging onto ourself
				// 2) Check we're not dragging onto one of our children 
				// (this is the lazy way, will break if there are nodes with the same name,
				// but it's quicker than checking all nodes below is)
				// 3) Check we're not dragging onto our parent
                if ((targetNode != dragNode) && (!targetNode.FullPath.StartsWith(dragNode.FullPath)) && (dragNode.Parent != targetNode))
                {
                    // Perform PAGE check
                    bool target_page = false;
                    if ((targetNode.Tag != null) && (((abstract_TreeNode)targetNode.Tag).Page))
                        target_page = true;

                    // Page can't be dropped in page, and Division can't be dropped in page
                    if (!target_page)
                    {
                        // Copy the node, add as a child to the destination node
                        dragNode.Remove();
                        targetNode.Nodes.Add( dragNode);
                        targetNode.Expand();

                        if (dragNode.SelectedImageIndex == 7)
                        {
                            dragNode.SelectedImageIndex = 4;
                            dragNode.ImageIndex = 4;
                        }

                        // Call drag complete event
                        if (DragComplete != null)
                        {
                            DragComplete(this, new DragCompleteEventArgs(dragNode, targetNode));
                        }
                    }

                    // Remove Original Node, set the dragged node as selected
                    SelectedNode = dragNode;

                    // Clear some values
                    dragBitmapCursor = null;
                }
                else
                {
                    SelectedNode = dragNode;
                }
			}	

			base.OnDragDrop(e);
		}

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            lastSelectedNode = SelectedNode;
            base.OnBeforeSelect(e);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyUp(KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Tab)
                return;

			if ( e.KeyCode == Keys.Escape )
			{
				if ( selectedNode != null )
				{
					SelectedNode = selectedNode;
				}

				// Set the cursor back
				Cursor = Cursors.Default;

				// Call cancel event
				if ( DragCancel != null )
				{
					DragCancel(this, new DragItemEventArgs( selectedNode ));
				}
			}

            TreeNode parentNode = lastSelectedNode.Parent;
            TreeNode lastNode = lastSelectedNode;
            if ((lastNode != null) && (parentNode != null) && (e.Alt) && ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Left)) && (SelectedNode != null))
            {
                // Try to move the last Selected node
                int index = lastNode.Index;                

                if (( e.KeyCode == Keys.Up ) && ( index > 0 ))
                {
                    parentNode.Nodes.Remove(lastNode);
                    parentNode.Nodes.Insert(index - 1, lastNode);
                    lastNode.Collapse();
                    SelectedNode = lastNode;

                    // Call drag complete event
                    if (DragComplete != null)
                    {
                        DragComplete(this, new DragCompleteEventArgs(lastNode, null));
                    }
                }

                if ((e.KeyCode == Keys.Down) && (index < parentNode.Nodes.Count - 1 ))
                {
                    parentNode.Nodes.Remove(lastNode);
                    parentNode.Nodes.Insert(index + 1, lastNode);
                    lastNode.Collapse();
                    SelectedNode = lastNode;

                    // Call drag complete event
                    if (DragComplete != null)
                    {
                        DragComplete(this, new DragCompleteEventArgs(lastNode, null));
                    }
                }

                if ((e.KeyCode == Keys.Left) && (parentNode != null) && (parentNode != Nodes[0]) && (lastNode.Tag.GetType().ToString() == "SobekCM.Resource_Object.Divisions.Division_TreeNode"))
                {
                    parentNode.Nodes.Remove(lastNode);
                    int parentIndex = parentNode.Index;
                    parentNode.Parent.Nodes.Insert(parentIndex, lastNode);
                    lastNode.Collapse();
                    SelectedNode = lastNode;

                    // Call drag complete event
                    if (DragComplete != null)
                    {
                        DragComplete(this, new DragCompleteEventArgs(lastNode, null));
                    }
                }
            }
            else
            {
                base.OnKeyUp(e);
            }
		}

		#endregion

		#region Bit map cursor stuff 



		protected virtual Cursor CreateDragCursor( TreeNode node )
		{
			int width = 100;
			int height = 20;
			string text = "Invalid";

			if ( node != null )
			{
				width = node.Bounds.Width + 100;
				if ( width == 0 )
					width = 100;
				height = node.Bounds.Height;
				text = node.Text;
			}

			Rectangle r = new Rectangle( 0, 0, width, height );
			using( Graphics g0 = CreateGraphics() )
			using( Bitmap bmp = new Bitmap( width, height * 4, g0 ) )
			using( Graphics g = Graphics.FromImage( bmp ) )
			{
				g.Clear( Color.FromArgb( 0, 0, 0, 0 ) );

				Color cb1 = Color.FromArgb( 255, 0, 89, 181 );
				Color cb2 = Color.FromArgb( 0, 0, 89, 181 );
				using( Brush b = new LinearGradientBrush( r, cb1, cb2, 0, false ) )
					g.FillRectangle( b, 0, 0, width, height );

				Color ct1 = Color.FromArgb( 255, 255, 255, 255 );
				Color ct2 = Color.FromArgb( 64, 255, 255, 255 );
				using( Brush b = new LinearGradientBrush( r, ct1, ct2, 0, false ) )
					g.DrawString( text, Font, b, 0, 0 );


				dragBitmapCursor = new BitmapCursor( bmp, Cursors.Default );
				return dragBitmapCursor.Cursor;
			}
		}

		#endregion
	}

	#endregion

	#region DragCompleteEventArgs class

	public class DragCompleteEventArgs : EventArgs
	{
	    public DragCompleteEventArgs( TreeNode SourceNode, TreeNode TargetNode )
		{
			this.SourceNode = SourceNode;
			this.TargetNode = TargetNode;
		}

	    /// <summary>
	    /// The node that was being dragged
	    /// </summary>
	    public TreeNode SourceNode { get; set; }

	    /// <summary>
	    /// The node that the source node was dragged onto.
	    /// </summary>
	    public TreeNode TargetNode { get; set; }
	}

	#endregion

	#region DragItemEventArgs class

	public class DragItemEventArgs : EventArgs
	{
	    public DragItemEventArgs( TreeNode Node )
		{
			this.Node = Node;
		}

	    /// <summary>
	    /// The ndoe that was being dragged
	    /// </summary>
	    public TreeNode Node { get; set; }
	}

	#endregion
}
