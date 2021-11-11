using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity //Herdando da classe abstrata Entity, não preciso mais declarar o Id
    {
        //public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
    "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
    "Invalid name, too short! Minimum 3 charecters");

            Name = name;

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
"Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
    "Invalid description, too short! Minimum 3 charecters");

            Description = description;

            DomainExceptionValidation.When(price < 0,
"Invalid price value");

            Price = price;

            DomainExceptionValidation.When(stock < 0,
"Invalid stock value");

            Stock = stock;

            DomainExceptionValidation.When(image.Length>250,
"Invalid image name, too long, maximum 250 characters");

            Image = image;

        }

        //Propriedades de navegação não fazem parte do modelo de Domínio, por isso, não é necessário colocar private set;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
