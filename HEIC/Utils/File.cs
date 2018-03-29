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
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetPath()
        {
            return HEICPINVOKE.File_GetPath(swigCPtr);
        }

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__File_t GetISOFile()
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__File_t(HEICPINVOKE.File_GetISOFile(swigCPtr), true);
        //}

        public uint GetPrimaryItemID()
        {
            return HEICPINVOKE.File_GetPrimaryItemID(swigCPtr);
        }

        public uint GetPrimaryThumbnailID()
        {
            return HEICPINVOKE.File_GetPrimaryThumbnailID(swigCPtr);
        }

        //public Vector_UnsignedInt GetAllItemIDs()
        //{
        //    return new Vector_UnsignedInt(HEICPINVOKE.File_GetAllItemIDs(swigCPtr), true);
        //}

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__INFE_t GetItemInfo(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__INFE_t(HEICPINVOKE.File_GetItemInfo(swigCPtr, itemID), true);
        //}

        public string GetItemType(uint itemID)
        {
            return HEICPINVOKE.File_GetItemType(swigCPtr, itemID);
        }

        //public Vector_UnsignedInt GetLinkedItemIDs(uint itemID)
        //{
        //    return new Vector_UnsignedInt(HEICPINVOKE.File_GetLinkedItemIDs(swigCPtr, itemID), true);
        //}

        //public SWIGTYPE_p_std__vectorT_std__shared_ptrT_ISOBMFF__Box_t_t GetItemProperties(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__vectorT_std__shared_ptrT_ISOBMFF__Box_t_t(HEICPINVOKE.File_GetItemProperties(swigCPtr, itemID), true);
        //}

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__HVCC_t GetItemHEVCConfiguration(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__HVCC_t(HEICPINVOKE.File_GetItemHEVCConfiguration(swigCPtr, itemID), true);
        //}

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__ISPE_t GetItemSpacialExtents(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__ISPE_t(HEICPINVOKE.File_GetItemSpacialExtents(swigCPtr, itemID), true);
        //}

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__IROT_t GetItemRotation(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__IROT_t(HEICPINVOKE.File_GetItemRotation(swigCPtr, itemID), true);
        //}

        //public SWIGTYPE_p_std__shared_ptrT_ISOBMFF__COLR_t GetItemColorInformations(uint itemID)
        //{
        //    return new SWIGTYPE_p_std__shared_ptrT_ISOBMFF__COLR_t(HEICPINVOKE.File_GetItemColorInformations(swigCPtr, itemID), true);
        //}

        public ImageSize GetItemDimensions(uint itemID)
        {
            return new ImageSize(HEICPINVOKE.File_GetItemDimensions(swigCPtr, itemID), true);
        }

        public void GetItemData(uint itemID, Vector_UnsignedChar dataOut)
        {
            HEICPINVOKE.File_GetItemData(swigCPtr, itemID, Vector_UnsignedChar.getCPtr(dataOut));
            if (!HEICPINVOKE.SWIGPendingException.Pending)
            {
                return;
            }
            throw HEICPINVOKE.SWIGPendingException.Retrieve();
        }

        //public void GetItemHEVCTiles(uint itemID, SWIGTYPE_p_std__vectorT_std__pairT_HEIC__ImageSize_std__vectorT_unsigned_char_t_t_t tilesOut)
        //{
        //    HEICPINVOKE.File_GetItemHEVCTiles(swigCPtr, itemID, SWIGTYPE_p_std__vectorT_std__pairT_HEIC__ImageSize_std__vectorT_unsigned_char_t_t_t.getCPtr(tilesOut));
        //    if (!HEICPINVOKE.SWIGPendingException.Pending)
        //    {
        //        return;
        //    }
        //    throw HEICPINVOKE.SWIGPendingException.Retrieve();
        //}
    }

}