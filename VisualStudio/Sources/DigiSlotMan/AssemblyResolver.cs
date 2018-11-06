using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Elreg.DigiRcMan
{
    public class AssemblyResolver
    {
        private readonly string _dllPath;

        public AssemblyResolver(string dllPath)
        {
            _dllPath = dllPath;
        }

        [DebuggerStepThrough]
        public void DoWork()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => ResolveAssembly(args);
        }

        [DebuggerStepThrough]
        private Assembly ResolveAssembly(ResolveEventArgs args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            //Get the Name of the AssemblyFile
            int index = args.Name.IndexOf(',');
            if (index >= 0)
            {
                var name = args.Name.Substring(0, index) + ".dll";

                //Load from Embedded Resources - This Function is not called if the Assembly is in the Application Folder
                var resources = thisAssembly.GetManifestResourceNames().Where(s => s.Replace(_dllPath, string.Empty).Equals(name));
                IEnumerable<string> enumerable = resources as string[] ?? resources.ToArray();
                if (enumerable.Any())
                {
                    var resourceName = enumerable.First();
                    using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream == null) return null;
                        var block = new byte[stream.Length];
                        stream.Read(block, 0, block.Length);
                        return Assembly.Load(block);
                    }
                }
            }
            return null;
        }
    }
}