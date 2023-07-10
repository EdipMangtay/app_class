using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace app_class
{
     
    internal class admin_product
    {
        public int urunid;
        public string yemek;
        public int fiyat;
        public decimal cook;
        public string Kcal;
        
        
        public static void admin(List<admin_product> list)
        {
            Console.Clear();
            Console.WriteLine("Admin Ürün Ekleme sayfası");
            while (true)
            {
                admin_product p = new admin_product();
                Console.Write("Ürün ID'sini girin: ");
                p.urunid = int.Parse(Console.ReadLine());

                Console.WriteLine("Yemek adını giriniz");
                p.yemek = Console.ReadLine();

                Console.WriteLine("Fiyat bilgisini giriniz");
                p.fiyat = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Pişirim süresini giriniz");
                p.cook = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Kalori bilgisini giriniz");
                p.Kcal = Console.ReadLine();
                list.Add(p);

                Console.WriteLine("Ürün eklendi Başka ürün eklemek için D");
                string secim = Console.ReadLine().ToUpper();
                if (secim == "D")
                {

                }
                else
                {
                    break;
                }


            }
        }
        public static void listele(List<admin_product> listele)
        {
            foreach (admin_product item in listele)
            {
                Console.WriteLine("Admin Tarafından Girilen ürünler...");
                Console.WriteLine("Ürün ID : " + item.urunid);
                Console.WriteLine("Yemeğin İsmi : " + item.yemek);
                Console.WriteLine("Yemeğin Fiyatı :" + item.fiyat);
                Console.WriteLine("Yemeğin Kalorisi : " + item.Kcal);
                Console.WriteLine("Pişirim Süresi : " + item.cook);
                Console.WriteLine();
            }
        }
        public static void alımlar(List<admin_product> slist)
        {
            Console.WriteLine("Kaç numaralı ürünü almak istiyorsunuz");
            int s2 = int.Parse(Console.ReadLine());
            int bakiye = 150;
            if (s2 <= slist.Count && s2 > 0)
            {
                Thread.Sleep(1000);
                List<admin_product> siparisler = new List<admin_product>(); // Geçici koleksiyon
                foreach (admin_product c in slist)
                {
                    
                    if (c.urunid == s2)
                    {

                        siparisler.Add(c);
                        Console.WriteLine("---Seçilen Ürün--- ");
                        Console.WriteLine("Ürün ID : " + c.urunid);
                        Console.WriteLine("Yemeğin İsmi : " + c.yemek);
                        Console.WriteLine("Yemeğin Fiyatı :" + c.fiyat);
                        Console.WriteLine("Yemeğin Kalorisi : " + c.Kcal);
                        Console.WriteLine("Pişirim Süresi : " + c.cook);
                        DateTime now = DateTime.Now;
                        string currentDateTime = now.ToString("dd/MM/yyyy HH:mm:ss");
                        Console.WriteLine("Sipariş Tarihi");
                        Console.WriteLine(currentDateTime);
                        Console.WriteLine();
                        Console.WriteLine("Sipariş Tutarı " + c.fiyat);
                        int m = c.fiyat;
                        
                        while (true)
                        {
                            Console.WriteLine("İşlemi Onaylıyor musunuz  E/H");
                            string secim = Console.ReadLine().ToUpper();
                            if (secim == "E")
                            {
                                if (m > bakiye)
                                {
                                    Console.WriteLine("Yetersiz Bakiye");
                                    Console.WriteLine("Para yüklemek için E çıkış için H?");
                                    string secim1 = Console.ReadLine().ToUpper();
                                    if (secim1 == "E")
                                    {
                                        Console.WriteLine("Iban bilgisi giriniz");
                                        string iban = Console.ReadLine();
                                        if (iban.StartsWith("TR") && iban.Length == 13)
                                        {
                                            Console.WriteLine("Tutar giriniz");
                                            int tutar = Convert.ToInt32(Console.ReadLine());
                                            bakiye += tutar;
                                            Console.WriteLine();
                                            Console.WriteLine("İşlem Başarılı yeni bakiye " + bakiye);
                                            Console.WriteLine("Siparişiniz Alındı Güncel bakiye : " + (bakiye - m));
                                            break;


                                        }

                                    }
                                }
                                else if (bakiye > m)
                                {
                                    Console.WriteLine("İşlem Başarılı");
                                    Console.WriteLine("Siparişiniz Alındı Güncel bakiye : " + (bakiye - m));
                                    break;


                                }
                            }
                            else if (secim == "H")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş");
                            }
                        }
                    }

                }

            }

        }
       

    }
    public class product2
    {
        public int urunid;
        public string yemek;
        public int fiyat;
        public decimal cook;
        public int kcal;
        public int bakiye = 100;

        

        public static List<product2> list = new List<product2>()
        {
            new product2(){urunid = 1,yemek = "Köfte",fiyat = 100,cook = 30,kcal = 340},
            new product2(){urunid = 2,yemek = "Pizza",fiyat = 150,cook = 30,kcal = 340},
            new product2(){urunid = 3,yemek = "Burger",fiyat = 200,cook = 30,kcal = 340},
            new product2(){urunid = 4,yemek = "Lahmacub",fiyat = 300,cook = 30,kcal = 340}
        };

        
        
        public static void aktar(List<product2> mlist)
        {
            Console.WriteLine("Kaç numaralı ürünü almak istiyorsunuz");
            int s1 = int.Parse(Console.ReadLine());
            int bakiye = 100;
            if(s1<=list.Count && s1>0)
            {
                foreach (product2 item in list)
                {
                    if (item.urunid == s1 )
                    {
                       
                        mlist.Add(item);
                        Console.WriteLine("---Seçilen Ürün--- ");
                        Console.WriteLine("Ürün ID : " + item.urunid);
                        Console.WriteLine("Yemeğin İsmi : " + item.yemek);
                        Console.WriteLine("Yemeğin Fiyatı :" + item.fiyat);
                        Console.WriteLine("Yemeğin Kalorisi : " + item.kcal);
                        Console.WriteLine("Pişirim Süresi : " + item.cook);
                        DateTime now = DateTime.Now;
                        string currentDateTime = now.ToString("dd/MM/yyyy HH:mm:ss");
                        Console.WriteLine("Sipariş Tarihi");
                        Console.WriteLine(currentDateTime);
                        Console.WriteLine();
                        Console.WriteLine("Sipariş Tutarı " + item.fiyat );
                        int a = item.fiyat;
                        while (true)
                        {
                            Console.WriteLine("İşlemi Onaylıyor musunuz  E/H");
                            string secim = Console.ReadLine().ToUpper();
                            if (secim == "E")
                            {
                               if (a > bakiye)
                               {
                                    Console.WriteLine("Yetersiz Bakiye");
                                    Console.WriteLine("Para yüklemek için E çıkış için H?");
                                    string secim1 = Console.ReadLine().ToUpper();
                                    if (secim1 == "E")
                                    {
                                        Console.WriteLine("Iban bilgisi giriniz");
                                        string iban = Console.ReadLine();
                                        if (iban.StartsWith("TR") && iban.Length==13)
                                        {
                                            Console.WriteLine("Tutar giriniz");
                                            int tutar = Convert.ToInt32(Console.ReadLine());
                                            bakiye += tutar;
                                            Console.WriteLine();
                                            Console.WriteLine("İşlem Başarılı yeni bakiye " + bakiye);
                                            Console.WriteLine("Siparişiniz Alındı Güncel bakiye : " + (bakiye - a));
                                            break;


                                        }

                                    }
                               }
                               else if (bakiye > a)
                               {
                                    Console.WriteLine("İşlem Başarılı");
                                    Console.WriteLine("Siparişiniz Alındı Güncel bakiye : " + (bakiye - a));
                                    break;

                                    
                               }
                            }
                            else if (secim == "H")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş");
                            }
                            Console.WriteLine("İşlem Başarılı");
                            Console.WriteLine("Siparişiniz Alındı Güncel bakiye : " + (bakiye - a));
                            break;
                        }
                      
                    }

                }

            }
            else
            {
                Console.WriteLine("Hata");
            }
            
         
        }
       




    }
}
