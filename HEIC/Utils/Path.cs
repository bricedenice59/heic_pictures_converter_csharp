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
        }
    }

}