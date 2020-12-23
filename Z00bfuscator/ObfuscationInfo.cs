#region License
// ====================================================
// Z00bfuscator Copyright(C) 2013-2019 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System.Collections.Generic;

namespace Z00bfuscator
{
    public struct ObfuscationInfo
    {
        public string OutputDirectory { get; set; }
        public string TempCreateDirectory { get; set; }
        public bool ObfuscateTypes { get; set; }
        public bool ObfuscateMethods { get; set; }
        public bool ObfuscateNamespaces { get; set; }
        public bool ObfuscateProperties { get; set; }
        public bool ObfuscateFields { get; set; }
        public bool ObfuscateResources { get; set; }

        public List<string> excludedTypes { get; set; }

        public ObfuscationInfo(string outputDirectory, string tempCreateDirectory, bool obfuscateTypes, bool obfuscateMethods, bool obfuscateNamespaces, bool obfuscateProperties, bool obfuscateFields, bool obfuscateResources, List<string> excludedTypes) : this() {
            this.OutputDirectory = outputDirectory;
            this.TempCreateDirectory = tempCreateDirectory;
            this.ObfuscateTypes = obfuscateTypes;
            this.ObfuscateMethods = obfuscateMethods;
            this.ObfuscateNamespaces = obfuscateNamespaces;
            this.ObfuscateProperties = obfuscateProperties;
            this.ObfuscateFields = obfuscateFields;
            this.ObfuscateResources = obfuscateResources;
            this.excludedTypes = excludedTypes;
        }
    }
}
