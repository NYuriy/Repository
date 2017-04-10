using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAwards.Models.Helpers
{
	/// <summary>
	/// thr Base helper class.
	/// </summary>
	public static class BaseHelper
	{
		/// <summary>
		/// Gets get image data.
		/// </summary>
		/// <param name="databytes"></param>
		/// <returns></returns>
		public static byte[] GetImageData(string databytes)
		{
			var tempAry = databytes.Split('-');
			var imageData = new byte[tempAry.Length];
			for (int i = 0; i < tempAry.Length; i++)
				imageData[i] = Convert.ToByte(tempAry[i], 16);
			return imageData;
		}
	}
}