namespace CadastroDeCliente
{
    public class ClientList
    {
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birthday { get; set; }

        public int Age => DateTime.Now.Year - Birthday.Year;
    }
}