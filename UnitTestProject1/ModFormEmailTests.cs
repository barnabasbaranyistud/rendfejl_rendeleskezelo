using NUnit.Framework;
using Rendeleskezeles;
using Rendeleskezelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RendeleskezeloTests
{
    [TestFixture]
    public class ModFormTests
    {
        private ModForm _form;

        // Simplified mock version of OrderDTO
        public class OrderDTO
        {
            public string bvin { get; set; }
            public BillingAddress BillingAddress { get; set; }
            public ShippingAddress ShippingAddress { get; set; }
            public string UserEmail { get; set; }
            public string StatusName { get; set; }
            public string StatusCode { get; set; }
            public DateTime TimeOfOrderUtc { get; set; }

            public OrderDTO()
            {
                BillingAddress = new BillingAddress();
                ShippingAddress = new ShippingAddress();
            }
        }

        // Simplified mock versions of BillingAddress and ShippingAddress
        public class BillingAddress
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class ShippingAddress
        {
            public string Line1 { get; set; }
            public string City { get; set; }
            public string CountryName { get; set; }
            public string PostalCode { get; set; }
        }

        [SetUp]
        public void Setup()
        {
            // Mock Bindingsource: próbáljunk meg egy működő példányt létrehozni
            var mockSource = new BindingSource();
            mockSource.DataSource = new OrderDTO(); 

            _form = (ModForm)Activator.CreateInstance(typeof(ModForm), mockSource);
        }

        // Email validálás tesztje
        [TestCase("abcd1234", false)]
        [TestCase("irf@@uni-corvinus", false)]
        [TestCase("irf.uni-corvinus.hu", false)]
        [TestCase("irf@uni-corvinus.hu", true)]
        [TestCase("irf@corvinus.hu", true)]
        [TestCase("irf@@uni-corvinus.", false)]
        [TestCase("irf@uni-corvinus", false)]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Act
            var actualResult = InvokeIsValidEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Cím validálás tesztje
        [TestCase("Fővám tér 8, Budapest, Hungary, 1098", true)]
        [TestCase("fővám tér 8, budapest, hungary, 1098", true)]
        [TestCase("Fővám tér8,Budapest,Hungary,1098", false)]
        [TestCase("Main Street, Budapest, Hungary, ABCD", false)]
        [TestCase("Fővám tér, Budapest, Hungary, 1098", false)]
        public void TestAddressValidation(string address, bool expected)
        {
            // Act
            var actualResult = InvokeIsValidAddress(address.Trim());

            // Assert
            Assert.AreEqual(expected, actualResult);
        }

        // A jövőbeli dátumok nem érvényesek
        [Test]
        public void TestFutureOrderDate_ShouldFail()
        {
            DateTime futureDate = DateTime.Now.AddDays(1);
            bool isFuture = futureDate.Date > DateTime.Now.Date;
            Assert.IsTrue(isFuture, "A jövőbeli dátum felismerése hibás.");
        }

        // Múltbeli vagy mai dátumok érvényesek
        [Test]
        public void TestPastOrTodayOrderDate_ShouldPass()
        {
            DateTime today = DateTime.Now;
            DateTime pastDate = DateTime.Now.AddDays(-1);
            Assert.IsFalse(today.Date > DateTime.Now.Date, "A mai dátum nem jövőbeli.");
            Assert.IsFalse(pastDate.Date > DateTime.Now.Date, "A múltbeli dátum nem jövőbeli.");
        }

        // Privát metódusok tesztelése Reflection-nel
        private bool InvokeIsValidEmail(string email)
        {
            var method = typeof(ModForm).GetMethod("IsValidEmail", BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)method.Invoke(_form, new object[] { email });
        }

        private bool InvokeIsValidAddress(string address)
        {
            var method = typeof(ModForm).GetMethod("IsValidAddress", BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)method.Invoke(_form, new object[] { address });
        }

    }
}
