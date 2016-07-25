using System;
using Akavache.Sqlite3;

namespace Mambo.FunctionalTests.iOS
{
	/// <summary>
	/// Linker preserve.
	/// </summary>
	[Preserve]
	public static class LinkerPreserve
	{
		/// <summary>
		/// Initializes the <see cref="T:Mambo.FunctionalTests.iOS.LinkerPreserve"/> class.
		/// </summary>
		static LinkerPreserve()
		{
			throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}

	/// <summary>
	/// Preserve attribute.
	/// </summary>
	public class PreserveAttribute : Attribute
	{
	}
}