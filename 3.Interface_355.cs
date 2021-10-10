using System;
using System.Collections.Generic;

namespace _3.Interface_355
{
    public interface IHutang
    {
        decimal DapatkanJumlahPembayaran();
    }

    public class Tagihan : IHutang
    {
        public string NomorBagian { get; }
        public string Deskripsi { get; }
        private int kuantitas;
        private decimal HargaperItem;


        public Tagihan(string nomorBagian, string deskripsi, int kuantitas,
        decimal HargaperItem)
        {
            NomorBagian = nomorBagian;
            Deskripsi = deskripsi;
            Kualitas = kuantitas;
            HargaPerItem = HargaperItem;
        }

        public int Kualitas
        {
            get
            {
                return kuantitas;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Kualitas)} harus >= 0");
                }

                kuantitas = value;
            }
        }


        public decimal HargaPerItem
        {
            get
            {
                return HargaperItem;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(HargaPerItem)} harus >= 0");
                }

                HargaperItem = value;
            }
        }

        public override string ToString() =>
        $"Tagihan:\nNomor bagian: {NomorBagian} ({Deskripsi})\n" +
        $"Kuantitas: {Kualitas}\nHarga Per Item: {HargaPerItem:C}";

        public decimal DapatkanJumlahPembayaran() => Kualitas * HargaPerItem;
    }
    public class GajiKaryawan : IHutang
    {
        public string namaDepan { get; }
        public string namaBelakang { get; }
        public string NomorKTP { get; }
        private decimal gajiMingguan;


        public GajiKaryawan(string Namadepan, string Namabelakang,
        string NoKTP, decimal gajimingguan)
        {
            namaDepan = Namadepan;
            namaBelakang = Namabelakang;
            NomorKTP = NoKTP;
            GajiMingguan = gajimingguan;
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



        public override string ToString() =>
        $"Nama pegawai: {namaDepan} {namaBelakang}\n" +
        $"No.KTP: {NomorKTP}\n" +
        $"Gaji mingguan: {gajiMingguan:C}";

        public decimal DapatkanJumlahPembayaran() => gajiMingguan;
    }

    class Test
    {
        static void Main()
        {

            var Hutang = new List<IHutang>() {
            new Tagihan("01234", "seat", 2, 375.00M),
            new Tagihan("56789", "tire", 4, 79.95M),
            new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M),
            new GajiKaryawan("Lisa", "Barnes", "888-88-8888", 1200.00M)};

            Console.WriteLine(
            "Tagihan dan Karyawan diproses secara polimorfis:\n");

            foreach (var hutang in Hutang)
            {

                Console.WriteLine($"{hutang}");
                Console.WriteLine(
                $"Pembayaran akhir: {hutang.DapatkanJumlahPembayaran():C}\n");
            }
        }

    }
}
