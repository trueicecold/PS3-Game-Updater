using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SFOReaderSharp
{
    class SFOValueTableEntry
    {
	    private int valueBytesReaded;
	
	    public SFOValueTableEntry() {
		    this.valueBytesReaded = 0;
	    }
	
	    /**
	     * Reads an entry of the dataValueTable an return it as String
	     * 
	     * @param fIn
	     * @param sfoIndexTableEntry
	     * @return String
	     * @throws IOException
	     */
	    public String readEntry(FileStream fIn, SFOIndexTableEntry sfoIndexTableEntry) {
		    byte[] entryByteArray = new byte[sfoIndexTableEntry.getSizeValueData()];
		
		    fIn.Read(entryByteArray,0,sfoIndexTableEntry.getSizeValueData());
		    valueBytesReaded += sfoIndexTableEntry.getSizeValueData();
		
		    long offsetNextValue = sfoIndexTableEntry.getOffsetDataValueInDataTable()+sfoIndexTableEntry.getSizeValueDataAndPadding(); // korrekt!
		    long skipBytes = (offsetNextValue)-valueBytesReaded;
		    fIn.Seek(skipBytes, SeekOrigin.Current);
		    valueBytesReaded += Convert.ToInt32(skipBytes);
		
		    return SFOReaderUtilities.byteArrayToString(entryByteArray, true);
	    }    
    }
}
