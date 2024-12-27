using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using static Task02.RenderControl;

namespace Task02
{
    public partial class RenderControl : OpenGL
    {
        public uint DrawMode { get; set; } = GL_FILL;
        public int TilesVertical { get; set; } = 1;
        public int TilesHorizontal { get; set; } = 1;
        figure _f = new figure();

        public RenderControl()
        {
            InitializeComponent();
        }

        private void OnRender(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT);
            glLoadIdentity();

            // Установить квадратное окно просмотра
            if (Width > Height)
                glViewport((Width - Height) / 2, 0, Height, Height);
            else
                glViewport(0, (Height - Width) / 2, Width, Width);

            // Рассчитать коэффициент масштаба
            double scaleFactor = Math.Max(TilesHorizontal, TilesVertical);
            glOrtho(
                -150 * scaleFactor, 350 * scaleFactor,  // Горизонтальные границы
                -150 * scaleFactor, 150 * scaleFactor,  // Вертикальные границы
                -1, 1                                   // Глубина
            );

            // Размер стороны фигуры и высота треугольника
            double sideSize = 100;
            double height = Math.Sqrt(3) / 2 * sideSize;

            // Рисование фигур в сетке
            for (int row = 0; row < TilesVertical; row++)
            {
                for (int col = 0; col < TilesHorizontal; col++)
                {
                    // Смещение по X и Y для текущей фигуры
                    double offsetX = col * 1.5 * sideSize;
                    double offsetY = row * 2 * height;

                    // Смещение для нечетных колонок
                    if (col % 2 != 0)
                        offsetY -= height;

                    // Отрисовка фигуры
                    _f.DrawComplexFigure(sideSize, DrawMode, offsetX, offsetY);
                }
            }

            glDisable(GL_LINES);
        }

    }
}