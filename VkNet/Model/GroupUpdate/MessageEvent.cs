﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Объект, который содержит сообщение и информацию о доступных пользователю функциях.
	/// </summary>
	[Serializable]
	public class MessageEvent
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор чата.
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Идентификатор чата.
		/// </summary>
		[JsonProperty("event_id")]
		public string EventId { get; set; }

		/// <summary>
		/// Идентификатор чата.
		/// </summary>
		[JsonProperty("payload")]
		public string Payload { get; set; }

		/// <summary>
		/// Идентификатор сообщения в чате.
		/// </summary>
		[JsonProperty("conversation_message_id")]
		public long? ConversationMessageId { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static MessageEvent FromJson(VkResponse response)
		{
			return new()
			{
				UserId = response["user_id"],
				PeerId = response["peer_id"],
				EventId = response["event_id"],
				Payload = response["payload"].ToString(),
				ConversationMessageId = response["conversation_message_id"]
			};
		}

	#endregion
	}
}