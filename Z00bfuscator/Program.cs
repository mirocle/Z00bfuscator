#region License
// ====================================================
// Z00bfuscator Copyright(C) 2013-2019 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Z00bfuscator
{
    class Program
    {
        static int Main(string[] args)
        {
            // Program.SetupConsole();

            if (args.Length == 0) {
                Console.WriteLine("Please input target file path!");
                return 1;
            }

            string target = args[0];
            string outputPath = Path.GetDirectoryName(target);
            string tempCreateDirectory = Path.Combine(Path.GetDirectoryName(target), "ObfuscatedAssembly");

            foreach (var filePath in args)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Input file [{filePath}] not exists!");
                    return 1;
                }

            }

            List<string> excludedTypes = new List<string>();
            // { "Medusa.Service.Platform.Core.NotObfuscateAttribute"};
            ObfuscationInfo info = new ObfuscationInfo(outputPath, tempCreateDirectory, true, true, true, false, true, false, excludedTypes);

            Obfuscator obfuscator = new Obfuscator(info);

            foreach (var filePath in args)
            {
                string newFilePath = Path.Combine(tempCreateDirectory,new FileInfo(filePath).Name);
                if (!Directory.Exists(tempCreateDirectory))
                {
                    Directory.CreateDirectory(tempCreateDirectory);
                }
                File.Copy(filePath, newFilePath, true);
                obfuscator.AddAssembly(newFilePath, true);
            }

            //obfuscator.OnOutputEvent += new DelOutputEvent(Program.RaiseOnOutputEvent);
            //obfuscator.OnNameObfuscated += new DelNameObfuscated(Program.RaiseOnNameObfuscated);
            //obfuscator.OnProgress += new DelProgress(Program.RaiseOnProgress);

            obfuscator.StartObfuscation();

            return 0;
        }

        //private static void RaiseOnOutputEvent(string message) {
        //    Console.WriteLine();
        //    Console.WriteLine(message);
        //}

        //private static void RaiseOnNameObfuscated(ObfuscationItem item, string initialName, string obfuscatedName) {
        //    Console.WriteLine();
        //    Console.WriteLine($"ItemObfuscated: [{item.ToString()}]");
        //    Console.WriteLine($"Old: [{initialName}]");
        //    Console.WriteLine($"New: [{obfuscatedName}]");
        //}

        //private static void RaiseOnProgress(string phaseName, int percents) {
        //    Console.WriteLine();
        //    Console.WriteLine($"{phaseName} : [%{percents}]");
        //}

        //private static void SetupConsole() {

        //    #region GetAssemblyInformation

        //    var asm = Assembly.GetExecutingAssembly();
        //    var title = asm.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
        //    var version = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
        //    var configuration = asm.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;
        //    var informationalVersion = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        //    Console.WindowWidth = 140;
        //    Console.BufferHeight = 5000;
        //    Console.Title = string.Format("{0} {1} ({2}) [{3}] {4}",
        //        title,
        //        version,
        //        File.GetLastWriteTime(asm.Location),
        //        string.IsNullOrEmpty(configuration) ? "Undefined" : string.Format("{0}", configuration),
        //        string.IsNullOrEmpty(informationalVersion) ? string.Empty : string.Format("<{0}>", informationalVersion));

        //    Console.WriteLine(Globals.BANNER);
        //    Console.WriteLine(Globals.STRING_SEPERATOR);

        //    #endregion GetAssemblyInformation
        //}
    }
}
