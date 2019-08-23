using CaptainShop.Application.ViewModels.Common;
using CaptainShop.Application.ViewModels.Product;
using CaptainShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();
        
        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize, string sortBy);

        ProductViewModel GetById(int id);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        void Save();

        void ImportExcel(string filePath, int categoryId);

        List<ProductQuantityViewModel> GetQuantities(int productId);

        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        List<ProductImageViewModel> GetImages(int productId);

        void AddImages(int productId, string[] images);

        List<WholePriceViewModel> GetWholePrices(int productId);

        void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);

        List<ProductViewModel> GetHotProduct(int top);

        List<ProductViewModel> GetLastest(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<ProductViewModel> GetUpsellProducts(int top);

        List<TagViewModel> GetProductTags(int productId);

        bool CheckAvailability (int productId, int size, int color);

    }
}
