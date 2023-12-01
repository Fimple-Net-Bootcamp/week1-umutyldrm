namespace LibraryProject{
    class Library{
        protected Dictionary<int,Book> bookInventory;
        protected Dictionary<int,Member> membersOfLibrary;
        public Library(){
            this.bookInventory = new Dictionary<int, Book>();
            this.membersOfLibrary = new Dictionary<int, Member>();
        }
        public void registerNewMember(Member newMember){
            this.membersOfLibrary.Add(newMember.memberID,newMember);
        }
        public void cancelMembership(Member memberToBeRemoved){
            if(memberToBeRemoved.numberOfBooksBorrowed() == 0)
                this.membersOfLibrary.Remove(memberToBeRemoved.memberID);
        }
        public void cancelMembership(int memberToBeRemovedID){
            Member memberToBeRemoved = this.membersOfLibrary[memberToBeRemovedID];
            if(memberToBeRemoved.numberOfBooksBorrowed() == 0)
                this.membersOfLibrary.Remove(memberToBeRemoved.memberID);
        }
        public void addNewBook(Book newBook){
            this.bookInventory.Add(newBook.bookID,newBook);
        }
        public void removeBook(Book removedBook){
            if(this.bookInventory[removedBook.bookID].isAvailable)
                this.bookInventory.Remove(removedBook.bookID);
        }
        public void removeBook(int bookID){
            if(this.bookInventory[bookID].isAvailable)
                this.bookInventory.Remove(bookID);
        }

        private bool doesBookExists(int bookID){
            return this.bookInventory.ContainsKey(bookID);
        }
        private bool doesBookExists(Book bookToCheck){
            return this.bookInventory.ContainsKey(bookToCheck.bookID);
        }
        private bool doesMemberExists(int memberID){
            return this.membersOfLibrary.ContainsKey(memberID);
        }
        private bool doesMemberExists(Member memberToCheck){
            return this.membersOfLibrary.ContainsKey(memberToCheck.memberID);
        }
        private Book getBookFromLibrary(int bookID){
            if(!doesBookExists(bookID))
                throw new KeyNotFoundException("No such book by that ID exists");

            return this.bookInventory[bookID];
        }
        private Member returnMemberFromLibrary(int memberID){
            if(!doesMemberExists(memberID))
                throw new KeyNotFoundException("No such member by that ID exists");

            return this.membersOfLibrary[memberID];
        }
        public void lendBook(int memberID, int bookID){
            if(doesBookExists(bookID) && doesMemberExists(memberID)){
                Book bookToBeLend = getBookFromLibrary(bookID);
                Member memberToLendBook = returnMemberFromLibrary(memberID);

                if(bookToBeLend.isAvailable){
                    memberToLendBook.borrowNewBook(bookToBeLend);
                    bookToBeLend.isAvailable = false;
                }
            }
        }
        public void receiveBookFromUser(int memberID, int bookID){
            if(doesBookExists(bookID) && doesMemberExists(memberID)){
                Book bookToBeLend = getBookFromLibrary(bookID);
                Member memberToReturnBook = returnMemberFromLibrary(memberID);

                if(memberToReturnBook.isBookBorrowed(bookID)){
                    memberToReturnBook.returnBook(bookToBeLend);
                    bookToBeLend.isAvailable = true;
                }
            }
        }
        public void printMembers(){
            foreach(var member in this.membersOfLibrary){
                member.Value.PrintDetails();
            }
        }
        public void printBooks(){
            foreach(var book in this.bookInventory){
                book.Value.PrintDetails();
            }
        }
    }
}