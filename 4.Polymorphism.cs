using System;
using System.Collections.Generic;

namespace _4.Polymorphism
{
    public abstract class Karyawan
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomorKTP { get; }

        public Karyawan(string namaDepan, string namaBelakang,
        string NoKTP)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = NoKTP;
        }

        public override string ToString() => $"{NamaDepan} {NamaBelakang}\n" +
        $"No.KTP: {NomorKTP}";

        public abstract decimal Pendapatan();
    }
    public class GajiKaryawan : Karyawan
    {
        private decimal gajiMingguan;

        public GajiKaryawan(string namaDepan, string namaBelakang,
        string NoKTP, decimal gajiMingguan)
        : base(namaDepan, namaBelakang, NoKTP)
        {
            GajiMingguan = gajiMingguan;
        }

        public decimal GajiMingguan
        {
            get
            {
                return gajiMingguan;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiMingguan)} harus >= 0");
                }

                gajiMingguan = value;
            }
        }

        public override decimal Pendapatan() => GajiMingguan;

        public override string ToString() =>
        $"Gaji Karyawan: {base.ToString()}\n" +
        $"Gaji Mingguan: {GajiMingguan:C}";
    }
    public class JamKerja : Karyawan
    {
        private decimal upah;
        private decimal jam;

        public JamKerja(string namaDepan, string namaBelakang,
        string NoKTP, decimal upahPerjam,
        decimal jamKerja)
        : base(namaDepan, namaBelakang, NoKTP)
        {
            Upah = upahPerjam;
            Jam = jamKerja;
        }

        public decimal Upah
        {
            get
            {
                return upah;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Upah)} harus >= 0");
                }

                upah = value;
            }
        }

        public decimal Jam
        {
            get
            {
                return jam;
            }
            set
            {
                if (value < 0 || value > 168)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Jam)} harus >= 0 dan <= 168");
                }

                jam = value;
            }
        }

        public override decimal Pendapatan()
        {
            if (Jam <= 40)
            {
                return Upah * Jam;
            }
            else
            {
                return (40 * Upah) + ((Jam - 40) * Upah * 1.5M);
            }
        }

        public override string ToString() =>
        $"karyawan: {base.ToString()}\n" +
        $"upah perjam: {Upah:C}\njam kerja: {Jam:F2}";
    }
    public class KomisiKaryawan : Karyawan
    {
        private decimal penjualanKotor;
        private decimal tarifGaji;

        public KomisiKaryawan(string namaDepan, string namaBelakang,
        string NoKTP, decimal penjualanKotor, decimal tarifGaji)
        : base(namaDepan, namaBelakang, NoKTP)
        {
            PenjualanKotor = penjualanKotor;
            TarifGaji = tarifGaji;
        }

        public decimal PenjualanKotor
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
                    value, $"{nameof(PenjualanKotor)} harus >= 0");
                }

                penjualanKotor = value;
            }
        }

        public decimal TarifGaji
        {
            get
            {
                return tarifGaji;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(TarifGaji)} harus > 0 dan < 1");
                }

                tarifGaji = value;
            }
        }

        public override decimal Pendapatan() => TarifGaji * PenjualanKotor;

        public override string ToString() =>
        $"Gaji karyawan: {base.ToString()}\n" +
        $"Penjualan kotor: {PenjualanKotor:C}\n" +
        $"Tarif gaji: {TarifGaji:F2}";
    }
    public class KomisiPlusGajiKaryawan : KomisiKaryawan
    {
        private decimal upahDasar;

        public KomisiPlusGajiKaryawan(string namaDepan, string namaBelakang,
        string NoKTP, decimal penjualKotor, decimal tarifGaji, decimal upahDasar)
        : base(namaDepan, namaBelakang, NoKTP, penjualKotor, tarifGaji)

        {
            UpahDasar = upahDasar;
        }

        public decimal UpahDasar
        {
            get
            {
                return upahDasar;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(UpahDasar)} harus >= 0");
                }

                upahDasar = value;
            }
        }


        public override decimal Pendapatan() => UpahDasar + base.Pendapatan();

        public override string ToString() =>
        $"Gaji pokok {base.ToString()}\nKomisi pokok: {UpahDasar:C}";
    }

    class Program
    {
        static void Main()
        {

            var gajiKaryawan = new GajiKaryawan("John", "Smith",
            "111-11-1111", 800.00M);
            var JamKerjaKaryawan = new JamKerja("Karen", "Price",
            "222-22-2222", 16.75M, 40.0M);
            var GajiKaryawan = new KomisiKaryawan("Sue", "Jones",
            "333-33-3333", 10000.00M, .06M);
            var komisiPlusGaji = new KomisiPlusGajiKaryawan("Bob", "Lewis",
            "444-44-4444", 5000.00M, .04M, 300.00M);


            Console.WriteLine("Karyawan diproses secara individual:\n");

            Console.WriteLine($"{gajiKaryawan}\ndiperoleh: " + $"{gajiKaryawan.Pendapatan():C}\n");
            Console.WriteLine($"{JamKerjaKaryawan}\ndiperoleh: {JamKerjaKaryawan.Pendapatan():C}\n");
            Console.WriteLine($"{GajiKaryawan}\ndiperoleh: " + $"{GajiKaryawan.Pendapatan():C}\n");
            Console.WriteLine($"{GajiKaryawan}\ndiperoleh: " + $"{komisiPlusGaji.Pendapatan():C}\n");


            var karyawan = new List<Karyawan>() { gajiKaryawan, JamKerjaKaryawan, GajiKaryawan, komisiPlusGaji };

            Console.WriteLine("Karyawan diproses secara polimorfik:\n");

            foreach (var pekerja_sekarang in karyawan)
            {
                Console.WriteLine(pekerja_sekarang);


                if (pekerja_sekarang is KomisiPlusGajiKaryawan)
                {

                    var karyawan1 = (KomisiPlusGajiKaryawan)pekerja_sekarang;

                    karyawan1.UpahDasar *= 1.10M;
                    Console.WriteLine("new base salary with 10% increase is: " + $"{karyawan1.UpahDasar:C}");
                }

                Console.WriteLine($"earned: {pekerja_sekarang.Pendapatan():C}\n");
            }

            for (int j = 0; j < karyawan.Count; j++)
            {
                Console.WriteLine(
                $"Type {j} adalah {karyawan[j].GetType()}");
            }
        }
    }
}
