using KuzeyCodeFirst.Models;

namespace KuzeyCodeFirst.Repository.Abstracts
{
    public class SiparisRepo:RepositoryBase<Siparis , int> 
    {
        public void SiparisOlustur()
        {
            //transaction ile yapilacak
        }
        public void SiparisRaporu(DateTime baslangic, DateTime bitis)
        {

        }
    }
}
