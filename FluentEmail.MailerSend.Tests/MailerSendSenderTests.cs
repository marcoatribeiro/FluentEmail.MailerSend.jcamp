using FluentAssertions;
using FluentEmail.Core;

namespace FluentEmail.MailerSend.Tests;

public class MailerSendSenderTests
{
    [Fact]
    public async Task SendEmailTest()
    {
        const string apiToken = "mlsn.8433f98d5f5dbe7b8330d04899cf204ea9adf538947b60801108564197e40b2b";

        Email.DefaultSender = new MailerSendSender(apiToken);

        var response = await Email
                .From("test@basicondo.com.br", "Test Sender")
                .To("marco.torino@gmail.com", "Test Sender")
                .Subject("Confirmação de registro no BasiCondo " + Guid.NewGuid())
                .Body(@"<!DOCTYPE html><html lang=""pt""><head><title>E-mail do BasiCondo</title><meta name=""viewport"" content=""width=device-width""/><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""/></head><body><h1>Test</h1><p>Este é um e-mail automático enviado pelo Sistema <b>BasiCondo</b>. Favor não responder.</p></body></html>", true)
                .AttachFromFilename(@"file\test.txt")
                .Tag("test_tag")
                .SendAsync()
                .ConfigureAwait(true);

        response.MessageId.Should().BeEmpty();
        response.ErrorMessages.Should().BeEmpty();
        response.Successful.Should().BeTrue();
    }
}
