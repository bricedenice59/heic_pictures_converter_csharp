using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.HEICPINVOKE
    internal class HEICPINVOKE
    {
        private const string RecoveryDllName = @"lib\HEIC_SWIG_DLL_v120xp.dll";

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Path__SWIG_0")]
        public static extern IntPtr new_Path__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Path__SWIG_1")]
        public static extern IntPtr new_Path__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Path")]
        public static extern void delete_Path(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_Convert__SWIG_0")]
        public static extern void Converter_Convert__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5, bool jarg6);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_ExtractThumbnail__SWIG_0")]
        public static extern void Converter_ExtractThumbnail__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Converter")]
        public static extern IntPtr new_Converter();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Converter")]
        public static extern void delete_Converter(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_File")]
        public static extern IntPtr new_File(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_File")]
        public static extern void delete_File(HandleRef jarg1);
    }
}