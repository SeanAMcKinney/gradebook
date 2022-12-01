using Xunit;

namespace GradeBook.Tests
{

     public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            // Long hand:  log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void ValuetypesPassByRef()
        {
        var x = GetInt();
        SetIntByRef(ref x);

        Assert.Equal(42, x);
        }

        private void SetIntByRef(ref int z)
        {
            z = 42;
        }


        [Fact]
        public void ValuetypesAlsoPassByValue()
        {
        var x = GetInt();
        SetInt(x);

        Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByOutInsteadOfRef()
        {
            // Act
            var book1 = GetBook("Book 1");
            GetBookSetNameWithOut (out book1, "New Name");

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameWithOut (out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Act
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            // Act
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Act
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        // String test
        [Fact]
        public void StringsBehaveLikeValueTypes()
            {
                string name = "Sean";
                string upper = MakeUpperCase(name);

                Assert.Equal("Sean", name);
                Assert.Equal("SEAN", upper);
            }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookRetrurnsDifferentObjects()
        {
            // Arragnge: test data
        
            // Act
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceTheSameObject()
        {
            // Arragnge: test data
        
            // Act
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}