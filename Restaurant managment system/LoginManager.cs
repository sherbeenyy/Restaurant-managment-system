using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

// class to store login credtionls 
public class LoginManager
{
    private const string CredentialsPath = "credentials.json";

    public Credentials CurrentCredentials { get; private set; }

    public LoginManager()
    {
        if (!LoadCredentials())
        {
            Owner newOwner = new Owner();
            newOwner.SetupOwnerCredentials();
        }
    }

    public bool LoadCredentials()
    {
        if (File.Exists(CredentialsPath))
        {
            string json = File.ReadAllText(CredentialsPath);
            CurrentCredentials = JsonConvert.DeserializeObject<Credentials>(json);
            return true;
        }
        return false;
    }

    public void SaveCredentials()
    {
        string json = JsonConvert.SerializeObject(CurrentCredentials, Formatting.Indented);
        File.WriteAllText(CredentialsPath, json);
    }

    public bool ValidateLogin(string username, string password)
    {
        LoadCredentials();
        if (CurrentCredentials != null && CurrentCredentials.Username == username)
        {
            string hashedInputPassword = Credentials.HashPassword(password);
            return hashedInputPassword == CurrentCredentials.HashedPassword;
        }
        return false;
    }
}

public class Credentials
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    public void SetPassword(string password)
    {
        HashedPassword = HashPassword(password);
    }

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

// Example Owner class

