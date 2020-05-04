using DotNetEnv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MiniErp.Application.Helpers
{
    public static class EnvLoader
    {
        private static object state = new object();

        /// <summary>
        /// Carrega as variáveis de ambiente de um arquivo .env
        /// </summary>
        public static void LoadEnv()
        {
            lock (state)
            {
                SetupAssemblyEnv();

                Thread.Sleep(1000);

                const string fileName = ".env";
                var assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var file = Path.Combine(assemblyDirectory, fileName);

                if (File.Exists(file))
                    Env.Load(file);
            }
        }

        /// <summary>
        /// Copia arquivo de variáveis de ambiente p/ o diretório de assembly
        /// </summary>
        private static void SetupAssemblyEnv()
        {
            const string fileName = ".env";

            var sourcePath = TryGetSolutionDirectoryInfo(fileName)?.FullName ?? string.Empty;
            var sourceFile = Path.Combine(sourcePath, fileName);

            var destPath = AppDomain.CurrentDomain.BaseDirectory;
            var destFile = Path.Combine(destPath, fileName);

            if (!File.Exists(sourceFile)) return;

            //Copying .env to assembly folder
            var sr = File.OpenText(sourceFile);
            var fileTxt = sr.ReadToEnd();
            sr.Close();

            var fileInfo = new FileInfo(destFile);
            var sw = fileInfo.CreateText();
            sw.Write(fileTxt);
            sw.Close();
        }

        /// <summary>
        /// Busca diretório raiz da app.
        /// </summary>
        /// <returns></returns>
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string filename)
        {
            var directory = Directory.GetParent(Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles(filename).Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }

        /// <summary>
        /// Busca diretório raiz da app.
        /// </summary>
        /// <returns></returns>
        public static DirectoryInfo TryGetDirectoryInfo(string filename)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles(filename).Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}
