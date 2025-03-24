﻿using FluentEmail.Core.Models;
using FluentEmail.MailerSend.Utils;

namespace FluentEmail.MailerSend;

internal static class ConversionExtensions
{
    public static Recipient ToRecipient(this Address @this) 
        => new() { Email = @this.EmailAddress, Name = @this.Name };

    public static IEnumerable<Recipient> ToRecipients(this IList<Address> @this) 
        => @this.Select(x => x.ToRecipient());

    public static IEnumerable<Attachment> ToAttachments(this IList<Core.Models.Attachment> @this) 
        => @this.Select(x => new Attachment { Content = x.Data.ToBase64String(), Filename = x.Filename, Id = x.ContentId });

    public static long? ToUnixTime(this DateTime? @this) 
        => @this == null ? null : new DateTimeOffset(@this.Value.ToUniversalTime()).ToUnixTimeSeconds();
}
