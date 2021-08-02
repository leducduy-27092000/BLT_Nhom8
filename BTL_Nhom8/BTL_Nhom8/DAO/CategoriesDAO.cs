﻿using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Nhom8.DAO
{

    public class CategoriesDAO
    {
        private WebCayCanh db = new WebCayCanh();
        public List<Category> GetAllCategoiries()
        {
            var listCate = db.Categories.ToList();
            return listCate;
        }

        public List<Product> GetProductsByCategoryId(int? id)
        {
            return db.Products.Where(p => p.Category_Id == id).ToList();

        }


    }
}