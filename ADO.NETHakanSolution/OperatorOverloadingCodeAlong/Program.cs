using System;

namespace OperatorOverloadingCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            Box gubbensLåda = new Box(100, 50, 50);
            Box gummansLåda = new Box(100, 51, 48);

            if (Box.LessThan(gubbensLåda, gummansLåda))
                Console.WriteLine($"{gubbensLåda} is smaller than {gummansLåda}");

            if (Box.GreaterThan(gubbensLåda, gummansLåda))
                Console.WriteLine($"{gubbensLåda} is bigger than {gummansLåda}");

            if (gubbensLåda < gummansLåda)
                Console.WriteLine($"{gubbensLåda} is smaller than {gummansLåda}");

            if (gubbensLåda > gummansLåda)
                Console.WriteLine($"{gubbensLåda} is bigger than {gummansLåda}");

            if (gubbensLåda == gummansLåda)
                Console.WriteLine("You boxes have the same volume.");

            if (gubbensLåda != gummansLåda)
                Console.WriteLine("Your boxes have different volumes.");

        }
    }
}
