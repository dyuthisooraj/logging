using HalcyonApparelsMVC.Models;

namespace HalcyonApparelsMVC.Interfaces
{
    public interface IMailSender
    {
       
       void SendBulkMail(IEnumerable<string> recepientEmails);

    }
}

