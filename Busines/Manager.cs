﻿using DataAcces.EntityFramework;
using Entities;
using Entities.Messasages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Busines
{
    public class Manager
    {
        Repository<User> repo_User = new Repository<User>();
        Repository<Firma> repo_Firma = new Repository<Firma>();
        Repository<Temas> repo_Temas = new Repository<Temas>();
        Repository<Personel> repo_Personel = new Repository<Personel>();
        Repository<Izin> repo_Izin = new Repository<Izin>();

        Repository<FirmaAciklama> repo_FirmaAciklama = new Repository<FirmaAciklama>();


        Repository<FirmaYetkili> repo_FirmaYetkili = new Repository<FirmaYetkili>();
        private Repository<Temaslar> repo_category = new Repository<Temaslar>();
        private Repository<Gorevler> repo_gorev = new Repository<Gorevler>();
        Repository<Personeller> repo_personel = new Repository<Personeller>();
        Repository<Izinler> repo_izin = new Repository<Izinler>();

        public List<Temaslar> GetCategories()
        {
            return repo_category.List();
        }
        public List<Gorevler> _GetGorevler()
        {
            return repo_gorev.List();
        }

        public List<Firma> GetFirmalar()
        {
            return repo_Firma.List();
        }

        public List<Personeller> GetPersoneller()
        {
            return repo_personel.List();
        }

        public List<Izinler> GetIzinler()
        {
            return repo_izin.List();
        }

        public BusinesLayerResult<User> Login(string mail, string sifre)
        {

            BusinesLayerResult<User> layerResult = new BusinesLayerResult<User>();
            layerResult.result = repo_User.Find(x => true); //x => x.Mail == mail && x.Sifre == sifre
                                                            // if (layerResult.result == null)
                                                            //{
                                                            //layerResult.addError(ErrosMesasagesCode.KullaniciBulunamadi, "Kullanıcı Bulunamadı!..");
                                                            // }
            return layerResult;
        }
        public int firmaEkle(Firma data)
        {
            BusinesLayerResult<Firma> layerResult = new BusinesLayerResult<Firma>();
            layerResult.result = repo_Firma.Find(x => x.FirmaAdi == data.FirmaAdi);
            if (layerResult.result == null)
            {
                return repo_Firma.Insert(data);
            }
            else
            {
                return -1;
            }

        }

        public int personelEkle(Personel data)
        {
           
            
                return repo_Personel.Insert(data);
            
           

        }

        public int izinOlustur(Izin data)
        {


            return repo_Izin.Insert(data);



        }



        public int temasEkle(Temaslar data)
        {
            /*BusinesLayerResult<Temas> layerResult = new BusinesLayerResult<Temas>();
            layerResult.result = repo_Temas.Find(x => x.SiparisNumara == data.SiparisNumara);
            if (layerResult.result == null)
            {
                
            }
            else
            {
                return -1;
            }*/
            return repo_category.Insert(data);

        }

        public int gorevEkle(Gorevler data)
        {
            /*BusinesLayerResult<Temas> layerResult = new BusinesLayerResult<Temas>();
            layerResult.result = repo_Temas.Find(x => x.SiparisNumara == data.SiparisNumara);
            if (layerResult.result == null)
            {
                
            }
            else
            {
                return -1;
            }*/
            return repo_gorev.Insert(data);

        }
        public int firmaAciklamaEkle(Firma firma, FirmaAciklama data, FirmaYetkili yetkili)
        {
            BusinesLayerResult<FirmaYetkili> layerResult = new BusinesLayerResult<FirmaYetkili>();
            layerResult.result = repo_FirmaYetkili.Find(x => x.Adi == yetkili.Adi);
            BusinesLayerResult<Firma> layerResult2 = new BusinesLayerResult<Firma>();
            layerResult2.result = repo_Firma.Find(x => x.FirmaAdi == firma.FirmaAdi);
            if (layerResult.result != null && layerResult2.result != null)
            {
                data.Yetkili = layerResult.result.ID;
                data.firmaID = layerResult2.result.ID;
                return repo_FirmaAciklama.Insert(data);
            }
            else
            {
                return -1;
            }

        }
        public int firmaYetkiliEkle(Firma firma, FirmaYetkili data)
        {
            BusinesLayerResult<Firma> layerResult2 = new BusinesLayerResult<Firma>();
            layerResult2.result = repo_Firma.Find(x => x.FirmaAdi == firma.FirmaAdi);
            if (layerResult2.result != null)
            {
                data.firmaID = layerResult2.result.ID;
                return repo_FirmaYetkili.Insert(data);
            }
            else
            {
                return -1;
            }

        }

        public List<Temas> TemasList()
        {
            return repo_Temas.List();
        }
        public List<Firma> FirmaList()
        {
            return repo_Firma.List();
        }

        public List<Personel> PersonelList()
        {
            return repo_Personel.List();
        }
        public List<FirmaAciklama> firmaAciklamaList(Int64 firmaID)
        {
            return repo_FirmaAciklama.List(x => x.firmaID == firmaID);
        }
        public List<FirmaYetkili> firmaYetkiliList(Int64 firmaID)
        {
            return repo_FirmaYetkili.List(x => x.firmaID == firmaID);
        }
        public bool firmaKontrol(Int64 firmaID) 
        {
            BusinesLayerResult<Firma> layerResult = new BusinesLayerResult<Firma>();
            layerResult.result = repo_Firma.Find(x => x.ID == firmaID);
            if (layerResult.result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool temasKontrol(string siparisNumarasi)
        {
            BusinesLayerResult<Temas> layerResult = new BusinesLayerResult<Temas>();
            layerResult.result = repo_Temas.Find(x => x.SiparisNumara == siparisNumarasi);
            if (layerResult.result != null)
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