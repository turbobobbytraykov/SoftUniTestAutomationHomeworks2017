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

    }
}
