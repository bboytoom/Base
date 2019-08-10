using System.Collections.Generic;

namespace Administrator.Query.Interface
{
    public interface IOperations<T, W>
    {
        bool Create(T data, int hieghUser, int main);
        bool Update(T data, int hieghUser);
        bool Delete(int id, int hieghUser);
        T Read(int id);
        IEnumerable<W> ReadAll(int id_main);
    }
}
