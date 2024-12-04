using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace Centipede
{
    internal class Game
    {
        private static List<Scene> _scenes;
        private static Scene _currentScene;

        public const int WIN_WIDTH = 800;
        public const int WIN_HEIGHT = 480;

        public Vector2 ballPosition = new Vector2(WIN_WIDTH / 2.0f, WIN_HEIGHT / 2.0f);
        public Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
        public int ballRadius = 20;

        const int WIN_WIDTH_Mid = WIN_WIDTH / 2;

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

            Raylib.InitWindow(WIN_WIDTH, WIN_HEIGHT, "Hello World");

            //timing

            Scene testScene = new TestScene();
            AddScene(testScene);

            while (!Raylib.WindowShouldClose())
            {
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
