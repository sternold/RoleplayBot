using System;
using System.Collections.Generic;
using System.IO;

namespace RoleplayBot.Util
{
	public class Config
	{
		private const string Extension = ".conf";

		private string Filename { get; }
		public bool IsNew { get; private set; }

		/// <summary>
		///     Creates/Reads a config file.
		/// </summary>
		/// <param name="filename">Name of the properties file. Do NOT include the extension</param>
		public Config(string filename)
		{
			Filename = filename + Extension;

			if (!File.Exists(Filename))
			{
				File.CreateText(Filename).Dispose();
				IsNew = true;
			}
		}

		/// <summary>
		///     Retrieves a value by key.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public object Get(string key)
		{
			var pairs = Load();
			pairs.TryGetValue(key, out object obj);
			return obj;
		}

		public bool GetAsBoolean(string key)
		{
			return Convert.ToBoolean(Get(key));
		}

		public string GetAsString(string key)
		{
			return Convert.ToString(Get(key));
		}

		public int GetAsInt(string key)
		{
			return Convert.ToInt32(Get(key));
		}

		/// <summary>
		///     Creates a new Key-Value pair.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Put(string key, object value)
		{
			var pairs = Load();
			pairs.Add(key, value);
			Save(pairs);
		}

		private void Save(Dictionary<string, object> pairs)
		{
			using (var writer = new StreamWriter(File.Open(Filename, FileMode.Open)))
			{
				foreach (var key in pairs.Keys)
				{
					pairs.TryGetValue(key, out object obj);
					writer.WriteLine(key + "=" + obj);
				}
			}
		}

		private Dictionary<string, object> Load()
		{
			var pairs = new Dictionary<string, object>();
			using (var reader = new StreamReader(File.Open(Filename, FileMode.Open)))
			{
				while (!reader.EndOfStream)
				{
					var pair = reader.ReadLine().Split('=');
					pairs.Add(pair[0], pair[1]);
				}
			}
			return pairs;
		}
	}
}