using System;
using Xunit;
using VendingMachine.Logic;
namespace Testing

{
    public class SodaLogicTests
    {
        private readonly ISodaMachineLogic testInterface;
    
        public SodaLogicTests()
        {
            testInterface = new SodaMachineLogic();
        }

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
