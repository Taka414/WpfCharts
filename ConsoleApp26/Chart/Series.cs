using System.Collections.Generic;
using System.Windows.Media;

namespace ConsoleApp26
{
    /// <summary>
    /// 1つのグラフの系列を表す
    /// </summary>
    public class Series
    {
        /// <summary>
        /// チャートの系列の名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 系列の色
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// 描画する値
        /// </summary>
        public IList<double> Values { get; set; } = new List<double>();
    }
}
