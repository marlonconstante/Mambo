using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class ExtraAttributes
    {
        [JsonProperty("categoria")]
        public string Category { get; set; }

        [JsonProperty("Tipo")]
        public List<string> Types { get; set; }

        [JsonProperty("flag_information")]
        public string FlagInformation { get; set; }

        [JsonProperty("sku_name")]
        public string SkuName { get; set; }

        [JsonProperty("marca")]
        public string Brand { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("additional_image_link")]
        public object AdditionalImageLink { get; set; }

        [JsonProperty("m_unit")]
        public string MUnit { get; set; }

        [JsonProperty("u_mult")]
        public string UMult { get; set; }

        [JsonProperty("Sabor")]
        public List<string> Flavor { get; set; }

        [JsonProperty("peso")]
        public string Weigth { get; set; }

        [JsonProperty("Embalagem")]
        public List<string> Packing { get; set; }

        [JsonProperty("Origem e Descrição")]
        public List<string> OriginAndDescription { get; set; }

        [JsonProperty("Especificação")]
        public List<string> Especification { get; set; }
    }
}

