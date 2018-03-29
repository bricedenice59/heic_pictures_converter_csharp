using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.HEICPINVOKE
    internal class HEICPINVOKE
    {
        internal const string RecoveryDllName = @"lib\HEIC_SWIG_DLL_v120xp.dll";
        protected class SWIGExceptionHelper
        {
            public delegate void ExceptionDelegate(string message);

            public delegate void ExceptionArgumentDelegate(string message, string paramName);

            private static ExceptionDelegate applicationDelegate;

            private static ExceptionDelegate arithmeticDelegate;

            private static ExceptionDelegate divideByZeroDelegate;

            private static ExceptionDelegate indexOutOfRangeDelegate;

            private static ExceptionDelegate invalidCastDelegate;

            private static ExceptionDelegate invalidOperationDelegate;

            private static ExceptionDelegate ioDelegate;

            private static ExceptionDelegate nullReferenceDelegate;

            private static ExceptionDelegate outOfMemoryDelegate;

            private static ExceptionDelegate overflowDelegate;

            private static ExceptionDelegate systemDelegate;

            private static ExceptionArgumentDelegate argumentDelegate;

            private static ExceptionArgumentDelegate argumentNullDelegate;

            private static ExceptionArgumentDelegate argumentOutOfRangeDelegate;

            [DllImport(RecoveryDllName)]
            public static extern void SWIGRegisterExceptionCallbacks_HEIC(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

            [DllImport(RecoveryDllName, EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_HEIC")]
            public static extern void SWIGRegisterExceptionCallbacksArgument_HEIC(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

            private static void SetPendingApplicationException(string message)
            {
                SWIGPendingException.Set(new ApplicationException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingArithmeticException(string message)
            {
                SWIGPendingException.Set(new ArithmeticException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingDivideByZeroException(string message)
            {
                SWIGPendingException.Set(new DivideByZeroException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingIndexOutOfRangeException(string message)
            {
                SWIGPendingException.Set(new IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingInvalidCastException(string message)
            {
                SWIGPendingException.Set(new InvalidCastException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingInvalidOperationException(string message)
            {
                SWIGPendingException.Set(new InvalidOperationException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingIOException(string message)
            {
                SWIGPendingException.Set(new IOException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingNullReferenceException(string message)
            {
                SWIGPendingException.Set(new NullReferenceException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingOutOfMemoryException(string message)
            {
                SWIGPendingException.Set(new OutOfMemoryException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingOverflowException(string message)
            {
                SWIGPendingException.Set(new OverflowException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingSystemException(string message)
            {
                SWIGPendingException.Set(new SystemException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingArgumentException(string message, string paramName)
            {
                SWIGPendingException.Set(new ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingArgumentNullException(string message, string paramName)
            {
                Exception ex = SWIGPendingException.Retrieve();
                if (ex != null)
                {
                    message = message + " Inner Exception: " + ex.Message;
                }
                SWIGPendingException.Set(new ArgumentNullException(paramName, message));
            }

            private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
            {
                Exception ex = SWIGPendingException.Retrieve();
                if (ex != null)
                {
                    message = message + " Inner Exception: " + ex.Message;
                }
                SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
            }

            static SWIGExceptionHelper()
            {
                applicationDelegate = SetPendingApplicationException;
                arithmeticDelegate = SetPendingArithmeticException;
                divideByZeroDelegate = SetPendingDivideByZeroException;
                indexOutOfRangeDelegate = SetPendingIndexOutOfRangeException;
                invalidCastDelegate = SetPendingInvalidCastException;
                invalidOperationDelegate = SetPendingInvalidOperationException;
                ioDelegate = SetPendingIOException;
                nullReferenceDelegate = SetPendingNullReferenceException;
                outOfMemoryDelegate = SetPendingOutOfMemoryException;
                overflowDelegate = SetPendingOverflowException;
                systemDelegate = SetPendingSystemException;
                argumentDelegate = SetPendingArgumentException;
                argumentNullDelegate = SetPendingArgumentNullException;
                argumentOutOfRangeDelegate = SetPendingArgumentOutOfRangeException;
                SWIGRegisterExceptionCallbacks_HEIC(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
                SWIGRegisterExceptionCallbacksArgument_HEIC(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
            }
        }

        public class SWIGPendingException
        {
            [ThreadStatic]
            private static Exception pendingException;

            private static int numExceptionsPending;

            public static bool Pending
            {
                get
                {
                    bool result = false;
                    if (numExceptionsPending > 0 && pendingException != null)
                    {
                        result = true;
                    }
                    return result;
                }
            }

            public static void Set(Exception e)
            {
                if (pendingException != null)
                {
                    throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
                }
                pendingException = e;
                lock (typeof(HEICPINVOKE))
                {
                    numExceptionsPending++;
                }
            }

            public static Exception Retrieve()
            {
                Exception result = null;
                if (numExceptionsPending > 0 && pendingException != null)
                {
                    result = pendingException;
                    pendingException = null;
                    lock (typeof(HEICPINVOKE))
                    {
                        numExceptionsPending--;
                        return result;
                    }
                }
                return result;
            }
        }

        protected class SWIGStringHelper
        {
            public delegate string SWIGStringDelegate(string message);

            private static SWIGStringDelegate stringDelegate;

            [DllImport(RecoveryDllName)]
            public static extern void SWIGRegisterStringCallback_HEIC(SWIGStringDelegate stringDelegate);

            private static string CreateString(string cString)
            {
                return cString;
            }

            static SWIGStringHelper()
            {
                stringDelegate = CreateString;
                SWIGRegisterStringCallback_HEIC(stringDelegate);
            }
        }

        protected class SWIGWStringHelper
        {
            public delegate string SWIGWStringDelegate(IntPtr message);

            private static SWIGWStringDelegate wstringDelegate;

            [DllImport(RecoveryDllName)]
            public static extern void SWIGRegisterWStringCallback_HEIC(SWIGWStringDelegate wstringDelegate);

            private static string CreateWString([MarshalAs(UnmanagedType.LPWStr)] IntPtr cString)
            {
                return Marshal.PtrToStringUni(cString);
            }

            static SWIGWStringHelper()
            {
                wstringDelegate = CreateWString;
                SWIGRegisterWStringCallback_HEIC(wstringDelegate);
            }
        }

        protected static SWIGExceptionHelper swigExceptionHelper;

        protected static SWIGStringHelper swigStringHelper;

        protected static SWIGWStringHelper swigWStringHelper;

        static HEICPINVOKE()
        {
            swigExceptionHelper = new SWIGExceptionHelper();
            swigStringHelper = new SWIGStringHelper();
            swigWStringHelper = new SWIGWStringHelper();
        }

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Clear")]
        public static extern void Vector_UnsignedInt_Clear(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Add")]
        public static extern void Vector_UnsignedInt_Add(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_size")]
        public static extern uint Vector_UnsignedInt_size(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_capacity")]
        public static extern uint Vector_UnsignedInt_capacity(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_reserve")]
        public static extern void Vector_UnsignedInt_reserve(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedInt__SWIG_0")]
        public static extern IntPtr new_Vector_UnsignedInt__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedInt__SWIG_1")]
        public static extern IntPtr new_Vector_UnsignedInt__SWIG_1(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedInt__SWIG_2")]
        public static extern IntPtr new_Vector_UnsignedInt__SWIG_2(int jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_getitemcopy")]
        public static extern uint Vector_UnsignedInt_getitemcopy(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_getitem")]
        public static extern uint Vector_UnsignedInt_getitem(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_setitem")]
        public static extern void Vector_UnsignedInt_setitem(HandleRef jarg1, int jarg2, uint jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_AddRange")]
        public static extern void Vector_UnsignedInt_AddRange(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_GetRange")]
        public static extern IntPtr Vector_UnsignedInt_GetRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Insert")]
        public static extern void Vector_UnsignedInt_Insert(HandleRef jarg1, int jarg2, uint jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_InsertRange")]
        public static extern void Vector_UnsignedInt_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_RemoveAt")]
        public static extern void Vector_UnsignedInt_RemoveAt(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_RemoveRange")]
        public static extern void Vector_UnsignedInt_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Repeat")]
        public static extern IntPtr Vector_UnsignedInt_Repeat(uint jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Reverse__SWIG_0")]
        public static extern void Vector_UnsignedInt_Reverse__SWIG_0(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Reverse__SWIG_1")]
        public static extern void Vector_UnsignedInt_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_SetRange")]
        public static extern void Vector_UnsignedInt_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Contains")]
        public static extern bool Vector_UnsignedInt_Contains(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_IndexOf")]
        public static extern int Vector_UnsignedInt_IndexOf(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_LastIndexOf")]
        public static extern int Vector_UnsignedInt_LastIndexOf(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedInt_Remove")]
        public static extern bool Vector_UnsignedInt_Remove(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Vector_UnsignedInt")]
        public static extern void delete_Vector_UnsignedInt(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Clear")]
        public static extern void Vector_UnsignedChar_Clear(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Add")]
        public static extern void Vector_UnsignedChar_Add(HandleRef jarg1, byte jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_size")]
        public static extern uint Vector_UnsignedChar_size(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_capacity")]
        public static extern uint Vector_UnsignedChar_capacity(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_reserve")]
        public static extern void Vector_UnsignedChar_reserve(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedChar__SWIG_0")]
        public static extern IntPtr new_Vector_UnsignedChar__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedChar__SWIG_1")]
        public static extern IntPtr new_Vector_UnsignedChar__SWIG_1(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_UnsignedChar__SWIG_2")]
        public static extern IntPtr new_Vector_UnsignedChar__SWIG_2(int jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_getitemcopy")]
        public static extern byte Vector_UnsignedChar_getitemcopy(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_getitem")]
        public static extern byte Vector_UnsignedChar_getitem(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_setitem")]
        public static extern void Vector_UnsignedChar_setitem(HandleRef jarg1, int jarg2, byte jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_AddRange")]
        public static extern void Vector_UnsignedChar_AddRange(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_GetRange")]
        public static extern IntPtr Vector_UnsignedChar_GetRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Insert")]
        public static extern void Vector_UnsignedChar_Insert(HandleRef jarg1, int jarg2, byte jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_InsertRange")]
        public static extern void Vector_UnsignedChar_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_RemoveAt")]
        public static extern void Vector_UnsignedChar_RemoveAt(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_RemoveRange")]
        public static extern void Vector_UnsignedChar_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Repeat")]
        public static extern IntPtr Vector_UnsignedChar_Repeat(byte jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Reverse__SWIG_0")]
        public static extern void Vector_UnsignedChar_Reverse__SWIG_0(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Reverse__SWIG_1")]
        public static extern void Vector_UnsignedChar_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_SetRange")]
        public static extern void Vector_UnsignedChar_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Contains")]
        public static extern bool Vector_UnsignedChar_Contains(HandleRef jarg1, byte jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_IndexOf")]
        public static extern int Vector_UnsignedChar_IndexOf(HandleRef jarg1, byte jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_LastIndexOf")]
        public static extern int Vector_UnsignedChar_LastIndexOf(HandleRef jarg1, byte jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_UnsignedChar_Remove")]
        public static extern bool Vector_UnsignedChar_Remove(HandleRef jarg1, byte jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Vector_UnsignedChar")]
        public static extern void delete_Vector_UnsignedChar(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Clear")]
        public static extern void Vector_Path_Clear(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Add")]
        public static extern void Vector_Path_Add(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_size")]
        public static extern uint Vector_Path_size(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_capacity")]
        public static extern uint Vector_Path_capacity(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_reserve")]
        public static extern void Vector_Path_reserve(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_Path__SWIG_0")]
        public static extern IntPtr new_Vector_Path__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_Path__SWIG_1")]
        public static extern IntPtr new_Vector_Path__SWIG_1(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Vector_Path__SWIG_2")]
        public static extern IntPtr new_Vector_Path__SWIG_2(int jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_getitemcopy")]
        public static extern IntPtr Vector_Path_getitemcopy(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_getitem")]
        public static extern IntPtr Vector_Path_getitem(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_setitem")]
        public static extern void Vector_Path_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_AddRange")]
        public static extern void Vector_Path_AddRange(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_GetRange")]
        public static extern IntPtr Vector_Path_GetRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Insert")]
        public static extern void Vector_Path_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_InsertRange")]
        public static extern void Vector_Path_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_RemoveAt")]
        public static extern void Vector_Path_RemoveAt(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_RemoveRange")]
        public static extern void Vector_Path_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Repeat")]
        public static extern IntPtr Vector_Path_Repeat(HandleRef jarg1, int jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Reverse__SWIG_0")]
        public static extern void Vector_Path_Reverse__SWIG_0(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_Reverse__SWIG_1")]
        public static extern void Vector_Path_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Vector_Path_SetRange")]
        public static extern void Vector_Path_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Vector_Path")]
        public static extern void delete_Vector_Path(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Map_Path_Path__SWIG_0")]
        public static extern IntPtr new_Map_Path_Path__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Map_Path_Path__SWIG_1")]
        public static extern IntPtr new_Map_Path_Path__SWIG_1(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_size")]
        public static extern uint Map_Path_Path_size(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_empty")]
        public static extern bool Map_Path_Path_empty(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_Clear")]
        public static extern void Map_Path_Path_Clear(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_getitem")]
        public static extern IntPtr Map_Path_Path_getitem(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_setitem")]
        public static extern void Map_Path_Path_setitem(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_ContainsKey")]
        public static extern bool Map_Path_Path_ContainsKey(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_Add")]
        public static extern void Map_Path_Path_Add(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_Remove")]
        public static extern bool Map_Path_Path_Remove(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_create_iterator_begin")]
        public static extern IntPtr Map_Path_Path_create_iterator_begin(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_get_next_key")]
        public static extern IntPtr Map_Path_Path_get_next_key(HandleRef jarg1, IntPtr jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Map_Path_Path_destroy_iterator")]
        public static extern void Map_Path_Path_destroy_iterator(HandleRef jarg1, IntPtr jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Map_Path_Path")]
        public static extern void delete_Map_Path_Path(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_ImageSize_width_set")]
        public static extern void ImageSize_width_set(HandleRef jarg1, ulong jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_ImageSize_width_get")]
        public static extern ulong ImageSize_width_get(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_ImageSize_height_set")]
        public static extern void ImageSize_height_set(HandleRef jarg1, ulong jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_ImageSize_height_get")]
        public static extern ulong ImageSize_height_get(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_ImageSize")]
        public static extern IntPtr new_ImageSize();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_ImageSize")]
        public static extern void delete_ImageSize(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Path__SWIG_0")]
        public static extern IntPtr new_Path__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Path__SWIG_1")]
        public static extern IntPtr new_Path__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetString")]
        public static extern string Path_GetString(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetFilename")]
        public static extern string Path_GetFilename(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetFilenameWithoutExtension")]
        public static extern string Path_GetFilenameWithoutExtension(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetExtension")]
        public static extern string Path_GetExtension(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetCreationTime")]
        public static extern IntPtr Path_GetCreationTime(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_GetModificationTime")]
        public static extern IntPtr Path_GetModificationTime(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_SetCreationTime")]
        public static extern void Path_SetCreationTime(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Path_SetModificationTime")]
        public static extern void Path_SetModificationTime(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Path")]
        public static extern void delete_Path(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_BitmapImage__SWIG_0")]
        public static extern IntPtr new_BitmapImage__SWIG_0();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_BitmapImage__SWIG_1")]
        public static extern IntPtr new_BitmapImage__SWIG_1(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_GetDimensions")]
        public static extern IntPtr BitmapImage_GetDimensions(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_GetData")]
        public static extern IntPtr BitmapImage_GetData(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_WriteTiles")]
        public static extern void BitmapImage_WriteTiles(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate90DegreesCW")]
        public static extern void BitmapImage_Rotate90DegreesCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate180DegreesCW")]
        public static extern void BitmapImage_Rotate180DegreesCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate270DegreesCW")]
        public static extern void BitmapImage_Rotate270DegreesCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate90DegreesCCW")]
        public static extern void BitmapImage_Rotate90DegreesCCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate180DegreesCCW")]
        public static extern void BitmapImage_Rotate180DegreesCCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_BitmapImage_Rotate270DegreesCCW")]
        public static extern void BitmapImage_Rotate270DegreesCCW(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_BitmapImage")]
        public static extern void delete_BitmapImage(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_SetProgressCallback")]
        public static extern void Converter_SetProgressCallback(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_Convert__SWIG_0")]
        public static extern void Converter_Convert__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5, bool jarg6);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_Convert__SWIG_1")]
        public static extern void Converter_Convert__SWIG_1(HandleRef jarg1, HandleRef jarg2, int jarg3, uint jarg4, bool jarg5);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_Convert__SWIG_2")]
        public static extern void Converter_Convert__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5, bool jarg6);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_ExtractThumbnail__SWIG_0")]
        public static extern void Converter_ExtractThumbnail__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_ExtractThumbnail__SWIG_1")]
        public static extern void Converter_ExtractThumbnail__SWIG_1(HandleRef jarg1, HandleRef jarg2, int jarg3, uint jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Converter_ExtractThumbnail__SWIG_2")]
        public static extern void Converter_ExtractThumbnail__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, uint jarg5);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Converter")]
        public static extern IntPtr new_Converter();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Converter")]
        public static extern void delete_Converter(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_File")]
        public static extern IntPtr new_File(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetPath")]
        public static extern string File_GetPath(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetISOFile")]
        public static extern IntPtr File_GetISOFile(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetPrimaryItemID")]
        public static extern uint File_GetPrimaryItemID(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetPrimaryThumbnailID")]
        public static extern uint File_GetPrimaryThumbnailID(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetAllItemIDs")]
        public static extern IntPtr File_GetAllItemIDs(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemInfo")]
        public static extern IntPtr File_GetItemInfo(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemType")]
        public static extern string File_GetItemType(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetLinkedItemIDs")]
        public static extern IntPtr File_GetLinkedItemIDs(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemProperties")]
        public static extern IntPtr File_GetItemProperties(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemHEVCConfiguration")]
        public static extern IntPtr File_GetItemHEVCConfiguration(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemSpacialExtents")]
        public static extern IntPtr File_GetItemSpacialExtents(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemRotation")]
        public static extern IntPtr File_GetItemRotation(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemColorInformations")]
        public static extern IntPtr File_GetItemColorInformations(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemDimensions")]
        public static extern IntPtr File_GetItemDimensions(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemData")]
        public static extern void File_GetItemData(HandleRef jarg1, uint jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_File_GetItemHEVCTiles")]
        public static extern void File_GetItemHEVCTiles(HandleRef jarg1, uint jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_File")]
        public static extern void delete_File(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_HEVCDecoder_Decode__SWIG_0")]
        public static extern void HEVCDecoder_Decode__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_HEVCDecoder_Decode__SWIG_1")]
        public static extern void HEVCDecoder_Decode__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_HEVCDecoder")]
        public static extern IntPtr new_HEVCDecoder();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_HEVCDecoder")]
        public static extern void delete_HEVCDecoder(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_GetQuality")]
        public static extern uint JPEGEncoder_GetQuality(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_SetQuality")]
        public static extern void JPEGEncoder_SetQuality(HandleRef jarg1, uint jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_GetEXIFData")]
        public static extern IntPtr JPEGEncoder_GetEXIFData(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_GetICCProfile")]
        public static extern IntPtr JPEGEncoder_GetICCProfile(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_SetEXIFData")]
        public static extern void JPEGEncoder_SetEXIFData(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_SetICCProfile")]
        public static extern void JPEGEncoder_SetICCProfile(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_EncodeRGB")]
        public static extern void JPEGEncoder_EncodeRGB(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_EncodeYCbCr")]
        public static extern void JPEGEncoder_EncodeYCbCr(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_JPEGEncoder_Encode")]
        public static extern void JPEGEncoder_Encode(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, int jarg4, HandleRef jarg5);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_JPEGEncoder")]
        public static extern IntPtr new_JPEGEncoder();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_JPEGEncoder")]
        public static extern void delete_JPEGEncoder(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_PNGEncoder_Encode")]
        public static extern void PNGEncoder_Encode(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_PNGEncoder")]
        public static extern IntPtr new_PNGEncoder();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_PNGEncoder")]
        public static extern void delete_PNGEncoder(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Task_Log")]
        public static extern void Task_Log(string jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_Task")]
        public static extern IntPtr new_Task(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Task_SetLogMessageCallback")]
        public static extern void Task_SetLogMessageCallback(HandleRef jarg1, HandleRef jarg2);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Task_Run")]
        public static extern void Task_Run(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_Task_WaitUntilFinished")]
        public static extern void Task_WaitUntilFinished(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_Task")]
        public static extern void delete_Task(HandleRef jarg1);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToRGB__SWIG_0")]
        public static extern void YUV420PDecoder_DecodeToRGB__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToRGB__SWIG_1")]
        public static extern void YUV420PDecoder_DecodeToRGB__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToRGB__SWIG_2")]
        public static extern void YUV420PDecoder_DecodeToRGB__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToYCbCr__SWIG_0")]
        public static extern void YUV420PDecoder_DecodeToYCbCr__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToYCbCr__SWIG_1")]
        public static extern void YUV420PDecoder_DecodeToYCbCr__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_YUV420PDecoder_DecodeToYCbCr__SWIG_2")]
        public static extern void YUV420PDecoder_DecodeToYCbCr__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_new_YUV420PDecoder")]
        public static extern IntPtr new_YUV420PDecoder();

        [DllImport(RecoveryDllName, EntryPoint = "CSharp_delete_YUV420PDecoder")]
        public static extern void delete_YUV420PDecoder(HandleRef jarg1);
    }

}