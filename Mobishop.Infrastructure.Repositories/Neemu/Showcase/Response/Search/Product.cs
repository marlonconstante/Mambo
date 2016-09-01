using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("originalId")]
        public string OriginalId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("numberOfInstallment")]
        public int NumberOfInstallment { get; set; }

        [JsonProperty("valueOfInstallmentRaw")]
        public string ValueOfInstallmentRaw { get; set; }

        [JsonProperty("valueOfInstallment")]
        public string ValueOfInstallment { get; set; }

        [JsonProperty("review")]
        public int Review { get; set; }

        [JsonProperty("delivery")]
        public int Delivery { get; set; }

        [JsonProperty("freight")]
        public int Freight { get; set; }

        [JsonProperty("kid")]
        public string Kid { get; set; }

        [JsonProperty("priceRaw")]
        public string PriceRaw { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("discountedPriceRaw")]
        public string DiscountedPriceRaw { get; set; }

        [JsonProperty("discountedPrice")]
        public string DiscountedPrice { get; set; }

        [JsonProperty("isAvailable")]
        public int IsAvailable { get; set; }

        [JsonProperty("discountPercent")]
        public string DiscountPercent { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("productUrlStore")]
        public string ProductUrlStore { get; set; }

        [JsonProperty("largeImage")]
        public string LargeImage { get; set; }

        [JsonProperty("ranking")]
        public int Ranking { get; set; }

        [JsonProperty("extendedWarranty")]
        public string ExtendedWarranty { get; set; }

        [JsonProperty("hasAttributes")]
        public int HasAttributes { get; set; }

        [JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        [JsonProperty("extraAttributes")]
        public ExtraAttributes ExtraAttributes { get; set; }

        [JsonProperty("isSize")]
        public bool IsSize { get; set; }

        [JsonProperty("peso")]
        public string Weigth { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("hasDiscount")]
        public bool HasDiscount { get; set; }

        [JsonProperty("vtexMiniCartProdScript")]
        public string VtexMiniCartProdScript { get; set; }

        [JsonProperty("isLast")]
        public bool? IsLast { get; set; }
    }
}

