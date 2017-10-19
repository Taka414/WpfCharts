using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp26
{
    /// <summary>
    /// ViewModelの基底クラスを表します。
    /// </summary>
    public abstract class ViewModelBase : Bindable, IDataErrorInfo
    {
        /// <summary>IDataErrorInfo用のエラーメッセージを保持する辞書 </summary>
        private Dictionary<string, string> _ErrorMessages = new Dictionary<string, string>();

        /// <summary>
        /// IDataErrorInfo の実装 
        /// </summary>
        public string Error
        {
            get { return (this._ErrorMessages.Count > 0) ? "Has Error" : null; }
        }

        /// <summary>
        /// IDataErrorInfo の実装
        /// </summary>
        public string this[string columnName]
        {
            get
            {
                if (this._ErrorMessages.ContainsKey(columnName))
                {

                    return this._ErrorMessages[columnName];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// エラーメッセージを設定します。
        /// </summary>
        protected void SetError(string propName, string message)
        {
            this._ErrorMessages[propName] = message;
        }

        /// <summary>
        /// 指定したメッセージメッセージを削除します。
        /// </summary>
        protected void ClearErrror(string propName)
        {
            if (this._ErrorMessages.ContainsKey(propName))
            {
                this._ErrorMessages.Remove(propName);
            }
        }
    }
}
