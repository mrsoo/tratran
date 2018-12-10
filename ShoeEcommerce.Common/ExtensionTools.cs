using Microsoft.AspNetCore.Http;
using ShoeEcommerce.Model.Accounts;
using System;
using System.Net;
using System.Net.Mail;

namespace ShoeEcommerce.Common
{
    public class ExtensionTools
    {
        public static string emailShop { get => "suutra123@gmail.com"; }
        public static string passemailShop { get => "trannguyensuutra"; }
        public static String GetFullPath(string name)
        {
            return @"/imagesAccount/" + name;
        }

        public static String GetFullMerchantPath(string name)
        {
            return @"/Client/imagesMerchant/" + name;
        }

        public static String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        public static void SendGmail(string email,string subject,string body)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailShop, passemailShop)
            };
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailShop);
            mailMessage.To.Add(email);
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
        }
    }
}