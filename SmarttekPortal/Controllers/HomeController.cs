using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busines;
using Entities;

namespace SmarttekPortal.Controllers
{
    public class HomeController : Controller
    {

        //Temaslar tms = new Temaslar();

        public ActionResult Temaslar()
        {
            if (giris())
            {
                return View();
            }
            return null;

        }
        public ActionResult Gorevler()
        {
            if (giris())
            {
                return View();
            }
            return null;
        }
        public ActionResult Personeller()
        {
            if (giris())
            {
                return View();
            }
            return null;
        }

        public ActionResult Izinler()
        {
            if (giris())
            {
                return View();
            }
            return null;
        }

        public ActionResult Urunler()
        {
            if (giris())
            {
                return View();
            }
            return null;
        }


        /* public string Temaslar()
         {
             return "Temaslar";
         }*/
        private User user = new User();
        public ActionResult Index(string firmaID)
        {
            if (giris())
            {
                if (firmaID != null)
                {
                    AciklamaDurum();
                    //ViewBag.YetkiliCombo
                    Manager mng = new Manager();
                    if (mng.firmaKontrol(Int64.Parse(firmaID)))
                    {
                        ViewBag.FirmaList = mng.FirmaList();
                        TempData["FirmaID"] = firmaID;
                        TempData["aciklama"] = mng.firmaAciklamaList(Int64.Parse(firmaID));
                        TempData["yetkili"] = mng.firmaYetkiliList(Int64.Parse(firmaID));
                        List<SelectListItem> items = new List<SelectListItem>();
                        foreach (FirmaYetkili data in mng.firmaYetkiliList(Int64.Parse(firmaID)))
                        {
                            items.Add(new SelectListItem { Text = data.Adi + " " + data.Soyadi, Value = data.ID.ToString() });

                        }
                        ViewBag.YetkiliCombo = items;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["FirmaID"] = "0";
                    //ViewBag.FirmaList
                    Manager mng = new Manager();
                    ViewBag.FirmaList = mng.FirmaList();
                    AciklamaDurum();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }

        }

        public ActionResult IndexTemaslar(string temasID)
        {
            if (giris())
            {
                if (temasID != null)
                {
                    
                    //ViewBag.YetkiliCombo
                    Manager mng = new Manager();
                    if (mng.temasKontrol(temasID))
                    {
                        ViewBag.TemasList = mng.TemasList();
                        TempData["TemasID"] = temasID;
                        
                        List<SelectListItem> items = new List<SelectListItem>();
                        
                        ViewBag.YetkiliCombo = items;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["TemasID"] = "0";
                    //ViewBag.FirmaList
                    Manager mng = new Manager();
                    ViewBag.TemasList = mng.TemasList();
                    
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }

        }


       









        [HttpPost]
        public ActionResult Index(Firma firma, FirmaAciklama firmaAciklama, FirmaYetkili firmaYetkili)
        {
            string hataMesaj = "";
            if (giris())
            {
                firma.KayitAcan = user.Adi + " " + user.Soyadi;
                firma.FirmaSehir = "varsayılan";
                firma.KayitTarih = DateTime.Now;
                firmaAciklama.KayitAcan = firma.KayitAcan;
                firmaAciklama.KayitTarih = DateTime.Now;
                Manager mng = new Manager();
                if (firma != null && firmaAciklama != null && firmaYetkili != null)
                {
                    AciklamaDurum();
                    int ekle = mng.firmaEkle(firma);
                    if (ekle > 0)
                    {
                        if (mng.firmaYetkiliEkle(firma,firmaYetkili) > 0)
                        {
                            if (mng.firmaAciklamaEkle(firma,firmaAciklama, firmaYetkili) > 0)
                            {
                                //hepsi eklendi mesaj
                                ViewBag.add = "Firma Eklendi.";
                            }
                            else
                            {
                                //yetkili eklenmedi
                                hataMesaj += "Firma Acıklama Eklenmedi <br>";
                            }
                        }
                        else
                        {
                            //firma Acıklama eklenmedi
                            hataMesaj += "Firma Yetkili Eklenmedi <br>";
                        }
                    }
                    else if (ekle == -1)
                    {
                        //firma Eklenmedi
                        hataMesaj += "Firma Zaten Kayıtlı <br>";
                    }
                    else
                    {
                        hataMesaj += "Firma Eklenmedi <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }

        public ActionResult FirmaDetay(Int64 firmaID)
        {
            if (giris())
            {

            }
            else
            {
                return RedirectToAction("Index", "Giris");

            }
            return View();

        }


        [HttpPost]
        public ActionResult IndexTemas(Temaslar t)
        {
            string hataMesaj = "";
            if (giris())
            {
                t.temas_olusturan = user.Adi + " " + user.Soyadi;
                //t.AcmaNedeni ="acmanedeni";
                t.temas_tarih = "ben de bilmiyom ki";
                
                Manager mng = new Manager();
                if (t != null)
                {
                    AciklamaDurum();
                    int ekle = mng.temasEkle(t);
                    if (ekle > 0)
                    {
                      
                    }
                    else
                    {
                        hataMesaj += "Temas Eklenmedi <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return RedirectToAction("Temaslar");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }





        [HttpPost]
        public ActionResult IndexGorev(Gorevler g)
        {
            string hataMesaj = "";
            if (giris())
            {
               
                //t.AcmaNedeni ="acmanedeni";
               // g.temas_tarih = "ben de bilmiyom ki";

                Manager mng = new Manager();
                if (g != null)
                {
                    
                    int ekle = mng.gorevEkle(g);
                    if (ekle > 0)
                    {

                    }
                    else
                    {
                        hataMesaj += "Gorev Eklenmedi <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return RedirectToAction("Gorevler");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }


        [HttpPost]
        public ActionResult IndexPersonel(Personel p)
        {
            string hataMesaj = "";
            if (giris())
            {


                Manager mng = new Manager();
                if (p != null)
                {
                    
                    int ekle = mng.personelEkle(p);
                    if (ekle > 0)
                    {

                    }
                    else
                    {
                        hataMesaj += "Personel Eklenmedi <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return RedirectToAction("Personeller");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }



        [HttpPost]
        public ActionResult IndexIzin(Izin i)
        {
            string hataMesaj = "";
            if (giris())
            {


                Manager mng = new Manager();
                if (i != null)
                {
                   
                    int ekle = mng.izinOlustur(i);
                    if (ekle > 0)
                    {

                    }
                    else
                    {
                        hataMesaj += "İzin oluşturma başarısız <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return RedirectToAction("Izinler");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }


        [HttpPost]
        public ActionResult IndexUrun(Urun i)
        {
            string hataMesaj = "";
            if (giris())
            {


                Manager mng = new Manager();
                if (i != null)
                {
                   
                    int ekle = mng.urunEkle(i);
                    if (ekle > 0)
                    {

                    }
                    else
                    {
                        hataMesaj += "Urun ekleme başarısız <br>";
                    }
                }
                ViewBag.addError = hataMesaj;
                return RedirectToAction("Urunler");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
        }







        public void AciklamaDurum()
        {
            //if (Int64.Parse(TempData["FirmaID"].ToString()) != 0)
            //{
            //    Maneger mng = new Maneger();
            //    List<SelectListItem> items2 = new List<SelectListItem>();
            //    foreach (FirmaYetkili data in mng.firmaYetkiliList(Int64.Parse(TempData["FirmaID"].ToString())))
            //    {
            //        items2.Add(new SelectListItem { Text = data.Adi + " " + data.Soyadi, Value = data.ID.ToString() });

            //    }
            //    ViewBag.YetkiliCombo = items2;
            //}
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Arandı", Value = "Arandı" });
            items.Add(new SelectListItem { Text = "Mail gönderildi", Value = "Mail gönderildi" });
            items.Add(new SelectListItem { Text = "Toplantı ayarlandı", Value = "Toplantı ayarlandı" });
            items.Add(new SelectListItem { Text = "Ziyaret edildi", Value = "Ziyaret edildi" });
            items.Add(new SelectListItem { Text = "Demo yapılacak", Value = "Demo yapılacak" });
            items.Add(new SelectListItem { Text = "Teklif", Value = "Teklif" });
            items.Add(new SelectListItem { Text = "Onay beklemede", Value = "Onay beklemede" });
            items.Add(new SelectListItem { Text = "Satış olumlu", Value = "Satış olumlu" });
            items.Add(new SelectListItem { Text = "Satış olumsuz", Value = "Satış olumsuz" });
            ViewBag.AciklamaDurum = items;
        }
        public bool giris()
        {
            user = Session["Login"] as User;
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}