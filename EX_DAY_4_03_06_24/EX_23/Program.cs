using System;
using System.Text;

struct PhanSo
{
    public int TuSo;
    public int MauSo;

    public PhanSo(int tuSo, int mauSo)
    {
        if (mauSo == 0)
        {
            throw new ArgumentException("Mẫu số không được bằng 0");
        }
        TuSo = tuSo;
        MauSo = mauSo;
        ToiGian();
    }

    public void ToiGian()
    {
        int gcd = GCD(TuSo, MauSo);
        TuSo /= gcd;
        MauSo /= gcd;
    }

    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        return new PhanSo(tu, mau);
    }

    public static PhanSo operator -(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        return new PhanSo(tu, mau);
    }

    public static PhanSo operator *(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.TuSo;
        int mau = a.MauSo * b.MauSo;
        return new PhanSo(tu, mau);
    }

    public static PhanSo operator /(PhanSo a, PhanSo b)
    {
        if (b.TuSo == 0)
        {
            throw new DivideByZeroException("Không thể chia cho phân số có tử số bằng 0");
        }
        int tu = a.TuSo * b.MauSo;
        int mau = a.MauSo * b.TuSo;
        return new PhanSo(tu, mau);
    }

    public override string ToString()
    {
        return $"{TuSo}/{MauSo}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        try
        {
            PhanSo ps1 = NhapPhanSo("nhập phân số thứ nhất");
            PhanSo ps2 = NhapPhanSo("nhập phân số thứ hai");

            Console.WriteLine($"Tổng: {ps1} + {ps2} = {ps1 + ps2}");
            Console.WriteLine($"Hiệu: {ps1} - {ps2} = {ps1 - ps2}");
            Console.WriteLine($"Tích: {ps1} * {ps2} = {ps1 * ps2}");
            Console.WriteLine($"Thương: {ps1} / {ps2} = {ps1 / ps2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
        Console.ReadKey();
    }

    static PhanSo NhapPhanSo(string message)
    {
        int tuSo, mauSo;
        while (true)
        {
            Console.WriteLine($"Vui lòng {message} (dạng tử số/mẫu số):");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Dữ liệu nhập không được trống.");
                continue;
            }

            string[] parts = input.Split('/');
            if (parts.Length != 2)
            {
                Console.WriteLine("Dữ liệu nhập không hợp lệ. Vui lòng nhập dạng tử số/mẫu số.");
                continue;
            }

            bool tuSoValid = int.TryParse(parts[0], out tuSo);
            bool mauSoValid = int.TryParse(parts[1], out mauSo);

            if (!tuSoValid || !mauSoValid)
            {
                Console.WriteLine("Tử số và mẫu số phải là số nguyên.");
                continue;
            }

            if (mauSo == 0)
            {
                Console.WriteLine("Mẫu số không được bằng 0. Vui lòng nhập lại.");
                continue;
            }

            break;
        }

        return new PhanSo(tuSo, mauSo);
    }
}
