using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp26
{
    /// <summary>
    /// Modelの基底クラスを表します。
    /// </summary>
    public abstract class Bindable : INotifyPropertyChanged
    {
        /// <summary>
        /// INotifyPropertyChanged の実装 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 既定の初期値でオブジェクトを初期化します。
        /// </summary>
        public Bindable() { }

        /// <summary>
        /// INotifyPropertyChanged.PropertyChangedイベントを発生させます。
        /// </summary>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged == null)
            {
                return;
            }
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
