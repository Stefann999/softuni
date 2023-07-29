namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTextBookToLibrary_CheckAdding()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new("asd", "dsa", "eee");

            library.AddTextBookToLibrary(textBook);

            int expectedCount = 1;
            int actualCount = library.Catalogue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void InventoryNumberIsCorrect()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new("asd1", "dsa", "eee");
            TextBook textBook2 = new("asd12", "dsa", "eee");
            TextBook textBook3 = new("asd123", "dsa", "eee");

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook2);
            library.AddTextBookToLibrary(textBook3);

            Assert.AreEqual(3, textBook3.InventoryNumber);
        }

        [Test]
        public void AddTextBookToLibrary_AddsProperly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new("asd", "dsa", "eee");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: asd - 1");
            sb.AppendLine($"Category: eee");
            sb.AppendLine($"Author: dsa");

            string expectedOutput = sb.ToString().TrimEnd();
            string actualOutput = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void LoanTextBook_LoansProperly()
        {
            TextBook textBook = new("asd", "dsa", "eee");
            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            var expectedOutput = ("asd loaned to Georgi.");
            var acutalOutput = library.LoanTextBook(1, "Georgi");

            Assert.AreEqual(expectedOutput, acutalOutput);
            Assert.AreEqual("Georgi", textBook.Holder);
        }

        [Test]
        public void LoanTextBook_HasntReturned()
        {
            TextBook textBook = new("asd", "dsa", "eee");
            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "Georgi");

            var acutalOutput = library.LoanTextBook(1, "Georgi");
            var expectedOutput = "Georgi still hasn't returned asd!";

            Assert.AreEqual(expectedOutput, acutalOutput);
        }

        [Test]
        public void ReturnTextBookWorksProperly()
        {
            TextBook textBook = new("asd", "dsa", "eee");
            UniversityLibrary library = new UniversityLibrary();
            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "Georgi");

            var expectedOutput = "asd is returned to the library.";
            var actualOutput = library.ReturnTextBook(1);

            Assert.AreEqual(expectedOutput, actualOutput);
            Assert.AreEqual(string.Empty, textBook.Holder);
        }
    }
}