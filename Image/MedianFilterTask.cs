using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		/* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */

        public static double MedianPixel (int vPix, int hPix, double[,] original)
        {
            var pixelsList = new List<double>();
            var hLength = original.GetLength(0);
            var vLength = original.GetLength(1);

            for (var h = hPix - 1; h <= hPix + 1; h++) //перебираем значения по вертикали
            {
                if (h < 0 || h + 1> hLength) continue; 
                // если вышли за границы дозволенного - проходим мимо
                for (var v = vPix - 1; v <= vPix + 1; v++) // по горизонтали
                {
                    if (v < 0 || v + 1 > vLength) continue;
                    pixelsList.Add(original[h,v]); //собираем массив из значений
                }
            }

            pixelsList.Sort(); // сортируем массив по значениям
            var medianIndex = pixelsList.Count / 2;
            if (pixelsList.Count == 2)
                return (pixelsList[0] + pixelsList[1]) / 2; // граничный случай, если пикселей два
            if (pixelsList.Count % 2 != 0) return pixelsList[medianIndex]; // если нечетно, то медиана четко определена
            if (pixelsList.Count % 2 % 2 == 0) // если четное, то соседнее слева
                return (pixelsList[medianIndex] + pixelsList[medianIndex - 1]) / 2;
            return (pixelsList[medianIndex] + pixelsList[medianIndex + 1]) / 2; // иначе справа
        }

		public static double[,] MedianFilter(double[,] original)
		{
            var rightCorner = original.GetLength(0);
            var bottomCorner = original.GetLength(1);
            var medianGreyscale = new double[rightCorner, bottomCorner];
            
            for (var hPix = 0; hPix < rightCorner; hPix++)
            for (var vPix = 0; vPix < bottomCorner; vPix++)
                medianGreyscale[hPix, vPix] = MedianPixel(vPix, hPix, original);
            return medianGreyscale; 
		}
	}
}