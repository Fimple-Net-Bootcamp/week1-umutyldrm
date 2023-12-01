namespace LibraryProject;
class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        Library patikaLibrary = new Library();
        Console.WriteLine("Welcom to the Patika Library!");
        while(!exit){
            Console.WriteLine("Please enter your command.");
            Console.WriteLine("1. Get details of all books");
            Console.WriteLine("2. Get details of all members");
            Console.WriteLine("3. Lend a book to a member");
            Console.WriteLine("4. Accept a returned book by a member");
            Console.WriteLine("5. Add a new book to library");
            Console.WriteLine("6. Register new user");
            Console.WriteLine("7. Delete a book");
            Console.WriteLine("8. Delete a member");
            Console.WriteLine("9. Exit");
            var userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "1":
                    {
                        patikaLibrary.printBooks();
                    }
                    break;
                case "2":
                        {
                        patikaLibrary.printMembers();
                        
                        }
                    break;
                case "3":
                    {
                        Console.WriteLine("Please enter member id: ");
                        var sMemberID = Console.ReadLine();
                        int memberID = 0;
                        Console.WriteLine("Please enter book id: ");
                        var sBookID = Console.ReadLine();
                        int bookID = 0;
                        if(Int32.TryParse(sMemberID, out memberID) && Int32.TryParse(sBookID, out bookID)){
                            patikaLibrary.lendBook(memberID,bookID);
                        }
                        else{
                            Console.WriteLine("Please check your input");
                        }
                    }
                    break;
                case "4":
                    {
                        Console.WriteLine("Please enter member id: ");
                        var sMemberID = Console.ReadLine();
                        int memberID = 0;
                        Console.WriteLine("Please enter book id: ");
                        var sBookID = Console.ReadLine();
                        int bookID = 0;
                        if(Int32.TryParse(sMemberID, out memberID) && Int32.TryParse(sBookID, out bookID)){
                            patikaLibrary.receiveBookFromUser(memberID,bookID);
                        }
                        else{
                            Console.WriteLine("Please check your input");
                        }
                    }
                    break;
                case "5":
                    {
                        addNewItemToLibrary(patikaLibrary);
                    }
                    break;
                case "6":
                    {
                        addNewMemberToLibrary(patikaLibrary);
                    }
                    break;
                case "7":
                    {
                        Console.WriteLine("Enter ID of book you wish to delete");
                        var sDeletedBookID = Console.ReadLine();
                        if(Int32.TryParse(sDeletedBookID, out int intDeletedBookID)){
                            patikaLibrary.removeBook(intDeletedBookID);
                        }
                        else{
                            Console.WriteLine("Please enter a valid integer number");
                        }
                    }
                    break;
                case "8":
                    {
                        Console.WriteLine("Enter ID of member you wish to delete");
                        var sMemberIDToRemove = Console.ReadLine();
                        if(Int32.TryParse(sMemberIDToRemove, out int intRemovedMemberID)){
                            patikaLibrary.cancelMembership(intRemovedMemberID);
                        }
                    }
                    break;
                case "9":
                    {
                        Console.WriteLine("Exiting the program");
                        exit = true;
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
        }
        
    }

    static public void addNewItemToLibrary(Library library){
        Console.WriteLine("Please enter type of material you wish to add to library");
        Console.WriteLine("1. Novel");
        var itemType = Console.ReadLine();
        switch(itemType){
            case("1"):
                {
                    Console.WriteLine("Please enter novel name: ");
                    var novelName = Console.ReadLine();
                    Console.WriteLine("Please enter author name: ");
                    var authorName = Console.ReadLine();
                    Console.WriteLine("Please enter novel genre: ");
                    var novelGenre = Console.ReadLine();
                    Novel newNovel = new Novel(novelName, authorName, novelGenre);
                    library.addNewBook(newNovel);
                }
                break;
            default:
                Console.WriteLine("Please enter a valid input for type");
                break;
        }
    }
    static public void addNewMemberToLibrary(Library library){
        Console.Write("Please enter member name: ");
        var memberName = Console.ReadLine();
        Console.Write("Please enter member lastname: ");
        var memberLastName = Console.ReadLine();
        Member newMember = new Member(memberName, memberLastName);
        library.registerNewMember(newMember);
    }
}
