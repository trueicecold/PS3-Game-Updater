using System;
using System.Text;
using System.IO;

namespace SFOReaderSharp
{
    public class SFOHeader {
	    private String fileType;
	    private String sfoVersion;
	    private int offsetKeyTable;
	    private int offsetValueTable;
	    private int numberDataItems;
	
	    public static SFOHeader read(FileStream fIn)
        {
		    SFOHeader sfoHeader = new SFOHeader();
		
		    byte[] tempByteArray = new byte[4];
		
		    // read FileType
		    fIn.Read(tempByteArray,0,4);
		    sfoHeader.setFileType(SFOReaderUtilities.byteArrayToString(tempByteArray));
		
		    // read sfoVerion
		    fIn.Read(tempByteArray,0,4);
		    sfoHeader.setSfoVersion(SFOReaderUtilities.byteArrayToString(tempByteArray));
		
		    // read offsetKeyTable
		    fIn.Read(tempByteArray,0,4);
		    sfoHeader.setOffsetKeyTable(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray));
		
		    // read offsetValueTable
		    fIn.Read(tempByteArray,0,4);
		    sfoHeader.setOffsetValueTable(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray));
		
		    // read numberDataItem
		    fIn.Read(tempByteArray,0,4);
		    sfoHeader.setNumberDataItems(SFOReaderUtilities.byteArrayReverseToInt(tempByteArray));
	
		    return sfoHeader;
	    }

	    public String getFileType() {
		    return fileType;
	    }

	    public void setFileType(String fileType) {
		    this.fileType = fileType;
	    }

	    public String getSfoVersion() {
		    return sfoVersion;
	    }

	    public void setSfoVersion(String sfoVersion) {
		    this.sfoVersion = sfoVersion;
	    }

	    public int getOffsetKeyTable() {
		    return offsetKeyTable;
	    }

	    public void setOffsetKeyTable(int offsetKeyTable) {
		    this.offsetKeyTable = offsetKeyTable;
	    }

	    public int getOffsetValueTable() {
		    return offsetValueTable;
	    }

	    public void setOffsetValueTable(int offsetValueTable) {
		    this.offsetValueTable = offsetValueTable;
	    }

	    public int getNumberDataItems() {
		    return numberDataItems;
	    }

	    public void setNumberDataItems(int numberDataItems) {
		    this.numberDataItems = numberDataItems;
	    }
	
	    public String toString() {
		    StringBuilder sb = new StringBuilder();
		
		    sb.Append("== SFO Header Data ==\n")
		    .Append("fileType:         ").Append(fileType).Append("\n")
		    .Append("sfoVersion:       ").Append(sfoVersion).Append("\n")
		    .Append("offsetKeyTable:   ").Append(offsetKeyTable).Append("\n")
		    .Append("offsetValueTable: ").Append(offsetValueTable).Append("\n")
		    .Append("numberDataItems:  ").Append(numberDataItems).Append("\n");
	
		    return sb.ToString();
	    }
    }
}
