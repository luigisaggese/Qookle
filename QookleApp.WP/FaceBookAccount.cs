using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Xna.Framework.Media;

namespace QookleApp.Android
{
	public class FaceBookAccount
	{
		public string name {
			get;
			set;
		}

        public dynamic picture { get; set; }
	    
        public string id { get; set; }
	}

    public class MyPicture
    {
        object data { get; set; }
    }

    class MyData
    {
        bool is_silhouette { get; set; }
        string url { get; set; }
    }
}

