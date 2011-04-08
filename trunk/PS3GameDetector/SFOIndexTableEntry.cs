using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SFOReaderSharp
{
    class SFOIndexTableEntry
    {
	    public static int INDEX_TABLE_ENTRY_LENGTH = 16;
	
	    private byte[] offsetKeyNameInKeyTable;
	    private byte dataAlignmentRequirements;
	    private byte dataTypeValue;
	    private int sizeValueData;
	    private int sizeValueDataAndPadding;
	    private int offsetDataValueInDataTable;
	
	    /**
	     * Reads one entry of the indexTable and return it's values in a SFOIndexTableEntry-object
	     * @param fIn
	     * @return SFOIndexTableEntry
	     * @throws IOException
	     */
	    public static SFOIndexTableEntry readEntry(FileStream fIn) {
		    SFOIndexTableEntry sfoIndexTableEntry = new SFOIndexTableEntry();
		
		    byte[] tempByteArray1 = new byte[1];
		    byte[] tempByteArray2 = new byte[2];
		    byte[] tempByteArray4 = new byte[4];
		
		    // read offsetKeyNameInKeyTable
		    fIn.Read(tempByteArray2,0,2);
		    sfoIndexTableEntry.setOffsetKeyNameInKeyTable(tempByteArray2);
		
		    // read dataAlignmentRequirements
		    fIn.Read(tempByteArray1,0,1);
		    sfoIndexTableEntry.setDataAlignmentRequirements(tempByteArray1[0]);
		
		    // read dataTypeValue
		    fIn.Read(tempByteArray1,0,1);
		    sfoIndexTableEntry.setDataTypeValue(tempByteArray1[0]);
		
		
		    // read sizeValueData
		    fIn.Read(tempByteArray4,0,4);
		    sfoIndexTableEntry.setSizeValueData(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray4));
		
		    // read sizeValueDataAndPadding
		    fIn.Read(tempByteArray4,0,4);
		    sfoIndexTableEntry.setSizeValueDataAndPadding(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray4));
		
		    // read offsetDataValueInDataTable
		    fIn.Read(tempByteArray4,0,4);
		    sfoIndexTableEntry.setOffsetDataValueInDataTable(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray4));
		
		    return sfoIndexTableEntry;
	    }

	    public byte[] getOffsetKeyNameInKeyTable() {
		    return offsetKeyNameInKeyTable;
	    }

	    public void setOffsetKeyNameInKeyTable(byte[] offsetKeyNameInKeyTable) {
		    this.offsetKeyNameInKeyTable = offsetKeyNameInKeyTable;
	    }

	    public byte getDataAlignmentRequirements() {
		    return dataAlignmentRequirements;
	    }

	    public void setDataAlignmentRequirements(byte dataAlignmentRequirements) {
		    this.dataAlignmentRequirements = dataAlignmentRequirements;
	    }

	    public byte getDataTypeValue() {
		    return dataTypeValue;
	    }

	    public void setDataTypeValue(byte dataTypeValue) {
		    this.dataTypeValue = dataTypeValue;
	    }

	    public int getSizeValueData() {
		    return sizeValueData;
	    }

	    public void setSizeValueData(int sizeValueData) {
		    this.sizeValueData = sizeValueData;
	    }

	    public int getSizeValueDataAndPadding() {
		    return sizeValueDataAndPadding;
	    }

	    public void setSizeValueDataAndPadding(int sizeValueDataAndPadding) {
		    this.sizeValueDataAndPadding = sizeValueDataAndPadding;
	    }

	    public int getOffsetDataValueInDataTable() {
		    return offsetDataValueInDataTable;
	    }

	    public void setOffsetDataValueInDataTable(int offsetDataValueInDataTable) {
		    this.offsetDataValueInDataTable = offsetDataValueInDataTable;
	    }
	
	    public String toString() {
		    StringBuilder sb = new StringBuilder();
		
		    sb.Append("== SFO IndexTable Entry ==\n")
		    .Append("offsetKeyNameInKeyTable:    ").Append(offsetKeyNameInKeyTable).Append("\n")
		    .Append("dataAlignmentRequirements:  ").Append(dataAlignmentRequirements).Append("\n")
		    .Append("dataTypeValue:              ").Append(dataTypeValue).Append("\n")
		    .Append("sizeValueData:              ").Append(sizeValueData).Append("\n")
		    .Append("sizeValueDataAndPadding:    ").Append(sizeValueDataAndPadding).Append("\n")
		    .Append("offsetDataValueInDataTable: ").Append(offsetDataValueInDataTable).Append("\n");
	
		    return sb.ToString();
	    }
    }
}
