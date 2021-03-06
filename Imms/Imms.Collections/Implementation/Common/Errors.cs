using System;

namespace Imms.Implementation {

	//Special exception type so it never gets ignored when thrown.
	/// <summary>
	/// An exception thrown by the deep, technical implementation level of a data structure.<br/>
	/// Checks for all exceptions must be performed at the user-visible wrapper level. If this exception is thrown, it means that there is a bug.
	/// </summary>
	internal class ImplementationException : Exception {
		internal ImplementationException(string message, Exception innerException = null) :
			base("This exception is thrown by the deep implementation level of a data structure. It should not be visible and if it is, this indicates a bug. More info: " + message, innerException) { }
	}

	/// <summary>
	///     Errors used by the implementation of some data structures. These shouldn't be user-visible and if they are, this
	///     constitutes a bug.
	/// </summary>
	static class ImplErrors {

		internal static ImplementationException Digit_too_large(int size) {
			return Invalid_digit_size(size, "The digit is too large for this operation.");
		}

		internal static ImplementationException Digit_too_small(int size) {
			return Invalid_digit_size(size, "The digit is too small for this operation.");
		}

		internal static ImplementationException Bad_digit_size(int size)
		{
			return Invalid_digit_size(size, "Is an error for digits to be of any size not in [1, 4].");
		}

		/// <summary>
		///     Thrown when a digit gets an invalid size.
		/// </summary>
		/// <param name="size"></param>
		/// <param name="message"></param>
		private static ImplementationException Invalid_digit_size(int size, string message = null) {
			return new ImplementationException(string.Format("This operation cannot be performed on a digit with this size. It was: {0}. More info: {1}", size, message));
		}

		/// <summary>
		///     Thrown when a switch statement that was supposed to handle all cases somehow didn't.
		/// </summary>
		/// <param name="info"></param>
		internal static ImplementationException Invalid_execution_path(string info) {
			return new ImplementationException(string.Format("An execution has reached a block never meant to be executed. More info: {0}", info));
		}

		/// <summary>
		///     Thrown when a method was executed on a node marked as Null, which is illegal for executions.
		/// </summary>
		/// <param name="objectKind"></param>
		internal static ImplementationException Invalid_invocation(string objectKind) {
			return new ImplementationException(string.Format("This operation cannot be executed on this kind of object. It was of the kind: {0}", objectKind));
		}

		public static ImplementationException Arg_out_of_range(string name, object value) {
			return new ImplementationException(string.Format("An argument was out of range.\r\nName: {0}\t Value: {1}", name, value));
		}


	}
}