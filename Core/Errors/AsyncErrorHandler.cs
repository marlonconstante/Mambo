using System;
using System.Diagnostics;

namespace Mambo.Core.Errors
{
	/// <summary>
	/// Async error handler.
	/// </summary>
	public static class AsyncErrorHandler
	{
		/// <summary>
		/// Handles the exception.
		/// </summary>
		/// <returns>The exception.</returns>
		/// <param name="exception">Exception.</param>
		public static void HandleException(Exception exception)
		{
			Debug.WriteLine(exception.Message);
		}
	}
}