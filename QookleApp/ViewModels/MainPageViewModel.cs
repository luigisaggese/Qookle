using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace QookleApp
{
	public class MainPageViewModel:BaseViewModel
	{
		public ObservableCollection<string> ListOfIngred {
			get;
			set;
		}

		public MainPageViewModel ()
		{
			SaveCommand = new Command (new Action(()=>{ListOfIngred = new ObservableCollection<string>(); ListOfIngred.Add("pasta"); OnSubmit();}));
		}
		public Action<IEnumerable<String>> SelectionCompletedAction{ get; set; }
		//tak??? sho robutu todi vsydu obscollection?
		void OnSubmit()
		{
			//NavigationPage. FU BL9t FU NAHUI

			//TIPA TUT TU VUBRAV INGREDIEBNTUListOfIngred
			if (SelectionCompletedAction != null)
				SelectionCompletedAction (ListOfIngred);
			//AHUENNO
			//@
			//TEPER TREBA PIDPUSATUS!
		}

		//je button treba na onclick shob vukonavsia mij metod
		public Command SaveCommand
		{
		    get;
		    internal set;
		}
	}
}
