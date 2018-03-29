using System;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.Path
    public class Path : IDisposable
    {
        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        internal Path(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(Path obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~Path()
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
                        HEICPINVOKE.delete_Path(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public Path()
            : this(HEICPINVOKE.new_Path__SWIG_0(), true)
        {
        }

        public Path(string path)
            : this(HEICPINVOKE.new_Path__SWIG_1(path), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetString()
        {
            return HEICPINVOKE.Path_GetString(swigCPtr);
        }

        public string GetFilename()
        {
            return HEICPINVOKE.Path_GetFilename(swigCPtr);
        }

        public string GetFilenameWithoutExtension()
        {
            return HEICPINVOKE.Path_GetFilenameWithoutExtension(swigCPtr);
        }

        public string GetExtension()
        {
            return HEICPINVOKE.Path_GetExtension(swigCPtr);
        }

        //public SWIGTYPE_p_time_t GetCreationTime()
        //{
        //    return new SWIGTYPE_p_time_t(HEICPINVOKE.Path_GetCreationTime(swigCPtr), true);
        //}

        //public SWIGTYPE_p_time_t GetModificationTime()
        //{
        //    return new SWIGTYPE_p_time_t(HEICPINVOKE.Path_GetModificationTime(swigCPtr), true);
        //}

        //public void SetCreationTime(SWIGTYPE_p_time_t value)
        //{
        //    HEICPINVOKE.Path_SetCreationTime(swigCPtr, SWIGTYPE_p_time_t.getCPtr(value));
        //    if (!HEICPINVOKE.SWIGPendingException.Pending)
        //    {
        //        return;
        //    }
        //    throw HEICPINVOKE.SWIGPendingException.Retrieve();
        //}

        //public void SetModificationTime(SWIGTYPE_p_time_t value)
        //{
        //    HEICPINVOKE.Path_SetModificationTime(swigCPtr, SWIGTYPE_p_time_t.getCPtr(value));
        //    if (!HEICPINVOKE.SWIGPendingException.Pending)
        //    {
        //        return;
        //    }
        //    throw HEICPINVOKE.SWIGPendingException.Retrieve();
        //}
    }

}