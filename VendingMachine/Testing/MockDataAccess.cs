using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Models;

namespace Testing
{
    public class MockDataAccess : IDataAccess
    {
        public List<CoinModel> CoinInventory { get; set; } = new List<CoinModel>();
        public (decimal sodaPrice, decimal cashOnHand, decimal totalIncome) MachineInfo { get; set; }
        public List<SodaModel> SodaInventory { get; set; } = new List<SodaModel>();
        public Dictionary<string, decimal> UserCredit { get; set; } = new Dictionary<string, decimal>();

        public MockDataAccess()
        {
            CoinInventory.Add(new CoinModel { Name = "Quarter", Amount = 0.25M });
            CoinInventory.Add(new CoinModel { Name = "Quarter", Amount = 0.25M });
            CoinInventory.Add(new CoinModel { Name = "Quarter", Amount = 0.25M });
            CoinInventory.Add(new CoinModel { Name = "Quarter", Amount = 0.25M });
            CoinInventory.Add(new CoinModel { Name = "Dime", Amount = 0.1M });
            CoinInventory.Add(new CoinModel { Name = "Dime", Amount = 0.1M });
            CoinInventory.Add(new CoinModel { Name = "Nickle", Amount = 0.05M });
            CoinInventory.Add(new CoinModel { Name = "Nickle", Amount = 0.05M });
            CoinInventory.Add(new CoinModel { Name = "Nickle", Amount = 0.05M });
            CoinInventory.Add(new CoinModel { Name = "Nickle", Amount = 0.05M });
            CoinInventory.Add(new CoinModel { Name = "Nickle", Amount = 0.05M });

            MachineInfo = (0.75M, 25.65M, 201.50M);

            SodaInventory.Add(new SodaModel { Name = "Coke", SlotOccupied = "1" });
            SodaInventory.Add(new SodaModel { Name = "Coke", SlotOccupied = "1" });
            SodaInventory.Add(new SodaModel { Name = "Coke", SlotOccupied = "1" });
            SodaInventory.Add(new SodaModel { Name = "Coke", SlotOccupied = "1" });
            SodaInventory.Add(new SodaModel { Name = "Coke", SlotOccupied = "1" });
            SodaInventory.Add(new SodaModel { Name = "Diet Coke", SlotOccupied = "2" });
            SodaInventory.Add(new SodaModel { Name = "Sprite", SlotOccupied = "3" });
            SodaInventory.Add(new SodaModel { Name = "Sprite", SlotOccupied = "3" });

        }
        void IDataAccess.CoinInventory_AddCoins(List<CoinModel> coins)
        {
            CoinInventory.AddRange(coins);
        }

        List<CoinModel> IDataAccess.CoinInventory_GetAll()
        {
            throw new NotImplementedException();
        }

        List<CoinModel> IDataAccess.CoinInventory_WithdrawCoins(decimal coinValue, int quantity)
        {
            var coins = CoinInventory.Where(x => x.Amount == coinValue).Take(quantity).ToList();

            coins.ForEach(x => CoinInventory.Remove(x));

            return coins;
        }

        decimal IDataAccess.MachineInfo_CashOnHand()
        {
            return MachineInfo.cashOnHand;
        }

        decimal IDataAccess.MachineInfo_EmptyCash()
        {
            var val = MachineInfo;
            decimal output = val.cashOnHand;

            val.cashOnHand = 0;
            MachineInfo = val;

            return output;
        }

        decimal IDataAccess.MachineInfo_SodaPrice()
        {
            return MachineInfo.sodaPrice;
        }

        decimal IDataAccess.MachineInfo_TotalIncome()
        {
            return MachineInfo.totalIncome;
        }

        void IDataAccess.SodaInventory_AddSodas(List<SodaModel> sodas)
        {
            SodaInventory.AddRange(sodas);
        }

        List<SodaModel> IDataAccess.SodaInventory_GetAll()
        {
            return SodaInventory;
        }

        SodaModel IDataAccess.SodaInventory_GetSoda(SodaModel soda)
        {
            return SodaInventory.Where(x => x.Name == soda.Name).FirstOrDefault();
        }

        List<SodaModel> IDataAccess.SodaInventory_GetTypes()
        {
            return SodaInventory.GroupBy(x => x.Name).Select(x => x.First()).ToList();
        }

        void IDataAccess.UserCredit_Clear(string userId)
        {
            if (UserCredit.ContainsKey(userId))
            {
                UserCredit[userId] = 0;
            }
        }

        void IDataAccess.UserCredit_Deposit(string userId)
        {
            if(UserCredit.ContainsKey(userId) == false)
            {
                throw new Exception("User not found for deposit");
            }

            var info = MachineInfo;
            info.cashOnHand += UserCredit[userId];
            info.totalIncome += UserCredit[userId];

            UserCredit.Remove(userId);
        }

        void IDataAccess.UserCredit_Insert(string userId, decimal amount)
        {
            UserCredit.TryGetValue(userId, out decimal currentCredit);
            UserCredit[userId] = currentCredit + amount;
        }

        decimal IDataAccess.UserCredit_Total(string userId)
        {
            UserCredit.TryGetValue(userId, out decimal currentCredit);
            return currentCredit;
        }
    }
}
