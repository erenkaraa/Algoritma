using System;

namespace KarakterSiliciApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Girdi giriniz (örn: Algoritma,3):");
            string input = Console.ReadLine();

            string[] girisler = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var girdi in girisler)
            {
                if (GirdiIsleyici.TryParse(girdi, out string metin, out int index))
                {
                    string sonuc = KarakterSilici.Sil(metin, index);
                    Console.WriteLine(sonuc);
                }
                else
                {
                    Console.WriteLine($"Geçersiz giriş: {girdi}");
                }
            }
        }
    }

    static class GirdiIsleyici
    {
        public static bool TryParse(string girdi, out string metin, out int index)
        {
            metin = string.Empty;
            index = -1;

            var parcalar = girdi.Split(',');

            if (parcalar.Length == 2 &&
                !string.IsNullOrWhiteSpace(parcalar[0]) &&
                int.TryParse(parcalar[1], out index))
            {
                metin = parcalar[0];
                return true;
            }

            return false;
        }
    }

    static class KarakterSilici
    {
        public static string Sil(string metin, int index)
        {
            if (index < 0 || index >= metin.Length)
                return metin;

            return metin.Remove(index, 1);
        }
    }
}
