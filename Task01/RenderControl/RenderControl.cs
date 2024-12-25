using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Task01
{
    public partial class RenderControl : OpenGL
    {
        private Timer renderTimer;

        public RenderControl()
        {
            InitializeComponent();
            renderTimer = new Timer { Interval = 16 };
            renderTimer.Tick += RenderGL;
            renderTimer.Start();
        }

        private void RenderGL(object sender, EventArgs e)
        {
            glViewport(0, 0, Width, Height);
            glLoadIdentity();
            gluOrtho2D(-4, 2, -2, 2);
            glClear(GL_COLOR_BUFFER_BIT);

            Class1 task = new Class1();
            task.DrawGrid();     // Координатная сетка
            task.DrawFigure();   // Фигура
            task.DrawPoints();   // Точки
        }
    }
}

