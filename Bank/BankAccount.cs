using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс, представляющий банковский счет клиента.
    /// Позволяет выполнять операции списания и пополнения средств.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Сообщение об ошибке: сумма списания превышает баланс.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке: сумма списания меньше нуля.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Конструктор банковского счета.
        /// </summary>
        /// <param name="customerName">Имя владельца счета</param>
        /// <param name="balance">Начальный баланс</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Имя владельца счета.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счета.
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списание средств со счета.
        /// </summary>
        /// <param name="amount">Сумма списания</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Пополнение счета.
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}