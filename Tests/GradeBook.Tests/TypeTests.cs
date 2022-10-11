using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Tests
{
    // Demonstrating a Delegate
    // When creating a Delegate, we use the keyword "delegate" and we need to define the parameters.
    // It can be empty parameters too.
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        private int count = 0;  // Field

        [Fact]
        // We define a method where we use the new type, "WriteLogDelegate".
        public void WriteLogDelegateCanPointToMethod()
        {
            // We define a variable (log) with the Delegate type (WriteLogDelegate).
            WriteLogDelegate log = ReturnMessage;

            // Log will take a new function, of type Delegate.
            // it can be write as:
            // log = ReturnMessage;

            //log = new WriteLogDelegate(ReturnMessage);

            log += ReturnMessage;
            log += IncrementCount;

            // We compare the actual and expected values.
           
            var result = log("Welcome");
            Assert.Equal(3, count);

        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
            // Simple method, where we return a message.
        {
            return message;
        }
        // ......................................................................

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;   
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // It takes the value that is inside of book1, that value is a pointer
            // to reference, and we're going to copy that value into book2 variable.
            //

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
