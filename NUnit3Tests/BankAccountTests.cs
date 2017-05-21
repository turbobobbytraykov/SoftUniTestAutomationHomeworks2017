using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit3Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        /*
         * Write a test that check that exception is thrown when you instantiate BankAccount with negative money
         */
        [Test]
        public void TestBankAccountInstantiationException()
        {
            Assert.That(() => { BankAcount bankAccount = new BankAcount(-100); }, Throws.TypeOf<ArgumentException>());
        }

        /*
         * Write a test that check Withdraw() method get right amount of money for bank transfer
         *  If withdraw amount is less than 1000 transfer fee is 5% of withdrawn amount
         *  If withdraw amount is greater than 1000 transfer fee is 2% of withdrawn amount
         */
        [Test]
        public void TestBankAccountWithdraw()
        {
            decimal initialAmount = 3000;
            var bankAccount = new BankAcount(initialAmount);

            Assert.Multiple(() =>
            {
                decimal withdrawAmount = 300;
                decimal expectedLefOverAmount = initialAmount - withdrawAmount - withdrawAmount * 0.05m;
                bankAccount.Withdraw(withdrawAmount);
                Assert.That(bankAccount.Amount, Is.EqualTo(expectedLefOverAmount));

                withdrawAmount = 1500;
                expectedLefOverAmount = bankAccount.Amount - withdrawAmount - withdrawAmount * 0.02m;
                bankAccount.Withdraw(withdrawAmount);
                Assert.That(bankAccount.Amount, Is.EqualTo(expectedLefOverAmount));
            });
        }

        // Write five more tests against BankAccount that test its functionality. Use five different type of asserts for these tests:
        // 1. not instantiated
        [Test]
        public void TestBankAccountInstantiation()
        {
            var bankAccount = new BankAcount(3000);
            Assert.That(bankAccount, Is.Not.Null);
        }

        // 2. less than - when withdrawing
        [Test]
        public void TestBankAccountWithdrawLessThan()
        {
            var bankAccount = new BankAcount(3000);
            bankAccount.Withdraw(300);
            Assert.That(bankAccount.Amount, Is.LessThan(2700));
        }

        // 3. is in range - when withdrawing
        [Test]
        public void TestBankAccountWithdrawInRange()
        {
            var bankAccount = new BankAcount(3000);
            bankAccount.Withdraw(300);
            Assert.That(bankAccount.Amount, Is.InRange(2700 - 2700 * 0.5m, 2700));
        }

        // 4. instance of
        [Test]
        public void TestBankAccountIsInstanceOf()
        {
            var bankAccount = new BankAcount(3000);
            Assert.That(bankAccount, Is.InstanceOf<BankAcount>());
        }

        // 5. is not a NaN
        [Test]
        public void TestBankAccountWithdrawIsNotNaN()
        {
            var bankAccount = new BankAcount(3000);
            bankAccount.Withdraw(300);
            Assert.That(bankAccount.Amount, Is.Not.NaN);
        }
    }
}
