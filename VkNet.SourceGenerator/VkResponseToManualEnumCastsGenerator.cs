﻿using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace VkNet.SourceGenerator
{
	[Generator]
	public class VkResponseToManualEnumCastsGenerator : VkResponseImplicitGeneratorBase<VkResponseToManualEnumCastsReceiver>
	{
		/// <inheritdoc />
		protected override string GetSourceCode()
		{
			var sb = new StringBuilder();
			sb.AppendLine("// DO NOT EDIT THIS FILE CAUSE ALL CHANGES WILL BE DELETED AUTOMATICALLY");
			sb.AppendLine();

			foreach (var usingName in Receiver.CandidateUsingList)
			{
				sb.AppendLine($"using {usingName};");
			}

			sb.AppendLine();
			sb.AppendLine("namespace VkNet.Utils");
			sb.AppendLine("{");
			sb.AppendLine("\tpublic partial class VkResponse");
			sb.AppendLine("\t{");

			foreach (var className in Receiver.CandidateClasses.Distinct())
			{
				if (!Receiver.DefaultValues.ContainsKey(className))
				{
					continue;
				}

				sb.AppendLine("\t\t/// <summary>");
				sb.AppendLine($"\t\t/// Преобразовать <see cref=\"{className}\" /> из <see cref=\"VkResponse\" />");
				sb.AppendLine("\t\t/// </summary>");
				sb.AppendLine("\t\t/// <param name=\"response\"> Ответ сервера vk.com. </param>");
				sb.AppendLine("\t\t/// <returns>");
				sb.AppendLine($"\t\t/// Результат преобразования в <see cref=\"{className}\" />.");
				sb.AppendLine("\t\t/// </returns>");
				sb.AppendLine($"\t\tpublic static implicit operator {className}(VkResponse response)");
				sb.AppendLine("\t\t{");

				sb.AppendLine(
					$"\t\t\treturn response == null ? {className}.{Receiver.DefaultValues[className]} : Utilities.EnumFrom<{className}>(response);");

				sb.AppendLine("\t\t}");
				sb.AppendLine();
			}

			sb.AppendLine("\t}");
			sb.AppendLine("}");

			return sb.ToString();
		}
	}
}