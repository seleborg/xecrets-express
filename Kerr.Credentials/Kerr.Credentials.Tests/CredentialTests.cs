using System;
using SecureString = System.Security.SecureString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kerr.Credentials.Tests
{
    [TestClass]
    public class CredentialTests
    {
        [TestMethod]
        public void CtorKey()
        {
            using (Credential credential = new Credential("target-name",
                                                          CredentialType.DomainVisiblePassword))
            {
                Assert.AreEqual("target-name", credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(0, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(0, credential.SecrectLength);
                Assert.AreEqual(0, credential.UserName.Length);
            }
        }

        [TestMethod]
        public void CtorKeyArgs()
        {
            try
            {
                new Credential(null,
                           CredentialType.Generic);

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("targetName", e.ParamName);
            }
        }

        [TestMethod]
        public void CtorFull()
        {
            SecureString password = new SecureString();
            password.AppendChar('s');
            password.AppendChar('e');
            password.AppendChar('c');
            password.AppendChar('r');
            password.AppendChar('e');
            password.AppendChar('t');

            using (Credential credential = new Credential("target-name",
                                                          CredentialType.Generic,
                                                          "user-name",
                                                          password,
                                                          CredentialPersistence.LocalComputer,
                                                          "description"))
            {
                Assert.AreEqual("target-name", credential.TargetName);
                Assert.AreEqual(CredentialType.Generic, credential.Type);
                Assert.AreEqual("description", credential.Description);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.LocalComputer, credential.Persistence);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);
                Assert.AreEqual("user-name", credential.UserName);
            }
        }

        [TestMethod]
        public void CtorFullArgs()
        {
            try
            {
                new Credential(null,
                               CredentialType.Generic,
                               "userName",
                               new SecureString(),
                               CredentialPersistence.Session,
                               "description");

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("targetName", e.ParamName);
            }

            try
            {
                new Credential("targetName",
                               CredentialType.Generic,
                               null,
                               new SecureString(),
                               CredentialPersistence.Session,
                               "description");

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("userName", e.ParamName);
            }

            try
            {
                new Credential("targetName",
                               CredentialType.Generic,
                               "userName",
                               null,
                               CredentialPersistence.Session,
                               "description");

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("password", e.ParamName);
            }

            try
            {
                new Credential("targetName",
                               CredentialType.Generic,
                               "userName",
                               new SecureString(),
                               CredentialPersistence.Session,
                               null);

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("description", e.ParamName);
            }
        }

        [TestMethod]
        public void CtorCopy()
        {
            using (Credential source = new Credential("target-name",
                                                      CredentialType.DomainVisiblePassword))
            using (Credential credential = new Credential(source))
            {
                Assert.AreEqual("target-name", credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(0, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(0, credential.SecrectLength);
                Assert.AreEqual(0, credential.UserName.Length);
            }
        }

        [TestMethod]
        public void CtorCopyArgs()
        {
            try
            {
                new Credential(null);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("copy", e.ParamName);
            }
        }

        [TestMethod]
        public void SetProperties()
        {
            SecureString password = new SecureString();
            password.AppendChar('s');
            password.AppendChar('e');
            password.AppendChar('c');
            password.AppendChar('r');
            password.AppendChar('e');
            password.AppendChar('t');

            using (Credential credential = new Credential("target-name",
                                                          CredentialType.DomainVisiblePassword))
            {
                Assert.AreEqual(0, credential.Description.Length);
                credential.Description = "description";
                Assert.AreEqual("description", credential.Description);

                Assert.AreEqual(0, credential.Password.Length);
                Assert.AreEqual(0, credential.SecrectLength);
                credential.Password = password;
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);

                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                credential.Persistence = CredentialPersistence.LocalComputer;
                Assert.AreEqual(CredentialPersistence.LocalComputer, credential.Persistence);

                Assert.AreEqual(0, credential.UserName.Length);
                credential.UserName = "user-name";
                Assert.AreEqual("user-name", credential.UserName);

                // Tests resetting password code path
                credential.Password = new SecureString();
            }
        }

        [TestMethod]
        public void SaveBadUserName()
        {
            try
            {
                using (Credential credential = new Credential("target-name",
                                                              CredentialType.DomainVisiblePassword))
                {
                    credential.Save();
                }
            }
            catch (UserNameInvalidException e)
            {
                Assert.AreEqual("The syntax of the user name is incorrect.", e.Message);
            }
        }

        [TestMethod]
        public void UserNameArgs()
        {
            try
            {
                using (Credential credential = new Credential("targetName",
                                                              CredentialType.Generic))
                {
                    credential.UserName = null;
                }

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("value", e.ParamName);
            }
        }

        [TestMethod]
        public void PasswordArgs()
        {
            try
            {
                using (Credential credential = new Credential("targetName",
                                                              CredentialType.Generic))
                {
                    credential.Password = null;
                }

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("value", e.ParamName);
            }
        }

        [TestMethod]
        public void DescriptionArgs()
        {
            try
            {
                using (Credential credential = new Credential("targetName",
                                                              CredentialType.Generic))
                {
                    credential.Description = null;
                }

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("value", e.ParamName);
            }
        }

        [TestMethod]
        public void SaveLoad()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string userName = "principal@authority";

            SecureString password = new SecureString();
            password.AppendChar('s');
            password.AppendChar('e');
            password.AppendChar('c');
            password.AppendChar('r');
            password.AppendChar('e');
            password.AppendChar('t');

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.DomainVisiblePassword))
            {
                credential.UserName = userName;
                credential.Password = password.Copy();

                Assert.AreEqual(targetName, credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);
                Assert.AreEqual(userName, credential.UserName);

                credential.Save();

                Assert.AreEqual(targetName, credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);
                Assert.AreEqual(userName, credential.UserName);

                credential.Load();

                Assert.AreEqual(targetName, credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);
                Assert.AreEqual(userName, credential.UserName);
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.DomainVisiblePassword))
            {
                credential.Load();

                Assert.AreEqual(targetName, credential.TargetName);
                Assert.AreEqual(CredentialType.DomainVisiblePassword, credential.Type);
                Assert.AreEqual(0, credential.Description.Length);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTime);
                Assert.AreNotEqual(DateTime.MinValue, credential.LastWriteTimeUtc);
                Assert.AreEqual(password.Length, credential.Password.Length);
                Assert.AreEqual(CredentialPersistence.Session, credential.Persistence);
                Assert.AreEqual(password.Length * 2, credential.SecrectLength);
                Assert.AreEqual(userName, credential.UserName);
            }

            Assert.IsTrue(Credential.Exists(targetName,
                                            CredentialType.DomainVisiblePassword));

            Credential.Delete(targetName,
                              CredentialType.DomainVisiblePassword);

            Assert.IsFalse(Credential.Exists(targetName,
                                             CredentialType.DomainVisiblePassword));
        }

        [TestMethod]
        public void LoadNotFound()
        {
            string targetName = "Kerr.Credentials.Test.Server";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            try
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.Load();
                }

                Assert.Fail();
            }
            catch (CredentialNotFoundException e)
            {
                Assert.AreEqual("No credential exists with the specified target name.", e.Message);
            }
        }

        [TestMethod]
        public void ChangeTargetName()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string userName = "principal@authority";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.DomainVisiblePassword))
            {
                credential.UserName = userName;

                credential.Save();

                Assert.AreEqual(targetName, credential.TargetName);
                credential.ChangeTargetName(targetName + "2");
                Assert.AreEqual(targetName + "2", credential.TargetName);
            }

            using (Credential credential = new Credential(targetName + "2",
                                                          CredentialType.DomainVisiblePassword))
            {
                Assert.AreEqual(targetName + "2", credential.TargetName);
                credential.Load();
                Assert.AreEqual(targetName + "2", credential.TargetName);

                credential.Delete();
            }
        }

        [TestMethod]
        public void ChangeTargetNameArgs()
        {
            try
            {
                using (Credential credential = new Credential("targetName",
                                                              CredentialType.Generic))
                {
                    credential.ChangeTargetName(null);
                }

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("newTargetName", e.ParamName);
            }
        }

        [TestMethod]
        public void ChangeTargetNameNotFound()
        {
            string targetName = "Kerr.Credentials.Test.Server";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            try
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.ChangeTargetName("newName");
                }

                Assert.Fail();
            }
            catch (CredentialNotFoundException e)
            {
                Assert.AreEqual("No credential exists with the specified target name.", e.Message);
            }
        }

        [TestMethod]
        public void ChangeTargetNameDuplicate()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string targetName2 = "Kerr.Credentials.Test.Server2";

            if (!Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.UserName = "a@b";
                    credential.Save();
                }
            }

            if (!Credential.Exists(targetName2,
                                  CredentialType.Generic))
            {
                using (Credential credential = new Credential(targetName2,
                                                              CredentialType.Generic))
                {
                    credential.UserName = "a@b";
                    credential.Save();
                }
            }

            try
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.ChangeTargetName(targetName2);
                }

                Assert.Fail();
            }
            catch (DuplicateTargetNameException e)
            {
                Assert.AreEqual("Another credential exists with the given target name.", e.Message);
            }
        }

        [TestMethod]
        public void ExistsArgs()
        {
            try
            {
                Credential.Exists(null,
                                  CredentialType.Generic);

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("targetName", e.ParamName);
            }
        }

        [TestMethod]
        public void Delete()
        {
            string targetName = "Kerr.Credentials.Test.Server";
            string userName = "principal@authority";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            using (Credential credential = new Credential(targetName,
                                                          CredentialType.DomainVisiblePassword))
            {
                credential.UserName = userName;
                credential.Save();
                credential.Delete();
            }
        }

        [TestMethod]
        public void DeleteNotFound()
        {
            string targetName = "Kerr.Credentials.Test.Server";

            if (Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                Credential.Delete(targetName,
                                  CredentialType.Generic);
            }

            try
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.Delete();
                }

                Assert.Fail();
            }
            catch (CredentialNotFoundException e)
            {
                Assert.AreEqual("No credential exists with the specified target name.", e.Message);
            }
        }

        [TestMethod]
        public void DeleteArgs()
        {
            try
            {
                Credential.Delete(null,
                                  CredentialType.Generic);

                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("targetName", e.ParamName);
            }
        }

        [TestMethod]
        public void Disposed()
        {
            try
            {
                using (Credential credential = new Credential("server",
                                                              CredentialType.Generic))
                {
                    credential.Dispose();
                    credential.Save();
                }

                Assert.Fail();
            }
            catch (ObjectDisposedException e)
            {
                Assert.AreEqual("Cannot access a disposed object.", e.Message);
            }
        }

        [TestMethod]
        public void DoubleLoad()
        {
            string targetName = "Kerr.Credentials.Test.Server";

            if (!Credential.Exists(targetName,
                                  CredentialType.Generic))
            {
                using (Credential credential = new Credential(targetName,
                                                              CredentialType.Generic))
                {
                    credential.UserName = "a@b";
                    credential.Save();
                    credential.Load();

                    // The second load tests a code path where the first secure string
                    // is deleted before the second one is stored
                    credential.Load();
                }
            }
        }
    }
}
