using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace Centipede
{
    internal class Game
    {
        private static List<Scene> _scenes;
        private static Scene _currentScene;

        public const int WIN_WIDTH = 800;
        public const int WIN_HEIGHT = 450;

        float pad1pos = WIN_HEIGHT / 3;
        float pad2pos = WIN_HEIGHT / 3;

        int player1Score = 0;
        int player2Score = 0;

        int squareSize = 5;

        public Vector2 ballPosition = new Vector2(WIN_WIDTH / 2.0f, WIN_HEIGHT / 2.0f);
        public Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
        public int ballRadius = 20;

        const int WIN_WIDTH_Mid = WIN_WIDTH / 2;

        public bool hasBounced = false;

        private static void DrawCenterLineDashed(int winCenter, int height)
        {
            const int LINE_LENGTH = 20;
            const int LINE_SPACING = 10;

            for (var counter = 0; counter < height; counter += LINE_LENGTH + LINE_SPACING)
            {
                Raylib.DrawLineEx(new Vector2(winCenter, counter), new Vector2(winCenter, counter + LINE_LENGTH), 3, Color.Black);
            }
        }

        public static Scene CurrentScene
        {
            get => _currentScene;
            set
            {
                if (_currentScene != null)
                    _currentScene.End();
                _currentScene = value;
                _currentScene.Start();
            }
        }

        public Game()
        {
            _scenes = new List<Scene>();
        }

        public static void AddScene(Scene scene)
        {
            if (!_scenes.Contains(scene))
                _scenes.Add(scene);

            if (_currentScene == null)
                CurrentScene = scene;
        }

        private static bool RemoveScenes(Scene scene)
        {
            bool removed = _scenes.Remove(scene);

            if (_currentScene == scene)
                CurrentScene = GetScene(0);

            return removed;
        }

        public static Scene GetScene(int index)
        {
            if (_scenes.Count <= 0 || _scenes.Count <= index || index < 0)
                return null;

            return _scenes[index];
        }
        public void Run()
        {
            Raylib.SetTargetFPS(60);

            Raylib.InitWindow(WIN_WIDTH, WIN_HEIGHT, "Pong");

            //timing

            Scene testScene = new TestScene();
            AddScene(testScene);

            while (!Raylib.WindowShouldClose())
            {
                Rectangle pad1 = new Rectangle(20, pad1pos, 20, WIN_HEIGHT / 6);
                Rectangle pad2 = new Rectangle(760, pad2pos, 20, WIN_HEIGHT / 6);

                Rectangle ballRect = new Rectangle
                {
                    X = ballPosition.x - ballRadius,
                    Y = ballPosition.y - ballRadius,
                    Width = ballRadius * 2,
                    Height = ballRadius * 2
                };

                // Paddle 1 movement
                if (Raylib.IsKeyDown(KeyboardKey.W)) pad1pos += 10;
                if (Raylib.IsKeyDown(KeyboardKey.S)) pad1pos -= 10;
                if (pad1pos <= 0) pad1pos = 5;
                if (pad1pos >= 375) pad1pos = 370;

                // Paddle 2 movement
                if (Raylib.IsKeyDown(KeyboardKey.Up)) pad2pos += 10;
                if (Raylib.IsKeyDown(KeyboardKey.Down)) pad2pos -= 10;
                if (pad2pos <= 0) pad2pos = 5;
                if (pad2pos >= 375) pad2pos = 370;

                // Ball movement
                ballPosition.x += ballSpeed.x;
                ballPosition.y += ballSpeed.y;

                ballRect.X = ballPosition.x - ballRadius;
                ballRect.Y = ballPosition.y - ballRadius;

                // Check collision with y-axis
                if ((ballPosition.y >= (Raylib.GetScreenHeight() - ballRadius)) || (ballPosition.y <= ballRadius))
                {
                    ballSpeed.y *= -1.0f;
                }

                if (!hasBounced)
                {
                    // Check collision with paddle 1
                    if (Raylib.CheckCollisionCircleRec(ballPosition, ballRadius, pad1))
                    {
                        ballSpeed.x *= -1.0f;
                        hasBounced = true;
                    }

                    // Check collision with paddle 2
                    if (Raylib.CheckCollisionCircleRec(ballPosition, ballRadius, pad2))
                    {
                        ballSpeed.x *= -1.0f;
                        hasBounced = true;
                    }
                }

                if (ballRect.X >= Raylib.GetRenderWidth())
                {
                    player1Score++;
                    ballPosition.x = 400;
                    ballPosition.y = 113;
                }

                if (ballRect.X <= 0)
                {
                    player2Score++;
                    ballPosition.x = 400;
                    ballPosition.y = 113;
                }

                var deltaTime = Raylib.GetFrameTime();

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                DrawCenterLineDashed(WIN_WIDTH_Mid, WIN_HEIGHT);

                CurrentScene.Update(deltaTime);

                Raylib.EndDrawing();
            }

            CurrentScene.End();

            Raylib.CloseWindow();
        }
    }
}
