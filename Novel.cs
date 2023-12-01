namespace LibraryProject{

        public class Novel : Book, IPrint
    {
        private string bookGenre;
        public Novel(string bookName , string authorName, string bookGenre): base(bookName, authorName, 30)
        {
            this.bookGenre = bookGenre;
        }
        public override void PrintDetails(){
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Details of novel");
            Console.WriteLine("Book name : " + this.bookName);
            Console.WriteLine("Author name : " + this.authorName);
            Console.WriteLine("bookID : " + this.bookID);
            Console.WriteLine("Borrow duration of book: " + this.maxBorrowDay);
            Console.WriteLine("Book Genre: " + this.bookGenre);
            if(this.isAvailable)
                Console.WriteLine("Book is available");
            else
                Console.WriteLine("Book is currently not available");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}