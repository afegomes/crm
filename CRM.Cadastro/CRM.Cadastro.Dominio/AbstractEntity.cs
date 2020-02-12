namespace CRM.Cadastro.Dominio
{
    public abstract class AbstractEntity
    {
        public long? Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!obj.GetType().Equals(typeof(AbstractEntity)))
            {
                return false;
            }

            var other = obj as AbstractEntity;

            if (!Id.HasValue || !other.Id.HasValue)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }
    }
}