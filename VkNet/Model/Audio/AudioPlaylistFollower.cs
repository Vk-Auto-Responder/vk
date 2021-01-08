using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Audio
{
	/// <summary>
	/// Подписчик плейлиста.
	/// </summary>
	[Serializable]
	public class AudioPlaylistFollower
	{
		/// <summary>
		/// Идентификатор владельца.
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор плейлиста.
		/// </summary>
		[JsonProperty("playlist_id")]
		public long PlaylistId { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioPlaylistFollower FromJson(VkResponse response)
		{
			var playlistFollower = new AudioPlaylistFollower
			{
				OwnerId = response["owner_id"],
				PlaylistId = response["playlist_id"]
			};

			return playlistFollower;
		}

	#endregion
	}
}