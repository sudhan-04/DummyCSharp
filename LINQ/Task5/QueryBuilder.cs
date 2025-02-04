using Task5.Model;
using Task5.Repository;

namespace Task5
{
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _tRepository;

        public QueryBuilder(IEnumerable<T> TRepository)
        {
            this._tRepository = TRepository;
        }
        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _tRepository.Where(predicate).AsQueryable();
        }

        public IEnumerable<T> SortBy<TKey>(Func<T, TKey> predicate)
        {
            return _tRepository.OrderBy(predicate).;
        }

        public IEnumerable<T> Execute()
        {
            return _tRepository;
        }
    }
}