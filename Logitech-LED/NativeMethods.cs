using System.Runtime.InteropServices;

namespace Logitech_LED
{
    public enum KeyName
    {
        Esc = 0x01,
        F1 = 0x3b,
        F2 = 0x3c,
        F3 = 0x3d,
        F4 = 0x3e,
        F5 = 0x3f,
        F6 = 0x40,
        F7 = 0x41,
        F8 = 0x42,
        F9 = 0x43,
        F10 = 0x44,
        F11 = 0x57,
        F12 = 0x58,
        PrintScreen = 0x137,
        ScrollLock = 0x46,
        PauseBreak = 0x145,
        Tilde = 0x29,
        One = 0x02,
        Two = 0x03,
        Three = 0x04,
        Four = 0x05,
        Five = 0x06,
        Six = 0x07,
        Seven = 0x08,
        Eight = 0x09,
        Nine = 0x0A,
        Zero = 0x0B,
        Minus = 0x0C,
        EQUALS = 0x0D,
        Backspace = 0x0E,
        Insert = 0x152,
        Home = 0x147,
        PageUp = 0x149,
        NumLock = 0x45,
        NumSlash = 0x135,
        NumAsterisk = 0x37,
        NumMinus = 0x4A,
        Tab = 0x0F,
        Q = 0x10,
        W = 0x11,
        E = 0x12,
        R = 0x13,
        T = 0x14,
        Y = 0x15,
        U = 0x16,
        I = 0x17,
        O = 0x18,
        P = 0x19,
        OpenBracket = 0x1A,
        CloseBracket = 0x1B,
        Backslash = 0x2B,
        KeyboardDelete = 0x153,
        End = 0x14F,
        PageDown = 0x151,
        NumSeven = 0x47,
        NumEight = 0x48,
        NumNine = 0x49,
        NumPlus = 0x4E,
        CapsLock = 0x3A,
        A = 0x1E,
        S = 0x1F,
        D = 0x20,
        F = 0x21,
        G = 0x22,
        H = 0x23,
        J = 0x24,
        K = 0x25,
        L = 0x26,
        Semicolon = 0x27,
        Apostrophe = 0x28,
        Enter = 0x1C,
        NumFour = 0x4B,
        NumFive = 0x4C,
        NumSix = 0x4D,
        LeftShift = 0x2A,
        Z = 0x2C,
        X = 0x2D,
        C = 0x2E,
        V = 0x2F,
        B = 0x30,
        N = 0x31,
        M = 0x32,
        Comma = 0x33,
        Period = 0x34,
        ForwardSlash = 0x35,
        RightShift = 0x36,
        ArrowUp = 0x148,
        NumOne = 0x4F,
        NumTwo = 0x50,
        NumThree = 0x51,
        NumEnter = 0x11C,
        LeftControl = 0x1D,
        LeftWindows = 0x15B,
        LeftAlt = 0x38,
        Space = 0x39,
        RightAlt = 0x138,
        RightWindows = 0x15C,
        ApplicationSelect = 0x15D,
        RightControl = 0x11D,
        ArrowLeft = 0x14B,
        ArrowDown = 0x150,
        ArrowRight = 0x14D,
        NumZero = 0x52,
        NumPeriod = 0x53
    }

    public enum BitmapSize
    {
        Width = 21,
        Height = 6,
        BytesPerKey = 4,
        Size = Width * Height * BytesPerKey
    }

    public class NativeMethods
    {
        public const int LogiLedDurationInfinite = 0;

        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedInit")]
        public static extern bool Init();
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSaveCurrentLighting")]
        public static extern bool SaveCurrentLighting();
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLighting")]
        public static extern bool SetLighting(int redPercentage, int greenPercentage, int bluePercentage);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedRestoreLighting")]
        public static extern bool RestoreLighting();
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedFlashLighting")]
        public static extern bool FlashLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedPulseLighting")]
        public static extern bool PulseLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedStopEffects")]
        public static extern bool StopEffects();
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLightingFromBitmap")]
        public static extern bool SetLightingFromBitmap(byte[] bitmap);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLightingForKeyWithScanCode")]
        public static extern bool SetLightingForKeyWithScanCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLightingForKeyWithHidCode")]
        public static extern bool SetLightingForKeyWithHidCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLightingForKeyWithQuartzCode")]
        public static extern bool SetLightingForKeyWithQuartzCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedSetLightingForKeyWithKeyNameCode")]
        public static extern bool SetLightingForKeyWithKeyNameCode(KeyName keyCode, int redPercentage, int greenPercentage, int bluePercentage);
        [DllImport("LogitechLedEnginesWrapper ", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LogiLedShutdown")]
        public static extern void Shutdown();
    }
}
