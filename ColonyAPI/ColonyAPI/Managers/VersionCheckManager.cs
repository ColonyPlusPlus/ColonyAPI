using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ColonyAPI.Managers;

namespace ColonyAPI.Managers
{
    public class VersionManager
    {

        public static string getVersionURL(string modname)
        {
            if(ModManager.modInstalled(modname))
            {
                Classes.Mod m = ModManager.getMod(modname);
                if(m.hasUpdateURL)
                {
                    return m.updateURL;
                }
            }
            return "";
        }

        public static void runVersionCheck(string ModName, Version currenVersion)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;


            WebClient client = new WebClient();
            string latestVersion = client.DownloadString(getVersionURL(ModName));

            if (latestVersion.Length > 0)
            {
                Version latest = new Version(latestVersion);

                var result = currenVersion.CompareTo(latest);
                if (result > 0)
                {
                    // currenversion is greater
                    Helpers.Utilities.WriteLog(ModName, "You are running a newer version than the public release (latest public release: " + latestVersion.ToString() + ")", Helpers.Chat.ChatColour.cyan, Helpers.Chat.ChatStyle.italic);
                }
                else if (result < 0)
                {
                    // latestversion is greater
                    Helpers.Utilities.WriteLog(ModName, "Out of date. Latest version: " + latestVersion.ToString() + "!", Helpers.Chat.ChatColour.red, Helpers.Chat.ChatStyle.italic);
                }
                else
                {
                    // currenversion is greater
                    Helpers.Utilities.WriteLog(ModName, "Up to date.", Helpers.Chat.ChatColour.white, Helpers.Chat.ChatStyle.italic);
                }

                return;
            }

        }

        public static string SinglePlayerrunVersionCheck(string modname, Version currenVersion)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;


            WebClient client = new WebClient();
            string latestVersion = client.DownloadString(getVersionURL(modname));

            if (latestVersion.Length > 0)
            {
                Version latest = new Version(latestVersion);

                var result = currenVersion.CompareTo(latest);
                if (result > 0)
                {
                    // currenversion is greater
                    return "You are running a newer version than the public release of "+modname+" (latest public release: " + latestVersion.ToString() + ")";
                }
                else if (result < 0)
                {
                    // latestversion is greater
                    return modname + " is out of date. Latest version: " + latestVersion.ToString() + "!";
                }
                else
                {
                    // currenversion is greater
                    return modname+" is up to date.";
                }

            }
            return "";
        }

        public static bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool isOk = true;
            // If there are errors in the certificate chain,
            // look at each error to determine the cause.
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                for (int i = 0; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                    {
                        continue;
                    }
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                        break;
                    }
                }
            }
            return isOk;
        }
    }
}
