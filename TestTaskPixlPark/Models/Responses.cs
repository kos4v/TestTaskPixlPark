using System;
using System.Collections.Generic;
using System.Linq;
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
