﻿using System;
using System.Collections.Generic;

namespace Funq.Abstract {

	static class FastComparer<TKey> {
		static IComparer<TKey> _defaultComparer;
		static Optional<bool> _isComparable;

		public static IComparer<TKey> Default {
			get {
				if (_isComparable.IsNone) LoadComparer();
				return _defaultComparer;
			}
		}

		static void LoadComparer() {
			if (_isComparable.IsNone) {
				var tryComparer = TryGetComparer();
				_isComparable = tryComparer.IsSome;
				_defaultComparer = tryComparer.IsSome ? tryComparer.Value : null;
			}
		}

		static Optional<IComparer<TKey>> TryGetComparer() {
			var t = typeof (TKey);
			IComparer<TKey> comparer;
			if (t == typeof (string)) comparer = (IComparer<TKey>) Comparers.CreateComparer<string>(String.CompareOrdinal);
			else comparer = Comparer<TKey>.Default;
			return comparer.AsOptional();
		}
	}
}