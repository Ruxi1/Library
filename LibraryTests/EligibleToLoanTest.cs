using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LibraryTests
{
    [TestClass]
    public class EligibleToLoanTest
    {
        private EligibleToLoan _eligible = null;
        private List<Client> _clients=null;
        [SetUp]
        public void SetUp()
        {
            _eligible = new EligibleToLoan();
            _clients = new List<Client>();
            _clients.Add(new Client("Ruxandra", "ruxi@gmail.com", true, 2));
            _clients.Add(new Client("Maria", "maria@gmail.com", true, 2));
            _clients.Add(new Client("Ana", "ana@gmail.com", false, 2));
            _clients.Add(new Client("Alex", "alex@gmail.com", true, 5));
        }
        [TearDown]
        public void TearDown()
        {
            _eligible=null;
            _clients=null;
        }

        [TestMethod]
        public void IsEligibleToLoan_NotClient_ExpectedFalse()
        {
            this.SetUp();
            Visitor visitor = new Visitor("Ruxi", "ruxi@gmail.com");
            bool result=_eligible.IsEligibleToLoan(visitor,_clients);
            Assert.IsFalse(result);
            this.TearDown();  
        }

        [TestMethod]
        public void IsEligibleToLoan_NotSubscripted_ExpectedFalse()
        {
            this.SetUp();
            Visitor visitor = new Visitor("Ana", "ana@gmail.com");
            bool result = _eligible.IsEligibleToLoan(visitor, _clients);
            Assert.IsFalse(result);
            this.TearDown();
        }

        [TestMethod]
        public void IsEligibleToLoan_HasManyBooks_ExpectedFalse()
        {
            this.SetUp();
            Visitor visitor = new Visitor("Alex", "alex@gmail.com");
            bool result = _eligible.IsEligibleToLoan(visitor, _clients);
            Assert.IsFalse(result);
            this.TearDown();
        }

        [TestMethod]
        public void IsEligibleToLoan_OK_ExpectedTrue()
        {
            this.SetUp();
            Visitor visitor = new Visitor("Maria", "maria@gmail.com");
            bool result = _eligible.IsEligibleToLoan(visitor, _clients);
            Assert.IsTrue(result);
            this.TearDown();
        }
    }
}
