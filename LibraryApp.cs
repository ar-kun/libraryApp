using System;
using System.Collections.Generic;

public class Book
{
  public string Title { get; set; }
  public string Author { get; set; }
  public int PublicationYear { get; set; }

  public Book(string title, string author, int publicationYear)
  {
    Title = title;
    Author = author;
    PublicationYear = publicationYear;
  }
}

public class LibraryCatalog
{
  private List<Book> books = new List<Book>();

  public void AddBook(Book book)
  {
    books.Add(book);
  }

  public void RemoveBook(Book book)
  {
    books.Remove(book);
  }

  public Book FindBook(string title)
  {
    return books.Find(book => book.Title == title);
  }

  public void ListBooks()
  {
    Console.WriteLine("____________________________");
    Console.WriteLine("Daftar Buku dalam Katalog Perpustakaan:");
    foreach (Book book in books)
    {
      Console.WriteLine($"- Judul buku {book.Title} ditulis oleh {book.Author}, terbit pada tahun: {book.PublicationYear}");
    }
    Console.WriteLine("____________________________");
  }
}

public class LibraryApp
{
  private LibraryCatalog catalog = new LibraryCatalog();

  private void AddBook()
  {
    try
    {
      Console.WriteLine("____________________________");
      Console.Write("Judul Buku: ");
      string title = Console.ReadLine();
      Console.Write("Penulis: ");
      string author = Console.ReadLine();
      Console.Write("Tahun Terbit: ");
      int publicationYear = int.Parse(Console.ReadLine());

      Book newBook = new Book(title, author, publicationYear);
      catalog.AddBook(newBook);
      Console.WriteLine("Buku berhasil ditambahkan ke katalog.");
      Console.WriteLine("____________________________");
    }
    catch (Exception e)
    {
      Console.WriteLine($"Terjadi kesalahan: {e.Message}");
    }
  }

  private void RemoveBook()
  {
    try
    {
      Console.Write("Judul Buku yang akan dihapus: ");
      string title = Console.ReadLine();
      Book bookToRemove = catalog.FindBook(title);

      if (bookToRemove != null)
      {
        Console.WriteLine("____________________________");
        catalog.RemoveBook(bookToRemove);
        Console.WriteLine("Buku berhasil dihapus dari katalog.");
        Console.WriteLine("____________________________");
      }
      else
      {
        Console.WriteLine("____________________________");
        Console.WriteLine("Buku tidak ditemukan dalam katalog.");
        Console.WriteLine("____________________________");
      }
    }
    catch (Exception e)
    {
      Console.WriteLine($"Terjadi kesalahan: {e.Message}");
    }
  }

  private void FindBook()
  {
    Console.Write("Cari Buku (Judul): ");
    string title = Console.ReadLine();
    Book foundBook = catalog.FindBook(title);

    if (foundBook != null)
    {
      Console.WriteLine("____________________________");
      Console.WriteLine($"Buku ditemukan:");
      Console.WriteLine($"Judul: {foundBook.Title}, Penulis: {foundBook.Author}, Tahun Terbit: {foundBook.PublicationYear}");
      Console.WriteLine("____________________________");
    }
    else
    {
      Console.WriteLine("____________________________");
      Console.WriteLine("Buku tidak ditemukan dalam katalog.");
      Console.WriteLine("____________________________");
    }
  }

  static void Main()
  {
    LibraryApp libraryApp = new LibraryApp();
    bool isRunning = true;
    while (isRunning)
    {
      Console.WriteLine("Menu Perpustakaan:");
      Console.WriteLine("1. Tambahkan Buku");
      Console.WriteLine("2. Hapus Buku");
      Console.WriteLine("3. Cari Buku");
      Console.WriteLine("4. Tampilkan Semua Buku");
      Console.WriteLine("5. Keluar");
      Console.Write("Enter your choice:  ");

      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          libraryApp.AddBook();
          break;
        case "2":
          libraryApp.RemoveBook();
          break;
        case "3":
          libraryApp.FindBook();
          break;
        case "4":
          libraryApp.catalog.ListBooks();
          break;
        case "5":
          isRunning = false;
          Console.WriteLine("Terima kasih Telah Berkunjung ~ Sampai Jumpa Lagi!");
          break;
        default:
          Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
          break;
      }
    }
  }
}
