namespace To_Do_List.Models
{
    public interface IListRepository
    {
        public bool CreateList(List list);
        public IEnumerable<List> GetAllList(int id);

    }
}
