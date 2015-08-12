using Logitech_LCD.Exceptions;
using System;
using Logitech_LED;

namespace Logitech_LCD
{
    /// <summary>
    /// The class to effectively use to access the SDK functions
    /// </summary>
    public class LogitechLed
    {
        #region Singleton implementation
        public static LogitechLed Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private static class Nested
        {
            // ReSharper disable once InconsistentNaming
            internal static readonly LogitechLed instance = new LogitechLed();
        }
        #endregion

        #region constructor / destructor
        private LogitechLed()
        { }

        ~LogitechLed()
        {
            NativeMethods.Shutdown();
        }
        #endregion

        /// <summary>
        /// Used to call all <see cref="NativeMethods"/> methods. Will throw an exception
        /// if the initialization is note done before callig the method 
        /// </summary>
        /// <param name="method">The method to execute</param>
        /// <param name="args">The args of the called function</param>
        /// <returns>The function returns, needs to be casted</returns>
        private object InvokeMethod(Delegate method, params object[] args)
        {
            if (IsInit)
            {
                return method.DynamicInvoke(args);
            }
            throw new LedNotInitializedException();
        }

        public bool IsInit { get; private set; }

        /// <summary>
        /// Allows the initialization of the SDK, MUST be called before any other function
        /// </summary>
        /// <returns>True if success, False if failed</returns>
        public bool Init()
        {
            IsInit = NativeMethods.Init();
            return IsInit;
        }

        ///// <summary>
        ///// Refresh the screen
        ///// </summary>
        ///// <exception cref="LcdNotInitializedException">If the LCD Screen has not been initialized</exception>
        //public void Update()
        //{
        //    InvokeMethod(new Action(NativeMethods.Update));
        //}

        ///// <summary>
        ///// Displays a bitmap on a Monochrome screen
        ///// </summary>
        ///// <param name="monoBitmap">The array of bytes to display, a byte will be displayed if it's value is > 128 <see cref="MonoBitmap"/></param>
        ///// <returns>True if succeeds false otherwise</returns>
        ///// <exception cref="LcdNotInitializedException">If the LCD Screen has not been initialized</exception>
        //public bool MonoSetBackground(byte[] monoBitmap)
        //{
        //    return (bool)InvokeMethod(new Func<byte[], bool>(NativeMethods.MonoSetBackground), monoBitmap);
        //}


    }
}
