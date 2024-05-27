using Raylib_cs;
using System.Numerics;

namespace Asad_Muhammad_a2_Toy
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 700;
            const int screenHeight = 500;

            Raylib.InitWindow(screenWidth, screenHeight, "2D Interactive Toy Project");
            Raylib.SetTargetFPS(60);

            // Array to grip graphic positions
            Vector2[] positions = new Vector2[5];
            Random random = new Random();

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector2(random.Next(screenWidth), random.Next(screenHeight));
            }

            while (!Raylib.WindowShouldClose())
            {
                //Refurbish
                if (Raylib.IsMouseButtonPressed(MouseButton.Forward))
                {
                    Vector2 mousePosition = Raylib.GetMousePosition();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        if (Raylib.CheckCollisionPointCircle(mousePosition, positions[i], 19))
                        {
                            positions[i] = mousePosition;
                        }
                    }
                }

                //Make
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                for (int i = 0; i < positions.Length; i++)
                {
                    DrawCompoundGraphic(positions[i].X, positions[i].Y);
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        //Function to Make compound graphic for exact location
        static void DrawCompoundGraphic(float x, float y)
        {
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.White, Color.Brown };

            //Make a House: rectangle for base and square for the roof
            Raylib.DrawRectangle((int)x - 19, (int)y - 19, 38, 38, colors[0]);
            Raylib.DrawTriangle(new Vector2(x - 24, y - 19),
                              new Vector2(x + 24, y - 19),
                              new Vector2(x, y - 59),
                              colors[1]
                           );

            //Make windows: small rectangles
            Raylib.DrawRectangle((int)x - 14, (int)y - 14, 9, 9, colors[2]);
            Raylib.DrawRectangle((int)x + 4, (int)y - 14, 9, 9, colors[3]);

            //Make door: rectangle
            Raylib.DrawRectangle((int)x - 4, (int)y + 0, 5, 10, colors[4]);

        }
    }
}












