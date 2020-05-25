using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Services.Utils.Constants
{
    public class ContentConstants
    {
        public const string HallPriceContent = "HallPrice";
        public const string HallRulesContent = "HallRules";
        public const string PuppyRecommendations = "PuppyRecommendations";
        public const string PuppyDemands = "PuppyDemands";
        public const string BreedContent = "Breed";
        public const string HallAbout = "HallAbout";
        public const string HotelAbout = "HotelAbout";
        public const string HotelPrice = "HotelPrice";
        public const string HotelRules = "HotelRules";

        public const string HotelContents = HotelAbout + HotelPrice + HotelRules;
        public const string KennelContents = BreedContent + PuppyRecommendations + PuppyDemands;
        public const string BuyPuppyContents = PuppyRecommendations + PuppyDemands;
        public const string HallContents = HallPriceContent + HallRulesContent + HallAbout;
        public const string NoContentImgContents = HotelContents + HallContents;
        public const string NoLinkOrImgContents = HotelContents + HallContents;
    }
}
