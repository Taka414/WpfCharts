using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ConsoleApp26
{
    /// <summary>
    /// 超簡易版チャート描画ライブラリ
    /// </summary>
    public class SimpleChart
    {
        //
        // Props
        // - - - - - - - - - - - - - - - - - - - -

        // Y軸の下限・上限の指定
        public double MaxAxisY { get; set; }
        public double MinAxisY { get; set; }

        // Y軸の罫線の幅
        public double YGridPtich { get; set; }

        // 罫線の色
        public Color AxisColor { get; set; } = Color.FromRgb(160, 160, 160);

        // グラフの背景色
        public Color BackGroundColor { get; set; } = Colors.White;

        // グラフの値
        public IList<Series> SeriesList { get; set; } = new List<Series>();

        //
        // Public Methods
        // - - - - - - - - - - - - - - - - - - - -

        // 指定した内容でチャートのビットマップをする
        public Rgb24ImageBuffer CreateChart(int imageWidth, int imageHeight)
        {
            var buffer = new Rgb24ImageBuffer(imageWidth, imageHeight);

            // 背景を塗りつぶす
            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    buffer.SetPixel(x, y, this.BackGroundColor);
                }
            }

            if (this.SeriesList.Count == 0)
            {
                return buffer;
            }

            // 1点ごとの幅を表す
            double bt = imageWidth / (double)this.SeriesList.Max(s => s.Values.Count);

            double yd = Math.Abs(this.MinAxisY);

            double baseY = this.MinAxisY + yd; // Y原点を0基準にした値

            double ydist = (this.MaxAxisY + yd) - (this.MinAxisY + yd);

            double yPitch = imageHeight / ydist;

            this.writeGrid(imageWidth, imageHeight, buffer, yd, ydist, yPitch);

            this.writeSeries(imageHeight, buffer, bt, yd, yPitch);

            return buffer;
        }

        //
        // Private Methods
        // - - - - - - - - - - - - - - - - - - - -

        // チャートを描画する
        private void writeSeries(int imageHeight, Rgb24ImageBuffer buffer, double bt, double yd, double yPitch)
        {
            foreach (Series series in this.SeriesList)
            {
                for (int i = 0; i < series.Values.Count; i++)
                {
                    int point_x = (int)Math.Floor(bt * i);
                    int point_y = (int)Math.Floor(imageHeight - Math.Abs(yPitch * (series.Values[i] - yd)));

                    if (point_y >= imageHeight)
                    {
                        point_y = imageHeight - 1;
                    }
                    else if (point_y < 0)
                    {
                        point_y = 0;
                    }

                    buffer.SetPixel(point_x, point_y, series.LineColor);
                }
            }
        }

        // 罫線を引く
        private void writeGrid(int imageWidth, int imageHeight, Rgb24ImageBuffer buffer, double yd, double ydist, double yPitch)
        {
            // Y軸の中央の高さ
            int center_y = (int)Math.Floor(imageHeight - Math.Abs(yPitch * (ydist - yd)));

            // 中央に線を引く
            for (int x = 0; x < imageWidth; x++)
            {
                buffer.SetPixel(x, center_y, this.AxisColor);
            }

            // 中央より下側のY軸罫線
            int index = 0;
            while (true)
            {
                int y = (int)(center_y + yPitch * index * this.YGridPtich);

                if (y >= imageHeight - 1)
                {
                    break;
                }

                for (int x = 0; x < imageWidth; x++)
                {
                    if (x % 7 > 2)
                    {
                        buffer.SetPixel(x, y, this.AxisColor);
                    }
                }

                index++;
            }

            // 中央より上側のY軸罫線
            index = 0;
            while (true)
            {
                int y = (int)(center_y - yPitch * index * this.YGridPtich);

                if (y < 0)
                {
                    break;
                }

                for (int x = 0; x < imageWidth; x++)
                {
                    if (x % 7 > 2)
                    {
                        buffer.SetPixel(x, y, this.AxisColor);
                    }
                }

                index++;
            }

            // X軸の罫線を引く
            double xPitch = imageWidth / 10;
            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    if (x % xPitch == 0 && y % 7 > 2)
                    {
                        buffer.SetPixel(x, y, this.AxisColor);
                    }
                }
            }
        }
    }
}
