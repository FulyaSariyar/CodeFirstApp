using KuzeyCodeFirst.Models;

namespace KuzeyCodeFirst.Repository.Abstracts
{
    public class UrunRepo:RepositoryBase<Urun , int> {
        public override void Update(Urun entity, bool isSaveLater = false)
        {
            var entry = _context.Entry(entity);
            var eskiFiyat = (decimal)entry.OriginalValues["Fiyat"];
            //urun fiyat gecmisi tablosuna eklenir/loglanir
            base.Update(entity, isSaveLater);
        }
    }
    
}
