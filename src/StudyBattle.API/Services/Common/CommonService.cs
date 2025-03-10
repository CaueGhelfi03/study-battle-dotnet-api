using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Security.Cryptography;
using StudyBattle.API.Interfaces.ICommon;

namespace StudyBattle.API.Common
{
    public class CommonService : ICommonService
    {
        public bool IsValidEmail (string emailAddress)
        {
            try
            {
                if(string.IsNullOrEmpty(emailAddress)) throw new ArgumentException("Email cannot be null or empty", nameof(emailAddress));
                MailAddress email = new MailAddress(emailAddress);
                return email.Address == emailAddress;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public string PasswordEncoder(string password)
        {
            if(password.IsNullOrEmpty()) throw new ArgumentNullException("Password cannot be null or empty", nameof(password));

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256/8));

            return hashed;
        }
    }


}
