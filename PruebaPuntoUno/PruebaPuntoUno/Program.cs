namespace PruebaPuntoUno
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrimerArray();
            program.SegundoArray();
            program.TercerArray();
            program.CuartoArray();
            program.QhintoArray();
        }

        public void PrimerArray()
        {
            Console.WriteLine(ContTripletas([1, 2, 3, 4, 3]));
        }

        public void SegundoArray()
        {
            Console.WriteLine(ContTripletas([1, 1, 1, 3, 3, 2, 2, 2]));
        }

        public void TercerArray()
        {
            Console.WriteLine(ContTripletas([0, 0, 5, 9, 9, 9, 3, 2]));
        }

        public void CuartoArray()
        {
            Console.WriteLine(ContTripletas([1, 1, 1, 1, 1, 1, 1]));
        }

        public void QhintoArray()
        {
            Console.WriteLine(ContTripletas([0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]));
        }

        public int ContTripletas(int[] nums)
        {
            if (nums == null || nums.Length < 3) { return 0; }
            int count = 0; for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] == nums[i + 1] && nums[i + 1] == nums[i + 2])
                {
                    count++; 
                    i = i + 2;
                }
            }
            return count;
        }
    }
}
