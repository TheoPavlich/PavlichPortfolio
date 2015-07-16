using System;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountOperations
    {
        public Response<Account> GetAccount(string accountNumber)
        {
            var repo = new AccountRepository();
            var response = new Response<Account>();

            try
            {
                var account = repo.GetAccount(accountNumber);

                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account Not Found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = account;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Account> MakeDeposit(DepositRequest request)
        {
            var response = new Response<Account>();
            var accountToUpdate = request.Account;

            try
            {
                if (request.DepositAmount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must deposit a positive amount.";
                }
                else
                {
                    accountToUpdate.Balance += request.DepositAmount;

                    var repo = new AccountRepository();
                    repo.UpdateAccount(accountToUpdate);
                    response.Success = true;
                    response.Data = accountToUpdate;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<Account> MakeWithdraw(WithdrawRequest request)
        {
            var response = new Response<Account>();
            var accountToUpdate = request.Account;

            try
            {
                if (request.WithdrawAmount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must withdraw a positive amount.";
                }
                else if (request.WithdrawAmount > accountToUpdate.Balance)
                {
                    response.Success = false;
                    response.Message = "Account lacks funds for withdraw. Please choose a smaller amount";
                }
                else
                {
                    accountToUpdate.Balance -= request.WithdrawAmount;

                    var repo = new AccountRepository();
                    repo.UpdateAccount(accountToUpdate);
                    response.Success = true;
                    response.Data = accountToUpdate;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}