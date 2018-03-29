using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.Vector_UnsignedChar
    public class Vector_UnsignedChar : IDisposable, IEnumerable, IList<byte>, ICollection<byte>, IEnumerable<byte>
    {
        public sealed class Vector_UnsignedCharEnumerator : IEnumerator, IEnumerator<byte>, IDisposable
        {
            private Vector_UnsignedChar collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public byte Current
            {
                get
                {
                    if (currentIndex == -1)
                    {
                        throw new InvalidOperationException("Enumeration not started.");
                    }
                    if (currentIndex > currentSize - 1)
                    {
                        throw new InvalidOperationException("Enumeration finished.");
                    }
                    if (currentObject == null)
                    {
                        throw new InvalidOperationException("Collection modified.");
                    }
                    return (byte)currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Vector_UnsignedCharEnumerator(Vector_UnsignedChar collection)
            {
                collectionRef = collection;
                currentIndex = -1;
                currentObject = null;
                currentSize = collectionRef.Count;
            }

            public bool MoveNext()
            {
                int count = collectionRef.Count;
                bool num = currentIndex + 1 < count && count == currentSize;
                if (num)
                {
                    currentIndex++;
                    currentObject = collectionRef[currentIndex];
                    return num;
                }
                currentObject = null;
                return num;
            }

            public void Reset()
            {
                currentIndex = -1;
                currentObject = null;
                if (collectionRef.Count == currentSize)
                {
                    return;
                }
                throw new InvalidOperationException("Collection modified.");
            }

            public void Dispose()
            {
                currentIndex = -1;
                currentObject = null;
            }
        }

        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public byte this[int index]
        {
            get
            {
                return getitem(index);
            }
            set
            {
                setitem(index, value);
            }
        }

        public int Capacity
        {
            get
            {
                return (int)capacity();
            }
            set
            {
                if (value < size())
                {
                    throw new ArgumentOutOfRangeException("Capacity");
                }
                reserve((uint)value);
            }
        }

        public int Count => (int)size();

        public bool IsSynchronized => false;

        internal Vector_UnsignedChar(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(Vector_UnsignedChar obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~Vector_UnsignedChar()
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
                        HEICPINVOKE.delete_Vector_UnsignedChar(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public Vector_UnsignedChar(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (byte item in c)
            {
                Add(item);
            }
        }

        public void CopyTo(byte[] array)
        {
            CopyTo(0, array, 0, Count);
        }

        public void CopyTo(byte[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, Count);
        }

        public void CopyTo(int index, byte[] array, int arrayIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Value is less than zero");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Value is less than zero");
            }
            if (array.Rank > 1)
            {
                throw new ArgumentException("Multi dimensional array.", "array");
            }
            if (index + count <= Count && arrayIndex + count <= array.Length)
            {
                for (int i = 0; i < count; i++)
                {
                    array.SetValue(getitemcopy(index + i), arrayIndex + i);
                }
                return;
            }
            throw new ArgumentException("Number of elements to copy is too large.");
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
        {
            return new Vector_UnsignedCharEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Vector_UnsignedCharEnumerator(this);
        }

        public Vector_UnsignedCharEnumerator GetEnumerator()
        {
            return new Vector_UnsignedCharEnumerator(this);
        }

        public void Clear()
        {
            HEICPINVOKE.Vector_UnsignedChar_Clear(swigCPtr);
        }

        public void Add(byte x)
        {
            HEICPINVOKE.Vector_UnsignedChar_Add(swigCPtr, x);
        }

        private uint size()
        {
            return HEICPINVOKE.Vector_UnsignedChar_size(swigCPtr);
        }

        private uint capacity()
        {
            return HEICPINVOKE.Vector_UnsignedChar_capacity(swigCPtr);
        }

        private void reserve(uint n)
        {
            HEICPINVOKE.Vector_UnsignedChar_reserve(swigCPtr, n);
        }

        public Vector_UnsignedChar()
            : this(HEICPINVOKE.new_Vector_UnsignedChar__SWIG_0(), true)
        {
        }

        public Vector_UnsignedChar(Vector_UnsignedChar other)
            : this(HEICPINVOKE.new_Vector_UnsignedChar__SWIG_1(getCPtr(other)), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector_UnsignedChar(int capacity)
            : this(HEICPINVOKE.new_Vector_UnsignedChar__SWIG_2(capacity), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        private byte getitemcopy(int index)
        {
            byte result = HEICPINVOKE.Vector_UnsignedChar_getitemcopy(swigCPtr, index);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private byte getitem(int index)
        {
            byte result = HEICPINVOKE.Vector_UnsignedChar_getitem(swigCPtr, index);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, byte val)
        {
            HEICPINVOKE.Vector_UnsignedChar_setitem(swigCPtr, index, val);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddRange(Vector_UnsignedChar values)
        {
            HEICPINVOKE.Vector_UnsignedChar_AddRange(swigCPtr, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector_UnsignedChar GetRange(int index, int count)
        {
            IntPtr intPtr = HEICPINVOKE.Vector_UnsignedChar_GetRange(swigCPtr, index, count);
            Vector_UnsignedChar result = (intPtr == IntPtr.Zero) ? null : new Vector_UnsignedChar(intPtr, true);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, byte x)
        {
            HEICPINVOKE.Vector_UnsignedChar_Insert(swigCPtr, index, x);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void InsertRange(int index, Vector_UnsignedChar values)
        {
            HEICPINVOKE.Vector_UnsignedChar_InsertRange(swigCPtr, index, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveAt(int index)
        {
            HEICPINVOKE.Vector_UnsignedChar_RemoveAt(swigCPtr, index);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveRange(int index, int count)
        {
            HEICPINVOKE.Vector_UnsignedChar_RemoveRange(swigCPtr, index, count);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Vector_UnsignedChar Repeat(byte value, int count)
        {
            IntPtr intPtr = HEICPINVOKE.Vector_UnsignedChar_Repeat(value, count);
            Vector_UnsignedChar result = (intPtr == IntPtr.Zero) ? null : new Vector_UnsignedChar(intPtr, true);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            HEICPINVOKE.Vector_UnsignedChar_Reverse__SWIG_0(swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            HEICPINVOKE.Vector_UnsignedChar_Reverse__SWIG_1(swigCPtr, index, count);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetRange(int index, Vector_UnsignedChar values)
        {
            HEICPINVOKE.Vector_UnsignedChar_SetRange(swigCPtr, index, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Contains(byte value)
        {
            return HEICPINVOKE.Vector_UnsignedChar_Contains(swigCPtr, value);
        }

        public int IndexOf(byte value)
        {
            return HEICPINVOKE.Vector_UnsignedChar_IndexOf(swigCPtr, value);
        }

        public int LastIndexOf(byte value)
        {
            return HEICPINVOKE.Vector_UnsignedChar_LastIndexOf(swigCPtr, value);
        }

        public bool Remove(byte value)
        {
            return HEICPINVOKE.Vector_UnsignedChar_Remove(swigCPtr, value);
        }
    }

}