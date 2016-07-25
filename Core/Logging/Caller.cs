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
		/// Gets the method signature.
		/// </summary>
		/// <returns>The method signature.</returns>
		/// <param name="filePath">File path.</param>
		/// <param name="memberName">Member name.</param>
		/// <param name="parameters">Parameters.</param>
		public static string GetMethodSignature([CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] parameters)
		{
			var fileName = filePath.Substring(filePath.LastIndexOf("/", StringComparison.CurrentCulture) + 1);
			var className = fileName.Replace(".cs", "");
			var methodParameters = string.Join(",", parameters);

			return $"{className}.{memberName}({methodParameters})";
		}
	}
}