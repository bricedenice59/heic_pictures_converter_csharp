using System;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    public class ImageSize : IDisposable
    {
        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        public ulong width
        {
            get
            {
                return HEICPINVOKE.ImageSize_width_get(swigCPtr);
            }
            set
            {
                HEICPINVOKE.ImageSize_width_set(swigCPtr, value);
            }
        }

        public ulong height
        {
            get
            {
                return HEICPINVOKE.ImageSize_height_get(swigCPtr);
            }
            set
            {
                HEICPINVOKE.ImageSize_height_set(swigCPtr, value);
            }
        }

        internal ImageSize(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(ImageSize obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~ImageSize()
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
                        HEICPINVOKE.delete_ImageSize(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public ImageSize()
            : this(HEICPINVOKE.new_ImageSize(), true)
        {
        }
    }
}