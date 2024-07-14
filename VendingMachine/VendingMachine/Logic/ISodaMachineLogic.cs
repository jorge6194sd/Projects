﻿using SodaMachineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Logic
{
    public interface ISodaMachineLogic
    {
        List<SodaModel> ListTypesOfSoda();

        // Takes in an amount and returns the total deposited so far
        decimal MoneyInserted(decimal monetaryAmount);

        // Gets the overall price for sodas - there is no individual pricing
        decimal GetSodaPrice();

        // SodaModel (or null), List<Coin> Change, string ErrorMessage
        (SodaModel soda, List<CoinModel> change, string errorMessage) RequestSoda(SodaModel soda);

        void IssueFullRefund();

        decimal GetMoneyInsertedTotal();

        void AddToSodaInventory(List<SodaModel> sodas);

        List<SodaModel> GetSodaInventory();

        decimal EmptyMoneyFromMachine();

        List<CoinModel> GetCoinInventory();

        void AddToCoinInventory(List<CoinModel> coins);

        decimal GetCurrentIncome();

        decimal GetTotalIncome();
    }
}
