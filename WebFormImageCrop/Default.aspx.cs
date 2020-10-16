using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormImageCrop
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTNCROP_Click(object sender, EventArgs e)
        {
            string UploadFileName = Path.GetFileName(imgUpload.ImageUrl) ;
            string UploadFilePath = Path.Combine(Server.MapPath("~/UploadImg"), UploadFileName);
            string CropFile = "";
            string CropFilePath="";
            if (File.Exists(UploadFilePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(UploadFilePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(X.Value),Convert.ToInt32(Y.Value),Convert.ToInt32(W.Value),Convert.ToInt32(Y.Value));
                //try
                //{
                    Bitmap bitm = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g= Graphics.FromImage(bitm))
                    {
                        g.DrawImage(orgImg,new Rectangle(0,0, bitm.Width,bitm.Height),CropArea,GraphicsUnit.Pixel);
                    }
                    CropFile = "crop_" + UploadFileName;
                    CropFilePath= Path.Combine(Server.MapPath("~/UploadImg/"), CropFile);
                    bitm.Save(CropFilePath);
                    Response.Redirect("~/UploadImg/" + CropFile,false);
                //}
                //catch (Exception EX)
                //{

                //    throw;
                //}
            
            }
            else
            {

            }

        }

        protected void BTNUPLOAD_Click(object sender, EventArgs e)
        {
            string UploadFileName = "";
            string UploadFilePath = "";
            if (FileUpload1.HasFile)
            {
                string EXT = Path.GetExtension(FileUpload1.FileName).ToLower();
                if(EXT ==".jpg"|| EXT == ".jpeg" || EXT==".gif"|| EXT==".png" )
                {
                    UploadFileName = Guid.NewGuid().ToString() + EXT;
                    UploadFilePath = Path.Combine(Server.MapPath("~/UploadImg"), UploadFileName);
                    try
                    {
                        FileUpload1.SaveAs(UploadFilePath);
                        imgUpload.ImageUrl = "~/UploadImg/" + UploadFileName;
                        PnlCrop.Visible = true;
                    }
                    catch (Exception ex)
                    {

                        Label1.Text = "hata : " + ex;
                    }
                }
                else
                {
                    Label1.Text = "dosya uzantısı hatası";
                }
            }
            else
            {
                Label1.Text = "DOSYA SEÇİNİZ";
            }

        }
    }
}