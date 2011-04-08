using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SFOReaderSharp
{
    class SFOKeyTableEntry
    {
	    public static byte DELIMITER_BYTE = 0;
	    private int keyTableLength;
	
	    public SFOKeyTableEntry() {
		    this.keyTableLength = 0;
	    }
	
	    /**
	     * Reads a key from the keyTable and return the value
	     * 
	     * @param fIn
	     * @return String
	     * @throws IOException
	     */
	    public String readEntry(FileStream fIn) {
		    byte[] tempByteArray1 = new byte[1];
		    StringBuilder sb = new StringBuilder();
		
		    fIn.Read(tempByteArray1, 0, 1);
		    keyTableLength++;
		    while(tempByteArray1[0] != DELIMITER_BYTE) {
			    sb.Append((char)tempByteArray1[0]);
			    fIn.Read(tempByteArray1, 0, 1);
			    keyTableLength++;
		    }
		
		    return sb.ToString();
	    }
	
	    /**
	     * Returns the keyTable-length in bytes
	     * @return Integer
	     */
	    public int getKeyTableLength() {
		    return this.keyTableLength;
	    }
    }
}
