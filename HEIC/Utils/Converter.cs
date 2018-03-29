// HEIC.Converter

using System;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    public class Converter : IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void CSCallback(double progress, [MarshalAs(UnmanagedType.LPStr)] string message);

        public enum OutputFormat
        {
            JPEG,
            PNG
        }

        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        public void SetProgressCallback(CSCallback callback)
        {
            HEIC_Converter_SetProgressCallback(swigCPtr, callback);
        }

        [DllImport("HEIC_DLL_v120xp")]
        private static extern bool HEIC_Converter_SetProgressCallback(HandleRef o, [MarshalAs(UnmanagedType.FunctionPtr)] CSCallback callback);

        internal Converter(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(Converter obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~Converter()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        HEICPINVOKE.delete_Converter(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        //public void SetProgressCallback(SWIGTYPE_p_std__functionT_void_fdouble_std__string_const_RF_t callback)
        //{
        //    HEICPINVOKE.Converter_SetProgressCallback(swigCPtr, SWIGTYPE_p_std__functionT_void_fdouble_std__string_const_RF_t.getCPtr(callback));
        //    if (!HEICPINVOKE.SWIGPendingException.Pending)
        //    {
        //        return;
        //    }
        //    throw HEICPINVOKE.SWIGPendingException.Retrieve();
        //}

        public void Convert(Path heic, Path output, OutputFormat format, uint quality, bool keepEXIF)
        {
            HEICPINVOKE.Converter_Convert__SWIG_0(swigCPtr, Path.getCPtr(heic), Path.getCPtr(output), (int)format, quality, keepEXIF);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Convert(Map_Path_Path files, OutputFormat format, uint quality, bool keepEXIF)
        {
            HEICPINVOKE.Converter_Convert__SWIG_1(swigCPtr, Map_Path_Path.getCPtr(files), (int)format, quality, keepEXIF);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Convert(Vector_Path files, Path outputDirectory, OutputFormat format, uint quality, bool keepEXIF)
        {
            HEICPINVOKE.Converter_Convert__SWIG_2(swigCPtr, Vector_Path.getCPtr(files), Path.getCPtr(outputDirectory), (int)format, quality, keepEXIF);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ExtractThumbnail(Path heic, Path output, OutputFormat format, uint quality)
        {
            HEICPINVOKE.Converter_ExtractThumbnail__SWIG_0(swigCPtr, Path.getCPtr(heic), Path.getCPtr(output), (int)format, quality);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ExtractThumbnail(Map_Path_Path files, OutputFormat format, uint quality)
        {
            HEICPINVOKE.Converter_ExtractThumbnail__SWIG_1(swigCPtr, Map_Path_Path.getCPtr(files), (int)format, quality);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ExtractThumbnail(Vector_Path files, Path outputDirectory, OutputFormat format, uint quality)
        {
            HEICPINVOKE.Converter_ExtractThumbnail__SWIG_2(swigCPtr, Vector_Path.getCPtr(files), Path.getCPtr(outputDirectory), (int)format, quality);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public Converter()
            : this(HEICPINVOKE.new_Converter(), true)
        {
        }
    }
}
