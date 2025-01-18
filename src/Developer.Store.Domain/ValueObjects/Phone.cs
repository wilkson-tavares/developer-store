using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.ValueObjects
{
    public class Phone
    {
        public string Value { get; }

        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone cannot be null or empty.", nameof(value));
            if (!IsValidPhone(value))
                throw new ArgumentException("Invalid phone format.", nameof(value));

            Value = value;
        }

        private bool IsValidPhone(string phone)
        {
            // Implementar a validação do formato do telefone aqui
            // Exemplo: (XX) XXXXX-XXXX
            var regex = new System.Text.RegularExpressions.Regex(@"^\(\d{2}\) \d{5}-\d{4}$");
            return regex.IsMatch(phone);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Phone other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
