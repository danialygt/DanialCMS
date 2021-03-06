﻿using DanialCMS.Core.Domain.Emails.Entities;
using DanialCMS.Core.Domain.Emails.Services;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Emails.Services
{
	public class EmailService : IEmailService
	{
		private readonly IEmailConfiguration _emailConfiguration;

		public EmailService(IEmailConfiguration emailConfiguration)
		{
			_emailConfiguration = emailConfiguration;
		}

		public void Send(Message message)
		{
			var mimeMessage = new MimeMessage();
			mimeMessage.To.AddRange(message.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
			mimeMessage.From.AddRange(message.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

			mimeMessage.Subject = message.Subject;

			mimeMessage.Body = new TextPart(TextFormat.Html)
			{
				Text = message.Content
			};

			
			using (var emailClient = new SmtpClient())
			{
				emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

				emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

				emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

				emailClient.Send(mimeMessage);

				emailClient.Disconnect(true);
			}
		}




		//public List<Message> ReceiveEmail(int maxCount = 10)
		//{
		//	using (var emailClient = new Pop3Client())
		//	{
		//		emailClient.Connect(_emailConfiguration.PopServer, _emailConfiguration.PopPort, true);

		//		emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

		//		emailClient.Authenticate(_emailConfiguration.PopUsername, _emailConfiguration.PopPassword);

		//		List<Message> emails = new List<Message>();
		//		for (int i = 0; i < emailClient.Count && i < maxCount; i++)
		//		{
		//			var message = emailClient.GetMessage(i);
		//			var emailMessage = new Message
		//			{
		//				Content = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
		//				Subject = message.Subject
		//			};
		//			emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
		//			emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
		//			emails.Add(emailMessage);
		//		}

		//		return emails;
		//	}
		//}

	}
}
