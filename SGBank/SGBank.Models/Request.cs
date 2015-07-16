namespace SGBank.Models
{
    public class DepositRequest
    {
        public decimal DepositAmount { get; set; }
        public Account Account { get; set; }
    }

    public class WithdrawRequest
    {
        public decimal WithdrawAmount { get; set; }
        public Account Account { get; set; }
    }
}