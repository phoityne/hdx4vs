using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell.Interop;
using System.Diagnostics;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace hdx4vs
{
    [ContentType("Haskell")]
	[Export(typeof(ILanguageClient))]
	public class HaskellLanguageClient : ILanguageClient
	{
		public string Name => "Haskell";

		public IEnumerable<string> ConfigurationSections => null;

		public object InitializationOptions => null;

		public IEnumerable<string> FilesToWatch => null;

		public event AsyncEventHandler<EventArgs> StartAsync;
		public event AsyncEventHandler<EventArgs> StopAsync;

		public async Task<Connection> ActivateAsync(CancellationToken token)
		{
			await Task.Yield();

            IVsSolution solution = (IVsSolution)Microsoft.VisualStudio.Shell.ServiceProvider.GlobalProvider.GetService(typeof(SVsSolution));
            solution.GetSolutionInfo(out string dir, out string file, out string ops);
            solution.GetProperty((int)__VSPROPID7.VSPROPID_IsInOpenFolderMode, out object folderMode);
            bool isOpenFolderMode = (bool)folderMode; // is the solution in folder mode?

            // File.AppendAllText(@"C:\temp\log.txt", dir + "\n");
            //Directory.SetCurrentDirectory(dir);

            System.Diagnostics.ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "stack";
            info.Arguments = "exec hie-wrapper -- --lsp --debug -l c:\\temp\\hie.log";
			info.RedirectStandardInput = true;
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			info.CreateNoWindow = true;

			Process process = new Process();
			process.StartInfo = info;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;

            if (process.Start())
			{
				return new Connection(process.StandardOutput.BaseStream, process.StandardInput.BaseStream);
			}

            return null;
		}

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        public async Task OnLoadedAsync()
		{
			await StartAsync?.InvokeAsync(this, EventArgs.Empty);
		}

		public Task OnServerInitializeFailedAsync(Exception e)
		{
			return Task.CompletedTask;
		}

		public Task OnServerInitializedAsync()
		{
            return Task.CompletedTask;
		}

	}
}
