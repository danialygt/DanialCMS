using DanialCMS.Core.Domain.Emails.Entities;

namespace DanialCMS.Core.Domain.Emails.Services
{
	public interface IEmailService
	{
		void Send(Message Message);
		//List<Message> ReceiveEmail(int maxCount = 10);
	}




}
