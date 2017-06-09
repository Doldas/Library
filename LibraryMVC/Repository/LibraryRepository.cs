using LibraryMVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC.Models;

namespace LibraryMVC.Repository
{
    public class LibraryRepository<T> : ICollection<LibraryRepository<T>>
                                               where T : Book
    {
        LibraryContext db;

        public LibraryRepository()
        {
            db = new LibraryContext();
        }
        public ICollection<Book>GetAllBooks()
        {
            return db.Books.ToList();
        }

        void ICollection<LibraryRepository<T>>.Add(LibraryRepository<T> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<LibraryRepository<T>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<LibraryRepository<T>>.Contains(LibraryRepository<T> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<LibraryRepository<T>>.CopyTo(LibraryRepository<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<LibraryRepository<T>>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<LibraryRepository<T>>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<LibraryRepository<T>>.Remove(LibraryRepository<T> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<LibraryRepository<T>> IEnumerable<LibraryRepository<T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}