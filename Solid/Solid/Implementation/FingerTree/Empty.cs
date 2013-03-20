using System;
using System.Collections.Generic;
using Solid.Common;
using Solid.FingerTree.Iteration;

namespace Solid.FingerTree
{
	internal sealed class Empty<T> : FTree<T>
		where T : Measured<T>
	{
		public static readonly Empty<T> Instance = new Empty<T>();

		private Empty() : base(0, TreeType.Empty)
		{
		}

		public override T Left
		{
			get { throw Common.Errors.Is_empty; }
		}

		public override T Right
		{
			get { throw Common.Errors.Is_empty; }
		}

		public override Measured Get(int index)
		{
			throw Common.Errors.Is_empty;
		}

		public override void Iter(Action<Measured> action1)
		{
			return;
		}

		public override void IterBack(Action<Measured> action)
		{
			
		}

		public override FTree<T> AddLeft(T item)
		{
			return new Single<T>(item.Measure, new Digit<T>(item, item.Measure));
		}

		public override FTree<T> AddRight(T item)
		{
			return new Single<T>(item.Measure, new Digit<T>(item, item.Measure));
		}

		public override FTree<T> DropLeft()
		{
			throw Common.Errors.Is_empty;
		}

		public override FTree<T> DropRight()
		{
			throw Common.Errors.Is_empty;
		}

		public override FTree<T> Reverse()
		{
			return this;
		}


		public override void Split(int count, out FTree<T> leftmost, out FTree<T> rightmost)
		{
			throw Common.Errors.Is_empty;
		}

		public override IEnumerator<Measured> GetEnumerator()
		{
			return EmptyEnumerator<T>.Instance;
		}

		public override FTree<T> Set(int index, Measured value)
		{
			throw Errors.Is_empty;
		}

		public override FTree<T> Insert(int index, object value)
		{
			return this.AddRight(value as T);
		}
	}
}