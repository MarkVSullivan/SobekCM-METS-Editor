#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor
{
	/// <summary>
	/// Summary description for XML_Panel.
	/// </summary>
	public class XML_Panel : Panel
	{
		private string xml_file;
		private string xml_file_contents;

		public XML_Panel( string XML_File )
		{
			xml_file = XML_File;
			base.AutoScroll = true;

			// Get the file contents
			StreamReader reader = new StreamReader( xml_file );
			xml_file_contents = reader.ReadToEnd() + " ";
			reader.Close();
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			// Define all the needed color brushes
			Brush remarkPen = new SolidBrush( Color.Blue );
			Brush tagPen = new SolidBrush( Color.Maroon );
			Brush dataPen = new SolidBrush( Color.Black );
			Brush namespacePen = new SolidBrush( Color.Red );
			Brush currentBrush = remarkPen;

			// Font
			Font font = new Font( "Courier New", 12F );

			// If there is no length, draw nothing
			if ( xml_file_contents.Trim().Length == 0 )
				return;

			// Draw all the characters
			Graphics g = e.Graphics;
			char thisChar, nextChar;
			int charIndex = 0;
			thisChar = xml_file_contents[0];
			nextChar = xml_file_contents[1];
			bool data_flag = false;
			bool tag_flag = false;
			int total_length = xml_file_contents.Length - 3;
			StringBuilder stringToDraw = new StringBuilder();
			float x = 10;
			float y = 10;
			float longest_line = 10;
			while ( charIndex < total_length )
			{
				switch( thisChar )
				{
					case '<':
						// Is this the beginning of a remark?
						if ( nextChar == '?' )
						{
							// Clear the string and then build the whole remarks
							stringToDraw.Remove( 0, stringToDraw.Length );
							while(( charIndex < total_length ) && !(( thisChar == '?' ) && ( nextChar == '>' )))
							{
								stringToDraw.Append( thisChar );
								charIndex++;
								thisChar = xml_file_contents[ charIndex ];
								nextChar = xml_file_contents[ charIndex + 1 ];
							}
							if ( charIndex < total_length )
							{
								stringToDraw.Append("?>");
								charIndex++;
							}

							// Now, draw this remark
							x += Draw_String( g, stringToDraw.ToString(), font, remarkPen, x, y );
						}
						else
						{
							// Entering tag, so set tag flag to true
							tag_flag = true;

							// Draw this character
							x += Draw_Char( g, thisChar, font, remarkPen, x, y );
						}
						break;

					case '>':
						// Exiting tag, so set tag flag to false
						tag_flag = false;
						
						// Draw this character
						x += Draw_Char( g, thisChar, font, remarkPen, x, y );
						break;

					case '=':
						if ( tag_flag )
						{
							// This is in a tag, so draw in blue
							x += Draw_Char( g, thisChar, font, remarkPen, x, y );
						}
						else
						{
							// Draw this as data
							x += Draw_Char( g, thisChar, font, dataPen, x, y );
						}
						break;

					case '"':
						// Reverse the in data flag
						data_flag = !data_flag;

						// Always draw in blue
						x += Draw_Char( g, thisChar, font, remarkPen, x, y );
						break;

					case '/':
						// Always draw in blue
						x += Draw_Char( g, thisChar, font, remarkPen, x, y );
						break;

					case ' ':
						x += 6;
						break;

					case '\t':
						x += 30;
						break;

					case '\r':
						longest_line = Math.Max( longest_line, x );
						y += 20;
						x = 10;
						break;

					case '\n':
						break;

					default:
						if ( tag_flag )
						{
							// If this is the tag, but is also in data, draw in black
							if ( data_flag )
							{
								// Clear the string and then build the whole data
								stringToDraw.Remove( 0, stringToDraw.Length );
								while(( charIndex < total_length ) && ( thisChar != '"' ) && ( thisChar != '>') && ( thisChar != '\r'))
								{
									stringToDraw.Append( thisChar );
									charIndex++;
									thisChar = xml_file_contents[ charIndex ];
									nextChar = xml_file_contents[ charIndex + 1 ];
								}

								// Step back to the previous character
								charIndex--;

								// Now, draw this remark
								x += Draw_String( g, stringToDraw.ToString(), font, dataPen, x, y );
							}
							else
							{
								// Clear the string and then build the whole data
								stringToDraw.Remove( 0, stringToDraw.Length );
								while(( charIndex < total_length ) && ( thisChar != '"' ) && ( thisChar != '>') && ( thisChar != '\r') && ( thisChar != '=') && ( thisChar != '/'))
								{
									stringToDraw.Append( thisChar );
									charIndex++;
									thisChar = xml_file_contents[ charIndex ];
									nextChar = xml_file_contents[ charIndex + 1 ];
								}

								// Step back to the previous character
								charIndex--;

								// Now, draw this data
								x += Draw_String( g, stringToDraw.ToString(), font, tagPen, x, y );
							}
						}
						else
						{
							// Clear the string and then build the whole data
							stringToDraw.Remove( 0, stringToDraw.Length );
							while(( charIndex < total_length ) && ( thisChar != '<') && ( thisChar != '\r'))
							{
								stringToDraw.Append( thisChar );
								charIndex++;
								thisChar = xml_file_contents[ charIndex ];
								nextChar = xml_file_contents[ charIndex + 1 ];
							}

							// Step back to the previous character
							charIndex--;

							// Now, draw this data
							x += Draw_String( g, stringToDraw.ToString(), font, dataPen, x, y );
						}
						break;
				}

				// Move to the next character
				charIndex++;
				thisChar = xml_file_contents[charIndex];
				nextChar = xml_file_contents[charIndex + 1 ];
			}

			// Add some height to see the last line
			Height = (int) y + 20;
			Width = (int) longest_line;
			

			base.OnPaint (e);
		}

		private float Draw_Char( Graphics g, char thisChar, Font font, Brush brush, float X, float Y )
		{
			// Draw this as a string anyway
			g.DrawString( thisChar.ToString(), font,brush, X, Y );

			return g.MeasureString( thisChar.ToString(), font ).Width - 4;
		}

		private float Draw_String( Graphics g, string thisString, Font font, Brush brush, float X, float Y )
		{
			// Draw this as a string anyway
			g.DrawString( thisString, font, brush, X, Y );

			return g.MeasureString( thisString, font ).Width - 4;
		}
	}
}
