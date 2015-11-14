#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.MARC;
using SobekCM.Resource_Object.Metadata_File_ReaderWriters;

#endregion

namespace SobekCM.METS_Editor
{
    public partial class Show_MARC_Form : Form
    {

        public Show_MARC_Form( SobekCM_Item item )
        {
            InitializeComponent();

            Marc21_File_ReaderWriter writer = new Marc21_File_ReaderWriter();
            MARC_Record tags = item.To_MARC_Record();

           // writer.Save_As_MARC_XML("test.xml", item, writer.UFDC_Standard_Tags( item, "World Map Collection" ));

            richTextBox1.AppendText("LDR      " + tags.Leader + "\n");
            foreach (MARC_Field tag in tags.Sorted_MARC_Tag_List)
            {
                richTextBox1.AppendText(tag.Tag.ToString().PadLeft(3,'0') + "  " );
                richTextBox1.SelectionColor = Color.Green;
                richTextBox1.AppendText( tag.Indicators );
                richTextBox1.SelectionColor = Color.Black;
                if ((tag.Tag == 8) || (tag.Tag == 7) || (tag.Tag == 6) || (tag.Tag == 5) || (tag.Tag == 1))
                {
                    richTextBox1.AppendText("  " + tag.Control_Field_Value.Replace(" ", "^") + "\n");
                }
                else
                {
                    richTextBox1.AppendText("  ");
                    string[] splitter = tag.Control_Field_Value.Split("|".ToCharArray());
                    foreach (string thisSplit in splitter)
                    {
                        if (thisSplit.Length > 2)
                        {
                            richTextBox1.SelectionColor = Color.Blue;
                            richTextBox1.AppendText("|" + thisSplit.Substring(0, 2));
                            richTextBox1.SelectionColor = Color.Black;
                            richTextBox1.AppendText(thisSplit.Substring(2));
                        }
                    }
                    richTextBox1.AppendText( "\n");
                }
            }
        }
        

        /// <summary> Method is called whenever this form is resized. </summary>
        /// <param name="e"></param>
        /// <remarks> This redraws the background of this form </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Get rid of any current background image
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            if (ClientSize.Width > 0)
            {
                // Create the items needed to draw the background
                Bitmap image = new Bitmap(ClientSize.Width, ClientSize.Height);
                Graphics gr = Graphics.FromImage(image);
                Rectangle rect = new Rectangle(new Point(0, 0), ClientSize);

                // Create the brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, SystemColors.Control, ControlPaint.Dark(SystemColors.Control), LinearGradientMode.Vertical);
                brush.SetBlendTriangularShape(0.33F);

                // Create the image
                gr.FillRectangle(brush, rect);
                gr.Dispose();

                // Set this as the backgroundf
                BackgroundImage = image;
            }
        }

        private void saveButton_Button_Pressed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
