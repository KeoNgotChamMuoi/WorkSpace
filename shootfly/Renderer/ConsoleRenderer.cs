using System;
using System.Collections.Generic;
using System.Text;
using ConsoleShooter.Entities;

namespace ConsoleShooter.Renderer
{
    public class ConsoleRenderer
    {
        private readonly int width;
        private readonly int height;

        public ConsoleRenderer(int w, int h)
        {
            width = w;
            height = h;

            // Ẩn con trỏ chuột
            Console.CursorVisible = false;

            // Chỉ đặt kích thước khi chạy trên Windows để tránh cảnh báo CA1416
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    Console.SetWindowSize(Math.Min(w + 1, Console.LargestWindowWidth), 
                                          Math.Min(h + 2, Console.LargestWindowHeight));
                    Console.SetBufferSize(Math.Min(w + 1, Console.LargestWindowWidth), 
                                          Math.Min(h + 2, Console.LargestWindowHeight));
                }
                catch
                {
                    // Nếu terminal không hỗ trợ thay đổi kích thước thì bỏ qua
                }
            }

            Console.Clear();
        }

        public void Render(Player player, List<Enemy> enemies, List<Bullet> bullets)
        {
            // Buffer 2D ký tự
            char[,] buffer = new char[height, width];

            // Điền trống
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    buffer[y, x] = ' ';

            // Vẽ player
            if (player.Y >= 0 && player.Y < height && player.X >= 0 && player.X < width)
                buffer[player.Y, player.X] = player.Symbol;

            // Vẽ enemy
            foreach (var e in enemies)
                if (e.Y >= 0 && e.Y < height && e.X >= 0 && e.X < width)
                    buffer[e.Y, e.X] = e.Symbol;

            // Vẽ đạn
            foreach (var b in bullets)
                if (b.Y >= 0 && b.Y < height && b.X >= 0 && b.X < width)
                    buffer[b.Y, b.X] = b.Symbol;

            // HUD (dòng thông tin)
            string hud = $" SCORE: {player.Score}   ENEMIES: {enemies.Count}   (←/→) Move  Space: Fire  Esc: Quit ";
            if (hud.Length > width) hud = hud.Substring(0, width);
            for (int i = 0; i < hud.Length; i++)
                buffer[0, i] = hud[i];

            // Dựng frame vào string
            StringBuilder sb = new();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    sb.Append(buffer[y, x]);
                sb.Append('\n');
            }

            // Hiển thị frame — không dùng Clear() để tránh flicker
            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }
    }
}
