using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            //act
            var actual = currentProduct.SayHello();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHelloParameterizedConstructor()
        {
            //arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";
            //act
            var actual = currentProduct.SayHello();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SayHello_ObjectInitilizer()
        {
            //arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";

            //act
            var actual = currentProduct.SayHello();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Product_Null()
        {
            //arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //act
            var actual = companyName;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConvertMetersToInchesTest()
        {
            //arrange
            var expected = 78.74;

            //act
            var actual = 2 * Product.InchesPerMeter;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MinimumPriceTest_Default()
        {
            //arrange
            var currentProduct = new Product();
            var expected = .96m;

            //act
            var actual = currentProduct.MinimumPrice;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MinimumPriceTest_Bulk()
        {
            //arrange
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;

            //act
            var actual = currentProduct.MinimumPrice;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductName_Format()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer  ";
            var expected = "Steel Hammer";

            //act
            var actual = currentProduct.ProductName;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductName_TooShort()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void ProductName_TooLong()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed Hand Saw";
            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            //act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void ProductName_JustRight()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed Saw";
            string expected = "Steel Bladed Saw";
            string expectedMessage = null;

            //act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void Category_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = "Tools";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Category_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Sequence_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = 1;

            //act
            var actual = currentProduct.SequenceNumber;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Sequence_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected = 5;

            //act
            var actual = currentProduct.SequenceNumber;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductCode_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            var expected = "Tools-0001";

            //act
            var actual = currentProduct.ProductCode;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            //arrange
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            var expected = 55m;

            //act
            var actual = currentProduct.CalculateSuggestedPrice(10m);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}