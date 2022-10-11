namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            // var result = book.ShowStats();

            // with variable "result" it will allow to capture whatever ShowStats() returns.
            // we redesigned ShowStats() because it does to many things.
            // ShowStats() - computes Average, High, Low and Console Writes all 3 of them.
            // We will separate the calculations from displaying;

            var result = book.GetStats();
            // This method will only compute the statistics.

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}