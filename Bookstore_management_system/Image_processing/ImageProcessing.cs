using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Image_processing
{
    public class ImageProcessor
    {
        public static byte[] EncodeImageToVarbinary(Image image)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Tính toán kích thước mới cho ảnh (giảm 50%)
                    int newWidth = (int)(image.Width * 0.5);
                    int newHeight = (int)(image.Height * 0.5);

                    // Tạo một Bitmap mới với kích thước mới
                    Bitmap resizedImage = new Bitmap(image, newWidth, newHeight);

                    // Lưu hình ảnh vào MemoryStream dưới dạng định dạng PNG
                    resizedImage.Save(memoryStream, ImageFormat.Png);

                    // Đặt vị trí của MemoryStream về đầu
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Trả về mảng byte chứa dữ liệu hình ảnh
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mã hóa ảnh: " + ex.Message);
                return null;
            }
        }
        public static byte[] EncodeImageToVarbinaryv2(Image image)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Lưu hình ảnh vào MemoryStream dưới dạng định dạng PNG (hoặc JPEG tùy chọn)
                    image.Save(memoryStream, ImageFormat.Png);

                    // Đặt vị trí của MemoryStream về đầu
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Trả về mảng byte chứa dữ liệu hình ảnh
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mã hóa ảnh: " + ex.Message);
                return null;
            }
        }


        public static Image DecodeImageFromVarbinary(byte[] imageBytes)
        {
            try
            {
                // Tạo MemoryStream từ mảng bytes
                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {
                    // Tạo hình ảnh từ MemoryStream
                    Image image = Image.FromStream(memoryStream);
                    return image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể giải mã ảnh: " + ex.Message);
                return null;
            }
        }

        public static byte[] UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến tệp ảnh được chọn
                string imagePath = openFileDialog.FileName;

                // Đọc dữ liệu từ tệp ảnh và trả về dưới dạng mảng byte
                byte[] imageData = File.ReadAllBytes(imagePath);
                return imageData;
            }
            else
            {
                // Nếu người dùng không chọn ảnh, trả về null
                return null;
            }
        }

    }
}

