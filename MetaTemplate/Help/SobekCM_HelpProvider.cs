namespace SobekCM.METS_Editor.Help
{
    public class SobekCM_HelpProvider : abstract_HelpProvider
    {
        public SobekCM_HelpProvider()
        {
            default_help_url = "http://ufdc.ufl.edu/help/metadata";
            
            // Build this help provider
            help_term_to_url.Add("abstract_form", "complexabstract");
            help_term_to_url.Add("abstract_language", "complexabstract");
            help_term_to_url.Add("abstract_simple", "abstract");
            help_term_to_url.Add("affiliation_hier", "affiliation");
            help_term_to_url.Add("attribution", "affiliation");
            help_term_to_url.Add("audience", "targetaudience");
            help_term_to_url.Add("bibid", "bibid");
            help_term_to_url.Add("collection", "collection");
            help_term_to_url.Add("coordinates", "coordinatepoint");
            help_term_to_url.Add("coordinates_form", "coordinateform");
            help_term_to_url.Add("copydate", "copyrightdate");
            help_term_to_url.Add("creation_notes", "creationnote");
            help_term_to_url.Add("creator_form", "complexcreator");
            help_term_to_url.Add("creator_simple", "creator");
            help_term_to_url.Add("donor", "donor");
            help_term_to_url.Add("donor_form", "donor");
            help_term_to_url.Add("ead_form", "ead");
            help_term_to_url.Add("edition", "edition");
            help_term_to_url.Add("encoding_level", "encodinglevel");
            help_term_to_url.Add("fclaFlags", "fclaflags");
            help_term_to_url.Add("fdaaccount", "fdaaccount");
            help_term_to_url.Add("fdaproject", "fdaproject");
            help_term_to_url.Add("fdasubaccount", "fdasubaccount");
            help_term_to_url.Add("format", "physicaldescription");
            help_term_to_url.Add("frequency", "frequency");
            help_term_to_url.Add("genre_scheme", "genre");
            help_term_to_url.Add("genre_simple", "genresimple");
            help_term_to_url.Add("holding_complex", "holding");
            help_term_to_url.Add("holding_simple", "holdingsimple");
            help_term_to_url.Add("identifier_scheme", "identifier");
            help_term_to_url.Add("identifier_simple", "identifiersimple");
            help_term_to_url.Add("language", "language");
            help_term_to_url.Add("manufacturer_form", "complexmanufacturer");
            help_term_to_url.Add("note", "note");
            help_term_to_url.Add("note_form", "complex_note");
            help_term_to_url.Add("othertitle", "othertitle");
            help_term_to_url.Add("othertitle_form", "othertitle");
            help_term_to_url.Add("otherurl", "relatedurl");
            help_term_to_url.Add("palmm_code", "palmmcode");
            help_term_to_url.Add("pubdate", "pubdate");
            help_term_to_url.Add("publisher_form", "complexpublisher");
            help_term_to_url.Add("publisher_simple", "publisher");
            help_term_to_url.Add("pubplace", "pubplace");
            help_term_to_url.Add("pubstatus", "pubstatus");
            help_term_to_url.Add("recordorigin", "recordorigin");
            help_term_to_url.Add("recordstatus", "recordstatus");
            help_term_to_url.Add("relateditem", "relateditem");
            help_term_to_url.Add("rights", "rightsmanagement");
            help_term_to_url.Add("scale", "scale");
            help_term_to_url.Add("serial_form", "serialhierarchy");
            help_term_to_url.Add("source_complex", "source");
            help_term_to_url.Add("source_simple", "sourcesimple");
            help_term_to_url.Add("source_note", "sourcenote");
            help_term_to_url.Add("spatial_complex", "spatial");
            help_term_to_url.Add("spatial_hier", "formspatial");
            help_term_to_url.Add("spatial_simple", "spatial");
            help_term_to_url.Add("subcollection", "subcollection");
            help_term_to_url.Add("subject_form", "formsubject");
            help_term_to_url.Add("subject_scheme", "subjectscheme");
            help_term_to_url.Add("subject_simple", "subject");
            help_term_to_url.Add("temporal_complex", "complextemporal");
            help_term_to_url.Add("temporal_simple", "temporal");
            help_term_to_url.Add("thumb_select", "mainthumbnail");
            help_term_to_url.Add("thumb_simple", "mainthumbnail");
            help_term_to_url.Add("title_form", "titlemain");
            help_term_to_url.Add("title_form_panel", "titlepanel");
            help_term_to_url.Add("title_panel", "titlepanel");
            help_term_to_url.Add("title_simple", "titlesimple");
            help_term_to_url.Add("toc", "structuremap");
            help_term_to_url.Add("type", "type");
            help_term_to_url.Add("type_form", "complextype");
            help_term_to_url.Add("vid", "vid");
            help_term_to_url.Add("view", "viewer");
            help_term_to_url.Add("wordmark", "wordmark");
        }

        public override string URL_from_Help_Term(string Help_Term)
        {
            if (help_term_to_url.ContainsKey(Help_Term))
            {
                return "http://ufdc.ufl.edu/help/" + help_term_to_url[Help_Term];
            }
            else
                return default_help_url;
        }
    }
}
