using InitProject.Model.Models;


namespace InitProject.Model.Entities;

public class PageItems
{
    public static PagedResponse<T> GetPagedItems<T>(List<T> items, PageDefaultValue pageDefault)
    {        
        pageDefault ??= new()
            {
                PageNumber = 10,
                PageSize = 2,
                TotalItems = items.Count
            };
        
        pageDefault.TotalPages = (int)Math.Ceiling((double)pageDefault.TotalItems / pageDefault.PageSize);

        
        //Logica para Pegar a ultima pagina como pageSize
        if (pageDefault.TotalPages != 0 && pageDefault.PageNumber > pageDefault.TotalPages)
            pageDefault.PageNumber = pageDefault.TotalPages - 1;



        //Logica para numeros impares
        if (pageDefault.TotalItems % pageDefault.PageSize != 0 && 
                pageDefault.PageNumber == (pageDefault.TotalItems / pageDefault.PageSize) + 1)
        {
            pageDefault.PageSize = pageDefault.TotalItems % pageDefault.PageSize;
        }

        List<T> itemsList = items.Skip((pageDefault.PageNumber - 1) * pageDefault.PageSize)
                                         .Take(pageDefault.PageSize).ToList();

        PagedResponse<T> response = new()
        {
            PageData = pageDefault,
            Items = itemsList
        };

        return response;
    }
}

public class PagedResponse<T>
{
    public PageDefaultValue PageData { get; set; }
    public List<T> Items { get; set; }
}

public class PageDefaultValue
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}


