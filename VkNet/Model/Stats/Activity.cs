using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Stats
{
	/// <summary>
	/// Activity
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(IgnoreUnexpectedArraysConverter<Activity>))]
	public class Activity
	{
		/// <summary>
		/// Количество лайков
		/// </summary>
		[JsonProperty("likes")]
		public long Likes { get; set; }

		/// <summary>
		/// Количество подписчиков
		/// </summary>
		[JsonProperty("subscribed")]
		public long Subscribed { get; set; }

		/// <summary>
		/// Количество неподписавшихся.
		/// </summary>
		[JsonProperty("unsubscribed")]
		public long Unsubscribed { get; set; }
	}
}