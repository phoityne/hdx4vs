using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace hdx4vs
{
	public class HaskellContentDefinition
	{
		[Export]
		[Name("Haskell")]
		[BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
		internal static ContentTypeDefinition HaskellContentTypeDefinition;


		[Export]
		[FileExtension(".hs")]
		[ContentType("Haskell")]
		internal static FileExtensionToContentTypeDefinition HaskellFileExtensionDefinition;
	}
}
