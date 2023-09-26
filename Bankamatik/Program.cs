using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bakiye = 2500;
            double cekilecektutar = 0;
            double faturatutari = 0;
            string hesnum = "";
            string altmenusecim = "";
            double yatirilacaktutar = 0;
            string sifre = "ab18";
            int deneme = 3;
            ILKGIRIS: //KULLANICININ KARSILASACAGI ILK MENU ILKGIRIS OLARAK TANITILDI. 1 VE 2 HARICINDE BASKA BIR DEGER GIRILDIGINDE SWITCH CASE BURAYA GERI YONLENDIRECEK
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz: ");
            Console.WriteLine("1-Kartlı İşlem");
            Console.WriteLine("2-Kartsız işlem");
            string ilkgirissecim = Console.ReadLine();
            switch (ilkgirissecim)
            {
                case "1": // KARTLI ISLEM SECILDIGINDE NE OLACAGINA DAIR..
                    Console.Clear();
                LOGIN:                         
                    Console.WriteLine("Şifrenizi giriniz");                   // 3 HATALI GIRIS BOYUNCA KULLANICI BURAYA GERI YONELNDIRILIR
                    string password = Console.ReadLine();

                    if (sifre == password)
                    {
                        Console.Clear();
                        Console.WriteLine("Giriş başarılı");
                    ANAMENU:
                        Console.WriteLine("1-Para Çekme");
                        Console.WriteLine("2-Para Yatırma");
                        Console.WriteLine("3-Para Transferleri");           //KARTLI ISLEM SECILDIGINDE GIRILECEK ANA MENU
                        Console.WriteLine("4-Eğitim Ödemeleri");
                        Console.WriteLine("5-Ödemeler");
                        Console.WriteLine("6-Bilgi güncelleme");
                        Console.WriteLine("7-Çıkış yap");
                        string anamenusecim = Console.ReadLine();
                        switch (anamenusecim)
                        {
                            case "1":
                                Console.Clear();
                                CASE1PARACEKME:
                                Console.WriteLine("-----PARA ÇEKME-----");
                                Console.WriteLine("Ana menüye dönmek için 0 değerini giriniz");                      //CASE1 PARA CEKME SECENEGI
                                Console.WriteLine("Lütfen çekmek istediğiniz tutarı giriniz: ");
                                try
                                {
                                    cekilecektutar = Convert.ToDouble(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.Clear() ;
                                    Console.WriteLine("Lütfen sadece numerik bir değer giriniz!");
                                    goto CASE1PARACEKME;
                                }
                                if (cekilecektutar==0)
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }

                                if (cekilecektutar>bakiye)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Çekilecek tutar bakiyeden büyük olamaz!. Güncel bakiyeniz {0}TL",bakiye);
                                    goto CASE1PARACEKME;
                                }
                                else if ((cekilecektutar%10) != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Çekilecek tutar 10 ve 10'un katları olmak zorundadır.");
                                    goto CASE1PARACEKME;
                                }
                                else
                                {
                                    Console.Clear();
                                    bakiye = bakiye - cekilecektutar;
                                    Console.WriteLine("Para çekme işlemi başarıyla gerçekleşmiştir. Güncel bakiyeniz {0}TL",bakiye);
                                    goto ALTMENU;
                                }//CASE1 PARA CEKME
                            case "2":
                                Console.Clear();
                            CASE2PARAYATIRMA:
                                Console.WriteLine("-----PARA YATIRMA-----");
                                Console.WriteLine("");
                                Console.WriteLine("1-Kredi Kartına");          //CASE 2 PARA YATIRMA KARTLI ISLEM
                                Console.WriteLine("2-Kendi Hesabınıza");
                                Console.WriteLine("9-Ana menüye dön");
                                Console.WriteLine("0-Çıkış yap");
                                string case2parayatirmasecim = Console.ReadLine();
                                if (case2parayatirmasecim=="1")
                                {
                                    Console.Clear();
                                    KKNUMGIRME:
                                    Console.WriteLine("Lütfen 12 haneli kredi kartı numaranızı giriniz: ");
                                    string kknum= Console.ReadLine();
                                    if (kknum.Length == 12)
                                    {
                                        PARAYATIRMAKKNUM:
                                        Console.WriteLine("Lütfen yatırılacak tutarı giriniz. Ana menüye dönmek için 0'ı tuşlayınız");
                                        try
                                        {
                                            yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen numerik bir değer giriniz");
                                            goto PARAYATIRMAKKNUM;
                                        }
                                        if (yatirilacaktutar>bakiye)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Yatırılacak tutar bakiyeden büyük olamaz");
                                            goto PARAYATIRMAKKNUM;
                                        }
                                        else
                                        {
                                            Console.Clear() ;
                                            bakiye = bakiye - yatirilacaktutar;
                                            Console.WriteLine("Paranız başarıyla yatırılmıştır. Güncel bakiyeniz {0}TL",bakiye);
                                            goto ALTMENU;
                                        }
                                    }
                                    else if(kknum == "0")
                                    {
                                        Console.Clear();
                                        goto ANAMENU;
                                    }
                                    else
                                    {
                                        Console.Clear() ;
                                        Console.WriteLine("Lütfen 12 haneli bir numara girdiğinizden emin olunuz");
                                        goto KKNUMGIRME;
                                    }
                                }//KREDI KARTINA SECENEGI
                                else if (case2parayatirmasecim=="2")
                                {
                                    KENDIHESPARAYATIRMA:
                                    Console.Clear();
                                    Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                                    Console.WriteLine("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                    try
                                    {
                                        yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen numerik bir değer giriniz");
                                        goto KENDIHESPARAYATIRMA;
                                    }
                                    if (yatirilacaktutar==0)
                                    {
                                        Console.Clear();
                                        goto ANAMENU;
                                    }
                                    else
                                    {
                                        bakiye = bakiye + yatirilacaktutar;
                                        Console.WriteLine("Para yatırma işlemi gerçekleşmiştir. Güncel bakiyeniz {0}TL",bakiye);
                                        goto ALTMENU;
                                    }
                                }//KENDI HESABINA SECENEGI
                                else if (case2parayatirmasecim=="9")
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }
                                else if (case2parayatirmasecim=="0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 1,2,9 ve 0 haricinde başka bir seçenek girmeyiniz");
                                    goto CASE2PARAYATIRMA;
                                }
                                break; //CASE2 PARA YATIRMA
                            case "3":
                                Console.Clear();
                                CASE3PARTRA:
                                Console.WriteLine("1-Başka hesaba EFT");
                                Console.WriteLine("2-Başka hesaba havale");
                                Console.WriteLine("9-Ana menüye dön");
                                Console.WriteLine("0-Çıkış yap");
                                string case3paratranssecim = Console.ReadLine();
                                if (case3paratranssecim=="1")
                                {
                                    Console.Clear();
                                    EFTNUM:
                                    Console.WriteLine("Lütfen EFT numarası giriniz (TR ile başlamalı ve akabinde 12 hane girilmeli):");
                                    string eftnum = Console.ReadLine();
                                    if (eftnum[0]!='T' || eftnum[1]!='R')
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen EFT numarasının TR ile başladığından emin olunuz");
                                        goto EFTNUM;
                                    }
                                    else if (eftnum.Length != 14)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen EFT numarasının 14 haneden (TR+12) oluştuğundan emin olunuz");
                                        goto EFTNUM;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        EFTTUTAR:
                                        Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                                        Console.WriteLine("Gönderilecek tutarı giriniz: ");
                                        try
                                        {
                                            yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen numerik bir değer giriniz");
                                            goto EFTTUTAR;
                                        }
                                        if (yatirilacaktutar==0)
                                        {
                                            Console.Clear();
                                            goto ANAMENU;
                                        }
                                        else if (yatirilacaktutar>bakiye)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Yatırılacak tutar bakiyeden büyük olamaz. Güncel bakiyeniz {0}TL", bakiye);
                                            goto EFTTUTAR;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bakiye = bakiye - yatirilacaktutar;
                                            Console.WriteLine("EFT işleminiz başarıyla gerçekleşmiştir. Güncel bakiyeniz {0}TL", bakiye);
                                            goto ALTMENU;

                                        }
                                    }

                                } //BAŞKA HESABA EFT
                                else if (case3paratranssecim =="2")
                                {
                                    Console.Clear ();
                                    HESNUMGIRIS:
                                    Console.WriteLine("Lütfen 11 haneli hesap numarasını giriniz");
                                    try
                                    {
                                        hesnum = Console.ReadLine();
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen geçerli bir değer giriniz");
                                        goto HESNUMGIRIS;
                                    }
                                    if (hesnum.Length != 11)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen hesap numarasının 11 haneli olduğundan emin olunuz");
                                        goto HESNUMGIRIS;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                    BASKAHESABAHAVALE:
                                        Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                                        Console.WriteLine("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                        try
                                        {
                                            yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen numerik bir değer giriniz");
                                            goto BASKAHESABAHAVALE;
                                        }
                                        if (yatirilacaktutar == 0)
                                        {
                                            Console.Clear();
                                            goto ANAMENU;
                                        }
                                        else if (bakiye < yatirilacaktutar)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Yatırılacak tutar bakiyenizden büyük olamaz");
                                            goto BASKAHESABAHAVALE;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            bakiye = bakiye - yatirilacaktutar;
                                            Console.WriteLine("Havale işlemi başarıyla gerçekleşmiştir. Güncel bakiyeniz {0}TL", bakiye);
                                            goto ALTMENU;
                                        }
                                    }
                                }//BAŞKA HESABA HAVALE
                                else if (case3paratranssecim == "9")
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }
                                else if (case3paratranssecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 1,2,9 ve 0 haricinde başka bir seçenek girmeyiniz");
                                    goto CASE3PARTRA;
                                }
                                break; //CASE3 PARA TRANSFERLERI 
                            case "4":
                                Console.Clear();
                                Console.WriteLine("Eğitim Ödemeleri Geçici Olarak Arızalıdır.");
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }
                                break; //CASE4 EGITIM ODEMELERI
                            case "5":
                                Console.Clear();
                                CASE5FATURALAR:
                                Console.WriteLine("1-Elektrik Faturası");
                                Console.WriteLine("2-Telefon Faturası");
                                Console.WriteLine("3-İnternet Faturası");
                                Console.WriteLine("4-Su Faturası");
                                Console.WriteLine("5-OGS Ödemeleri");
                                Console.WriteLine("9-Ana Menü");
                                Console.WriteLine("0-Çıkış");
                                string odemelersecim = Console.ReadLine();
                                if (odemelersecim=="1" || odemelersecim == "2" || odemelersecim == "3" || odemelersecim == "4" || odemelersecim == "5") //ELEKTRIK FATURASI
                                {
                                    Console.Clear();
                                    FATURA:
                                    Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                                    Console.WriteLine("Lütfen ödenecek tutarı giriniz: ");
                                    try
                                    {
                                        faturatutari = Convert.ToDouble(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen numerik bir değer giriniz");
                                        goto FATURA;
                                    }
                                    if (faturatutari==0)
                                    {
                                        Console.Clear();
                                        goto ANAMENU;
                                    }
                                    else if (faturatutari>bakiye)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Hesabınızda yeterli bakiye bulunmamaktadır.");
                                        goto FATURA;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        bakiye = bakiye - faturatutari;
                                        Console.WriteLine("Tutar ödenmiştir. Güncel bakiyeniz {0}TL",bakiye);
                                        goto ALTMENU;
                                    }
                                }
                                else if (odemelersecim == "9")
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }
                                else if (odemelersecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen seçenekler haricinde başka bir değer girmeyiniz");
                                    goto CASE5FATURALAR;
                                }//FATURALAR
                                break; //CASE5 ODEMELER
                            case "6":
                                Console.Clear ();
                                Console.WriteLine("Anamenüye dönmek için 0'ı tuşlayınız");
                                Console.WriteLine("Lütfen eski şifrenizi giriniz: ");
                                string eskisifre = Console.ReadLine();
                                if (eskisifre=="0")
                                {
                                    Console.Clear();
                                    goto ANAMENU;
                                }
                                else if (eskisifre==sifre)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen yeni şifrenizi giriniz");
                                    sifre = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Şifreniz yenilenmiştir");
                                    goto ILKGIRIS;
                                }
                                break; //CASE6 BILGI GUNCELLEME
                            case "7":
                                Environment.Exit(0);
                                break; //CASE7 EXIT
                            default:
                                Console.Clear();
                                Console.WriteLine("Lütfen 1,2,3,4,5,6 ve 7 seçeneklerinden başka bir değer girmeyiniz");
                                goto ANAMENU;
                                
                        }

                    }
                    else                                                    
                    {
                        deneme = 3;
                        Console.Clear();
                        deneme--;
                        if (deneme == 0)
                        {
                            Console.WriteLine("Çok fazla başarısız deneme yapılmıştır. Lütfen müşteri temsilcinizle görüşünüz");
                            Environment.Exit(0);
                            Console.Read();
                        }
                        else
                        {
                            Console.WriteLine("Şifreniz hatalı");
                            Console.WriteLine("{0} deneme hakkınız kalmıştır.", deneme);
                            goto LOGIN;
                        }

                    }
                    break; ///-- KARTLI ISLEM
                case "2": //--KARTSIZ ISLEM MENU
                    Console.Clear();
                    KARTSIZISLEMMENU: 
                    Console.WriteLine("1-CepBank Para Çekmek");
                    Console.WriteLine("2-Para Yatırma");
                    Console.WriteLine("3-Kredi Kartı Ödeme");
                    Console.WriteLine("4-Eğitim Ödemeleri");
                    Console.WriteLine("5-Ödemeler");
                    Console.WriteLine("6-Çıkış");
                    string kartsizislemsecim = Console.ReadLine();
                    if (kartsizislemsecim == "1") //CEPBANK PARA CEKMEK
                    {
                        Console.Clear();
                    CEPBANKPARA:
                        Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                        Console.WriteLine("Lütfen TC kimlik numaranızı giriniz: ");
                        string tc = Console.ReadLine();
                        if (tc == "0")
                        {
                            Console.Clear();
                            goto KARTSIZISLEMMENU;
                        }//0 GIRILIRSE ANAMENUYE DONME KISMI
                        Console.WriteLine("Telefon numaranızı giriniz");
                        string telno = Console.ReadLine();
                        if (telno == "0")
                        {
                            Console.Clear();
                            goto KARTSIZISLEMMENU;
                        }//0 GIRILIRSE ANAMENUYE DONME KISMI
                        if (tc.Length != 11 || telno.Length != 10)
                        {
                            deneme--;
                            Console.Clear();
                            Console.WriteLine("Lütfen TC kimlik numaranızı ve telefon numaranızı eksiksiz girdiğinizden emin olunuz {0} hakkınız kalmıştır", deneme);
                            if (deneme == 0)
                            {
                                Environment.Exit(0);
                            }
                            goto CEPBANKPARA;
                        }// KARTSIZ ISLEMLER ICIN 3 KERE YANLIS GIRME HAKKI KISMI
                        else if (tc.Length == 11 && telno.Length == 10)
                        {
                            Console.Clear();
                        CEKMETALEBI:
                            Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                            Console.WriteLine("Lütfen çekmek istediğiniz tutarı giriniz: ");
                            try
                            {
                                cekilecektutar = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen numerik bir değer giriniz");
                                goto CEKMETALEBI;
                            }
                            if (cekilecektutar == 0)
                            {
                                Console.Clear();
                                goto KARTSIZISLEMMENU;
                            }
                            else if (cekilecektutar > bakiye)
                            {
                                Console.Clear();
                                Console.WriteLine("Çekilecek tutar bakiyeden büyük olamaz");
                                goto CEKMETALEBI;
                            }
                            else
                            {
                                Console.Clear();
                                bakiye = bakiye - cekilecektutar;
                                Console.WriteLine("Para çekme işlemi başarılı. Güncel bakiyeniz {0}TL", bakiye);
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }
                            }

                        }


                    }//CEPBANK PARA CEKMEK
                    else if (kartsizislemsecim == "2")
                    {
                        Console.Clear();
                    PARAYATIRMAKARTSIZISLEM:
                        Console.WriteLine("1-Nakit Ödeme");
                        Console.WriteLine("2-Hesaptan Ödeme");
                        Console.WriteLine("9-Ana menü");
                        Console.WriteLine("0-Çıkış");
                        string case2parayatirmasecim = Console.ReadLine();
                        if (case2parayatirmasecim == "1") //NAKIT ODEME
                        {
                            Console.Clear();
                        KKNUMVETCKNALMA:
                            Console.WriteLine("Lütfen 12 haneli kredi kartı numaranızı giriniz");
                            string kknum = Console.ReadLine();
                            Console.WriteLine("Lütfen TC kimlik numaranızı giriniz: ");
                            string tcno = Console.ReadLine();
                            if (kknum.Length == 12 && tcno.Length == 11)
                            {
                                Console.Clear();
                            PARAYATIRMAGIRILECEKTUTAR:
                                Console.WriteLine("Lütfen yatırılacak tutarı giriniz:");
                                try
                                {
                                    yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen numerik bir değer giriniz");
                                    goto PARAYATIRMAGIRILECEKTUTAR;
                                }
                                Console.Clear();
                                bakiye = bakiye + yatirilacaktutar;
                                Console.WriteLine("İşlem başarılı. Güncel bakiyeniz {0}TL", bakiye);
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen bilgileri doğru girdiğinizden emin olunuz");
                                goto KKNUMVETCKNALMA;
                            }

                        }//NAKIT ODEME
                        else if (case2parayatirmasecim == "2")//HESAPTAN ODEME
                        {
                            Console.Clear();
                        KKNOVEHESNOALMA:
                            Console.WriteLine("Lütfen kredi kartı numaranızı giriniz:");
                            string kknum = Console.ReadLine();
                            Console.WriteLine("Lütfen hesap numaranızı giriniz:");
                            string hesapno = Console.ReadLine();
                            if (kknum.Length != 12 || hesapno.Length != 12)
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen bilgileri doğru girdiğinizden emin olunuz");
                                goto KKNOVEHESNOALMA;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen yatırılacak tutarı giriniz: ");
                                yatirilacaktutar = Convert.ToDouble(Console.ReadLine());
                                Console.Clear();
                                bakiye = bakiye + yatirilacaktutar;
                                Console.WriteLine("İşlem başarılı. Güncel bakiyeniz {0}TL", bakiye);
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }
                            }



                        }//HESAPTAN ODEME
                        else if (case2parayatirmasecim == "9")
                        {
                            Console.Clear();
                            goto KARTSIZISLEMMENU;
                        }//ANAMENU
                        else if (case2parayatirmasecim == "0")
                        {
                            Environment.Exit(0);
                        }//CIKIS
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen ekrandakı seçeneklerden başka bir değer girmeyiniz.");
                            goto PARAYATIRMAKARTSIZISLEM;
                        }//1290 HARICI DEGER

                    } //PARA YATIRMA KARTSIZ ISLEM
                    else if (kartsizislemsecim == "3")
                    {
                        Console.Clear();
                    TCVEKARTNOGIRME:
                        Console.WriteLine("Ana mneyüde dönmek için 0'ı tuşlayınız");
                        Console.WriteLine("TC kimlik numaranızı giriniz:");
                        string tcno = Console.ReadLine();
                        Console.WriteLine("On iki haneli kart numaranızı giriniz:");
                        string kartno = Console.ReadLine();
                        if (tcno.Length == 11 && kartno.Length == 12)
                        {
                        KREDIBORCU:
                            Console.WriteLine("Borcunuz için yatırılacak tutarı giriniz: ");
                            try
                            {
                                cekilecektutar = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen numerik bir değer giriniz");
                                goto KREDIBORCU;
                            }
                            if (cekilecektutar > bakiye)
                            {
                                Console.Clear();
                                Console.WriteLine("Yetersiz bakiye. Güncel bakiyeniz {0}TL", bakiye);
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                bakiye = bakiye - cekilecektutar;
                                Console.WriteLine("İşlem başarılıı. Güncel  bakiyeniz {0}TL", bakiye);
                            ALTMENU:
                                Console.WriteLine("9- Ana Menüye Dön");
                                Console.WriteLine("0- Çıkış Yap");
                                altmenusecim = Console.ReadLine();
                                if (altmenusecim == "9")
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (altmenusecim == "0")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                    goto ALTMENU;
                                }
                            }
                        }
                        else
                        {
                            deneme--;
                            Console.Clear();
                            Console.WriteLine("Lütfen bilgileri doğru girdiğinizden emin olunuz. {0} hakkınız kalmıştır", deneme);
                            if (deneme == 0)
                            {
                                Environment.Exit(0);
                            }
                            goto TCVEKARTNOGIRME;

                        }
                    } //KREDI KARTI YATIRMA
                    else if (kartsizislemsecim == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("Eğitim ödemeleri geçici olarak arızalı");
                    ALTMENU:
                        Console.WriteLine("9- Ana Menüye Dön");
                        Console.WriteLine("0- Çıkış Yap");
                        altmenusecim = Console.ReadLine();
                        if (altmenusecim == "9")
                        {
                            Console.Clear();
                            goto KARTSIZISLEMMENU;
                        }
                        else if (altmenusecim == "0")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                            goto ALTMENU;
                        }
                    }//EGITIM ODEMELERI
                    else if (kartsizislemsecim == "5")
                    {
                        Console.Clear();
                    TCVEKARTNOGIRME:
                        Console.WriteLine("Ana mneyüde dönmek için 0'ı tuşlayınız");
                        Console.WriteLine("TC kimlik numaranızı giriniz:");
                        string tcno = Console.ReadLine();
                        Console.WriteLine("On iki haneli kart numaranızı giriniz:");
                        string kartno = Console.ReadLine();
                        if (tcno.Length == 11 && kartno.Length == 12)
                        {
                            Console.Clear();
                            Console.WriteLine("1-Elektrik Faturası");
                            Console.WriteLine("2-Telefon Faturası");
                            Console.WriteLine("3-İnternet Faturası");
                            Console.WriteLine("4-Su Faturası");
                            Console.WriteLine("5-OGS Ödemeleri");
                            Console.WriteLine("9-Ana Menü");
                            Console.WriteLine("0-Çıkış");
                            string odemelersecim = Console.ReadLine();
                            if (odemelersecim == "1" || odemelersecim == "2" || odemelersecim == "3" || odemelersecim == "4" || odemelersecim == "5")
                            {
                                Console.Clear();
                            FATURA:
                                Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayınız");
                                Console.WriteLine("Lütfen ödenecek tutarı giriniz: ");
                                try
                                {
                                    faturatutari = Convert.ToDouble(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lütfen numerik bir değer giriniz");
                                    goto FATURA;
                                }
                                if (faturatutari == 0)
                                {
                                    Console.Clear();
                                    goto KARTSIZISLEMMENU;
                                }
                                else if (faturatutari > bakiye)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Hesabınızda yeterli bakiye bulunmamaktadır.");
                                    goto FATURA;
                                }
                                else
                                {
                                    Console.Clear();
                                    bakiye = bakiye - faturatutari;
                                    Console.WriteLine("Tutar ödenmiştir. Güncel bakiyeniz {0}TL", bakiye);
                                ALTMENU:
                                    Console.WriteLine("9- Ana Menüye Dön");
                                    Console.WriteLine("0- Çıkış Yap");
                                    altmenusecim = Console.ReadLine();
                                    if (altmenusecim == "9")
                                    {
                                        Console.Clear();
                                        goto KARTSIZISLEMMENU;
                                    }
                                    else if (altmenusecim == "0")
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lütfen 9 ve 0 seçenekleri dışında başka bir veri girmeyiniz");
                                        goto ALTMENU;
                                    }

                                }

                            }
                        }
                        else
                        {
                            deneme--;
                            Console.Clear();
                            Console.WriteLine("Lütfen bilgileri doğru girdiğinizden emin olunuz. {0} hakkınız kalmıştır", deneme);
                            if (deneme == 0)
                            {
                                Environment.Exit(0);
                            }
                            goto TCVEKARTNOGIRME;

                        }

                    }//FATURALAR // BURADA KALDIM
                    else if (kartsizislemsecim == "6")
                    {
                        Environment.Exit(0);
                    } //CIKIS TAMAMLANDI
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen ekrandaki seçeneklerden başka bir değer girmeyiniz");
                        goto KARTSIZISLEMMENU;
                    }

                    break; ///--KARTSIZ ISLEM
                default:
                    Console.Clear ();
                    Console.WriteLine("Lütfen 1 ve 2 haricinde başka bir değer girmeyiniz");
                    goto ILKGIRIS;
                    
            }

        }
    }
}
