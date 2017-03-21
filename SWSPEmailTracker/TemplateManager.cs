using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPEmailTracker.Properties;
using SWSPEmailTracker.web.Infrastructure;
using SWSPEmailTracker.web.SWSPETl.Model;
using Telerik.WinControls;
using Telerik.WinControls.RichTextBox.FormatProviders;
using Telerik.WinControls.RichTextBox.Layout;
using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.RichTextBoc.FileFormats.OpenXml.Docx;
using Telerik.WinControls.RichTextBox.FileFormats.Xaml;
using Telerik.WinControls.RichTextBox.FileFormats.Rtf;
using Telerik.WinControls.RichTextBox.FormatProviders.Txt;
using Telerik.WinControls.RichTextBox.FileFormats.Html;
using Telerik.WinControls.RichTextBox.FileFormats.Pdf;


namespace SWSPEmailTracker
{
    public partial class TemplateManager : Form
    {
        public TemplateManager()
        {
            InitializeComponent();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void TemplateManager_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.TemplateManager_TemplateManager_Load_the_system_will_try_to_fetch_data_from_your_server__so_be_patient_);
            Application.DoEvents();
            var et = new EmailTemplate();
            var a = et.LoadAll();
                // DataAccess.NhSession.Query<EmailTemplate>().ToList();

            comboBox1.DataSource = a;
            comboBox1.DisplayMember = "Descriptor";
            var tr = new TrackImage();
            var ba = tr.LoadAll(); //DataAccess.NhSession.Query<TrackImage>().ToList();

            comboBox2.DataSource = ba;
            comboBox2.DisplayMember = "Descriptor";
            var linktrack = new LinkTrack();
            var ca = linktrack.LoadAll(); // DataAccess.NhSession.Query<LinkTrack>().ToList();

            comboBox3.DataSource = ca;
            comboBox3.DisplayMember = "Descriptor";


        }

        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            
            string myHTMLString = richTextBox1.Text;

            HtmlFormatProvider htmltxt = new HtmlFormatProvider();
            
            TxtFormatProvider msgtxt = new TxtFormatProvider();
            string myTXTString = msgtxt.Export(htmltxt.Import(myHTMLString));
            var et = new EmailTemplate();
            var alltmp = et.LoadAll();//DataAccess.NhSession.Query<EmailTemplate>().ToList();
            var tmps = alltmp.Where(x => x.EmailSubject == textBox3.Text).ToList();
            if (tmps.Count > 0)
            {
                var a = tmps.First();
                a.DKIMDomain = textBox1.Text;
                a.DKIMSelector = textBox2.Text;
                a.EmailHTMLData = Encoding.UTF8.GetBytes(myHTMLString);
                a.EmailPlainData = Encoding.UTF8.GetBytes(myTXTString);
                a.EmailSubject = textBox3.Text;
                a.FromName = textBox5.Text;
                a.Host = textBox6.Text;
                a.Password = textBox8.Text;
                a.ReplyTo = textBox4.Text;
                a.SenderUsername = textBox7.Text;
                a.Update();
                Saveemailtemplatelocally(a);
            }
            else
            {
                var a = new web.SWSPETl.Model.EmailTemplate
                            {
                                DKIMDomain = textBox1.Text,
                                DKIMSelector = textBox2.Text,
                                EmailHTMLData = Encoding.UTF8.GetBytes(myHTMLString),
                                EmailPlainData = Encoding.UTF8.GetBytes(myTXTString),
                                EmailSubject = textBox3.Text,
                                FromName = textBox5.Text,
                                Host = textBox6.Text,
                                Password = textBox8.Text,
                                ReplyTo = textBox4.Text,
                                SenderUsername = textBox7.Text
                            };
                a.Persist();
                Saveemailtemplatelocally(a);
            }

            MessageBox.Show("Saved");
            TemplateManager_Load(sender, e);
        }
        private static void Saveemailtemplatelocally(EmailTemplate emailTemplate)
        {
            var alltmp = SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.EmailTemplate>().ToList();
            var tmps = alltmp.Where(x => x.EmailSubject == emailTemplate.EmailSubject).ToList();
            if (tmps.Count > 0)
            {
                var temp = tmps.First();
                temp.DKIMDomain = emailTemplate.DKIMDomain;
                temp.DKIMSelector = emailTemplate.DKIMSelector;
                temp.EmailHTMLData = emailTemplate.EmailHTMLData;
                temp.EmailPlainData = emailTemplate.EmailPlainData;
                temp.EmailSubject = emailTemplate.EmailSubject;
                temp.FromName = emailTemplate.FromName;
                temp.Host = emailTemplate.Host;
                temp.Password = emailTemplate.Password;
                temp.ReplyTo = emailTemplate.ReplyTo;
                temp.SenderUsername = emailTemplate.SenderUsername;
                temp.ONLineTemplateID = emailTemplate.LocalID;
                temp.Persist();
            }
            else
            {
                var temp = new SWSPET.BL.SWSPET.Model.EmailTemplate
                               {
                                   DKIMDomain = emailTemplate.DKIMDomain,
                                   DKIMSelector = emailTemplate.DKIMSelector,
                                   EmailHTMLData = emailTemplate.EmailHTMLData,
                                   EmailPlainData = emailTemplate.EmailPlainData,
                                   EmailSubject = emailTemplate.EmailSubject,
                                   FromName = emailTemplate.FromName,
                                   Host = emailTemplate.Host,
                                   Password = emailTemplate.Password,
                                   ReplyTo = emailTemplate.ReplyTo,
                                   SenderUsername = emailTemplate.SenderUsername
                                   ,
                                   ONLineTemplateID = emailTemplate.LocalID
                               };
                temp.Persist();
            }
            MessageBox.Show("Saved in local.");

        }

        private void ToolStripButton11Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter =
                    "Web Pages (*.htm,*.html)|*.htm;*.html";
                if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var s = new StreamReader(openDialog.FileName);
                    richTextBox1.Text=s.ReadToEnd();
                }
            }
        }
        //private void OpenDocument()
        //{
        //    using (OpenFileDialog openDialog = new OpenFileDialog())
        //    {
        //        openDialog.Filter = "Word Documents (*.docx,*.doc)|*.docx;*.doc|Web Pages (*.htm,*.html)|*.htm;*.html|Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml";
        //        if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            string extension = System.IO.Path.GetExtension(openDialog.SafeFileName).ToLower();
        //            IDocumentFormatProvider provider = GetProviderByExtension(extension);
        //            if (provider == null)
        //            {
        //                RadMessageBox.Show("Unable to find format provider for extension " + extension, "Error"); return;
        //            }
        //            using (Stream stream = openDialog.OpenFile())
        //            {
        //                RadDocument document = provider.Import(stream);
        //                this.DetachDocument(this.radRichTextBox1.Document);
        //                this.radRichTextBox1.Document = document;
        //                this.AttachDocument(document);
        //                //document.LayoutMode = DocumentLayoutMode.Paged; 
        //            }
        //        } this.radRichTextBox1.Focus();
        //    }
        //}
        private static IDocumentFormatProvider GetProviderByExtension(string extension)
        {
            if (extension == ".xaml") { return new XamlFormatProvider(); }
            if ((extension == ".docx") || (extension == ".doc")) { return new DocxFormatProvider(); }
            if (extension == ".rtf") { return new RtfFormatProvider(); }
            if ((extension == ".htm") || (extension == ".html")) { return new HtmlFormatProvider(); }
            if (extension == ".txt") { return new TxtFormatProvider(); }
            if (extension == ".pdf") { return new PdfFormatProvider(); }
            return null;
        }
        private void AttachDocument(RadDocument document)
        {
            document.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Document_PropertyChanged);
        }
        private void DetachDocument(RadDocument document)
        {
            document.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Document_PropertyChanged);
        }
        private void Document_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RadDocument document = sender as RadDocument;
            //   this.radBtnPrintLayout.ToggleState = document.LayoutMode == DocumentLayoutMode.Paged ? ToggleState.On : ToggleState.Off; 
            //  this.radBtnWebLayout.ToggleState = document.LayoutMode == DocumentLayoutMode.Flow ? ToggleState.On : ToggleState.Off;
        }

        private void radButton6_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void radButton16_Click(object sender, System.EventArgs e)
        {
            var aaa = (EmailTemplate)comboBox1.SelectedItem;
            textBox1.Text = aaa.DKIMDomain;
            textBox2.Text = aaa.DKIMSelector;
            textBox3.Text = aaa.EmailSubject;
            textBox4.Text = aaa.ReplyTo;
            textBox5.Text = aaa.FromName;
            textBox6.Text = aaa.Host;
            textBox7.Text = aaa.SenderUsername;
            textBox8.Text = aaa.Password;
            richTextBox1.Text =Encoding.UTF8.GetString( aaa.EmailHTMLData);

            webBrowser1.DocumentText = Encoding.UTF8.GetString(aaa.EmailHTMLData);
            
        }
        private void SaveDocument()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Word Documents (*.docx,*.doc)|*.docx;*.doc|Web Pages (*.htm,*.html)|*.htm;*.html|Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml";
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string extension = System.IO.Path.GetExtension(saveDialog.FileName).ToLower();
                    IDocumentFormatProvider provider = GetProviderByExtension(extension);
                    if (provider == null)
                    {
                        RadMessageBox.Show("Unable to find format provider for extension " + extension, "Error"); return;
                    }


                    using (

                     Stream stream = saveDialog.OpenFile())
                    {


                    //    provider.Export(radRichTextBox1.Document, stream);
                    }


                }
            }
        }
        private void radButton17_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter =
                    "Web Pages (*.htm,*.html)|*.htm;*.html";
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var sw = new StreamWriter(saveDialog.FileName);
                    sw.Write(richTextBox1.Text);
                    MessageBox.Show("Saved.");
                }
            }

        }

        private void RadButton3Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText="<p><b>VisitorIDentificationName</b></p>";
                  

                //    radRichTextBox1.Document.Insert();
                    
            
            
                
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = richTextBox1.Text;
        }

        private void radButton13_Click(object sender, EventArgs e)
        {
            var o =new  ImageTemplateManager();
            o.ShowDialog();
        }

        private void radButton8_Click(object sender, EventArgs e)
        {

            var ti = (TrackImage) comboBox2.SelectedItem;
            richTextBox1.SelectedText = ti.Tracklink;
         
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            var ti = (LinkTrack)comboBox3.SelectedItem;
            richTextBox1.SelectedText = ti.Tracklink;
        }
    }
}
