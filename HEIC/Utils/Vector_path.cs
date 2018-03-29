using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.Vector_Path
    public class Vector_Path : IDisposable, IEnumerable, IEnumerable<Path>
    {
        public sealed class Vector_PathEnumerator : IEnumerator, IEnumerator<Path>, IDisposable
        {
            private Vector_Path collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public Path Current
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
                    return (Path)currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Vector_PathEnumerator(Vector_Path collection)
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

        public Path this[int index]
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

        internal Vector_Path(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(Vector_Path obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~Vector_Path()
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
                        HEICPINVOKE.delete_Vector_Path(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public Vector_Path(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (Path item in c)
            {
                Add(item);
            }
        }

        public void CopyTo(Path[] array)
        {
            CopyTo(0, array, 0, Count);
        }

        public void CopyTo(Path[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, Count);
        }

        public void CopyTo(int index, Path[] array, int arrayIndex, int count)
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

        IEnumerator<Path> IEnumerable<Path>.GetEnumerator()
        {
            return new Vector_PathEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Vector_PathEnumerator(this);
        }

        public Vector_PathEnumerator GetEnumerator()
        {
            return new Vector_PathEnumerator(this);
        }

        public void Clear()
        {
            HEICPINVOKE.Vector_Path_Clear(swigCPtr);
        }

        public void Add(Path x)
        {
            HEICPINVOKE.Vector_Path_Add(swigCPtr, Path.getCPtr(x));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        private uint size()
        {
            return HEICPINVOKE.Vector_Path_size(swigCPtr);
        }

        private uint capacity()
        {
            return HEICPINVOKE.Vector_Path_capacity(swigCPtr);
        }

        private void reserve(uint n)
        {
            HEICPINVOKE.Vector_Path_reserve(swigCPtr, n);
        }

        public Vector_Path()
            : this(HEICPINVOKE.new_Vector_Path__SWIG_0(), true)
        {
        }

        public Vector_Path(Vector_Path other)
            : this(HEICPINVOKE.new_Vector_Path__SWIG_1(getCPtr(other)), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector_Path(int capacity)
            : this(HEICPINVOKE.new_Vector_Path__SWIG_2(capacity), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        private Path getitemcopy(int index)
        {
            Path result = new Path(HEICPINVOKE.Vector_Path_getitemcopy(swigCPtr, index), true);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private Path getitem(int index)
        {
            Path result = new Path(HEICPINVOKE.Vector_Path_getitem(swigCPtr, index), false);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, Path val)
        {
            HEICPINVOKE.Vector_Path_setitem(swigCPtr, index, Path.getCPtr(val));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddRange(Vector_Path values)
        {
            HEICPINVOKE.Vector_Path_AddRange(swigCPtr, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector_Path GetRange(int index, int count)
        {
            IntPtr intPtr = HEICPINVOKE.Vector_Path_GetRange(swigCPtr, index, count);
            Vector_Path result = (intPtr == IntPtr.Zero) ? null : new Vector_Path(intPtr, true);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, Path x)
        {
            HEICPINVOKE.Vector_Path_Insert(swigCPtr, index, Path.getCPtr(x));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void InsertRange(int index, Vector_Path values)
        {
            HEICPINVOKE.Vector_Path_InsertRange(swigCPtr, index, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveAt(int index)
        {
            HEICPINVOKE.Vector_Path_RemoveAt(swigCPtr, index);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveRange(int index, int count)
        {
            HEICPINVOKE.Vector_Path_RemoveRange(swigCPtr, index, count);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Vector_Path Repeat(Path value, int count)
        {
            IntPtr intPtr = HEICPINVOKE.Vector_Path_Repeat(Path.getCPtr(value), count);
            Vector_Path result = (intPtr == IntPtr.Zero) ? null : new Vector_Path(intPtr, true);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            HEICPINVOKE.Vector_Path_Reverse__SWIG_0(swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            HEICPINVOKE.Vector_Path_Reverse__SWIG_1(swigCPtr, index, count);
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetRange(int index, Vector_Path values)
        {
            HEICPINVOKE.Vector_Path_SetRange(swigCPtr, index, getCPtr(values));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }
    }

}