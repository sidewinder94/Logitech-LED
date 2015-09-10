using System;

namespace Logitech_LED
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
        {
            Init();
        }

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
        /// Is called when the LogitechLed instance is created
        /// </summary>
        /// <returns>True if success, False if failed</returns>
        public bool Init()
        {
            if (IsInit) return IsInit;//Skip if it is already initialized
            IsInit = NativeMethods.Init();
            return IsInit;
        }


        public bool SaveCurrentLighting()
        {
            return (bool)InvokeMethod(new Func<bool>(NativeMethods.SaveCurrentLighting));
        }

        public bool SetLighting(int redPercentage, int greenPercentage, int bluePercentage)
        {
            return (bool)InvokeMethod(new Func<int, int, int, bool>(NativeMethods.SetLighting), redPercentage, greenPercentage, bluePercentage);
        }

        public bool RestoreLighting()
        {
            return (bool)InvokeMethod(new Func<bool>(NativeMethods.RestoreLighting));
        }

        public bool FlashLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration,
            int milliSecondsInterval)
        {
            return (bool)InvokeMethod(new Func<int, int, int, int, int, bool>(NativeMethods.FlashLighting), redPercentage, greenPercentage, bluePercentage, milliSecondsDuration, milliSecondsInterval);
        }

        public bool PulseLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration,
            int milliSecondsInterval)
        {
            return (bool)InvokeMethod(new Func<int, int, int, int, int, bool>(NativeMethods.PulseLighting), redPercentage, greenPercentage, bluePercentage, milliSecondsDuration, milliSecondsInterval);
        }

        public bool StopEffects()
        {
            return (bool)InvokeMethod(new Func<bool>(NativeMethods.StopEffects));
        }

        public bool SetLightingFromBitmap(byte[] bitmap)
        {
            return (bool)InvokeMethod(new Func<byte[], bool>(NativeMethods.SetLightingFromBitmap), bitmap);
        }

        public bool SetLightingForKeyWithScanCode(int keyCode, int redPercentage, int greenPercentage,
            int bluePercentage)
        {
            return (bool)InvokeMethod(new Func<int, int, int, int, bool>(NativeMethods.SetLightingForKeyWithScanCode), keyCode, redPercentage, greenPercentage, bluePercentage);
        }

        public bool SetLightingForKeyWithHidCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage)
        {
            return (bool)InvokeMethod(new Func<int, int, int, int, bool>(NativeMethods.SetLightingForKeyWithHidCode), keyCode, redPercentage, greenPercentage, bluePercentage);
        }

        public bool SetLightingForKeyWithQuartzCode(int keyCode, int redPercentage, int greenPercentage,
            int bluePercentage)
        {
            return (bool)InvokeMethod(new Func<int, int, int, int, bool>(NativeMethods.SetLightingForKeyWithQuartzCode), keyCode, redPercentage, greenPercentage, bluePercentage);
        }

        public bool SetLightingForKeyWithKeyNameCode(KeyName keyCode, int redPercentage, int greenPercentage,
            int bluePercentage)
        {
            return (bool)InvokeMethod(new Func<KeyName, int, int, int, bool>(NativeMethods.SetLightingForKeyWithKeyNameCode), keyCode, redPercentage, greenPercentage, bluePercentage);
        }
    }
}
