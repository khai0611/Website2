using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GioiThieuSanPham.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Productname { get; set; }
        public float OldPrice { get; set; }
        public float NewPrice { get; set; }
        public string Manufacturer { get; set; }
        public int Warranty { get; set; }
        public string SummaryInfo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Color { get; set; }

        public List<ProductModel> ListModel()
        {
            var ResultList = new List<ProductModel>();

            ProductModel productModel = new ProductModel();
            productModel.ID = 1;
            productModel.Productname = "Drill";
            productModel.OldPrice = 1000000;
            productModel.NewPrice = 800000;
            productModel.Manufacturer = "Samsung";
            productModel.Warranty = 12;
            productModel.SummaryInfo = "Use battery, no large noise";

            ResultList.Add(productModel);

            ProductModel productModel1 = new ProductModel();
            productModel1.ID = 2;
            productModel1.Productname = "Fan";
            productModel1.OldPrice = 500000;
            productModel1.NewPrice = 300000;
            productModel1.Manufacturer = "Asia";
            productModel1.Warranty = 24;
            productModel1.SummaryInfo = "LOW and HIGH fan settings, features a rear mounted slider speed and power control";

            ResultList.Add(productModel);

            return ResultList;
        }

        public ProductModel Information(int id)
        {
            //id = 1; return sp1
            if (id == 1)
            {
                ProductModel productModel = new ProductModel();
                productModel.ID = 1;
                productModel.Productname = "Drill";
                productModel.OldPrice = 1000000;
                productModel.NewPrice = 800000;
                productModel.Manufacturer = "Samsung";
                productModel.Warranty = 12;
                productModel.SummaryInfo = "Use battery, no large noise";
                return productModel;
            }
            
            //id = 2; return sp2
            if(id == 2)
            {
                ProductModel productModel1 = new ProductModel();
                productModel1.ID = 2;
                productModel1.Productname = "Fan";
                productModel1.OldPrice = 500000;
                productModel1.NewPrice = 300000;
                productModel1.Manufacturer = "Asia";
                productModel1.Warranty = 24;
                productModel1.SummaryInfo = "LOW and HIGH fan settings, features a rear mounted slider speed and power control";
                return productModel1;
            }
            
            //return null;
            return null;
        }
    }
}