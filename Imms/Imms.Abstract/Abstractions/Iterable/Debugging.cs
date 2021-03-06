using System.Diagnostics;
using System.Linq;

namespace Imms.Abstract {
	partial class AbstractIterable<TElem, TIterable, TBuilder> {
		/// <summary>
		///     A string representation of this object, for use with the DebuggerDisplay attribute.
		/// </summary>
		protected virtual string DebuggerDisplay {
			get { return string.Format("{0}, Length = {1}", GetType().PrettyName(), Length); }
		}

	}

	/// <summary>
	///     Generic DebugView for an iterable collection.
	/// </summary>
	internal class IterableDebugView<TElem> {
		/// <summary>
		/// Constructs an IterableDebugView for the list.
		/// </summary>
		/// <param name="list"></param>
		public IterableDebugView(IAnyIterable<TElem> list) {
			Object = list;
		}
		/// <summary>
		/// The object for which this debug view is for.
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IAnyIterable<TElem> Object { get; private set; }

		/// <summary>
		/// The length of the collection.
		/// </summary>
		public int Length {
			get { return Object.Length; }
		}

		/// <summary>
		/// Converts the collection to an array, showing its elements.
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public TElem[] zItems {
			get { return Object.ToArray(); }
		}
	}
}