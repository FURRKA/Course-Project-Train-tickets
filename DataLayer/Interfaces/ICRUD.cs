namespace DataLayer.Interfaces
{
    internal interface ICRUD<T> where T: IEntity
    {
        public void Create(T item);
        public void Read();
        public void Update(int id);
        public void Delete(int id);
    }
}
