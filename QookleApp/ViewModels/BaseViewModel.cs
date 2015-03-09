namespace QookleApp
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The base view model.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        public BaseViewModel()
        {
        }

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// The on property chnaged.
        /// </summary>
        /// <param name="propName">
        /// The prop name.
        /// </param>
        public void OnPropertyChnaged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}