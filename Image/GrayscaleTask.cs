using System;

namespace Recognizer
{
    public static class GrayscaleTask
    {
        /* 
         * Переведите изображение в серую гамму.
         * 
         * original[x, y] - массив пикселей с координатами x, y. 
         * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
         * 
         * Получившийся массив должен иметь те же размеры, 
         * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
         *
         * Используйте формулу:
         * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
         * 
         * Почему формула именно такая — читайте в википедии 
         * http://ru.wikipedia.org/wiki/Оттенки_серого
         */

        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var width = original.GetLength(0);
            var length = original.GetLength(1);
            var grayscale = new double[width, length];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    var pixelR = Convert.ToDouble(original[i, j].R);
                    var pixelG = Convert.ToDouble(original[i, j].G);
                    var pixelB = Convert.ToDouble(original[i, j].B);
                    var toGray = (0.299 * pixelR + 0.587 * pixelG + 0.114 * pixelB) / 255;
                    grayscale[i, j] = toGray;
                }
            }

            return grayscale;
        }
    }
}