using KuzeyCodeFirst.Data;
using KuzeyCodeFirst.Models;

namespace KuzeyCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private KuzeyContext _dbContext = new KuzeyContext();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            _dbContext.Kategoriler.Add(entity: new Kategori
            {
                Ad="Kategori",
                Aciklama="Açýklama"
            });
            _dbContext.SaveChanges();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var kategori = _dbContext.Kategoriler.First();
            kategori.Aciklama = "Güncel Açýklama";
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