using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities.IO
{
    public partial class HexFileStream : Stream
    {
        private VirtualMemorySpace m_MemorySpace = new VirtualMemorySpace();
        private UInt32 m_AccessPointer = 0;
        private FileAccess m_Access = FileAccess.Read;
        private String m_FilePath = null;
        //private StreamReader m_StreamReader = null;
        private FileStream m_FileStream = null;
        
        private FileMode m_FileMode = FileMode.Open;
        public UInt32 StartLinearAddress;

        //! \brief constructor
        public HexFileStream(String tFilePath,FileMode tMode, FileAccess tAccess)
        {
            if (null == tFilePath)
            {
                throw new ArgumentNullException("tFilePath","file path string should not be a null.");
            }
            else if ("" == tFilePath.Trim())
            {
                throw new ArgumentException("tFilePath", "path is an empty string ,contains only white space, or contains one or more invalid characters.");
            }

            m_FilePath = tFilePath;
            m_Access = tAccess;
            m_FileMode = tMode;

            Initialize();
        }

        private void Initialize()
        {
            if (null != m_FilePath)
            {
                try
                {
                    if (m_Access == FileAccess.Read) 
                    {
                        m_FileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.Read);
                    }
                    else if (m_Access == FileAccess.Write)
                    {
                        m_FileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.Write);
                    }
                    else
                    {
                        m_FileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.ReadWrite);
                    }
                }
                catch (Exception Err)
                {
                    m_FileStream = null;
                    m_FilePath = null;

                    throw Err;
                }
            }


            if (m_Access != FileAccess.Read)
            {
                m_MemorySpace.BeginUpdateMemorySpaceEvent += new VirtualMemorySpaceImage.BeginUpdateMemorySpace(m_MemorySpace_BeginUpdateMemorySpaceEvent);
                m_MemorySpace.EndUpdateMemorySpaceEvent += new VirtualMemorySpaceImage.EndUpdateMemorySpace(m_MemorySpace_EndUpdateMemorySpaceEvent);
                m_MemorySpace.UpdateMemorySpaceEvent += new VirtualMemorySpaceImage.UpdateMemorySpace(m_MemorySpace_UpdateMemorySpaceEvent);
                
            }

            if (m_Access != FileAccess.Write)
            {
                m_MemorySpace.LoadMemoryBlockEvent += new VirtualMemorySpaceImage.LoadMemoryBlock(LoadMemoryBlockFromHexFile);
                

                FillMemorySpace();
            }

        }

        private void FillMemorySpace()
        {
            FileStream tFileStream = null;
            if (m_Access == FileAccess.Write)
            {
                return;
            }
            else if (m_Access == FileAccess.Read) 
            {
                tFileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.Read);
            }
            else
            {
                tFileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.ReadWrite);
            }

            StreamReader tStreamReader = new StreamReader(tFileStream);
            
            String tRecordStr = null;
            try
            {
                Boolean bSeeEOF = true;
                UInt32 tAddress = 0;
                do
                {
                    tRecordStr = tStreamReader.ReadLine();
                    if (null != tRecordStr)
                    {
                        Record tRecord = Record.Parse(tRecordStr);
                        bSeeEOF = false;
                        if (null == tRecord)
                        {
                            throw new IOException("Illegal Hexadecimal Object File.");
                        }
                        switch (tRecord.RecordType)
                        {
                            case Record.Type.DATA_RECORD:
                                m_MemorySpace.Write(tAddress + tRecord.LoadOffset, tRecord.Data);
                                break;
                            case Record.Type.END_OF_FILE_RECORD:
                                bSeeEOF = true;
                                break;
                            case Record.Type.EXTEND_SEGMENT_ADDRESS_RECORD:
                                tAddress = ((ExtendSegmentAddressRecord)tRecord).ExtendSegmentBaseAddress;
                                break;
                            case Record.Type.START_SEGMENT_ADDRESS_RECORD:
                                tAddress = ((StartSegmentAddressRecord)tRecord).StartSegmentAddress;
                                break;
                            case Record.Type.EXTEND_LINEAR_ADDRESS_RECORD:
                                tAddress = ((ExtendLinearAddressRecord)tRecord).UpperLinearBaseAddress;
                                break;
                            case Record.Type.START_LINEAR_ADDRESS_RECORD:
                                tAddress = ((StartLinearAddressRecord)tRecord).StartLinearAddress;
                                StartLinearAddress = tAddress;
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                while (!bSeeEOF);
            }
            catch (Exception Err)
            {
                Err.ToString();
                throw Err;
            }
            finally
            {
                tStreamReader.Close();
            }
        }

        //! \brief load memory block from hex file
        private Boolean LoadMemoryBlockFromHexFile(UInt32 tTargetAddress, ref Byte[] tData, Int32 tSize)
        {
            if (m_Access == FileAccess.Write)
            {
                return false;
            }
            else if (null == m_FileStream)
            {
                return false;
            }
            else if (!m_FileStream.CanRead)
            {
                return false;
            }

            VirtualMemorySpace tMemorySpace = new VirtualMemorySpace();
            tMemorySpace.SpaceLength = UInt32.MaxValue;

            StreamReader tStreamReader = null;
            try
            {

                FileStream tFileStream = null;
                if (m_Access == FileAccess.Read)
                {
                    tFileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.Read);
                }
                else
                {
                    tFileStream = new FileStream(m_FilePath, m_FileMode, m_Access, FileShare.ReadWrite);
                }

                tStreamReader = new StreamReader(tFileStream);
                if (null == tStreamReader)
                {
                    return false;
                }
            }
            catch (Exception Err)
            {
                Err.ToString();
                tStreamReader.Close();
                return false;
            }

            String tRecordStr = null;
            try
            {
                Boolean bSeeEOF = false;
                UInt32 tAddress = 0;
                do
                {
                    tRecordStr = tStreamReader.ReadLine();
                    if (null != tRecordStr)
                    {
                        Record tRecord = Record.Parse(tRecordStr);
                        if (null == tRecord)
                        {
                            break;
                        }
                        switch (tRecord.RecordType)
                        {
                            case Record.Type.DATA_RECORD:
                                if (
                                        ((tRecord.LoadOffset + tAddress) < tTargetAddress)
                                    && ((tRecord.LoadOffset + tAddress + tRecord.Data.Length) <= tTargetAddress)
                                   )
                                {
                                    continue;
                                }
                                else if (
                                            ((tRecord.LoadOffset + tAddress) > tTargetAddress)
                                        && ((tTargetAddress + tSize) <= (tRecord.LoadOffset + tAddress))
                                        )
                                {
                                    break;
                                }
                                tMemorySpace.Write(tAddress + tRecord.LoadOffset, tRecord.Data);
                                break;
                            case Record.Type.END_OF_FILE_RECORD:
                                bSeeEOF = true;
                                break;
                            case Record.Type.EXTEND_SEGMENT_ADDRESS_RECORD:
                                tAddress = ((ExtendSegmentAddressRecord)tRecord).ExtendSegmentBaseAddress;
                                break;
                            case Record.Type.START_SEGMENT_ADDRESS_RECORD:
                                tAddress = ((StartSegmentAddressRecord)tRecord).StartSegmentAddress;
                                break;
                            case Record.Type.EXTEND_LINEAR_ADDRESS_RECORD:
                                tAddress = ((ExtendLinearAddressRecord)tRecord).UpperLinearBaseAddress;
                                break;
                            case Record.Type.START_LINEAR_ADDRESS_RECORD:
                                tAddress = ((StartLinearAddressRecord)tRecord).StartLinearAddress;
                                break;
                            default:
                                break;
                        }

                    }
                }
                while (!bSeeEOF);
            }
            catch (Exception Err)
            {
                Err.ToString();
            }
            finally
            {
                tStreamReader.Dispose();
            }

            return tMemorySpace.Read(tTargetAddress, ref tData, tSize);
        }

        private void m_MemorySpace_UpdateMemorySpaceEvent(UInt32 tAddress, Byte[] tData)
        {
            
        }

        private void m_MemorySpace_EndUpdateMemorySpaceEvent()
        {
            
        }

        private void m_MemorySpace_BeginUpdateMemorySpaceEvent()
        {
            
        }

        

        //! \brief async read bytes
        public override IAsyncResult BeginRead(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object stateObject)
        {
            throw new NotSupportedException();
        }

        //! \brief read bytes
        public override Int32 Read(Byte[] array, Int32 offset, Int32 count)
        {
            if (m_Access == FileAccess.Write)
            { 
                throw new NotSupportedException();;
            }
            else if ((null == m_FileStream) || (null == m_MemorySpace))
            {
                throw new ObjectDisposedException("HexFileStream");
            }
            
            else if (!m_FileStream.CanRead)
            {
                throw new NotSupportedException();
            }
            
            else if (null == array)
            {
                throw new ArgumentNullException();
            }
            else if ((0 == array.Length) || (0 == count))
            {
                return 0;
            }
            else if ((offset < 0) || (count < 0) || (array.Length < (offset + count)))
            {
                throw new ArgumentOutOfRangeException();
            }

            Byte[] tBuffer = new Byte[count];
            if (!m_MemorySpace.Read(m_AccessPointer,tBuffer))
            {
                throw new IOException();
            }
            m_AccessPointer += (UInt32)count;

            //! copy buffer
            tBuffer.CopyTo(array, offset);

            return count;
        }

        //! \brief read one byte from current position
        public override Int32 ReadByte()
        {
            Byte[] tBuffer = new Byte[1];

            if (1 == Read(tBuffer, 0, 1))
            {
                return tBuffer[0];
            }

            throw new IOException();
        }

        //! \brief async write bytes
        public override IAsyncResult BeginWrite(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback userCallback, Object stateObject)
        {
            throw new NotSupportedException();
        }

        //! \brief write bytes
        public override void Write(Byte[] array, Int32 offset, Int32 count)
        {
            
        }

        //! \brief write byte
        public override void WriteByte(byte value)
        {
            
        }



        //! \brief get/set current address
        public override Int64 Position
        {
            get
            {
                return m_AccessPointer;
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        //! \brief set hex file max length
        public override void SetLength(Int64 value)
        {
            if ((null == m_FileStream) || (null == m_MemorySpace))
            {
                throw new ObjectDisposedException("HexFileStream");
            }
            
            else if ((!m_FileStream.CanWrite) || (!m_FileStream.CanSeek))
            {
                throw new NotSupportedException();
            }
            
            else if ((value < 0) || (value > UInt32.MaxValue))
            {
                throw new ArgumentException("Out of memory space range");
            }

            m_MemorySpace.SpaceLength = (UInt32)value;
        }

        //! \brief seek access pointer
        public override Int64 Seek(Int64 offset, SeekOrigin origin)
        {
            if (null == m_FileStream)
            {
                throw new ObjectDisposedException("HexFileStream");
            }
            else if (!m_FileStream.CanSeek)
            {
                throw new NotSupportedException();
            }
            
            switch (origin)
            { 
                case SeekOrigin.Begin:
                    m_AccessPointer = 0;
                    break;
                case SeekOrigin.Current:
                    break;
                case SeekOrigin.End:
                    m_AccessPointer = (UInt32)m_MemorySpace.Size;
                    break;
            }

            if (
                    ((offset + (Int64)m_AccessPointer) > UInt32.MaxValue)
                || ((offset + (Int64)m_AccessPointer) < 0)
               )
            {
                throw new ArgumentException("Out of memory space range.");
            }

            m_AccessPointer = (UInt32)((Int64)m_AccessPointer + offset);

            return m_AccessPointer;
        }

        private Boolean m_bDisposed = false;

        public Boolean Disposed
        {
            get { return m_bDisposed; }
        }

        //! \brief dispose managed objects
        protected override void Dispose(Boolean disposing)
        {
            if ((disposing) && (!m_bDisposed))
            {
                Close();                
            }

            base.Dispose(disposing);
        }

        //! \brief hex stream length (not the file length)
        public override long Length
        {
            get
            {
                return m_MemorySpace.Size;
            }
        }

        //! \brief close this stream
        public override void Close()
        {
            m_bDisposed = true;

            if (null != m_MemorySpace)
            {
                //! memory space
                m_MemorySpace.BeginUpdateMemorySpaceEvent -= new VirtualMemorySpaceImage.BeginUpdateMemorySpace(m_MemorySpace_BeginUpdateMemorySpaceEvent);
                m_MemorySpace.EndUpdateMemorySpaceEvent -= new VirtualMemorySpaceImage.EndUpdateMemorySpace(m_MemorySpace_EndUpdateMemorySpaceEvent);
                m_MemorySpace.UpdateMemorySpaceEvent -= new VirtualMemorySpaceImage.UpdateMemorySpace(m_MemorySpace_UpdateMemorySpaceEvent);
                m_MemorySpace.LoadMemoryBlockEvent -= new VirtualMemorySpaceImage.LoadMemoryBlock(LoadMemoryBlockFromHexFile);
                m_MemorySpace = null;
            }


            //! file stream
            if (null != m_FileStream)
            {
                m_FileStream.Dispose();
                m_FileStream = null;
            }

            base.Close();
        }

        public override Boolean CanRead
        {
            get 
            {
                if (null != m_FileStream)
                {
                    return m_FileStream.CanRead;
                }

                return false;
            }
        }

        public override Boolean CanSeek
        {
            get
            {
                if (null != m_FileStream)
                {
                    return m_FileStream.CanSeek;
                }

                return false;
            }
        }

        public override Boolean CanWrite
        {
            get
            {
                if (null != m_FileStream)
                {
                    return m_FileStream.CanWrite;
                }

                return false;
            }
        }

        public override void Flush()
        {
            if ((null == m_FileStream) || (null == m_MemorySpace))
            {
                throw new ObjectDisposedException("HexFileStream");
            }

            m_MemorySpace.Update();
            m_FileStream.Flush();
        }

        public MemoryBlock[] MemoryBlocks
        {
            get { return m_MemorySpace.MemoryBlocks; }
        }

        public VirtualMemorySpaceImage MemorySpace
        {
            get { return m_MemorySpace; }
        }
    }
}
