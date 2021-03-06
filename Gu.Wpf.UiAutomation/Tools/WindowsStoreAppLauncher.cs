﻿namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class WindowsStoreAppLauncher
    {
        [ComImport]
        [Guid("2E941141-7F97-4756-BA1D-9DECDE894A3D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IApplicationActivationManager
        {
            IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);

            IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);

            IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }

        public static Process Launch(string appUserModelId, string arguments)
        {
            var launcher = new ApplicationActivationManager();
            var hr = launcher.ActivateApplication(appUserModelId, arguments, ActivateOptions.None, out uint processId).ToInt32();
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            if (processId > 0)
            {
                return Process.GetProcessById((int)processId);
            }

            throw new Exception($"Could not launch Store App '{appUserModelId}'");
        }

        [ComImport]
        [Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]
        private class ApplicationActivationManager : IApplicationActivationManager
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        // ReSharper restore InconsistentNaming
    }
}
