using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project7_MailRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Db7Project8Entities context = new Db7Project8Entities();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            /* 
             * 1. ADIM: GÜVENLİK (ŞİFRE KONTROLÜ)
             * Kullanıcının girdiği şifreler uyuşmazsa, veritabanını ve mail sunucusunu yormadan 
             * işlemi anında kesiyoruz (return ile) ve uyarı veriyoruz.
             */
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler birbiriyle uyuşmuyor. Lütfen kontrol edip tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /* 
             * 2. ADIM: VERİTABANI KAYIT İŞLEMLERİ
             * 6 haneli rastgele bir doğrulama kodu üretip, formdan gelen diğer verilerle 
             * birlikte TblUser tablosuna kaydediyoruz.
             */
            Random random = new Random();
            int confirmCode = random.Next(100000, 1000000);

            TblUser user = new TblUser();
            user.Email = txtEmail.Text;
            user.Name = txtName.Text;
            user.Password = txtPassword.Text;
            user.Surname = txtSurname.Text;
            user.IsConfirm = false;
            user.ConfirmCode = confirmCode.ToString();

            context.TblUser.Add(user);
            context.SaveChanges();

            #region Mail Kodları 

            /* 
             * 3. ADIM: MAİL İÇERİĞİNİ HAZIRLAMA (MIME MESSAGE)
             * Mailin kimden gideceğini, kime gideceğini, başlığını ve mesajın gövdesine 
             * eklenecek olan 6 haneli kodu (confirmCode) ayarlıyoruz.
             */
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("AdminRegister", "emirhanyilmaz3959@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", txtEmail.Text);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Email Adresinizin Konfirmasyon Kodu: " + confirmCode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Email Konfirmasyon Kodu";

            /* 
             * 4. ADIM: SMTP BAĞLANTISI VE YÖNLENDİRME
             * Gmail'in SMTP sunucusuna bağlanıp kimlik doğrulaması yapıyor ve maili gönderiyoruz. 
             * İşlem başarılı olduğunda kullanıcıyı doğrulama formuna (FrmMailConfirm) aktarıyoruz.
             */
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("emirhanyilmaz3959@gmail.com", "pjcfkvnxwgcmmliv");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            MessageBox.Show("Mail Adresinize Doğrulama Kodu Gönderilmiştir");

            FrmMailConfirm frm = new FrmMailConfirm();
            frm.email = txtEmail.Text;
            frm.Show();

            #endregion
        }
    }
}