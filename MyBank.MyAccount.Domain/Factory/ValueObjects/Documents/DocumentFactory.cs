using MyBank.MyAccount.Crosscutting.Enums.DomainDataTypes.Documents;
using MyBank.MyAccount.Domain.ValueObjects;

namespace MyBank.MyAccount.Domain.Factory.ValueObjects.Documents
{
    public sealed class DocumentFactory
    {
        public static Document Create(
            string number,
            EnumDocumentType documentType
        ) => new Document(number, documentType);
    }
}