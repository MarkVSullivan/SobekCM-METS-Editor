#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DLC.Tools;
using SobekCM.METS_Editor.Template;
using SobekCM.Resource_Object;

#endregion

namespace SobekCM.METS_Editor.Elements
{
	/// <summary>
	/// Summary description for Temporal_Complex_Element.
	/// </summary>
	public class Temporal_Complex_Element : abstract_Element, iElement
	{
		protected TextBox thisPeriodBox, thisStartBox, thisEndBox;
		protected string start, end, period;
		private int start_length, end_length, period_length;

		public Temporal_Complex_Element()
		{
			// Configure the start year box
			thisStartBox = new TextBox();
			thisStartBox.Width = 55;
			thisStartBox.Location = new Point( 115, 2 );
			thisStartBox.BackColor = Color.White;
            thisStartBox.TextChanged += subElement_TextChanged;
            thisStartBox.Enter += textBox_Enter;
            thisStartBox.Leave += textBox_Leave;
            thisStartBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisStartBox );

			// Configure the end year box
			thisEndBox = new TextBox();
			thisEndBox.Width = 55;
			thisEndBox.Location = new Point( 115, 2 );
			thisEndBox.BackColor = Color.White;
            thisEndBox.TextChanged += subElement_TextChanged;
            thisEndBox.Enter += textBox_Enter;
            thisEndBox.Leave += textBox_Leave;
            thisEndBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisEndBox );

			// Configure the period name box
			thisPeriodBox = new TextBox();
			thisPeriodBox.Width = 80;
			thisPeriodBox.Location = new Point( 115, 2 );
			thisPeriodBox.BackColor = Color.White;
            thisPeriodBox.TextChanged += subElement_TextChanged;
            thisPeriodBox.Enter += textBox_Enter;
            thisPeriodBox.Leave += textBox_Leave;
            thisPeriodBox.ForeColor = Color.MediumBlue;
			Controls.Add( thisPeriodBox );

			// Set default title to blank
			title = "Temporal Coverage";
			start = "Start Year";
			end = "End Year";
			period = "Period";

			// Set default lengths
			start_length = 69;
			end_length = 56;
			period_length = 45;
			base.maximum_input_length = 550;

			// Set the type of this object
			base.type = Element_Type.Temporal;
			base.display_subtype = "complex";

			// Set some immutable characteristics
			always_single = false;
			always_mandatory = false;

            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                thisPeriodBox.BorderStyle = BorderStyle.FixedSingle;
                thisEndBox.BorderStyle = BorderStyle.FixedSingle;
                thisStartBox.BorderStyle = BorderStyle.FixedSingle;
            }
		}

        void textBox_Leave(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.White;
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            if (!read_only)
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
        }

        /// <summary> Returns the HTML URL Stub </summary>
        /// <returns></returns>
        public override string Help_URL()
        {
            return "temporal_complex";
        }

        private void subElement_TextChanged(object sender, EventArgs e)
        {
            base.OnDataChanged();
        }

		/// <summary> Override the OnPaint method to draw the title before the text box </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the title
			base.Draw_Title( e.Graphics, title );

			// Draw the smaller titles
			Font smallerFont = new Font( Font.FontFamily, Font.SizeInPoints - 1 );

			// Draw the start year
            e.Graphics.DrawString(start + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + 5, 6);

			// Draw the end year
			int end_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( start_length ));
            e.Graphics.DrawString(end + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + end_spot + thisStartBox.Width + 5, 6);

			// Draw the period
			int period_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( end_length + start_length ));
            e.Graphics.DrawString(period + ":", smallerFont, new SolidBrush(Color.DimGray), title_length + period_spot + thisStartBox.Width + thisEndBox.Width + 10, 6);

			// Determine the y-mid-point
			int midpoint = (int) (1.5 * Font.SizeInPoints );

			// If this is repeatable, show the '+' to add another after this one
			base.Draw_Repeatable_Help_Icons( e.Graphics, Width - 22 - Help_Button_Width, midpoint - 8 );

			// Call this for the base
			base.OnPaint (e);
		}

		private void position_boxes()
		{
			// Set the spot for the start
			int start_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( start_length ));
			thisStartBox.Location = new Point( base.title_length + start_spot, thisStartBox.Location.Y );

			// Set the spot for the end box
			int end_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( end_length + start_length ));
			thisEndBox.Location = new Point( base.title_length + end_spot + thisStartBox.Width + 5, thisEndBox.Location.Y );

			// Set the width of the text box and the location
			int period_spot = (int) (( Font.SizeInPoints / 10.0 ) * ( end_length + start_length + period_length ));
            thisPeriodBox.Width = Width - base.title_length - period_spot - 40 - thisStartBox.Width - thisEndBox.Width - Help_Button_Width;
			thisPeriodBox.Location = new Point( base.title_length + period_spot + thisStartBox.Width + thisEndBox.Width + 10, thisPeriodBox.Location.Y );
		}

		#region Methods Implementing the Abstract Methods from abstract_Element class

		/// <summary> Reads the inner data from the Template XML format </summary>
		protected override void Inner_Read_Data( XmlTextReader xmlReadera )
		{

		}

		/// <summary> Writes the inner data into Template XML format </summary>
		protected override string Inner_Write_Data( )
		{
			return String.Empty;
		}

		/// <summary> Perform any height setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Height( float size )
		{
			// Set total height
			int size_int = (int) size;
			Height = size_int + ( size_int + 7 );

			// Now, set the height of the text box
			//			thisBox.Height =  ( size_int + 7 ) + 4;
		}

		/// <summary> Perform any width setting calculations specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Width( int new_width )
		{
////			// Set the spot for the start and end box
////			this.thisStartBox.Location = new Point( base.title_length + 80, thisStartBox.Location.Y );
////			this.thisEndBox.Location = new Point( base.title_length + 215, thisEndBox.Location.Y );
////
////			// Set the width of the text box
////			thisPeriodBox.Width = new_width - base.title_length - 390;
////			thisPeriodBox.Location = new Point( base.title_length + 340, thisPeriodBox.Location.Y );
///
			position_boxes();
		}

		/// <summary> Perform any readonly functions specific to the
		/// implementation of abstract_Element. </summary>
		protected override void Inner_Set_Read_Only()
		{
			if ( base.read_only )
			{
				thisStartBox.ReadOnly = true;
				thisEndBox.ReadOnly = true;
				thisPeriodBox.ReadOnly = true;
				thisStartBox.BackColor = Color.WhiteSmoke;
				thisEndBox.BackColor = Color.WhiteSmoke;
				thisPeriodBox.BackColor = Color.WhiteSmoke;
			}
			else
			{
				thisStartBox.ReadOnly = false;
				thisEndBox.ReadOnly = false;
				thisPeriodBox.ReadOnly = false;
				thisStartBox.BackColor = Color.White;
				thisEndBox.BackColor = Color.White;
				thisPeriodBox.BackColor = Color.White;
			}
		}

		/// <summary> Clones this element, not copying the actual data
		/// in the fields, but all other values. </summary>
		/// <returns>Clone of this element</returns>
		public override abstract_Element Clone()
		{
			// Get the new element
			Temporal_Complex_Element newElement = (Temporal_Complex_Element) Element_Factory.getElement( Type, Display_SubType );
			newElement.Location = Location;
			newElement.Language = Language;
			newElement.Title_Length = Title_Length;
			newElement.Font = Font;
			newElement.Set_Width( Width );
			newElement.Height = Height;
			newElement.Index = Index + 1;

			return newElement;
		}

		/// <summary> Sets the language to use for the user interface on this element. </summary>
		/// <remarks> Sets the text for the label according to language </remarks>
		protected override void Inner_Set_Language( Template_Language newLanguage )
		{
			switch( newLanguage )
			{
				case Template_Language.English:
					title = "Temporal Subject";
					start = "Start Year";
					end = "End Year";
					period = "Period";
                    start_length = 69;
                    end_length = 56;
                    period_length = 45;
					break;
				case Template_Language.Spanish:
					title = "Sujeto Temporal";
					start = "Comience Año";
					end = "Año Del Final";
					period = "Período";
                    start_length = 92;
                    end_length = 80;
                    period_length = 50;
					break;
				case Template_Language.French:
					title = "Sujet Temporel";
					start = "Commencez Année";
					end = "Année De Fin";
					period = "Période";
                    start_length = 120;
                    end_length = 80;
                    period_length = 50;
					break;
				default:
					title = "Temporal Subject - unknown";
					start = "Start Year";
					end = "End Year";
					period = "Period";
					break;
			}
		}

		/// <summary> Set the minimum title length specific to the 
		/// implementation of abstract_Element.  </summary>
		/// <param name="size"> Height of the font </param>
		protected override void Inner_Set_Minimum_Title_Length( Font current_font, Template_Language current_language )
		{
			// Get the size of the font
			float font_size = 10.0F;

			font_size = Font.SizeInPoints;

			// Set the title length
			switch( current_language )
			{
				case Template_Language.English:
					base.minimum_title_length = (int) (font_size * 12);
					break;
				case Template_Language.Spanish:
					base.minimum_title_length = (int) (font_size * 14);
					break;
				case Template_Language.French:
					base.minimum_title_length = (int) (font_size * 14);
					break;
				default:
					base.minimum_title_length = (int) (font_size * 10);
					break;
			}
		}

		/// <summary> Checks the data in this element for validity. </summary>

		/// <returns> TRUE if valid, otherwise FALSE </returns>
		/// <remarks> This sets the <see cref="abstract_Element.Invalid_String" /> value. </remarks>
		public override bool isValid()
		{
			return true;
		}

		/// <summary> Prepares the bib object for the save, by clearing the 
		/// existing data in this element's related field. </summary>
		/// <param name="Bib"> Existing Bib object </param>
		public override void Prepare_For_Save( SobekCM_Item Bib )
		{
			Bib.Bib_Info.Clear_TemporalSubjects();
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object into which to save this element's data </param>
		public override void Save_To_Bib( SobekCM_Item Bib )
		{
			if (( thisStartBox.Text.Trim().Length > 0 ) ||
				( thisEndBox.Text.Trim().Length > 0 ) ||
				( thisPeriodBox.Text.Trim().Length > 0 ))
			{
				int temp_start = -1;
				int temp_end = -1;
				try
				{
					if ( thisStartBox.Text.Trim().Length > 0 )
					{
						temp_start = Convert.ToInt16( thisStartBox.Text.Trim() );
					}
				}
				catch { }
				try
				{
					if ( thisEndBox.Text.Trim().Length > 0 )
					{
						temp_end = Convert.ToInt16( thisEndBox.Text.Trim() );
					}
				}
				catch { }

				Bib.Bib_Info.Add_Temporal_Subject( temp_start, temp_end, thisPeriodBox.Text.Trim() );
			}
		}

		/// <summary> Saves the data stored in this instance of the 
		/// element to the provided bibliographic object </summary>
		/// <param name="Bib"> Object to populate this element from </param>
		public override void Populate_From_Bib( SobekCM_Item Bib )
		{
			if ( base.index < Bib.Bib_Info.TemporalSubjects.Count )
			{
				thisPeriodBox.Text = Bib.Bib_Info.TemporalSubjects[ base.index ].TimePeriod;
                int start_year = Bib.Bib_Info.TemporalSubjects[ base.index ].Start_Year;
                if (( start_year != -1 ) && ( start_year != 0 ))
                    thisStartBox.Text = start_year.ToString();
                int end_year = Bib.Bib_Info.TemporalSubjects[base.index].End_Year;
                if ((end_year != -1) && (end_year != 0))
                    thisEndBox.Text = end_year.ToString();
			}
		}

		/// <summary> Gets the flag indicating this element has an entered value </summary>
		public override bool hasValue
		{
			get
			{
				if (( thisStartBox.Text.Trim().Length > 0 ) || ( thisPeriodBox.Text.Trim().Length > 0 ) || ( thisEndBox.Text.Trim().Length > 0 ))
					return true;
				else
					return false;
			}
		}

		#endregion

	}
}
