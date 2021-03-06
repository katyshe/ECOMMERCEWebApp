﻿using ECOMMERCEWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCEWebApp.Models
{
    //this class will help us support Pagging feature 
    public class PagingHelper<T> : List<T>
    {
        public int PageNumber { get; private set; }

        //this field  help us define if there is another page that we have to show 
        public int TotalPages { get; private set; }

        public PagingHelper(List<T> items, int pageNumber, int pageSize, int itemsCount)
        {
            PageNumber = pageNumber;
            TotalPages = (itemsCount / pageSize);
            this.AddRange(items);
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public static PagingHelper<T> CreatPagedLsit(IList<T>items, int pageNumber, int pageSize)
        {
            var itemCount = items.Count();
            var pageditems = items.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return new PagingHelper<T>(pageditems, pageNumber, pageSize, itemCount);
        }


        
    }
}
