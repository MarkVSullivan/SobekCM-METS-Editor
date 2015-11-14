namespace SobekCM.METS_Editor.BatchImport
{
    public enum Importer_Type_Enum
    {
        METS = 0,
        MARC,
        Spreadsheet
    }

    interface iImporter_Process
    {
        Importer_Type_Enum Importer_Type { get; }
    }

}
