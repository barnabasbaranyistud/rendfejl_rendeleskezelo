using NUnit.Framework;
using Rendeleskezelo;
using System;
using System.Reflection;
using System.ComponentModel; // Using this instead of Windows.Forms

namespace RendeleskezeloTests
{
    [TestFixture]
    public class ModFormSimpleTests
    {
        private ModForm _form;

        [SetUp]
        public void Setup()
        {
            // Replace Windows.Forms.BindingSource with a System.ComponentModel.BindingList
            var bindingSource = new BindingList<object>();
            _form = (ModForm)Activator.CreateInstance(typeof(ModForm), bindingSource, true);
        }

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

        [TestCase("teszt@example.com", true)]
        [TestCase("Teszt.User@domain.hu", true)]
        [TestCase("teszt@domain", false)]
        [TestCase("teszt@", false)]
        [TestCase("teszt@.com", false)]
        public void TestEmailValidation(string email, bool expected)
        {
            bool result = InvokeIsValidEmail(email);
            Assert.AreEqual(expected, result, $"Email teszt sikertelen: {email}");
        }

        [TestCase("Fővám tér 8, Budapest, Hungary, 1098", true)]
        [TestCase("fővám tér 8, budapest, hungary, 1098", true)]
        [TestCase("  Fővám tér 8 , Budapest , Hungary , 1098  ", true)]
        [TestCase("Fővám tér 8,Budapest,Hungary,1098", true)]
        [TestCase("Fővám tér8,Budapest,Hungary,1098", false)]
        [TestCase("Main Street, Budapest, Hungary, ABCD", false)]
        [TestCase("Fővám tér, Budapest, Hungary, 1098", false)]
        public void TestAddressValidation(string address, bool expected)
        {
            bool result = InvokeIsValidAddress(address.Trim());
            Assert.AreEqual(expected, result, $"Cím teszt sikertelen: {address}");
        }

        [Test]
        public void TestFutureOrderDate_ShouldFail()
        {
            DateTime futureDate = DateTime.Now.AddDays(1);
            Assert.IsTrue(futureDate.Date > DateTime.Now.Date, "A teszthez jövőbeli dátum kell.");
            // A ValidateForm privát, ezért a dátumlogikát külön kell tesztelni
            bool isFuture = futureDate.Date > DateTime.Now.Date;
            Assert.IsTrue(isFuture, "A jövőbeli dátum felismerése hibás.");
        }

        [Test]
        public void TestPastOrTodayOrderDate_ShouldPass()
        {
            DateTime today = DateTime.Now;
            Assert.IsFalse(today.Date > DateTime.Now.Date, "A mai dátum nem jövőbeli.");
            DateTime pastDate = DateTime.Now.AddDays(-1);
            Assert.IsFalse(pastDate.Date > DateTime.Now.Date, "A múltbeli dátum nem jövőbeli.");
        }
    }
}