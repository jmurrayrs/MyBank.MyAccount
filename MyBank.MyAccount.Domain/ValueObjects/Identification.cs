namespace MyBank.MyAccount.Domain.ValueObjects
{
    public sealed class Identification
    {
        public string Name { get; private set; } = default!;
        public string LastName { get; private set; } = default!;

        public Identification()
        { }
    }
}