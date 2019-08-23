namespace CaptainShop.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        public T Id { get; set; }

        /// <summary>
        /// True if Domain Entity has an Identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}