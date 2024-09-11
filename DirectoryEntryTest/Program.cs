// See https://aka.ms/new-console-template for more information

using System.DirectoryServices;
using System.Text.Json;

String configFileText = File.ReadAllText("config.json");
Config config = JsonSerializer.Deserialize<Config>(configFileText);

String ldapUrl = config.ldapUrl;
String ldapUser = config.ldapUser;
String ldapPassword = config.ldapPassword;
AuthenticationTypes ldapAuthType = AuthenticationTypes.Encryption | AuthenticationTypes.ServerBind;

DirectoryEntry entry = new DirectoryEntry(ldapUrl, ldapUser, ldapPassword, ldapAuthType);
Console.WriteLine(entry.Parent.Path);
Console.WriteLine("Done");

public class Config
{
    public String ldapUrl;
    public String ldapUser;
    public String ldapPassword;
}