using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using Aga.Controls.Tree;

using Virl.Fresk.Primitives;
using Virl.Fresk.Compound;

namespace Virl.Fresk
{
	public class BrowserTreeModel : ITreeModel
	{
		private GrGroup _root;

		public BrowserTreeModel()
		{
			_root = new GrGroup(null);
			_root.Model = this;
		}
		
		public GrGroup Root
		{
			get { return _root; }
		}

		public TreePath GetPath(IGrObj node)
		{
			if (node == _root)
				return TreePath.Empty;
			else
			{
				Stack<object> stack = new Stack<object>();
				while (node != _root)
				{
					stack.Push(node);
					node = node.Parent;
				}
				return new TreePath(stack.ToArray());
			}
		}

		public IGrObj FindNode(TreePath path)
		{
			if (path.IsEmpty())
				return _root;
			else
				return FindNode(_root, path, 0);
		}

		private IGrObj FindNode(IGrObj root, TreePath path, int level)
		{
			foreach (IGrObj node in root.Objects)
				if (node == path.FullPath[level])
				{
					if (level == path.FullPath.Length - 1)
						return node;
					else
						return FindNode(node, path, level + 1);
				}
			return null;
		}

		#region ITreeModel Members

		public System.Collections.IEnumerable GetChildren(TreePath treePath)
		{
			IGrObj node = FindNode(treePath);
			if (node != null)
				foreach (IGrObj n in node.Objects)
					yield return n;
			else
				yield break;
		}

		public bool IsLeaf(TreePath treePath)
		{
			IGrObj node = FindNode(treePath);
			if (node != null)
				return node.IsPrimitive;
			else
				throw new ArgumentException("treePath");
		}

		public event EventHandler<TreeModelEventArgs> NodesChanged;
		internal void OnNodesChanged(TreeModelEventArgs args)
		{
			if (NodesChanged != null)
				NodesChanged(this, args);
		}

		public event EventHandler<TreePathEventArgs> StructureChanged;
		public void OnStructureChanged(TreePathEventArgs args)
		{
			if (StructureChanged != null)
				StructureChanged(this, args);
		}

		public event EventHandler<TreeModelEventArgs> NodesInserted;
		internal void OnNodeInserted(IGrObj parent, int index, IGrObj node)
		{
			if (NodesInserted != null)
			{
				TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
				NodesInserted(this, args);
			}

		}

		public event EventHandler<TreeModelEventArgs> NodesRemoved;
		internal void OnNodeRemoved(IGrObj parent, int index, IGrObj node)
		{
			if (NodesRemoved != null)
			{
				TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
				NodesRemoved(this, args);
			}
		}

		#endregion
	}
}
