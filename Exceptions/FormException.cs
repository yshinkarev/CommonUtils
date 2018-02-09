using System;
using Common.Exceptions.Forms;
using System.Threading;

namespace Common.Exceptions
{
    /// <summary>
    /// Обрабатывает исключение и показывает форму с информацией об исключении
    /// </summary>
    public static class ExceptionProcess
    {
        static string _email;
        
        public static void ShowForm(Exception ex)
        {
            frmFormException f = new frmFormException(ex);

            if (!string.IsNullOrEmpty(_email))
            {
                f.lbEmail.Text = _email;
                f.lbEmail.Links.Add(0, _email.Length, "mailto:" + _email);
            }

            f.ShowDialog();
        }

        public static void SetApplicationHandlerOnException()
        {            
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        #region InternalFunc

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        { // All exceptions thrown by the main thread are handled over this method

            ShowForm(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {// All exceptions thrown by additional threads are handled in this method

            ShowForm(e.ExceptionObject as Exception);

            // Suspend the current thread for now to stop the exception from throwing.
            //Thread.CurrentThread.Suspend();
        }

        #endregion

        #region Properties

        public static string Email
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value", @"Email");

                _email = value;
            }
        }

        #endregion
    }
}
