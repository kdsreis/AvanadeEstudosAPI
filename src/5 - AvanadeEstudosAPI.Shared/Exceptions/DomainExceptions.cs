using System;

namespace AvanadeEstudosAPI.Shared.Exceptions
{
    public class DomainExceptions : System.Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public DomainExceptions() { }       
        public DomainExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected DomainExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public DomainExceptions(string message, List<string> errors) : base(message)
        { 
             _errors = errors;
        }        
    }
}
