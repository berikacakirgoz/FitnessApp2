// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

//MusteriTest();

static void MusteriTest()
{
    MusteriManager musteriManager = new MusteriManager(new EfMusteriDal());
    foreach (var musteri in musteriManager.GetAll())
    {
        Console.WriteLine(musteri.Soyad);
    }
}
EgitmenManager egitmenManager = new EgitmenManager(new EfEgitmenDal());
foreach (var egitmen in egitmenManager.GetAll())
{
    Console.WriteLine(egitmen.Ad);
}

