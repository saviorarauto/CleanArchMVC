using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, 1, "Product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product with negative Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Create Product with Null Name")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product description", 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product with Empty Name")]
        public void CreateProduct_WithEmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, string.Empty, "Product description", 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product with Short Name")]
        public void CreateProduct_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short! Minimum 3 charecters");
        }


        [Fact(DisplayName = "Create Product with Null Description")]
        public void CreateProduct_WithNullDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product with Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", string.Empty, 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product description with Short Description")]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short! Minimum 5 charecters");
        }


        [Fact(DisplayName = "Create Product price with invalid number")]
        public void CreateProduct_WithInvalidPrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product description", -1, 1, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "Create Product stock with invalid number")] // usado quando tenho parametros no teste de unidade
        [InlineData(-5)]
        //[Fact] => quando eu usar Theory, eu não posso usar Fact
        public void CreateProduct_WithInvalidStock_DomainExceptionInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, value, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }


        [Fact(DisplayName = "Create Product image with Long Length")]
        public void CreateProduct_WithLongLength_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, 1,
                "Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage_Productimage");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product image with Empty String")]
        public void CreateProduct_WithEmptyString_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, 1,
                string.Empty);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product image with Null String")]
        public void CreateProduct_WithNullString_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, 1,
                null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product image with Null String, but with NullException")]
        public void CreateProduct_WithNullString_NullExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 1, 1,
                null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

    }
}
