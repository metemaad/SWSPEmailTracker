using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPEmailTracker.web.SWSPETl.Model;


namespace SWSPEmailTracker
{
    public partial class ImageTemplateManager : Form
    {
        private static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
   
        public ImageTemplateManager()
        {
            InitializeComponent();
        }

        private IList<TrackImage> _f;
        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            var tr = new web.SWSPETl.Model.TrackImage();
            var fw = tr.LoadAll();
               //SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query
                 //  <SWSPEmailTracker.web.SWSPETl.Model.TrackImage>().ToList();
            var fs = fw.Where(x => x.TrackTitle == textBox1.Text).ToList();
            if (fs.Count>0)
            {
                var o=MessageBox.Show(textBox1.Text+" Image track is in your server database. do you like to update that track?", "", MessageBoxButtons.YesNo);
                if (o==DialogResult.Yes)
                {
                    var a = fs.First();
                    a.Title = textBox1.Text;
                    var ms = new MemoryStream(Imagedata);
                    a.TrackImageByte = ms.ToArray();
                    a.Update();
                    //search in local
                    var local =
                        SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackImage>().Where(
                            x => x.ServerTrackID == a.Id.ToString()).ToList();
                    if (local.Count>0)
                    {
                        var b = local.First();
                        
                        b.Title = a.Title;
                        b.TrackImageByte = ms.ToArray();
                        b.ServerTrackID = a.LocalID.ToString();
                        b.Persist();
                    }else
                    {
                        var b = new SWSPET.BL.SWSPET.Model.TrackImage
                                    {
                                        Title = a.Title,
                                        TrackImageByte = a.TrackImageByte,
                                        ServerTrackID = a.LocalID.ToString()
                                    };
                        b.Persist();
                    }

                    MessageBox.Show("Updated.");
                }
            }
            else
            {
                var a = new web.SWSPETl.Model.TrackImage
                            {
                                Title = textBox1.Text,
                                TrackImageByte = Imagedata
                            };
                a.Persist();

                var local =
                       SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackImage>().Where(
                           x => x.ServerTrackID == a.Id.ToString()).ToList();
                if (local.Count > 0)
                {
                    var b = local.First();

                    b.Title = a.Title;
                    b.TrackImageByte = a.TrackImageByte;
                    b.ServerTrackID = a.LocalID.ToString();
                    b.Persist();
                }
                else
                {
                    var b = new SWSPET.BL.SWSPET.Model.TrackImage
                    {
                        Title = a.Title,
                        TrackImageByte = a.TrackImageByte,
                        ServerTrackID = a.LocalID.ToString()
                    };
                    b.Persist();
                }
                    
                MessageBox.Show("Inserted.");
            }
            UpdateData();
        }

        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            var fj=(TrackImage)toolStripComboBox1.ComboBox.SelectedItem;
            
            textBox1.Text = fj.Title;
            var ms = new MemoryStream(fj.TrackImageByte);
            Title = fj.Title;
            Imagedata = ms.ToArray();
            pictureBox1.Image = Image.FromStream(ms);

        }
        
        public string Title { get; set; }
        public byte[] Imagedata { get; set; }
        private void ImageTemplateManager_Load(object sender, EventArgs e)
        {
            //SWSPEmailTracker.web.Infrastructure.DataAccess.CreateDatabase();
            UpdateData();
            
        }

        private void UpdateData()
        {
            Application.DoEvents();
            var ti = new web.SWSPETl.Model.TrackImage();
            _f = ti.LoadAll();// SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<SWSPEmailTracker.web.SWSPETl.Model.TrackImage>().ToList();
            
            toolStripComboBox1.ComboBox.DataSource = _f;
            toolStripComboBox1.ComboBox.DisplayMember = "Descriptor";
        }


        private void ToolStripButton6Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {

                
                pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                
                
            }
        }

        private void ToolStripButton4Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {

                
                var ms = new MemoryStream();
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image.Save(ms,ImageFormat.Jpeg);
                Imagedata = ms.ToArray();
            }
        }

        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            Title = textBox1.Text;
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            var g=SWSPET.BL.Infrastructure.DataAccess.NhSession.Query<SWSPET.BL.SWSPET.Model.TrackImage>().ToList();
            foreach (var trackImage in g)
            {
                trackImage.Delete();
            }
            var ti = new TrackImage();
            var fw = ti.LoadAll();
          //SWSPEmailTracker.web.Infrastructure.DataAccess.NhSession.Query<SWSPEmailTracker.web.SWSPETl.Model.TrackImage>().ToList();
            foreach (var trackImage in fw)
            {
                var h = new SWSPET.BL.SWSPET.Model.TrackImage
                            {
                                Title = trackImage.Title,
                                TrackImageByte = trackImage.TrackImageByte,
                                ServerTrackID = trackImage.Id.ToString()
                            };
                h.Persist();
                
            }
            MessageBox.Show("Finished");
        }
    }
}
