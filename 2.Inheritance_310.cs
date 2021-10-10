using System;

namespace _2.Inheritance_310
{
    public class KomisiKaryawan
    {
        public string namaDepan { get; }
        public string namaBelakang { get; }
        public string NomorKTP { get; }
        private decimal Penjualankotor;
        private decimal Tarifkomisi;
        private decimal Gajipokok;

        public KomisiKaryawan(string Namadepan, string Namabelakang,
        string NoKTP, decimal Penjualankotor,
        decimal tarifKomisi, decimal gajiPokok)
        {
            namaDepan = Namadepan;
            namaBelakang = Namabelakang;
            NomorKTP = NoKTP;
            PenjualanKotor = Penjualankotor;
            TarifKomisi = tarifKomisi;
            GajiPokok = gajiPokok;
        }

        public decimal PenjualanKotor
        {
            get
            {
                return Penjualankotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(PenjualanKotor)} harus >= 0");
                }

                Penjualankotor = value;
            }
        }

        public decimal TarifKomisi
        {
            get
            {
                return Tarifkomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(TarifKomisi)} harus > 0 dan < 1");
                }

                Tarifkomisi = value;
            }
        }

        public decimal GajiPokok
        {
            get
            {
                return Gajipokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiPokok)} harus >= 0");
                }

                Gajipokok = value;
            }
        }

        public decimal Pendapatan() => Gajipokok + (Tarifkomisi * Penjualankotor);

        public override string ToString() =>
            $"Gaji pokok karyawan: {namaDepan} {namaBelakang}\n" +
            $"No.KTP: {NomorKTP}\n" +
            $"Penjualan kotor: {Penjualankotor:C}\n" + $"Tarif komisi: {Tarifkomisi:F2}\n" + $"Gaji pokok: {Gajipokok:C}";
    }
    class Test
    {
        static void Main()
        {
            var Karyawan = new KomisiKaryawan("Bob", "Lewis",
            "333-33-3333", 5000.00M, .04M, 300.00M);
            Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode: \n");
            Console.WriteLine($"Nama depan : {Karyawan.namaDepan }");
            Console.WriteLine($"Nama belakang : {Karyawan.namaBelakang }");
            Console.WriteLine($"No.KTP : {Karyawan.NomorKTP}");
            Console.WriteLine($"Penjualan kotor : {Karyawan.PenjualanKotor:C}");
            Console.WriteLine($"Tarif komisi : {Karyawan.TarifKomisi:F2}");
            Console.WriteLine($"Pendapatan : {Karyawan.Pendapatan():C}");
            Console.WriteLine($"Gaji pokok : {Karyawan.GajiPokok:C}");

            Karyawan.GajiPokok = 1000.00M;
            Console.WriteLine("\nInformasi karyawan yang terbarui diperoleh :\n");
            Console.WriteLine(Karyawan);
            Console.WriteLine($"Pendapatan: {Karyawan.Pendapatan():C}");
        }
    }
}
