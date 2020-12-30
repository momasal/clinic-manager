﻿using System;
using System.Diagnostics;

namespace FinalProject
{
    public interface IBankAccount
    {
        string AccountNumber { get; set; }
        int Balance { get; }
        int ReduceBalance(int value);
        int IncreaseBalance(int value);
    }

    class BankAccount : IBankAccount
    {
        private int balance;

        public BankAccount(string accountNumber, int balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public string AccountNumber { get; set; }

        public int Balance
        {
            get => balance;
            private set
            {
                if (value < 0)
                    throw new ArithmeticException();
                balance = value;
            }
        }
        /**
         * Summary:
         * withdraw from the bank account
         * Returns:
         * (-1) --> if account balance is not enough
         * (positive number) --> new balance value
         **/
        public int ReduceBalance(int value)
        {
            try
            {
                Debug.Assert(value > 0);
                Balance -= value;
                return Balance;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        /**
         * Summary:
         * Increase bank account balance
         * Returns:
         * new balance value
         **/
        public int IncreaseBalance(int value)
        {
            Debug.Assert(value > 0);
            Balance += value;
            return Balance;
        }
    }
}
