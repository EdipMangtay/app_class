using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace app_class
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            List<product2> kullanciP = new List<product2>();
            List<admin_product> urunler = new List<admin_product>();
            admin_product p = new admin_product();
           
           
                     


            while (true)
            {
                Console.WriteLine("Admin girişi için 1 - Menü için 2  Çıkmak için q");



                string secim = Console.ReadLine();
                if (secim == "1")
                {
                    admin_product.admin(urunler);
                    admin_product.listele(urunler);
                    admin_product.alımlar(urunler);
                    Console.WriteLine("Afiyet olsun");
                    Console.WriteLine("Aldığınız ürün");
                    
                    
                   

                }
                else if (secim == "2")
                {
                    Console.WriteLine("------MENÜ-----");
                    foreach (product2 item in product2.list)
                    {
                        Console.WriteLine("Ürün ID : " + item.urunid);
                        Console.WriteLine("Yemeğin İsmi : " + item.yemek);
                        Console.WriteLine("Yemeğin Fiyatı :" + item.fiyat);
                        Console.WriteLine("Yemeğin Kalorisi : " + item.kcal);
                        Console.WriteLine("Pişirim Süresi : " + item.cook);
                        Console.WriteLine();

                    }
                    Console.WriteLine();

                    product2.aktar(kullanciP);
                    Console.WriteLine("Başarılı");
                    Console.WriteLine("Sipariş geçmişi için G");
                    string g = Console.ReadLine().ToUpper();
                    if (g == "G")
                    {
                        foreach (product2 item in kullanciP)
                        {
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
                            
                        }
                    }


                    Console.WriteLine();

                }
                else if(secim =="q")
                {
                    Console.WriteLine("Çıkış yapılıyor");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş ");
                }

            }
        }
    }
}
