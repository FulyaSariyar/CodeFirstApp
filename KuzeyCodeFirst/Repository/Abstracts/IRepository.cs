using KuzeyCodeFirst.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Repository.Abstracts
{
    internal interface IRepository<T,in TId> where T :BaseEntity // in TId,in sayesinde degistiremezsin ama kullanabilirsin.
    {
        T GetById(TId id);
        IQueryable<T> Get(Func<T,bool> predicate=null);



        void Add(T entity,bool isSaveLater=false); //SaveChange metodunu her kayit ekledigimde calistirmamak icin isSaveLater ekledim.
        void Remove(T entity, bool isSaveLater = false);
        void Update(T entity, bool isSaveLater = false);
        int Save();



    }
}
