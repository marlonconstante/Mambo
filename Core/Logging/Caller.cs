using System;
using System.Runtime.CompilerServices;

namespace Mambo.Core.Logging
{
	/// <summary>
	/// Caller.
	/// </summary>
	public static class Caller
	{
		/// <summary>
		/// Gets the info.
		/// </summary>
		/// <returns>The info.</returns>
		/// <param name="filePath">File path.</param>
		/// <param name="memberName">Member name.</param>
		/// <param name="lineNumber">Line number.</param>
		public static string GetInfo([CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
		{
			var fileName = filePath.Substring(filePath.LastIndexOf("/", StringComparison.CurrentCulture) + 1);
			var className = fileName.Replace(".cs", "");

			return $"{className}.{memberName}:{lineNumber}";
		}
	}
}