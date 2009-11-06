using System;
using System.Collections;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlCollection.
	/// </summary>
	public class XmlCollection : ICollection
	{
		private ArrayList m_ArrayList = new ArrayList(); 

		public virtual void Add(object newItem)
		{
			this.ArrayList.Add (newItem);
		}

		public virtual void Clear ()
		{
			this.ArrayList.Clear ();
		}

		public ArrayList ArrayList
		{
			get { return m_ArrayList; }
			//set { m_ArrayList = value; }
		}

		public int Count
		{
			get { return m_ArrayList.Count; }
			//set { /* Nothing to do, count updated during load */}
		}

		#region ICollection
		public object this[int index]
		{
			get{return this.ArrayList[index];}
		}

		// Provide the explicit interface member for ICollection.
		void ICollection.CopyTo(Array array, int index)
		{
			this.ArrayList.CopyTo(array, index);
		}
    
		// Provide the strongly typed member for ICollection.
		public void CopyTo(object[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}

		public void CopyTo(Array array, int index)
		{
			this.ArrayList.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get{return this;}
		}

		public bool IsSynchronized
		{
			get{return false;}
		}

		public IEnumerator GetEnumerator()
		{
			return this.ArrayList.GetEnumerator();
		}
		#endregion
	}
}
