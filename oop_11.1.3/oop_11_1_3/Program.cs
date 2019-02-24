using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintable printer = PrinterCreator.create(PrinterType.CONSOLE);

            printer.print("Input count of elements in vector:");
            int n = UserInput.inputInt();

            int[] intArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                printer.print("Input element №" + i);
                intArray[i] = UserInput.inputInt();
            }

            Vector vector = new Vector(intArray);
            int sumOfElem = Calculator.sumOfElemBetweenFirstAndLastZero(vector);
            int prodOfElem = Calculator.prodOfEvenElem(vector);
            int firstZero = Calculator.indexOfFirstZero(vector);
            int lastZero = Calculator.indexOfLastZero(vector);

            printer.print("product of even elements = " + prodOfElem);
            printer.print("sum of elements between first and last zero = " + sumOfElem);
            printer.print("index of first zero = " + firstZero);
            printer.print("index of last zero = " + lastZero);

            Console.ReadKey();
        }
    }
    public class Vector
    {
        private int[] elements;

        public Vector(int[] elements)
        {
            this.elements = elements;
        }

        public int[] getElements()
        {
            return elements;
        }

        public void setElements(int[] elements)
        {
            if (elements != null)
            {
                this.elements = elements;
            }
        }

    }
    public class Calculator
    {
        public static int prodOfEvenElem(Vector vector)
        {
            int prodOfElem = 1;

            if (vector == null)
            {
                return prodOfElem;
            }

            int[] intArray = vector.getElements();

            if (intArray == null)
            {
                return prodOfElem;
            }

            for (int i = 0; i < intArray.Length; i += 2)
            {
                prodOfElem *= intArray[i];
            }

            return prodOfElem;
        }

        public static int sumOfElemBetweenFirstAndLastZero(Vector vector)
        {
            int sumOfElem = 0;

            if (vector == null)
            {
                return sumOfElem;
            }

            int[] intArray = vector.getElements();

            if (intArray == null)
            {
                return sumOfElem;
            }

            int indexFirst = indexOfFirstZero(vector);
            int indexLast = indexOfLastZero(vector);

            if (indexFirst == -1 || indexLast == -1)
            {
                return sumOfElem;
            }

            for (int i = indexFirst; i < indexLast; i++)
            {
                sumOfElem += intArray[i];
            }

            return sumOfElem;
        }

        public static int indexOfFirstZero(Vector vector)
        {
            int indexFirst = -1;

            if (vector == null)
            {
                return indexFirst;
            }

            int[] doubleArray = vector.getElements();

            if (doubleArray == null || doubleArray.Length < 1)
            {
                return indexFirst;
            }

            for (int i = 0; i < doubleArray.Length; i++)
            {
                if (doubleArray[i] == 0)
                {
                    return i;
                }
            }
            return indexFirst;
        }

        public static int indexOfLastZero(Vector vector)
        {
            int indexLast = -1;

            if (vector == null)
            {
                return indexLast;
            }

            int[] doubleArray = vector.getElements();

            if (doubleArray == null || doubleArray.Length < 1)
            {
                return indexLast;
            }

            for (int i = doubleArray.Length - 1; i >= 0; i--)
            {
                if (doubleArray[i] == 0)
                {
                    return i;
                }
            }
            return indexLast;
        }
    }
    public class UserInput
    {
        public static double inputDouble()
        {
            return double.Parse(Console.ReadLine());
        }

        public static int inputInt()
        {
            return int.Parse(Console.ReadLine());
        }
    }
    public class PrinterCreator
    {
        public static IPrintable create(PrinterType printerType)
        {
            IPrintable printer = null;

            switch (printerType)
            {
                case PrinterType.CONSOLE:
                    {
                        printer = new ConsolePrint();
                        break;
                    }
            }

            return printer;
        }
    }
    public interface IPrintable
    {
        void print(Object o);
    }
    public enum PrinterType
    {
        CONSOLE
    }
    public class ConsolePrint : IPrintable
    {

        public void print(Object o)
        {
            if (o == null)
            {
                return;
            }
            Console.WriteLine(o);
        }
    }
}
