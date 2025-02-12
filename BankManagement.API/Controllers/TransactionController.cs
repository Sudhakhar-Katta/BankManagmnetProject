using BankManagment.Core.Entities;
using BankManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BankManagment.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase {

        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService) {
            _transactionService = transactionService;
        }

        [HttpGet("{userId}")]

        public IActionResult GetTransactions(string userId) { 
               var transactions=_transactionService.GetTransactions(userId);
               return Ok(transactions);
        }

        [HttpPost("deposit")]

        public IActionResult Deposit([FromBody] Transaction transactions)
        { 
            var result=_transactionService.Deposit(transactions.UserAccountId,transactions.amount);
            return Ok(new { Message = "Deposit Succesful", Balance = result });

        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw([FromBody] Transaction transactions) {

            var result = _transactionService.Withdraw(transactions.UserAccountId, transaction.Amount);
            if (result < 0) return BadRequest(new { Message = "Insufficent Balances" });

            return Ok(new {Message="Withdraw Succesfull", Balance=result});

        }
}

