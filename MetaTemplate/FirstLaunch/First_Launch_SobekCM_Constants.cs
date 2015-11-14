#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SobekCM.METS_Editor.Settings;

#endregion

namespace SobekCM.METS_Editor.FirstLaunch
{
    public partial class First_Launch_SobekCM_Constants : Form
    {
        public First_Launch_SobekCM_Constants()
        {
            InitializeComponent();

            // Populate all the sobekcm default aggregations
            List<string> aggregations = MetaTemplate_UserSettings.SobekCM_Aggregations;
            if (aggregations != null)
            {
                if (aggregations.Count > 0) aggregationTextBox1.Text = aggregations[0];
                if (aggregations.Count > 1) aggregationTextBox2.Text = aggregations[1];
                if (aggregations.Count > 2) aggregationTextBox3.Text = aggregations[2];
                if (aggregations.Count > 3) aggregationTextBox4.Text = aggregations[3];
                if (aggregations.Count > 4) aggregationTextBox5.Text = aggregations[4];
            }

            // Populate all the sobekcm default wordmarks
            List<string> wordmars = MetaTemplate_UserSettings.SobekCM_Wordmarks;
            if (wordmars != null)
            {
                if (wordmars.Count > 0) wordmarksTextBox1.Text = wordmars[0];
                if (wordmars.Count > 1) wordmarksTextBox2.Text = wordmars[1];
                if (wordmars.Count > 2) wordmarksTextBox3.Text = wordmars[2];
                if (wordmars.Count > 3) wordmarksTextBox4.Text = wordmars[3];
                if (wordmars.Count > 4) wordmarksTextBox5.Text = wordmars[4];
            }

            // Populate all the sobekcm default web skins
            List<string> webskins = MetaTemplate_UserSettings.SobekCM_Web_Skins;
            if (webskins != null)
            {
                if (webskins.Count > 0) webSkinTextBox1.Text = webskins[0];
                if (webskins.Count > 1) webSkinTextBox2.Text = webskins[1];
                if (webskins.Count > 2) webSkinTextBox3.Text = webskins[2];
                if (webskins.Count > 3) webSkinTextBox4.Text = webskins[3];
                if (webskins.Count > 4) webSkinTextBox5.Text = webskins[4];
            }

            // Populate all the sobekcm default viewers
            List<string> viewers = MetaTemplate_UserSettings.SobekCM_Viewers;
            if (viewers != null)
            {
                if (viewers.Count > 0) viewersComboBox1.Text = viewers[0];
                if (viewers.Count > 1) viewersComboBox2.Text = viewers[1];
                if (viewers.Count > 2) viewersComboBox3.Text = viewers[2];
                if (viewers.Count > 3) viewersComboBox4.Text = viewers[3];
            }

        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Khaki;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void continueButton_Button_Pressed(object sender, EventArgs e)
        {
            // Populate all the sobekcm default aggregations
            List<string> aggregations = new List<string>();
            if (aggregationTextBox1.Text.Trim().Length > 0) aggregations.Add(aggregationTextBox1.Text.Trim().ToUpper());
            if ((aggregationTextBox2.Text.Trim().Length > 0) && ( !aggregations.Contains(aggregationTextBox2.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox2.Text.Trim().ToUpper());
            if ((aggregationTextBox3.Text.Trim().Length > 0) && ( !aggregations.Contains(aggregationTextBox3.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox3.Text.Trim().ToUpper());
            if ((aggregationTextBox4.Text.Trim().Length > 0) && ( !aggregations.Contains(aggregationTextBox4.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox4.Text.Trim().ToUpper());
            if ((aggregationTextBox5.Text.Trim().Length > 0) && ( !aggregations.Contains(aggregationTextBox5.Text.Trim().ToUpper()))) aggregations.Add(aggregationTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Aggregations = aggregations;

            // Populate all the sobekcm default wordmarks
            List<string> wordmars = new List<string>();
            if (wordmarksTextBox1.Text.Trim().Length > 0) wordmars.Add(wordmarksTextBox1.Text.Trim().ToUpper());
            if ((wordmarksTextBox2.Text.Trim().Length > 0) && ( !wordmars.Contains(wordmarksTextBox2.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox2.Text.Trim().ToUpper());
            if ((wordmarksTextBox3.Text.Trim().Length > 0) && ( !wordmars.Contains(wordmarksTextBox3.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox3.Text.Trim().ToUpper());
            if ((wordmarksTextBox4.Text.Trim().Length > 0) && ( !wordmars.Contains(wordmarksTextBox4.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox4.Text.Trim().ToUpper());
            if ((wordmarksTextBox5.Text.Trim().Length > 0) && ( !wordmars.Contains(wordmarksTextBox5.Text.Trim().ToUpper()))) wordmars.Add(wordmarksTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Wordmarks = wordmars;

            // Populate all the sobekcm default web skins
            List<string> webskins = new List<string>();
            if (webSkinTextBox1.Text.Trim().Length > 0) webskins.Add(webSkinTextBox1.Text.Trim().ToUpper());
            if ((webSkinTextBox2.Text.Trim().Length > 0) && ( !webskins.Contains(webSkinTextBox2.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox2.Text.Trim().ToUpper());
            if ((webSkinTextBox3.Text.Trim().Length > 0) && ( !webskins.Contains(webSkinTextBox3.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox3.Text.Trim().ToUpper());
            if ((webSkinTextBox4.Text.Trim().Length > 0) && ( !webskins.Contains(webSkinTextBox4.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox4.Text.Trim().ToUpper());
            if ((webSkinTextBox5.Text.Trim().Length > 0) && ( !webskins.Contains(webSkinTextBox5.Text.Trim().ToUpper()))) webskins.Add(webSkinTextBox5.Text.Trim().ToUpper());
            MetaTemplate_UserSettings.SobekCM_Web_Skins = webskins;

            // Populate all the sobekcm default viewers
            List<string> viewers = new List<string>();
            if (viewersComboBox1.Text.Trim().Length > 0) viewers.Add(viewersComboBox1.Text.Trim());
            if (viewersComboBox2.Text.Trim().Length > 0) viewers.Add(viewersComboBox2.Text.Trim());
            if (viewersComboBox3.Text.Trim().Length > 0) viewers.Add(viewersComboBox3.Text.Trim());
            if (viewersComboBox4.Text.Trim().Length > 0) viewers.Add(viewersComboBox4.Text.Trim());
            MetaTemplate_UserSettings.SobekCM_Viewers = viewers;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelRoundButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
