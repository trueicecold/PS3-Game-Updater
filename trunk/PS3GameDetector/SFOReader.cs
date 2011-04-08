using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SFOReaderSharp
{
    class SFOReader
    {
        public static int HEADER_SIZE = 20;
        private String sfoFile;
        
        private SFOHeader sfoHeader;
        private ArrayList indexTableEntryList = new ArrayList();
        private ArrayList keyTableEntryList = new ArrayList();
        private ArrayList valueTableEntryList = new ArrayList();
        private Dictionary<String, String> keyValueMap = new Dictionary<String, String>();

        public SFOReader(String sfoFile)
        {
            this.sfoFile = sfoFile;
            parse();
        }

        /**
         * parse the submitted file (sfoFile) with the constructor and
         * fills the different ArrayLists and HashMaps
         */
        private void parse()
        {
            FileStream fIn;

            try
            {
                fIn = new FileStream(sfoFile, FileMode.Open, FileAccess.Read);

                // sfoHeader lesen
                sfoHeader = SFOHeader.read(fIn);

                for (int i = 0; i < sfoHeader.getNumberDataItems(); i++)
                {
                    indexTableEntryList.Add(SFOIndexTableEntry.readEntry(fIn));
                }

                // Zum KeyTable Anfang springen 
                // (offset der KeyTabelle - Header-Lהnge - Anzahl * IndexEntry Lהnge = restl. zu ignorierende Bytes)
                int skipBytesToKeyTable = sfoHeader.getOffsetKeyTable() - HEADER_SIZE - (sfoHeader.getNumberDataItems() * SFOIndexTableEntry.INDEX_TABLE_ENTRY_LENGTH);
                fIn.Seek(skipBytesToKeyTable, SeekOrigin.Current);

                // read KeyTable
                SFOKeyTableEntry sfoKeyTableEntry = new SFOKeyTableEntry();
                for (int i = 0; i < sfoHeader.getNumberDataItems(); i++)
                {
                    keyTableEntryList.Add(sfoKeyTableEntry.readEntry(fIn));
                }

                long skipBytesToValueTable = sfoHeader.getOffsetValueTable() - sfoHeader.getOffsetKeyTable() - sfoKeyTableEntry.getKeyTableLength();
                fIn.Seek(skipBytesToValueTable, SeekOrigin.Current);

                // read ValueTable
                SFOValueTableEntry sfoValueTableEntry = new SFOValueTableEntry();
                for (int i = 0; i < sfoHeader.getNumberDataItems(); i++)
                {
                    valueTableEntryList.Add(sfoValueTableEntry.readEntry(fIn, (SFOIndexTableEntry)indexTableEntryList[i]).Replace("\0",""));
                }

                for (int i = 0; i < keyTableEntryList.Count; i++)
                {
                    keyValueMap.Add(keyTableEntryList[i].ToString(), valueTableEntryList[i].ToString());
                }

                fIn.Close();
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.Message);
            }
        }

        /**
         * Returns the keys found in the sfo-File
         * 
         * @return List<String>
         */
        public ArrayList getKeyTableEntryList()
        {
            return keyTableEntryList;
        }

        /**
         * Returns the dataValues found in the sfo-File
         * 
         * @return List<String>
         */
        public ArrayList getValueTableEntryList()
        {
            return valueTableEntryList;
        }

        /**
         * Returns the title/dataValues found in the sfo-File.
         * Key of the Map is the title and value of the Map is the dataValue
         * that fits to the title.
         * 
         * @return Map<String, String>
         */
        public Dictionary<String, String> getKeyValueMap()
        {
            return keyValueMap;
        }
    }
}
