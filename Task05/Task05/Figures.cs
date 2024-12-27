using System;
using System.Runtime.InteropServices;

namespace Task05
{
    public partial class RenderControl
    {
        public class Figures
        {
            public delegate void outText(string s, double x, double y, double z);
            public outText Print;

            public void Grid(double size, double step = 1.0)
            {
                glDisable(GL_LIGHTING);
                glLineWidth(0.5f);
                glColor3ub(200, 200, 200);

                glBegin(GL_LINES);
                for (double i = -size; i <= size; i += step)
                {
                    glVertex3d(i, 0, -size);
                    glVertex3d(i, 0, size);

                    glVertex3d(-size, 0, i);
                    glVertex3d(size, 0, i);
                }
                glEnd();

                glEnable(GL_LIGHTING);
            }

            public void CoordinateLines(double x, double y, double z)
            {
                glDisable(GL_LIGHTING);
                glLineWidth(2.5f);
                glBegin(GL_LINES);
                glColor3ub(0, 0, 200);
                glVertex3d(x, y, z);
                glVertex3d(x + 2, y, z);

                glColor3ub(0, 200, 0);
                glVertex3d(x, y, z);
                glVertex3d(x, y + 2, z);

                glColor3ub(200, 0, 0);
                glVertex3d(x, y, z);
                glVertex3d(x, y, z + 2);
                glEnd();

                Print?.Invoke("X", x + 2, y, z);
                Print?.Invoke("Y", x, y + 2, z);
                Print?.Invoke("Z", x, y, z + 2);
            }

            public void Sphere(double x0, double y0, double z0, double radius, int slices = 20, int stacks = 20)
            {
                glPushMatrix();
                glTranslated(x0, y0, z0);

                for (int i = 0; i < stacks; i++)
                {
                    double phi1 = Math.PI * i / stacks;
                    double phi2 = Math.PI * (i + 1) / stacks;

                    glBegin(GL_QUAD_STRIP);
                    for (int j = 0; j <= slices; j++)
                    {
                        double theta = 2.0 * Math.PI * j / slices;

                        double x1 = radius * Math.Sin(phi1) * Math.Cos(theta);
                        double y1 = radius * Math.Cos(phi1);
                        double z1 = radius * Math.Sin(phi1) * Math.Sin(theta);

                        double x2 = radius * Math.Sin(phi2) * Math.Cos(theta);
                        double y2 = radius * Math.Cos(phi2);
                        double z2 = radius * Math.Sin(phi2) * Math.Sin(theta);

                        glColor3ub(150, 100, 255);
                        glVertex3d(x1, y1, z1);
                        glVertex3d(x2, y2, z2);
                    }
                    glEnd();
                }

                glPopMatrix();
            }

            public void Cylinder(double x0, double y0, double z0, double radius, double height, int slices = 20)
            {
                glPushMatrix();
                glTranslated(x0, y0, z0);

                glBegin(GL_QUAD_STRIP);
                for (int i = 0; i <= slices; i++)
                {
                    double theta = 2.0 * Math.PI * i / slices;

                    double x1 = radius * Math.Cos(theta);
                    double z1 = radius * Math.Sin(theta);

                    glColor3ub(200, 200, 100);
                    glVertex3d(x1, 0, z1);
                    glVertex3d(x1, height, z1);
                }
                glEnd();

                glPopMatrix();
            }

            public void Disc(double x0, double y0, double z0, double radiusOuter, double radiusInner, int slices = 20)
            {
                glPushMatrix();
                glTranslated(x0, y0, z0);

                glBegin(GL_QUAD_STRIP);
                for (int i = 0; i <= slices; i++)
                {
                    double theta = 2.0 * Math.PI * i / slices;

                    double xOuter = radiusOuter * Math.Cos(theta);
                    double zOuter = radiusOuter * Math.Sin(theta);
                    double xInner = radiusInner * Math.Cos(theta);
                    double zInner = radiusInner * Math.Sin(theta);

                    glColor3ub(255, 200, 100);
                    glVertex3d(xOuter, 0, zOuter);
                    glVertex3d(xInner, 0, zInner);
                }
                glEnd();

                glPopMatrix();
            }

        }
    }
}