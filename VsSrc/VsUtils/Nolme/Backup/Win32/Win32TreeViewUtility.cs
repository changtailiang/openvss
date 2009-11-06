using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Nolme.Core;

namespace Nolme.Win32
{
	public delegate void DelegateTreeViewParse (TreeNode node, string pathToCheck, string[] pathArray, int level);

	/// <summary>
	/// Summary description for Win32TreeViewUtility.
	/// </summary>
	public sealed class Win32TreeViewUtility
	{
		private Win32TreeViewUtility()	{}

		#region Is ()
		public static bool IsChildNodeExist (TreeNode node)
		{
			if (node == null)
			{
				throw new NolmeArgumentNullException ();
			}

			if (node.Nodes.Count == 0)
				return false;
			return true;
		}
		/// <summary>
		/// Check if parentNode already contain childNodeText
		/// WARNING : SEARCH CASE INSENSITIVE
		/// </summary>
		/// <param name="parentNode"></param>
		/// <param name="childNodeText"></param>
		/// <returns></returns>
		public static bool IsChildNodeExist (TreeView sourceTreeView, string childNodeText)
		{
			TreeNode	oNodeFound = Win32TreeViewUtility.GetChildNode (sourceTreeView, childNodeText);
			if (oNodeFound == null)
				return false;
			return true;
		}

		public static TreeNode GetChildNode (TreeView sourceTreeView, string childNodeText)
		{
			if (sourceTreeView == null)	throw new NolmeArgumentNullException ();
			if (childNodeText == null)	throw new NolmeArgumentNullException ();

			TreeNode	NodeFound;
			//int		iCount = 0;
			
			for (int i = 0; i < sourceTreeView.Nodes.Count; i++)
			{
				if (string.Compare (sourceTreeView.Nodes[i].Text, childNodeText, true, CultureInfo.InvariantCulture) == 0)
				{
					//if (iCount == 0)
					{
						NodeFound = sourceTreeView.Nodes[i];
						return NodeFound;
					}
					//iCount++;	// Just count occurences
				}
			}
				
			return null;
		}

		/// <summary>
		/// Check if parentNode already contain childNodeText
		/// WARNING : SEARCH CASE INSENSITIVE
		/// </summary>
		/// <param name="parentNode"></param>
		/// <param name="childNodeText"></param>
		/// <returns></returns>
		public static bool IsChildNodeExist (TreeNode parentNode, string childNodeText)
		{
			TreeNode	oNodeFound = Win32TreeViewUtility.GetChildNode (parentNode, childNodeText);
			if (oNodeFound == null)
				return false;
			return true;
		}

		public static TreeNode GetChildNode (TreeNode parentNode, string childNodeText)
		{
			TreeNode	NodeFound;
			//int			iCount = 0;

			NodeFound = null;
			if (parentNode != null)
			{
				for (int i = 0; i < parentNode.Nodes.Count; i++)
				{
					if (string.Compare (parentNode.Nodes[i].Text, childNodeText, true, CultureInfo.InvariantCulture) == 0)
					{
						//if (iCount == 0)
						{
							NodeFound= parentNode.Nodes[i];
							return NodeFound;
						}
						//iCount++;	// Just count occurences
					}
				}
			}
			return null;
		}

		public static bool IsPathExistInTreeView (TreeView sourceTreeView, string pathToCheck)
		{
			TreeNode oNode = GetNodeFromPath (sourceTreeView, pathToCheck);

			if (oNode == null)
				return false;
			return true;
		}
		#endregion

		#region Get()
		public static string GetPathFromNode(TreeNode node) 
		{
			if (node == null)
			{
				throw new NolmeArgumentNullException ();
			}
			if (node.Parent == null) 
			{
				return node.Text;
			}
			return Path.Combine(GetPathFromNode(node.Parent), node.Text);
		}

		public static TreeNode GetNodeFromPath (TreeView sourceTreeView, string path)
		{
			TreeNode oNode  = GetNodeFromPath (sourceTreeView, path, null);
			return oNode;
		}

		public static TreeNode GetNodeFromPath (TreeView sourceTreeView, string path, DelegateTreeViewParse callback)
		{
			TreeNode oNode;

			if (sourceTreeView == null)
			{
				throw new NolmeArgumentNullException ();
			}

			if (sourceTreeView.Nodes.Count == 0)
				return null;

			string[] aszSplitedPath = DirectoryUtility.SplitRelativePath (path);
			if (aszSplitedPath.Length > 0)
			{
				for (int i = 0; i < sourceTreeView.Nodes.Count; i++)
				{
					if (string.Compare (sourceTreeView.Nodes[i].Text, aszSplitedPath[0], true, CultureInfo.InvariantCulture) == 0)
					{
						// Callback
						if (callback != null)
						{
							callback (sourceTreeView.Nodes[i], path, aszSplitedPath, 1);
						}

						if (aszSplitedPath.Length > 1)
						{
							// Check childs
							oNode = Internal_IsPathExistInTreeview (sourceTreeView.Nodes[i], path, aszSplitedPath, 1, callback);
						}
						else
						{
							// Path to check is only a drive letter
							// Comparaison here has succeeded
							oNode = sourceTreeView.Nodes[i];
						}
						return oNode;
					}
				}
			}
			return null;
		}
		#endregion

		#region Check/uncheck
		public static void CheckTreeNodeChilds (TreeNode node, bool checkNode)
		{
			if (node == null)
			{
				throw new NolmeArgumentNullException ();
			}
			
			foreach(TreeNode currentNode in node.Nodes)
			{
				currentNode.Checked = checkNode;
				if(currentNode.Nodes.Count > 0)
				{
					// If the current node has child nodes, call the CheckTreeNode method recursively.
					CheckTreeNodeChilds (currentNode, checkNode);
				}
			}
		}

		public static void UncheckParentTreeNode (TreeNode node)
		{
			if (node == null)
			{
				throw new NolmeArgumentNullException ();
			}

			node.Checked = false;
			
			// If not the root node, recurse
			if (node.Parent != null)
				UncheckParentTreeNode (node.Parent);
		}

		public static void CheckParentTreeNode (TreeNode node)
		{
			if (node == null)
			{
				throw new NolmeArgumentNullException ();
			}

			node.Checked = true;
			
			// If not the root node, recurse
			if (node.Parent != null)
				CheckParentTreeNode (node.Parent);
		}
		#endregion
		
		#region Other
		/// <summary>
		/// Add in treeview a path splited. Each element from folders name will be a treenode
		/// Create only not already created nodes
		/// </summary>
		/// <param name="sourceTreeView"></param>
		/// <param name="path"></param>
		public static TreeNode AddTreeNodeFromPath (TreeView sourceTreeView, string path)
		{
			if (sourceTreeView == null)	throw new NolmeArgumentNullException ();
			if (path == null)			throw new NolmeArgumentNullException ();

			string		szDriveLetter;
			string []	aszPath = DirectoryUtility.SplitRelativePath (path);
			TreeNode	oNode, oOutNode;
			//bool		bResult;

			oNode = null;
			if (aszPath.Length != 0)
			{
				// Add first element
				szDriveLetter	= aszPath[0];
				oOutNode		= Win32TreeViewUtility.GetChildNode (sourceTreeView, szDriveLetter);
				if (oOutNode == null)
				{
					oOutNode = sourceTreeView.Nodes.Add (szDriveLetter);
				}
				oNode = oOutNode;

				// Add other elemetns
				for (int i = 1; i < aszPath.Length; i++)
				{
					oOutNode = Win32TreeViewUtility.GetChildNode (oNode, aszPath[i]);
					if (oOutNode == null)
					{
						oOutNode = oNode.Nodes.Add (aszPath[i]);
					}

					// Switch parent node
					oNode = oOutNode;
				}
			}
			return oNode;
		}

		public static TreeNode AddTreeNodeFromRegistryPath (TreeView sourceTreeView, string path)
		{
			if (path == null)			throw new NolmeArgumentNullException ();
			if (sourceTreeView == null)	throw new NolmeArgumentNullException ();

			string		szDriveLetter;
			string []	aszPath = DirectoryUtility.SplitRelativePath (path);
			TreeNode	oNode, oOutNode;
			//bool		bResult;

			oNode = null;
			if (aszPath.Length != 0)
			{
				// Add first element
				szDriveLetter	= aszPath[0];
				oOutNode		= Win32TreeViewUtility.GetChildNode (sourceTreeView, szDriveLetter);
				if (oOutNode == null)
				{
					oOutNode = sourceTreeView.Nodes.Add (szDriveLetter);
				}
				oNode = oOutNode;

				// Add other elemetns
				for (int i = 1; i < aszPath.Length; i++)
				{
					oOutNode = Win32TreeViewUtility.GetChildNode (oNode, aszPath[i]);
					if (oOutNode == null)
					{
						oOutNode = oNode.Nodes.Add (aszPath[i]);
					}

					// Switch parent node
					oNode = oOutNode;
				}
			}
			return oNode;
		}

		/// <summary>
		/// Remove a treenode & its childs using file path
		/// </summary>
		/// <param name="sourceTreeView"></param>
		/// <param name="path"></param>
		public static void RemoveTreeNodeFromPath (TreeView sourceTreeView, string path, bool removeParentIfEmpty)
		{
			TreeNode oNodeToManage	= Win32TreeViewUtility.GetNodeFromPath (sourceTreeView, path);
			if (oNodeToManage != null)
			{
				TreeNode oParent = oNodeToManage.Parent;

				oNodeToManage.Remove ();
				if (removeParentIfEmpty)
				{
					RemoveEmptyParents (oParent);
				}
			}
		}
		public static void RemoveEmptyParents (TreeNode nodeToManage)
		{
			if (nodeToManage != null)
			{
				// Save treenode parent
				TreeNode oParent = nodeToManage.Parent;

				// Remove treenode
				nodeToManage.Remove ();

				// Recurse
				RemoveEmptyParents (oParent);
			}
		}
		#endregion

		#region Internal functions used during recursion
		private static TreeNode Internal_IsPathExistInTreeview (TreeNode node, string pathToCheck, string[] pathArray, int level, DelegateTreeViewParse callback)
		{
			// Stop recurse
			if (level == pathArray.Length)
			{
				return node;
			}

			// Scan all childs
			for (int i = 0; i < node.Nodes.Count; i++)
			{
				if (string.Compare (node.Nodes[i].Text, pathArray[level], true, CultureInfo.InvariantCulture) == 0)
				{
					// Callback
					if (callback != null)
					{
						callback (node.Nodes[i], pathToCheck, pathArray, level + 1);
					}

					// Check node childs
					return Internal_IsPathExistInTreeview (node.Nodes[i], pathToCheck, pathArray, level + 1, callback);
				}
			}
			return null;
		}
		#endregion 
	}
}
