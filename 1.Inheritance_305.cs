using System;

namespace _1.Inheritance_305
{
    public class Gaji_karyawan : object
    {
        public string namaDepan { get; }
        public string namaBelakang { get; }
        public string NomorKTP { get; }
        private decimal penjualanKotor;
        private decimal tarifKomisi;


        public Gaji_karyawan(string Namadepan, string Namabelakang,
        string NoKTP, decimal Penjualankotor,
        decimal Tarifkomisi)
        {

            namaDepan = Namadepan;
            namaBelakang = Namabelakang;
            NomorKTP = NoKTP;
            Penjualan_Kotor = Penjualankotor;
            Tarif_Komisi = Tarifkomisi;
        }

        public decimal Penjualan_Kotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Penjualan_Kotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }

        public decimal Tarif_Komisi
        {
            get
            {
                return tarifKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Tarif_Komisi)} harus > 0 dan < 1");
                }

                tarifKomisi = value;
            }
        }

        public decimal Pendapatan() => tarifKomisi * penjualanKotor;


        public override string ToString() =>
        $"Nama pegawai: {namaDepan} {namaBelakang}\n" +
        $"No.KTP: {NomorKTP}\n" +
        $"Penjualan kotor: {penjualanKotor:C}\n" +
        $"Tarif komisi: {tarifKomisi:F2}";
    }
    class Test
    {
        static void Main()
        {

            var karyawan = new Gaji_karyawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

            Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode: \n");
            Console.WriteLine($"Nama depan = {karyawan.namaDepan}");
            Console.WriteLine($"Nama belakang = { karyawan.namaBelakang}");
            Console.WriteLine($"No.KTP = {karyawan.NomorKTP }");
            Console.WriteLine($"Penjualan Kotor = {karyawan.Penjualan_Kotor:C}");
            Console.WriteLine($"Tarif harga = {karyawan.Tarif_Komisi:F2}");
            Console.WriteLine($"Pendapatan = {karyawan.Pendapatan():C}");


            karyawan.Penjualan_Kotor = 5000.00M;
            karyawan.Tarif_Komisi = .1M;

            Console.WriteLine("\nInformasi karyawan yang terbarui diperoleh:\n");
            Console.WriteLine(karyawan);
            Console.WriteLine($"Pendapatan: {karyawan.Pendapatan():C}");
        }
    }
}

