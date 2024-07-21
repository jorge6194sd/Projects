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

    }
}
