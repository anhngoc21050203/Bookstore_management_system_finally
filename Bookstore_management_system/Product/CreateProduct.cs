using System;

namespace Bookstore_management_system.Product
{
    public class CreateProduct
    {
        public static product CreateObjectProduct(int productid, string productName, int categoryId, byte[] barcode, string description, byte[] imagePath, decimal unitPrice, int quantityInStock, string publishingCompany, DateTime createdAt, string createdBy)
        {
            // Tạo đối tượng product mới
            return new product
            {
                productid = productid,
                productname = productName,
                categoryid = categoryId,
                barcode = barcode,
                description = description,
                imgpath = imagePath,
                unitprice = unitPrice,
                quantityinstock = quantityInStock,
                publishing_company = publishingCompany,
                created_at = createdAt,
                created_by = createdBy
            };
        }
    }
}
