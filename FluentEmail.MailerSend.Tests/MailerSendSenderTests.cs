﻿using FluentAssertions;
using FluentEmail.Core;

namespace FluentEmail.MailerSend.Tests;

public class MailerSendSenderTests
{
    [Fact]
    public async void SendEmailTest()
    {
        const string apiToken = "MAILSENDER_API_TOKEN";

        Email.DefaultSender = new MailerSendSender(apiToken);

        var response = await Email
                .From("sender@email.com", "Test Sender")
                .To("test@email.com", "Test recipient")
                .Subject("FluentEmail MailerSend Test")
                .Body("<html><body><h1>Test</h1><p>Greetings from the team, you got this message through MailerSend.</p></body></html>", true)
                .Tag("test_tag")
                .SendAsync()
                .ConfigureAwait(true);

        response.MessageId.Should().BeEmpty();
        response.ErrorMessages.Should().BeEmpty();
        response.Successful.Should().BeTrue();
    }
}
