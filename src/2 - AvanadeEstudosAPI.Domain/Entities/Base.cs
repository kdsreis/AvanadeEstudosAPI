using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;

namespace AvanadeEstudosAPI.Domain.Entities{
    public abstract class Base{

        //Propriedades    
        public int Id { get; set; }
        public DateTime DateAdded { get; protected set; }
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        //Comportamentos
        public virtual void SetDateAdded()
        {
            DateAdded = DateTime.UtcNow;
        }
        private void AddErrorList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
                _errors.Add(error.ErrorMessage);
        }

        private void CleanErrors()
            => _errors.Clear();
               
        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
                builder.Append(" " + error);

            return builder.ToString();
        }
    } 
}