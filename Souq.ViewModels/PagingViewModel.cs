using System;

namespace Souq.ViewModels
{
    public class PagingViewModel<T>
    {
        public int totalItems { get; set; }
        public int TotalPages { get; set; }
        public T items { get; set; }
        public int CurrentPage { get; set; }

    }
}
