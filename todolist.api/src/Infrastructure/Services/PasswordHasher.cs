using System.Security.Cryptography;
using Core.Interfaces;

namespace Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize =16;
    private const int KeySize=32;
    private const int Iterations=10000;

    public string HashPassword(string password)
    {
        using var algorithm= new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256);
        var salt = algorithm.Salt;
        var key= algorithm.GetBytes(KeySize);

        var hashByte= new byte[SaltSize+KeySize];
        Array.Copy(salt,0, hashByte,0, SaltSize);
        Array.Copy(key,0, hashByte,SaltSize, KeySize);

        return Convert.ToBase64String(hashByte);

    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var key = algorithm.GetBytes(KeySize);

        for (var i = 0; i < KeySize; i++)
        {
            if (hashBytes[SaltSize + i] != key[i])
            {
                return false;
            }
        }

        return true;
    }
}
