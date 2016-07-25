﻿using System;
using Akavache.Sqlite3;

namespace Mambo
{
	/// <summary>
	/// Linker preserve.
	/// </summary>
	[Preserve]
	public static class LinkerPreserve
	{
		/// <summary>
		/// Initializes the <see cref="T:Mambo.LinkerPreserve"/> class.
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