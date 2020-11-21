namespace GrupoShemesh.Api.Core.DTOs
{
    public class PaymentMethodDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string ApplicationUserId { get; set; }
    }

    public class PaymentMethodAddOrEitDTO
    {

        public string Code { get; set; }

        public string Description { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
