using Konscious.Security.Cryptography;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;
using System.Security.Cryptography;
using System.Text;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Securities;

public sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = 4,
            MemorySize = 65536,     // 64 MB
            Iterations = 4
        };

        var hash = argon2.GetBytes(HashSize);

        return Convert.ToBase64String(
            Combine(salt, hash)
        );
    }

    public bool Verify(string hash, string password)
    {
        var decoded = Convert.FromBase64String(hash);

        var salt = decoded[..SaltSize];
        var storedHash = decoded[SaltSize..];

        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = 4,
            MemorySize = 65536,
            Iterations = 4
        };

        var computedHash = argon2.GetBytes(HashSize);

        return CryptographicOperations.FixedTimeEquals(
            storedHash,
            computedHash
        );
    }

    private static byte[] Combine(byte[] a, byte[] b)
    {
        var result = new byte[a.Length + b.Length];
        Buffer.BlockCopy(a, 0, result, 0, a.Length);
        Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
        return result;
    }
}

