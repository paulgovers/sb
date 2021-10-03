﻿using System;
using System.Collections.Generic;

namespace SB.TelephoneNotes.BLL.Interfaces.Models
{
    public class PagedList<T> 
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Data { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = items;
        }
        public static PagedList<T> ToPagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
