using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DidYouFall.Models.Forms.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DidYouFall.Models.Forms.Validations.Tests
{
    [TestClass()]
    public class InputsTests
    {
        Validations.Inputs vld = new Validations.Inputs();
        [TestMethod()]
        [ExpectedException(typeof(Exception), "A senha deve ter pelo menos uma letra e um numero, e entre 4 a 16 characteres")]
        public void PasswordString_WithOnlyNumbers()
        {
            vld.PasswordString("123456");
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "A senha deve ter pelo menos uma letra e um numero, e entre 4 a 16 characteres")]
        public void PasswordStringTestg_WithOnlyLetters()
        {
            vld.PasswordString("abcdefg");
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "A senha deve ter pelo menos uma letra e um numero, e entre 4 a 16 characteres")]
        public void PasswordStringTestg_With3Characters()
        {
            vld.PasswordString("abc");
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception), "A senha deve ter pelo menos uma letra e um numero, e entre 4 a 16 characteres")]
        public void PasswordStringTestg_With20Characters()
        {
            vld.PasswordString("45678910111213141516");
            Assert.Fail();

        }
        [TestMethod()]
        public void PasswordStringTestg_WithOnlyLettersNumbers()
        {
            vld.PasswordString("abcdefg123");

        }
    }
}
