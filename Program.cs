using NTwain;
using NTwain.Data;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace list_twain {
	class Program {
		static void Main(string[] args) {
			if (PlatformInfo.Current.IsApp64Bit) {
				Console.WriteLine("Platform: 64 bit");
			} else {
				Console.WriteLine("Platform: 32 bit");
			}
			var twain = new TwainSession(TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly()));
			twain.Open();
			Console.WriteLine("Listing TWAIN devices...");
			foreach (var device in twain) {
				Console.WriteLine($"Device: {device.Name}");
				Console.WriteLine($"\tId: {device.Id}");
				Console.WriteLine($"\tManufacturer: {device.Manufacturer}");
				Console.WriteLine($"\tProductFamily: {device.ProductFamily}");
				Console.WriteLine($"\tProtocolVersion: {device.ProtocolVersion}");
			}
			twain.Close();
		}
	}
}