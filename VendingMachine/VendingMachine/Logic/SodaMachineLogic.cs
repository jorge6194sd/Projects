using SodaMachineLibrary.Models;

namespace VendingMachine.Logic
{
    public class SodaMachineLogic : ISodaMachineLogic
    {
        public void AddToCoinInventory(List<CoinModel> coins)
        {
            throw new NotImplementedException();
        }

        public void AddToSodaInventory(List<SodaModel> sodas)
        {
            throw new NotImplementedException();
        }

        public decimal EmptyMoneyFromMachine()
        {
            throw new NotImplementedException();
        }

        public List<CoinModel> GetCoinInventory()
        {
            throw new NotImplementedException();
        }

        public decimal GetCurrentIncome()
        {
            throw new NotImplementedException();
        }

        public decimal GetMoneyInsertedTotal()
        {
            throw new NotImplementedException();
        }

        public List<SodaModel> GetSodaInventory()
        {
            throw new NotImplementedException();
        }

        public decimal GetSodaPrice()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalIncome()
        {
            throw new NotImplementedException();
        }

        public void IssueFullRefund()
        {
            throw new NotImplementedException();
        }

        public List<SodaModel> ListTypesOfSoda()
        {
            throw new NotImplementedException();
        }

        public decimal MoneyInserted(decimal monetaryAmount)
        {
            throw new NotImplementedException();
        }

        public (SodaModel soda, List<CoinModel> change, string errorMessage) RequestSoda(SodaModel soda)
        {
            throw new NotImplementedException();
        }
    }
}
