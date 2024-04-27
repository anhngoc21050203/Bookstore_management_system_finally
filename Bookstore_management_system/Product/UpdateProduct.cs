using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Product
{
    public class UpdateProduct
    {
        public static void UpdateProductInDatabase(int productid, string productName, int categoryId, byte[] barcode, string description, byte[] imagePath, decimal unitPrice, int quantityInStock, string publishingCompany, DateTime updateAt, string updateBy)
        {
            using(var context = new BookShopEntities3())
            {
                var existingPro = context.products.FirstOrDefault(s => s.productid == productid);
                if (existingPro != null)
                {
                    existingPro.productid = productid;
                    existingPro.productname = productName;
                    existingPro.categoryid = categoryId;
                    existingPro.barcode = barcode;
                    existingPro.description = description;
                    existingPro.imgpath = imagePath;
                    existingPro.unitprice = unitPrice;
                    existingPro.quantityinstock = quantityInStock;
                    existingPro.publishing_company = publishingCompany;
                    existingPro.updated_at = updateAt;
                    existingPro.update_by = updateBy;
                    context.SaveChanges();

                }
            }
        }
    }
}
