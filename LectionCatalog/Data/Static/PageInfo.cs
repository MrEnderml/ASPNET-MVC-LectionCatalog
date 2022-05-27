namespace LectionCatalog.Data.Static
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return TotalItems == 0? 1 : (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
