using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.NetEnterpriseServers;


namespace ShopSmart.Client
{
    static class Program
    {
        /// <summary>
        /// The form to run...
        /// </summary>
        static ClientForm _form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Program._form = new ClientForm();
            Application.Run(Program._form);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Program.HandleException(sender, e.IsTerminating,e.ExceptionObject as Exception);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Program.HandleException(sender, false, e.Exception);
        }

        private static void HandleException(object sender, bool isTerminating, Exception exception)
        {
            ExceptionMessageBox emb = new ExceptionMessageBox(exception, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error);
            emb.Caption = "Unhandled Exception";
            emb.Show(Program._form);
        }

    }
}
