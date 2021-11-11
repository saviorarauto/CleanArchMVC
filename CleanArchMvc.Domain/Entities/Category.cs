using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity //Herdando da classe abstrata Entity, não preciso mais declarar o Id
    {
        //public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name); //obs: no final da validação, ele passa o Name = name
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length< 3,
    "Invalid name, too short! Minimum 3 charecters");

            Name = name;
        }

        //Propriedades de navegação não fazem parte do modelo de Domínio, por isso, não é necessário colocar private set;
        public ICollection<Product> Products { get; set; }
    }
}
