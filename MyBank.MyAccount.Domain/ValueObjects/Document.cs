namespace MyBank.MyAccount.Domain.ValueObjects
{
    public class Document
    {
        public string CPF { get; private set; } = default!;
        public Document(string cpf)
        {
            CPF = cpf;
        }
    }
}