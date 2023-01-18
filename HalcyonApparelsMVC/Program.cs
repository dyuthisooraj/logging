using HalcyonApparelsMVC.Interfaces;
using HalcyonApparelsMVC.Services;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAuthenticate, SalesforceAuthenticate>();
builder.Services.AddSingleton<ISalesforceData, SalesforceData>();
builder.Services.AddSingleton<IMailSender, MailSender>();
//builder.Services.AddSingleton<IEmail, Email>();
builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromMinutes(10);
});
;

builder.Services.AddSingleton<FluentEmail.Core.Interfaces.ISender>(x =>
{
    return new FluentEmail.Smtp.SmtpSender(new Func<SmtpClient>(() =>
    {
        var client = new SmtpClient("smtp.sendgrid.net", 587);
        client.SendCompleted += delegate (object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
                System.Diagnostics.Trace.TraceError($"Error sending email: {e.Error.Message}");
            if (sender is SmtpClient)
                (sender as SmtpClient).Dispose();
        };
        return client;
    }));
});

var from = builder.Configuration.GetSection("Email")["From"];

var gmailSender = builder.Configuration.GetSection("Gmail")["Sender"];
var gmailPassword = builder.Configuration.GetSection("Gmail")["Password"];
var gmailPort = Convert.ToInt32(builder.Configuration.GetSection("Gmail")["Port"]);

////---Sendgrid
//var sendGridSender = builder.Configuration.GetSection("Sendgrid")["Sender"];
//var sendGridKey = builder.Configuration.GetSection("Sendgrid")["SendgridKey"];

//builder.Services.AddFluentEmail("testuserhalcyon88@gmail.com", "testuserhalcyon88@gmail.com")
//                .AddRazorRenderer()
//                .AddSendGridSender("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");

//builder.Services.AddFluentEmail(sendGridSender, from)
//                .AddRazorRenderer()
//                .AddSendGridSender(sendGridKey);


builder.Services
    .AddFluentEmail(gmailSender, from)
    .AddRazorRenderer()
    .AddSmtpSender(new SmtpClient("smtp.gmail.com")
    {
        UseDefaultCredentials = false,
        Port = gmailPort,
        Credentials = new NetworkCredential(gmailSender, gmailPassword),
        EnableSsl = true,

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseSalesforceMiddleware();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
   pattern: "{controller=LoginMVC}/{action=Login}/{id?}");
//pattern: "{controller=Home}/{action=AccessoryView}/{id?}");


app.Run();
