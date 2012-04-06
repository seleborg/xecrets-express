using System;
using SecureString = System.Security.SecureString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kerr.Credentials.Tests
{
    [TestClass]
    public class CredentialSetTests
    {
        [TestMethod]
        public void CountProperty()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string userName = "principal@authority";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            int oldCount = 0;

            using (CredentialSet credentials = new CredentialSet())
            {
                oldCount = credentials.Count;
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.Generic))
            {
                credential.UserName = userName;
                credential.Save();
            }

            int newCount = 0;

            using (CredentialSet credentials = new CredentialSet())
            {
                newCount = credentials.Count;
            }

            Assert.AreEqual(oldCount + 1, newCount);
        }

        [TestMethod]
        public void Filter()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string userName = "principal@authority";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            using (CredentialSet credentials = new CredentialSet(targetName))
            {
                Assert.AreEqual(0, credentials.Count);
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.Generic))
            {
                credential.UserName = userName;
                credential.Save();
            }

            using (CredentialSet credentials = new CredentialSet(targetName))
            {
                Assert.AreEqual(1, credentials.Count);

                {
                    Credential credential = credentials[0];

                    Assert.AreEqual(targetName, credential.TargetName);
                    Assert.AreEqual(CredentialType.Generic, credential.Type);
                    Assert.AreEqual(0, credential.Description.Length);
                    Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTime);
                    Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                    Assert.AreEqual(0, credential.Password.Length);
                    Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                    Assert.AreEqual(0 * 2, credential.SecrectLength);
                    Assert.AreEqual(userName, credential.UserName);
                }

                foreach (Credential credential in credentials)
                {
                    Assert.AreEqual(targetName, credential.TargetName);
                    Assert.AreEqual(CredentialType.Generic, credential.Type);
                    Assert.AreEqual(0, credential.Description.Length);
                    Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTime);
                    Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                    Assert.AreEqual(0, credential.Password.Length);
                    Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                    Assert.AreEqual(0 * 2, credential.SecrectLength);
                    Assert.AreEqual(userName, credential.UserName);
                }
            }
        }
    }
}
