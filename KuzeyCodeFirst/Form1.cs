using KuzeyCodeFirst.Data;
using KuzeyCodeFirst.Models;
using KuzeyCodeFirst.Repository.Abstracts;

namespace KuzeyCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private KuzeyContext _dbContext = new KuzeyContext();
        private KategoriRepo _kategoriRepo = new KategoriRepo();
        private SiparisRepo _siparisRepo = new SiparisRepo();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //_dbContext.Kategoriler.Add(entity: new Kategori
            //{
            //    Ad="Kategori",
            //    Aciklama="A��klama"
            //});
            //_dbContext.SaveChanges();
            var kategori = new Kategori
            {
                Ad = "Kategori",
                Aciklama="a��klama"

            };
            _kategoriRepo.Add(kategori);
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var kategori = _dbContext.Kategoriler.First();
            kategori.Aciklama = "G�ncel A��klama";
            _dbContext.SaveChanges();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var kategori = _dbContext.Kategoriler.First();
            _dbContext.Kategoriler.Remove(kategori);
            _dbContext.SaveChanges();
        }
    }
}