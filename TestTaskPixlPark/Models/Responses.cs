using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTaskPixlPark.Models
{
    public class ResponseAuth
    {
        public string RequestToken { get; set; }
        public string AccessToken { get; set; }
        public string Expires { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string Error { get; set; }
        public string Success { get; set; }
        public string RequireSsl { get; set; }

    }

    public class ResponseOrders
    {
        public string ApiVersion { get; set; }
        public string ResponseCode { get; set; }
        public Product[] Result { get; set; }

        public void Start()
        {
            foreach (var res in Result)
            {
                res.DateCreated = StrToNormDateConvert(res.DateCreated);
                res.DateModified = StrToNormDateConvert(res.DateModified);
                res.DatePaid = StrToNormDateConvert(res.DatePaid);
                res.Update();
            }
        }

        public string StrToNormDateConvert(string strDate) 
        {
            if (strDate == null)
                return strDate;
            Regex regex = new Regex(@"\D+");
            DateTime Year1970 = new DateTime(1970, 1, 1, 0, 0, 0);

            double AddMs;
            if (double.TryParse(regex.Replace(strDate, ""), out AddMs))
                return Year1970.AddMilliseconds(AddMs).ToString();
            return strDate;
        }
    }

    public class DeliveryAddress
    {
        public string ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

    }

    public class Shipping
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ShippingType { get; set; }
    }

    public class Product
    {
        public void Update()
        {
            if (DeliveryAddress == null)
                DeliveryAddress = new DeliveryAddress();
            if (Shipping == null)
                Shipping = new Shipping();
        }
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string SourceOrderId { get; set; }
        public string Title { get; set; }
        public string TrackingUrl { get; set; }
        public string Status { get; set; }
        public string RenderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string CommentsCount { get; set; }
        public string DownloadLink { get; set; }
        public string PreviewImageUrl { get; set; }
        public string Price { get; set; }
        public string DiscountPrice { get; set; }
        public string DeliveryPrice { get; set; }
        public string TotalPrice { get; set; }
        public string UserId { get; set; }
        public string UserCompanyAccountId { get; set; }
        public string DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DatePaid { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public Shipping Shipping { get; set; }
    }

}
