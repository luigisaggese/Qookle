﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
	public class CustomList:ListView
	{
		List<Object> visibleItems = new List<object> ();
		public Action OnScrolledToEnd{ get; set; }
		public CustomList ()
		{
			BackgroundColor = Color.Transparent;
			this.ItemTapped += (object sender, ItemTappedEventArgs e) => 
			{
				if(e.Item.GetType()==typeof(Recipe))
				this.Navigation.PushAsync(new RecipeDetailedPage (((Recipe)e.Item)));
			};
			this.ItemAppearing+= (sender, e) => {
				if(!visibleItems.Contains(e.Item))
				{
					visibleItems.Add(e.Item);
					var Items=((IEnumerable<Object>)ItemsSource).ToList();
					var count=Items.Count();
					if(count>0)
					if(e.Item==Items[count-1])
					if(OnScrolledToEnd!=null)
						OnScrolledToEnd();

				}

				};
			this.ItemDisappearing+=(sender,e)=>{
				visibleItems.Remove(e.Item);
			};
		}
	}
}

