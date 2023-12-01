namespace LibraryProject{
    
    class Member: IPrint{
        private static int _nextMemberId = 1;
        private string _name;
        private string _lastName;
        private int _memberID;
        private Dictionary<int,Book> booksBorrowed;
        internal string name{
            get{return _name;}
            set{_name = value;}
        }
        internal string lastName{
            get{return _lastName;}
            set{_lastName = value;}
        }
        internal int memberID{
            get{return _memberID;}
            set{_memberID = value;}
        }
        public void borrowNewBook(Book bookToBeAdded){
            this.booksBorrowed.Add(bookToBeAdded.bookID,bookToBeAdded);
        }
        public void returnBook(Book bookToBeReturned){
            this.booksBorrowed.Remove(bookToBeReturned.bookID);
        }
        public bool isBookBorrowed(int bookID){
            return this.booksBorrowed.ContainsKey(bookID);
        }
        public bool isBookBorrowed(Book bookToCheck){
            return this.booksBorrowed.ContainsKey(bookToCheck.bookID);
        }
        public Member(string name, string lastName){
            this._name = name;
            this._lastName = lastName;
            this._memberID = _nextMemberId;
            this.booksBorrowed = new Dictionary<int, Book>();
            _nextMemberId++;
        }
        public int numberOfBooksBorrowed(){
            return this.booksBorrowed.Count();
        }
        public void PrintDetails()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Member Details");
            Console.WriteLine("Member full name: {0} {1}",this.name,this.lastName);
            Console.WriteLine("Member ID: {0}", this.memberID);
            Console.WriteLine("Currently borrowed books");
            Console.WriteLine("--------------------------------------------------------");
            foreach(var userBook in this.booksBorrowed){
                userBook.Value.PrintDetails();
            }
            Console.WriteLine("--------------------------------------------------------");
        }
    }   
}
