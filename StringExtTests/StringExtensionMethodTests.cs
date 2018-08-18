using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiffTheFox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtTests
{
    [TestClass]
    public class StringExtensionMethodTests
    {
        [TestMethod]
        public void TestPartitionByIndex()
        {
            string head, tail;

            (head, tail) = "hello world".Partition(5, 1);
            Assert.AreEqual("hello", head);
            Assert.AreEqual("world", tail);
            
            (head, tail) = "fooBar".Partition(3, 0);
            Assert.AreEqual("foo", head);
            Assert.AreEqual("Bar", tail);

            (head, tail) = "abcde".Partition(0, 2);
            Assert.AreEqual("", head);
            Assert.AreEqual("cde", tail);

            (head, tail) = "testing".Partition(-1, 1);
            Assert.AreEqual("testing", head);
            Assert.AreEqual("", tail);

            string body = "this is a test";

            (head, tail) = body.Partition(body.IndexOf(' '), 1);
            Assert.AreEqual("this", head);
            Assert.AreEqual("is a test", tail);

            (head, tail) = body.Partition(body.LastIndexOf(' '), 1);
            Assert.AreEqual("this is a", head);
            Assert.AreEqual("test", tail);

            (head, tail) = body.Partition(body.IndexOf('?'), 1);
            Assert.AreEqual("this is a test", head);
            Assert.AreEqual("", tail);

            (head, tail) = "ABCDE".Partition(3, 5);
            Assert.AreEqual("ABC", head);
            Assert.AreEqual("", tail);

            Assert.ThrowsException<ArgumentNullException>(() => StringExtensions.Partition(null, 42, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => StringExtensions.Partition("too short", 42, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => StringExtensions.Partition("too low", -123456, 0));
        }

        [TestMethod]
        public void TestPartitionByChar()
        {
            string head, tail;

            (head, tail) = "hello world".Partition(' ');
            Assert.AreEqual("hello", head);
            Assert.AreEqual("world", tail);

            (head, tail) = "nospaces".Partition(' ');
            Assert.AreEqual("nospaces", head);
            Assert.AreEqual("", tail);

            (head, tail) = "".Partition(' ');
            Assert.AreEqual("", head);
            Assert.AreEqual("", tail);

            (head, tail) = "test value=some value".Partition('=');
            Assert.AreEqual("test value", head);
            Assert.AreEqual("some value", tail);

            (head, tail) = "multiple choice answer".Partition(' ');
            Assert.AreEqual("multiple", head);
            Assert.AreEqual("choice answer", tail);
        }

        [TestMethod]
        public void TestPartitionByString()
        {
            string head, tail;

            (head, tail) = "hello:=world".Partition(":=");
            Assert.AreEqual("hello", head);
            Assert.AreEqual("world", tail);

            (head, tail) = "nospaces".Partition(":=");
            Assert.AreEqual("nospaces", head);
            Assert.AreEqual("", tail);

            (head, tail) = "".Partition(":=");
            Assert.AreEqual("", head);
            Assert.AreEqual("", tail);

            (head, tail) = "test value=some value".Partition("=");
            Assert.AreEqual("test value", head);
            Assert.AreEqual("some value", tail);

            (head, tail) = "multiple//choice//answer".Partition("//");
            Assert.AreEqual("multiple", head);
            Assert.AreEqual("choice//answer", tail);
        }

        [TestMethod]
        public void TestIndexOfByFunction()
        {
            string test = "abcdEfgHijKlm";

            Assert.AreEqual(4, test.IndexOf(char.IsUpper));
            Assert.AreEqual(0, test.IndexOf(char.IsLower));
            Assert.AreEqual(-1, test.IndexOf(c => false));

            Assert.AreEqual(10, test.LastIndexOf(char.IsUpper));
            Assert.AreEqual(12, test.LastIndexOf(char.IsLower));
            Assert.AreEqual(-1, test.LastIndexOf(c => false));

            Assert.ThrowsException<ArgumentNullException>(() => StringExtensions.IndexOf(null, c => true));
            Assert.ThrowsException<ArgumentNullException>(() => StringExtensions.LastIndexOf(null, c => true));
            Assert.ThrowsException<ArgumentNullException>(() => StringExtensions.IndexOf("TEST", null));
            Assert.ThrowsException<ArgumentNullException>(() => StringExtensions.LastIndexOf("TEST", null));
        }
    }
}
