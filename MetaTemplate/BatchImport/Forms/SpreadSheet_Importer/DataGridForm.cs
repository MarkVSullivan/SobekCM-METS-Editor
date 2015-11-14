#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DLC.Tools;

#endregion

namespace SobekCM.METS_Editor.BatchImport
{
    public partial class DataGridForm : Form
    {
        public DataGridForm()
        {
            InitializeComponent();
        }

        public DataGridForm(DataTable excelDataTbl)
        {
            InitializeComponent();
            dataGridView1.DataSource = excelDataTbl;

            // Perform some additional work if this was not XP theme
            if (!Windows_Appearance_Checker.is_XP_Theme)
            {
                btnCloseForm.FlatStyle = FlatStyle.Flat;
            }
        
            // count the number of valid records in the input table
            int counter = 0;

            // check for empty rows
            foreach (DataRow row in excelDataTbl.Rows)
            {

                bool empty_row = true;
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (row[i].ToString().Length > 0)
                    {
                        empty_row = false;
                        counter++;
                        break;
                    }
                }

                if (empty_row)
                {                                                                                                             
                    // continue to next row in the input table
                    continue;
                }
            }

            // set the display text
            totalRecordsLabel.Text = "Total Records: " + counter.ToString("#,##0;");             
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

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}