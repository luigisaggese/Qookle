using System;
using System.ComponentModel;
namespace QookleApp
{
	public class BaseViewModel:INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public void OnPropertyChnaged(String propName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propName));
		}

		public BaseViewModel ()
		{
		}
	}
}

