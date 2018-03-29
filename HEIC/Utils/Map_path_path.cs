using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HEIC.Utils
{
    // HEIC.Map_Path_Path
    public class Map_Path_Path : IDisposable, IDictionary<Path, Path>, ICollection<KeyValuePair<Path, Path>>, IEnumerable<KeyValuePair<Path, Path>>, IEnumerable
    {
        public sealed class Map_Path_PathEnumerator : IEnumerator, IEnumerator<KeyValuePair<Path, Path>>, IDisposable
        {
            private Map_Path_Path collectionRef;

            private IList<Path> keyCollection;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public KeyValuePair<Path, Path> Current
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
                    return (KeyValuePair<Path, Path>)currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Map_Path_PathEnumerator(Map_Path_Path collection)
            {
                collectionRef = collection;
                keyCollection = new List<Path>(collection.Keys);
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
                    Path key = keyCollection[currentIndex];
                    currentObject = new KeyValuePair<Path, Path>(key, collectionRef[key]);
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

        public Path this[Path key]
        {
            get
            {
                return getitem(key);
            }
            set
            {
                setitem(key, value);
            }
        }

        public int Count => (int)size();

        public bool IsReadOnly => false;

        public ICollection<Path> Keys
        {
            get
            {
                ICollection<Path> collection = new List<Path>();
                int count = Count;
                if (count > 0)
                {
                    IntPtr swigiterator = create_iterator_begin();
                    for (int i = 0; i < count; i++)
                    {
                        collection.Add(get_next_key(swigiterator));
                    }
                    destroy_iterator(swigiterator);
                }
                return collection;
            }
        }

        public ICollection<Path> Values
        {
            get
            {
                ICollection<Path> collection = new List<Path>();
                using (Map_Path_PathEnumerator map_Path_PathEnumerator = GetEnumerator())
                {
                    while (map_Path_PathEnumerator.MoveNext())
                    {
                        collection.Add(map_Path_PathEnumerator.Current.Value);
                    }
                    return collection;
                }
            }
        }

        internal Map_Path_Path(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(Map_Path_Path obj)
        {
            return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
        }

        ~Map_Path_Path()
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
                        HEICPINVOKE.delete_Map_Path_Path(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public bool TryGetValue(Path key, out Path value)
        {
            if (ContainsKey(key))
            {
                value = this[key];
                return true;
            }
            value = null;
            return false;
        }

        public void Add(KeyValuePair<Path, Path> item)
        {
            Add(item.Key, item.Value);
        }

        public bool Remove(KeyValuePair<Path, Path> item)
        {
            if (Contains(item))
            {
                return Remove(item.Key);
            }
            return false;
        }

        public bool Contains(KeyValuePair<Path, Path> item)
        {
            if (this[item.Key] == item.Value)
            {
                return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<Path, Path>[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(KeyValuePair<Path, Path>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
            }
            if (array.Rank > 1)
            {
                throw new ArgumentException("Multi dimensional array.", "array");
            }
            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException("Number of elements to copy is too large.");
            }
            IList<Path> list = new List<Path>(Keys);
            for (int i = 0; i < list.Count; i++)
            {
                Path key = list[i];
                array.SetValue(new KeyValuePair<Path, Path>(key, this[key]), arrayIndex + i);
            }
        }

        IEnumerator<KeyValuePair<Path, Path>> IEnumerable<KeyValuePair<Path, Path>>.GetEnumerator()
        {
            return new Map_Path_PathEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Map_Path_PathEnumerator(this);
        }

        public Map_Path_PathEnumerator GetEnumerator()
        {
            return new Map_Path_PathEnumerator(this);
        }

        public Map_Path_Path()
            : this(HEICPINVOKE.new_Map_Path_Path__SWIG_0(), true)
        {
        }

        public Map_Path_Path(Map_Path_Path other)
            : this(HEICPINVOKE.new_Map_Path_Path__SWIG_1(getCPtr(other)), true)
        {
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        private uint size()
        {
            return HEICPINVOKE.Map_Path_Path_size(swigCPtr);
        }

        public bool empty()
        {
            return HEICPINVOKE.Map_Path_Path_empty(swigCPtr);
        }

        public void Clear()
        {
            HEICPINVOKE.Map_Path_Path_Clear(swigCPtr);
        }

        private Path getitem(Path key)
        {
            Path result = new Path(HEICPINVOKE.Map_Path_Path_getitem(swigCPtr, Path.getCPtr(key)), false);
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(Path key, Path x)
        {
            HEICPINVOKE.Map_Path_Path_setitem(swigCPtr, Path.getCPtr(key), Path.getCPtr(x));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool ContainsKey(Path key)
        {
            bool result = HEICPINVOKE.Map_Path_Path_ContainsKey(swigCPtr, Path.getCPtr(key));
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Add(Path key, Path val)
        {
            HEICPINVOKE.Map_Path_Path_Add(swigCPtr, Path.getCPtr(key), Path.getCPtr(val));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Remove(Path key)
        {
            bool result = HEICPINVOKE.Map_Path_Path_Remove(swigCPtr, Path.getCPtr(key));
            if (HEICPINVOKE.SWIGPendingException.Pending)
            {
                throw HEICPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private IntPtr create_iterator_begin()
        {
            return HEICPINVOKE.Map_Path_Path_create_iterator_begin(swigCPtr);
        }

        private Path get_next_key(IntPtr swigiterator)
        {
            return new Path(HEICPINVOKE.Map_Path_Path_get_next_key(swigCPtr, swigiterator), false);
        }

        private void destroy_iterator(IntPtr swigiterator)
        {
            HEICPINVOKE.Map_Path_Path_destroy_iterator(swigCPtr, swigiterator);
        }
    }

}