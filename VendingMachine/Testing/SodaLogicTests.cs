using System;
using Xunit;
using VendingMachine.Logic;
namespace Testing

{
    public class SodaLogicTests
    {
        private readonly ISodaMachineLogic testInterface;
    

        [Fact]
        public void EmptyMoneyFromMachine_ShouldThrowNotImplementedException() 
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.EmptyMoneyFromMachine());
        }

        [Fact]
        public void GetCoinInventory_ShouldThrowNotImplementedException()
        {

            /*
             * This method should count how many coins there are of each denomination, inside of the machine
             * For example if the machine already had 3 quarters, and this transaction takes another 2 
             * quarters, then this method, after the transaction, would contain 5 quarters. 
             * So the expected result of quantity of quarters would be 5
             */

            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetCoinInventory());
        }

        [Fact]
        public void GetCurrentIncome_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetCurrentIncome());
        }

        [Fact]
        public void GetMoneyInsertedTotal_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetMoneyInsertedTotal());
        }

        [Fact]
        public void GetSodaInventory_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetSodaInventory());
        }

        [Fact]
        public void GetSodaPrice_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetSodaPrice());
        }

        [Fact]
        public void GetTotalIncome_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.GetTotalIncome());
        }

        [Fact]
        public void IssueFullRefund_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.IssueFullRefund());
        }

        [Fact]
        public void ListTypesOfSoda_ShouldThrowNotImplementedException()
        {
            //ARRANGE

            //ACT

            //ASSERT
            Assert.Throws<NotImplementedException>(() => testInterface.ListTypesOfSoda());
        }

    }
}
