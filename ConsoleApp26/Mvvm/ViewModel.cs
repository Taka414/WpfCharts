using System.Collections.Generic;
using System.Windows.Media;

namespace ConsoleApp26
{
    /// <summary>
    /// MainWindow用のViewModelを表す
    /// </summary>
    public class ViewModel : ViewModelBase
    {
        //
        // Fields
        // - - - - - - - - - - - - - - - - - - - -

        private ImageSource _ImageSource;

        //
        // Props
        // - - - - - - - - - - - - - - - - - - - -

        public ImageSource ImageSource {
            get { return this._ImageSource; }
            set
            {
                this._ImageSource = value;
                this.RaisePropertyChanged();
            }
        }

        public IList<int> SampleCountList { get; set; } = new List<int>()
        {
            1000,
            2000,
            5000,
            10000,
            20000,
        };

        public int SampleCount { get; set; }

        public int SelectedIndex { get; set; } = 0;

        public int MaxY { get; set; } = 10;

        public int MinY { get; set; } = -10;

        public int PtichY { get; set; } = 2;
    }
}
