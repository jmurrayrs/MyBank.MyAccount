using MyBank.MyAccount.Crosscutting.Enums.DomainDataTypes.Documents;

namespace MyBank.MyAccount.Domain.ValueObjects
{
    public class Document
    {
        public string Number { get; private set; } = default!;
        public EnumDocumentType DocumentType { get; private set; } = default!;

        public Document(
            string number,
            EnumDocumentType documentType
        )
        {
            Number = number;
            DocumentType = documentType;
        }
    }
}