using Administrator.Contract;
using System.Linq;

namespace Administrator.Query.Interface
{
    public interface IOperations<T>
    {
        bool Create(ViewModelUser data, int hieghUser, int main);
        bool Update(ViewModelUser data, int hieghUser);
        bool Delete(int id, int hieghUser);
        T Read(int id);
        IQueryable<T> ReadAll(int id_main);
    }
}
