using System;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.File
    public class File : IDisposable
    {
        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        internal File(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(File obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~File()
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
                        HEICPINVOKE.delete_File(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public File(Path path)
            : this(HEICPINVOKE.new_File(Path.getCPtr(path)), true)
        {
        }
    }

}