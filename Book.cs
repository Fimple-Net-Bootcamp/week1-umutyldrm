
using System.Runtime.CompilerServices;

namespace LibraryProject{
    abstract public class Book: IPrint
    {
        private static int _nextBookId = 1;
        private string _bookName;
        private string _authorName;
        private int _bookID;
        private int _maxBorrowDay;
        private bool _isAvailable = true;
        internal string bookName{
            get{return _bookName;}
        }
        internal string authorName{
            get{return _authorName;}
        }
        internal int bookID{
            get{return _bookID;}
        }
        internal int maxBorrowDay{
            get{return _maxBorrowDay;}
            set{_maxBorrowDay = value;}
        }
        internal bool isAvailable{
            get{return _isAvailable;}
            set{_isAvailable = value;}
        }
        public Book(string bookName , string authorName, int maxBorrowDay){
            this._bookName = bookName;
            this._authorName = authorName;
            this._bookID = _nextBookId;
            this._isAvailable = true;
            this.maxBorrowDay = maxBorrowDay;
            _nextBookId += 1;
        }
        public void setAvailable(){
            this.isAvailable = true;
        }
        public void setUnavailable(){
            this.isAvailable = false;
        }

        virtual public void PrintDetails()
        {
            Console.WriteLine("Base class implementation for logging details");
        }
    }
}
