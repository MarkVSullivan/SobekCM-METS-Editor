#region Using directives

using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
    /// <summary> Object used in the metadata template to display and allow the user 
    /// to edit a classification and authority of a bibliographic package.</summary>
    /// <remarks>This class extends the <see cref="keywordScheme_Element"/> object.<br /><br />
    /// Written by Mark Sullivan ( 2011 ).</remarks>
    public class Classification_Element : keywordScheme_Element
    {
        /// <summary> Constructor for a new instance of the Classification_Element class </summary>
        public Classification_Element()
            : base("Classification")
        {
            // Set the type of this object
            base.type = Element_Type.Classification;
            base.display_subtype = "complex";

            // Set some immutable characteristics
            always_single = false;
            always_mandatory = false;
            base.thisSchemeBox.Width = 110;
            base.maximum_input_length = 475;

            // Add the authorities
            base.thisSchemeBox.Items.Add("");
            base.thisSchemeBox.Items.Add("accs");
            base.thisSchemeBox.Items.Add("acmccs");
            base.thisSchemeBox.Items.Add("agricola");
            base.thisSchemeBox.Items.Add("agrissc");
            base.thisSchemeBox.Items.Add("anscr");
            base.thisSchemeBox.Items.Add("ardocs");
            base.thisSchemeBox.Items.Add("asb");
            base.thisSchemeBox.Items.Add("azdocs");
            base.thisSchemeBox.Items.Add("bar");
            base.thisSchemeBox.Items.Add("bcl");
            base.thisSchemeBox.Items.Add("bcmc");
            base.thisSchemeBox.Items.Add("bkl");
            base.thisSchemeBox.Items.Add("blissc");
            base.thisSchemeBox.Items.Add("blsrissc");
            base.thisSchemeBox.Items.Add("cacodoc");
            base.thisSchemeBox.Items.Add("cadocs");
            base.thisSchemeBox.Items.Add("ccpgq");
            base.thisSchemeBox.Items.Add("celex");
            base.thisSchemeBox.Items.Add("chfbn");
            base.thisSchemeBox.Items.Add("clc");
            base.thisSchemeBox.Items.Add("clutscny");
            base.thisSchemeBox.Items.Add("codocs");
            base.thisSchemeBox.Items.Add("cslj");
            base.thisSchemeBox.Items.Add("cstud");
            base.thisSchemeBox.Items.Add("cutterec");
            base.thisSchemeBox.Items.Add("ddc");
            base.thisSchemeBox.Items.Add("dopaed");
            base.thisSchemeBox.Items.Add("ekl");
            base.thisSchemeBox.Items.Add("farl");
            base.thisSchemeBox.Items.Add("fcps");
            base.thisSchemeBox.Items.Add("fiaf");
            base.thisSchemeBox.Items.Add("finagri");
            base.thisSchemeBox.Items.Add("flarch");
            base.thisSchemeBox.Items.Add("fldocs");
            base.thisSchemeBox.Items.Add("frtav");
            base.thisSchemeBox.Items.Add("gadocs");
            base.thisSchemeBox.Items.Add("gfdc");
            base.thisSchemeBox.Items.Add("ghbs");
            base.thisSchemeBox.Items.Add("iadocs");
            base.thisSchemeBox.Items.Add("ifzs");
            base.thisSchemeBox.Items.Add("inspec");
            base.thisSchemeBox.Items.Add("ipc");
            base.thisSchemeBox.Items.Add("jelc");
            base.thisSchemeBox.Items.Add("kab");
            base.thisSchemeBox.Items.Add("kfmod");
            base.thisSchemeBox.Items.Add("kktb");
            base.thisSchemeBox.Items.Add("ksdocs");
            base.thisSchemeBox.Items.Add("kssb");
            base.thisSchemeBox.Items.Add("kuvacs");
            base.thisSchemeBox.Items.Add("laclaw");
            base.thisSchemeBox.Items.Add("ladocs");
            base.thisSchemeBox.Items.Add("lcc");
            base.thisSchemeBox.Items.Add("loovs");
            base.thisSchemeBox.Items.Add("methepp");
            base.thisSchemeBox.Items.Add("midocs");
            base.thisSchemeBox.Items.Add("mmlcc");
            base.thisSchemeBox.Items.Add("modocs");
            base.thisSchemeBox.Items.Add("moys");
            base.thisSchemeBox.Items.Add("mpkkl");
            base.thisSchemeBox.Items.Add("msc");
            base.thisSchemeBox.Items.Add("msdocs");
            base.thisSchemeBox.Items.Add("naics");
            base.thisSchemeBox.Items.Add("nasasscg");
            base.thisSchemeBox.Items.Add("nbdocs");
            base.thisSchemeBox.Items.Add("ncdocs");
            base.thisSchemeBox.Items.Add("ncsclt");
            base.thisSchemeBox.Items.Add("nhcp");
            base.thisSchemeBox.Items.Add("nicem");
            base.thisSchemeBox.Items.Add("njb");
            base.thisSchemeBox.Items.Add("nlm");
            base.thisSchemeBox.Items.Add("nmdocs");
            base.thisSchemeBox.Items.Add("nvdocs");
            base.thisSchemeBox.Items.Add("nwbib");
            base.thisSchemeBox.Items.Add("nydocs");
            base.thisSchemeBox.Items.Add("ohdocs");
            base.thisSchemeBox.Items.Add("okdocs");
            base.thisSchemeBox.Items.Add("ordocs");
            base.thisSchemeBox.Items.Add("padocs");
            base.thisSchemeBox.Items.Add("pssppbkj");
            base.thisSchemeBox.Items.Add("rich");
            base.thisSchemeBox.Items.Add("ridocs");
            base.thisSchemeBox.Items.Add("rilm");
            base.thisSchemeBox.Items.Add("rpb");
            base.thisSchemeBox.Items.Add("rswk");
            base.thisSchemeBox.Items.Add("rubbk");
            base.thisSchemeBox.Items.Add("rubbkd");
            base.thisSchemeBox.Items.Add("rubbkk");
            base.thisSchemeBox.Items.Add("rubbkm");
            base.thisSchemeBox.Items.Add("rubbkmv");
            base.thisSchemeBox.Items.Add("rubbkn");
            base.thisSchemeBox.Items.Add("rubbknp");
            base.thisSchemeBox.Items.Add("rubbko");
            base.thisSchemeBox.Items.Add("rubbks");
            base.thisSchemeBox.Items.Add("rueskl");
            base.thisSchemeBox.Items.Add("rugasnti");
            base.thisSchemeBox.Items.Add("rvk");
            base.thisSchemeBox.Items.Add("sbb");
            base.thisSchemeBox.Items.Add("scdocs");
            base.thisSchemeBox.Items.Add("sddocs");
            base.thisSchemeBox.Items.Add("sdnb");
            base.thisSchemeBox.Items.Add("sfb");
            base.thisSchemeBox.Items.Add("siblcs");
            base.thisSchemeBox.Items.Add("skb");
            base.thisSchemeBox.Items.Add("ssd");
            base.thisSchemeBox.Items.Add("ssgn");
            base.thisSchemeBox.Items.Add("sswd");
            base.thisSchemeBox.Items.Add("stub");
            base.thisSchemeBox.Items.Add("suaslc");
            base.thisSchemeBox.Items.Add("sudocs");
            base.thisSchemeBox.Items.Add("swank");
            base.thisSchemeBox.Items.Add("taikclas");
            base.thisSchemeBox.Items.Add("taykl");
            base.thisSchemeBox.Items.Add("teatkl");
            base.thisSchemeBox.Items.Add("txdocs");
            base.thisSchemeBox.Items.Add("tykoma");
            base.thisSchemeBox.Items.Add("udc");
            base.thisSchemeBox.Items.Add("uef");
            base.thisSchemeBox.Items.Add("undocs");
            base.thisSchemeBox.Items.Add("upsylon");
            base.thisSchemeBox.Items.Add("usgslcs");
            base.thisSchemeBox.Items.Add("utdocs");
            base.thisSchemeBox.Items.Add("veera");
            base.thisSchemeBox.Items.Add("vsiso");
            base.thisSchemeBox.Items.Add("wadocs");
            base.thisSchemeBox.Items.Add("widocs");
            base.thisSchemeBox.Items.Add("wydocs");
            base.thisSchemeBox.Items.Add("ykl");
            base.thisSchemeBox.Items.Add("z");
            base.thisSchemeBox.Items.Add("zdbs");
            base.thisSchemeBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "classification";
        }

        /// <summary> Sets the language to use for the user interface on this element. </summary>
        /// <remarks> Sets the text for the label according to language </remarks>
        protected override void Inner_Set_Language(Template_Language newLanguage)
        {
            switch (newLanguage)
            {
                case Template_Language.English:
                    base.title = "Classification";
                    base.scheme = "Authority";
                    base.Scheme_Length = 65;
                    break;
                case Template_Language.Spanish:
                    base.title = "(Classification)";
                    base.scheme = "(Authority)";
                    base.Scheme_Length = 65;
                    break;
                case Template_Language.French:
                    base.title = "(Classification)";
                    base.scheme = "(Authority)";
                    base.Scheme_Length = 65;
                    break;
                default:
                    base.title = "Classification - unknown";
                    base.scheme = "(Authority)";
                    break;
            }
        }

        /// <summary> Set the minimum title length specific to the 
        /// implementation of abstract_Element.  </summary>
        /// <param name="size"> Height of the font </param>
        protected override void Inner_Set_Minimum_Title_Length(Font current_font, Template_Language current_language)
        {
            // Get the size of the font
            float font_size = 10.0F;

            font_size = Font.SizeInPoints;

            // Set the title length
            switch (current_language)
            {
                case Template_Language.English:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.Spanish:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                case Template_Language.French:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
                default:
                    base.minimum_title_length = (int)(font_size * 10);
                    break;
            }
        }

        /// <summary> Prepares the bib object for the save, by clearing the 
        /// existing data in this element's related field. </summary>
        /// <param name="Bib"> Existing Bib object </param>
        public override void Prepare_For_Save(SobekCM_Item Bib)
        {
            Bib.Bib_Info.Clear_Classifications();
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object into which to save this element's data </param>
        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            if (base.thisKeywordBox.Text.Trim().Length > 0)
            {
                if (base.thisSchemeBox.Text.Trim().Length > 0)
                {
                    Bib.Bib_Info.Add_Classification( base.thisKeywordBox.Text.Trim(), base.thisSchemeBox.Text.ToLower());
                }
                else
                {
                    Bib.Bib_Info.Add_Classification(base.thisKeywordBox.Text );
                }
            }
        }

        /// <summary> Saves the data stored in this instance of the 
        /// element to the provided bibliographic object </summary>
        /// <param name="Bib"> Object to populate this element from </param>
        public override void Populate_From_Bib(SobekCM_Item Bib)
        {
            if (( base.index >= 0 ) && ( base.index < Bib.Bib_Info.Classifications_Count))
            {
                base.thisKeywordBox.Text = Bib.Bib_Info.Classifications[base.index].Classification;
                base.thisSchemeBox.Text = Bib.Bib_Info.Classifications[base.index].Authority.ToLower();
            }
        }
    }
}