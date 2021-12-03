using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        public Product()
        {
            Console.WriteLine("Product instance created");
            //this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
            Console.WriteLine("Product instance has a name: " + ProductName);
        }
        private string productName;
        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }
        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string Description { get; set; }
        public int ProductId { get; set; }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get { 
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor; 
            }
            set { productVendor = value; }
        }
        public DateTime? AvailabilityDate { get; set; }
        public string ValidationMessage { get; private set; }

        public string ProductCode => this.Category + "-" + this.SequenceNumber;

        public decimal Cost { get; set; }

        /// <summary>
        /// Calculates the suggested retail price.
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public decimal CalculateSuggestedPrice(decimal markupPercent) =>
            this.Cost + (this.Cost * markupPercent / 100);


        public string SayHello()
        {
            return "Hello " + ProductName + " (" + ProductId + "): " + Description + " Available on: " + AvailabilityDate?.ToShortDateString();
        }
        public override string ToString()
        {
            return this.productName + " (" + this.ProductId + ")";
        }
    }
}
