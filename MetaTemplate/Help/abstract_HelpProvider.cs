#region Using directives

using System.Collections.Generic;

#endregion

namespace SobekCM.METS_Editor.Help
{
    public abstract class abstract_HelpProvider
    {
        protected Dictionary<string, string> help_term_to_url;
        protected string default_help_url;

        public abstract_HelpProvider()
        {
            help_term_to_url = new Dictionary<string, string>();
            default_help_url = "http://ufdc.ufl.edu/";
        }

        public virtual string URL_from_Help_Term(string Help_Term)
        {
            if (help_term_to_url.ContainsKey(Help_Term))
                return help_term_to_url[Help_Term];
            else
                return default_help_url;
        }
    }
}
