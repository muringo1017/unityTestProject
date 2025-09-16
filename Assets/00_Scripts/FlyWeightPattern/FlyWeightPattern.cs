using System;
using System.Collections.Generic;
using UnityEngine;


public class Book
{
public string BookName;
public string BookDescription;
}
public class FlyWeightPattern : MonoBehaviour
{
    private Dictionary<string, Book> bookFactory = new Dictionary<string, Book>();

    private void Start()
    {
        GetBook("인프런강의", "배웠다");
        GetBook("인프런강의", "배웠다");
        GetBook("인프런강의", "배웠다");
        GetBook("인프런강의", "배웠다");
        GetBook("인프1런강의", "배웠1다");
    }

    Book GetBook(string name, string description)
    {
        if (bookFactory.ContainsKey(name) == false)
        {
            bookFactory.Add(name, new Book {BookName = name, BookDescription = description});
            Debug.Log("add new book");
        }

        else
        {
            Debug.Log("기존 정보 호출");
        }

        return bookFactory[name];
    }
}

