using Domain.SharedKernel.Abstractions;
using Domain.Supplier.Events;
using Domain.Supplier.ValueObjects;

namespace Domain.Supplier
{
    public sealed class Supplier : Entity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Email Email { get; private set; } 
        public PhoneNumber PhoneNumber {  get; private set; }

        private Supplier(
             Guid id,
             string name,
             string address,
             Email email,
             PhoneNumber phoneNumber) : base(id)

        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static Supplier Create(
            string name,
            string address,
            Email email,
            PhoneNumber phoneNumber)
        {
            var supplier = new Supplier(
                Guid.NewGuid(),
                name,
                address,
                email,
                phoneNumber);

            supplier.RaiseDomainEvents(new SupplierCreateDomainEvent(supplier.Id));

            return supplier;
        }
        
        public void EditEmail(Email email) 
        {
            Email = email;
        }

        public void EditAdress(string address)
        {
            Address = address; 
        }

    } 
}
